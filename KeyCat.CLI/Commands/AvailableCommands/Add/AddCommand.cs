using KeyCat.CLI.Commands.AvailableCommands.Help;

namespace KeyCat.CLI.Commands.AvailableCommands.Add;

internal sealed class AddCommand : Command
{
    private const string name = "add";
    private const string info = "Lets you create a new hotkey.";

    public AddCommand()
    {
        Name = name;
        Info = info;
        Arguments = [];
        Handler = new AddCommandHandler(this).Handle;
    }
}