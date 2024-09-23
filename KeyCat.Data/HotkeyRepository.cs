using Microsoft.EntityFrameworkCore;

namespace KeyCat.Data;

public sealed class HotkeyRepository : IDisposable, IAsyncDisposable
{
    private readonly HotkeysContext _context = new();

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    public async Task<Hotkey?> GetByNameAsync(string name) =>
        await _context.Hotkeys.FirstOrDefaultAsync(h => h.Name.ToLower() == name.ToLower());

    public async Task<Hotkey?> GetByShortcutAsync(string shortcut) =>
        await _context.Hotkeys.FirstOrDefaultAsync(h => h.Shortcut.ToLower() == shortcut.ToLower());

    public async Task<List<Hotkey>> ListAllAsync() => await _context.Hotkeys.ToListAsync();

    public async Task<bool> AddAsync(Hotkey hotkey)
    {
        var isHotkeyExists = await _context.Hotkeys.AnyAsync(
            h => h.Shortcut.ToLower() == hotkey.Shortcut.ToLower() ||
                 hotkey.Shortcut.ToLower().StartsWith(h.Shortcut.ToLower()) ||
                 h.Name.ToLower() == hotkey.Name.ToLower());

        if (isHotkeyExists)
        {
            return false;
        }

        await _context.Hotkeys.AddAsync(hotkey);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Hotkey hotkey)
    {
        var isHotkeyExists = await _context.Hotkeys.AnyAsync(
            h => (h.Shortcut.ToLower() == hotkey.Shortcut.ToLower() ||
                 hotkey.Shortcut.ToLower().StartsWith(h.Shortcut.ToLower()) ||
                 h.Name.ToLower() == hotkey.Name.ToLower()) &&
                 h.Id != hotkey.Id);

        if (isHotkeyExists)
        {
            return false;
        }

        _context.Hotkeys.Update(hotkey);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string shortcut)
    {
        var hotkey = await GetByShortcutAsync(shortcut);

        if (hotkey is null)
        {
            return false;
        }

        _context.Hotkeys.Remove(hotkey);
        await _context.SaveChangesAsync();
        return true;
    }
}