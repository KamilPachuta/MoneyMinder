namespace Client.Models.Requests.Account.Commands;

public class ChangePasswordRequest
{
    public string Password { get; set; }
    public string NewPassword { get; set; }

    public ChangePasswordRequest(string password, string newPassword)
    {
        Password = password;
        NewPassword = newPassword;
    }

    public ChangePasswordRequest()
    {
    }
}
