namespace KeyCat.CLI.Interface.Forms.Hotkey;

internal sealed class HotkeyForm : FormsChain
{
    private readonly NameForm _nameForm = new();
    private readonly DescriptionForm _descriptionForm = new();
    private readonly ExecutableForm _executableForm = new();
    private readonly ShortcutForm _shortcutForm = new();

    public override FormsChain InitializeChain() =>
        AddForm(_nameForm)
            .AddForm(_descriptionForm)
            .AddForm(_executableForm)
            .AddForm(_shortcutForm);

    public string? Name => _nameForm.Input;
    public string? Description => _descriptionForm.Input;
    public string? Executable => _executableForm.Input;
    public string? Shortcut => _shortcutForm.Input;
}