using Microsoft.EntityFrameworkCore;

namespace KeyCat.Data;

internal sealed class HotkeysContext : DbContext
{
    private static readonly string directory =
        $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\keycat";
    private static readonly string connectionString =
        $@"Data Source={directory}\hotkeys.db";

    public DbSet<Hotkey> Hotkeys { get; init; }

    public HotkeysContext()
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite(connectionString);
}