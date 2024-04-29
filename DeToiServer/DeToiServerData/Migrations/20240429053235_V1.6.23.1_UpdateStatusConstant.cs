using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V16231_UpdateStatusConstant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ServiceStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("0774e101-f1a3-4186-af1e-af95a26e9ead"),
                columns: new[] { "Icon", "Priority" },
                values: new object[] { "faHandshakeSimpleSlash", 5 });

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2"),
                columns: new[] { "Icon", "Name", "Priority" },
                values: new object[] { "faPersonRunning", "Đang di chuyển", 3 });

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("3f98b502-7245-4e86-b7b4-7db05357a1f8"),
                columns: new[] { "Icon", "Priority" },
                values: new object[] { "faPersonDigging", 3 });

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("8a9f22f1-3c67-49f7-bd84-ec290e4a37fd"),
                columns: new[] { "Icon", "Priority" },
                values: new object[] { "faRoadCircleXmark", 2 });

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a53e9887-2186-4ff8-a009-f7706c800b52"),
                columns: new[] { "Icon", "Priority" },
                values: new object[] { "faHandshake", 1 });

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32"),
                columns: new[] { "Icon", "Priority" },
                values: new object[] { "faPersonCircleCheck", 4 });

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a888efc3-1d7b-445a-b38c-758737b67bad"),
                columns: new[] { "Icon", "Priority" },
                values: new object[] { "faWandMagicSparkles", 0 });

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Icon", "Name", "Priority" },
                values: new object[] { new Guid("083cdec1-ae32-475e-8c64-62599d6fe6c1"), "faTruckFast", "Đang vận chuyển", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("083cdec1-ae32-475e-8c64-62599d6fe6c1"));

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ServiceStatuses");

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
                columns: new[] { "Icon", "Name" },
                values: new object[] { "faHouse", "Đang di chuyển, hãy kiên nhẫn" });

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
        }
    }
}
