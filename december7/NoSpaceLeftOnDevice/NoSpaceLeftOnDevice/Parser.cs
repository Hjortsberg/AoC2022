namespace NoSpaceLeftOnDevice;

public class Parser
{
    public static Filesystem ParseTerminalOutput(string input)
    {
        var terminalLines = input.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.RemoveEmptyEntries);

        var resultingFilesystem = BuildFilesystem(terminalLines);

        return resultingFilesystem;
    }

    // problem can probably be suitable to solve with both linked list and some tree structure.
    private static Filesystem BuildFilesystem(IEnumerable<string> terminalLines)
    {
        var filesystem = new Filesystem();
        foreach (var line in terminalLines)
        {
            // is it a command I executed?
            if (line[0] is '$')
            {
                var commandComponents = line.Split(' ');
                if (commandComponents[1] == "cd")
                {
                    filesystem.ChangeDirectory(commandComponents[2]);
                }

                continue;
            }

            filesystem.CreateEntity(line);
        }

        return filesystem;
    }
}