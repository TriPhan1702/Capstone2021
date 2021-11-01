using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Salons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorUserId = table.Column<int>(type: "int", nullable: false),
                    Tittle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Users_AuthorUserId",
                        column: x => x.AuthorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 11, 1, 20, 53, 42, 795, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 47, 226, 54, 178, 30, 250, 193, 249, 143, 120, 170, 36, 153, 123, 123, 237, 243, 96, 158, 187, 173, 85, 39, 123, 76, 131, 116, 138, 47, 157, 21, 251, 34, 139, 200, 93, 242, 210, 40, 45, 211, 215, 225, 41, 115, 156, 159, 240, 108, 92, 84, 68, 28, 224, 191, 195, 15, 204, 253, 75, 128, 81, 239, 174 }, new byte[] { 254, 123, 123, 100, 63, 112, 148, 45, 108, 214, 43, 94, 159, 87, 124, 134, 155, 1, 88, 30, 244, 47, 253, 0, 22, 39, 29, 58, 16, 109, 218, 58, 198, 23, 104, 191, 222, 5, 126, 45, 177, 251, 64, 130, 150, 68, 81, 196, 13, 58, 246, 17, 40, 179, 46, 133, 1, 111, 67, 250, 114, 76, 4, 54, 13, 119, 128, 130, 52, 238, 171, 40, 226, 43, 114, 206, 237, 215, 7, 0, 148, 171, 148, 93, 154, 179, 31, 92, 40, 173, 211, 76, 93, 15, 92, 201, 126, 126, 44, 77, 233, 50, 48, 229, 86, 211, 149, 145, 241, 246, 114, 2, 213, 75, 238, 114, 102, 197, 176, 173, 153, 62, 249, 191, 64, 145, 162, 156 }, "active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 47, 226, 54, 178, 30, 250, 193, 249, 143, 120, 170, 36, 153, 123, 123, 237, 243, 96, 158, 187, 173, 85, 39, 123, 76, 131, 116, 138, 47, 157, 21, 251, 34, 139, 200, 93, 242, 210, 40, 45, 211, 215, 225, 41, 115, 156, 159, 240, 108, 92, 84, 68, 28, 224, 191, 195, 15, 204, 253, 75, 128, 81, 239, 174 }, new byte[] { 254, 123, 123, 100, 63, 112, 148, 45, 108, 214, 43, 94, 159, 87, 124, 134, 155, 1, 88, 30, 244, 47, 253, 0, 22, 39, 29, 58, 16, 109, 218, 58, 198, 23, 104, 191, 222, 5, 126, 45, 177, 251, 64, 130, 150, 68, 81, 196, 13, 58, 246, 17, 40, 179, 46, 133, 1, 111, 67, 250, 114, 76, 4, 54, 13, 119, 128, 130, 52, 238, 171, 40, 226, 43, 114, 206, 237, 215, 7, 0, 148, 171, 148, 93, 154, 179, 31, 92, 40, 173, 211, 76, 93, 15, 92, 201, 126, 126, 44, 77, 233, 50, 48, 229, 86, 211, 149, 145, 241, 246, 114, 2, 213, 75, 238, 114, 102, 197, 176, 173, 153, 62, 249, 191, 64, 145, 162, 156 }, "active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 47, 226, 54, 178, 30, 250, 193, 249, 143, 120, 170, 36, 153, 123, 123, 237, 243, 96, 158, 187, 173, 85, 39, 123, 76, 131, 116, 138, 47, 157, 21, 251, 34, 139, 200, 93, 242, 210, 40, 45, 211, 215, 225, 41, 115, 156, 159, 240, 108, 92, 84, 68, 28, 224, 191, 195, 15, 204, 253, 75, 128, 81, 239, 174 }, new byte[] { 254, 123, 123, 100, 63, 112, 148, 45, 108, 214, 43, 94, 159, 87, 124, 134, 155, 1, 88, 30, 244, 47, 253, 0, 22, 39, 29, 58, 16, 109, 218, 58, 198, 23, 104, 191, 222, 5, 126, 45, 177, 251, 64, 130, 150, 68, 81, 196, 13, 58, 246, 17, 40, 179, 46, 133, 1, 111, 67, 250, 114, 76, 4, 54, 13, 119, 128, 130, 52, 238, 171, 40, 226, 43, 114, 206, 237, 215, 7, 0, 148, 171, 148, 93, 154, 179, 31, 92, 40, 173, 211, 76, 93, 15, 92, 201, 126, 126, 44, 77, 233, 50, 48, 229, 86, 211, 149, 145, 241, 246, 114, 2, 213, 75, 238, 114, 102, 197, 176, 173, 153, 62, 249, 191, 64, 145, 162, 156 }, "active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 47, 226, 54, 178, 30, 250, 193, 249, 143, 120, 170, 36, 153, 123, 123, 237, 243, 96, 158, 187, 173, 85, 39, 123, 76, 131, 116, 138, 47, 157, 21, 251, 34, 139, 200, 93, 242, 210, 40, 45, 211, 215, 225, 41, 115, 156, 159, 240, 108, 92, 84, 68, 28, 224, 191, 195, 15, 204, 253, 75, 128, 81, 239, 174 }, new byte[] { 254, 123, 123, 100, 63, 112, 148, 45, 108, 214, 43, 94, 159, 87, 124, 134, 155, 1, 88, 30, 244, 47, 253, 0, 22, 39, 29, 58, 16, 109, 218, 58, 198, 23, 104, 191, 222, 5, 126, 45, 177, 251, 64, 130, 150, 68, 81, 196, 13, 58, 246, 17, 40, 179, 46, 133, 1, 111, 67, 250, 114, 76, 4, 54, 13, 119, 128, 130, 52, 238, 171, 40, 226, 43, 114, 206, 237, 215, 7, 0, 148, 171, 148, 93, 154, 179, 31, 92, 40, 173, 211, 76, 93, 15, 92, 201, 126, 126, 44, 77, 233, 50, 48, 229, 86, 211, 149, 145, 241, 246, 114, 2, 213, 75, 238, 114, 102, 197, 176, 173, 153, 62, 249, 191, 64, 145, 162, 156 }, "active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 47, 226, 54, 178, 30, 250, 193, 249, 143, 120, 170, 36, 153, 123, 123, 237, 243, 96, 158, 187, 173, 85, 39, 123, 76, 131, 116, 138, 47, 157, 21, 251, 34, 139, 200, 93, 242, 210, 40, 45, 211, 215, 225, 41, 115, 156, 159, 240, 108, 92, 84, 68, 28, 224, 191, 195, 15, 204, 253, 75, 128, 81, 239, 174 }, new byte[] { 254, 123, 123, 100, 63, 112, 148, 45, 108, 214, 43, 94, 159, 87, 124, 134, 155, 1, 88, 30, 244, 47, 253, 0, 22, 39, 29, 58, 16, 109, 218, 58, 198, 23, 104, 191, 222, 5, 126, 45, 177, 251, 64, 130, 150, 68, 81, 196, 13, 58, 246, 17, 40, 179, 46, 133, 1, 111, 67, 250, 114, 76, 4, 54, 13, 119, 128, 130, 52, 238, 171, 40, 226, 43, 114, 206, 237, 215, 7, 0, 148, 171, 148, 93, 154, 179, 31, 92, 40, 173, 211, 76, 93, 15, 92, 201, 126, 126, 44, 77, 233, 50, 48, 229, 86, 211, 149, 145, 241, 246, 114, 2, 213, 75, 238, 114, 102, 197, 176, 173, 153, 62, 249, 191, 64, 145, 162, 156 }, "active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 47, 226, 54, 178, 30, 250, 193, 249, 143, 120, 170, 36, 153, 123, 123, 237, 243, 96, 158, 187, 173, 85, 39, 123, 76, 131, 116, 138, 47, 157, 21, 251, 34, 139, 200, 93, 242, 210, 40, 45, 211, 215, 225, 41, 115, 156, 159, 240, 108, 92, 84, 68, 28, 224, 191, 195, 15, 204, 253, 75, 128, 81, 239, 174 }, new byte[] { 254, 123, 123, 100, 63, 112, 148, 45, 108, 214, 43, 94, 159, 87, 124, 134, 155, 1, 88, 30, 244, 47, 253, 0, 22, 39, 29, 58, 16, 109, 218, 58, 198, 23, 104, 191, 222, 5, 126, 45, 177, 251, 64, 130, 150, 68, 81, 196, 13, 58, 246, 17, 40, 179, 46, 133, 1, 111, 67, 250, 114, 76, 4, 54, 13, 119, 128, 130, 52, 238, 171, 40, 226, 43, 114, 206, 237, 215, 7, 0, 148, 171, 148, 93, 154, 179, 31, 92, 40, 173, 211, 76, 93, 15, 92, 201, 126, 126, 44, 77, 233, 50, 48, 229, 86, 211, 149, 145, 241, 246, 114, 2, 213, 75, 238, 114, 102, 197, 176, 173, 153, 62, 249, 191, 64, 145, 162, 156 }, "active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 47, 226, 54, 178, 30, 250, 193, 249, 143, 120, 170, 36, 153, 123, 123, 237, 243, 96, 158, 187, 173, 85, 39, 123, 76, 131, 116, 138, 47, 157, 21, 251, 34, 139, 200, 93, 242, 210, 40, 45, 211, 215, 225, 41, 115, 156, 159, 240, 108, 92, 84, 68, 28, 224, 191, 195, 15, 204, 253, 75, 128, 81, 239, 174 }, new byte[] { 254, 123, 123, 100, 63, 112, 148, 45, 108, 214, 43, 94, 159, 87, 124, 134, 155, 1, 88, 30, 244, 47, 253, 0, 22, 39, 29, 58, 16, 109, 218, 58, 198, 23, 104, 191, 222, 5, 126, 45, 177, 251, 64, 130, 150, 68, 81, 196, 13, 58, 246, 17, 40, 179, 46, 133, 1, 111, 67, 250, 114, 76, 4, 54, 13, 119, 128, 130, 52, 238, 171, 40, 226, 43, 114, 206, 237, 215, 7, 0, 148, 171, 148, 93, 154, 179, 31, 92, 40, 173, 211, 76, 93, 15, 92, 201, 126, 126, 44, 77, 233, 50, 48, 229, 86, 211, 149, 145, 241, 246, 114, 2, 213, 75, 238, 114, 102, 197, 176, 173, 153, 62, 249, 191, 64, 145, 162, 156 }, "active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 47, 226, 54, 178, 30, 250, 193, 249, 143, 120, 170, 36, 153, 123, 123, 237, 243, 96, 158, 187, 173, 85, 39, 123, 76, 131, 116, 138, 47, 157, 21, 251, 34, 139, 200, 93, 242, 210, 40, 45, 211, 215, 225, 41, 115, 156, 159, 240, 108, 92, 84, 68, 28, 224, 191, 195, 15, 204, 253, 75, 128, 81, 239, 174 }, new byte[] { 254, 123, 123, 100, 63, 112, 148, 45, 108, 214, 43, 94, 159, 87, 124, 134, 155, 1, 88, 30, 244, 47, 253, 0, 22, 39, 29, 58, 16, 109, 218, 58, 198, 23, 104, 191, 222, 5, 126, 45, 177, 251, 64, 130, 150, 68, 81, 196, 13, 58, 246, 17, 40, 179, 46, 133, 1, 111, 67, 250, 114, 76, 4, 54, 13, 119, 128, 130, 52, 238, 171, 40, 226, 43, 114, 206, 237, 215, 7, 0, 148, 171, 148, 93, 154, 179, 31, 92, 40, 173, 211, 76, 93, 15, 92, 201, 126, 126, 44, 77, 233, 50, 48, 229, 86, 211, 149, 145, 241, 246, 114, 2, 213, 75, 238, 114, 102, 197, 176, 173, 153, 62, 249, 191, 64, 145, 162, 156 }, "active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 47, 226, 54, 178, 30, 250, 193, 249, 143, 120, 170, 36, 153, 123, 123, 237, 243, 96, 158, 187, 173, 85, 39, 123, 76, 131, 116, 138, 47, 157, 21, 251, 34, 139, 200, 93, 242, 210, 40, 45, 211, 215, 225, 41, 115, 156, 159, 240, 108, 92, 84, 68, 28, 224, 191, 195, 15, 204, 253, 75, 128, 81, 239, 174 }, new byte[] { 254, 123, 123, 100, 63, 112, 148, 45, 108, 214, 43, 94, 159, 87, 124, 134, 155, 1, 88, 30, 244, 47, 253, 0, 22, 39, 29, 58, 16, 109, 218, 58, 198, 23, 104, 191, 222, 5, 126, 45, 177, 251, 64, 130, 150, 68, 81, 196, 13, 58, 246, 17, 40, 179, 46, 133, 1, 111, 67, 250, 114, 76, 4, 54, 13, 119, 128, 130, 52, 238, 171, 40, 226, 43, 114, 206, 237, 215, 7, 0, 148, 171, 148, 93, 154, 179, 31, 92, 40, 173, 211, 76, 93, 15, 92, 201, 126, 126, 44, 77, 233, 50, 48, 229, 86, 211, 149, 145, 241, 246, 114, 2, 213, 75, 238, 114, 102, 197, 176, 173, 153, 62, 249, 191, 64, 145, 162, 156 }, "active" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorUserId",
                table: "Articles",
                column: "AuthorUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Salons");

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
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 }, "Active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 }, "Active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 }, "Active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 }, "Active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 }, "Active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 }, "Active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 }, "Active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 }, "Active" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new byte[] { 175, 116, 240, 90, 252, 46, 190, 86, 131, 197, 50, 247, 226, 231, 116, 238, 103, 67, 84, 38, 128, 110, 109, 220, 3, 88, 199, 253, 248, 226, 8, 1, 232, 113, 244, 230, 102, 60, 57, 187, 138, 122, 121, 21, 61, 193, 160, 59, 80, 199, 165, 19, 42, 57, 134, 37, 61, 167, 241, 68, 55, 34, 201, 207 }, new byte[] { 114, 73, 164, 86, 190, 61, 57, 97, 217, 97, 81, 50, 131, 242, 107, 47, 224, 38, 20, 135, 113, 90, 129, 116, 138, 95, 66, 228, 206, 204, 86, 224, 31, 231, 205, 142, 41, 247, 13, 41, 133, 36, 200, 99, 95, 204, 241, 232, 177, 188, 94, 6, 221, 66, 86, 13, 206, 50, 11, 36, 10, 50, 54, 69, 32, 29, 238, 18, 144, 131, 227, 81, 205, 123, 57, 212, 24, 169, 155, 68, 87, 242, 89, 210, 229, 237, 245, 25, 128, 17, 21, 74, 116, 100, 174, 99, 131, 213, 13, 240, 92, 32, 215, 206, 212, 85, 167, 202, 118, 105, 223, 136, 237, 54, 167, 108, 157, 12, 238, 104, 138, 26, 149, 196, 204, 83, 155, 239 }, "Active" });
        }
    }
}
