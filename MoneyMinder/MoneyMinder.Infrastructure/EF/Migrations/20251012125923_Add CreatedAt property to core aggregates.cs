using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMinder.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtpropertytocoreaggregates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                schema: "MoneyMinder",
                table: "SavingsTransactions",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "MoneyMinder",
                table: "SavingsAccounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<byte>(
                name: "Category",
                schema: "MoneyMinder",
                table: "Payments",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "Category",
                schema: "MoneyMinder",
                table: "Limits",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "MoneyMinder",
                table: "CurrencyAccounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "MoneyMinder",
                table: "Accounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "MoneyMinder",
                table: "SavingsAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "MoneyMinder",
                table: "CurrencyAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "MoneyMinder",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "MoneyMinder",
                table: "SavingsTransactions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                schema: "MoneyMinder",
                table: "Payments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                schema: "MoneyMinder",
                table: "Limits",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");
        }
    }
}
