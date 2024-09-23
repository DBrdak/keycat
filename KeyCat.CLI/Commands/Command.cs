using KeyCat.CLI.Commands.AvailableCommands.Add;
using KeyCat.CLI.Commands.AvailableCommands.Edit;
using KeyCat.CLI.Commands.AvailableCommands.Help;
using KeyCat.CLI.Commands.AvailableCommands.List;
using KeyCat.CLI.Commands.AvailableCommands.Remove;
using KeyCat.CLI.Interface;

namespace KeyCat.CLI.Commands;

internal abstract class Command
{
    public string Name { get; init; }
    public string Info { get; init; }
    public IReadOnlyList<Argument> Arguments { get; init; }
    public Func<Task> Handler { get; init; }

    public static IReadOnlyList<Command> AvailableCommands =
    [
        new AddCommand(), 
        new EditCommand(), 
        new HelpCommand(), 
        new ListCommand(), 
        new RemoveCommand()
    ];

    public void SetArguments(string[] args)
    {
        if (args.Length < 1)
        {
            return;
        }

        for (var (i, j) = (0, 1); j < args.Length; (i, j) = (i += 2, j += 2))
        {
            var isValidArgument = args[i].StartsWith("-") && args.ElementAtOrDefault(j) is not null;

            if (!isValidArgument)
            {
                Terminal.PrintError("Invalid argument was specified");
                Environment.Exit(1);
            }

            var isLongName = args[i].StartsWith("--");

            var name = args[i].Replace("-", "");
            var value = args.ElementAtOrDefault(j) is var arg && arg is not null && !arg.StartsWith('-') ?
                args[j] :
                null;

            Arguments.FirstOrDefault(a => (a.LongName == name && isLongName) || a.ShortName == name)?.SetValue(value);
        }
    }
}