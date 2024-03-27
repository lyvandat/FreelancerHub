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

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "UIElementServiceRequirements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "UIElementAdditionServiceRequirements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MediaType",
                table: "ServiceProven",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("0f6f1894-3ee7-46a8-9939-842e3c620231"),
                column: "ServiceClassName",
                value: "ElectronicsCleaning");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"),
                column: "ServiceClassName",
                value: "Moving");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f"),
                column: "ServiceClassName",
                value: "Shopping");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a"),
                column: "ServiceClassName",
                value: "Repairing");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e"),
                column: "ServiceClassName",
                value: "Cleaning");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("07cb166a-4b4e-4637-b224-6277a69003d9"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3361bc88-9f58-4be8-ac37-561606430f8a"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3779d349-abcb-4dbc-abf1-25ba9e94a695"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("63ce2ebf-ef36-4b4a-891e-abbde2a75b38"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("662a64be-f7ea-4419-8978-dbf8f19159dc"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("73bf981f-1cfd-483d-80ee-14ab6d2e55ef"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("88006a8c-d757-4b85-8b91-c88e6078fe9c"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("96d250d4-0c0e-4521-b94e-05f3cafca3f3"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a5677de0-a6a7-42c0-ab77-f34b75beb63d"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b9f74f9e-f792-4c48-b1b6-b6f0bc402d07"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c82954a1-39d4-4012-86b3-6cad42c2b399"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cca752d4-c17c-4c31-906f-f33cb8a18e48"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ef2034c1-7f44-4d07-b9c0-e2a497999a9d"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f1b832b2-49f3-456f-bacb-b1f8da766bea"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "Priority", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("e4808927-3dc6-46b7-b7ab-5edf2afbcc67"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("f670b870-421a-4837-b16b-9029ab626e84"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[] { new Guid("fa2ac76a-fe36-4db3-897e-8c692644dd7f"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("c1172732-84d4-417e-9ad6-7ffea5607ad1"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("f365e9d6-5b78-4e3c-8fd7-16db18012ab4"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "Priority", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("96b6ea1b-226b-423c-a7d1-00c419d53f95"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("bca8b656-0db5-470a-acae-a7869b0ca1d8"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[] { new Guid("c969b51b-1cc9-4479-8069-197a16673a00"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("6d68d0c3-fbe5-4e5a-a45e-de03922307fd"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "1" },
                    { new Guid("99bb4829-3134-40fc-a8fb-a9cd9e00b90a"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("9f467b46-d2bc-48f3-a546-8cbd814ac917"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("bc06c177-029b-45e8-a5e4-df1d5ab43e31"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("c3551f80-af69-410c-88d5-8f5bd9448200"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("d47c6be0-e8b2-4091-b341-35d44dbd1a40"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null }
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
                keyValue: new Guid("e4808927-3dc6-46b7-b7ab-5edf2afbcc67"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("f670b870-421a-4837-b16b-9029ab626e84"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("fa2ac76a-fe36-4db3-897e-8c692644dd7f"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("c1172732-84d4-417e-9ad6-7ffea5607ad1"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("f365e9d6-5b78-4e3c-8fd7-16db18012ab4"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("96b6ea1b-226b-423c-a7d1-00c419d53f95"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("bca8b656-0db5-470a-acae-a7869b0ca1d8"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("c969b51b-1cc9-4479-8069-197a16673a00"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("6d68d0c3-fbe5-4e5a-a45e-de03922307fd"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("99bb4829-3134-40fc-a8fb-a9cd9e00b90a"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("9f467b46-d2bc-48f3-a546-8cbd814ac917"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("bc06c177-029b-45e8-a5e4-df1d5ab43e31"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("c3551f80-af69-410c-88d5-8f5bd9448200"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("d47c6be0-e8b2-4091-b341-35d44dbd1a40"));

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "UIElementServiceRequirements");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "UIElementAdditionServiceRequirements");

            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "ServiceProven");

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

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("0f6f1894-3ee7-46a8-9939-842e3c620231"),
                column: "ServiceClassName",
                value: "ElectronicsCleaningService");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"),
                column: "ServiceClassName",
                value: "MovingService");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f"),
                column: "ServiceClassName",
                value: "ShoppingService");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a"),
                column: "ServiceClassName",
                value: "RepairingService");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e"),
                column: "ServiceClassName",
                value: "CleaningService");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("07cb166a-4b4e-4637-b224-6277a69003d9"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3361bc88-9f58-4be8-ac37-561606430f8a"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3779d349-abcb-4dbc-abf1-25ba9e94a695"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("63ce2ebf-ef36-4b4a-891e-abbde2a75b38"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("662a64be-f7ea-4419-8978-dbf8f19159dc"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("73bf981f-1cfd-483d-80ee-14ab6d2e55ef"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("88006a8c-d757-4b85-8b91-c88e6078fe9c"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("96d250d4-0c0e-4521-b94e-05f3cafca3f3"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a5677de0-a6a7-42c0-ab77-f34b75beb63d"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b9f74f9e-f792-4c48-b1b6-b6f0bc402d07"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c82954a1-39d4-4012-86b3-6cad42c2b399"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cca752d4-c17c-4c31-906f-f33cb8a18e48"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ef2034c1-7f44-4d07-b9c0-e2a497999a9d"),
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f1b832b2-49f3-456f-bacb-b1f8da766bea"),
                column: "Image",
                value: null);

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
