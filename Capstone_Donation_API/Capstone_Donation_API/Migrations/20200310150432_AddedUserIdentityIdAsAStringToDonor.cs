using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Donation_API.Migrations
{
    public partial class AddedUserIdentityIdAsAStringToDonor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIdentityId",
                table: "Donors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdentityId",
                table: "Donors");
        }
    }
}
