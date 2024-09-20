using Microsoft.EntityFrameworkCore;

namespace KeyCat.Data;

internal sealed class HotkeysContext : DbContext
{
    private const string connectionString = "Data Source=hotkeys.db";
    public DbSet<Hotkey> Hotkeys { get; init; }

    public HotkeysContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite(connectionString);
}