using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class LoginResponse : IResponse
{
    public string Token { get; set; }
}