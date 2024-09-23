using KeyCat.CLI.Interface;
using KeyCat.Data;

namespace KeyCat.CLI.Commands.AvailableCommands.List;

internal sealed class ListCommandHandler : CommandHandler<ListCommand>
{
    private readonly HotkeyRepository _hotkeyRepository;

    public ListCommandHandler(ListCommand command) : base(command)
    {
        _hotkeyRepository = new HotkeyRepository();
    }

    public override async Task Handle()
    {
        var hotkeys = await _hotkeyRepository.ListAllAsync();

        PrintHotkeys(hotkeys);
    }

    private void PrintHotkeys(List<Hotkey> hotkeys)
    {
        Terminal.PrintLine("========== Available hotkeys ==========", ConsoleColor.Green);
        Console.WriteLine();

        if (hotkeys.Count < 1)
        {
            Terminal.PrintLine("No hotkeys found.", ConsoleColor.Red);
            Environment.Exit(1);
        }

        hotkeys.ForEach(hotkey =>
        {
            Terminal.PrintLine($"-> LongName: {hotkey.Name}", ConsoleColor.Blue);
            Terminal.PrintLine($"\t {hotkey.Description}");
            Terminal.Print($"\t Shortcut: ", ConsoleColor.Cyan);
            Terminal.PrintLine($"{hotkey.Shortcut}");
            Terminal.Print($"\t Executable: ", ConsoleColor.Cyan);
            Terminal.PrintLine($"{hotkey.Executable}");
            Console.WriteLine();
        });
    }
}