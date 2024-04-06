using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1612_SystemBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("0b91ff3e-eb16-4da5-a4cd-73ca58a24bef"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("ba23fabc-0763-48e8-b534-33a73728466c"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("c34ddc45-a194-494f-a15d-81dd006a8f1a"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("1eb406f8-be82-4132-b5b2-8676292f4dad"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("47f7f38f-a496-40dc-afc8-507b7a5eaf77"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("31b4c043-9834-4794-83d0-28c8d2bb9011"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("91c7447b-389d-496c-b2d9-a9b1ee30fa3e"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("c5a0ebb4-b2e6-475d-8e3f-13a3b5ba6192"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("15ca8730-d328-489a-b0dc-320a1b986495"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("41a68d0a-c9b5-4c6d-a066-6202039cd75e"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("4a38cbb6-d8db-4e83-b34d-5bca67c61475"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("51f03bdf-e0e1-4b7d-8e2d-2202067e158b"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("932f825d-4ebf-4906-9988-7e55473fda6f"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("fee3de12-26fd-4dc8-8a6d-ac40d2ab4033"));

            migrationBuilder.AddColumn<string>(
                name: "SystemBalance",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "Priority", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("1e3d90cc-1443-491a-9265-3b61eea9fc9a"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("55233aaa-5f54-494f-9a94-ff082b59461b"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[] { new Guid("7e2c57f3-dece-4345-bd7c-318a3277e260"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("062688cd-2f09-4092-adb0-f53765436e24"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("306ef686-e501-4412-a5f0-ee35eefe3091"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[] { new Guid("a3b721b0-be8d-4016-8f4f-f6748312e047"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "Priority", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("b4f9e796-97da-4c69-b5f2-2f5ed739215b"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("e827dddf-43c1-427f-a8d5-5fe1cdd2463c"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("229d616b-3465-4992-89b7-bdf6928d2459"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "1" },
                    { new Guid("66fa10ed-f576-4399-9795-244ade87eefa"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("80350911-b5c7-43c4-bf2a-ce7c02d2135e"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("adf01acb-d6ba-4890-bfdd-8603dc6238ba"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("cc0a5340-dd6d-40cf-bd3b-83843dc4a0eb"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("df335267-c44a-491c-8a5f-d852f7a30a07"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("1e3d90cc-1443-491a-9265-3b61eea9fc9a"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("55233aaa-5f54-494f-9a94-ff082b59461b"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("7e2c57f3-dece-4345-bd7c-318a3277e260"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("062688cd-2f09-4092-adb0-f53765436e24"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("306ef686-e501-4412-a5f0-ee35eefe3091"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("a3b721b0-be8d-4016-8f4f-f6748312e047"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("b4f9e796-97da-4c69-b5f2-2f5ed739215b"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("e827dddf-43c1-427f-a8d5-5fe1cdd2463c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("229d616b-3465-4992-89b7-bdf6928d2459"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("66fa10ed-f576-4399-9795-244ade87eefa"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("80350911-b5c7-43c4-bf2a-ce7c02d2135e"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("adf01acb-d6ba-4890-bfdd-8603dc6238ba"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("cc0a5340-dd6d-40cf-bd3b-83843dc4a0eb"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("df335267-c44a-491c-8a5f-d852f7a30a07"));

            migrationBuilder.DropColumn(
                name: "SystemBalance",
                table: "Freelancers");

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("0b91ff3e-eb16-4da5-a4cd-73ca58a24bef"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[] { new Guid("ba23fabc-0763-48e8-b534-33a73728466c"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("c34ddc45-a194-494f-a15d-81dd006a8f1a"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("1eb406f8-be82-4132-b5b2-8676292f4dad"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("47f7f38f-a496-40dc-afc8-507b7a5eaf77"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "Priority", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("31b4c043-9834-4794-83d0-28c8d2bb9011"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("91c7447b-389d-496c-b2d9-a9b1ee30fa3e"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[] { new Guid("c5a0ebb4-b2e6-475d-8e3f-13a3b5ba6192"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("15ca8730-d328-489a-b0dc-320a1b986495"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("41a68d0a-c9b5-4c6d-a066-6202039cd75e"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("4a38cbb6-d8db-4e83-b34d-5bca67c61475"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("51f03bdf-e0e1-4b7d-8e2d-2202067e158b"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "1" },
                    { new Guid("932f825d-4ebf-4906-9988-7e55473fda6f"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("fee3de12-26fd-4dc8-8a6d-ac40d2ab4033"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" }
                });
        }
    }
}
