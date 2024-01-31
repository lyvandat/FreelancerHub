using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V2_BasicModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_DeviceInfo_DeviceInfoId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_HomeInfo_HomeInfoId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ShoppingInfo_ShoppingInfoId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_DeviceInfoId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_HomeInfoId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ShoppingInfoId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CleaningService_Price",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeviceInfoId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "HomeInfoId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ShoppingInfoId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ShoppingService_Price",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Services");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Services",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.CreateTable(
                name: "CleaningServices",
                columns: table => new
                {
                    CleaningServiceId = table.Column<int>(type: "int", nullable: false),
                    HomeInfoId = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningServices", x => x.CleaningServiceId);
                    table.ForeignKey(
                        name: "FK_CleaningServices_HomeInfo_HomeInfoId",
                        column: x => x.HomeInfoId,
                        principalTable: "HomeInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CleaningServices_Services_CleaningServiceId",
                        column: x => x.CleaningServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairingServices",
                columns: table => new
                {
                    RepairingServiceId = table.Column<int>(type: "int", nullable: false),
                    DeviceInfoId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairingServices", x => x.RepairingServiceId);
                    table.ForeignKey(
                        name: "FK_RepairingServices_DeviceInfo_DeviceInfoId",
                        column: x => x.DeviceInfoId,
                        principalTable: "DeviceInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepairingServices_Services_RepairingServiceId",
                        column: x => x.RepairingServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingServices",
                columns: table => new
                {
                    ShoppingServiceId = table.Column<int>(type: "int", nullable: false),
                    ShoppingInfoId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingServices", x => x.ShoppingServiceId);
                    table.ForeignKey(
                        name: "FK_ShoppingServices_Services_ShoppingServiceId",
                        column: x => x.ShoppingServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingServices_ShoppingInfo_ShoppingInfoId",
                        column: x => x.ShoppingInfoId,
                        principalTable: "ShoppingInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleaningServices_HomeInfoId",
                table: "CleaningServices",
                column: "HomeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairingServices_DeviceInfoId",
                table: "RepairingServices",
                column: "DeviceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingServices_ShoppingInfoId",
                table: "ShoppingServices",
                column: "ShoppingInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleaningServices");

            migrationBuilder.DropTable(
                name: "RepairingServices");

            migrationBuilder.DropTable(
                name: "ShoppingServices");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Services",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21,
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CleaningService_Price",
                table: "Services",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceInfoId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Services",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeInfoId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Services",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingInfoId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ShoppingService_Price",
                table: "Services",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Services",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_DeviceInfoId",
                table: "Services",
                column: "DeviceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_HomeInfoId",
                table: "Services",
                column: "HomeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ShoppingInfoId",
                table: "Services",
                column: "ShoppingInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_DeviceInfo_DeviceInfoId",
                table: "Services",
                column: "DeviceInfoId",
                principalTable: "DeviceInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_HomeInfo_HomeInfoId",
                table: "Services",
                column: "HomeInfoId",
                principalTable: "HomeInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ShoppingInfo_ShoppingInfoId",
                table: "Services",
                column: "ShoppingInfoId",
                principalTable: "ShoppingInfo",
                principalColumn: "Id");
        }
    }
}
