using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V161_UpdateFreelancerAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CleaningServices_Services_CleaningServiceId",
                table: "CleaningServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiceType_Orders_OrdersId",
                table: "OrderServiceType");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiceType_ServiceTypes_ServiceTypesId",
                table: "OrderServiceType");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairingServices_Services_RepairingServiceId",
                table: "RepairingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingServices_Services_ShoppingServiceId",
                table: "ShoppingServices");

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("1d0cc21a-9f11-4fda-bcbc-e91a2ab59c0d"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a62dc11d-ba95-4a4c-aa4f-79f64550b57f"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("0016015a-18cf-4440-9843-41715e38fbd3"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("011298f1-1a7c-4ade-81bf-eed40dd5241a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("0f63a1c1-6891-4c27-a03f-7d007f15c337"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("158a5619-b9a5-4f7d-909f-8d7977df3157"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1bca3cde-76d2-4c21-b79f-7ef5122a7c00"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1d4750b0-c43f-4b23-bd69-8fa3006fce19"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("2ee48a9c-2f75-43dd-843d-319600aa2925"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3a8671ac-bb6d-45bf-9100-4d57a42a9712"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("529ba881-d3f8-4ad2-a9d1-780afdf94cf0"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("6194477c-e5bd-414e-937d-e930084539a5"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b323ee5f-aa25-4bf6-a8e7-7b367db83196"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c3b8b3c0-fce6-432d-8411-9cfb75165359"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("d0f2f30e-9e87-43c2-8811-f1e4e9c95c7a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("efd893f7-79c9-4456-b01e-d6f4928e157a"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("b79e5600-78c3-478f-b94e-f846e3b472b3"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("d7c2e8e9-22ba-4d0e-bade-718c3fbcc3d9"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("e5630cdf-c2fb-4468-adcd-be75b0493cee"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("d620c95b-c334-4696-9d80-47adbde38693"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("feaf1a3e-d3b5-485f-8a85-f1b507d57c00"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("20bb011e-77dd-4330-8e8a-875947a9446b"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("7a05eeb5-075d-4806-8401-3b5f22e88c43"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("9bdee193-e804-49ee-8061-8d8ba44e4e91"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("21d0fe6e-9655-45e5-a7d9-ff703b141f88"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("390a40e8-bff6-4a36-80d5-09ced1b82b42"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("69edc585-d2dc-49e5-869f-16b53077b901"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8ea607cc-6aa1-4961-a9b1-e3bc8f2f3616"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b028e47a-4556-4391-adbf-932f859b058c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("d05624ab-c41e-452f-b2a5-8ad25b9f3b32"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("fe8fb7ae-e828-47ea-9d9c-c7c18c96527d"));

            migrationBuilder.RenameColumn(
                name: "ShoppingServiceId",
                table: "ShoppingServices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ServiceProven",
                newName: "ImageBefore");

            migrationBuilder.RenameColumn(
                name: "RepairingServiceId",
                table: "RepairingServices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ServiceTypesId",
                table: "OrderServiceType",
                newName: "ServiceTypeId");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "OrderServiceType",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServiceType_ServiceTypesId",
                table: "OrderServiceType",
                newName: "IX_OrderServiceType_ServiceTypeId");

            migrationBuilder.RenameColumn(
                name: "CleaningServiceId",
                table: "CleaningServices",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ImageAfter",
                table: "ServiceProven",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamMemberCount",
                table: "Freelancers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.FreelancerId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Favorites_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favorites_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_CustomerId",
                table: "Favorites",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CleaningServices_Services_Id",
                table: "CleaningServices",
                column: "Id",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_RepairingServices_Services_Id",
                table: "RepairingServices",
                column: "Id",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingServices_Services_Id",
                table: "ShoppingServices",
                column: "Id",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CleaningServices_Services_Id",
                table: "CleaningServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiceType_Orders_OrderId",
                table: "OrderServiceType");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiceType_ServiceTypes_ServiceTypeId",
                table: "OrderServiceType");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairingServices_Services_Id",
                table: "RepairingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingServices_Services_Id",
                table: "ShoppingServices");

            migrationBuilder.DropTable(
                name: "Favorites");

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

            migrationBuilder.DropColumn(
                name: "ImageAfter",
                table: "ServiceProven");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TeamMemberCount",
                table: "Freelancers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingServices",
                newName: "ShoppingServiceId");

            migrationBuilder.RenameColumn(
                name: "ImageBefore",
                table: "ServiceProven",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RepairingServices",
                newName: "RepairingServiceId");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "OrderServiceType",
                newName: "ServiceTypesId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderServiceType",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServiceType_ServiceTypeId",
                table: "OrderServiceType",
                newName: "IX_OrderServiceType_ServiceTypesId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CleaningServices",
                newName: "CleaningServiceId");

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1d0cc21a-9f11-4fda-bcbc-e91a2ab59c0d"), "Đã tiếp nhận" },
                    { new Guid("a62dc11d-ba95-4a4c-aa4f-79f64550b57f"), "Đã hoàn thành" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("0016015a-18cf-4440-9843-41715e38fbd3"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("011298f1-1a7c-4ade-81bf-eed40dd5241a"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("0f63a1c1-6891-4c27-a03f-7d007f15c337"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("158a5619-b9a5-4f7d-909f-8d7977df3157"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("1bca3cde-76d2-4c21-b79f-7ef5122a7c00"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("1d4750b0-c43f-4b23-bd69-8fa3006fce19"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("2ee48a9c-2f75-43dd-843d-319600aa2925"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("3a8671ac-bb6d-45bf-9100-4d57a42a9712"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("529ba881-d3f8-4ad2-a9d1-780afdf94cf0"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("6194477c-e5bd-414e-937d-e930084539a5"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("b323ee5f-aa25-4bf6-a8e7-7b367db83196"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("c3b8b3c0-fce6-432d-8411-9cfb75165359"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("d0f2f30e-9e87-43c2-8811-f1e4e9c95c7a"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("efd893f7-79c9-4456-b01e-d6f4928e157a"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("b79e5600-78c3-478f-b94e-f846e3b472b3"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("d7c2e8e9-22ba-4d0e-bade-718c3fbcc3d9"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("e5630cdf-c2fb-4468-adcd-be75b0493cee"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("d620c95b-c334-4696-9d80-47adbde38693"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("feaf1a3e-d3b5-485f-8a85-f1b507d57c00"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("20bb011e-77dd-4330-8e8a-875947a9446b"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("7a05eeb5-075d-4806-8401-3b5f22e88c43"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("9bdee193-e804-49ee-8061-8d8ba44e4e91"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("21d0fe6e-9655-45e5-a7d9-ff703b141f88"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("390a40e8-bff6-4a36-80d5-09ced1b82b42"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("69edc585-d2dc-49e5-869f-16b53077b901"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("8ea607cc-6aa1-4961-a9b1-e3bc8f2f3616"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("b028e47a-4556-4391-adbf-932f859b058c"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("d05624ab-c41e-452f-b2a5-8ad25b9f3b32"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("fe8fb7ae-e828-47ea-9d9c-c7c18c96527d"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CleaningServices_Services_CleaningServiceId",
                table: "CleaningServices",
                column: "CleaningServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServiceType_Orders_OrdersId",
                table: "OrderServiceType",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServiceType_ServiceTypes_ServiceTypesId",
                table: "OrderServiceType",
                column: "ServiceTypesId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairingServices_Services_RepairingServiceId",
                table: "RepairingServices",
                column: "RepairingServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingServices_Services_ShoppingServiceId",
                table: "ShoppingServices",
                column: "ShoppingServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
