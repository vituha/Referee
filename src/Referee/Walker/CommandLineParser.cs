namespace Walker
{
    sealed class CommandLineParser
    {
        public Command ParseCommandLine(string[] args)
        {
            if (args.Length != 1)
                return new ShowIllegalUsageCommand();

            if (args[0] == "/?")
                return new ShowHelpCommand();

            return new WalkCommand(args[0]);
        }
    }
}
