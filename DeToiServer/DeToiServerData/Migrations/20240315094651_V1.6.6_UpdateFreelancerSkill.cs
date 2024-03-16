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

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Keys", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("0e321e31-9dbc-4dc9-8254-c8d8dad2d288"), 20000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("10d310ab-36f7-49b5-8ea5-48e1c57a284e"), 60000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("2807d266-aa39-44c8-b22e-7c76fdc3e06e"), 50000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("3d3ad5b3-177b-4b6d-9538-c19bd4860df1"), 4000000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("44524e67-32d7-4da3-8426-0c17973ebeb3"), 200000.0, "Sửa máy giặt", null, null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("5dd79744-00ad-4a36-8768-f8afb1e6e128"), 300000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("5fc7364b-ae63-4b18-be0a-cf2eb3fa44c7"), 100000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("68f7a6f2-e189-4356-a9c7-2ab5b962182e"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("6bdfb33e-fc0f-4d42-a5ce-264391fed961"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("8d4d51a7-b18a-461f-b2c6-fe911045e503"), 200000.0, "Hãy yên tâm không nổ đâu", null, null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("a6902bee-437e-4d5e-b405-ab84dee8e030"), 50000000.0, "Hãy yên tâm không nổ đâu", null, null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("b5204b6a-4cf1-4dbc-b011-ada931ea5e5b"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("d9aaa36a-4f1a-4984-a26f-d28c8811f14f"), 200000.0, "Sửa chữa để tôi lo", null, null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("ec4282ce-7a09-4aee-83fc-98e01f3be861"), 40000.0, "Mua sắm hộ siêu nhanh", null, null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("6b9466dc-e1d0-43fb-8cac-c05f1b2bfc99"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("e53baa6c-23af-46f7-b132-c1a875571eaf"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("ec44264f-7366-4245-8199-a39f77424247"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("5e2ce522-17a1-41a4-ac38-a67bd44433e2"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("bce2d13b-3e00-4dac-a0c8-2df9426cb112"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("0220fbcd-8d74-4b11-8012-27bcaeec90b8"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("7522e1ee-6bfc-4515-847e-a97f7806b018"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("d6f2124b-745d-4ad9-8e3f-0a41c3cfcd3b"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("1aa2013c-d516-475b-85ea-8aa0ed87ce6a"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("21221049-ba6c-47bf-8ec4-033656a46a07"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("21f01545-d4bb-4e5d-951a-efa8aff4b837"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("439a8b84-1fd5-4efc-bb9a-141f53da6fd6"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("8432f37e-999a-4b2d-8625-043e169912cf"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("9f1da711-aa9d-4583-99d7-1c62ea75f851"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("a353e561-8b38-40ea-887a-76f6bda61f3a"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" }
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
                keyValue: new Guid("0e321e31-9dbc-4dc9-8254-c8d8dad2d288"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("10d310ab-36f7-49b5-8ea5-48e1c57a284e"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("2807d266-aa39-44c8-b22e-7c76fdc3e06e"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3d3ad5b3-177b-4b6d-9538-c19bd4860df1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("44524e67-32d7-4da3-8426-0c17973ebeb3"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("5dd79744-00ad-4a36-8768-f8afb1e6e128"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("5fc7364b-ae63-4b18-be0a-cf2eb3fa44c7"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("68f7a6f2-e189-4356-a9c7-2ab5b962182e"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("6bdfb33e-fc0f-4d42-a5ce-264391fed961"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("8d4d51a7-b18a-461f-b2c6-fe911045e503"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a6902bee-437e-4d5e-b405-ab84dee8e030"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b5204b6a-4cf1-4dbc-b011-ada931ea5e5b"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("d9aaa36a-4f1a-4984-a26f-d28c8811f14f"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ec4282ce-7a09-4aee-83fc-98e01f3be861"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("6b9466dc-e1d0-43fb-8cac-c05f1b2bfc99"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("e53baa6c-23af-46f7-b132-c1a875571eaf"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("ec44264f-7366-4245-8199-a39f77424247"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("5e2ce522-17a1-41a4-ac38-a67bd44433e2"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("bce2d13b-3e00-4dac-a0c8-2df9426cb112"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("0220fbcd-8d74-4b11-8012-27bcaeec90b8"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("7522e1ee-6bfc-4515-847e-a97f7806b018"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("d6f2124b-745d-4ad9-8e3f-0a41c3cfcd3b"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("1aa2013c-d516-475b-85ea-8aa0ed87ce6a"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("21221049-ba6c-47bf-8ec4-033656a46a07"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("21f01545-d4bb-4e5d-951a-efa8aff4b837"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("439a8b84-1fd5-4efc-bb9a-141f53da6fd6"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8432f37e-999a-4b2d-8625-043e169912cf"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("9f1da711-aa9d-4583-99d7-1c62ea75f851"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("a353e561-8b38-40ea-887a-76f6bda61f3a"));

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
