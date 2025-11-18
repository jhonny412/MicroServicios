namespace Usuarios.Domain.Abstractions
{
    public class Result
    {
        public bool IsSuccess { get;}
        public Error Error { get; }
        public bool IsFailure => !IsSuccess;
        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
                throw new InvalidOperationException("A success result cannot hace un error.");

            if (!isSuccess && error == Error.None)
                throw new InvalidOperationException("A failure result must have an error.");

            IsSuccess = isSuccess;
            Error = error;
        }        
    }
}