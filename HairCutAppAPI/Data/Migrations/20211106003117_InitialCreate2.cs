using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Devices_UserId",
                table: "Devices");

            migrationBuilder.AddColumn<bool>(
                name: "HasAutoSchedule",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 86, 137, 136, 87, 47, 14, 237, 109, 113, 8, 164, 180, 181, 24, 237, 228, 169, 141, 16, 184, 217, 247, 146, 252, 103, 229, 67, 48, 201, 94, 118, 220, 211, 51, 60, 93, 138, 4, 46, 65, 1, 71, 181, 186, 9, 80, 94, 121, 55, 156, 225, 31, 6, 164, 192, 137, 77, 63, 210, 29, 105, 143, 143 }, new byte[] { 82, 238, 177, 15, 8, 198, 125, 177, 115, 115, 7, 21, 10, 148, 173, 254, 205, 198, 97, 226, 244, 96, 66, 243, 19, 111, 23, 117, 139, 109, 156, 121, 193, 231, 168, 41, 118, 177, 178, 129, 254, 79, 112, 6, 48, 223, 5, 140, 149, 72, 163, 173, 219, 201, 38, 91, 190, 28, 195, 228, 35, 29, 247, 195, 0, 106, 189, 38, 74, 208, 249, 166, 96, 97, 67, 228, 239, 194, 157, 207, 229, 226, 160, 79, 129, 144, 157, 47, 0, 21, 247, 181, 128, 201, 3, 115, 167, 100, 250, 49, 247, 170, 116, 87, 191, 220, 96, 157, 132, 165, 96, 223, 87, 135, 246, 172, 193, 175, 139, 253, 5, 161, 6, 129, 206, 61, 131, 231 } });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AppointmentId",
                table: "Notifications",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Devices_UserId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "HasAutoSchedule",
                table: "Staff");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356), new DateTime(2021, 11, 4, 17, 59, 51, 477, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 99, 96, 162, 95, 216, 9, 233, 239, 210, 214, 247, 78, 226, 117, 52, 244, 157, 50, 93, 136, 131, 240, 71, 238, 146, 239, 211, 160, 195, 43, 143, 200, 201, 9, 205, 200, 63, 128, 1, 120, 189, 110, 146, 80, 149, 90, 44, 231, 106, 97, 163, 136, 178, 186, 66, 17, 4, 173, 90, 80, 30, 247, 251 }, new byte[] { 183, 148, 65, 27, 79, 19, 66, 249, 79, 112, 205, 227, 215, 31, 12, 230, 42, 57, 72, 244, 249, 48, 196, 34, 197, 29, 239, 195, 66, 82, 72, 109, 184, 106, 42, 25, 54, 67, 95, 149, 209, 170, 207, 79, 46, 9, 76, 105, 246, 169, 90, 21, 72, 28, 243, 15, 105, 118, 170, 81, 209, 39, 138, 76, 200, 84, 96, 63, 127, 74, 51, 243, 173, 168, 247, 67, 71, 6, 191, 148, 93, 64, 190, 63, 68, 13, 109, 239, 159, 152, 38, 77, 50, 43, 214, 29, 4, 233, 152, 32, 186, 251, 65, 7, 63, 153, 96, 32, 58, 229, 0, 107, 196, 187, 154, 250, 34, 238, 215, 201, 65, 99, 55, 31, 130, 115, 74, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 99, 96, 162, 95, 216, 9, 233, 239, 210, 214, 247, 78, 226, 117, 52, 244, 157, 50, 93, 136, 131, 240, 71, 238, 146, 239, 211, 160, 195, 43, 143, 200, 201, 9, 205, 200, 63, 128, 1, 120, 189, 110, 146, 80, 149, 90, 44, 231, 106, 97, 163, 136, 178, 186, 66, 17, 4, 173, 90, 80, 30, 247, 251 }, new byte[] { 183, 148, 65, 27, 79, 19, 66, 249, 79, 112, 205, 227, 215, 31, 12, 230, 42, 57, 72, 244, 249, 48, 196, 34, 197, 29, 239, 195, 66, 82, 72, 109, 184, 106, 42, 25, 54, 67, 95, 149, 209, 170, 207, 79, 46, 9, 76, 105, 246, 169, 90, 21, 72, 28, 243, 15, 105, 118, 170, 81, 209, 39, 138, 76, 200, 84, 96, 63, 127, 74, 51, 243, 173, 168, 247, 67, 71, 6, 191, 148, 93, 64, 190, 63, 68, 13, 109, 239, 159, 152, 38, 77, 50, 43, 214, 29, 4, 233, 152, 32, 186, 251, 65, 7, 63, 153, 96, 32, 58, 229, 0, 107, 196, 187, 154, 250, 34, 238, 215, 201, 65, 99, 55, 31, 130, 115, 74, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 99, 96, 162, 95, 216, 9, 233, 239, 210, 214, 247, 78, 226, 117, 52, 244, 157, 50, 93, 136, 131, 240, 71, 238, 146, 239, 211, 160, 195, 43, 143, 200, 201, 9, 205, 200, 63, 128, 1, 120, 189, 110, 146, 80, 149, 90, 44, 231, 106, 97, 163, 136, 178, 186, 66, 17, 4, 173, 90, 80, 30, 247, 251 }, new byte[] { 183, 148, 65, 27, 79, 19, 66, 249, 79, 112, 205, 227, 215, 31, 12, 230, 42, 57, 72, 244, 249, 48, 196, 34, 197, 29, 239, 195, 66, 82, 72, 109, 184, 106, 42, 25, 54, 67, 95, 149, 209, 170, 207, 79, 46, 9, 76, 105, 246, 169, 90, 21, 72, 28, 243, 15, 105, 118, 170, 81, 209, 39, 138, 76, 200, 84, 96, 63, 127, 74, 51, 243, 173, 168, 247, 67, 71, 6, 191, 148, 93, 64, 190, 63, 68, 13, 109, 239, 159, 152, 38, 77, 50, 43, 214, 29, 4, 233, 152, 32, 186, 251, 65, 7, 63, 153, 96, 32, 58, 229, 0, 107, 196, 187, 154, 250, 34, 238, 215, 201, 65, 99, 55, 31, 130, 115, 74, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 99, 96, 162, 95, 216, 9, 233, 239, 210, 214, 247, 78, 226, 117, 52, 244, 157, 50, 93, 136, 131, 240, 71, 238, 146, 239, 211, 160, 195, 43, 143, 200, 201, 9, 205, 200, 63, 128, 1, 120, 189, 110, 146, 80, 149, 90, 44, 231, 106, 97, 163, 136, 178, 186, 66, 17, 4, 173, 90, 80, 30, 247, 251 }, new byte[] { 183, 148, 65, 27, 79, 19, 66, 249, 79, 112, 205, 227, 215, 31, 12, 230, 42, 57, 72, 244, 249, 48, 196, 34, 197, 29, 239, 195, 66, 82, 72, 109, 184, 106, 42, 25, 54, 67, 95, 149, 209, 170, 207, 79, 46, 9, 76, 105, 246, 169, 90, 21, 72, 28, 243, 15, 105, 118, 170, 81, 209, 39, 138, 76, 200, 84, 96, 63, 127, 74, 51, 243, 173, 168, 247, 67, 71, 6, 191, 148, 93, 64, 190, 63, 68, 13, 109, 239, 159, 152, 38, 77, 50, 43, 214, 29, 4, 233, 152, 32, 186, 251, 65, 7, 63, 153, 96, 32, 58, 229, 0, 107, 196, 187, 154, 250, 34, 238, 215, 201, 65, 99, 55, 31, 130, 115, 74, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 99, 96, 162, 95, 216, 9, 233, 239, 210, 214, 247, 78, 226, 117, 52, 244, 157, 50, 93, 136, 131, 240, 71, 238, 146, 239, 211, 160, 195, 43, 143, 200, 201, 9, 205, 200, 63, 128, 1, 120, 189, 110, 146, 80, 149, 90, 44, 231, 106, 97, 163, 136, 178, 186, 66, 17, 4, 173, 90, 80, 30, 247, 251 }, new byte[] { 183, 148, 65, 27, 79, 19, 66, 249, 79, 112, 205, 227, 215, 31, 12, 230, 42, 57, 72, 244, 249, 48, 196, 34, 197, 29, 239, 195, 66, 82, 72, 109, 184, 106, 42, 25, 54, 67, 95, 149, 209, 170, 207, 79, 46, 9, 76, 105, 246, 169, 90, 21, 72, 28, 243, 15, 105, 118, 170, 81, 209, 39, 138, 76, 200, 84, 96, 63, 127, 74, 51, 243, 173, 168, 247, 67, 71, 6, 191, 148, 93, 64, 190, 63, 68, 13, 109, 239, 159, 152, 38, 77, 50, 43, 214, 29, 4, 233, 152, 32, 186, 251, 65, 7, 63, 153, 96, 32, 58, 229, 0, 107, 196, 187, 154, 250, 34, 238, 215, 201, 65, 99, 55, 31, 130, 115, 74, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 99, 96, 162, 95, 216, 9, 233, 239, 210, 214, 247, 78, 226, 117, 52, 244, 157, 50, 93, 136, 131, 240, 71, 238, 146, 239, 211, 160, 195, 43, 143, 200, 201, 9, 205, 200, 63, 128, 1, 120, 189, 110, 146, 80, 149, 90, 44, 231, 106, 97, 163, 136, 178, 186, 66, 17, 4, 173, 90, 80, 30, 247, 251 }, new byte[] { 183, 148, 65, 27, 79, 19, 66, 249, 79, 112, 205, 227, 215, 31, 12, 230, 42, 57, 72, 244, 249, 48, 196, 34, 197, 29, 239, 195, 66, 82, 72, 109, 184, 106, 42, 25, 54, 67, 95, 149, 209, 170, 207, 79, 46, 9, 76, 105, 246, 169, 90, 21, 72, 28, 243, 15, 105, 118, 170, 81, 209, 39, 138, 76, 200, 84, 96, 63, 127, 74, 51, 243, 173, 168, 247, 67, 71, 6, 191, 148, 93, 64, 190, 63, 68, 13, 109, 239, 159, 152, 38, 77, 50, 43, 214, 29, 4, 233, 152, 32, 186, 251, 65, 7, 63, 153, 96, 32, 58, 229, 0, 107, 196, 187, 154, 250, 34, 238, 215, 201, 65, 99, 55, 31, 130, 115, 74, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 99, 96, 162, 95, 216, 9, 233, 239, 210, 214, 247, 78, 226, 117, 52, 244, 157, 50, 93, 136, 131, 240, 71, 238, 146, 239, 211, 160, 195, 43, 143, 200, 201, 9, 205, 200, 63, 128, 1, 120, 189, 110, 146, 80, 149, 90, 44, 231, 106, 97, 163, 136, 178, 186, 66, 17, 4, 173, 90, 80, 30, 247, 251 }, new byte[] { 183, 148, 65, 27, 79, 19, 66, 249, 79, 112, 205, 227, 215, 31, 12, 230, 42, 57, 72, 244, 249, 48, 196, 34, 197, 29, 239, 195, 66, 82, 72, 109, 184, 106, 42, 25, 54, 67, 95, 149, 209, 170, 207, 79, 46, 9, 76, 105, 246, 169, 90, 21, 72, 28, 243, 15, 105, 118, 170, 81, 209, 39, 138, 76, 200, 84, 96, 63, 127, 74, 51, 243, 173, 168, 247, 67, 71, 6, 191, 148, 93, 64, 190, 63, 68, 13, 109, 239, 159, 152, 38, 77, 50, 43, 214, 29, 4, 233, 152, 32, 186, 251, 65, 7, 63, 153, 96, 32, 58, 229, 0, 107, 196, 187, 154, 250, 34, 238, 215, 201, 65, 99, 55, 31, 130, 115, 74, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 99, 96, 162, 95, 216, 9, 233, 239, 210, 214, 247, 78, 226, 117, 52, 244, 157, 50, 93, 136, 131, 240, 71, 238, 146, 239, 211, 160, 195, 43, 143, 200, 201, 9, 205, 200, 63, 128, 1, 120, 189, 110, 146, 80, 149, 90, 44, 231, 106, 97, 163, 136, 178, 186, 66, 17, 4, 173, 90, 80, 30, 247, 251 }, new byte[] { 183, 148, 65, 27, 79, 19, 66, 249, 79, 112, 205, 227, 215, 31, 12, 230, 42, 57, 72, 244, 249, 48, 196, 34, 197, 29, 239, 195, 66, 82, 72, 109, 184, 106, 42, 25, 54, 67, 95, 149, 209, 170, 207, 79, 46, 9, 76, 105, 246, 169, 90, 21, 72, 28, 243, 15, 105, 118, 170, 81, 209, 39, 138, 76, 200, 84, 96, 63, 127, 74, 51, 243, 173, 168, 247, 67, 71, 6, 191, 148, 93, 64, 190, 63, 68, 13, 109, 239, 159, 152, 38, 77, 50, 43, 214, 29, 4, 233, 152, 32, 186, 251, 65, 7, 63, 153, 96, 32, 58, 229, 0, 107, 196, 187, 154, 250, 34, 238, 215, 201, 65, 99, 55, 31, 130, 115, 74, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 99, 96, 162, 95, 216, 9, 233, 239, 210, 214, 247, 78, 226, 117, 52, 244, 157, 50, 93, 136, 131, 240, 71, 238, 146, 239, 211, 160, 195, 43, 143, 200, 201, 9, 205, 200, 63, 128, 1, 120, 189, 110, 146, 80, 149, 90, 44, 231, 106, 97, 163, 136, 178, 186, 66, 17, 4, 173, 90, 80, 30, 247, 251 }, new byte[] { 183, 148, 65, 27, 79, 19, 66, 249, 79, 112, 205, 227, 215, 31, 12, 230, 42, 57, 72, 244, 249, 48, 196, 34, 197, 29, 239, 195, 66, 82, 72, 109, 184, 106, 42, 25, 54, 67, 95, 149, 209, 170, 207, 79, 46, 9, 76, 105, 246, 169, 90, 21, 72, 28, 243, 15, 105, 118, 170, 81, 209, 39, 138, 76, 200, 84, 96, 63, 127, 74, 51, 243, 173, 168, 247, 67, 71, 6, 191, 148, 93, 64, 190, 63, 68, 13, 109, 239, 159, 152, 38, 77, 50, 43, 214, 29, 4, 233, 152, 32, 186, 251, 65, 7, 63, 153, 96, 32, 58, 229, 0, 107, 196, 187, 154, 250, 34, 238, 215, 201, 65, 99, 55, 31, 130, 115, 74, 53 } });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId",
                unique: true);
        }
    }
}
