using KeyCat.CLI.Interface.Forms;
using KeyCat.CLI.Interface.Forms.Hotkey;

namespace KeyCat.CLI;

internal class Program
{
    static async Task Main(string[] args)
    {
        var chain = (await new HotkeyFormsChain().InitializeChain().InvokeChainAsync()).As<HotkeyFormsChain>();
        Console.WriteLine(chain.Name);
        Console.WriteLine(chain.Description);
        Console.WriteLine(chain.Shortcut);
        Console.WriteLine(chain.Executable);
    }
}