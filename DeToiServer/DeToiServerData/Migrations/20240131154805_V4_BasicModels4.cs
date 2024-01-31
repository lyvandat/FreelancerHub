using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V4_BasicModels4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceAccountSkill_Freelancers_FreelancersId",
                table: "FreelanceAccountSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceAccountSkill_Skills_SkillsId",
                table: "FreelanceAccountSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreelanceAccountSkill",
                table: "FreelanceAccountSkill");

            migrationBuilder.RenameTable(
                name: "FreelanceAccountSkill",
                newName: "FreelanceSkills");

            migrationBuilder.RenameIndex(
                name: "IX_FreelanceAccountSkill_SkillsId",
                table: "FreelanceSkills",
                newName: "IX_FreelanceSkills_SkillsId");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ShoppingServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Services",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RepairingServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "RepairingServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                table: "CleaningServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreelanceSkills",
                table: "FreelanceSkills",
                columns: new[] { "FreelancersId", "SkillsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FreelanceSkills_Freelancers_FreelancersId",
                table: "FreelanceSkills",
                column: "FreelancersId",
                principalTable: "Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreelanceSkills_Skills_SkillsId",
                table: "FreelanceSkills",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceSkills_Freelancers_FreelancersId",
                table: "FreelanceSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceSkills_Skills_SkillsId",
                table: "FreelanceSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreelanceSkills",
                table: "FreelanceSkills");

            migrationBuilder.RenameTable(
                name: "FreelanceSkills",
                newName: "FreelanceAccountSkill");

            migrationBuilder.RenameIndex(
                name: "IX_FreelanceSkills_SkillsId",
                table: "FreelanceAccountSkill",
                newName: "IX_FreelanceAccountSkill_SkillsId");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ShoppingServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

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

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RepairingServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "RepairingServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "CleaningServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "CleaningServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "CleaningServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                table: "CleaningServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreelanceAccountSkill",
                table: "FreelanceAccountSkill",
                columns: new[] { "FreelancersId", "SkillsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FreelanceAccountSkill_Freelancers_FreelancersId",
                table: "FreelanceAccountSkill",
                column: "FreelancersId",
                principalTable: "Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreelanceAccountSkill_Skills_SkillsId",
                table: "FreelanceAccountSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
