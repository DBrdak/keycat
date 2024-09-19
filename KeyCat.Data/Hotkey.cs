using System.ComponentModel.DataAnnotations.Schema;

namespace KeyCat.Data;

[Table(nameof(HotkeysContext.Hotkeys))]
public sealed record Hotkey
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Shortcut { get; set; }
    public HashSet<string> Keys { get; init; }
    public string Executable { get; set; }

    public Hotkey(string name, string description, string shortcut, string executable, Guid? id = null)
    {
        Name = name;
        Shortcut = shortcut;
        Keys = [..shortcut.Split('+')];
        Executable = executable;
        Description = description;
        Id = id ?? Guid.NewGuid();
    }
}