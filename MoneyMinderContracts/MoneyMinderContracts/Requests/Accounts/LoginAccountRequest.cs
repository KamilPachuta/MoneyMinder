namespace MoneyMinderContracts.Requests.Accounts;

public class LoginAccountRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public LoginAccountRequest()
    {
    }

    public LoginAccountRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}