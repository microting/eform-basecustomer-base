using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormBaseCustomerBase.Migrations
{
    public partial class AddingMoreFieldsToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "CustomerVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreditLimit",
                table: "CustomerVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentOverdue",
                table: "CustomerVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "CustomerVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreditLimit",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentOverdue",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "PaymentOverdue",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "CustomerVersions");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PaymentOverdue",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Customers");
        }
    }
}
