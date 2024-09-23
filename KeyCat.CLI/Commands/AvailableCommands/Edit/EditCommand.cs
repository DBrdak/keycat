using System.Reflection;
using KeyCat.CLI.Commands.AvailableCommands.Add;

namespace KeyCat.CLI.Commands.AvailableCommands.Edit;

internal sealed class EditCommand : Command
{
    private const string name = "edit";
    private const string info = "You can edit a field of a given hotkey.";

    public EditCommand()
    {
        Name = name;
        Info = info;
        Arguments = [new EditNameArgument(), new EditFieldArgument()];
        Handler = new EditCommandHandler(this).Handle;
    }
}