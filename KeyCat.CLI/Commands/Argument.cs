namespace KeyCat.CLI.Commands;

internal abstract record Argument
{
    public string LongName { get; init; }
    public string ShortName { get; init; }
    public string Info {get; init; }
    public string? Value { get; private set; }

    protected Argument(string longName, string shortName, string info)
    {
        LongName = longName;
        ShortName = shortName;
        Info = info;
        Value = null;
    }

    public void SetValue(string? value) => Value = value;
}