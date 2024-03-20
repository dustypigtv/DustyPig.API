using System;

namespace DustyPig.API.v3.Models;

public class Result
{
    public bool Success { get; set; }

    public string Error { get; set; }

    public static Result BuildSuccess() => new() { Success = true };

    public static Result BuildError(string error) => new() { Error = error };

    public static Result BuildError(Exception ex) => new() { Error = ex.Message };


    /// <summary>
    /// Implicitly converts the specified <paramref name="ex"/> to an <see cref="Result"/> and sets <see cref="Error"/> = <paramref name="ex"/>.ToString().
    /// </summary>
    /// <param name="ex">The value to convert.</param>
    public static implicit operator Result(ModelValidationException ex) => BuildError(ex.ToString());


    /// <summary>
    /// Implicitly converts the specified <paramref name="ex"/> to an <see cref="Result"/> and sets <see cref="Error"/> = <paramref name="ex"/>.Message.
    /// </summary>
    /// <param name="ex">The value to convert.</param>
    public static implicit operator Result(Exception ex) => BuildError(ex.Message);


    /// <summary>
    /// Implicitly converts the specified <paramref name="error"/> to an <see cref="Result"/> and sets <see cref="Error"/> = <paramref name="error"/>.
    /// </summary>
    /// <param name="error">The value to convert.</param>
    public static implicit operator Result(string error) => BuildError(error);

}





public class Result<T>
{
    public bool Success { get; set; }

    public string Error { get; set; }

    public T Data { get; set; }

    public static Result<T> BuildSuccess(T data) => new() { Success = true, Data = data };

    public static Result<T> BuildError(string error) => new() { Error = error };

    public static Result<T> BuildError(Exception ex) => new() { Error = ex.Message };

    public static Result<T> FromResult(Result result) => new Result<T> { Success = result.Success, Error = result.Error };


    /// <summary>
    /// Implicitly converts the specified <paramref name="ex"/> to an <see cref="Result{T}"/> and sets <see cref="Error"/> = <paramref name="ex"/>.ToString().
    /// </summary>
    /// <param name="ex">The value to convert.</param>
    public static implicit operator Result<T>(ModelValidationException ex) => BuildError(ex.ToString());


    /// <summary>
    /// Implicitly converts the specified <paramref name="ex"/> to an <see cref="Result{T}"/> and sets <see cref="Error"/> = <paramref name="ex"/>.Message.
    /// </summary>
    /// <param name="ex">The value to convert.</param>
    public static implicit operator Result<T>(Exception ex) => BuildError(ex.Message);


    /// <summary>
    /// Implicitly converts the specified <paramref name="value"/> to an <see cref="Result{T}"/> and sets <see cref="Success"/> = true.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator Result<T>(T value) => BuildSuccess(value);


    /// <summary>
    /// Implicitly converts the specified <paramref name="error"/> to an <see cref="Result{T}"/> and sets <see cref="Error"/> = <paramref name="error"/>.
    /// </summary>
    /// <param name="error">The value to convert.</param>
    public static implicit operator Result<T>(string error) => BuildError(error);

    /// <summary>
    /// Implicitly converts the specified <paramref name="result"/> to an <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="result">The <see cref="Result"/>.</param>
    public static implicit operator Result<T>(Result result) => FromResult(result);
}
