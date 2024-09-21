using System.Diagnostics;
using KeyCat.Data;
using KeyCat.SharedKernel;
using SharpHook;

namespace KeyCat.Listener;

internal static class Program
{
    private static GlobalHookBase? globalHook;

    private static readonly HashSet<Key> pressedKeys = new();

    [STAThread]
    static void Main()
    {
        Subscribe();

        Application.Run();

        Unsubscribe();
    }

    private static void Subscribe()
    {
        globalHook = new SimpleGlobalHook(true);

        globalHook.KeyPressed += GlobalHook_KeyDown;
        globalHook.MousePressed += GlobalHook_MouseDown;
        globalHook.KeyReleased += GlobalHook_KeyUp;
        globalHook.MouseReleased += GlobalHook_MouseUp;
        globalHook.RunAsync();
    }

    private static void Unsubscribe()
    {
        globalHook.KeyPressed -= GlobalHook_KeyDown;
        globalHook.MousePressed -= GlobalHook_MouseDown;
        globalHook.KeyReleased -= GlobalHook_KeyUp;
        globalHook.MouseReleased -= GlobalHook_MouseUp;

        globalHook.Dispose();
    }


    private static async void GlobalHook_KeyDown(object? sender, KeyboardHookEventArgs e)
    {
        var pressedKey = e.Data.KeyCode.ToKey();
        
        if (pressedKey is null)
        {
            return;
        }

        pressedKeys.Add(pressedKey);

        await using var hotkeyRepository = new HotkeyRepository();

        var hotkey = await hotkeyRepository.GetByShortcutAsync(Key.AsSequence(pressedKeys));
        
        if(hotkey is not null)
        {
            ExecuteHotkey(hotkey.Executable);
        }
    }

    private static void GlobalHook_KeyUp(object? sender, KeyboardHookEventArgs e) => 
        pressedKeys.Remove(e.Data.KeyCode.ToKey());

    private static async void GlobalHook_MouseDown(object? sender, MouseHookEventArgs e)
    {
        var pressedKey = e.Data.Button.ToKey();

        if (pressedKey is null)
        {
            return;
        }

        pressedKeys.Add(pressedKey);

        await using var hotkeyRepository = new HotkeyRepository();

        var hotkey = await hotkeyRepository.GetByShortcutAsync(Key.AsSequence(pressedKeys));

        if (hotkey is not null)
        {
            ExecuteHotkey(hotkey.Executable);
        }
    }

    private static void GlobalHook_MouseUp(object? sender, MouseHookEventArgs e) =>
        pressedKeys.Remove(e.Data.Button.ToKey());

    private static void ExecuteHotkey(string executablePath)
    {
        try
        {
            if (!File.Exists(executablePath))
            {
                MessageBox.Show($"Executable file not found: {executablePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO Problem - it does not work for console files (ps1, bat, etc.)
            Process.Start(new ProcessStartInfo
            {
                FileName = executablePath,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            });

            pressedKeys.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error executing executable file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}