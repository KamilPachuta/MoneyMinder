namespace MoneyMinderContracts.Requests.Accounts;

public class ChangePhoneNumberRequest
{
    public string Code { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;

    public ChangePhoneNumberRequest()
    {
    }
    
    public ChangePhoneNumberRequest(string code, string number)
    {
        Code = code;
        Number = number;
    }
}
