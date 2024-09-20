using KeyCat.CLI.Factories;
using KeyCat.CLI.Interface.Forms.Hotkey;
using KeyCat.Data;
using Newtonsoft.Json;

namespace KeyCat.CLI;

internal class Program
{
    static async Task Main(string[] args)
    {
        var factory = new HotkeyFactory();
        await factory.ProduceInteractive();
        Console.WriteLine(JsonConvert.SerializeObject(factory.Product));
    }
}