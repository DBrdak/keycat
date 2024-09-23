using System.Diagnostics.CodeAnalysis;
using KeyCat.CLI.Interface;
using KeyCat.CLI.Interface.Forms.Hotkey;
using KeyCat.Data;
using Newtonsoft.Json.Linq;
using SQLitePCL;

namespace KeyCat.CLI.Commands.AvailableCommands.Edit;

internal sealed class EditCommandHandler : CommandHandler<EditCommand>
{
    private EditNameArgument? _nameArg;
    private EditFieldArgument? _fieldArg;
    private readonly HotkeyRepository _hotkeyRepository;

    public EditCommandHandler(EditCommand command) : base(command)
    {
        _hotkeyRepository = new HotkeyRepository();
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

        switch (_fieldArg.Value)
        {
            case "0":
                EditName(hotkey);
                break;
            case "1":
                EditDescription(hotkey);
                break;
            case "2":
                await EditShortcut(hotkey);
                break;
            case "3":
                EditExecutable(hotkey);
                break;
        }

        var isSuccessful = await _hotkeyRepository.UpdateAsync(hotkey);

        if (!isSuccessful)
        {
            Terminal.PrintError("Hotkey already exist. Possible reasons:");
            Terminal.PrintError("\t-> New shortuct starts with the existing shortcut");
            Terminal.PrintError("\t-> Existing shortuct starts with the new shortcut");
            Terminal.PrintError("\t-> Shortcuts are equal");
            Terminal.PrintError("\t-> Names are equal");
            Terminal.PrintError("You can amend or delete the existing hotkey.");
            Environment.Exit(1);
        }
    }

    [MemberNotNull(nameof(_nameArg))]
    [MemberNotNull(nameof(_fieldArg))]
    private void ProcessArguments()
    {
        _nameArg = Command.Arguments.OfType<EditNameArgument>().FirstOrDefault();
        _fieldArg = Command.Arguments.OfType<EditFieldArgument>().FirstOrDefault();
        var isValid = true;

        if (_nameArg is null)
        {
            Terminal.PrintError("Argument \"Name\" is required");
            isValid = false;
        }

        if (_fieldArg is null)
        {
            Terminal.PrintError("Argument \"Field\" is required");
            isValid = false;
        } 
        else if(EditFieldArgument.ValidValues.All(value => value == _fieldArg.Value))
        {
            Terminal.PrintError($"Invalid value \"{_fieldArg.Value}\" for argument \"Field\". Type help for further reference");
            isValid = false;
        }

        if (!isValid)
        {
            Environment.Exit(1);
        }
    }

    private void EditName(Hotkey hotkey)
    {
        var form = new NameForm();
        form.Initialize();
        form.HandleInput();
        hotkey.UpdateName(form.Input);
    }

    private void EditDescription(Hotkey hotkey)
    {
        var form = new DescriptionForm();
        form.Initialize();
        form.HandleInput();
        hotkey.UpdateDescription(form.Input);
    }

    private async Task EditShortcut(Hotkey hotkey)
    {
        var form = new ShortcutForm();
        form.Initialize();
        await form.HandleInput();
        hotkey.UpdateShortcut(form.Input);
    }

    private void EditExecutable(Hotkey hotkey)
    {
        var form = new ExecutableForm();
        form.Initialize();
        form.HandleInput();
        hotkey.UpdateExecutable(form.Input);
    }
}