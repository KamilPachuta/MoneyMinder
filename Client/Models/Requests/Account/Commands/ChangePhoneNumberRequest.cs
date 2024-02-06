namespace Client.Models.Requests.Account.Commands;

public class ChangePhoneNumberRequest
{
    public string Code { get; set; }
    public string Number { get; set; }

    public ChangePhoneNumberRequest(string code, string number)
    {
        Code = code;
        Number = number;
    }

    public ChangePhoneNumberRequest()
    {
    }
}
