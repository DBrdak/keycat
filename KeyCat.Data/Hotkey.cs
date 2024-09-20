using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KeyCat.Data;

[Table(nameof(HotkeysContext.Hotkeys))]
public sealed class Hotkey
{
    public Guid Id { get; init; }
    [MaxLength(50)]
    public string Name { get; init; }
    [MaxLength(300)]
    public string Description { get; init; }
    [MaxLength(100)]
    public string Shortcut { get; init; }
    [NotMapped]
    public HashSet<string> Keys { get; init; }
    [MaxLength(300)]
    public string Executable { get; init; }

    public Hotkey(string name, string description, string shortcut, string executable, Guid? id = null)
    {
        Name = name;
        Shortcut = shortcut;
        Keys = [..shortcut.Split('+')];
        Executable = executable;
        Description = description;
        Id = id ?? Guid.NewGuid();
    }

    public Hotkey(Hotkey original)
    {
        Id = original.Id;
        Name = original.Name;
        Description = original.Description;
        Shortcut = original.Shortcut;
        Keys = original.Keys;
        Executable = original.Executable;
    }

    [JsonConstructor]
    private Hotkey()
    { }

}