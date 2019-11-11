using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormBaseCustomerBase.Migrations
{
    public partial class AddingCrmIdToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrmId",
                table: "CustomerVersions",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CrmId",
                table: "Customers",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrmId",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "CrmId",
                table: "Customers");
        }
    }
}
