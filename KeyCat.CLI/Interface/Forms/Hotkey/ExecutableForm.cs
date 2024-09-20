using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KeyCat.CLI.Interface.Forms.Hotkey;

internal sealed class ExecutableForm : Form<string>
{
    private const string inputLabel = "Executable file path: ";
    private string _executablePath = "";

    public ExecutableForm() : base(inputLabel)
    {
    }

    public override async Task HandleInput()
    {
        _executablePath = Terminal.Input();

        SetInput(_executablePath);
    }

    protected override void ValidateInput()
    {
        if (!File.Exists(_executablePath))
        {
            Terminal.PrintError("Invalid value (File does not exist)");
            Environment.Exit(1);
        }
    }
}