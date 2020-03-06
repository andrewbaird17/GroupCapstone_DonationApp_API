using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Donation_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    MedicalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    BloodType = table.Column<string>(nullable: true),
                    OnMedications = table.Column<bool>(nullable: false),
                    HasAllergies = table.Column<bool>(nullable: false),
                    IsMale = table.Column<bool>(nullable: false),
                    Ethnicity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.MedicalId);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    DonorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(nullable: false),
                    MedicalId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.DonorId);
                    table.ForeignKey(
                        name: "FK_Donors_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donors_MedicalHistories_MedicalId",
                        column: x => x.MedicalId,
                        principalTable: "MedicalHistories",
                        principalColumn: "MedicalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "State", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "oconomowoc", "wi", "329 e pleasant st", 53066 },
                    { 2, "milwaukee", "wi", "324 s second st", 53204 },
                    { 3, "milwaukee", "wi", "2100 n kilian pl", 53212 },
                    { 4, "west allis", "wi", "1427 s 75th st", 53214 },
                    { 5, "madison", "wi", "1100 bowen ct", 53715 },
                    { 6, "naperville", "il", "874 havenshire rd", 60565 },
                    { 7, "st paul", "mn", "177 mcknight rd n", 55119 },
                    { 8, "waukesha", "wi", "114 douglass ave", 53186 },
                    { 9, "kenosha", "wi", "1105 57th st", 53140 }
                });

            migrationBuilder.InsertData(
                table: "MedicalHistories",
                columns: new[] { "MedicalId", "Age", "BloodType", "Ethnicity", "HasAllergies", "Height", "IsMale", "OnMedications", "Weight" },
                values: new object[,]
                {
                    { 8, 44, "a-", "asian", true, 49, false, true, 285 },
                    { 7, 19, "ab-", "white", false, 56, true, true, 185 },
                    { 6, 64, "ab+", "pacific islander", true, 63, false, false, 137 },
                    { 5, 75, "o-", " native american/alaskan native", false, 53, false, false, 118 },
                    { 1, 56, "a+", "white", false, 66, true, false, 205 },
                    { 3, 24, "b+", "african american", true, 59, false, false, 180 },
                    { 2, 53, "b-", "white", false, 50, false, true, 140 },
                    { 9, 22, "ab-", "native hawaiian", false, 65, true, false, 155 },
                    { 4, 33, "o+", "white", true, 48, true, true, 345 },
                    { 10, 30, "ab+", "white", false, 55, true, true, 170 }
                });

            migrationBuilder.InsertData(
                table: "Donors",
                columns: new[] { "DonorId", "AddressId", "FirstName", "IsActive", "LastName", "MedicalId" },
                values: new object[,]
                {
                    { 1, 1, "jerry", true, "griswold", 1 },
                    { 2, 1, "mary", true, "griswold", 2 },
                    { 3, 2, "lisa", true, "anderhal", 3 },
                    { 4, 3, "lucas", true, "allen", 4 },
                    { 5, 4, "marissa", true, "gabel", 5 },
                    { 6, 5, "jessica", true, "sievers", 6 },
                    { 7, 6, "trevor", true, "smith", 7 },
                    { 8, 7, "lucy", true, "olson", 8 },
                    { 9, 8, "gabe", true, "neuman", 9 },
                    { 10, 9, "phil", true, "jefferson", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_AddressId",
                table: "Donors",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_MedicalId",
                table: "Donors",
                column: "MedicalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "MedicalHistories");
        }
    }
}
