using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V12_UpdateUIElement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("31ae4781-3b0f-4d1f-947c-5a4e38301c84"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("4676cc5a-d402-4239-97bc-69650d1ad84e"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("017e2302-f69c-4e56-ae80-48b1143cb9d3"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1b56cfc1-689d-4e39-b1fd-697b22f75e4c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("26780a58-f18a-4549-b2a1-39a1da8940f4"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("7164452a-8848-4c4a-8a35-7ffc8b0c2aa1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("85d09f60-3472-48cb-89eb-22bed6cfed38"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("9267f1b4-ebc5-40cf-b745-4f624fd6f00f"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("948893e1-c7b0-4947-b60c-ebef235a5453"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("963b12f2-9046-4521-b723-4cc7be5b63f9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("97d291e4-3817-490a-a75b-f79d013272ac"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a8fe689e-c10a-44b7-b9e2-b3ffa2d95836"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c18d08b7-f578-4fc5-9c82-4f15e7a6c301"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb9f48c1-69c3-4ddd-8af9-26553b026c28"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("e4ba8f37-6455-415e-ac62-8c6f42576e44"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f3292f56-4ecb-4b56-99c7-96a6681c0db1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f7783d57-5b1b-46a9-b40c-d3f35ee8307d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("fce5008f-0d78-4bea-b3be-9cd17ddad3a4"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("fce9d49c-c240-4a2c-a1cb-517bb66c76db"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("fd1c1368-b365-43e9-a016-7f946f4ba66d"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("09f1d165-c519-4648-a8a9-9515ab17076c"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("1a7e166a-1011-4189-8c2b-50b907c0f580"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("6bf12a04-053a-4899-bda3-b8f470001c23"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("bce91a34-b766-4ec8-a90d-f565d4485b89"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("e5493f23-c4f3-484b-99c0-05dc3a81ea7f"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("e90018d5-ca82-44a6-8805-86e3e80842c7"));

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

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Services",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

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
                name: "UIElementAdditionServiceRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoSelect = table.Column<bool>(type: "bit", nullable: false),
                    ServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIElementAdditionServiceRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UIElementAdditionServiceRequirements_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UIElementInputMethodTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIElementInputMethodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UIElementInputOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InputMethodTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIElementInputOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UIElementInputOptions_UIElementInputMethodTypes_InputMethodTypeId",
                        column: x => x.InputMethodTypeId,
                        principalTable: "UIElementInputMethodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UIElementServiceRequirementInputMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIElementServiceRequirementInputMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UIElementServiceRequirementInputMethods_UIElementInputMethodTypes_MethodId",
                        column: x => x.MethodId,
                        principalTable: "UIElementInputMethodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UIElementServiceRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabelIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIElementServiceRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UIElementServiceRequirements_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UIElementServiceRequirements_UIElementServiceRequirementInputMethods_InputMethodId",
                        column: x => x.InputMethodId,
                        principalTable: "UIElementServiceRequirementInputMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UIElementValidationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIElementValidationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UIElementValidationTypes_UIElementServiceRequirementInputMethods_InputMethodId",
                        column: x => x.InputMethodId,
                        principalTable: "UIElementServiceRequirementInputMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("0f6f1894-3ee7-46a8-9939-842e3c620231"), "Bao gồm vệ sinh máy lạnh, tủ lạnh, ...", "https://detoivn.sirv.com/services/vesinhmaylanh/category.png", "Vệ sinh thiết bị" },
                    { new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"), "Chuyển nhà phòng trọ", "https://detoivn.sirv.com/services/chuyennhaphongtro/category.png", "Chuyển nhà phòng trọ" }
                });

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9d07dbb1-16bf-4aa7-b9d4-59bf0b0c4f76"), "Đã hoàn thành" },
                    { new Guid("e76625fb-b8a7-4ad3-a25a-0daadfcac988"), "Đã tiếp nhận" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("0cb65240-610c-43fa-8e1b-7e33a05ec2c0"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("0f8f5fac-dc4a-4d3d-b1b8-64738ad33f28"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("1b00898e-8d70-468c-8aa9-dfef3f15f0c7"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("206e468e-8a50-4331-827b-7bce2b9128fd"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603"), 30000.0, "Dọn dẹp Phòng trọ", "https://detoivn.sirv.com/services/dondep/phongtro.png", "Phòng trọ", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("49a42267-d9dc-4e11-87a5-36525d4254d9"), 55000.0, "Dọn dẹp Biệt thự", "https://detoivn.sirv.com/services/dondep/bietthu.png", "Biệt thự", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("71f55ad0-0b03-42c0-9617-f626d23f5e8a"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("78d78b48-5ce1-4840-96ba-321c1c1ccbc7"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("900ba2b4-9a36-4b0a-8d55-59b1b531beca"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("a7e6ce5d-6e54-4f11-9543-e35f9868d76c"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("a860d638-c3a5-4b42-bd16-e9aad300bd8e"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("ab9224ee-9478-4f47-bbf9-d88a9a5102c4"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("afefd895-29e4-4bad-9ee3-7bd9a0f53a09"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("b8937eed-2939-41ae-8e4d-fa8a4f46d4ab"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("d2918d21-88d8-4871-8cb6-aeee7896f09c"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("dbb78597-043d-47c1-8810-93d392fd09ba"), 40000.0, "Dọn dẹp Căn hộ chung cư", "https://detoivn.sirv.com/services/dondep/chungcu.jpg", "Căn hộ chung cư", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("ef2632f0-47bd-4bbe-a46f-628a28f03d8b"), 50000.0, "Dọn dẹp Nhà / Nhà phố", "https://detoivn.sirv.com/services/dondep/n%C3%A2-nhapho.png", "Nhà / Nhà phố", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("f78e54c8-da98-4cef-9569-307b92ef4697"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputMethodTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("49affbf6-08cb-4de7-a78c-b7ef741862ed"), "input" },
                    { new Guid("7bb50f83-c17c-48e2-a755-d51c397e06f4"), "input" },
                    { new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "select" }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Label", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("1ae07a68-2065-4f0e-a60c-fe8b8f19cca4"), true, "faDog", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("a1a30cc8-4c10-473c-94fd-0ca71157bfcc"), false, "faBroom", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("b7cd1971-51c5-4212-83b0-695185203343"), false, "faComputer", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("2e6fbe65-7b54-4509-881a-d6ba68db5149"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" },
                    { new Guid("e8a2b705-fd29-49a0-b841-e60409e08fdd"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirementInputMethods",
                columns: new[] { "Id", "DataType", "MethodId" },
                values: new object[,]
                {
                    { new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "text", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609") },
                    { new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "number", new Guid("7bb50f83-c17c-48e2-a755-d51c397e06f4") },
                    { new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "text", new Guid("7bb50f83-c17c-48e2-a755-d51c397e06f4") }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("a406450f-670a-4fd5-a650-0a415802eead"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("b6dc0d6f-4785-4c07-9ce9-a5a730be012c"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("bd03311f-c631-487c-80e8-63cf3d1b2ef2"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("2c8f0029-063c-42ab-8821-b381837b4547"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" },
                    { new Guid("61ba2f6a-4dda-40f8-a877-2f8480003ed0"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("655c8c73-8fe2-4cf0-95e4-ccb427f77596"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("ad4ee88c-0e5e-435c-86c3-880ba8367b55"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("d8f5c8ce-3131-48aa-a7ae-5ddfc68ae04a"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("e7dced49-719b-4da7-aa8e-aef49d137794"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("f978f0dc-4d55-49f4-b96d-1b548fcedd60"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UIElementAdditionServiceRequirements_ServiceTypeId",
                table: "UIElementAdditionServiceRequirements",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UIElementInputOptions_InputMethodTypeId",
                table: "UIElementInputOptions",
                column: "InputMethodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UIElementServiceRequirementInputMethods_MethodId",
                table: "UIElementServiceRequirementInputMethods",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_UIElementServiceRequirements_InputMethodId",
                table: "UIElementServiceRequirements",
                column: "InputMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_UIElementServiceRequirements_ServiceTypeId",
                table: "UIElementServiceRequirements",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UIElementValidationTypes_InputMethodId",
                table: "UIElementValidationTypes",
                column: "InputMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UIElementAdditionServiceRequirements");

            migrationBuilder.DropTable(
                name: "UIElementInputOptions");

            migrationBuilder.DropTable(
                name: "UIElementServiceRequirements");

            migrationBuilder.DropTable(
                name: "UIElementValidationTypes");

            migrationBuilder.DropTable(
                name: "UIElementServiceRequirementInputMethods");

            migrationBuilder.DropTable(
                name: "UIElementInputMethodTypes");

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("0f6f1894-3ee7-46a8-9939-842e3c620231"));

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("9d07dbb1-16bf-4aa7-b9d4-59bf0b0c4f76"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("e76625fb-b8a7-4ad3-a25a-0daadfcac988"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("0cb65240-610c-43fa-8e1b-7e33a05ec2c0"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("0f8f5fac-dc4a-4d3d-b1b8-64738ad33f28"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("1b00898e-8d70-468c-8aa9-dfef3f15f0c7"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("206e468e-8a50-4331-827b-7bce2b9128fd"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("49a42267-d9dc-4e11-87a5-36525d4254d9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("71f55ad0-0b03-42c0-9617-f626d23f5e8a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("78d78b48-5ce1-4840-96ba-321c1c1ccbc7"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("900ba2b4-9a36-4b0a-8d55-59b1b531beca"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a7e6ce5d-6e54-4f11-9543-e35f9868d76c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a860d638-c3a5-4b42-bd16-e9aad300bd8e"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ab9224ee-9478-4f47-bbf9-d88a9a5102c4"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("afefd895-29e4-4bad-9ee3-7bd9a0f53a09"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8937eed-2939-41ae-8e4d-fa8a4f46d4ab"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("d2918d21-88d8-4871-8cb6-aeee7896f09c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("dbb78597-043d-47c1-8810-93d392fd09ba"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ef2632f0-47bd-4bbe-a46f-628a28f03d8b"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f78e54c8-da98-4cef-9569-307b92ef4697"));

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

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Services",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21,
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f"),
                column: "Image",
                value: "image");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a"),
                column: "Image",
                value: "image");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e"),
                column: "Image",
                value: "image");

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("31ae4781-3b0f-4d1f-947c-5a4e38301c84"), "Đã hoàn thành" },
                    { new Guid("4676cc5a-d402-4239-97bc-69650d1ad84e"), "Đã tiếp nhận" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("017e2302-f69c-4e56-ae80-48b1143cb9d3"), 55000.0, "Dọn dẹp Biệt thự", "https://detoivn.sirv.com/services/dondep/bietthu.png", "Biệt thự", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("1b56cfc1-689d-4e39-b1fd-697b22f75e4c"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("26780a58-f18a-4549-b2a1-39a1da8940f4"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("7164452a-8848-4c4a-8a35-7ffc8b0c2aa1"), 50000.0, "Dọn dẹp Nhà / Nhà phố", "https://detoivn.sirv.com/services/dondep/n%C3%A2-nhapho.png", "Nhà / Nhà phố", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("85d09f60-3472-48cb-89eb-22bed6cfed38"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("9267f1b4-ebc5-40cf-b745-4f624fd6f00f"), 40000.0, "Dọn dẹp Căn hộ chung cư", "https://detoivn.sirv.com/services/dondep/chungcu.jpg", "Căn hộ chung cư", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("948893e1-c7b0-4947-b60c-ebef235a5453"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("963b12f2-9046-4521-b723-4cc7be5b63f9"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("97d291e4-3817-490a-a75b-f79d013272ac"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("a8fe689e-c10a-44b7-b9e2-b3ffa2d95836"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("c18d08b7-f578-4fc5-9c82-4f15e7a6c301"), 30000.0, "Dọn dẹp Phòng trọ", "https://detoivn.sirv.com/services/dondep/phongtro.png", "Phòng trọ", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("cb9f48c1-69c3-4ddd-8af9-26553b026c28"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("e4ba8f37-6455-415e-ac62-8c6f42576e44"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("f3292f56-4ecb-4b56-99c7-96a6681c0db1"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("f7783d57-5b1b-46a9-b40c-d3f35ee8307d"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("fce5008f-0d78-4bea-b3be-9cd17ddad3a4"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("fce9d49c-c240-4a2c-a1cb-517bb66c76db"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("fd1c1368-b365-43e9-a016-7f946f4ba66d"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") }
                });

            migrationBuilder.InsertData(
                table: "ShoppingInfo",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("09f1d165-c519-4648-a8a9-9515ab17076c"), "image", "Đi siêu thị sang trọng" },
                    { new Guid("1a7e166a-1011-4189-8c2b-50b907c0f580"), "image", "Đi chợ truyền thống" },
                    { new Guid("6bf12a04-053a-4899-bda3-b8f470001c23"), "image", "Đi mua vé xem phim" },
                    { new Guid("bce91a34-b766-4ec8-a90d-f565d4485b89"), "image", "Đi mua giày camping" },
                    { new Guid("e5493f23-c4f3-484b-99c0-05dc3a81ea7f"), "image", "Đi siêu thị" },
                    { new Guid("e90018d5-ca82-44a6-8805-86e3e80842c7"), "image", "Đi mua quần áo" }
                });
        }
    }
}
