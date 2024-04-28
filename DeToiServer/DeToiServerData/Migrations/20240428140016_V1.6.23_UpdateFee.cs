using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1623_UpdateFee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "Id", "Amount", "Type" },
                values: new object[,]
                {
                    { new Guid("3e85a38f-21e3-43e8-9ecb-1d697a9cebf1"), 50000.0, "MinServicePrice" },
                    { new Guid("4165cef1-7486-45d6-9ce1-677dc35956d5"), 0.050000000000000003, "Platform" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fees_Type",
                table: "Fees",
                column: "Type",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fees");
        }
    }
}
