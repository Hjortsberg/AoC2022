using System.Collections.Concurrent;

namespace CampCleanup;

public class Parser
{
    public static IEnumerable<ElfPair> ParseSectionAssignmentsByElfPair(string input)
    {
        var sectionAssignmentsAsStrings = input.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None);

        var pairs = new ConcurrentBag<ElfPair>();
        Parallel.ForEach(sectionAssignmentsAsStrings, elfPair =>
        {
            pairs.Add(ProcessString(elfPair));
        });
        return pairs;
    }

    static ElfPair ProcessString(string input)
    {
        var upperAndLowerSectionIdsForPair = input.Split(new char[] {',', '-'});
        return new ElfPair(new SectionAssignment(int.Parse(upperAndLowerSectionIdsForPair[0]), int.Parse(upperAndLowerSectionIdsForPair[1])) ,new SectionAssignment(int.Parse(upperAndLowerSectionIdsForPair[2]), int.Parse(upperAndLowerSectionIdsForPair[3])));
    }
}