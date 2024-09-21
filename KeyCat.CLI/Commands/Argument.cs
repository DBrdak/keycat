namespace KeyCat.CLI.Commands;

internal abstract record Argument
{
    public string Name { get; init; }
    public string Info {get; init; }
    public string? Value { get; private set; }

    public void SetValue(string? value) => Value = value;
}