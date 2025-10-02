namespace MoneyMinderContracts.Requests.Accounts;

public class ChangeNameRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ChangeNameRequest()
    {
    }
    
    public ChangeNameRequest(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
