using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMinder.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class SmallRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                schema: "MoneyMinderr",
                table: "Expenses");

            migrationBuilder.AlterColumn<Guid>(
                name: "BudgetId",
                schema: "MoneyMinderr",
                table: "Expenses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                schema: "MoneyMinderr",
                table: "Expenses",
                column: "BudgetId",
                principalSchema: "MoneyMinderr",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                schema: "MoneyMinderr",
                table: "Expenses");

            migrationBuilder.AlterColumn<Guid>(
                name: "BudgetId",
                schema: "MoneyMinderr",
                table: "Expenses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                schema: "MoneyMinderr",
                table: "Expenses",
                column: "BudgetId",
                principalSchema: "MoneyMinderr",
                principalTable: "Budgets",
                principalColumn: "Id");
        }
    }
}
