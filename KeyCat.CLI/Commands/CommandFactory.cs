using KeyCat.CLI.Commands.AvailableCommands.Help;

namespace KeyCat.CLI.Commands;

internal sealed class CommandFactory
{
    public static Command CreateCommand(string[] args)
    {
        if (args.Length == 0)
        {
            return new HelpCommand();
        }

        var commandName = args[0];
        var command = Command.AvailableCommands.FirstOrDefault(c => c.Name == commandName);
        command?.SetArguments(args[1..]);

        return command ?? new HelpCommand();
    }
}