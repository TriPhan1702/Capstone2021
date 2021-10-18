using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentsNumber",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "SuccessfulAppointmentsNumber",
                table: "Staff");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 18, 19, 14, 57, 282, DateTimeKind.Local).AddTicks(799) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Status" },
                values: new object[] { 1, null, "tphan2883@gmail.com", new byte[] { 68, 113, 5, 73, 182, 235, 216, 69, 80, 101, 111, 132, 3, 217, 6, 74, 84, 163, 159, 95, 61, 157, 92, 239, 59, 155, 201, 6, 145, 145, 131, 183, 75, 61, 207, 145, 60, 50, 140, 167, 166, 70, 63, 215, 198, 132, 248, 105, 152, 232, 114, 118, 148, 74, 21, 35, 135, 146, 111, 44, 0, 2, 169, 254 }, new byte[] { 183, 32, 183, 56, 165, 203, 121, 56, 242, 104, 175, 208, 224, 229, 250, 23, 157, 52, 66, 116, 23, 193, 167, 234, 110, 123, 13, 21, 184, 39, 19, 176, 249, 114, 238, 121, 228, 50, 223, 158, 102, 67, 161, 3, 163, 180, 153, 151, 115, 253, 137, 194, 82, 120, 183, 44, 168, 77, 127, 97, 92, 78, 177, 106, 242, 79, 131, 28, 55, 42, 204, 46, 204, 206, 119, 240, 168, 206, 152, 142, 101, 141, 98, 190, 150, 125, 209, 187, 39, 244, 93, 63, 67, 85, 142, 141, 8, 231, 157, 197, 34, 97, 18, 116, 194, 178, 221, 145, 131, 6, 235, 64, 149, 7, 47, 161, 162, 15, 143, 18, 152, 58, 208, 7, 118, 139, 92, 125 }, "0869190061", "manager", "Active" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentsNumber",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SuccessfulAppointmentsNumber",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809) });
        }
    }
}
