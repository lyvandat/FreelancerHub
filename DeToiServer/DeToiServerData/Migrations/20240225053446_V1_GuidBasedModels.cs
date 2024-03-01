using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1_GuidBasedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    LoginToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Tilte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

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
                name: "FrequentlyAskedQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Tilte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequentlyAskedQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermOfServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Tilte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermOfServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTeam = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freelancers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTypes_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerPromotions",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPromotions", x => new { x.PromotionId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerPromotions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPromotions_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FreelanceAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerAccountId",
                        column: x => x.CustomerAccountId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Freelancers_FreelanceAccountId",
                        column: x => x.FreelanceAccountId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FreelanceSkills",
                columns: table => new
                {
                    FreelancersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelanceSkills", x => new { x.FreelancersId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_FreelanceSkills_Freelancers_FreelancersId",
                        column: x => x.FreelancersId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreelanceSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedPrice = table.Column<double>(type: "float", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ServiceStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ServiceStatuses_ServiceStatusId",
                        column: x => x.ServiceStatusId,
                        principalTable: "ServiceStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CleaningServices",
                columns: table => new
                {
                    CleaningServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningServices", x => x.CleaningServiceId);
                    table.ForeignKey(
                        name: "FK_CleaningServices_HomeInfo_HomeInfoId",
                        column: x => x.HomeInfoId,
                        principalTable: "HomeInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CleaningServices_Services_CleaningServiceId",
                        column: x => x.CleaningServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairingServices",
                columns: table => new
                {
                    RepairingServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairingServices", x => x.RepairingServiceId);
                    table.ForeignKey(
                        name: "FK_RepairingServices_DeviceInfo_DeviceInfoId",
                        column: x => x.DeviceInfoId,
                        principalTable: "DeviceInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepairingServices_Services_RepairingServiceId",
                        column: x => x.RepairingServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingServices",
                columns: table => new
                {
                    ShoppingServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ShoppingItems = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingServices", x => x.ShoppingServiceId);
                    table.ForeignKey(
                        name: "FK_ShoppingServices_Services_ShoppingServiceId",
                        column: x => x.ShoppingServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingServices_ShoppingInfo_ShoppingInfoId",
                        column: x => x.ShoppingInfoId,
                        principalTable: "ShoppingInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderService",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderService", x => new { x.OrderId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_OrderService_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderService_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "HomeInfo",
                columns: new[] { "Id", "Image", "Name", "Size" },
                values: new object[,]
                {
                    { new Guid("6996af11-7ba4-4b03-a396-0d110f948a43"), "https://detoivn.sirv.com/services/dondep/phongtro.png", "Phòng trọ", "10x20" },
                    { new Guid("c69b68d0-eb6f-4f96-8614-e4b5fbe4501b"), "https://detoivn.sirv.com/services/dondep/bietthu.png", "Biệt thự", "200x200" },
                    { new Guid("dd68702e-5cbf-45c9-af9f-8209a85bf6e3"), "https://detoivn.sirv.com/services/dondep/n%C3%A2-nhapho.png", "Nhà / Nhà phố", "30x30" },
                    { new Guid("e72de283-6c95-4c42-b53e-0608bbac1281"), "https://detoivn.sirv.com/services/dondep/chungcu.jpg", "Căn hộ chung cư", "40x40" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f"), "Bao gồm đi chợ, siêu thị, nhà sách, và nhiều dịch vụ khác", "https://detoivn.sirv.com/services/dicho/category.png", "Mua sắm" },
                    { new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a"), "Bao gồm sửa máy lạnh, tủ lạnh, và nhiều dịch vụ khác", "https://detoivn.sirv.com/services/suachua/category.png", "Sửa chữa" },
                    { new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e"), "Bao gồm lau nhà, quét nhà, hút bụi, và nhiều dịch vụ khác", "https://detoivn.sirv.com/services/dondep/category.png", "Dọn dẹp" }
                });

            migrationBuilder.InsertData(
                table: "ServiceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e046144-4299-42ea-8564-0cb08348012e"), "Đã tiếp nhận" },
                    { new Guid("3afb2a2a-0a04-4970-8e67-3290e3e694cf"), "Đã hoàn thành" },
                    { new Guid("8a9f22f1-3c67-49f7-bd84-ec290e4a37fd"), "Chờ xử lí" }
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

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "BasePrice", "Description", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    // dọn dẹp 
                    { new Guid("2c5e99f9-2e58-4bee-9db6-a6cc1d30a9c2"), 100000.0, "Giặt thảm sạch", "Giặt thảm", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("34197bee-753f-417f-9c03-5af4e3b8ebf6"), 150000.0, "Vệ sinh máy lạnh", "Vệ sinh máy lạnh", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("7a5218a3-1a4a-4d08-915c-62b92a276aed"), 55000.0, "Quét nhà sạch", "Quét nhà", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("7a8326cb-f8bd-451a-ae4b-e0b0f6aa7f5d"), 50000.0, "Lau nhà sạch", "Lau nhà", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("a78f0dd3-4904-449b-8d9f-296ebff404dd"), 30000.0, "Lau cửa kính sạch", "Lau cửa kính", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("b226e651-8f96-4243-9079-a4c3ae90f486"), 120000.0, "Giặt ga giường", "Giặt ga giường", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("cf682390-2bfb-466d-8f62-cd069ee9d0d0"), 40000.0, "Hút bụi sạch", "Hút bụi", new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    { new Guid("068d3fb3-be6b-4022-869a-8e29f7f9c5c1"), 200000.0, "Hãy yên tâm không nổ đâu", "Sửa máy tính laptop", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("0c6ffd36-948c-403b-9a81-61126f415f47"), 50000000.0, "Hãy yên tâm không nổ đâu", "Sửa bình gas", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("175929d6-8a3e-48d0-b0f1-7c96fdf14261"), 200000.0, "Sửa chữa để tôi lo", "Sửa tivi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("26ad9436-19aa-4f68-ba3c-b1c3e56f2939"), 200000.0, "Sửa chữa để tôi lo", "Sửa bàn ủi", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("3f7b318b-d544-4f7f-854d-0ef2f1374b6d"), 200000.0, "Sửa máy giặt", "Sửa máy giặt", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("a2fc1345-e83d-4a9d-a9c6-6b869994c80c"), 200000.0, "Sửa chữa để tôi lo", "Sửa ống nước", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("a7d76680-728e-4867-a337-172430676bc1"), 200000.0, "Sửa chữa để tôi lo", "Sửa máy lạnh", new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    { new Guid("052b05f7-1411-4658-aae4-e4075bcb636c"), 60000.0, "Mua sắm hộ siêu nhanh", "Đi mua quần áo", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("0ff2ae05-6d9f-4791-8143-07333908e808"), 4000000.0, "Mua sắm hộ siêu nhanh", "Đi mua vé concert", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("4678a0c5-4d4f-40b7-a3d9-98e8cbfbdbc7"), 20000.0, "Mua sắm hộ siêu nhanh", "Đi mua vé xem phim", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("89b68e39-059c-49db-ae9a-1267806739d1"), 100000.0, "Mua sắm hộ siêu nhanh", "Đi siêu thị sang trọng", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("c3d8a46d-5e0d-4a3b-9426-6220a01f0d12"), 50000.0, "Mua sắm hộ siêu nhanh", "Đi siêu thị hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("e0f33e4c-c7ba-4236-9a71-0709e3f35663"), 300000.0, "Mua sắm hộ siêu nhanh", "Đi mua giày camping", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    { new Guid("ee04bf80-ff70-4e28-8910-ac516f3fb8c2"), 40000.0, "Mua sắm hộ siêu nhanh", "Đi chợ hộ", new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerAccountId",
                table: "Addresses",
                column: "CustomerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_FreelanceAccountId",
                table: "Addresses",
                column: "FreelanceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningServices_HomeInfoId",
                table: "CleaningServices",
                column: "HomeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPromotions_CustomerId",
                table: "CustomerPromotions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountId",
                table: "Customers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_AccountId",
                table: "Freelancers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceSkills_SkillsId",
                table: "FreelanceSkills",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FreelancerId",
                table: "Orders",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceCategoryId",
                table: "Orders",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceStatusId",
                table: "Orders",
                column: "ServiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_ServiceId",
                table: "OrderService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairingServices_DeviceInfoId",
                table: "RepairingServices",
                column: "DeviceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceCategoryId",
                table: "Services",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_ServiceCategoryId",
                table: "ServiceTypes",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingServices_ShoppingInfoId",
                table: "ShoppingServices",
                column: "ShoppingInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "CleaningServices");

            migrationBuilder.DropTable(
                name: "CustomerPromotions");

            migrationBuilder.DropTable(
                name: "FreelanceSkills");

            migrationBuilder.DropTable(
                name: "FrequentlyAskedQuestions");

            migrationBuilder.DropTable(
                name: "OrderService");

            migrationBuilder.DropTable(
                name: "RepairingServices");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "ShoppingServices");

            migrationBuilder.DropTable(
                name: "TermOfServices");

            migrationBuilder.DropTable(
                name: "HomeInfo");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DeviceInfo");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ShoppingInfo");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Freelancers");

            migrationBuilder.DropTable(
                name: "ServiceStatuses");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
