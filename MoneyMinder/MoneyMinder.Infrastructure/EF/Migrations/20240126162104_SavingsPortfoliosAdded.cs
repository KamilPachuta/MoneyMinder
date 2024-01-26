using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMinder.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class SavingsPortfoliosAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavingsPortfolios",
                schema: "MoneyMinderr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    PlannedAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    ActualAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsPortfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsPortfolios_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "MoneyMinderr",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavingsPortfolios_AccountId",
                schema: "MoneyMinderr",
                table: "SavingsPortfolios",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavingsPortfolios",
                schema: "MoneyMinderr");
        }
    }
}
