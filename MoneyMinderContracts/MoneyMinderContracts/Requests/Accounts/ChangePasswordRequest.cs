namespace MoneyMinderContracts.Requests.Accounts;

public record ChangePasswordRequest(string Password, string NewPassword);