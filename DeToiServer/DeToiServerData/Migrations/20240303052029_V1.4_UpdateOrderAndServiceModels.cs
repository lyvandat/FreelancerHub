using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V14_UpdateOrderAndServiceModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ServiceCategories_ServiceCategoryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceCategories_ServiceCategoryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ServiceCategoryId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("12d7401b-04fa-49e9-80d6-1376003e4e4c"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("bf619456-6cf2-4c2d-886f-0b2145f577e1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1280aeec-6105-4cc6-bd24-132509a4574b"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("19b87c34-25a7-4706-8a09-742b6ac458a4"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("19e9fe76-fdf3-4d07-b167-33b42587ec6d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1e2cc78b-9d8e-4ae2-9f81-52b523e9a627"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3c4da28b-d868-4036-9ce2-14b3a84e43d3"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("50a9dee0-7761-4d26-bf93-036ad29b98eb"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("55bfef55-c850-4970-aabf-9dade399d2c7"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("73f75487-fd52-42a6-92cd-f1d8a3726724"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("8e043355-95f2-4d0b-83b2-54a809651c5c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("9f954c11-6404-4f70-aca5-0804166f9ce6"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b821082e-8391-4fa7-9db7-85695f1bf07c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("e29b6c90-148b-4ace-b6c5-e118abd767f6"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("e72b9b62-87c5-4eb4-8f23-6b23e43070d3"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f39c4d7d-4527-4269-8bc3-cc99c531146d"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("3020324a-caf9-4692-95b5-4a1acb62ddcf"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("bb838727-c872-483b-8cb5-22828f87dfb6"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("c4ea2d37-e1c1-42f2-9763-a93df5edc1b8"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("4ee5bbfc-d498-48a2-bdec-0476e19db35d"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("af95212e-0b3f-450d-90d0-3f38dfcfeb47"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("248de0c4-43f2-4ab4-bd5e-8ca0f809fe94"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("5817a739-250c-4e17-928e-acd93a117c0c"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("96df0b1a-66b0-4d1a-be33-3d0566a19235"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("04123548-d885-4bba-946e-e34e75efb3a2"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("4a2c1171-93eb-4192-aa93-417a81f6fde7"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("5fe8cb5b-5a22-4ba5-9b61-b83416bc5c60"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("6021e98e-7803-42a1-ae20-631fc058b9fc"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("73425903-c3a4-4990-a558-b692f6ef80f4"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8e1ce306-b145-4b3d-9757-7129ce455c16"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("a514e638-91ee-4403-b197-29332e2a9453"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceCategoryId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ServiceCategoryId",
                table: "Services",
                newName: "ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ServiceCategoryId",
                table: "Services",
                newName: "IX_Services_ServiceTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingItems",
                table: "ShoppingServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ShoppingServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RepairingServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "RepairingServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "RoomNumber",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                table: "CleaningServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OrderServiceType",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderServiceType", x => new { x.OrdersId, x.ServiceTypesId });
                    table.ForeignKey(
                        name: "FK_OrderServiceType_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderServiceType_ServiceTypes_ServiceTypesId",
                        column: x => x.ServiceTypesId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProven",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProven", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProven_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProven_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProven_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("735aa6eb-94d9-4c5c-8417-96abf49f2d72"), "Đã tiếp nhận" },
                    { new Guid("b1fb753b-9681-48a4-9f79-a636c50feddb"), "Đã hoàn thành" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("1039bad2-b65a-4255-91f0-af948b4463d9"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("1580d865-d735-45d8-95d8-3371321a63d1"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("23201f99-ed46-4bcf-bdf2-be018e8a3f0b"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("333bccdc-2e2d-4e7e-9cf6-05d1400e7d29"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("5c9ab053-ef87-42b9-a894-b6dd81bfdcca"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("661d7b51-a226-4d7d-a1d7-2113f7a14024"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("70c24c26-3078-45d1-b88d-0044222b363a"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("9c27f439-55df-473a-bbdc-6bac05932603"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("ac21271d-0d34-407c-b39c-1c4da5e62b1f"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("b3b32419-ede8-4913-af8a-95d709701e1f"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("b8c1564c-4da1-4d4c-98d4-3eba2ece4b8a"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("bb62341f-1355-4549-8d5e-fde3736137cb"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("bd49a09c-d922-46e9-81ea-758d96dd6f42"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("fc2ec6d8-6e49-4c7a-b2c4-60ce4456d269"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("690acece-52cc-4061-bedc-e0c745495e7a"), false, "faBroom", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("8e448c9d-d662-473e-97f3-83a1d0f18dd3"), false, "faComputer", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("a3bbd60a-d3e5-4b08-9cdf-fb0bc9cb3cb9"), true, "faDog", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("04058c40-7ca7-4e4f-8e69-8d2ae7770d73"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("e14602ec-0a17-4a96-bcf3-1987f8a81411"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("0a90e514-3bba-4e11-90ad-7d82ef8d0a95"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("50e143c0-4224-427c-91d9-77a7e3588a9c"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("6e304e67-076f-4fb6-b9ec-2ab3dc44c78d"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("33a3b88b-70c5-4b0b-a86f-fb1c8d10c16a"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("35d58cbc-6766-4914-91f5-758c2253accd"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("48427a49-c66a-4ab6-8c42-d42d14371cdf"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("ae5c9ba3-81f3-4cac-b431-ab8818f40e96"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("bc1b2b05-4b7f-44c2-81b7-661fb82f44de"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("fabf7815-de87-4a5f-b738-febe491f850f"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("fea169f1-ae08-4f4d-bcee-d01bc75c2dac"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderServiceType_ServiceTypesId",
                table: "OrderServiceType",
                column: "ServiceTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProven_FreelancerId",
                table: "ServiceProven",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProven_OrderId",
                table: "ServiceProven",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProven_ServiceTypeId",
                table: "ServiceProven",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "OrderServiceType");

            migrationBuilder.DropTable(
                name: "ServiceProven");

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("735aa6eb-94d9-4c5c-8417-96abf49f2d72"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("b1fb753b-9681-48a4-9f79-a636c50feddb"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1039bad2-b65a-4255-91f0-af948b4463d9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1580d865-d735-45d8-95d8-3371321a63d1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("23201f99-ed46-4bcf-bdf2-be018e8a3f0b"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("333bccdc-2e2d-4e7e-9cf6-05d1400e7d29"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("5c9ab053-ef87-42b9-a894-b6dd81bfdcca"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("661d7b51-a226-4d7d-a1d7-2113f7a14024"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("70c24c26-3078-45d1-b88d-0044222b363a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("9c27f439-55df-473a-bbdc-6bac05932603"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ac21271d-0d34-407c-b39c-1c4da5e62b1f"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b3b32419-ede8-4913-af8a-95d709701e1f"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8c1564c-4da1-4d4c-98d4-3eba2ece4b8a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("bb62341f-1355-4549-8d5e-fde3736137cb"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("bd49a09c-d922-46e9-81ea-758d96dd6f42"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("fc2ec6d8-6e49-4c7a-b2c4-60ce4456d269"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("690acece-52cc-4061-bedc-e0c745495e7a"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("8e448c9d-d662-473e-97f3-83a1d0f18dd3"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("a3bbd60a-d3e5-4b08-9cdf-fb0bc9cb3cb9"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("04058c40-7ca7-4e4f-8e69-8d2ae7770d73"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("e14602ec-0a17-4a96-bcf3-1987f8a81411"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("0a90e514-3bba-4e11-90ad-7d82ef8d0a95"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("50e143c0-4224-427c-91d9-77a7e3588a9c"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("6e304e67-076f-4fb6-b9ec-2ab3dc44c78d"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("33a3b88b-70c5-4b0b-a86f-fb1c8d10c16a"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("35d58cbc-6766-4914-91f5-758c2253accd"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("48427a49-c66a-4ab6-8c42-d42d14371cdf"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("ae5c9ba3-81f3-4cac-b431-ab8818f40e96"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("bc1b2b05-4b7f-44c2-81b7-661fb82f44de"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("fabf7815-de87-4a5f-b738-febe491f850f"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("fea169f1-ae08-4f4d-bcee-d01bc75c2dac"));

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "Services",
                newName: "ServiceCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                newName: "IX_Services_ServiceCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingItems",
                table: "ShoppingServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ShoppingServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Services",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RepairingServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "RepairingServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceCategoryId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "CleaningServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "RoomNumber",
                table: "CleaningServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "CleaningServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "CleaningServices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                table: "CleaningServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12d7401b-04fa-49e9-80d6-1376003e4e4c"), "Đã hoàn thành" },
                    { new Guid("bf619456-6cf2-4c2d-886f-0b2145f577e1"), "Đã tiếp nhận" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("1280aeec-6105-4cc6-bd24-132509a4574b"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("19b87c34-25a7-4706-8a09-742b6ac458a4"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("19e9fe76-fdf3-4d07-b167-33b42587ec6d"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("1e2cc78b-9d8e-4ae2-9f81-52b523e9a627"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("3c4da28b-d868-4036-9ce2-14b3a84e43d3"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("50a9dee0-7761-4d26-bf93-036ad29b98eb"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("55bfef55-c850-4970-aabf-9dade399d2c7"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("73f75487-fd52-42a6-92cd-f1d8a3726724"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("8e043355-95f2-4d0b-83b2-54a809651c5c"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("9f954c11-6404-4f70-aca5-0804166f9ce6"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("b821082e-8391-4fa7-9db7-85695f1bf07c"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("e29b6c90-148b-4ace-b6c5-e118abd767f6"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("e72b9b62-87c5-4eb4-8f23-6b23e43070d3"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("f39c4d7d-4527-4269-8bc3-cc99c531146d"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("3020324a-caf9-4692-95b5-4a1acb62ddcf"), false, "faBroom", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("bb838727-c872-483b-8cb5-22828f87dfb6"), true, "faDog", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("c4ea2d37-e1c1-42f2-9763-a93df5edc1b8"), false, "faComputer", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("4ee5bbfc-d498-48a2-bdec-0476e19db35d"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("af95212e-0b3f-450d-90d0-3f38dfcfeb47"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("248de0c4-43f2-4ab4-bd5e-8ca0f809fe94"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("5817a739-250c-4e17-928e-acd93a117c0c"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("96df0b1a-66b0-4d1a-be33-3d0566a19235"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("04123548-d885-4bba-946e-e34e75efb3a2"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("4a2c1171-93eb-4192-aa93-417a81f6fde7"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("5fe8cb5b-5a22-4ba5-9b61-b83416bc5c60"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("6021e98e-7803-42a1-ae20-631fc058b9fc"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("73425903-c3a4-4990-a558-b692f6ef80f4"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("8e1ce306-b145-4b3d-9757-7129ce455c16"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("a514e638-91ee-4403-b197-29332e2a9453"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceCategoryId",
                table: "Orders",
                column: "ServiceCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ServiceCategories_ServiceCategoryId",
                table: "Orders",
                column: "ServiceCategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceCategories_ServiceCategoryId",
                table: "Services",
                column: "ServiceCategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
