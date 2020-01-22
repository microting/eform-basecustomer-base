using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormBaseCustomerBase.Migrations
{
    public partial class AddingMorePropertiesToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "CustomerVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CadastralNumber",
                table: "CustomerVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompletionYear",
                table: "CustomerVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorsWithLivingSpace",
                table: "CustomerVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyNumber",
                table: "CustomerVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CadastralNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompletionYear",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorsWithLivingSpace",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyNumber",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "CadastralNumber",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "CompletionYear",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "FloorsWithLivingSpace",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "PropertyNumber",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CadastralNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompletionYear",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FloorsWithLivingSpace",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PropertyNumber",
                table: "Customers");
        }
    }
}
