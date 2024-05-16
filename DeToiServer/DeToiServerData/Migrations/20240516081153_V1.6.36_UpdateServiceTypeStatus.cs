using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1636_UpdateServiceTypeStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypeStatuses_ServiceStatuses_ServiceStatusId",
                table: "ServiceTypeStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypeStatuses_ServiceTypes_ServiceTypeId",
                table: "ServiceTypeStatuses");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypeStatuses_ServiceStatuses_ServiceStatusId",
                table: "ServiceTypeStatuses",
                column: "ServiceStatusId",
                principalTable: "ServiceStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypeStatuses_ServiceTypes_ServiceTypeId",
                table: "ServiceTypeStatuses",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypeStatuses_ServiceStatuses_ServiceStatusId",
                table: "ServiceTypeStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypeStatuses_ServiceTypes_ServiceTypeId",
                table: "ServiceTypeStatuses");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypeStatuses_ServiceStatuses_ServiceStatusId",
                table: "ServiceTypeStatuses",
                column: "ServiceStatusId",
                principalTable: "ServiceStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypeStatuses_ServiceTypes_ServiceTypeId",
                table: "ServiceTypeStatuses",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id");
        }
    }
}
