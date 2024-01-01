using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonService.Infrastructure.Data.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    wallet_name = table.Column<string>(type: "text", nullable: true),
                    profile_created_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "referrals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_name = table.Column<string>(type: "text", nullable: false),
                    referral_name = table.Column<string>(type: "text", nullable: false),
                    referral_id = table.Column<Guid>(type: "uuid", nullable: false),
                    income = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_referrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_referrals_persons_referral_id",
                        column: x => x.referral_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_referrals_referral_id",
                table: "referrals",
                column: "referral_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "referrals");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
