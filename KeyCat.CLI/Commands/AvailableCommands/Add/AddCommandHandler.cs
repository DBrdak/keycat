using KeyCat.CLI.Interface;
using KeyCat.CLI.Interface.Forms.Factories;
using KeyCat.Data;

namespace KeyCat.CLI.Commands.AvailableCommands.Add;

internal sealed class AddCommandHandler : CommandHandler<AddCommand>
{
    private readonly HotkeyRepository _hotkeyRepository;

    public AddCommandHandler(AddCommand command) : base(command)
    {
        _hotkeyRepository = new HotkeyRepository();
    }

    public override async Task Handle()
    {
        var factory = new HotkeyFactory();

        await factory.ProduceInteractive();

        var hotkey = factory.Product;

        var isSuccessful = await _hotkeyRepository.AddAsync(hotkey);

        Console.WriteLine();

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
        
        Terminal.PrintLine("Hotkey created successfully!", ConsoleColor.Green);
        Terminal.Print($"You can now use it under the shortcut", ConsoleColor.Cyan);
        Terminal.Print($" {hotkey.Shortcut} ", ConsoleColor.Blue);
        Terminal.Print("or list or available hotkeys by using the list command.", ConsoleColor.Cyan);
        Console.WriteLine();
    }
}