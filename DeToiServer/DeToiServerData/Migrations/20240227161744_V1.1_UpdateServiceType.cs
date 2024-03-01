using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V11_UpdateServiceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CleaningServices_HomeInfo_HomeInfoId",
                table: "CleaningServices");

            migrationBuilder.DropTable(
                name: "HomeInfo");

            migrationBuilder.DropIndex(
                name: "IX_CleaningServices_HomeInfoId",
                table: "CleaningServices");

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("0e046144-4299-42ea-8564-0cb08348012e"));

            migrationBuilder.DeleteData(
                table: "ServiceStatuses",
                keyColumn: "Id",
                keyValue: new Guid("3afb2a2a-0a04-4970-8e67-3290e3e694cf"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("052b05f7-1411-4658-aae4-e4075bcb636c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("068d3fb3-be6b-4022-869a-8e29f7f9c5c1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("0c6ffd36-948c-403b-9a81-61126f415f47"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("0ff2ae05-6d9f-4791-8143-07333908e808"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("175929d6-8a3e-48d0-b0f1-7c96fdf14261"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("26ad9436-19aa-4f68-ba3c-b1c3e56f2939"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("2c5e99f9-2e58-4bee-9db6-a6cc1d30a9c2"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("34197bee-753f-417f-9c03-5af4e3b8ebf6"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3f7b318b-d544-4f7f-854d-0ef2f1374b6d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("4678a0c5-4d4f-40b7-a3d9-98e8cbfbdbc7"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("7a5218a3-1a4a-4d08-915c-62b92a276aed"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("7a8326cb-f8bd-451a-ae4b-e0b0f6aa7f5d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("89b68e39-059c-49db-ae9a-1267806739d1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a2fc1345-e83d-4a9d-a9c6-6b869994c80c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a78f0dd3-4904-449b-8d9f-296ebff404dd"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a7d76680-728e-4867-a337-172430676bc1"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b226e651-8f96-4243-9079-a4c3ae90f486"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c3d8a46d-5e0d-4a3b-9426-6220a01f0d12"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cf682390-2bfb-466d-8f62-cd069ee9d0d0"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("e0f33e4c-c7ba-4236-9a71-0709e3f35663"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ee04bf80-ff70-4e28-8910-ac516f3fb8c2"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("64b571b5-db08-4e3d-88dc-018ada53458c"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("750ac2d8-4b14-4a57-9a16-d0513341071e"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("932fc861-9f0c-41bf-951a-d247ef8f4bf0"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("94a999a1-07e5-4aab-a7ca-021743972e8e"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("a63ef5db-4cfb-48cd-9bf0-9b3bb2ed2035"));

            migrationBuilder.DeleteData(
                table: "ShoppingInfo",
                keyColumn: "Id",
                keyValue: new Guid("fdb1f195-c278-4007-b084-0fc94fee7d98"));

            migrationBuilder.DropColumn(
                name: "HomeInfoId",
                table: "CleaningServices");

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

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ServiceTypes",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "Users",
                columns: table => new
                {
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Phone);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    ConnectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Connected = table.Column<bool>(type: "bit", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_Connections_Users_UserPhone",
                        column: x => x.UserPhone,
                        principalTable: "Users",
                        principalColumn: "Phone");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Connections_UserPhone",
                table: "Connections",
                column: "UserPhone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Users");

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

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ServiceTypes");

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

            migrationBuilder.AddColumn<Guid>(
                name: "HomeInfoId",
                table: "CleaningServices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HomeInfo",
                columns: new[] { "Id", "Image", "Name", "Size" },
                values: new object[,]
                {
                    { new Guid("6996af11-7ba4-4b03-a396-0d110f948a43"), "image", "Phòng trọ", "10x20" },
                    { new Guid("c69b68d0-eb6f-4f96-8614-e4b5fbe4501b"), "image", "Biệt thự", "200x200" },
                    { new Guid("dd68702e-5cbf-45c9-af9f-8209a85bf6e3"), "image", "Nhà / Nhà phố", "30x30" },
                    { new Guid("e72de283-6c95-4c42-b53e-0608bbac1281"), "image", "Căn hộ chung cư", "40x40" }
                });

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e046144-4299-42ea-8564-0cb08348012e"), "Đã tiếp nhận" },
                    { new Guid("3afb2a2a-0a04-4970-8e67-3290e3e694cf"), "Đã hoàn thành" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("052b05f7-1411-4658-aae4-e4075bcb636c"), 60000.0, "Mua sắm hộ siêu nhanh", "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("068d3fb3-be6b-4022-869a-8e29f7f9c5c1"), 200000.0, "Hãy yên tâm không nổ đâu", "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("0c6ffd36-948c-403b-9a81-61126f415f47"), 50000000.0, "Hãy yên tâm không nổ đâu", "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("0ff2ae05-6d9f-4791-8143-07333908e808"), 4000000.0, "Mua sắm hộ siêu nhanh", "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("175929d6-8a3e-48d0-b0f1-7c96fdf14261"), 200000.0, "Sửa chữa để tôi lo", "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("26ad9436-19aa-4f68-ba3c-b1c3e56f2939"), 200000.0, "Sửa chữa để tôi lo", "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("2c5e99f9-2e58-4bee-9db6-a6cc1d30a9c2"), 100000.0, "Giặt thảm sạch", "Giặt thảm", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("34197bee-753f-417f-9c03-5af4e3b8ebf6"), 150000.0, "Vệ sinh máy lạnh", "Vệ sinh máy lạnh", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("3f7b318b-d544-4f7f-854d-0ef2f1374b6d"), 200000.0, "Sửa máy giặt", "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("4678a0c5-4d4f-40b7-a3d9-98e8cbfbdbc7"), 20000.0, "Mua sắm hộ siêu nhanh", "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("7a5218a3-1a4a-4d08-915c-62b92a276aed"), 55000.0, "Quét nhà sạch", "Quét nhà", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("7a8326cb-f8bd-451a-ae4b-e0b0f6aa7f5d"), 50000.0, "Lau nhà sạch", "Lau nhà", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("89b68e39-059c-49db-ae9a-1267806739d1"), 100000.0, "Mua sắm hộ siêu nhanh", "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("a2fc1345-e83d-4a9d-a9c6-6b869994c80c"), 200000.0, "Sửa chữa để tôi lo", "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("a78f0dd3-4904-449b-8d9f-296ebff404dd"), 30000.0, "Lau cửa kính sạch", "Lau cửa kính", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("a7d76680-728e-4867-a337-172430676bc1"), 200000.0, "Sửa chữa để tôi lo", "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("b226e651-8f96-4243-9079-a4c3ae90f486"), 120000.0, "Giặt ga giường", "Giặt ga giường", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("c3d8a46d-5e0d-4a3b-9426-6220a01f0d12"), 50000.0, "Mua sắm hộ siêu nhanh", "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("cf682390-2bfb-466d-8f62-cd069ee9d0d0"), 40000.0, "Hút bụi sạch", "Hút bụi", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("e0f33e4c-c7ba-4236-9a71-0709e3f35663"), 300000.0, "Mua sắm hộ siêu nhanh", "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("ee04bf80-ff70-4e28-8910-ac516f3fb8c2"), 40000.0, "Mua sắm hộ siêu nhanh", "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") }
                });

            migrationBuilder.InsertData(
                table: "ShoppingInfo",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("64b571b5-db08-4e3d-88dc-018ada53458c"), "image", "Đi siêu thị" },
                    { new Guid("750ac2d8-4b14-4a57-9a16-d0513341071e"), "image", "Đi siêu thị sang trọng" },
                    { new Guid("932fc861-9f0c-41bf-951a-d247ef8f4bf0"), "image", "Đi chợ truyền thống" },
                    { new Guid("94a999a1-07e5-4aab-a7ca-021743972e8e"), "image", "Đi mua vé xem phim" },
                    { new Guid("a63ef5db-4cfb-48cd-9bf0-9b3bb2ed2035"), "image", "Đi mua giày camping" },
                    { new Guid("fdb1f195-c278-4007-b084-0fc94fee7d98"), "image", "Đi mua quần áo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleaningServices_HomeInfoId",
                table: "CleaningServices",
                column: "HomeInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CleaningServices_HomeInfo_HomeInfoId",
                table: "CleaningServices",
                column: "HomeInfoId",
                principalTable: "HomeInfo",
                principalColumn: "Id");
        }
    }
}
