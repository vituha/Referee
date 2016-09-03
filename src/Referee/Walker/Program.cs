using System;

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

            int returnCode = 0;

            result.Handle(
                () => returnCode = 0,
                (errorCode, errorMessage) =>
                {
                    Console.Error.WriteLine(errorMessage);
                    returnCode = (int)errorCode;
                });

            return returnCode;
        }
    }
}
