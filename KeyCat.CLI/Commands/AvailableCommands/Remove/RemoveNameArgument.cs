namespace KeyCat.CLI.Commands.AvailableCommands.Remove;

internal sealed record RemoveNameArgument : Argument
{
    private const string longName = "name";
    private const string shortName = "n";
    private const string info = "The name of the hotkey to be deleted";

    public RemoveNameArgument() : base(longName, shortName, info)
    {
    }
}