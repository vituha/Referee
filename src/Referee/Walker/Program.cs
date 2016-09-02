namespace Walker
{
    class Program
    {
        static int Main(string[] args)
        {
            var parser = new CommandLineParser();

            Command command = parser.ParseCommandLine(args);

            var handler = new CommandHandler();

            CommandResult result = command.HandleWith(handler);

            int returnCode =
                result.IsSuccessful
                    ? 0
                    : (int)result.ErrorCode.Value;

            return returnCode;
        }
    }
}
