using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderClient.Core;

public class Result
{
    public bool Succeeded { get; set; }
    public List<string> ErrorList { get; set; } = new List<string>();

    public static Result Success() => new Result { Succeeded = true };
    public static Result Failure(params string[] errors) => new Result { Succeeded = false, ErrorList = errors.ToList() };
}

public class Result<T> where T : class, IResponse
{
    public bool Succeeded { get; set; }
    public List<string> ErrorList { get; set; } = new List<string>();
    public T Response { get; set; }

    public static Result<T> Success(T response) => new Result<T> { Succeeded = true, Response = response };
    public static Result<T> Failure(params string[] errors) => new Result<T> { Succeeded = false, ErrorList = errors.ToList() };
}
