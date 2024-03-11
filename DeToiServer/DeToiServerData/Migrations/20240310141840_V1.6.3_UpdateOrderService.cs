using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V163_UpdateOrderService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("2274772b-0c34-4760-8ace-ae4044c57b6a"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("e1dd2e24-92e7-4d3e-900e-96d9bd123952"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("0fcd6144-727c-48e8-88ee-3cee76e5bffc"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("11622e75-904f-48d3-96d7-9d79f3cdfb35"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("16438f98-2bb0-45f9-a55f-1756802440c7"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1af7ad25-f0d8-40ab-85bb-b81fd34d7178"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("23d025ca-3e57-4e10-a35d-6dd89b8e30a8"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("24dd4960-f1d5-4d3d-b54d-1350236f9abe"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("35ffdc5f-6693-4947-8228-3de859c13fbd"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("6e135fa2-e812-4b9a-8e0f-a4c7be6fe710"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("893cf9cd-8e51-49c4-bf3a-36feb7967080"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e09b1f3-4b3c-4c5b-a793-f34b9b014c7f"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e45290b-e276-4306-942b-fba7353e13f5"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b39dcf27-8be4-43fd-a139-9fc18f12ab63"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("bb45a26e-8f06-4d10-b8bc-460cae162c76"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ca3301a2-d220-44f4-a02d-fc4e591c02df"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("41899b80-8d8c-42ba-ba04-290a533dcb52"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("9dbfb4d0-c317-4be9-b7b3-f2351caaaec3"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("e60b683d-7bcb-4276-8eaf-4f925dfb14d4"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("61a2cd2d-406f-4ff9-86be-593ed58e7d28"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("fc018129-957c-4865-a265-6435ca52e05d"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("8d0f55c2-0ce2-441c-a2ff-60aba82b8ffc"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("a3206feb-3c4c-4914-9aa5-ce7760d1cec5"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("b2166c0b-62a3-4c31-9a4a-2471a6f8684b"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("29dd13f2-9f66-4fb4-a245-0953e2b5a5f6"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("2a09ff77-0a73-4df8-8a7c-ab997eb22e9c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("38e705f5-06de-4745-94cc-5b1e32436068"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("7391d03b-005f-4bc0-9d18-c76849acb423"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("9475d0fe-ad70-441c-a900-3ab8c8461f72"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("cd380bde-80c8-4f22-8069-b05d188b51ca"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("d6fbff5b-8a91-4ec6-b4e3-a9da27652883"));

            migrationBuilder.AddColumn<string>(
                name: "ServiceClassName",
                table: "ServiceCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("591f9ac0-2356-4251-a4c7-b3a216b1b6c9"), "Đã hoàn thành" },
                    { new Guid("971860cb-bb9a-4010-b569-b60db2451b4a"), "Đã tiếp nhận" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("0e4b5d47-6ef9-4ffb-b7f1-50a45d92b627"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("178716e7-92ee-4aea-bda0-9a68805cf68b"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("34f8cbce-8df2-4a42-9013-2d050bdf312c"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("3804cff6-754e-498b-a19f-78cba12e67de"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("5939b6b2-d77a-45aa-bc9c-3e54a3a6e159"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("6e6ec54f-48d6-4ecb-a912-3b66fba03251"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("76b52d25-5943-48fc-a2b7-c28eb6f1d0be"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("76c6f209-e949-4c31-abf9-208e253384c4"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("a0ff00d2-0662-42d7-afb2-982039502e66"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("b54647aa-0a6e-4928-b83f-d59b6eea091a"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("cc339409-bd29-4927-9338-8be7b9efdd54"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("d6e7d078-cc56-4ac8-a601-809c8ed13556"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("ed8cce96-af0b-4c92-8569-2bfad88601d9"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("f51f92b3-df4a-4165-bbca-7d862467628c"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("1814adc5-8093-4bee-b772-fd07224843d3"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("38871c9f-9ffa-40b2-9e50-08e0a83f0fda"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("d0152a67-f322-4c4f-93d0-4591449944d5"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("b04e805a-192a-4006-bc52-6e69b14c6309"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("d9e63f90-875c-4291-9295-f413192e6909"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("17386a3a-c6a5-4ba3-98e2-82b9434fb34e"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("59eb8826-6635-42bf-9df3-c54b435a1cab"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("8a50b1c1-4382-403f-b777-35da27778d08"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("1a9f9ddf-76ea-4a46-88cf-32a8f0d91305"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("2ff24fdb-27ea-4de3-9a49-1cae61c7335e"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("5ab0385e-8250-4c67-886f-eacbe03cf06c"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("7c2d20e7-e283-4517-87cc-d96e4b71c803"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("bed7963c-f207-4b46-90b6-0c3f8c62d7ee"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("f8313dcf-d57f-49ba-bad3-4c62494b3832"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("fe4239f3-c270-4e4e-aef0-cbd63b6fd514"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("591f9ac0-2356-4251-a4c7-b3a216b1b6c9"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("971860cb-bb9a-4010-b569-b60db2451b4a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("0e4b5d47-6ef9-4ffb-b7f1-50a45d92b627"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("178716e7-92ee-4aea-bda0-9a68805cf68b"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("34f8cbce-8df2-4a42-9013-2d050bdf312c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3804cff6-754e-498b-a19f-78cba12e67de"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("5939b6b2-d77a-45aa-bc9c-3e54a3a6e159"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("6e6ec54f-48d6-4ecb-a912-3b66fba03251"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("76b52d25-5943-48fc-a2b7-c28eb6f1d0be"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("76c6f209-e949-4c31-abf9-208e253384c4"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a0ff00d2-0662-42d7-afb2-982039502e66"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b54647aa-0a6e-4928-b83f-d59b6eea091a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cc339409-bd29-4927-9338-8be7b9efdd54"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("d6e7d078-cc56-4ac8-a601-809c8ed13556"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ed8cce96-af0b-4c92-8569-2bfad88601d9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f51f92b3-df4a-4165-bbca-7d862467628c"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("1814adc5-8093-4bee-b772-fd07224843d3"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("38871c9f-9ffa-40b2-9e50-08e0a83f0fda"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("d0152a67-f322-4c4f-93d0-4591449944d5"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("b04e805a-192a-4006-bc52-6e69b14c6309"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("d9e63f90-875c-4291-9295-f413192e6909"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("17386a3a-c6a5-4ba3-98e2-82b9434fb34e"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("59eb8826-6635-42bf-9df3-c54b435a1cab"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("8a50b1c1-4382-403f-b777-35da27778d08"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("1a9f9ddf-76ea-4a46-88cf-32a8f0d91305"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("2ff24fdb-27ea-4de3-9a49-1cae61c7335e"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("5ab0385e-8250-4c67-886f-eacbe03cf06c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("7c2d20e7-e283-4517-87cc-d96e4b71c803"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("bed7963c-f207-4b46-90b6-0c3f8c62d7ee"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f8313dcf-d57f-49ba-bad3-4c62494b3832"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("fe4239f3-c270-4e4e-aef0-cbd63b6fd514"));

            migrationBuilder.DropColumn(
                name: "ServiceClassName",
                table: "ServiceCategories");

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2274772b-0c34-4760-8ace-ae4044c57b6a"), "Đã tiếp nhận" },
                    { new Guid("e1dd2e24-92e7-4d3e-900e-96d9bd123952"), "Đã hoàn thành" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("0fcd6144-727c-48e8-88ee-3cee76e5bffc"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("11622e75-904f-48d3-96d7-9d79f3cdfb35"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("16438f98-2bb0-45f9-a55f-1756802440c7"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("1af7ad25-f0d8-40ab-85bb-b81fd34d7178"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("23d025ca-3e57-4e10-a35d-6dd89b8e30a8"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("24dd4960-f1d5-4d3d-b54d-1350236f9abe"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("35ffdc5f-6693-4947-8228-3de859c13fbd"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("6e135fa2-e812-4b9a-8e0f-a4c7be6fe710"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("893cf9cd-8e51-49c4-bf3a-36feb7967080"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("9e09b1f3-4b3c-4c5b-a793-f34b9b014c7f"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("9e45290b-e276-4306-942b-fba7353e13f5"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("b39dcf27-8be4-43fd-a139-9fc18f12ab63"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("bb45a26e-8f06-4d10-b8bc-460cae162c76"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("ca3301a2-d220-44f4-a02d-fc4e591c02df"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("41899b80-8d8c-42ba-ba04-290a533dcb52"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("9dbfb4d0-c317-4be9-b7b3-f2351caaaec3"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("e60b683d-7bcb-4276-8eaf-4f925dfb14d4"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("61a2cd2d-406f-4ff9-86be-593ed58e7d28"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("fc018129-957c-4865-a265-6435ca52e05d"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("8d0f55c2-0ce2-441c-a2ff-60aba82b8ffc"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("a3206feb-3c4c-4914-9aa5-ce7760d1cec5"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("b2166c0b-62a3-4c31-9a4a-2471a6f8684b"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("29dd13f2-9f66-4fb4-a245-0953e2b5a5f6"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("2a09ff77-0a73-4df8-8a7c-ab997eb22e9c"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("38e705f5-06de-4745-94cc-5b1e32436068"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("7391d03b-005f-4bc0-9d18-c76849acb423"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("9475d0fe-ad70-441c-a900-3ab8c8461f72"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("cd380bde-80c8-4f22-8069-b05d188b51ca"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("d6fbff5b-8a91-4ec6-b4e3-a9da27652883"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" }
                });
        }
    }
}
