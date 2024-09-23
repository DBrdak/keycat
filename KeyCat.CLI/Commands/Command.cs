using KeyCat.CLI.Commands.AvailableCommands.Add;
using KeyCat.CLI.Commands.AvailableCommands.Edit;
using KeyCat.CLI.Commands.AvailableCommands.Help;
using KeyCat.CLI.Commands.AvailableCommands.List;
using KeyCat.CLI.Commands.AvailableCommands.Remove;

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

        for (var (i, j) = (0, 1); j < args.Length; (i, j) = (i += 1, j += 1))
        {
            var name = args[i].Replace("-", "");
            var value = args.ElementAtOrDefault(j) is var arg && arg is not null && !arg.StartsWith('-') ?
                args[j] :
                null;

            Arguments.FirstOrDefault(a => a.LongName == name || a.ShortName == name)?.SetValue(value);
        }
    }
}