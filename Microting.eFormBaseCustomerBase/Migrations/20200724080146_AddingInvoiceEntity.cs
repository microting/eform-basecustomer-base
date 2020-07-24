using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormBaseCustomerBase.Migrations
{
    public partial class AddingInvoiceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissions_FK_Plugi",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                table: "PluginGroupPermissionVersions");

            // migrationBuilder.DropIndex(
            //     name: "IX_PluginGroupPermissionVersions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
            //     table: "PluginGroupPermissionVersions");

            migrationBuilder.DropIndex(
                name: "IX_PluginGroupPermissionVersions_PermissionId",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.DropIndex(
                name: "IX_Fields_Name",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RelatedEntityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Date = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    GrossAmount = table.Column<DateTime>(nullable: false),
                    NetAmount = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Pdf = table.Column<string>(nullable: true),
                    VatAmount = table.Column<int>(nullable: false),
                    Remainder = table.Column<int>(nullable: false),
                    RemainderBaseCurrency = table.Column<int>(nullable: false),
                    VatIncluded = table.Column<bool>(nullable: false),
                    PageNo = table.Column<int>(nullable: false),
                    ApiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Date = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    GrossAmount = table.Column<DateTime>(nullable: false),
                    NetAmount = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Pdf = table.Column<string>(nullable: true),
                    VatAmount = table.Column<int>(nullable: false),
                    Remainder = table.Column<int>(nullable: false),
                    RemainderBaseCurrency = table.Column<int>(nullable: false),
                    VatIncluded = table.Column<bool>(nullable: false),
                    PageNo = table.Column<int>(nullable: false),
                    ApiId = table.Column<int>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceVersions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceVersions_CustomerId",
                table: "InvoiceVersions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "InvoiceVersions");

            migrationBuilder.AddColumn<int>(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Name",
                table: "Fields",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RelatedEntityId",
                table: "Customers",
                column: "RelatedEntityId",
                unique: true,
                filter: "[RelatedEntityId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                principalTable: "PluginGroupPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId",
                principalTable: "PluginPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
