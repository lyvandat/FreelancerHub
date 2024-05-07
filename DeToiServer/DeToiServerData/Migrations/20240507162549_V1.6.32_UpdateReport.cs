using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1632_UpdateReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Accounts_FromId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Accounts_ToId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "Reports",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "Reports",
                newName: "FromAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ToId",
                table: "Reports",
                newName: "IX_Reports_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_FromId",
                table: "Reports",
                newName: "IX_Reports_FromAccountId");

            migrationBuilder.CreateTable(
                name: "ReportImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportImages_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportImages_ReportId",
                table: "ReportImages",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Accounts_FromAccountId",
                table: "Reports",
                column: "FromAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Orders_OrderId",
                table: "Reports",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Accounts_FromAccountId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Orders_OrderId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "ReportImages");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Reports",
                newName: "ToId");

            migrationBuilder.RenameColumn(
                name: "FromAccountId",
                table: "Reports",
                newName: "FromId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_OrderId",
                table: "Reports",
                newName: "IX_Reports_ToId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_FromAccountId",
                table: "Reports",
                newName: "IX_Reports_FromId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Accounts_FromId",
                table: "Reports",
                column: "FromId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Accounts_ToId",
                table: "Reports",
                column: "ToId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
