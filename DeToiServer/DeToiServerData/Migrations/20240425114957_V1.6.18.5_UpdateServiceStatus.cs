using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V16185_UpdateServiceStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategories_ServiceActivationStatus_ServiceActivationStatusId",
                table: "ServiceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypes_ServiceActivationStatus_ActivationStatusId",
                table: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "ServiceActivationStatus");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTypes_ActivationStatusId",
                table: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCategories_ServiceActivationStatusId",
                table: "ServiceCategories");

            migrationBuilder.DropColumn(
                name: "ActivationStatusId",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "ServiceActivationStatusId",
                table: "ServiceCategories");

            migrationBuilder.AddColumn<string>(
                name: "AddressRequireOption",
                table: "ServiceTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "destination");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "ServiceStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ServiceTypeStatuses",
                columns: table => new
                {
                    ServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeStatuses", x => new { x.ServiceTypeId, x.ServiceStatusId });
                    table.ForeignKey(
                        name: "FK_ServiceTypeStatuses_ServiceStatuses_ServiceStatusId",
                        column: x => x.ServiceStatusId,
                        principalTable: "ServiceStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceTypeStatuses_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("0774e101-f1a3-4186-af1e-af95a26e9ead"),
                column: "Icon",
                value: "faHouse");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2"),
                column: "Icon",
                value: "faHouse");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("3f98b502-7245-4e86-b7b4-7db05357a1f8"),
                column: "Icon",
                value: "faHouse");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("8a9f22f1-3c67-49f7-bd84-ec290e4a37fd"),
                column: "Icon",
                value: "faHouse");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a53e9887-2186-4ff8-a009-f7706c800b52"),
                column: "Icon",
                value: "faHouse");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32"),
                column: "Icon",
                value: "faHouse");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a888efc3-1d7b-445a-b38c-758737b67bad"),
                column: "Icon",
                value: "faHouse");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeStatuses_ServiceStatusId",
                table: "ServiceTypeStatuses",
                column: "ServiceStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceTypeStatuses");

            migrationBuilder.DropColumn(
                name: "AddressRequireOption",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "ServiceStatuses");

            migrationBuilder.AddColumn<Guid>(
                name: "ActivationStatusId",
                table: "ServiceTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceActivationStatusId",
                table: "ServiceCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceActivationStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceActivationStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_ActivationStatusId",
                table: "ServiceTypes",
                column: "ActivationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategories_ServiceActivationStatusId",
                table: "ServiceCategories",
                column: "ServiceActivationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategories_ServiceActivationStatus_ServiceActivationStatusId",
                table: "ServiceCategories",
                column: "ServiceActivationStatusId",
                principalTable: "ServiceActivationStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypes_ServiceActivationStatus_ActivationStatusId",
                table: "ServiceTypes",
                column: "ActivationStatusId",
                principalTable: "ServiceActivationStatus",
                principalColumn: "Id");
        }
    }
}
