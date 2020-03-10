using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Donation_API.Migrations
{
    public partial class RenamedPropertyToIdentityUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdentityId",
                table: "Donors");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Donors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Donors");

            migrationBuilder.AddColumn<string>(
                name: "UserIdentityId",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
