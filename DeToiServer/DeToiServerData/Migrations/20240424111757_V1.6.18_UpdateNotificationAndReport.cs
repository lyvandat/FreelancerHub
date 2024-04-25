using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1618_UpdateNotificationAndReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("0f6f1894-3ee7-46a8-9939-842e3c620231"));

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("07cb166a-4b4e-4637-b224-6277a69003d9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3361bc88-9f58-4be8-ac37-561606430f8a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3779d349-abcb-4dbc-abf1-25ba9e94a695"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("49a42267-d9dc-4e11-87a5-36525d4254d9"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("63ce2ebf-ef36-4b4a-891e-abbde2a75b38"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("662a64be-f7ea-4419-8978-dbf8f19159dc"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("73bf981f-1cfd-483d-80ee-14ab6d2e55ef"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("88006a8c-d757-4b85-8b91-c88e6078fe9c"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("96d250d4-0c0e-4521-b94e-05f3cafca3f3"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("a5677de0-a6a7-42c0-ab77-f34b75beb63d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("b9f74f9e-f792-4c48-b1b6-b6f0bc402d07"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("c82954a1-39d4-4012-86b3-6cad42c2b399"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("cca752d4-c17c-4c31-906f-f33cb8a18e48"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("dbb78597-043d-47c1-8810-93d392fd09ba"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ef2034c1-7f44-4d07-b9c0-e2a497999a9d"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("ef2632f0-47bd-4bbe-a46f-628a28f03d8b"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("f1b832b2-49f3-456f-bacb-b1f8da766bea"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("373127f5-b0d3-4be6-b3d3-e05e154ee87e"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("9959236f-c76b-4aad-9b6c-b9330b44c5e9"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("c5c59b38-aadb-4a5d-a3b3-1c0f20dff32b"));

            migrationBuilder.DeleteData(
                table: "UIElementInputMethodTypes",
                keyColumn: "Id",
                keyValue: new Guid("49affbf6-08cb-4de7-a78c-b7ef741862ed"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("b2ef36d0-8de4-4acd-a6c9-e9b5b4a3e7bb"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("c32f911d-e17b-409c-be33-d977371d126e"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("544015e0-9224-4666-b0e7-d45b216eed73"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("6ea5f689-3e43-434e-9915-e87bbb092ac0"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("f7981814-382d-4881-8b37-282b74ed28c7"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("01700b41-4af1-4ae5-9839-b01e5cfa2205"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("5d68535a-792b-4732-b24d-f9a77281609c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("a1d8ec7e-3783-4d68-894d-cbe25cebebbd"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("bcd66cb1-a6fe-4233-9368-ec05bad6e26f"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("cf84e5b8-3137-4735-900f-960722eedd9e"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f81033ee-a089-4421-9022-b339a220c293"));

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f"));

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a"));

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirementInputMethods",
                keyColumn: "Id",
                keyValue: new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirementInputMethods",
                keyColumn: "Id",
                keyValue: new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirementInputMethods",
                keyColumn: "Id",
                keyValue: new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"));

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e"));

            migrationBuilder.DeleteData(
                table: "UIElementInputMethodTypes",
                keyColumn: "Id",
                keyValue: new Guid("7bb50f83-c17c-48e2-a755-d51c397e06f4"));

            migrationBuilder.DeleteData(
                table: "UIElementInputMethodTypes",
                keyColumn: "Id",
                keyValue: new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"));

            migrationBuilder.DropColumn(
                name: "ActiveTime",
                table: "Freelancers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ServiceTypes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "ServiceTypes",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ServiceCategories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "ServiceCategories",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "MarkCount",
                table: "Freelancers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PushTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushBody = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationAccounts",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationAccounts", x => new { x.AccountId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_NotificationAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationAccounts_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rejected = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ReportDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResolvingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionIdOnCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("57779da0-5c1e-43d0-92c8-35ad09735667")),
                    ActionIdOnFreelance = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Accounts_FromId",
                        column: x => x.FromId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_Accounts_ToId",
                        column: x => x.ToId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_ReportActions_ActionIdOnCustomer",
                        column: x => x.ActionIdOnCustomer,
                        principalTable: "ReportActions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_ReportActions_ActionIdOnFreelance",
                        column: x => x.ActionIdOnFreelance,
                        principalTable: "ReportActions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ReportActions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00ecac93-4e33-4145-b72a-787893f68a84"), "", "Cấm tài khoản Customer" },
                    { new Guid("39cff80d-a7b4-4ef1-899d-a1b4fef74b80"), "", "Hoàn tiền 50%" },
                    { new Guid("558aeed2-8609-4f8d-9a27-57f36e3c9062"), "", "Hoàn tiền 100%" },
                    { new Guid("57779da0-5c1e-43d0-92c8-35ad09735667"), "", "Không hành động" },
                    { new Guid("aadbe15c-882f-4a3b-bd76-e017eee11027"), "", "Cấm tài khoản Freelancer" },
                    { new Guid("afdc03f7-f266-4031-ae34-223abad7b771"), "", "Đánh gậy tài khoản Freelancer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationAccounts_NotificationId",
                table: "NotificationAccounts",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ActionIdOnCustomer",
                table: "Reports",
                column: "ActionIdOnCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ActionIdOnFreelance",
                table: "Reports",
                column: "ActionIdOnFreelance");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_FromId",
                table: "Reports",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ToId",
                table: "Reports",
                column: "ToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationAccounts");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ReportActions");

            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ServiceCategories");

            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "ServiceCategories");

            migrationBuilder.DropColumn(
                name: "MarkCount",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Accounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ServiceTypes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveTime",
                table: "Freelancers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Accounts",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Accounts",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Accounts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Description", "Image", "Keys", "Name", "ServiceActivationStatusId", "ServiceClassName" },
                values: new object[,]
                {
                    { new Guid("0f6f1894-3ee7-46a8-9939-842e3c620231"), "Bao gồm vệ sinh máy lạnh, tủ lạnh, ...", "https://detoivn.b-cdn.net/services/vesinhmaylanh/category.png", null, "Vệ sinh thiết bị", null, "ElectronicsCleaning" },
                    { new Guid("1b1a6ebd-2838-4b3d-a1f1-1818305df2d6"), "Chuyển nhà phòng trọ", "https://detoivn.b-cdn.net/services/chuyennhaphongtro/category.png", null, "Chuyển nhà, phòng trọ", null, "Moving" },
                    { new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f"), "Bao gồm đi chợ, siêu thị, nhà sách, và nhiều dịch vụ khác", "https://detoivn.b-cdn.net/services/dicho/category.png", null, "Mua sắm", null, "Shopping" },
                    { new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a"), "Bao gồm sửa máy lạnh, tủ lạnh, và nhiều dịch vụ khác", "https://detoivn.b-cdn.net/services/suachua/category.png", null, "Sửa chữa", null, "Repairing" },
                    { new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e"), "Bao gồm lau nhà, quét nhà, hút bụi, và nhiều dịch vụ khác", "https://detoivn.b-cdn.net/services/dondep/category.png", null, "Dọn dẹp", null, "Cleaning" }
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
                table: "ServiceTypes",
                columns: new[] { "Id", "ActivationStatusId", "BasePrice", "CreatedAt", "Description", "Image", "Keys", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { new Guid("07cb166a-4b4e-4637-b224-6277a69003d9"), null, 4000000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mua sắm hộ siêu nhanh", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("3361bc88-9f58-4be8-ac37-561606430f8a"), null, 300000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mua sắm hộ siêu nhanh", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("3779d349-abcb-4dbc-abf1-25ba9e94a695"), null, 60000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mua sắm hộ siêu nhanh", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603"), null, 30000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dọn dẹp Phòng trọ", "https://detoivn.b-cdn.net/services/dondep/phongtro.png", null, "Phòng trọ", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("49a42267-d9dc-4e11-87a5-36525d4254d9"), null, 55000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dọn dẹp Biệt thự", "https://detoivn.b-cdn.net/services/dondep/bietthu.png", null, "Biệt thự", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("63ce2ebf-ef36-4b4a-891e-abbde2a75b38"), null, 200000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa máy giặt", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("662a64be-f7ea-4419-8978-dbf8f19159dc"), null, 200000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa chữa để tôi lo", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("73bf981f-1cfd-483d-80ee-14ab6d2e55ef"), null, 100000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mua sắm hộ siêu nhanh", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("88006a8c-d757-4b85-8b91-c88e6078fe9c"), null, 200000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa chữa để tôi lo", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("96d250d4-0c0e-4521-b94e-05f3cafca3f3"), null, 50000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mua sắm hộ siêu nhanh", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("a5677de0-a6a7-42c0-ab77-f34b75beb63d"), null, 20000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mua sắm hộ siêu nhanh", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("b9f74f9e-f792-4c48-b1b6-b6f0bc402d07"), null, 200000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa chữa để tôi lo", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("c82954a1-39d4-4012-86b3-6cad42c2b399"), null, 40000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mua sắm hộ siêu nhanh", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("cca752d4-c17c-4c31-906f-f33cb8a18e48"), null, 200000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hãy yên tâm không nổ đâu", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("dbb78597-043d-47c1-8810-93d392fd09ba"), null, 40000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dọn dẹp Căn hộ chung cư", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Căn hộ chung cư", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("ef2034c1-7f44-4d07-b9c0-e2a497999a9d"), null, 50000000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hãy yên tâm không nổ đâu", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("ef2632f0-47bd-4bbe-a46f-628a28f03d8b"), null, 50000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dọn dẹp Nhà / Nhà phố", "https://detoivn.b-cdn.net/services/dondep/n%C3%A2-nhapho.png", null, "Nhà / Nhà phố", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("f1b832b2-49f3-456f-bacb-b1f8da766bea"), null, 200000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa chữa để tôi lo", "https://detoivn.b-cdn.net/services/dondep/chungcu.jpg", null, "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") }
                });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("b2ef36d0-8de4-4acd-a6c9-e9b5b4a3e7bb"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("c32f911d-e17b-409c-be33-d977371d126e"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
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
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "Priority", "ServiceTypeId" },
                values: new object[,]
                {
                    { new Guid("373127f5-b0d3-4be6-b3d3-e05e154ee87e"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") },
                    { new Guid("9959236f-c76b-4aad-9b6c-b9330b44c5e9"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") }
                });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[] { new Guid("c5c59b38-aadb-4a5d-a3b3-1c0f20dff32b"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("544015e0-9224-4666-b0e7-d45b216eed73"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[] { new Guid("6ea5f689-3e43-434e-9915-e87bbb092ac0"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("f7981814-382d-4881-8b37-282b74ed28c7"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("01700b41-4af1-4ae5-9839-b01e5cfa2205"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "1" },
                    { new Guid("5d68535a-792b-4732-b24d-f9a77281609c"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("a1d8ec7e-3783-4d68-894d-cbe25cebebbd"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("bcd66cb1-a6fe-4233-9368-ec05bad6e26f"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null },
                    { new Guid("cf84e5b8-3137-4735-900f-960722eedd9e"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("f81033ee-a089-4421-9022-b339a220c293"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" }
                });
        }
    }
}
