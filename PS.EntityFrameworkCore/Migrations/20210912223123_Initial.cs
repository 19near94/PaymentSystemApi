using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    balance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransaction",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    account_id = table.Column<string>(nullable: true),
                    amount = table.Column<double>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    AcctBalanceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Accounts_AcctBalanceId",
                        column: x => x.AcctBalanceId,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_AcctBalanceId",
                table: "AccountTransaction",
                column: "AcctBalanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransaction");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
