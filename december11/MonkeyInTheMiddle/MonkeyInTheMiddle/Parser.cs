namespace MonkeyInTheMiddle;

public static class Parser
{
    public static List<Monkey> Parse(string inputRaw)
    {
        var parsedLines = inputRaw.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        List<Monkey> monkeys = new List<Monkey>();

        var monkeyIndex = -1;
        List<ulong> itemsArray = new List<ulong>();
        IOperation tempOp = null;
        int operationConstant = -1;
        int testConstant = -1;
        int trueMonkeyIndex = -1;

        foreach (var line in parsedLines)
        {
            if (line.StartsWith("Monkey "))
            {
                monkeyIndex++;
                continue;
            }

            if (string.IsNullOrWhiteSpace(line))
                continue;

            if (line.StartsWith("  Starting items: "))
            {
                var items = line.Split(": ");
                itemsArray = ParseItems(items[1]);
                continue;
            }

            if (line.StartsWith("  Operation: new = old"))
            {
                var res = ParseOperation(line);
                tempOp = res.Item1;
                operationConstant = res.Item2;
                continue;
            }

            if (line.StartsWith("  Test: divisible by"))
            {
                testConstant = ParseTest(line);
                continue;
            }

            if (line.StartsWith("    If true: throw to monkey"))
            {
                trueMonkeyIndex = ParseMonkeyIndex(line);
                continue;
            }

            if (line.StartsWith("    If false: throw to monkey "))
            {
                var falseMonkeyIndex = ParseMonkeyIndex(line);
                var newMonkey = new Monkey(monkeyIndex, itemsArray.ToArray(), tempOp, testConstant, trueMonkeyIndex,
                    falseMonkeyIndex, monkeys);
                if (operationConstant != -1)
                {
                    newMonkey.OperationConstant = operationConstant;
                }
                monkeys.Add(newMonkey);
                itemsArray = new List<ulong>();
                tempOp = null;
                operationConstant = -1;
                testConstant = -1;
                trueMonkeyIndex = -1;
            }
        }

        var gcd = GCD(monkeys);

        for (int i = 0; i < monkeys.Count; i++)
        {
            monkeys[i].santiyIndex = gcd;
        }

        return monkeys;
    }

    private static List<ulong> ParseItems(string itemLine)
    {
        var lineComponents = itemLine.Split(new string[] {", "}, StringSplitOptions.None);
        var tempList = new List<ulong>();
        foreach (var line in lineComponents)
        {
            tempList.Add(ulong.Parse(line));
        }

        return tempList;
    }

    private static Tuple<IOperation, int> ParseOperation(string opLine)
    {
        var opLineComponents = opLine.Split(' ');
        var opConstant = -1;
        if (opLineComponents[7] != "old")
        {
            opConstant = int.Parse(opLineComponents[7]);
        }

        if (opLineComponents[6] == "*")
        {
            return new Tuple<IOperation, int>(new Multiply(), opConstant);
        }

        if (opLineComponents[6] == "+")
        {
            return new Tuple<IOperation, int>(new Add2(), opConstant);
        }

        if (opLineComponents[6] == "-")
        {
            return new Tuple<IOperation, int>(new Subtract(), opConstant);
        }

        if (opLineComponents[6] == "/")
        {
            return new Tuple<IOperation, int>(new Divide(), opConstant);
        }
        
        throw new ArgumentException(); // Check input, probably need new op method.
    }

    private static int ParseTest(string line)
    {
        var testComponents = line.Split(' ');
        return int.Parse(testComponents[5]);
    }

    private static int ParseMonkeyIndex(string line)
    {
        var monkeyToThrowTo = line.Split(' ');
        return int.Parse(monkeyToThrowTo[9]);
    }

    static int GCDFunc(int a, int b)
    {
        return b == 0 ? a : GCDFunc(b, a % b);
    }
    private static int GCD(List<Monkey> monkeys)
    {
        var temp = monkeys.Select(x => x.TestConstant).ToArray();
        return temp.Aggregate((num, val) => num * val / GCDFunc(num, val));
    }


}