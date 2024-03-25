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
                    TotalQuestion = table.Column<int>(type: "int", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelanceQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreelanceQuizzes_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
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
                    { new Guid("0bbbc3d6-4c7f-4b6d-bd8f-35e3b66b9df6"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("589580f5-7943-44a7-b9dd-54d78e90fdda"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("d7571ef5-f696-4ff6-a1f2-5af0cc4518fe"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("0e61408b-15d1-4e45-be0c-f9d43d32b299"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("ac4fb75b-497d-4e45-b8db-4a9d3b47dee1"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("28e52281-2dff-42f6-a3e9-7255b8489751"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("45811fc1-d5e3-46c8-9ec5-613d9580eaa0"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("fa8a946d-7822-4aad-8b52-563c658c66ac"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("08d8f2a4-376f-4ac6-b30b-03f99cc5fd16"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("4c092111-0abe-4e7d-83fb-248558cc6e7a"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("8b945d7e-8794-4601-be3a-23e06d291dd8"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("e546c1dc-532d-4a00-8bec-720e194be822"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("e9c1e5ae-62b4-4f9c-bab1-99b36ba3b64c"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("f06c0488-0525-4117-ae95-666b5d9fbe08"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "1" }
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
                name: "IX_FreelanceQuizResults_QuizId",
                table: "FreelanceQuizResults",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceQuizzes_FreelancerId",
                table: "FreelanceQuizzes",
                column: "FreelancerId");

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
                keyValue: new Guid("0bbbc3d6-4c7f-4b6d-bd8f-35e3b66b9df6"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("589580f5-7943-44a7-b9dd-54d78e90fdda"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("d7571ef5-f696-4ff6-a1f2-5af0cc4518fe"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("0e61408b-15d1-4e45-be0c-f9d43d32b299"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("ac4fb75b-497d-4e45-b8db-4a9d3b47dee1"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("28e52281-2dff-42f6-a3e9-7255b8489751"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("45811fc1-d5e3-46c8-9ec5-613d9580eaa0"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("fa8a946d-7822-4aad-8b52-563c658c66ac"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("08d8f2a4-376f-4ac6-b30b-03f99cc5fd16"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("4c092111-0abe-4e7d-83fb-248558cc6e7a"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8b945d7e-8794-4601-be3a-23e06d291dd8"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("e546c1dc-532d-4a00-8bec-720e194be822"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("e9c1e5ae-62b4-4f9c-bab1-99b36ba3b64c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f06c0488-0525-4117-ae95-666b5d9fbe08"));

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
