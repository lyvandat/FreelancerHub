using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V162_UpdateDeleteBehaviorForOrderAndServiceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiceType_Orders_OrderId",
                table: "OrderServiceType");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiceType_ServiceTypes_ServiceTypeId",
                table: "OrderServiceType");

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("0fb77aa9-989f-4530-8b1b-67cd968d9cf0"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("9330172e-c981-4461-b73c-c17224806aa8"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("173588d8-475a-4870-b047-0d6e177395a1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1db70586-3e1d-42fd-a9ed-dfe8f1f30e7b"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("2ac5c5df-fe7b-4952-a9f9-7ccdd6b59dda"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("4b085a83-e9e7-474d-8606-d1fe55a51a53"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("6525202b-a08c-483b-b3b5-26a1af360f52"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("77a2af47-4a36-414b-834b-fb3f743cc54b"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("7819c92f-8d37-4a5a-9a6f-42f985f6a256"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("9c20dc89-a43b-4af2-8190-17235bd3a8f9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a2f3f330-b9e1-4c1c-8e74-9786d704b311"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b70741ac-c45f-42ac-a2f9-390a57e33f64"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("befb92f5-64d2-4ea4-98ff-c99463f1eb8c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cac55f4a-7742-4e62-ad81-23bff118301d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cc903f63-a66e-4471-914a-9f9995a8d788"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ffca48ec-c5dd-46a8-b148-53bbbf7c776b"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("0d0a4d8b-ba66-43a1-a86e-37825bcc8485"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("215461a2-723b-4606-91ee-343f1984b262"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("75d08e25-c262-45c9-a77d-c1b149a15f78"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("c9a222e0-d66e-44d3-b978-e48d5036903a"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("e60728b7-e336-4881-8758-37e28d6a9714"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("64da3c30-abff-4a7e-bf58-f265c76b07ff"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("6fa93df3-17aa-48df-9d00-f3244f933188"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("b2da3029-d63e-4a89-b07e-5b7c4acc6b10"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("0cc30fd4-3466-458d-b27b-0c6d4fe896f3"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("3cfdc78c-5290-4343-bccd-22f7baa64359"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("98483a53-f045-4c16-ba16-ede39ae166df"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("98e3c891-4809-4869-a2d1-f1ee1237bd3e"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("d7019658-0a26-48a1-92de-8028271c5f05"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f99cf854-4300-441d-ac6a-537e47b14afe"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("fe30dab0-ee4c-4e68-b616-a1f1e8a2ab83"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServiceType_Orders_OrderId",
                table: "OrderServiceType",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServiceType_ServiceTypes_ServiceTypeId",
                table: "OrderServiceType",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiceType_Orders_OrderId",
                table: "OrderServiceType");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiceType_ServiceTypes_ServiceTypeId",
                table: "OrderServiceType");

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

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0fb77aa9-989f-4530-8b1b-67cd968d9cf0"), "Đã hoàn thành" },
                    { new Guid("9330172e-c981-4461-b73c-c17224806aa8"), "Đã tiếp nhận" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("173588d8-475a-4870-b047-0d6e177395a1"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("1db70586-3e1d-42fd-a9ed-dfe8f1f30e7b"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("2ac5c5df-fe7b-4952-a9f9-7ccdd6b59dda"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("4b085a83-e9e7-474d-8606-d1fe55a51a53"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("6525202b-a08c-483b-b3b5-26a1af360f52"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("77a2af47-4a36-414b-834b-fb3f743cc54b"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("7819c92f-8d37-4a5a-9a6f-42f985f6a256"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("9c20dc89-a43b-4af2-8190-17235bd3a8f9"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("a2f3f330-b9e1-4c1c-8e74-9786d704b311"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("b70741ac-c45f-42ac-a2f9-390a57e33f64"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("befb92f5-64d2-4ea4-98ff-c99463f1eb8c"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("cac55f4a-7742-4e62-ad81-23bff118301d"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("cc903f63-a66e-4471-914a-9f9995a8d788"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("ffca48ec-c5dd-46a8-b148-53bbbf7c776b"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("0d0a4d8b-ba66-43a1-a86e-37825bcc8485"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("215461a2-723b-4606-91ee-343f1984b262"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("75d08e25-c262-45c9-a77d-c1b149a15f78"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("c9a222e0-d66e-44d3-b978-e48d5036903a"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("e60728b7-e336-4881-8758-37e28d6a9714"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("64da3c30-abff-4a7e-bf58-f265c76b07ff"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("6fa93df3-17aa-48df-9d00-f3244f933188"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("b2da3029-d63e-4a89-b07e-5b7c4acc6b10"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("0cc30fd4-3466-458d-b27b-0c6d4fe896f3"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("3cfdc78c-5290-4343-bccd-22f7baa64359"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("98483a53-f045-4c16-ba16-ede39ae166df"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("98e3c891-4809-4869-a2d1-f1ee1237bd3e"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("d7019658-0a26-48a1-92de-8028271c5f05"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("f99cf854-4300-441d-ac6a-537e47b14afe"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("fe30dab0-ee4c-4e68-b616-a1f1e8a2ab83"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServiceType_Orders_OrderId",
                table: "OrderServiceType",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServiceType_ServiceTypes_ServiceTypeId",
                table: "OrderServiceType",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id");
        }
    }
}
