namespace ASP_MVC.Helpers
{
    // Simple functional result wrapper for service/repository operations
    public sealed class Result
    {
        public bool IsSuccess { get; }
        public string? Error { get; }

        private Result(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, null);
        public static Result Fail(string error) => new(false, error);
    }
}



