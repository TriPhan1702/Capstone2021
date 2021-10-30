using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_AuthorId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 10, 30, 11, 36, 28, 403, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_AuthorId",
                table: "Reviews",
                column: "AuthorId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_AuthorId",
                table: "Reviews");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 10, 28, 19, 13, 54, 63, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 238, 35, 69, 167, 109, 72, 116, 41, 65, 202, 176, 83, 91, 30, 218, 64, 152, 107, 2, 130, 30, 49, 105, 31, 246, 62, 234, 183, 7, 58, 36, 97, 41, 175, 26, 128, 82, 138, 196, 117, 206, 12, 191, 72, 123, 19, 169, 145, 150, 231, 157, 184, 120, 228, 248, 140, 77, 192, 29, 86, 251, 22, 204 }, new byte[] { 203, 226, 36, 144, 160, 140, 190, 144, 32, 227, 216, 246, 44, 55, 1, 197, 99, 198, 152, 241, 131, 77, 120, 140, 28, 233, 161, 167, 17, 23, 53, 118, 150, 52, 71, 123, 30, 16, 160, 222, 93, 144, 231, 96, 167, 229, 79, 24, 37, 212, 22, 25, 103, 165, 159, 46, 193, 240, 82, 48, 96, 3, 85, 94, 219, 116, 147, 143, 142, 149, 32, 204, 165, 107, 69, 101, 243, 13, 41, 58, 16, 88, 216, 154, 198, 233, 10, 162, 246, 162, 52, 17, 147, 138, 249, 73, 20, 74, 117, 53, 160, 172, 97, 122, 38, 168, 11, 84, 146, 17, 71, 221, 202, 61, 73, 123, 162, 120, 172, 127, 152, 57, 219, 132, 100, 149, 170, 86 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 238, 35, 69, 167, 109, 72, 116, 41, 65, 202, 176, 83, 91, 30, 218, 64, 152, 107, 2, 130, 30, 49, 105, 31, 246, 62, 234, 183, 7, 58, 36, 97, 41, 175, 26, 128, 82, 138, 196, 117, 206, 12, 191, 72, 123, 19, 169, 145, 150, 231, 157, 184, 120, 228, 248, 140, 77, 192, 29, 86, 251, 22, 204 }, new byte[] { 203, 226, 36, 144, 160, 140, 190, 144, 32, 227, 216, 246, 44, 55, 1, 197, 99, 198, 152, 241, 131, 77, 120, 140, 28, 233, 161, 167, 17, 23, 53, 118, 150, 52, 71, 123, 30, 16, 160, 222, 93, 144, 231, 96, 167, 229, 79, 24, 37, 212, 22, 25, 103, 165, 159, 46, 193, 240, 82, 48, 96, 3, 85, 94, 219, 116, 147, 143, 142, 149, 32, 204, 165, 107, 69, 101, 243, 13, 41, 58, 16, 88, 216, 154, 198, 233, 10, 162, 246, 162, 52, 17, 147, 138, 249, 73, 20, 74, 117, 53, 160, 172, 97, 122, 38, 168, 11, 84, 146, 17, 71, 221, 202, 61, 73, 123, 162, 120, 172, 127, 152, 57, 219, 132, 100, 149, 170, 86 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 238, 35, 69, 167, 109, 72, 116, 41, 65, 202, 176, 83, 91, 30, 218, 64, 152, 107, 2, 130, 30, 49, 105, 31, 246, 62, 234, 183, 7, 58, 36, 97, 41, 175, 26, 128, 82, 138, 196, 117, 206, 12, 191, 72, 123, 19, 169, 145, 150, 231, 157, 184, 120, 228, 248, 140, 77, 192, 29, 86, 251, 22, 204 }, new byte[] { 203, 226, 36, 144, 160, 140, 190, 144, 32, 227, 216, 246, 44, 55, 1, 197, 99, 198, 152, 241, 131, 77, 120, 140, 28, 233, 161, 167, 17, 23, 53, 118, 150, 52, 71, 123, 30, 16, 160, 222, 93, 144, 231, 96, 167, 229, 79, 24, 37, 212, 22, 25, 103, 165, 159, 46, 193, 240, 82, 48, 96, 3, 85, 94, 219, 116, 147, 143, 142, 149, 32, 204, 165, 107, 69, 101, 243, 13, 41, 58, 16, 88, 216, 154, 198, 233, 10, 162, 246, 162, 52, 17, 147, 138, 249, 73, 20, 74, 117, 53, 160, 172, 97, 122, 38, 168, 11, 84, 146, 17, 71, 221, 202, 61, 73, 123, 162, 120, 172, 127, 152, 57, 219, 132, 100, 149, 170, 86 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 238, 35, 69, 167, 109, 72, 116, 41, 65, 202, 176, 83, 91, 30, 218, 64, 152, 107, 2, 130, 30, 49, 105, 31, 246, 62, 234, 183, 7, 58, 36, 97, 41, 175, 26, 128, 82, 138, 196, 117, 206, 12, 191, 72, 123, 19, 169, 145, 150, 231, 157, 184, 120, 228, 248, 140, 77, 192, 29, 86, 251, 22, 204 }, new byte[] { 203, 226, 36, 144, 160, 140, 190, 144, 32, 227, 216, 246, 44, 55, 1, 197, 99, 198, 152, 241, 131, 77, 120, 140, 28, 233, 161, 167, 17, 23, 53, 118, 150, 52, 71, 123, 30, 16, 160, 222, 93, 144, 231, 96, 167, 229, 79, 24, 37, 212, 22, 25, 103, 165, 159, 46, 193, 240, 82, 48, 96, 3, 85, 94, 219, 116, 147, 143, 142, 149, 32, 204, 165, 107, 69, 101, 243, 13, 41, 58, 16, 88, 216, 154, 198, 233, 10, 162, 246, 162, 52, 17, 147, 138, 249, 73, 20, 74, 117, 53, 160, 172, 97, 122, 38, 168, 11, 84, 146, 17, 71, 221, 202, 61, 73, 123, 162, 120, 172, 127, 152, 57, 219, 132, 100, 149, 170, 86 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 238, 35, 69, 167, 109, 72, 116, 41, 65, 202, 176, 83, 91, 30, 218, 64, 152, 107, 2, 130, 30, 49, 105, 31, 246, 62, 234, 183, 7, 58, 36, 97, 41, 175, 26, 128, 82, 138, 196, 117, 206, 12, 191, 72, 123, 19, 169, 145, 150, 231, 157, 184, 120, 228, 248, 140, 77, 192, 29, 86, 251, 22, 204 }, new byte[] { 203, 226, 36, 144, 160, 140, 190, 144, 32, 227, 216, 246, 44, 55, 1, 197, 99, 198, 152, 241, 131, 77, 120, 140, 28, 233, 161, 167, 17, 23, 53, 118, 150, 52, 71, 123, 30, 16, 160, 222, 93, 144, 231, 96, 167, 229, 79, 24, 37, 212, 22, 25, 103, 165, 159, 46, 193, 240, 82, 48, 96, 3, 85, 94, 219, 116, 147, 143, 142, 149, 32, 204, 165, 107, 69, 101, 243, 13, 41, 58, 16, 88, 216, 154, 198, 233, 10, 162, 246, 162, 52, 17, 147, 138, 249, 73, 20, 74, 117, 53, 160, 172, 97, 122, 38, 168, 11, 84, 146, 17, 71, 221, 202, 61, 73, 123, 162, 120, 172, 127, 152, 57, 219, 132, 100, 149, 170, 86 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 238, 35, 69, 167, 109, 72, 116, 41, 65, 202, 176, 83, 91, 30, 218, 64, 152, 107, 2, 130, 30, 49, 105, 31, 246, 62, 234, 183, 7, 58, 36, 97, 41, 175, 26, 128, 82, 138, 196, 117, 206, 12, 191, 72, 123, 19, 169, 145, 150, 231, 157, 184, 120, 228, 248, 140, 77, 192, 29, 86, 251, 22, 204 }, new byte[] { 203, 226, 36, 144, 160, 140, 190, 144, 32, 227, 216, 246, 44, 55, 1, 197, 99, 198, 152, 241, 131, 77, 120, 140, 28, 233, 161, 167, 17, 23, 53, 118, 150, 52, 71, 123, 30, 16, 160, 222, 93, 144, 231, 96, 167, 229, 79, 24, 37, 212, 22, 25, 103, 165, 159, 46, 193, 240, 82, 48, 96, 3, 85, 94, 219, 116, 147, 143, 142, 149, 32, 204, 165, 107, 69, 101, 243, 13, 41, 58, 16, 88, 216, 154, 198, 233, 10, 162, 246, 162, 52, 17, 147, 138, 249, 73, 20, 74, 117, 53, 160, 172, 97, 122, 38, 168, 11, 84, 146, 17, 71, 221, 202, 61, 73, 123, 162, 120, 172, 127, 152, 57, 219, 132, 100, 149, 170, 86 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 238, 35, 69, 167, 109, 72, 116, 41, 65, 202, 176, 83, 91, 30, 218, 64, 152, 107, 2, 130, 30, 49, 105, 31, 246, 62, 234, 183, 7, 58, 36, 97, 41, 175, 26, 128, 82, 138, 196, 117, 206, 12, 191, 72, 123, 19, 169, 145, 150, 231, 157, 184, 120, 228, 248, 140, 77, 192, 29, 86, 251, 22, 204 }, new byte[] { 203, 226, 36, 144, 160, 140, 190, 144, 32, 227, 216, 246, 44, 55, 1, 197, 99, 198, 152, 241, 131, 77, 120, 140, 28, 233, 161, 167, 17, 23, 53, 118, 150, 52, 71, 123, 30, 16, 160, 222, 93, 144, 231, 96, 167, 229, 79, 24, 37, 212, 22, 25, 103, 165, 159, 46, 193, 240, 82, 48, 96, 3, 85, 94, 219, 116, 147, 143, 142, 149, 32, 204, 165, 107, 69, 101, 243, 13, 41, 58, 16, 88, 216, 154, 198, 233, 10, 162, 246, 162, 52, 17, 147, 138, 249, 73, 20, 74, 117, 53, 160, 172, 97, 122, 38, 168, 11, 84, 146, 17, 71, 221, 202, 61, 73, 123, 162, 120, 172, 127, 152, 57, 219, 132, 100, 149, 170, 86 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 238, 35, 69, 167, 109, 72, 116, 41, 65, 202, 176, 83, 91, 30, 218, 64, 152, 107, 2, 130, 30, 49, 105, 31, 246, 62, 234, 183, 7, 58, 36, 97, 41, 175, 26, 128, 82, 138, 196, 117, 206, 12, 191, 72, 123, 19, 169, 145, 150, 231, 157, 184, 120, 228, 248, 140, 77, 192, 29, 86, 251, 22, 204 }, new byte[] { 203, 226, 36, 144, 160, 140, 190, 144, 32, 227, 216, 246, 44, 55, 1, 197, 99, 198, 152, 241, 131, 77, 120, 140, 28, 233, 161, 167, 17, 23, 53, 118, 150, 52, 71, 123, 30, 16, 160, 222, 93, 144, 231, 96, 167, 229, 79, 24, 37, 212, 22, 25, 103, 165, 159, 46, 193, 240, 82, 48, 96, 3, 85, 94, 219, 116, 147, 143, 142, 149, 32, 204, 165, 107, 69, 101, 243, 13, 41, 58, 16, 88, 216, 154, 198, 233, 10, 162, 246, 162, 52, 17, 147, 138, 249, 73, 20, 74, 117, 53, 160, 172, 97, 122, 38, 168, 11, 84, 146, 17, 71, 221, 202, 61, 73, 123, 162, 120, 172, 127, 152, 57, 219, 132, 100, 149, 170, 86 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 238, 35, 69, 167, 109, 72, 116, 41, 65, 202, 176, 83, 91, 30, 218, 64, 152, 107, 2, 130, 30, 49, 105, 31, 246, 62, 234, 183, 7, 58, 36, 97, 41, 175, 26, 128, 82, 138, 196, 117, 206, 12, 191, 72, 123, 19, 169, 145, 150, 231, 157, 184, 120, 228, 248, 140, 77, 192, 29, 86, 251, 22, 204 }, new byte[] { 203, 226, 36, 144, 160, 140, 190, 144, 32, 227, 216, 246, 44, 55, 1, 197, 99, 198, 152, 241, 131, 77, 120, 140, 28, 233, 161, 167, 17, 23, 53, 118, 150, 52, 71, 123, 30, 16, 160, 222, 93, 144, 231, 96, 167, 229, 79, 24, 37, 212, 22, 25, 103, 165, 159, 46, 193, 240, 82, 48, 96, 3, 85, 94, 219, 116, 147, 143, 142, 149, 32, 204, 165, 107, 69, 101, 243, 13, 41, 58, 16, 88, 216, 154, 198, 233, 10, 162, 246, 162, 52, 17, 147, 138, 249, 73, 20, 74, 117, 53, 160, 172, 97, 122, 38, 168, 11, 84, 146, 17, 71, 221, 202, 61, 73, 123, 162, 120, 172, 127, 152, 57, 219, 132, 100, 149, 170, 86 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_AuthorId",
                table: "Reviews",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
