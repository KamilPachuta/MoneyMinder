using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses;

public class LoginResponse : IResponse
{
    public string Token { get; set; } = string.Empty;

    public LoginResponse()
    {
    }

    public LoginResponse(string token)
    {
        Token = token;
    }
}
