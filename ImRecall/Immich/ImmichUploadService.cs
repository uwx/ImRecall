using System.Drawing;
using System.Globalization;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Maxine.Fetch;
using Microsoft.IO;
using Org.OpenAPITools.Model;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using static Maxine.Fetch.Fetch;

namespace ImRecall;

public interface IImmichUploadService
{
    Task UploadAsync(string filename, Bitmap bitmap, CancellationToken token = default);
}

public partial class ImmichUploadService(ImmichAuth auth) : IImmichUploadService
{
    private readonly RecyclableMemoryStreamManager _memoryStreamManager = new();

    private const string AlbumName = "ImRecall";

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
        
        var baseUri = new Uri(auth.Url);
        var authKey = auth.Key;
        
        using var bulkUploadCheck = await FetchAsync(new Request
        {
            RequestUri = new Uri(baseUri, "/api/assets/bulk-upload-check"),
            Method = HttpMethod.Post,
            Body = RequestBody.Json(new AssetBulkUploadCheckDto(assets:
            [
                new AssetBulkUploadCheckItem(checksum: hashString, id: filename)
            ]), ImmichJsonContext.WithConverters.AssetBulkUploadCheckDto),
            Headers =
            {
                { "Accept", "application/json" },
                { "x-api-key", authKey },
            }
        }, token);
        if (!bulkUploadCheck.Ok)
        {
            throw new InvalidOperationException($"Failed bulk upload check: {bulkUploadCheck.Status} {bulkUploadCheck.StatusText}");
        }

        var result = (await bulkUploadCheck.Json<AssetBulkUploadCheckResponseDto>(cancellationToken: token, typeInfo: ImmichJsonContext.WithConverters.AssetBulkUploadCheckResponseDto))!.Results[0];
        string uploadedAssetId;
        if (result.Action == AssetBulkUploadCheckResult.ActionEnum.Accept)
        {
            using var uploadAsset = await FetchAsync(new Request
            {
                RequestUri = new Uri(baseUri, "/api/assets"),
                Method = HttpMethod.Post,
                Body = new FormData()
                    .Append("deviceAssetId", WhitespaceRegex.Replace($"{Path.GetFileNameWithoutExtension(filename)}-{stream.Length}", ""))
                    .Append("deviceId", "ImRecall")
                    .Append("fileCreatedAt", DateTime.Now.ToString("o", CultureInfo.InvariantCulture))
                    .Append("fileModifiedAt", DateTime.Now.ToString("o", CultureInfo.InvariantCulture))
                    .Append("fileSize", stream.Length.ToString())
                    .Append("isFavorite", "false")
                    .Append("assetData", stream, filename),
                Headers =
                {
                    { "Accept", "application/json" },
                    { "x-api-key", authKey },
                }
            }, token);
            if (!uploadAsset.Ok)
            {
                throw new InvalidOperationException($"Failed to upload asset: {uploadAsset.Status} {uploadAsset.StatusText}");
            }
            var uploadedAsset = (await uploadAsset.Json<AssetMediaResponseDto>(cancellationToken: token, typeInfo: ImmichJsonContext.WithConverters.AssetMediaResponseDto))!;
            uploadedAssetId = uploadedAsset.Id;
        }
        else
        {
            uploadedAssetId = result.AssetId!;
        }

        using var getAlbums = await FetchAsync(new Request
        {
            RequestUri = new Uri(baseUri, "/api/albums"),
            Method = HttpMethod.Get,
            Headers =
            {
                { "Accept", "application/json" },
                { "x-api-key", authKey },
            }
        }, token);
        if (!getAlbums.Ok)
        {
            throw new InvalidOperationException($"Failed to get albums: {getAlbums.Status} {getAlbums.StatusText}");
        }

        var albums = (await getAlbums.Json<AlbumResponseDto[]>(cancellationToken: token, typeInfo: ImmichJsonContext.WithConverters.AlbumResponseDtoArray))
            !.Select(album => (Name: album.AlbumName, album.Id)).ToArray();
            
        var screenshotsAlbum = albums.FirstOrDefault(album => album.Name == AlbumName);
        if (screenshotsAlbum == default)
        {
            using var createAlbum = await FetchAsync(new Request
            {
                RequestUri = new Uri(baseUri, "/api/albums"),
                Method = HttpMethod.Post,
                Body = RequestBody.Json(new CreateAlbumDto(AlbumName), ImmichJsonContext.WithConverters.CreateAlbumDto),
                Headers =
                {
                    { "Accept", "application/json" },
                    { "x-api-key", authKey },
                }
            }, token);
            if (!createAlbum.Ok)
            {
                throw new InvalidOperationException($"Failed to create Screenshots album: {createAlbum.Status} {createAlbum.StatusText}");
            }
            var album = await createAlbum.Json<AlbumResponseDto>(cancellationToken: token, typeInfo: ImmichJsonContext.WithConverters.AlbumResponseDto);
            screenshotsAlbum = (album!.AlbumName, album.Id);
        }

        #if DEBUG
        var memoryStream = new MemoryStream();
        await JsonContent.Create(new AlbumsAddAssetsDto(albumIds: [ Guid.Parse(screenshotsAlbum.Id) ], assetIds: [ Guid.Parse(uploadedAssetId) ]), ImmichJsonContext.WithConverters.AlbumsAddAssetsDto).CopyToAsync(memoryStream, token);
        Console.WriteLine(Encoding.UTF8.GetString(memoryStream.ToArray()));
        #endif
        
        using var addToAlbum = await FetchAsync(new Request
        {
            RequestUri = new Uri(baseUri, $"/api/albums/assets"),
            Method = HttpMethod.Put,
            Body = RequestBody.Json(new AlbumsAddAssetsDto(albumIds: [ Guid.Parse(screenshotsAlbum.Id) ], assetIds: [ Guid.Parse(uploadedAssetId) ]), ImmichJsonContext.WithConverters.AlbumsAddAssetsDto),
            Headers =
            {
                { "Accept", "application/json" },
                { "x-api-key", authKey },
            }
        }, token);
        if (!addToAlbum.Ok)
        {
            throw new InvalidOperationException($"Failed to add asset to Screenshots album: {addToAlbum.Status} {addToAlbum.StatusText}");
        }
    }

    [GeneratedRegex(@"\s+", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    private static partial Regex WhitespaceRegex { get; }
}