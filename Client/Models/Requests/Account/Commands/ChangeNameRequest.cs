namespace Client.Models.Requests.Account.Commands;

public class ChangeNameRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ChangeNameRequest(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public ChangeNameRequest()
    {
    }
}
