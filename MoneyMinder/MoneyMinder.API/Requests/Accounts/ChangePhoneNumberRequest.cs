namespace MoneyMinder.API.Requests.Accounts;

public record ChangePhoneNumberRequest(string Code, string Number);