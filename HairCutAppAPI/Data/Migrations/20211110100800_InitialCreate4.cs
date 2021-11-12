using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Notifications",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512), new DateTime(2021, 11, 10, 17, 8, 0, 177, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 32, 1, 109, 107, 29, 232, 85, 61, 76, 103, 218, 93, 48, 162, 221, 227, 161, 48, 56, 217, 253, 213, 101, 169, 145, 11, 47, 10, 71, 22, 125, 30, 155, 49, 59, 203, 63, 128, 117, 84, 173, 127, 141, 255, 100, 96, 150, 143, 109, 214, 86, 150, 12, 223, 247, 59, 239, 167, 186, 234, 234, 206, 92 }, new byte[] { 180, 208, 30, 162, 221, 99, 187, 192, 189, 245, 163, 46, 5, 85, 40, 224, 19, 86, 52, 106, 171, 153, 223, 21, 171, 66, 250, 102, 72, 145, 197, 122, 243, 216, 135, 215, 234, 175, 249, 175, 172, 54, 97, 155, 32, 59, 95, 165, 161, 3, 157, 13, 153, 226, 51, 101, 27, 227, 183, 176, 124, 168, 237, 224, 152, 211, 99, 180, 95, 237, 42, 4, 119, 241, 49, 240, 63, 35, 239, 214, 95, 73, 176, 188, 42, 212, 109, 253, 245, 3, 168, 247, 66, 28, 49, 169, 99, 38, 218, 33, 176, 190, 217, 178, 244, 118, 67, 184, 89, 50, 121, 1, 82, 236, 105, 87, 84, 96, 7, 218, 9, 132, 44, 90, 249, 125, 9, 44 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 32, 1, 109, 107, 29, 232, 85, 61, 76, 103, 218, 93, 48, 162, 221, 227, 161, 48, 56, 217, 253, 213, 101, 169, 145, 11, 47, 10, 71, 22, 125, 30, 155, 49, 59, 203, 63, 128, 117, 84, 173, 127, 141, 255, 100, 96, 150, 143, 109, 214, 86, 150, 12, 223, 247, 59, 239, 167, 186, 234, 234, 206, 92 }, new byte[] { 180, 208, 30, 162, 221, 99, 187, 192, 189, 245, 163, 46, 5, 85, 40, 224, 19, 86, 52, 106, 171, 153, 223, 21, 171, 66, 250, 102, 72, 145, 197, 122, 243, 216, 135, 215, 234, 175, 249, 175, 172, 54, 97, 155, 32, 59, 95, 165, 161, 3, 157, 13, 153, 226, 51, 101, 27, 227, 183, 176, 124, 168, 237, 224, 152, 211, 99, 180, 95, 237, 42, 4, 119, 241, 49, 240, 63, 35, 239, 214, 95, 73, 176, 188, 42, 212, 109, 253, 245, 3, 168, 247, 66, 28, 49, 169, 99, 38, 218, 33, 176, 190, 217, 178, 244, 118, 67, 184, 89, 50, 121, 1, 82, 236, 105, 87, 84, 96, 7, 218, 9, 132, 44, 90, 249, 125, 9, 44 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 32, 1, 109, 107, 29, 232, 85, 61, 76, 103, 218, 93, 48, 162, 221, 227, 161, 48, 56, 217, 253, 213, 101, 169, 145, 11, 47, 10, 71, 22, 125, 30, 155, 49, 59, 203, 63, 128, 117, 84, 173, 127, 141, 255, 100, 96, 150, 143, 109, 214, 86, 150, 12, 223, 247, 59, 239, 167, 186, 234, 234, 206, 92 }, new byte[] { 180, 208, 30, 162, 221, 99, 187, 192, 189, 245, 163, 46, 5, 85, 40, 224, 19, 86, 52, 106, 171, 153, 223, 21, 171, 66, 250, 102, 72, 145, 197, 122, 243, 216, 135, 215, 234, 175, 249, 175, 172, 54, 97, 155, 32, 59, 95, 165, 161, 3, 157, 13, 153, 226, 51, 101, 27, 227, 183, 176, 124, 168, 237, 224, 152, 211, 99, 180, 95, 237, 42, 4, 119, 241, 49, 240, 63, 35, 239, 214, 95, 73, 176, 188, 42, 212, 109, 253, 245, 3, 168, 247, 66, 28, 49, 169, 99, 38, 218, 33, 176, 190, 217, 178, 244, 118, 67, 184, 89, 50, 121, 1, 82, 236, 105, 87, 84, 96, 7, 218, 9, 132, 44, 90, 249, 125, 9, 44 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 32, 1, 109, 107, 29, 232, 85, 61, 76, 103, 218, 93, 48, 162, 221, 227, 161, 48, 56, 217, 253, 213, 101, 169, 145, 11, 47, 10, 71, 22, 125, 30, 155, 49, 59, 203, 63, 128, 117, 84, 173, 127, 141, 255, 100, 96, 150, 143, 109, 214, 86, 150, 12, 223, 247, 59, 239, 167, 186, 234, 234, 206, 92 }, new byte[] { 180, 208, 30, 162, 221, 99, 187, 192, 189, 245, 163, 46, 5, 85, 40, 224, 19, 86, 52, 106, 171, 153, 223, 21, 171, 66, 250, 102, 72, 145, 197, 122, 243, 216, 135, 215, 234, 175, 249, 175, 172, 54, 97, 155, 32, 59, 95, 165, 161, 3, 157, 13, 153, 226, 51, 101, 27, 227, 183, 176, 124, 168, 237, 224, 152, 211, 99, 180, 95, 237, 42, 4, 119, 241, 49, 240, 63, 35, 239, 214, 95, 73, 176, 188, 42, 212, 109, 253, 245, 3, 168, 247, 66, 28, 49, 169, 99, 38, 218, 33, 176, 190, 217, 178, 244, 118, 67, 184, 89, 50, 121, 1, 82, 236, 105, 87, 84, 96, 7, 218, 9, 132, 44, 90, 249, 125, 9, 44 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 32, 1, 109, 107, 29, 232, 85, 61, 76, 103, 218, 93, 48, 162, 221, 227, 161, 48, 56, 217, 253, 213, 101, 169, 145, 11, 47, 10, 71, 22, 125, 30, 155, 49, 59, 203, 63, 128, 117, 84, 173, 127, 141, 255, 100, 96, 150, 143, 109, 214, 86, 150, 12, 223, 247, 59, 239, 167, 186, 234, 234, 206, 92 }, new byte[] { 180, 208, 30, 162, 221, 99, 187, 192, 189, 245, 163, 46, 5, 85, 40, 224, 19, 86, 52, 106, 171, 153, 223, 21, 171, 66, 250, 102, 72, 145, 197, 122, 243, 216, 135, 215, 234, 175, 249, 175, 172, 54, 97, 155, 32, 59, 95, 165, 161, 3, 157, 13, 153, 226, 51, 101, 27, 227, 183, 176, 124, 168, 237, 224, 152, 211, 99, 180, 95, 237, 42, 4, 119, 241, 49, 240, 63, 35, 239, 214, 95, 73, 176, 188, 42, 212, 109, 253, 245, 3, 168, 247, 66, 28, 49, 169, 99, 38, 218, 33, 176, 190, 217, 178, 244, 118, 67, 184, 89, 50, 121, 1, 82, 236, 105, 87, 84, 96, 7, 218, 9, 132, 44, 90, 249, 125, 9, 44 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 32, 1, 109, 107, 29, 232, 85, 61, 76, 103, 218, 93, 48, 162, 221, 227, 161, 48, 56, 217, 253, 213, 101, 169, 145, 11, 47, 10, 71, 22, 125, 30, 155, 49, 59, 203, 63, 128, 117, 84, 173, 127, 141, 255, 100, 96, 150, 143, 109, 214, 86, 150, 12, 223, 247, 59, 239, 167, 186, 234, 234, 206, 92 }, new byte[] { 180, 208, 30, 162, 221, 99, 187, 192, 189, 245, 163, 46, 5, 85, 40, 224, 19, 86, 52, 106, 171, 153, 223, 21, 171, 66, 250, 102, 72, 145, 197, 122, 243, 216, 135, 215, 234, 175, 249, 175, 172, 54, 97, 155, 32, 59, 95, 165, 161, 3, 157, 13, 153, 226, 51, 101, 27, 227, 183, 176, 124, 168, 237, 224, 152, 211, 99, 180, 95, 237, 42, 4, 119, 241, 49, 240, 63, 35, 239, 214, 95, 73, 176, 188, 42, 212, 109, 253, 245, 3, 168, 247, 66, 28, 49, 169, 99, 38, 218, 33, 176, 190, 217, 178, 244, 118, 67, 184, 89, 50, 121, 1, 82, 236, 105, 87, 84, 96, 7, 218, 9, 132, 44, 90, 249, 125, 9, 44 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 32, 1, 109, 107, 29, 232, 85, 61, 76, 103, 218, 93, 48, 162, 221, 227, 161, 48, 56, 217, 253, 213, 101, 169, 145, 11, 47, 10, 71, 22, 125, 30, 155, 49, 59, 203, 63, 128, 117, 84, 173, 127, 141, 255, 100, 96, 150, 143, 109, 214, 86, 150, 12, 223, 247, 59, 239, 167, 186, 234, 234, 206, 92 }, new byte[] { 180, 208, 30, 162, 221, 99, 187, 192, 189, 245, 163, 46, 5, 85, 40, 224, 19, 86, 52, 106, 171, 153, 223, 21, 171, 66, 250, 102, 72, 145, 197, 122, 243, 216, 135, 215, 234, 175, 249, 175, 172, 54, 97, 155, 32, 59, 95, 165, 161, 3, 157, 13, 153, 226, 51, 101, 27, 227, 183, 176, 124, 168, 237, 224, 152, 211, 99, 180, 95, 237, 42, 4, 119, 241, 49, 240, 63, 35, 239, 214, 95, 73, 176, 188, 42, 212, 109, 253, 245, 3, 168, 247, 66, 28, 49, 169, 99, 38, 218, 33, 176, 190, 217, 178, 244, 118, 67, 184, 89, 50, 121, 1, 82, 236, 105, 87, 84, 96, 7, 218, 9, 132, 44, 90, 249, 125, 9, 44 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 32, 1, 109, 107, 29, 232, 85, 61, 76, 103, 218, 93, 48, 162, 221, 227, 161, 48, 56, 217, 253, 213, 101, 169, 145, 11, 47, 10, 71, 22, 125, 30, 155, 49, 59, 203, 63, 128, 117, 84, 173, 127, 141, 255, 100, 96, 150, 143, 109, 214, 86, 150, 12, 223, 247, 59, 239, 167, 186, 234, 234, 206, 92 }, new byte[] { 180, 208, 30, 162, 221, 99, 187, 192, 189, 245, 163, 46, 5, 85, 40, 224, 19, 86, 52, 106, 171, 153, 223, 21, 171, 66, 250, 102, 72, 145, 197, 122, 243, 216, 135, 215, 234, 175, 249, 175, 172, 54, 97, 155, 32, 59, 95, 165, 161, 3, 157, 13, 153, 226, 51, 101, 27, 227, 183, 176, 124, 168, 237, 224, 152, 211, 99, 180, 95, 237, 42, 4, 119, 241, 49, 240, 63, 35, 239, 214, 95, 73, 176, 188, 42, 212, 109, 253, 245, 3, 168, 247, 66, 28, 49, 169, 99, 38, 218, 33, 176, 190, 217, 178, 244, 118, 67, 184, 89, 50, 121, 1, 82, 236, 105, 87, 84, 96, 7, 218, 9, 132, 44, 90, 249, 125, 9, 44 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 32, 1, 109, 107, 29, 232, 85, 61, 76, 103, 218, 93, 48, 162, 221, 227, 161, 48, 56, 217, 253, 213, 101, 169, 145, 11, 47, 10, 71, 22, 125, 30, 155, 49, 59, 203, 63, 128, 117, 84, 173, 127, 141, 255, 100, 96, 150, 143, 109, 214, 86, 150, 12, 223, 247, 59, 239, 167, 186, 234, 234, 206, 92 }, new byte[] { 180, 208, 30, 162, 221, 99, 187, 192, 189, 245, 163, 46, 5, 85, 40, 224, 19, 86, 52, 106, 171, 153, 223, 21, 171, 66, 250, 102, 72, 145, 197, 122, 243, 216, 135, 215, 234, 175, 249, 175, 172, 54, 97, 155, 32, 59, 95, 165, 161, 3, 157, 13, 153, 226, 51, 101, 27, 227, 183, 176, 124, 168, 237, 224, 152, 211, 99, 180, 95, 237, 42, 4, 119, 241, 49, 240, 63, 35, 239, 214, 95, 73, 176, 188, 42, 212, 109, 253, 245, 3, 168, 247, 66, 28, 49, 169, 99, 38, 218, 33, 176, 190, 217, 178, 244, 118, 67, 184, 89, 50, 121, 1, 82, 236, 105, 87, 84, 96, 7, 218, 9, 132, 44, 90, 249, 125, 9, 44 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

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
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 233, 15, 2, 190, 151, 88, 118, 65, 87, 21, 192, 87, 98, 187, 122, 114, 88, 58, 135, 247, 110, 239, 214, 186, 25, 45, 230, 50, 111, 153, 188, 151, 230, 162, 65, 187, 112, 65, 255, 205, 123, 176, 45, 10, 22, 74, 173, 85, 159, 75, 86, 241, 166, 90, 122, 85, 236, 3, 219, 28, 242, 33, 108 }, new byte[] { 91, 133, 99, 188, 91, 162, 41, 19, 221, 62, 141, 167, 173, 102, 56, 36, 222, 141, 236, 87, 7, 25, 139, 59, 110, 181, 39, 243, 222, 41, 31, 96, 161, 47, 89, 88, 236, 91, 210, 191, 228, 252, 72, 168, 164, 150, 158, 216, 246, 251, 100, 16, 210, 238, 69, 67, 199, 0, 12, 235, 86, 210, 89, 85, 206, 164, 146, 51, 96, 33, 194, 94, 214, 236, 252, 31, 36, 41, 38, 95, 137, 96, 202, 154, 217, 190, 166, 167, 71, 204, 204, 50, 254, 140, 2, 181, 10, 110, 157, 226, 9, 138, 62, 224, 229, 211, 189, 208, 94, 197, 66, 119, 97, 125, 50, 6, 144, 72, 247, 94, 39, 26, 113, 253, 101, 201, 93, 224 } });
        }
    }
}
