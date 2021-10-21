using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChosenStaffId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 10, 21, 15, 13, 54, 709, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 242, 202, 78, 80, 32, 223, 174, 106, 76, 101, 206, 7, 87, 23, 15, 255, 164, 172, 130, 75, 45, 144, 149, 167, 162, 95, 118, 104, 48, 174, 37, 233, 50, 250, 93, 133, 152, 145, 153, 30, 54, 93, 149, 249, 162, 208, 43, 54, 130, 202, 232, 41, 225, 142, 44, 1, 192, 133, 152, 160, 179, 62, 219 }, new byte[] { 116, 49, 154, 95, 232, 240, 15, 218, 157, 4, 204, 138, 0, 207, 28, 169, 242, 246, 240, 244, 216, 12, 94, 73, 1, 133, 77, 111, 152, 63, 31, 0, 249, 46, 164, 17, 153, 190, 185, 94, 132, 167, 107, 215, 69, 109, 47, 41, 220, 168, 61, 171, 57, 142, 122, 249, 138, 91, 183, 78, 133, 145, 30, 31, 30, 70, 48, 136, 131, 86, 106, 160, 191, 74, 109, 46, 181, 48, 98, 158, 145, 6, 100, 223, 107, 255, 114, 8, 157, 150, 248, 135, 151, 27, 11, 131, 147, 158, 48, 99, 78, 30, 173, 226, 99, 123, 68, 211, 158, 62, 224, 18, 42, 185, 192, 173, 232, 193, 36, 186, 230, 240, 102, 157, 212, 21, 144, 245 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 242, 202, 78, 80, 32, 223, 174, 106, 76, 101, 206, 7, 87, 23, 15, 255, 164, 172, 130, 75, 45, 144, 149, 167, 162, 95, 118, 104, 48, 174, 37, 233, 50, 250, 93, 133, 152, 145, 153, 30, 54, 93, 149, 249, 162, 208, 43, 54, 130, 202, 232, 41, 225, 142, 44, 1, 192, 133, 152, 160, 179, 62, 219 }, new byte[] { 116, 49, 154, 95, 232, 240, 15, 218, 157, 4, 204, 138, 0, 207, 28, 169, 242, 246, 240, 244, 216, 12, 94, 73, 1, 133, 77, 111, 152, 63, 31, 0, 249, 46, 164, 17, 153, 190, 185, 94, 132, 167, 107, 215, 69, 109, 47, 41, 220, 168, 61, 171, 57, 142, 122, 249, 138, 91, 183, 78, 133, 145, 30, 31, 30, 70, 48, 136, 131, 86, 106, 160, 191, 74, 109, 46, 181, 48, 98, 158, 145, 6, 100, 223, 107, 255, 114, 8, 157, 150, 248, 135, 151, 27, 11, 131, 147, 158, 48, 99, 78, 30, 173, 226, 99, 123, 68, 211, 158, 62, 224, 18, 42, 185, 192, 173, 232, 193, 36, 186, 230, 240, 102, 157, 212, 21, 144, 245 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 242, 202, 78, 80, 32, 223, 174, 106, 76, 101, 206, 7, 87, 23, 15, 255, 164, 172, 130, 75, 45, 144, 149, 167, 162, 95, 118, 104, 48, 174, 37, 233, 50, 250, 93, 133, 152, 145, 153, 30, 54, 93, 149, 249, 162, 208, 43, 54, 130, 202, 232, 41, 225, 142, 44, 1, 192, 133, 152, 160, 179, 62, 219 }, new byte[] { 116, 49, 154, 95, 232, 240, 15, 218, 157, 4, 204, 138, 0, 207, 28, 169, 242, 246, 240, 244, 216, 12, 94, 73, 1, 133, 77, 111, 152, 63, 31, 0, 249, 46, 164, 17, 153, 190, 185, 94, 132, 167, 107, 215, 69, 109, 47, 41, 220, 168, 61, 171, 57, 142, 122, 249, 138, 91, 183, 78, 133, 145, 30, 31, 30, 70, 48, 136, 131, 86, 106, 160, 191, 74, 109, 46, 181, 48, 98, 158, 145, 6, 100, 223, 107, 255, 114, 8, 157, 150, 248, 135, 151, 27, 11, 131, 147, 158, 48, 99, 78, 30, 173, 226, 99, 123, 68, 211, 158, 62, 224, 18, 42, 185, 192, 173, 232, 193, 36, 186, 230, 240, 102, 157, 212, 21, 144, 245 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 242, 202, 78, 80, 32, 223, 174, 106, 76, 101, 206, 7, 87, 23, 15, 255, 164, 172, 130, 75, 45, 144, 149, 167, 162, 95, 118, 104, 48, 174, 37, 233, 50, 250, 93, 133, 152, 145, 153, 30, 54, 93, 149, 249, 162, 208, 43, 54, 130, 202, 232, 41, 225, 142, 44, 1, 192, 133, 152, 160, 179, 62, 219 }, new byte[] { 116, 49, 154, 95, 232, 240, 15, 218, 157, 4, 204, 138, 0, 207, 28, 169, 242, 246, 240, 244, 216, 12, 94, 73, 1, 133, 77, 111, 152, 63, 31, 0, 249, 46, 164, 17, 153, 190, 185, 94, 132, 167, 107, 215, 69, 109, 47, 41, 220, 168, 61, 171, 57, 142, 122, 249, 138, 91, 183, 78, 133, 145, 30, 31, 30, 70, 48, 136, 131, 86, 106, 160, 191, 74, 109, 46, 181, 48, 98, 158, 145, 6, 100, 223, 107, 255, 114, 8, 157, 150, 248, 135, 151, 27, 11, 131, 147, 158, 48, 99, 78, 30, 173, 226, 99, 123, 68, 211, 158, 62, 224, 18, 42, 185, 192, 173, 232, 193, 36, 186, 230, 240, 102, 157, 212, 21, 144, 245 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 242, 202, 78, 80, 32, 223, 174, 106, 76, 101, 206, 7, 87, 23, 15, 255, 164, 172, 130, 75, 45, 144, 149, 167, 162, 95, 118, 104, 48, 174, 37, 233, 50, 250, 93, 133, 152, 145, 153, 30, 54, 93, 149, 249, 162, 208, 43, 54, 130, 202, 232, 41, 225, 142, 44, 1, 192, 133, 152, 160, 179, 62, 219 }, new byte[] { 116, 49, 154, 95, 232, 240, 15, 218, 157, 4, 204, 138, 0, 207, 28, 169, 242, 246, 240, 244, 216, 12, 94, 73, 1, 133, 77, 111, 152, 63, 31, 0, 249, 46, 164, 17, 153, 190, 185, 94, 132, 167, 107, 215, 69, 109, 47, 41, 220, 168, 61, 171, 57, 142, 122, 249, 138, 91, 183, 78, 133, 145, 30, 31, 30, 70, 48, 136, 131, 86, 106, 160, 191, 74, 109, 46, 181, 48, 98, 158, 145, 6, 100, 223, 107, 255, 114, 8, 157, 150, 248, 135, 151, 27, 11, 131, 147, 158, 48, 99, 78, 30, 173, 226, 99, 123, 68, 211, 158, 62, 224, 18, 42, 185, 192, 173, 232, 193, 36, 186, 230, 240, 102, 157, 212, 21, 144, 245 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 242, 202, 78, 80, 32, 223, 174, 106, 76, 101, 206, 7, 87, 23, 15, 255, 164, 172, 130, 75, 45, 144, 149, 167, 162, 95, 118, 104, 48, 174, 37, 233, 50, 250, 93, 133, 152, 145, 153, 30, 54, 93, 149, 249, 162, 208, 43, 54, 130, 202, 232, 41, 225, 142, 44, 1, 192, 133, 152, 160, 179, 62, 219 }, new byte[] { 116, 49, 154, 95, 232, 240, 15, 218, 157, 4, 204, 138, 0, 207, 28, 169, 242, 246, 240, 244, 216, 12, 94, 73, 1, 133, 77, 111, 152, 63, 31, 0, 249, 46, 164, 17, 153, 190, 185, 94, 132, 167, 107, 215, 69, 109, 47, 41, 220, 168, 61, 171, 57, 142, 122, 249, 138, 91, 183, 78, 133, 145, 30, 31, 30, 70, 48, 136, 131, 86, 106, 160, 191, 74, 109, 46, 181, 48, 98, 158, 145, 6, 100, 223, 107, 255, 114, 8, 157, 150, 248, 135, 151, 27, 11, 131, 147, 158, 48, 99, 78, 30, 173, 226, 99, 123, 68, 211, 158, 62, 224, 18, 42, 185, 192, 173, 232, 193, 36, 186, 230, 240, 102, 157, 212, 21, 144, 245 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 242, 202, 78, 80, 32, 223, 174, 106, 76, 101, 206, 7, 87, 23, 15, 255, 164, 172, 130, 75, 45, 144, 149, 167, 162, 95, 118, 104, 48, 174, 37, 233, 50, 250, 93, 133, 152, 145, 153, 30, 54, 93, 149, 249, 162, 208, 43, 54, 130, 202, 232, 41, 225, 142, 44, 1, 192, 133, 152, 160, 179, 62, 219 }, new byte[] { 116, 49, 154, 95, 232, 240, 15, 218, 157, 4, 204, 138, 0, 207, 28, 169, 242, 246, 240, 244, 216, 12, 94, 73, 1, 133, 77, 111, 152, 63, 31, 0, 249, 46, 164, 17, 153, 190, 185, 94, 132, 167, 107, 215, 69, 109, 47, 41, 220, 168, 61, 171, 57, 142, 122, 249, 138, 91, 183, 78, 133, 145, 30, 31, 30, 70, 48, 136, 131, 86, 106, 160, 191, 74, 109, 46, 181, 48, 98, 158, 145, 6, 100, 223, 107, 255, 114, 8, 157, 150, 248, 135, 151, 27, 11, 131, 147, 158, 48, 99, 78, 30, 173, 226, 99, 123, 68, 211, 158, 62, 224, 18, 42, 185, 192, 173, 232, 193, 36, 186, 230, 240, 102, 157, 212, 21, 144, 245 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 242, 202, 78, 80, 32, 223, 174, 106, 76, 101, 206, 7, 87, 23, 15, 255, 164, 172, 130, 75, 45, 144, 149, 167, 162, 95, 118, 104, 48, 174, 37, 233, 50, 250, 93, 133, 152, 145, 153, 30, 54, 93, 149, 249, 162, 208, 43, 54, 130, 202, 232, 41, 225, 142, 44, 1, 192, 133, 152, 160, 179, 62, 219 }, new byte[] { 116, 49, 154, 95, 232, 240, 15, 218, 157, 4, 204, 138, 0, 207, 28, 169, 242, 246, 240, 244, 216, 12, 94, 73, 1, 133, 77, 111, 152, 63, 31, 0, 249, 46, 164, 17, 153, 190, 185, 94, 132, 167, 107, 215, 69, 109, 47, 41, 220, 168, 61, 171, 57, 142, 122, 249, 138, 91, 183, 78, 133, 145, 30, 31, 30, 70, 48, 136, 131, 86, 106, 160, 191, 74, 109, 46, 181, 48, 98, 158, 145, 6, 100, 223, 107, 255, 114, 8, 157, 150, 248, 135, 151, 27, 11, 131, 147, 158, 48, 99, 78, 30, 173, 226, 99, 123, 68, 211, 158, 62, 224, 18, 42, 185, 192, 173, 232, 193, 36, 186, 230, 240, 102, 157, 212, 21, 144, 245 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 242, 202, 78, 80, 32, 223, 174, 106, 76, 101, 206, 7, 87, 23, 15, 255, 164, 172, 130, 75, 45, 144, 149, 167, 162, 95, 118, 104, 48, 174, 37, 233, 50, 250, 93, 133, 152, 145, 153, 30, 54, 93, 149, 249, 162, 208, 43, 54, 130, 202, 232, 41, 225, 142, 44, 1, 192, 133, 152, 160, 179, 62, 219 }, new byte[] { 116, 49, 154, 95, 232, 240, 15, 218, 157, 4, 204, 138, 0, 207, 28, 169, 242, 246, 240, 244, 216, 12, 94, 73, 1, 133, 77, 111, 152, 63, 31, 0, 249, 46, 164, 17, 153, 190, 185, 94, 132, 167, 107, 215, 69, 109, 47, 41, 220, 168, 61, 171, 57, 142, 122, 249, 138, 91, 183, 78, 133, 145, 30, 31, 30, 70, 48, 136, 131, 86, 106, 160, 191, 74, 109, 46, 181, 48, 98, 158, 145, 6, 100, 223, 107, 255, 114, 8, 157, 150, 248, 135, 151, 27, 11, 131, 147, 158, 48, 99, 78, 30, 173, 226, 99, 123, 68, 211, 158, 62, 224, 18, 42, 185, 192, 173, 232, 193, 36, 186, 230, 240, 102, 157, 212, 21, 144, 245 } });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ChosenStaffId",
                table: "Appointments",
                column: "ChosenStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Staff_ChosenStaffId",
                table: "Appointments",
                column: "ChosenStaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Staff_ChosenStaffId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ChosenStaffId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ChosenStaffId",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274), new DateTime(2021, 10, 19, 14, 11, 27, 983, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });
        }
    }
}
