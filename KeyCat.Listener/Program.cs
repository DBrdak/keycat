using System.Diagnostics;
using Gma.System.MouseKeyHook;
using KeyCat.Data;
using Newtonsoft.Json;

namespace KeyCat.Listener;

internal static class Program
{
    private static IKeyboardMouseEvents? globalHook;

    private static readonly HashSet<Keys> pressedKeys = new();

    [STAThread]
    static void Main()
    {
        Subscribe();

        Application.Run();

        Unsubscribe();
    }

    private static void Subscribe()
    {
        globalHook = Hook.GlobalEvents();

        globalHook.KeyDown += GlobalHook_KeyDown;
        globalHook.KeyUp += GlobalHook_KeyUp;
    }

    private static void Unsubscribe()
    {
        globalHook.KeyDown -= GlobalHook_KeyDown;
        globalHook.KeyUp -= GlobalHook_KeyUp;

        globalHook.Dispose();
    }

    private static async void GlobalHook_KeyDown(object sender, KeyEventArgs e)
    {
        pressedKeys.Add(e.KeyCode);

        await using var hotkeyRepository = new HotkeyRepository();

        var hotkey = await hotkeyRepository.GetByShortcutAsync(string.Join('+', pressedKeys));
        
        if(hotkey is not null)
        {
            ExecuteHotkey(hotkey.Executable);
        }
    }

    private static void GlobalHook_KeyUp(object sender, KeyEventArgs e) => 
        pressedKeys.Remove(e.KeyCode);

    private static void ExecuteHotkey(string executablePath)
    {
        try
        {
            if (!File.Exists(executablePath))
            {
                MessageBox.Show($"Executable file not found: {executablePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = executablePath,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error executing executable file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}