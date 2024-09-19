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

    public async Task<Hotkey?> GetByShortcutAsync(string shortcut) =>
        await _context.Hotkeys.FirstOrDefaultAsync(h => h.Shortcut.ToLower() == shortcut.ToLower());

    public async Task<List<Hotkey>> ListAllAsync() => await _context.Hotkeys.ToListAsync();

    public async Task AddAsync(Hotkey hotkey)
    {
        await _context.Hotkeys.AddAsync(hotkey);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Hotkey hotkey)
    {
        _context.Hotkeys.Update(hotkey);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Hotkey hotkey)
    {
        _context.Hotkeys.Remove(hotkey);
        await _context.SaveChangesAsync();
    }
}