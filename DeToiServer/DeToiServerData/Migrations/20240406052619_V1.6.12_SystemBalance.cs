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

            migrationBuilder.AlterColumn<string>(
                name: "Balance",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "SystemBalance",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("0f6f1894-3ee7-46a8-9939-842e3c620231"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/vesinhmaylanh/category.png");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/chuyennhaphongtro/category.png");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dicho/category.png");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/suachua/category.png");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/category.png");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("07cb166a-4b4e-4637-b224-6277a69003d9"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3361bc88-9f58-4be8-ac37-561606430f8a"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3779d349-abcb-4dbc-abf1-25ba9e94a695"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/phongtro.png");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("49a42267-d9dc-4e11-87a5-36525d4254d9"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/bietthu.png");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("63ce2ebf-ef36-4b4a-891e-abbde2a75b38"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("662a64be-f7ea-4419-8978-dbf8f19159dc"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("73bf981f-1cfd-483d-80ee-14ab6d2e55ef"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("88006a8c-d757-4b85-8b91-c88e6078fe9c"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("96d250d4-0c0e-4521-b94e-05f3cafca3f3"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a5677de0-a6a7-42c0-ab77-f34b75beb63d"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b9f74f9e-f792-4c48-b1b6-b6f0bc402d07"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c82954a1-39d4-4012-86b3-6cad42c2b399"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cca752d4-c17c-4c31-906f-f33cb8a18e48"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("dbb78597-043d-47c1-8810-93d392fd09ba"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ef2034c1-7f44-4d07-b9c0-e2a497999a9d"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ef2632f0-47bd-4bbe-a46f-628a28f03d8b"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/n%C3%A2-nhapho.png");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f1b832b2-49f3-456f-bacb-b1f8da766bea"),
                column: "Image",
                value: "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg");

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[] { new Guid("05639c16-5494-46d0-bfcc-0d50fa2fc27e"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "Priority", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("27909e32-9a63-4365-bba5-ab2022ed4ba5"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("c137e02e-cf5c-40e6-8c6f-8599fed70065"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("29dda00e-4e22-40cf-aa60-086bc5cc60ac"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("c93ab8f9-37f6-4eac-9024-165702e45344"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("40f5d11e-ac80-4d35-b38e-6cf254016465"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[] { new Guid("cec4a739-1fe4-4939-bbbd-3643653d7820"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("ee33d636-ed97-475c-a88e-26f238f11963"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("588cfde4-0c3e-400f-a7f5-84a902c6734b"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("a3bbc2b1-9239-4d28-8c62-2c48c52da51c"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("b1e4374a-48f6-49d0-8717-ba997531dfb5"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("dd97438d-6dfe-4f51-885e-23f468d1576b"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "1" },
                    { new Guid("f20ca85a-f71c-443d-b7c5-55b3d80f8d64"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("fe82f89d-5ed0-4d29-a825-5958f1f4cdc3"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("05639c16-5494-46d0-bfcc-0d50fa2fc27e"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("27909e32-9a63-4365-bba5-ab2022ed4ba5"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("c137e02e-cf5c-40e6-8c6f-8599fed70065"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("29dda00e-4e22-40cf-aa60-086bc5cc60ac"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("c93ab8f9-37f6-4eac-9024-165702e45344"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("40f5d11e-ac80-4d35-b38e-6cf254016465"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("cec4a739-1fe4-4939-bbbd-3643653d7820"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("ee33d636-ed97-475c-a88e-26f238f11963"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("588cfde4-0c3e-400f-a7f5-84a902c6734b"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("a3bbc2b1-9239-4d28-8c62-2c48c52da51c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b1e4374a-48f6-49d0-8717-ba997531dfb5"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("dd97438d-6dfe-4f51-885e-23f468d1576b"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f20ca85a-f71c-443d-b7c5-55b3d80f8d64"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("fe82f89d-5ed0-4d29-a825-5958f1f4cdc3"));

            migrationBuilder.DropColumn(
                name: "SystemBalance",
                table: "Freelancers");

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Freelancers",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("0f6f1894-3ee7-46a8-9939-842e3c620231"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/vesinhmaylanh/category.png");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/chuyennhaphongtro/category.png");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dicho/category.png");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/suachua/category.png");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/category.png");

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
                keyValue: new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/phongtro.png");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("49a42267-d9dc-4e11-87a5-36525d4254d9"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/bietthu.png");

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
                keyValue: new Guid("dbb78597-043d-47c1-8810-93d392fd09ba"),
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
                keyValue: new Guid("ef2632f0-47bd-4bbe-a46f-628a28f03d8b"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/n%C3%A2-nhapho.png");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f1b832b2-49f3-456f-bacb-b1f8da766bea"),
                column: "Image",
                value: "https://detoivn.sirv.com/services/dondep/chungcu.jpg");

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
