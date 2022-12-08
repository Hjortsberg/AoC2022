namespace SupplyStacks;

public class Parser
{
    public static (IEnumerable<Stack>, IEnumerable<Step>) ParseInput(string rawInput)
    {
        var lines = rawInput.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None);
        
        var stacksAndIndex = ParseStacks(lines);
        
        var index = stacksAndIndex.Item2 +1 ; // index that separate stacks from steps

        // slice the array to only contain rearrangement instructions
        var rearrangementProcedureLines = lines[index..];
        var rearrangementProcedure = ParseRearrangementProcedure(rearrangementProcedureLines);

        return (stacksAndIndex.Item1, rearrangementProcedure);
    }

    private static IEnumerable<Step> ParseRearrangementProcedure(string[] input)
    {
        // first step will be at index 0
        var rearrangementProcedure = new List<Step>();

        for (int i = 0; i < input.Length; i++)
        {
            var line = input[i];
            var stepComponents = line.Split(' ');
            rearrangementProcedure.Add(
                new Step(
                    stepComponents[0], 
                    int.Parse(stepComponents[1]), 
                    int.Parse(stepComponents[3]), 
                    int.Parse(stepComponents[5])));
        }

        return rearrangementProcedure;
    }

    private static (IEnumerable<Stack>, int) ParseStacks(string[] input)
    {
        var stacks = new List<Stack>();
        // first we need the correct amount of stacks created to insert values to
        // stack 1 will be at position 0 in the list.
        var stackNumberIndex = 1;
        for (int i = 1; i < input[0].Length - 1; i +=4)
        {
            stacks.Add(new Stack{StackNumber = stackNumberIndex});
            stackNumberIndex++;
        }

        // Im assuming that all containers will be identified by one letter
        var blankInputDividerIndex = 0;

        for(int j = 0; j < input.Length; j++)
        {
            var line = input[j];
            if (string.IsNullOrWhiteSpace(line))
            {
                blankInputDividerIndex = j; // we extract this divider inside this method in order to skip one iteration of the input.
                break;
            }
            var y = 0;
            for (int i = 1; i < line.Length - 1; i += 4)
            {
                if (Char.IsDigit(line[i]))
                    break;
                if (line[i] != ' ')
                {
                     stacks[y].AddCrates(new List<Crate> {new(line[i])});
                }

                y++;
            }
        }

        return (stacks, blankInputDividerIndex);
    }
}