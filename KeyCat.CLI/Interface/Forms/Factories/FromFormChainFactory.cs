using KeyCat.CLI.Interface.Forms.Hotkey;

namespace KeyCat.CLI.Interface.Forms.Factories;

internal abstract class FromFormChainFactory<T> where T : FormsChain
{
    protected async Task<T> GatherDataAsync() =>
        (await new HotkeyForm()
            .InitializeChain()
            .InvokeChainAsync())
        .As<T>();

    public abstract Task ProduceInteractive();
}