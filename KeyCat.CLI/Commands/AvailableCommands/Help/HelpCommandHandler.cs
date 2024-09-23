using KeyCat.CLI.Interface;

namespace KeyCat.CLI.Commands.AvailableCommands.Help;

internal class HelpCommandHandler : CommandHandler<HelpCommand>
{
    public HelpCommandHandler(HelpCommand command) : base(command)
    {
    }

    public override async Task Handle()
    {
        Terminal.PrintLine("========== Available commands ==========", ConsoleColor.Green);

        foreach (var command in Commands.Command.AvailableCommands)
        {
            Terminal.PrintLine($"-> {command.Name}", ConsoleColor.Cyan);
            Terminal.PrintLine($"\t {command.Info}");
            Terminal.PrintLine($"\t Parameters:");
            command.Arguments.ToList().ForEach(
                arg => Terminal.PrintLine($"\t\t -> {arg.LongName}, {arg.ShortName} - {arg.Info}"));
            Console.WriteLine();
        }
    }
}