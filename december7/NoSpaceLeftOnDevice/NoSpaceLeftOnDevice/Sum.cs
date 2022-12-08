using System.Collections.Concurrent;

namespace NoSpaceLeftOnDevice;

public static class Sum
{
    private static int sharedTotal;
    private static ConcurrentBag<int> smallestDirectoryFordeletion = new ConcurrentBag<int>();
    public static void AddToTotal(int amount)
    {
        Interlocked.Add(ref sharedTotal, amount);
    }

    public static int GetTotal()
    {
        return sharedTotal;
    }

    public static void AddDir(int amount)
    {
         smallestDirectoryFordeletion.Add(amount);
    }
    public static int GetSmallestDirForDelete()
    {
        return smallestDirectoryFordeletion.Min();
    }
}