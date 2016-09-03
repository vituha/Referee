namespace Walker
{
    interface ICommandHandler<TResult>
    {
        TResult Handle(ShowHelpCommand cmd);
        TResult Handle(WalkCommand cmd);
        TResult Handle(ShowIllegalUsageCommand cmd);
    }
}
