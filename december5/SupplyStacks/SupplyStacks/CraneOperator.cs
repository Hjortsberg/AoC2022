namespace SupplyStacks;

public class CraneOperator
{
    public IEnumerable<Stack> Rearrange(IEnumerable<Stack> startStacks, IEnumerable<Step> steps)
    {
        var stacks = startStacks.ToList(); // to list, avoid multiple enumeration
        foreach (var step in steps)
        {
            if (step.Operation.ToLower() == "move")
            {
                Move(stacks, step);
            }
        }

        return stacks;
    }

    private void Move(List<Stack> stacks, Step step)
    {
        var fromStack = stacks.First(x => x.StackNumber == step.From);
        var cratesToMove = fromStack.TakeCrates(step.NumberOfCrates);
        var toStack = stacks.First(x => x.StackNumber == step.To);
        toStack.SetMultipleCratesAtTop(cratesToMove);
    }
}