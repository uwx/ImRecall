namespace ImRecall;

public class ImRecallOptions
{
    public const string ImRecall = "ImRecall";

    public bool EnableUpload { get; set; } = true;
    public string AlbumName { get; set; } = "ImRecall";
    public bool ArchiveUploads { get; set; } = true;
}