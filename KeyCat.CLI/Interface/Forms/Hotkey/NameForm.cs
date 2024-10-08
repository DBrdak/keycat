﻿using System.Text.RegularExpressions;

namespace KeyCat.CLI.Interface.Forms.Hotkey;

internal sealed class NameForm : Form<string>
{
    private const string inputLabel = "Name: ";
    private string _name = "";
    private const string namePattern = @"^[a-zA-Z0-9 ]{3,55}$";

    public NameForm() : base(inputLabel)
    {
    }

    public override Task HandleInput()
    {
        _name = Terminal.Input();
        CleanupName();

        SetInput(_name);

        return Task.CompletedTask;
    }

    private void CleanupName() => _name = Regex.Replace(_name, @"\s+", " ").Trim();

    protected override void ValidateInput()
    {
        if (!Regex.IsMatch(_name, namePattern))
        {
            Terminal.PrintError("Invalid value (Name can only contain letters, digits and spaces. Name lenght must be between 3 and 55 characters)");
            Environment.Exit(1);
        }
    }
}