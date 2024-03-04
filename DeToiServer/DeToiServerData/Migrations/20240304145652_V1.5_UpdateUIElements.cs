using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V15_UpdateUIElements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairingServices_DeviceInfo_DeviceInfoId",
                table: "RepairingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingServices_ShoppingInfo_ShoppingInfoId",
                table: "ShoppingServices");

            migrationBuilder.DropTable(
                name: "DeviceInfo");

            migrationBuilder.DropTable(
                name: "ShoppingInfo");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingServices_ShoppingInfoId",
                table: "ShoppingServices");

            migrationBuilder.DropIndex(
                name: "IX_RepairingServices_DeviceInfoId",
                table: "RepairingServices");

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

            migrationBuilder.DropColumn(
                name: "ShoppingInfoId",
                table: "ShoppingServices");

            migrationBuilder.DropColumn(
                name: "DeviceInfoId",
                table: "RepairingServices");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "CleaningServices");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "CleaningServices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CleaningServices");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "CleaningServices");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "UIElementServiceRequirements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "UIElementAdditionServiceRequirements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ShoppingServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShoppingServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RepairingServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "RepairingServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "RoomNumber",
                table: "CleaningServices",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "CleaningServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CleanningType",
                table: "CleaningServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "FreelancerBringTools",
                table: "CleaningServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasElectronics",
                table: "CleaningServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPets",
                table: "CleaningServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Addresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "Addresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"),
                column: "Name",
                value: "Chuyển nhà, phòng trọ");

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d37715a9-87f2-450b-be60-e69455f0e579"), "Đã tiếp nhận" },
                    { new Guid("f63f8341-6512-469f-a501-27386fd0fe36"), "Đã hoàn thành" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("52cf5b39-503b-4c57-91b6-d202378bcf6d"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("58cef338-3e8b-4f50-9f68-eec69a3e4661"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("6d9f7c83-deeb-4ec9-8282-084210e52315"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("7f47b8b8-86b6-4159-846c-b38452f36ac8"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("81f3484c-2b80-43f4-a2b2-75b0e7bfad1b"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("9115029e-ecbf-4577-8d0a-bef80fb71b48"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("94952ed0-a0bf-4c8f-8b4f-f20ede7b0992"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("a5a86c35-dd54-430b-a802-f59b4f05119c"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("aaae5cde-aa6d-4c9d-8a14-8439d98e3e68"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("b1005590-7593-453e-9ab3-edff3795b463"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("d0ec1619-ab64-4ea4-acb1-32f245422cf1"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("d95ba325-5b76-45af-9594-9253429d6e29"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("dacb40d5-916f-4478-831d-0d6149091b4d"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("f8c33571-dc5b-4d12-835b-b604af8a04a7"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("5c3c8c8e-d6ee-4f93-bd2b-fb1206ac77a9"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("6156392e-2a9f-4a5c-8c44-45c9a1df760b"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("d94fad58-623b-4264-bc68-11aa451fe6a7"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("8e8a0640-b4ad-4617-b838-1d08752b5b93"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("90cf8f53-e354-42b8-ab2c-7cb9e0909573"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("3204c6bc-9593-4f53-90c4-d430c671fd30"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("a759ed35-eec8-49e7-b36c-e8391ed8326a"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("e832f08d-21d9-41bd-b5c8-3d476611ad7f"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("2a73ea76-ace6-412e-a678-e00f260a0b2f"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("55096e10-35bd-4bcd-92d3-3687d1ea8084"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("b3a8cb92-5cd5-47bd-8271-5a0985522101"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("c38d3fac-2554-45f1-bd80-9818cf21290c"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("c8ec7e66-b730-4284-82f7-0a15fe71988c"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("f2dff9d2-31e2-4c38-baf1-a09f57ab05fc"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("f7b42e58-ced8-4f1a-a656-f1e1f29696d6"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("d37715a9-87f2-450b-be60-e69455f0e579"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("f63f8341-6512-469f-a501-27386fd0fe36"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("52cf5b39-503b-4c57-91b6-d202378bcf6d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("58cef338-3e8b-4f50-9f68-eec69a3e4661"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("6d9f7c83-deeb-4ec9-8282-084210e52315"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("7f47b8b8-86b6-4159-846c-b38452f36ac8"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("81f3484c-2b80-43f4-a2b2-75b0e7bfad1b"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("9115029e-ecbf-4577-8d0a-bef80fb71b48"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("94952ed0-a0bf-4c8f-8b4f-f20ede7b0992"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a5a86c35-dd54-430b-a802-f59b4f05119c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("aaae5cde-aa6d-4c9d-8a14-8439d98e3e68"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b1005590-7593-453e-9ab3-edff3795b463"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("d0ec1619-ab64-4ea4-acb1-32f245422cf1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("d95ba325-5b76-45af-9594-9253429d6e29"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("dacb40d5-916f-4478-831d-0d6149091b4d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f8c33571-dc5b-4d12-835b-b604af8a04a7"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("5c3c8c8e-d6ee-4f93-bd2b-fb1206ac77a9"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("6156392e-2a9f-4a5c-8c44-45c9a1df760b"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("d94fad58-623b-4264-bc68-11aa451fe6a7"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("8e8a0640-b4ad-4617-b838-1d08752b5b93"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("90cf8f53-e354-42b8-ab2c-7cb9e0909573"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("3204c6bc-9593-4f53-90c4-d430c671fd30"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("a759ed35-eec8-49e7-b36c-e8391ed8326a"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("e832f08d-21d9-41bd-b5c8-3d476611ad7f"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("2a73ea76-ace6-412e-a678-e00f260a0b2f"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("55096e10-35bd-4bcd-92d3-3687d1ea8084"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b3a8cb92-5cd5-47bd-8271-5a0985522101"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("c38d3fac-2554-45f1-bd80-9818cf21290c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("c8ec7e66-b730-4284-82f7-0a15fe71988c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f2dff9d2-31e2-4c38-baf1-a09f57ab05fc"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f7b42e58-ced8-4f1a-a656-f1e1f29696d6"));

            migrationBuilder.DropColumn(
                name: "Key",
                table: "UIElementServiceRequirements");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "UIElementAdditionServiceRequirements");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ShoppingServices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShoppingServices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RepairingServices");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "RepairingServices");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "CleaningServices");

            migrationBuilder.DropColumn(
                name: "CleanningType",
                table: "CleaningServices");

            migrationBuilder.DropColumn(
                name: "FreelancerBringTools",
                table: "CleaningServices");

            migrationBuilder.DropColumn(
                name: "HasElectronics",
                table: "CleaningServices");

            migrationBuilder.DropColumn(
                name: "HasPets",
                table: "CleaningServices");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingInfoId",
                table: "ShoppingServices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceInfoId",
                table: "RepairingServices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "RoomNumber",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "CleaningServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "CleaningServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "DeviceInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingInfo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"),
                column: "Name",
                value: "Chuyển nhà phòng trọ");

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
                name: "IX_ShoppingServices_ShoppingInfoId",
                table: "ShoppingServices",
                column: "ShoppingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairingServices_DeviceInfoId",
                table: "RepairingServices",
                column: "DeviceInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairingServices_DeviceInfo_DeviceInfoId",
                table: "RepairingServices",
                column: "DeviceInfoId",
                principalTable: "DeviceInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingServices_ShoppingInfo_ShoppingInfoId",
                table: "ShoppingServices",
                column: "ShoppingInfoId",
                principalTable: "ShoppingInfo",
                principalColumn: "Id");
        }
    }
}
