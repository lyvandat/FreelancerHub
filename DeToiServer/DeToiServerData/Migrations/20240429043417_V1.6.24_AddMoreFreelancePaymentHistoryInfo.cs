using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1624_AddMoreFreelancePaymentHistoryInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelancePaymentHistories_Freelancers_FreelanceAccountId",
                table: "FreelancePaymentHistories");

            migrationBuilder.RenameColumn(
                name: "FreelanceAccountId",
                table: "FreelancePaymentHistories",
                newName: "FreelancerId");

            migrationBuilder.RenameIndex(
                name: "IX_FreelancePaymentHistories_FreelanceAccountId",
                table: "FreelancePaymentHistories",
                newName: "IX_FreelancePaymentHistories_FreelancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FreelancePaymentHistories_Freelancers_FreelancerId",
                table: "FreelancePaymentHistories",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelancePaymentHistories_Freelancers_FreelancerId",
                table: "FreelancePaymentHistories");

            migrationBuilder.RenameColumn(
                name: "FreelancerId",
                table: "FreelancePaymentHistories",
                newName: "FreelanceAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_FreelancePaymentHistories_FreelancerId",
                table: "FreelancePaymentHistories",
                newName: "IX_FreelancePaymentHistories_FreelanceAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_FreelancePaymentHistories_Freelancers_FreelanceAccountId",
                table: "FreelancePaymentHistories",
                column: "FreelanceAccountId",
                principalTable: "Freelancers",
                principalColumn: "Id");
        }
    }
}
