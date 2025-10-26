using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.IO;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace ImRecall;

public interface IImmichUploadService
{
    Task UploadAsync(string filename, Bitmap bitmap, CancellationToken token = default);
}

public partial class ImmichUploadService(IAssetsApi assetsApi) : IImmichUploadService
{
    private readonly RecyclableMemoryStreamManager _memoryStreamManager = new();

    public async Task UploadAsync(string filename, Bitmap bitmap, CancellationToken token = default)
    {
        await using var stream = _memoryStreamManager.GetStream();
        bitmap.Save(stream, ImageFormat.Png);

        stream.Position = 0;
        Span<byte> hash = stackalloc byte[20];
        if (SHA1.HashData(stream, hash) < 20)
        {
            throw new InvalidOperationException("Failed to compute SHA-1 hash.");
        }

        var hashString = Convert.ToHexStringLower(hash);

        stream.Position = 0;
        var response = await assetsApi.CheckBulkUploadAsync(new AssetBulkUploadCheckDto([
            new AssetBulkUploadCheckItem(hashString, filename)
        ]), token);

        if (!response.TryOk(out var dto))
        {
            return;
        }

        var result = dto.Results[0];
        if (result.Action != AssetBulkUploadCheckResult.ActionEnum.Accept)
        {
            return;
        }

        var response2 = await assetsApi.UploadAssetAsync(
            assetData: stream,
            deviceAssetId: WhitespaceRegex.Replace(
                $"{Path.GetFileNameWithoutExtension(filename)}-{stream.Length}", ""),
            deviceId: "ImRecall",
            fileCreatedAt: DateTime.Now,
            fileModifiedAt: DateTime.Now,
            metadata: [],
            filename: filename,
            isFavorite: false,
            cancellationToken: token
        );
        if (!response2.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Failed to upload asset: {response2.StatusCode} {response2.ReasonPhrase}");
        }
    }

    [GeneratedRegex(@"\s+", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    private static partial Regex WhitespaceRegex { get; }
}