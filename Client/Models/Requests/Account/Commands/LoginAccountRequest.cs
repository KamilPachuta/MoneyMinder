namespace Client.Models.Requests.Account.Commands;

public class LoginAccountRequest
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginAccountRequest()
    {
        
    }
    
    public LoginAccountRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}