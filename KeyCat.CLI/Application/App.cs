using System.Runtime.InteropServices;
using KeyCat.CLI.Commands;

namespace KeyCat.CLI.Application;

internal sealed class App
{
    public async Task Run(string[] args)
    {
        //if (args.Length == 0)
        //{
        //    var argss = Console.ReadLine()?.Split(' ');

        //    var commandd = CommandFactory.CreateCommand(argss);

        //    await commandd.Handler.Invoke();
        //    return;
        //}

        var command = CommandFactory.CreateCommand(args);

        await command.Handler.Invoke();
    }
}