using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1628_UpdateNotificationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PushBadgeCount",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PushSound",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PushSubTitle",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("8a9f22f1-3c67-49f7-bd84-ec290e4a37fd"),
                column: "Name",
                value: "Chưa hoạt động");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32"),
                column: "Name",
                value: "Đã hoàn thành");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PushBadgeCount",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PushSound",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PushSubTitle",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("8a9f22f1-3c67-49f7-bd84-ec290e4a37fd"),
                column: "Name",
                value: "Chưa đến giờ hoạt động");

            migrationBuilder.UpdateData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32"),
                column: "Name",
                value: "Đã hoàn thành nhiệm vụ");
        }
    }
}
