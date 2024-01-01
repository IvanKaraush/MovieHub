using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonService.Infrastructure.Data.Migrations
{
    public partial class FixNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "referrals",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "referrals",
                newName: "Id");
        }
    }
}
