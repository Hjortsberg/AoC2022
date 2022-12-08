namespace NoSpaceLeftOnDevice;

public record File(string FileName, string? FileType, int FileSize) : IFilesystemEntity
{
    public string Name()
    {
        return FileName;
    }

    int IFilesystemEntity.Size()
    {
        return FileSize;
    }
}