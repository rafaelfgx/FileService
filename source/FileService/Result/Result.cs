namespace FileService
{
    public class Result : IResult
    {
        protected Result() { }

        public string Message { get; protected set; }

        public bool Succeeded { get; protected set; }

        public static IResult Fail(string message)
        {
            return new Result { Succeeded = false, Message = message };
        }

        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }
    }

    public sealed class Result<T> : Result, IResult<T>
    {
        private Result() { }

        public T Data { get; private set; }

        public static new IResult<T> Fail(string message)
        {
            return new Result<T> { Succeeded = false, Message = message };
        }

        public static IResult<T> Success(T data)
        {
            return new Result<T> { Succeeded = true, Data = data };
        }
    }
}
