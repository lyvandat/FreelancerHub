using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerPayment.Migrations
{
    /// <inheritdoc />
    public partial class V1_AddOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstimatedPrice = table.Column<double>(type: "float", nullable: false),
                    RecommendPrice = table.Column<double>(type: "float", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
