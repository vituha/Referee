namespace Walker
{
    abstract class Command
    {
        public abstract TResult HandleWith<TResult>(ICommandHandler<TResult> handler);
    }

    sealed class ShowHelpCommand : Command
    {
        public override TResult HandleWith<TResult>(ICommandHandler<TResult> handler)
        {
            return handler.Handle(this);
        }
    }

    sealed class WalkCommand : Command
    {
        public WalkCommand(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public override TResult HandleWith<TResult>(ICommandHandler<TResult> handler)
        {
            return handler.Handle(this);
        }
    }

    sealed class ShowIllegalUsageCommand : Command
    {
        public override TResult HandleWith<TResult>(ICommandHandler<TResult> handler)
        {
            return handler.Handle(this);
        }
    }
}
