using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 11, 6, 16, 12, 27, 719, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { "https://thispersondoesnotexist.com/image", new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { "https://thispersondoesnotexist.com/image", new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { "https://thispersondoesnotexist.com/image", new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { "https://thispersondoesnotexist.com/image", new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { "https://thispersondoesnotexist.com/image", new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { "https://thispersondoesnotexist.com/image", new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { "https://thispersondoesnotexist.com/image", new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { "https://thispersondoesnotexist.com/image", new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { "https://thispersondoesnotexist.com/image", new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078), new DateTime(2021, 11, 6, 7, 31, 16, 688, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvatarUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });
        }
    }
}
