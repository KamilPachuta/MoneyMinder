namespace MoneyMinder.API.Requests.Accounts;

public record ChangePasswordRequest(string Password, string NewPassword);