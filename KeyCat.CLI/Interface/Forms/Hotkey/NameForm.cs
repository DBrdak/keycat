using System.Text.RegularExpressions;

namespace KeyCat.CLI.Interface.Forms.Hotkey;

internal sealed class NameForm : Form<string>
{
    private const string inputLabel = "LongName: ";
    private string _name = "";
    private const string namePattern = @"^[a-zA-Z0-9 ]{3,55}$";

    public NameForm() : base(inputLabel)
    {
    }

    public override async Task HandleInput()
    {
        _name = Terminal.Input();
        CleanupName();

        SetInput(_name);
    }

    private void CleanupName() => _name = Regex.Replace(_name, @"\s+", " ").Trim();

    protected override void ValidateInput()
    {
        if (!Regex.IsMatch(_name, namePattern))
        {
            Terminal.PrintError("Invalid value (LongName can only contain letters, digits and spaces. LongName lenght must be between 3 and 55 characters)");
            Environment.Exit(1);
        }
    }
}