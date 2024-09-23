namespace KeyCat.CLI.Commands.AvailableCommands.Edit;

internal sealed record EditFieldArgument : Argument
{
    private const string longName = "field";
    private const string shortName = "f";
    private const string info =
        "The field of the hotkey you want to edit (name = 0, description = 1, shortcut = 2, executable file path = 3)";
    public static IReadOnlyList<string> ValidValues = ["0", "1", "2", "3"];

    public EditFieldArgument() : base(longName, shortName, info)
    {
    }
}