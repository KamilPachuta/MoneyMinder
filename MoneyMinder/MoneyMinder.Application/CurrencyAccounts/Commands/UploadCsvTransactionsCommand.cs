using MediatR;
using Microsoft.AspNetCore.Http;
using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record UploadCsvTransactionsCommand(Guid AccountId, Guid CurrencyAccountId, IFormFile File) : CurrencyCommand(AccountId, CurrencyAccountId);