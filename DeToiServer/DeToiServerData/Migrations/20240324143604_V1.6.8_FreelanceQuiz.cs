using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V168_FreelanceQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceClones");

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("2442392a-20f6-403f-9d16-fc77553a5cef"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("655c2497-9f5a-40ca-a659-fc129893ec4f"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("7415683a-c434-47ca-b913-0b98432a3307"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("408174fe-eedd-46c0-9800-b77445d18e23"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("f93fa429-1cd1-432c-89cb-5b8f81e4d697"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("04b710c1-b3da-4593-b64a-4c2a4c97da9d"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("3a995894-8685-459c-a619-2e3622d390d8"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("eed48235-238c-4281-ab1f-04e66fb4b84e"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("3b6a4ec0-a67c-4086-9808-aabbde67b3d9"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("4d24e5c5-1fab-4bd6-8fa6-253bc88e7894"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("7be23889-f6d2-445e-ad4a-270f68523cf6"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("81feed3a-b24e-4ff6-94ab-51cdb3da2147"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("853f4e96-384b-4f1c-93bc-f80010a387c4"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("99b34594-bbd7-4e16-8bb2-79fac59e135c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("e383e057-7122-4382-9c78-3e0375da9d28"));

            migrationBuilder.CreateTable(
                name: "FreelanceQuizQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfSkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelanceQuizQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreelanceQuizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalTime = table.Column<int>(type: "int", nullable: false),
                    TotalQuestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelanceQuizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreelanceQuizAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelanceQuizAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreelanceQuizAnswers_FreelanceQuizQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FreelanceQuizQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FreelanceQuizResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCorrect = table.Column<int>(type: "int", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelanceQuizResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreelanceQuizResults_FreelanceQuizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "FreelanceQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreelanceQuizResults_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => new { x.QuizId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_QuizQuestions_FreelanceQuizQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FreelanceQuizQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuizQuestions_FreelanceQuizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "FreelanceQuizzes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FreelanceCorrectQuestions",
                columns: table => new
                {
                    ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelanceCorrectQuestions", x => new { x.ResultId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_FreelanceCorrectQuestions_FreelanceQuizQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FreelanceQuizQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FreelanceCorrectQuestions_FreelanceQuizResults_ResultId",
                        column: x => x.ResultId,
                        principalTable: "FreelanceQuizResults",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("3125d91d-6514-4b2f-8659-30053bfbd817"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("9b26abee-0a58-42ab-ab54-513f426efa58"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("e0fffebe-561b-4cc5-ba40-24b1ecbd32a8"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("77e2226d-b004-4efb-9143-bd0eac9dfb54"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("d73d6560-cc60-4f1e-81b1-fb298da2a3b0"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("81daab7a-6023-4582-b09b-f36df4decfc6"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("d50b8357-0610-4b3a-b55d-eafc7c796927"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("d78160ce-d75d-4cfe-b7ab-68cf33f7a3d2"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("27c731e1-475c-43d5-b553-0da58e93a088"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("487879e1-0510-4d5e-a8af-53abf0e71bc8"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("498667b1-287d-4edd-8ada-beaedd1eed4d"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "1" },
                    { new Guid("b404edda-e35b-41fd-9b33-ea59845fbfca"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("c8fb9e92-64bd-4a22-bdcc-50abc5c2b2b5"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("e571f4ad-f69c-419d-874d-9e6dce0ffb5e"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceCorrectQuestions_QuestionId",
                table: "FreelanceCorrectQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceQuizAnswers_QuestionId",
                table: "FreelanceQuizAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceQuizResults_FreelancerId",
                table: "FreelanceQuizResults",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceQuizResults_QuizId",
                table: "FreelanceQuizResults",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuestionId",
                table: "QuizQuestions",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreelanceCorrectQuestions");

            migrationBuilder.DropTable(
                name: "FreelanceQuizAnswers");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "FreelanceQuizResults");

            migrationBuilder.DropTable(
                name: "FreelanceQuizQuestions");

            migrationBuilder.DropTable(
                name: "FreelanceQuizzes");

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("3125d91d-6514-4b2f-8659-30053bfbd817"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("9b26abee-0a58-42ab-ab54-513f426efa58"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("e0fffebe-561b-4cc5-ba40-24b1ecbd32a8"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("77e2226d-b004-4efb-9143-bd0eac9dfb54"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("d73d6560-cc60-4f1e-81b1-fb298da2a3b0"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("81daab7a-6023-4582-b09b-f36df4decfc6"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("d50b8357-0610-4b3a-b55d-eafc7c796927"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("d78160ce-d75d-4cfe-b7ab-68cf33f7a3d2"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("27c731e1-475c-43d5-b553-0da58e93a088"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("487879e1-0510-4d5e-a8af-53abf0e71bc8"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("498667b1-287d-4edd-8ada-beaedd1eed4d"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b404edda-e35b-41fd-9b33-ea59845fbfca"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("c8fb9e92-64bd-4a22-bdcc-50abc5c2b2b5"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("e571f4ad-f69c-419d-874d-9e6dce0ffb5e"));

            migrationBuilder.CreateTable(
                name: "ServiceClones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requirement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceClones", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("2442392a-20f6-403f-9d16-fc77553a5cef"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("655c2497-9f5a-40ca-a659-fc129893ec4f"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("7415683a-c434-47ca-b913-0b98432a3307"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("408174fe-eedd-46c0-9800-b77445d18e23"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("f93fa429-1cd1-432c-89cb-5b8f81e4d697"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("04b710c1-b3da-4593-b64a-4c2a4c97da9d"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("3a995894-8685-459c-a619-2e3622d390d8"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("eed48235-238c-4281-ab1f-04e66fb4b84e"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("3b6a4ec0-a67c-4086-9808-aabbde67b3d9"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("4d24e5c5-1fab-4bd6-8fa6-253bc88e7894"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("7be23889-f6d2-445e-ad4a-270f68523cf6"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("81feed3a-b24e-4ff6-94ab-51cdb3da2147"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("853f4e96-384b-4f1c-93bc-f80010a387c4"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("99b34594-bbd7-4e16-8bb2-79fac59e135c"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("e383e057-7122-4382-9c78-3e0375da9d28"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" }
                });
        }
    }
}
