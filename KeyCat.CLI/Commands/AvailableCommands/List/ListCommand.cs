namespace KeyCat.CLI.Commands.AvailableCommands.List;

internal sealed class ListCommand : Command
{
    private const string name = "list";
    private const string info = "Displays a list of all available hotkeys.";

    public ListCommand()
    {
        Name = name;
        Info = info;
        Arguments = [];
        Handler = new ListCommandHandler(this).Handle;
    }
}