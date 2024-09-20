namespace KeyCat.CLI.Interface.Forms;

internal abstract class FormsChain
{
    private readonly List<Form> _forms = [];

    public abstract FormsChain InitializeChain();

    public FormsChain AddForm(Form form)
    {
        _forms.Add(form);
        return this;
    }

    public async Task<FormsChain> InvokeChainAsync()
    {
        foreach (var form in _forms)
        {
            form.Initialize();
            await Task.Delay(500);
            await form.HandleInput();
        }

        return this;
    }

    public T As<T>() where T : FormsChain => this as T;
}