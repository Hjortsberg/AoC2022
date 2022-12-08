namespace NoSpaceLeftOnDevice;

public class Directory : IFilesystemEntity
{
    public string Name { get; init; }
    public Directory _parentDirectory { get; set; }
    private List<IFilesystemEntity> _references = new List<IFilesystemEntity>();

    string IFilesystemEntity.Name()
    {
        return Name;
    }

    public int Size()
    {
        var sum = _references.Sum(x => x.Size());
        if (sum >= 3562874)
        {
            Console.WriteLine("directory: {0}, size: {1}", Name, sum);
            Sum.AddToTotal(sum);
            Sum.AddDir(sum);
        }        
        return sum;
    }



    public Directory ParentDirectory()
    {
        return _parentDirectory;
    }

    public Directory TryMoveIn(string directoryName)
    {
        var resultOfOperation =
            (Directory)_references.FirstOrDefault(x => (x.Name() == directoryName) && x.GetType() == typeof(Directory));
        if (resultOfOperation is null)
        {
            var newDirectory = new Directory() { Name = directoryName, _parentDirectory = this };
            _references.Add(newDirectory);
            return newDirectory;
        }
        return resultOfOperation;
    }

    public void Create(IFilesystemEntity entity)
    {
        _references.Add(entity);
    }
}