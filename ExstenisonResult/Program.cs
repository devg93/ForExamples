// using System;
// using System.Threading.Tasks;

// public readonly struct Result<T>
// {
//     public T Value { get; }
//     public string? Error { get; }
//     public bool IsSuccess { get; }
//     public bool IsFailure => !IsSuccess;

//     private Result(T value, string? error, bool isSuccess)
//     {
//         Value = value;
//         Error = error;
//         IsSuccess = isSuccess;
//     }

//     public static Result<T> Success(T value) => new(value, null, true);

//     public static Result<T> Failure(string error) =>
//         new(default!, error ?? "Unknown error", false);

//     // public TResult Match<TResult>(Func<T, TResult> onSuccess, Func<string, TResult> onFailure)
//     //     => IsSuccess ? onSuccess(Value) : onFailure(Error!);

//     public void ThrowIfFailure()
//     {
//         if (IsFailure)
//             throw new InvalidOperationException(Error);
//     }

//     public override string ToString()
//         => IsSuccess ? $"Success({Value})" : $"Failure({Error})";
// }

// // public static class TaskResultExtensions
// // {
// //     public static async Task<Result<T>> AsResult<T>(this Task<T> task)
// //     {
// //         try
// //         {
// //             var value = await task;
// //             return Result<T>.Success(value);
// //         }
// //         catch (Exception ex)
// //         {
// //             return Result<T>.Failure(ex.Message);
// //         }
// //     }
// // }

// public static class ResultExtensions
// {
//     public static TOut Fold<T, TOut>(this Result<T> result, Func<T, TOut> onSuccess, Func<string?, TOut> onFailure)
//         => result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error);
// }

// public class Program
// {
//     public static async Task<string> GetDataAsync()
//     {
//         await Task.Delay(200);
//         return "Neo!";
//     }

//     public static async Task Main(string[] args)
//     {
//         var result = await GetDataAsync().;

//         // result.Match(
//         //     success => { Console.WriteLine($"Got: {success}"); return 0; },
//         //     error => { Console.WriteLine($"Error: {error}"); return -1; }
//         // );

//         result.IsSuccess<string>("");

//         result.ThrowIfFailure();
//         Console.WriteLine($"Final value: {result.Value}");
//     }
// }



using System;
using System.Threading.Tasks;

public readonly struct Result<T>
{
    public T Value { get; }
    public string? Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    private Result(T value, string? error, bool isSuccess)
    {
        Value = value;
        Error = error;
        IsSuccess = isSuccess;
    }

    public static Result<T> Success(T value) => new(value, null, true);

    public static Result<T> Failure(string error) =>
        new(default!, error ?? "Unknown error", false);

    public void ThrowIfFailure()
    {
        if (IsFailure)
            throw new InvalidOperationException(Error);
    }

    public override string ToString()
        => IsSuccess ? $"Success({Value})" : $"Failure({Error})";
}

public static class TaskResultExtensions
{
    public static async Task<Result<T>> AsResult<T>(this Task<T> task)
    {
        try
        {
            var value = await task;
            return Result<T>.Success(value);
        }
        catch (Exception ex)
        {
            return Result<T>.Failure(ex.Message);
        }
    }
}



public static class ValueTaskResultExtensions
{
    public static async ValueTask<Result<T>> AsResult<T>(this ValueTask<T> task)
    {
        try
        {
            var value = await task;
            return Result<T>.Success(value);
        }
        catch (Exception ex)
        {
            return Result<T>.Failure(ex.Message);
        }
    }
}

// public static class ResultExtensions
// {
//     public static TOut Fold<T, TOut>(this Result<T> result, Func<T, TOut> onSuccess, Func<string?, TOut> onFailure)
//         => result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error);
// }

public class Program
{
    public static async Task<string> GetDataAsync()
    {
        await Task.Delay(200);
        return "Neo!";
    }

    public static async Task Main(string[] args)
    {
        var result = await GetDataAsync().AsResult();

        if (result.IsSuccess)
        {
            Console.WriteLine($"Got: {result.Value}");
        }
        else
        {
            Console.WriteLine($"Error: {result.Error}");
        }

        // ან შეგიძლია ისროლო exception თუ ჩავარდა
        result.ThrowIfFailure();

        Console.WriteLine($"Final value: {result.Value}");
    }
}
