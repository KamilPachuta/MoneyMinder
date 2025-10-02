namespace MoneyMinderContracts.Requests.Accounts;

public class DeleteAccountRequest
{
    public string Password { get; set; } = string.Empty;

    public DeleteAccountRequest()
    {
    }
    
    public DeleteAccountRequest(string password)
    {
        Password = password;
    }
}