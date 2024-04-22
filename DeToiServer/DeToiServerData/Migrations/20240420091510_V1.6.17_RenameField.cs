using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeToiServerData.Migrations
{
    /// <inheritdoc />
    public partial class V1617_RenameField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("9512c8f0-b0f7-457e-900a-ed07a1317db8"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("a83f0ade-a5dd-4a6f-ad20-bad7d5797592"));

            migrationBuilder.DeleteData(
                table: "UIElementAdditionServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("da787485-1173-4bec-b845-7eaf626a5d37"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("979adeaa-fc5d-4467-957f-a69b7dc2a2d5"));

            migrationBuilder.DeleteData(
                table: "UIElementInputOptions",
                keyColumn: "Id",
                keyValue: new Guid("bf644fef-dd88-4852-900e-083ff307e3f7"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("3a905575-94c4-4641-8d1c-be9e9cf34b0f"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("5478cd5a-2275-4538-a3f5-4bb640437324"));

            migrationBuilder.DeleteData(
                table: "UIElementServiceRequirements",
                keyColumn: "Id",
                keyValue: new Guid("5f8aebbc-c79a-48d6-a880-9c374a12304c"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("2ac69245-5d8d-4e39-9c62-3f60e9f0e8fd"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("31110304-53e8-4dc0-8310-dee34c2963e1"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("3d7c664a-445a-404e-8a62-a0b7264ea6cb"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("74f19f3a-d0f7-4a35-ba3a-1b6d3260a72b"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("a8d438fa-5b74-493f-9732-4462b21f9c9e"));

            migrationBuilder.DeleteData(
                table: "UIElementValidationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f0f4511e-bf47-43cc-843b-67631eb52252"));

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PaymentHistories",
                newName: "PaymentStatus");

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
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("b2ef36d0-8de4-4acd-a6c9-e9b5b4a3e7bb"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("c32f911d-e17b-409c-be33-d977371d126e"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "PaymentHistories",
                newName: "Status");

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("9512c8f0-b0f7-457e-900a-ed07a1317db8"), false, "faBroom", "freelancerBringTools", "Nhân viên tự mang theo dụng cụ", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "ServiceTypeId" },
                values: new object[] { new Guid("a83f0ade-a5dd-4a6f-ad20-bad7d5797592"), true, "faDog", "hasPets", "Nhà có thú cưng", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementAdditionServiceRequirements",
                columns: new[] { "Id", "AutoSelect", "Icon", "Key", "Label", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("da787485-1173-4bec-b845-7eaf626a5d37"), false, "faComputer", "hasElectronics", "Nhà có nhiều đồ điện tử", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementInputOptions",
                columns: new[] { "Id", "Description", "InputMethodTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("979adeaa-fc5d-4467-957f-a69b7dc2a2d5"), "Trung bình 50.000đ / phòng, tiết kiệm và nhanh chóng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn theo phòng" },
                    { new Guid("bf644fef-dd88-4852-900e-083ff307e3f7"), "Tất cả dịch vụ, dọn toàn bộ nhà / phòng", new Guid("89e6f2f5-15cc-470c-a363-427ee8646609"), "Dọn trọn gói" }
                });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("3a905575-94c4-4641-8d1c-be9e9cf34b0f"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "roomNumber", "Số lượng phòng", "faPersonShelter", "Lưu ý: Nếu bạn chọn dịch vụ dọn theo phòng, vui lòng bổ sung số phòng cần dọn ở đây", 2, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "ServiceTypeId" },
                values: new object[] { new Guid("5478cd5a-2275-4538-a3f5-4bb640437324"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "addressLine", "Số nhà, số phòng, hẻm (ngõ)", null, "Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent", new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementServiceRequirements",
                columns: new[] { "Id", "InputMethodId", "Key", "Label", "LabelIcon", "Placeholder", "Priority", "ServiceTypeId" },
                values: new object[] { new Guid("5f8aebbc-c79a-48d6-a880-9c374a12304c"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "cleanningType", "Bạn muốn chúng tôi dọn như thế nào?", "faFlag", "Giúp nhân viên biết thêm về công việc cần làm", 1, new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603") });

            migrationBuilder.InsertData(
                table: "UIElementValidationTypes",
                columns: new[] { "Id", "InputMethodId", "Message", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("2ac69245-5d8d-4e39-9c62-3f60e9f0e8fd"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 2.", "min", "1" },
                    { new Guid("31110304-53e8-4dc0-8310-dee34c2963e1"), new Guid("0ad2fdde-73c5-433c-99f8-95e9c9df32a4"), "Thông báo valid input 2 custom 1.", "required", null },
                    { new Guid("3d7c664a-445a-404e-8a62-a0b7264ea6cb"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 3.", "max", "255" },
                    { new Guid("74f19f3a-d0f7-4a35-ba3a-1b6d3260a72b"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 2.", "min", "0" },
                    { new Guid("a8d438fa-5b74-493f-9732-4462b21f9c9e"), new Guid("95b69f6f-c8a5-4b94-824b-214bb7435c4f"), "Thông báo valid input 1 custom 1.", "required", null },
                    { new Guid("f0f4511e-bf47-43cc-843b-67631eb52252"), new Guid("42b3fce8-5392-4bfd-97a2-0b84532a4b67"), "Thông báo valid input 3 custom 1.", "required", null }
                });
        }
    }
}
