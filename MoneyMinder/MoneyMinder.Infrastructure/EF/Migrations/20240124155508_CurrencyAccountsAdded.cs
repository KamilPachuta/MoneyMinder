using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMinder.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class CurrencyAccountsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyAccounts",
                schema: "MoneyMinderr",
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
                        principalSchema: "MoneyMinderr",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                schema: "MoneyMinderr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyAccountId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balances_CurrencyAccounts_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalSchema: "MoneyMinderr",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                schema: "MoneyMinderr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    ExpectedIncome = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_CurrencyAccounts_Id",
                        column: x => x.Id,
                        principalSchema: "MoneyMinderr",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                schema: "MoneyMinderr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyAccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_CurrencyAccounts_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalSchema: "MoneyMinderr",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MonthlyIncomes",
                schema: "MoneyMinderr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyAccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Month = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyIncomes_CurrencyAccounts_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalSchema: "MoneyMinderr",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MonthlyPayments",
                schema: "MoneyMinderr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    CurrencyAccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Month = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyPayments_CurrencyAccounts_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalSchema: "MoneyMinderr",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "MoneyMinderr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    CurrencyAccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_CurrencyAccounts_CurrencyAccountId",
                        column: x => x.CurrencyAccountId,
                        principalSchema: "MoneyMinderr",
                        principalTable: "CurrencyAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                schema: "MoneyMinderr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalSchema: "MoneyMinderr",
                        principalTable: "Budgets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_CurrencyAccountId",
                schema: "MoneyMinderr",
                table: "Balances",
                column: "CurrencyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAccounts_AccountId",
                schema: "MoneyMinderr",
                table: "CurrencyAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BudgetId",
                schema: "MoneyMinderr",
                table: "Expenses",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_CurrencyAccountId",
                schema: "MoneyMinderr",
                table: "Incomes",
                column: "CurrencyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyIncomes_CurrencyAccountId",
                schema: "MoneyMinderr",
                table: "MonthlyIncomes",
                column: "CurrencyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPayments_CurrencyAccountId",
                schema: "MoneyMinderr",
                table: "MonthlyPayments",
                column: "CurrencyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CurrencyAccountId",
                schema: "MoneyMinderr",
                table: "Payments",
                column: "CurrencyAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances",
                schema: "MoneyMinderr");

            migrationBuilder.DropTable(
                name: "Expenses",
                schema: "MoneyMinderr");

            migrationBuilder.DropTable(
                name: "Incomes",
                schema: "MoneyMinderr");

            migrationBuilder.DropTable(
                name: "MonthlyIncomes",
                schema: "MoneyMinderr");

            migrationBuilder.DropTable(
                name: "MonthlyPayments",
                schema: "MoneyMinderr");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "MoneyMinderr");

            migrationBuilder.DropTable(
                name: "Budgets",
                schema: "MoneyMinderr");

            migrationBuilder.DropTable(
                name: "CurrencyAccounts",
                schema: "MoneyMinderr");
        }
    }
}
