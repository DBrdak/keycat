namespace KeyCat.CLI.Commands.AvailableCommands.Help;

internal sealed class HelpCommand : Command
{
    private const string name = "help";
    private const string info = "Displays help information about the available commands.";

    public HelpCommand()
    {
        Name = name;
        Info = info;
        Arguments = [];
        Handler = new HelpCommandHandler(this).Handle;
    }
}