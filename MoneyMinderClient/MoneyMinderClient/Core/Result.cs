using System.Net;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderClient.Core;

public class Result
{
    public bool Succeeded { get; set; }
    public HttpStatusCode  StatusCode { get; set; }
    public List<string> ErrorList { get; set; } = new List<string>();

    public static Result Success(HttpStatusCode statusCode) => new Result { Succeeded = true, StatusCode = statusCode };
    public static Result Failure(HttpStatusCode statusCode, params string[] errors) => new Result { Succeeded = false, StatusCode = statusCode, ErrorList = errors.ToList() };
}

public class Result<T> where T : class, IResponse
{
    public bool Succeeded { get; set; }
    public HttpStatusCode  StatusCode { get; set; }
    public List<string> ErrorList { get; set; } = new List<string>();
    public T Response { get; set; }

    public static Result<T> Success(HttpStatusCode statusCode, T response) => new Result<T> { Succeeded = true, StatusCode = statusCode, Response = response };
    public static Result<T> Failure(HttpStatusCode statusCode, params string[] errors) => new Result<T> { Succeeded = false, StatusCode = statusCode, ErrorList = errors.ToList() };
    
   // public static Result<T> UnAuthorized(params string[] errors) => new Result<T> { Succeeded = false, ErrorList = errors.ToList() };
}
