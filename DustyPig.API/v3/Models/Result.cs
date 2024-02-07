using System;

namespace DustyPig.API.v3.Models
{
    public class Result
    {
        public bool Success { get; set; }   

        public string Error { get; set; }

        public static Result BuildSuccess() => new() { Success = true };

        public static Result BuildError(string error) => new() { Error = error };

        public static Result BuildError(Exception ex) => new() {  Error = ex.Message };
    }

    public class Result<T>
    { 
        public bool Success { get; set; }

        public string Error { get; set; }

        public T Data { get; set; }

        public static Result<T> BuildSuccess(T data) => new Result<T> { Success = true, Data = data };

        public static Result<T> BuildError(string error) => new Result<T> { Error = error };

        public static Result<T> BuildError(Exception ex) => new Result<T> { Error = ex.Message };
    }
}
