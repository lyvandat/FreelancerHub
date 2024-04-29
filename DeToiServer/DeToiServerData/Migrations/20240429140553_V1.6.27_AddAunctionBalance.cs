using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1627_AddAunctionBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuctionBalance",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuctionBalance",
                table: "Freelancers");
        }
    }
}
