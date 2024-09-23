using System.Text.RegularExpressions;

namespace KeyCat.CLI.Interface.Forms.Hotkey;

internal sealed class DescriptionForm : Form<string>
{
    private const string inputLabel = "Description: ";
    private string _description = "";
    private const string descriptionPattern = @"^[a-zA-Z0-9,.\- ]{0,255}$";

    public DescriptionForm() : base(inputLabel)
    {
    }

    public override Task HandleInput()
    {
        _description = Terminal.Input();
        CleanupDescription();

        SetInput(_description);

        return Task.CompletedTask;
    }

    private void CleanupDescription() => _description = Regex.Replace(_description, @"\s+", " ").Trim();

    protected override void ValidateInput()
    {
        if (Regex.IsMatch(_description, descriptionPattern))
        {
            return;
        }
        
        Terminal.PrintError("Invalid value (Allowed characters are: letters, digits, spaces, periods, commas and dashes. Description length must be between 0 and 255 characters)");
        Environment.Exit(1);
    }
}