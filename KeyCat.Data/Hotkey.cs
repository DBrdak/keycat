using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KeyCat.Data;

[Table(nameof(HotkeysContext.Hotkeys))]
public sealed class Hotkey
{
    public Guid Id { get; init; }
    [MaxLength(50)]
    public string Name { get; private set; }
    [MaxLength(300)]
    public string Description { get; private set; }
    [MaxLength(100)]
    public string Shortcut { get; private set; }
    [NotMapped]
    public HashSet<string> Keys { get; init; }
    [MaxLength(300)]
    public string Executable { get; private set; }

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

    public void UpdateName(string name) => Name = name;
    public void UpdateDescription(string description) => Description = description;
    public void UpdateShortcut(string shortcut) => Shortcut = shortcut;
    public void UpdateExecutable(string executable) => Executable = executable;
}