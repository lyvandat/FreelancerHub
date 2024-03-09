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

            migrationBuilder.AddColumn<int>(
                name: "TeamMemberCount",
                table: "Freelancers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("758bcb0c-23f5-4f14-9483-b82109136538"), "Đã hoàn thành" },
                    { new Guid("c24606fe-0967-4e21-bd63-a4a12409f511"), "Đã tiếp nhận" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("0448389f-7cb3-49af-911f-76920022a059"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("4f1868cb-1af2-4434-9b38-54f77216d7be"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("58cd3263-89f9-4cb4-9e1c-ba16f3ae601e"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("5e7c53b6-a969-4025-9d4f-3f985be447d6"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("62ae4f32-78b6-49b0-b814-fd26b4d798d2"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("6b253ecf-ba5b-4890-8be0-5b1395043740"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("79cd0f3c-6e89-46ea-8b1f-cc60b003aec7"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("7a678572-8bba-456a-ba5a-32beda74fa82"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("7ca4b1d5-d67e-4414-b258-fd0b2a87485c"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("875eab1a-1e20-4fb6-b930-7b7753c3c3ac"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("c1c9142b-a2ad-481b-96d4-5da9a05d0d2c"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("c6f615f8-ee76-4a94-86ea-f84c8299b5c0"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("d3c1d464-e0aa-4f10-b3d3-a41b85ef8ea9"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("f2d6798f-1996-44bc-b8a4-6ab5db5d3081"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("8ae82bee-fd5a-428b-8629-b02fe9992ea3"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("9f308ab1-d5c8-4a8c-9901-f847a38f7938"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("b9597027-f8e3-42b5-a4e3-c3e13a5a1db1"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("1635cd74-2b7d-4c7c-afa2-37d6f3ab8c62"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("55d730d5-9bf0-4e57-a839-bfacc5813243"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("8bf0fb46-cd55-44a8-a22f-63f93aaaa31c"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("a5d0c6a6-78cb-49d2-b0b3-0c52129ed061"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("ef48a192-452b-462b-b4ad-bc9e9c65d12e"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("038c3a10-8a52-4700-af00-80ecca758695"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("35d8bd4c-749a-4c98-bd88-47815b9990dc"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("7435ff61-7059-4fcd-bb91-265548f70464"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("8245d420-6d5c-4cd8-beed-de061d987deb"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("af906cc5-4670-4e95-a7a8-01029412454a"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("f160416a-8427-43e3-8793-ff60af711877"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("fc0211bc-ab8f-458f-b603-f03e99880c7a"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" }
                });

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

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("758bcb0c-23f5-4f14-9483-b82109136538"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("c24606fe-0967-4e21-bd63-a4a12409f511"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("0448389f-7cb3-49af-911f-76920022a059"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("4f1868cb-1af2-4434-9b38-54f77216d7be"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("58cd3263-89f9-4cb4-9e1c-ba16f3ae601e"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("5e7c53b6-a969-4025-9d4f-3f985be447d6"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("62ae4f32-78b6-49b0-b814-fd26b4d798d2"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("6b253ecf-ba5b-4890-8be0-5b1395043740"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("79cd0f3c-6e89-46ea-8b1f-cc60b003aec7"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("7a678572-8bba-456a-ba5a-32beda74fa82"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("7ca4b1d5-d67e-4414-b258-fd0b2a87485c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("875eab1a-1e20-4fb6-b930-7b7753c3c3ac"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c1c9142b-a2ad-481b-96d4-5da9a05d0d2c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c6f615f8-ee76-4a94-86ea-f84c8299b5c0"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("d3c1d464-e0aa-4f10-b3d3-a41b85ef8ea9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f2d6798f-1996-44bc-b8a4-6ab5db5d3081"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("8ae82bee-fd5a-428b-8629-b02fe9992ea3"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("9f308ab1-d5c8-4a8c-9901-f847a38f7938"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("b9597027-f8e3-42b5-a4e3-c3e13a5a1db1"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("1635cd74-2b7d-4c7c-afa2-37d6f3ab8c62"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("55d730d5-9bf0-4e57-a839-bfacc5813243"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("8bf0fb46-cd55-44a8-a22f-63f93aaaa31c"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("a5d0c6a6-78cb-49d2-b0b3-0c52129ed061"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("ef48a192-452b-462b-b4ad-bc9e9c65d12e"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("038c3a10-8a52-4700-af00-80ecca758695"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("35d8bd4c-749a-4c98-bd88-47815b9990dc"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("7435ff61-7059-4fcd-bb91-265548f70464"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8245d420-6d5c-4cd8-beed-de061d987deb"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("af906cc5-4670-4e95-a7a8-01029412454a"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f160416a-8427-43e3-8793-ff60af711877"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("fc0211bc-ab8f-458f-b603-f03e99880c7a"));

            migrationBuilder.DropColumn(
                name: "TeamMemberCount",
                table: "Freelancers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingServices",
                newName: "ShoppingServiceId");

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
