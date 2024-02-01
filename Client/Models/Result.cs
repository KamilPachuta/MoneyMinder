using MoneyMinderClient.Models.Responses;

namespace MoneyMinderClient.Models;

public class Result
{
    public bool Succeeded { get; set; }
    
    public List<string> ErrorList { get; set; } = new();
}

public class Result<T> where T : class, IResponse
{
    public bool Succeeded { get; set; }
    
    public List<string> ErrorList { get; set; } = new();

    public T Response { get; set; }
}