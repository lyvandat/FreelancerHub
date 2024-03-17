using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V166_UpdateFreelancerSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceSkills_Freelancers_FreelancersId",
                table: "FreelanceSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceSkills_Skills_SkillsId",
                table: "FreelanceSkills");

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("20caafd9-a543-4eda-8be8-0485b1611c7a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("62a3297b-ac1d-463c-bec8-8fbe5d52553e"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("63a2ebd1-3c34-4068-b20e-135d87b16761"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("706c658f-7621-43f1-b12b-421efba7fb41"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("89343ddd-beb2-4a0a-bc27-19833309c70f"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("8f65982a-7eea-4f42-a518-1b52e1fd7d01"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("9c1037af-54ba-45c2-bdad-c889a7e77f06"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ac8152dd-a816-401d-88f3-92592c634a55"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b0289dc1-5d40-41f9-ba23-4f0a43caead6"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8df43cc-8ad2-4bf5-80c4-783f6d7cdf8c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("d1759901-36be-4643-b1dc-06988d02df07"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ea0bff4e-c0c1-4d7d-83ac-95bd7eea27e6"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ea17a32e-ef00-418a-8ece-e78efd5eef14"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f4dc9e54-ccf3-403f-a8ef-04fcd5ca980f"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("000a661a-4ea1-4e1f-92d3-d57c1f018f1a"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("3d7d7b97-ae07-4bce-bb26-aa0e898d44d0"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("7686ddfd-fb8f-4ab3-a8e9-61137f32f746"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("073709d9-c03b-4a78-8bb8-b345fa2acc07"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("821be71d-0ea7-4d00-866b-d2085795ee2e"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("7227416c-a449-4b99-b57c-69e9a311b903"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("7a9104e3-ce99-41a9-bd7b-ebf347eefbcc"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("83a35967-f24d-4c1c-bb30-d1dfb75cbc08"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("6cbd39e4-23b5-4606-95f0-8876c025beb3"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("6de1977b-9370-49c0-8e05-5c0ea9aec20d"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("74a53bc4-06d2-4f14-b1c4-f2cbf28b3027"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("7536d579-fd81-408f-bd8e-7ad3d96d9fbf"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("7a771c93-6950-4ca5-b0e6-3250223aa64b"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("d6b4537d-b39a-43c3-9f20-05e6eb0013e0"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("dd84c818-d28c-4163-9429-a1850f2d11f1"));

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "FreelanceSkills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "FreelancersId",
                table: "FreelanceSkills",
                newName: "FreelancerId");

            migrationBuilder.RenameIndex(
                name: "IX_FreelanceSkills_SkillsId",
                table: "FreelanceSkills",
                newName: "IX_FreelanceSkills_SkillId");

            migrationBuilder.AddColumn<string>(
                name: "SkillCategory",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalReviewCount",
                table: "Freelancers",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Keys", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("07cb166a-4b4e-4637-b224-6277a69003d9"), 4000000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("3361bc88-9f58-4be8-ac37-561606430f8a"), 20000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("3779d349-abcb-4dbc-abf1-25ba9e94a695"), 100000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("63ce2ebf-ef36-4b4a-891e-abbde2a75b38"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("662a64be-f7ea-4419-8978-dbf8f19159dc"), 50000000.0, "Hãy yên tâm không nổ đâu", null, null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("73bf981f-1cfd-483d-80ee-14ab6d2e55ef"), 60000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("88006a8c-d757-4b85-8b91-c88e6078fe9c"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("96d250d4-0c0e-4521-b94e-05f3cafca3f3"), 300000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("a5677de0-a6a7-42c0-ab77-f34b75beb63d"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("b9f74f9e-f792-4c48-b1b6-b6f0bc402d07"), 40000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("c82954a1-39d4-4012-86b3-6cad42c2b399"), 200000.0, "Sửa máy giặt", null, null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("cca752d4-c17c-4c31-906f-f33cb8a18e48"), 50000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("ef2034c1-7f44-4d07-b9c0-e2a497999a9d"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("f1b832b2-49f3-456f-bacb-b1f8da766bea"), 200000.0, "Hãy yên tâm không nổ đâu", null, null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("03dbec9f-9a4b-46a0-8330-352029773c7e"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("4f235eaa-4b25-4f02-8fc9-8bd2d8857065"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("eb5060b8-960d-4c46-8636-016386121c49"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("a832659f-fbc0-4993-8c1d-6fbdf3b850f0"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("c340e9e5-16f6-4631-a276-eba34768a1e7"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("4fb74a10-a23a-457a-9776-a279c5c3df91"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("cfd1bd30-2f2d-4134-a9bc-ee05696a2e80"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("e81456c6-3e66-47ad-b0e3-f69385a3631b"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("0885d284-0aa1-40be-a3a0-036b17dd55ad"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("27e804d3-e8bc-4cf0-870c-39b8125602b3"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("29f926d7-abbb-4355-b2c3-f5ee30af0522"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("2e9b0527-01bf-40ea-90a9-b748873febb8"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("7ead3fc4-1e3b-46d6-aeb9-0c28acf2aff1"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("878a0fcf-6ce4-4d00-84a3-853aeaee0d32"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("8a49e1e5-f594-47f3-b380-8936dd9863c4"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FreelanceSkills_Freelancers_FreelancerId",
                table: "FreelanceSkills",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FreelanceSkills_Skills_SkillId",
                table: "FreelanceSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceSkills_Freelancers_FreelancerId",
                table: "FreelanceSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceSkills_Skills_SkillId",
                table: "FreelanceSkills");

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("07cb166a-4b4e-4637-b224-6277a69003d9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3361bc88-9f58-4be8-ac37-561606430f8a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3779d349-abcb-4dbc-abf1-25ba9e94a695"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("63ce2ebf-ef36-4b4a-891e-abbde2a75b38"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("662a64be-f7ea-4419-8978-dbf8f19159dc"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("73bf981f-1cfd-483d-80ee-14ab6d2e55ef"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("88006a8c-d757-4b85-8b91-c88e6078fe9c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("96d250d4-0c0e-4521-b94e-05f3cafca3f3"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a5677de0-a6a7-42c0-ab77-f34b75beb63d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b9f74f9e-f792-4c48-b1b6-b6f0bc402d07"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c82954a1-39d4-4012-86b3-6cad42c2b399"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cca752d4-c17c-4c31-906f-f33cb8a18e48"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ef2034c1-7f44-4d07-b9c0-e2a497999a9d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f1b832b2-49f3-456f-bacb-b1f8da766bea"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("03dbec9f-9a4b-46a0-8330-352029773c7e"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("4f235eaa-4b25-4f02-8fc9-8bd2d8857065"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("eb5060b8-960d-4c46-8636-016386121c49"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("a832659f-fbc0-4993-8c1d-6fbdf3b850f0"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("c340e9e5-16f6-4631-a276-eba34768a1e7"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("4fb74a10-a23a-457a-9776-a279c5c3df91"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("cfd1bd30-2f2d-4134-a9bc-ee05696a2e80"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("e81456c6-3e66-47ad-b0e3-f69385a3631b"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("0885d284-0aa1-40be-a3a0-036b17dd55ad"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("27e804d3-e8bc-4cf0-870c-39b8125602b3"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("29f926d7-abbb-4355-b2c3-f5ee30af0522"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("2e9b0527-01bf-40ea-90a9-b748873febb8"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("7ead3fc4-1e3b-46d6-aeb9-0c28acf2aff1"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("878a0fcf-6ce4-4d00-84a3-853aeaee0d32"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8a49e1e5-f594-47f3-b380-8936dd9863c4"));

            migrationBuilder.DropColumn(
                name: "SkillCategory",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "FreelanceSkills",
                newName: "SkillsId");

            migrationBuilder.RenameColumn(
                name: "FreelancerId",
                table: "FreelanceSkills",
                newName: "FreelancersId");

            migrationBuilder.RenameIndex(
                name: "IX_FreelanceSkills_SkillId",
                table: "FreelanceSkills",
                newName: "IX_FreelanceSkills_SkillsId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "TotalReviewCount",
                table: "Freelancers",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Keys", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("20caafd9-a543-4eda-8be8-0485b1611c7a"), 50000000.0, "Hãy yên tâm không nổ đâu", null, null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("62a3297b-ac1d-463c-bec8-8fbe5d52553e"), 40000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("63a2ebd1-3c34-4068-b20e-135d87b16761"), 20000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("706c658f-7621-43f1-b12b-421efba7fb41"), 60000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("89343ddd-beb2-4a0a-bc27-19833309c70f"), 50000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("8f65982a-7eea-4f42-a518-1b52e1fd7d01"), 200000.0, "Sửa máy giặt", null, null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("9c1037af-54ba-45c2-bdad-c889a7e77f06"), 100000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("ac8152dd-a816-401d-88f3-92592c634a55"), 200000.0, "Hãy yên tâm không nổ đâu", null, null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("b0289dc1-5d40-41f9-ba23-4f0a43caead6"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("b8df43cc-8ad2-4bf5-80c4-783f6d7cdf8c"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("d1759901-36be-4643-b1dc-06988d02df07"), 300000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("ea0bff4e-c0c1-4d7d-83ac-95bd7eea27e6"), 4000000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("ea17a32e-ef00-418a-8ece-e78efd5eef14"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("f4dc9e54-ccf3-403f-a8ef-04fcd5ca980f"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("000a661a-4ea1-4e1f-92d3-d57c1f018f1a"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("3d7d7b97-ae07-4bce-bb26-aa0e898d44d0"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("7686ddfd-fb8f-4ab3-a8e9-61137f32f746"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("073709d9-c03b-4a78-8bb8-b345fa2acc07"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("821be71d-0ea7-4d00-866b-d2085795ee2e"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("7227416c-a449-4b99-b57c-69e9a311b903"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("7a9104e3-ce99-41a9-bd7b-ebf347eefbcc"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("83a35967-f24d-4c1c-bb30-d1dfb75cbc08"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("6cbd39e4-23b5-4606-95f0-8876c025beb3"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("6de1977b-9370-49c0-8e05-5c0ea9aec20d"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("74a53bc4-06d2-4f14-b1c4-f2cbf28b3027"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("7536d579-fd81-408f-bd8e-7ad3d96d9fbf"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("7a771c93-6950-4ca5-b0e6-3250223aa64b"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("d6b4537d-b39a-43c3-9f20-05e6eb0013e0"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("dd84c818-d28c-4163-9429-a1850f2d11f1"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null }
                });

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
    }
}
