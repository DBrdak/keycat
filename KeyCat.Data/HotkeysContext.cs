using Microsoft.EntityFrameworkCore;

namespace KeyCat.Data;

internal sealed class HotkeysContext : DbContext
{
    private const string dbPath = "hotkeys.db";
    public DbSet<Hotkey> Hotkeys { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite(dbPath);
}