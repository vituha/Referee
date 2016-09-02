namespace Walker
{
    sealed class CommandResult
    {
        public bool IsSuccessful { get; private set; }
        public ErrorCode? ErrorCode { get; private set; }

        public static CommandResult Successful()
        {
            return
                new CommandResult
                {
                    IsSuccessful = true,
                    ErrorCode = null,
                };
        }

        public static CommandResult Failed(ErrorCode code)
        {
            return
                new CommandResult
                {
                    IsSuccessful = false,
                    ErrorCode = code,
                };
        }
    }
}
