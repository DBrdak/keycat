namespace KeyCat.CLI.Commands;

internal abstract class CommandHandler<TCommand> where TCommand : Command
{
    protected readonly TCommand Command;

    protected CommandHandler(TCommand command)
    {
        Command = command;
    }

    public abstract Task Handle();
}