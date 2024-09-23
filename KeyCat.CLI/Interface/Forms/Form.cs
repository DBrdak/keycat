using System.Diagnostics.CodeAnalysis;

namespace KeyCat.CLI.Interface.Forms;

internal abstract class Form
{
    private readonly string _inputLabel;
    public abstract Task HandleInput();
    protected abstract void ValidateInput();

    protected Form(string inputLabel)
    {
        _inputLabel = inputLabel;
    }

    public void Initialize() => Terminal.Print(_inputLabel, ConsoleColor.Cyan);
}

internal abstract class Form<T> : Form
{
    private T? _input;
    public T? Input => _input;

    protected Form(string inputLabel) : base(inputLabel)
    {
    }

    [MemberNotNull(nameof(_input))]
    [MemberNotNull(nameof(Input))]
    public abstract override Task HandleInput();
    protected abstract override void ValidateInput();
    protected void SetInput(T input)
    {
        ValidateInput();
        _input = input;
    }
}