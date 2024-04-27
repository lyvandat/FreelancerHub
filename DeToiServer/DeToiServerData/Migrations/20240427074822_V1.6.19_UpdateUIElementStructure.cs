using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1619_UpdateUIElementStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UIElementInputOptionInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mask = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buttons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIElementInputOptionInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UIElementInputOptionInfos_UIElementInputOptions_OptionId",
                        column: x => x.OptionId,
                        principalTable: "UIElementInputOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UIElementInputOptionInfoValidations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIElementInputOptionInfoValidations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UIElementInputOptionInfoValidations_UIElementInputOptionInfos_InfoId",
                        column: x => x.InfoId,
                        principalTable: "UIElementInputOptionInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UIElementInputOptionInfos_OptionId",
                table: "UIElementInputOptionInfos",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UIElementInputOptionInfoValidations_InfoId",
                table: "UIElementInputOptionInfoValidations",
                column: "InfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UIElementInputOptionInfoValidations");

            migrationBuilder.DropTable(
                name: "UIElementInputOptionInfos");
        }
    }
}
