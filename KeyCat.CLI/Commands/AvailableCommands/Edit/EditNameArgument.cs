namespace KeyCat.CLI.Commands.AvailableCommands.Edit;

internal sealed record EditNameArgument : Argument
{
    private const string longName = "name";
    private const string shortName = "n";
    private const string info = "The name of the searched hotkey";

    public EditNameArgument() : base(longName, shortName, info)
    {
    }
}