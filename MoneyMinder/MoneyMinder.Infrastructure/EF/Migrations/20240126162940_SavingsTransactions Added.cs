using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMinder.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class SavingsTransactionsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavingsTransactions",
                schema: "MoneyMinderr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    SavingsPortfolioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsTransactions_SavingsPortfolios_SavingsPortfolioId",
                        column: x => x.SavingsPortfolioId,
                        principalSchema: "MoneyMinderr",
                        principalTable: "SavingsPortfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavingsTransactions_SavingsPortfolioId",
                schema: "MoneyMinderr",
                table: "SavingsTransactions",
                column: "SavingsPortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavingsTransactions",
                schema: "MoneyMinderr");
        }
    }
}
