using System.Diagnostics.CodeAnalysis;
using KeyCat.CLI.Interface;
using KeyCat.CLI.Interface.Forms.Hotkey;
using KeyCat.Data;

namespace KeyCat.CLI.Factories;

internal sealed class HotkeyFactory : FromFormChainFactory<HotkeyForm>
{
    private Hotkey product;
    public Hotkey Product => product;

    [MemberNotNull(nameof(product))]
    public override async Task ProduceInteractive()
    {
        var form = await GatherDataAsync();

        var isSuccessfull = form switch
        {
            _ when form.Name is null =>
                Terminal.PrintError(
                    "Unexpected error occured, Name was not registered. Please try again."),
            _ when form.Description is null =>
                Terminal.PrintError(
                    "Unexpected error occured, Description was not registered. Please try again."),
            _ when form.Executable is null =>
                Terminal.PrintError(
                    "Unexpected error occured, Executable Path was not registered. Please try again."),
            _ when form.Shortcut is null =>
                Terminal.PrintError(
                    "Unexpected error occured, Shortcut was not registered. Please try again."),
            _ => true
        };

        if (!isSuccessfull)
        {
            Environment.Exit(1);
        }

        product = new Hotkey(form.Name!, form.Description!, form.Shortcut!, form.Executable!);
    }
}