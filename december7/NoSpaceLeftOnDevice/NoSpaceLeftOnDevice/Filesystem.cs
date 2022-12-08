namespace NoSpaceLeftOnDevice;

public class Filesystem
{
    private List<IFilesystemEntity> _references = new ();
    private Directory _workingDirectory;

    public Filesystem()
    {
        _workingDirectory = new Directory(){Name = "/"};
        _workingDirectory._parentDirectory = _workingDirectory; // assign self as parent directory
        _references.Add(_workingDirectory);
    }



    public Directory GetWorkingDirectory()
    {
        return _workingDirectory;
    }

    public void ChangeDirectory(string directoryName)
    {
        if (directoryName == "..")
        {
            _workingDirectory = _workingDirectory.ParentDirectory();
            return;
        }

        if (directoryName == "/")
        {
            // stupid cast, but first thing in this should always be the directory created in
            // the constructor above
            _workingDirectory = (Directory)_references[0];
            return;
        }

        _workingDirectory = _workingDirectory.TryMoveIn(directoryName);
    }

    public void CreateEntity(string filesystemEntityToAdd)
    {
        var filesystemEntityComponents = filesystemEntityToAdd.Split(' ');
        if (filesystemEntityComponents[0] == "dir")
        {
            var newDirectory = new Directory()
                { Name = filesystemEntityComponents[1], _parentDirectory = _workingDirectory };
            _workingDirectory.Create(newDirectory);
            return;
        }

        var fileNameAndType = filesystemEntityComponents[1].Split('.');
        var newFile = new File(fileNameAndType[0], fileNameAndType.Length > 1 ? fileNameAndType[1] : "",
            int.Parse(filesystemEntityComponents[0]));
        _workingDirectory.Create(newFile);
    }
}