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

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("47156bda-6077-4d2e-bc06-825e48c7f9ea"), "Đã tiếp nhận" },
                    { new Guid("d3480359-9cb9-447f-b0d3-78f153f21d19"), "Đã hoàn thành" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Image", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("129554a2-2dfb-4b6c-9664-1c5653e07215"), 60000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("19dce9ec-7ffa-4f7e-a417-b09290069f0c"), 200000.0, "Sửa máy giặt", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("27d058d1-e0c4-4778-8631-741ce8f177c0"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("37e0d9ee-db46-46c5-86af-e63fe52836c7"), 200000.0, "Hãy yên tâm không nổ đâu", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603"), 30000.0, "Dọn dẹp Phòng trọ", "https://detoivn.sirv.com/services/dondep/phongtro.png", "Phòng trọ", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("468d1faf-e9a1-471a-86ff-5a35c37042f7"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("49a42267-d9dc-4e11-87a5-36525d4254d9"), 55000.0, "Dọn dẹp Biệt thự", "https://detoivn.sirv.com/services/dondep/bietthu.png", "Biệt thự", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("4df80075-0f53-46f3-8337-470e655abe18"), 20000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("6e972095-8216-4f93-9e97-912be32b0a65"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("7aedca00-7d84-4528-98c9-8afde075d269"), 50000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("89bec0c6-6cf0-4382-95ba-8727aa7a5dc3"), 4000000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("903bbd65-7822-45ac-8202-ee87279debce"), 300000.0, "Mua sắm hộ siêu nhanh", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("d77cea99-d611-41c8-b959-4913c65edb53"), 40000.0, "Mua sắm hộ siêu nhanh", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("dbb78597-043d-47c1-8810-93d392fd09ba"), 40000.0, "Dọn dẹp Căn hộ chung cư", "https://detoivn.sirv.com/services/dondep/chungcu.jpg", "Căn hộ chung cư", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("ef2632f0-47bd-4bbe-a46f-628a28f03d8b"), 50000.0, "Dọn dẹp Nhà / Nhà phố", "https://detoivn.sirv.com/services/dondep/n%C3%A2-nhapho.png", "Nhà / Nhà phố", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("f8372e31-72f4-427d-857a-f28401693c8e"), 50000000.0, "Hãy yên tâm không nổ đâu", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("faf7cbb1-0ad7-4fa7-9869-442ea2ba125c"), 100000.0, "Mua sắm hộ siêu nhanh", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("fcac5651-2dab-469d-8c89-fdd953199014"), 200000.0, "Sửa chữa để tôi lo", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") }
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
                    { new Guid("5aa24b79-0091-4e68-90e8-81e77d1725b7"), false, "faBroom", "Nhân viên tự mang theo dụng cụ", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("aab3c1d7-a8e0-4c3c-b090-445dc0f4a587"), false, "faComputer", "Nhà có nhiều đồ điện tử", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("ab6c1954-ead6-4ab7-9184-7d07937da97a"), true, "faDog", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("9bae1e0a-f3c5-4354-8946-01e41f3e976c"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("b6ed9cad-1754-41b5-92c9-cfe600800d15"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
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
                    { new Guid("e390b90d-8e55-4f1a-ae2d-6ea443470487"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("f63cf964-bba0-4c92-9d0a-706cdaf630c7"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("f79d7980-26db-4ba1-b87d-6b6700f49000"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("0a201374-c3e7-4084-8ca0-32b93518d2af"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 3.", "max", "10" },
                    { new Guid("204b86c4-a178-443d-b05a-c75cd532e53e"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("36409e48-bf21-400c-a9e2-c0252bda9cdb"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("409e0b53-e8ba-42ae-a40c-dfb51e3c1803"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("81ad9402-004b-4106-8a4f-a3ec5ceab98d"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("adf2c237-9068-4f03-bb49-379180b1827a"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("ecc1a51f-a913-4a39-9c7b-ca71617620be"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "0" }
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
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("47156bda-6077-4d2e-bc06-825e48c7f9ea"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("d3480359-9cb9-447f-b0d3-78f153f21d19"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("129554a2-2dfb-4b6c-9664-1c5653e07215"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("19dce9ec-7ffa-4f7e-a417-b09290069f0c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("27d058d1-e0c4-4778-8631-741ce8f177c0"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("37e0d9ee-db46-46c5-86af-e63fe52836c7"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("468d1faf-e9a1-471a-86ff-5a35c37042f7"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("49a42267-d9dc-4e11-87a5-36525d4254d9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("4df80075-0f53-46f3-8337-470e655abe18"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("6e972095-8216-4f93-9e97-912be32b0a65"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("7aedca00-7d84-4528-98c9-8afde075d269"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("89bec0c6-6cf0-4382-95ba-8727aa7a5dc3"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("903bbd65-7822-45ac-8202-ee87279debce"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("d77cea99-d611-41c8-b959-4913c65edb53"));

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
                keyValue: new Guid("f8372e31-72f4-427d-857a-f28401693c8e"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("faf7cbb1-0ad7-4fa7-9869-442ea2ba125c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("fcac5651-2dab-469d-8c89-fdd953199014"));

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
