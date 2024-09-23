using System.Reflection;
using KeyCat.CLI.Commands.AvailableCommands.Add;

namespace KeyCat.CLI.Commands.AvailableCommands.Edit;

internal sealed class EditCommand : Command
{
    private const string name = "add";
    private const string info = "Lets you create a new hotkey.";

    public EditCommand()
    {
        Name = name;
        Info = info;
        Arguments = [new EditNameArgument()];
        Handler = new EditCommandHandler(this).Handle;
    }
}