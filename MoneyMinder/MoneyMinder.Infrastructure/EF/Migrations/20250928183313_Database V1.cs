using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMinder.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyAccounts",
                schema: "MoneyMinder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "MoneyMinder",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingsAccounts",
                schema: "MoneyMinder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<byte>(type: "smallint", nullable: false),
                    PlannedAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "MoneyMinder",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                schema: "MoneyMinder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency = table.Column<byte>(type: "smallint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyAccountId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balances_CurrencyAccounts_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalSchema: "MoneyMinder",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                schema: "MoneyMinder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency = table.Column<byte>(type: "smallint", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CurrencyAccountId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_CurrencyAccounts_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalSchema: "MoneyMinder",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                schema: "MoneyMinder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyAccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<byte>(type: "smallint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_CurrencyAccounts_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalSchema: "MoneyMinder",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "MoneyMinder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    CurrencyAccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<byte>(type: "smallint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_CurrencyAccounts_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalSchema: "MoneyMinder",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingsTransactions",
                schema: "MoneyMinder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    SavingsAccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<byte>(type: "smallint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsTransactions_SavingsAccounts_SavingsAccountId",
                        column: x => x.SavingsAccountId,
                        principalSchema: "MoneyMinder",
                        principalTable: "SavingsAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Limits",
                schema: "MoneyMinder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Limits_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalSchema: "MoneyMinder",
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_CurrencyAccountId",
                schema: "MoneyMinder",
                table: "Balances",
                column: "CurrencyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_CurrencyAccountId",
                schema: "MoneyMinder",
                table: "Budgets",
                column: "CurrencyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAccounts_AccountId",
                schema: "MoneyMinder",
                table: "CurrencyAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_CurrencyAccountId",
                schema: "MoneyMinder",
                table: "Incomes",
                column: "CurrencyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Limits_BudgetId",
                schema: "MoneyMinder",
                table: "Limits",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CurrencyAccountId",
                schema: "MoneyMinder",
                table: "Payments",
                column: "CurrencyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccounts_AccountId",
                schema: "MoneyMinder",
                table: "SavingsAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsTransactions_SavingsAccountId",
                schema: "MoneyMinder",
                table: "SavingsTransactions",
                column: "SavingsAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances",
                schema: "MoneyMinder");

            migrationBuilder.DropTable(
                name: "Incomes",
                schema: "MoneyMinder");

            migrationBuilder.DropTable(
                name: "Limits",
                schema: "MoneyMinder");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "MoneyMinder");

            migrationBuilder.DropTable(
                name: "SavingsTransactions",
                schema: "MoneyMinder");

            migrationBuilder.DropTable(
                name: "Budgets",
                schema: "MoneyMinder");

            migrationBuilder.DropTable(
                name: "SavingsAccounts",
                schema: "MoneyMinder");

            migrationBuilder.DropTable(
                name: "CurrencyAccounts",
                schema: "MoneyMinder");
        }
    }
}
