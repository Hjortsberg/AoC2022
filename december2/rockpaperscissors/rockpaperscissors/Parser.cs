namespace rockpaperscissors;

public static class Parser
{
    public static List<Round> Parse(string input)
    {
        var roundAsString = input.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None);
        var rounds = new List<Round>();
        foreach (var roundString in roundAsString)
        {
            var opponentShape = roundString[0];
            var myShape = roundString[2];

            rounds.Add(new Round(ResolveShape(opponentShape), ResolveShape(myShape)));
        }

        return rounds;
    }

    public static List<Round> ParsePartTwo(string input)
    {
        var roundAsString = input.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None);
        var rounds = new List<Round>();
        foreach (var roundString in roundAsString)
        {
            var opponentShape = roundString[0];
            var outcome = roundString[2];

            rounds.Add(new Round(ResolveShape(opponentShape), ResolveOutcome(opponentShape, outcome)));
        }

        return rounds;
    }

    private static Shapes ResolveShape(char letter)
    {
        if (letter is 'A' or 'X')
        {
            return Shapes.Rock;
        }

        if (letter is 'B' or 'Y')
        {
            return Shapes.Paper;
        }

        return Shapes.Scissors;
    }

    private static Shapes ResolveOutcome(char opponentLetter, char letter)
    {
        if (letter is 'X' && opponentLetter == 'B' ||
            letter is 'Y' && opponentLetter == 'A' ||
            letter is 'Z' && opponentLetter == 'C')
        {
            return Shapes.Rock;
        }

        if (letter is 'X' && opponentLetter == 'C' ||
            letter is 'Y' && opponentLetter == 'B' ||
            letter is 'Z' && opponentLetter == 'A')
        {
            return Shapes.Paper;
        }

        return Shapes.Scissors;
    }
}
