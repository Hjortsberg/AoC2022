using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace RucksackReorganization;

public static class Parser
{
    public static IEnumerable<Rucksack> ParseRucksack(string input)
    {
        var rucksacksAsStrings = input.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None);

        var rucksacks = new ConcurrentBag<Rucksack>();
        Parallel.ForEach(rucksacksAsStrings, rucksack =>
        {
            var indexMiddle = rucksack.Length / 2;
            rucksacks.Add(new Rucksack(SortString(rucksack[..indexMiddle]), SortString(rucksack[indexMiddle..])));
        });
        return rucksacks;
    }

    public static IEnumerable<Group> ParseRucksackForGroup(string input)
    {
        var rucksacksAsStrings = input.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None);

        var groups = new List<Group>();
        for (int i = 0; i < rucksacksAsStrings.Length; i += 3)
        {
            groups.Add(new Group(SortString(rucksacksAsStrings[i]), SortString(rucksacksAsStrings[i+1]), SortString(rucksacksAsStrings[i+2])));
        }
        return groups;
    }

    static string SortString(string input)
    {
        char[] characters = input.ToArray();
        Array.Sort(characters);
        var unique = new HashSet<char>(characters);
        return new string(unique.ToArray());
    }
}