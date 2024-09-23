using KeyCat.CLI.Commands.AvailableCommands.Edit;
using KeyCat.CLI.Interface;
using KeyCat.Data;
using System.Diagnostics.CodeAnalysis;

namespace KeyCat.CLI.Commands.AvailableCommands.Remove;

internal sealed class RemoveCommandHandler : CommandHandler<RemoveCommand>
{
    private RemoveNameArgument? _nameArg;
    private readonly HotkeyRepository _hotkeyRepository;

    public RemoveCommandHandler(RemoveCommand command) : base(command)
    {
        _hotkeyRepository = new ();
    }

    public override async Task Handle()
    {
        ProcessArguments();

        var hotkey = await _hotkeyRepository.GetByNameAsync(_nameArg.Value!);

        if (hotkey is null)
        {
            Terminal.PrintError($"Hotkey with name \"{_nameArg.Value}\" not found");
            Environment.Exit(1);
        }

        await _hotkeyRepository.DeleteAsync(hotkey);
    }

    [MemberNotNull(nameof(_nameArg))]
    private void ProcessArguments()
    {
        _nameArg = Command.Arguments.OfType<RemoveNameArgument>().FirstOrDefault();

        if (_nameArg is not null)
        {
            return;
        }

        Terminal.PrintError("Argument \"Name\" is required");
        Environment.Exit(1);
    }
}