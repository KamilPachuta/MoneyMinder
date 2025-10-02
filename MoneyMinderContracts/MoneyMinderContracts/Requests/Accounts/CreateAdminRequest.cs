namespace MoneyMinderContracts.Requests.Accounts;

public class CreateAdminRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public CreateAdminRequest()
    {
    }
    
    public CreateAdminRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
