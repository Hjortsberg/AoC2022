namespace MonkeyInTheMiddle;

public class MonkeyPack
{
    private IEnumerable<Monkey> _monkeys;

    public MonkeyPack(IEnumerable<Monkey> monkeys)
    {
        _monkeys = monkeys;
    }

    public ulong PlayKeepAway(int numberOfRounds)
    {
        for (int i = 0; i < numberOfRounds; i++)
        {
            foreach (var monkey in _monkeys)
            {
                monkey.Do();
            }
        }

        _monkeys = _monkeys.OrderByDescending(x => x.InspectedItems);
        var topTwoMostActiveMonkeys = _monkeys.Take(2).ToArray();
        return topTwoMostActiveMonkeys[0].InspectedItems * topTwoMostActiveMonkeys[1].InspectedItems;
    }
}