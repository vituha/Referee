using System;

namespace Walker
{
    sealed class CommandResult
    {
        bool isSuccessful;
        ErrorCode errorCode;
        string errorMessage;

        public static CommandResult Successful()
        {
            return
                new CommandResult
                {
                    isSuccessful = true,
                };
        }

        public static CommandResult Failed(ErrorCode code, string message)
        {
            return
                new CommandResult
                {
                    isSuccessful = false,
                    errorCode = code,
                    errorMessage = message,
                };
        }

        public void Handle(Action ifSuccessful, Action<ErrorCode, string> ifFailed)
        {
            if (isSuccessful)
                ifSuccessful();
            else
                ifFailed(errorCode, errorMessage);
        }
    }
}
