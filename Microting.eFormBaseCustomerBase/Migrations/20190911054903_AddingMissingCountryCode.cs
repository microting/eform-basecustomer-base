using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormBaseCustomerBase.Migrations
{
    public partial class AddingMissingCountryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "CustomerVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Customers");
        }
    }
}
