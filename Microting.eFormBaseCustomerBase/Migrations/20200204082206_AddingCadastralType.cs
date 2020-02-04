using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormBaseCustomerBase.Migrations
{
    public partial class AddingCadastralType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CadastralType",
                table: "CustomerVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CadastralType",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CadastralType",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "CadastralType",
                table: "Customers");
        }
    }
}
