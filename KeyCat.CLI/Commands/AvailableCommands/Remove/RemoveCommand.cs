using KeyCat.CLI.Commands.AvailableCommands.Edit;

namespace KeyCat.CLI.Commands.AvailableCommands.Remove;

internal sealed class RemoveCommand : Command
{
    private const string name = "remove";
    private const string info = "You can edit a field of a given hotkey.";

    public RemoveCommand()
    {
        Name = name;
        Info = info;
        Arguments = [new RemoveNameArgument()];
        Handler = new RemoveCommandHandler(this).Handle;
    }
}