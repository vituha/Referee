using System;
using System.IO;
using System.Reflection;

namespace Walker
{
    sealed class CommandHandler : ICommandHandler<CommandResult>
    {
        public CommandResult Handle(WalkCommand cmd)
        {
            ReferencesWalker walker = new ReferencesWalker();

            try
            {
                Graph g = walker.Walk(cmd.Path);
            }
            catch (FileNotFoundException e)
            {
                var message = $"Specified file does not exist: \"{e.FileName}\".";
                Console.Error.WriteLine(message);
                return CommandResult.Failed(ErrorCode.FileNotFound);
            }
            catch (Exception e)
            {
                var message =
                    "Unknown error occurred. " +
                    "Plase help us improve this program by submitting new issue with following text on GitHub: " +
                    $"\"{e}\".";
                Console.Error.WriteLine(message);
                return CommandResult.Failed(ErrorCode.UnknownError);
            }

            return CommandResult.Successful();
        }

        public CommandResult Handle(ShowHelpCommand cmd)
        {
            Help.WriteTo(Console.Out);
            return CommandResult.Successful();
        }

        public CommandResult Handle(ShowIllegalUsageCommand cmd)
        {
            string programName = Path.GetFileName(Assembly.GetEntryAssembly().Location);
            var message = $"Illegal usage. Run {programName} /? to read help page.";
            Console.Error.WriteLine(message);
            return CommandResult.Failed(ErrorCode.IllegalUsage);
        }
    }
}
