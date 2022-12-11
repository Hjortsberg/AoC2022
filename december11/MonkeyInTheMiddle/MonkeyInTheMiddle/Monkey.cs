namespace MonkeyInTheMiddle;

public class Monkey
{
    public int Index { get; init; }
    public ulong[] Items { get; set; }

    private IOperation _operation;

    private int _operationConstant;
    public int OperationConstant
    {
        set
        {
            _operationConstant = value;
            _useConstant = true;
        }
    }
    private bool _useConstant;

    public int TestConstant { get; }
    private readonly int _trueMonkeyIndex;
    private readonly int _falseMonkeyIndex;
    public ulong InspectedItems { get; private set; } = 0;

    private List<Monkey> _monkeys;

    public int santiyIndex { get; set; }

    public Monkey(int index, ulong[] items, IOperation operation, int testConstant, int trueTestResultMonkeyIndex, int falseTestResultMonkeyIndex, List<Monkey> monkeys)
    {
        Index = index;
        Items = items;
        _operation = operation;
        TestConstant = testConstant;
        _trueMonkeyIndex = trueTestResultMonkeyIndex;
        _falseMonkeyIndex = falseTestResultMonkeyIndex;
        _monkeys = monkeys;

    }

    private ulong Inspect(ulong item)
    {
        InspectedItems++;
        return _operation.Calculate(item, _useConstant ? (ulong)_operationConstant : item);
    }

    /*private ulong GetBored(ulong worryLevel)
    {
        return (ulong)Math.Floor(worryLevel / 2.0);
    }*/

    private ulong RemainSane(ulong item)
    {
        return item % (ulong)santiyIndex;
    }

    private bool Test(ulong worryLevel)
    {
        return worryLevel % (ulong)TestConstant == 0;
    }

    public void ThrowItem(bool monkeySelector, ulong item)
    {
        var monkey = monkeySelector ? _monkeys[_trueMonkeyIndex] : _monkeys[_falseMonkeyIndex];
        monkey.CatchItem(item);
    }

    public void CatchItem(ulong item)
    {
        Items = Items.Append(item).ToArray();
    }

    public void Do()
    {
        foreach (var item in Items)
        {
            var worryLevel = Inspect(item);
            //worryLevel = GetBored(worryLevel);       // part two don't use this
            worryLevel = RemainSane(worryLevel); // part 2
            var monkeySelector = Test(worryLevel);
            ThrowItem(monkeySelector, worryLevel);
            Items = Array.Empty<ulong>();
        }
    }
}