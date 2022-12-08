namespace SupplyStacks;

public class Stack
{
    private List<Crate> _crates = new();
    public int StackNumber { get; set; }

    public List<Crate> TakeCrates(int numberOfCrates)
    {
        //var startIndex = _crates.Count - 1 - numberOfCrates;
        var pickedUpCrates = _crates.GetRange(0, numberOfCrates);
        _crates.RemoveRange(0,numberOfCrates);
        return pickedUpCrates;
    }

    public void AddCrates(List<Crate> cratesToAdd)
    {
         _crates.AddRange(cratesToAdd);
    }

    //Part 1
    public void SetCratesAtTop(List<Crate> cratesToSetAtTop)
    {
        cratesToSetAtTop.Reverse();
        _crates.InsertRange(0, cratesToSetAtTop);
    }
    //Part 2
    public void SetMultipleCratesAtTop(List<Crate> cratesToSetAtTop)
    {
        _crates.InsertRange(0, cratesToSetAtTop);
    }

    public char GetTopCrateId()
    {
        return _crates.First().Id;
    }
}