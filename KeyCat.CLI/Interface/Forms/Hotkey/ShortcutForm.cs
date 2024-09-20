using SharpHook;
using KeyCat.SharedKernel;

namespace KeyCat.CLI.Interface.Forms.Hotkey;

internal sealed class ShortcutForm : Form<string>
{
    private readonly HashSet<Key> _pressedKeys = new();
    private const string inputLabel = "Shortcut: ";
    private const int maxShortcutLength = 4;

    public ShortcutForm() : base(inputLabel)
    {
    }

    public override async Task HandleInput()
    {
        var hook = new SimpleGlobalHook();
        var tcs = new TaskCompletionSource<string>();

        hook.KeyPressed += (_, e) =>
        {
            var key = e.Data.KeyCode.ToKey();

            if (key != null)
            {
                _pressedKeys.Add(key);
            }
        };

        hook.KeyReleased += (_, _) =>
        {
            hook.Dispose();
            var shortcutString = Key.AsSequence(_pressedKeys);
            tcs.SetResult(shortcutString);
        };

        hook.MousePressed += (_, e) =>
        {
            var key = e.Data.Button.ToKey();

            if (key != null)
            {
                _pressedKeys.Add(key);
            }
        };

        hook.MouseReleased += (_, _) =>
        {
            hook.Dispose();
            var shortcutString = Key.AsSequence(_pressedKeys);
            tcs.SetResult(shortcutString);
        };

        await hook.RunAsync();

        var shortcut = await tcs.Task;

        SetInput(shortcut);

        Terminal.Print($"{shortcut}", ConsoleColor.Magenta);
    }

    protected override void ValidateInput()
    {
        if (_pressedKeys.Count > maxShortcutLength)
        {
            Terminal.PrintError("Invalid value (Shortcut is too long - you can assign up to 4 keys)");
            Environment.Exit(1);
        }
    }
}