namespace MoneyMinderContracts.Requests.Accounts;

public class ChangePasswordRequest
{
    public string Password { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;

    public ChangePasswordRequest()
    {
    }
    
    public ChangePasswordRequest(string password, string newPassword)
    {
        Password = password;
        NewPassword = newPassword;
    }
}
