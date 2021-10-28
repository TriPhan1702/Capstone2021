using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRatings_Appointments_AppointmentId",
                table: "AppointmentRatings");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentRatings_AppointmentId",
                table: "AppointmentRatings");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "AppointmentRatings");

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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RatingId",
                table: "Appointments",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentRatings_RatingId",
                table: "Appointments",
                column: "RatingId",
                principalTable: "AppointmentRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentRatings_RatingId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_RatingId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "AppointmentRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 10, 28, 19, 12, 40, 340, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 93, 155, 189, 186, 20, 112, 2, 41, 13, 84, 113, 40, 128, 246, 220, 15, 236, 238, 22, 171, 86, 172, 153, 220, 242, 174, 78, 198, 187, 210, 138, 221, 203, 184, 219, 110, 130, 46, 246, 22, 193, 188, 30, 69, 29, 255, 244, 232, 238, 20, 21, 224, 239, 201, 106, 146, 89, 185, 151, 41, 98, 199, 82 }, new byte[] { 145, 228, 251, 194, 157, 65, 91, 47, 98, 72, 167, 152, 69, 253, 197, 189, 88, 201, 95, 83, 241, 193, 127, 41, 184, 204, 2, 132, 29, 219, 94, 139, 79, 132, 86, 33, 78, 103, 134, 84, 221, 9, 33, 181, 77, 49, 7, 223, 220, 236, 223, 12, 30, 129, 12, 236, 60, 106, 115, 131, 232, 88, 24, 18, 113, 233, 17, 153, 67, 50, 54, 34, 73, 36, 23, 88, 150, 203, 176, 182, 245, 194, 217, 132, 17, 82, 237, 88, 110, 195, 114, 245, 66, 100, 26, 219, 215, 74, 190, 80, 114, 242, 22, 249, 23, 212, 72, 8, 112, 113, 142, 55, 96, 23, 58, 52, 140, 254, 20, 217, 229, 27, 206, 255, 62, 146, 18, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 93, 155, 189, 186, 20, 112, 2, 41, 13, 84, 113, 40, 128, 246, 220, 15, 236, 238, 22, 171, 86, 172, 153, 220, 242, 174, 78, 198, 187, 210, 138, 221, 203, 184, 219, 110, 130, 46, 246, 22, 193, 188, 30, 69, 29, 255, 244, 232, 238, 20, 21, 224, 239, 201, 106, 146, 89, 185, 151, 41, 98, 199, 82 }, new byte[] { 145, 228, 251, 194, 157, 65, 91, 47, 98, 72, 167, 152, 69, 253, 197, 189, 88, 201, 95, 83, 241, 193, 127, 41, 184, 204, 2, 132, 29, 219, 94, 139, 79, 132, 86, 33, 78, 103, 134, 84, 221, 9, 33, 181, 77, 49, 7, 223, 220, 236, 223, 12, 30, 129, 12, 236, 60, 106, 115, 131, 232, 88, 24, 18, 113, 233, 17, 153, 67, 50, 54, 34, 73, 36, 23, 88, 150, 203, 176, 182, 245, 194, 217, 132, 17, 82, 237, 88, 110, 195, 114, 245, 66, 100, 26, 219, 215, 74, 190, 80, 114, 242, 22, 249, 23, 212, 72, 8, 112, 113, 142, 55, 96, 23, 58, 52, 140, 254, 20, 217, 229, 27, 206, 255, 62, 146, 18, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 93, 155, 189, 186, 20, 112, 2, 41, 13, 84, 113, 40, 128, 246, 220, 15, 236, 238, 22, 171, 86, 172, 153, 220, 242, 174, 78, 198, 187, 210, 138, 221, 203, 184, 219, 110, 130, 46, 246, 22, 193, 188, 30, 69, 29, 255, 244, 232, 238, 20, 21, 224, 239, 201, 106, 146, 89, 185, 151, 41, 98, 199, 82 }, new byte[] { 145, 228, 251, 194, 157, 65, 91, 47, 98, 72, 167, 152, 69, 253, 197, 189, 88, 201, 95, 83, 241, 193, 127, 41, 184, 204, 2, 132, 29, 219, 94, 139, 79, 132, 86, 33, 78, 103, 134, 84, 221, 9, 33, 181, 77, 49, 7, 223, 220, 236, 223, 12, 30, 129, 12, 236, 60, 106, 115, 131, 232, 88, 24, 18, 113, 233, 17, 153, 67, 50, 54, 34, 73, 36, 23, 88, 150, 203, 176, 182, 245, 194, 217, 132, 17, 82, 237, 88, 110, 195, 114, 245, 66, 100, 26, 219, 215, 74, 190, 80, 114, 242, 22, 249, 23, 212, 72, 8, 112, 113, 142, 55, 96, 23, 58, 52, 140, 254, 20, 217, 229, 27, 206, 255, 62, 146, 18, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 93, 155, 189, 186, 20, 112, 2, 41, 13, 84, 113, 40, 128, 246, 220, 15, 236, 238, 22, 171, 86, 172, 153, 220, 242, 174, 78, 198, 187, 210, 138, 221, 203, 184, 219, 110, 130, 46, 246, 22, 193, 188, 30, 69, 29, 255, 244, 232, 238, 20, 21, 224, 239, 201, 106, 146, 89, 185, 151, 41, 98, 199, 82 }, new byte[] { 145, 228, 251, 194, 157, 65, 91, 47, 98, 72, 167, 152, 69, 253, 197, 189, 88, 201, 95, 83, 241, 193, 127, 41, 184, 204, 2, 132, 29, 219, 94, 139, 79, 132, 86, 33, 78, 103, 134, 84, 221, 9, 33, 181, 77, 49, 7, 223, 220, 236, 223, 12, 30, 129, 12, 236, 60, 106, 115, 131, 232, 88, 24, 18, 113, 233, 17, 153, 67, 50, 54, 34, 73, 36, 23, 88, 150, 203, 176, 182, 245, 194, 217, 132, 17, 82, 237, 88, 110, 195, 114, 245, 66, 100, 26, 219, 215, 74, 190, 80, 114, 242, 22, 249, 23, 212, 72, 8, 112, 113, 142, 55, 96, 23, 58, 52, 140, 254, 20, 217, 229, 27, 206, 255, 62, 146, 18, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 93, 155, 189, 186, 20, 112, 2, 41, 13, 84, 113, 40, 128, 246, 220, 15, 236, 238, 22, 171, 86, 172, 153, 220, 242, 174, 78, 198, 187, 210, 138, 221, 203, 184, 219, 110, 130, 46, 246, 22, 193, 188, 30, 69, 29, 255, 244, 232, 238, 20, 21, 224, 239, 201, 106, 146, 89, 185, 151, 41, 98, 199, 82 }, new byte[] { 145, 228, 251, 194, 157, 65, 91, 47, 98, 72, 167, 152, 69, 253, 197, 189, 88, 201, 95, 83, 241, 193, 127, 41, 184, 204, 2, 132, 29, 219, 94, 139, 79, 132, 86, 33, 78, 103, 134, 84, 221, 9, 33, 181, 77, 49, 7, 223, 220, 236, 223, 12, 30, 129, 12, 236, 60, 106, 115, 131, 232, 88, 24, 18, 113, 233, 17, 153, 67, 50, 54, 34, 73, 36, 23, 88, 150, 203, 176, 182, 245, 194, 217, 132, 17, 82, 237, 88, 110, 195, 114, 245, 66, 100, 26, 219, 215, 74, 190, 80, 114, 242, 22, 249, 23, 212, 72, 8, 112, 113, 142, 55, 96, 23, 58, 52, 140, 254, 20, 217, 229, 27, 206, 255, 62, 146, 18, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 93, 155, 189, 186, 20, 112, 2, 41, 13, 84, 113, 40, 128, 246, 220, 15, 236, 238, 22, 171, 86, 172, 153, 220, 242, 174, 78, 198, 187, 210, 138, 221, 203, 184, 219, 110, 130, 46, 246, 22, 193, 188, 30, 69, 29, 255, 244, 232, 238, 20, 21, 224, 239, 201, 106, 146, 89, 185, 151, 41, 98, 199, 82 }, new byte[] { 145, 228, 251, 194, 157, 65, 91, 47, 98, 72, 167, 152, 69, 253, 197, 189, 88, 201, 95, 83, 241, 193, 127, 41, 184, 204, 2, 132, 29, 219, 94, 139, 79, 132, 86, 33, 78, 103, 134, 84, 221, 9, 33, 181, 77, 49, 7, 223, 220, 236, 223, 12, 30, 129, 12, 236, 60, 106, 115, 131, 232, 88, 24, 18, 113, 233, 17, 153, 67, 50, 54, 34, 73, 36, 23, 88, 150, 203, 176, 182, 245, 194, 217, 132, 17, 82, 237, 88, 110, 195, 114, 245, 66, 100, 26, 219, 215, 74, 190, 80, 114, 242, 22, 249, 23, 212, 72, 8, 112, 113, 142, 55, 96, 23, 58, 52, 140, 254, 20, 217, 229, 27, 206, 255, 62, 146, 18, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 93, 155, 189, 186, 20, 112, 2, 41, 13, 84, 113, 40, 128, 246, 220, 15, 236, 238, 22, 171, 86, 172, 153, 220, 242, 174, 78, 198, 187, 210, 138, 221, 203, 184, 219, 110, 130, 46, 246, 22, 193, 188, 30, 69, 29, 255, 244, 232, 238, 20, 21, 224, 239, 201, 106, 146, 89, 185, 151, 41, 98, 199, 82 }, new byte[] { 145, 228, 251, 194, 157, 65, 91, 47, 98, 72, 167, 152, 69, 253, 197, 189, 88, 201, 95, 83, 241, 193, 127, 41, 184, 204, 2, 132, 29, 219, 94, 139, 79, 132, 86, 33, 78, 103, 134, 84, 221, 9, 33, 181, 77, 49, 7, 223, 220, 236, 223, 12, 30, 129, 12, 236, 60, 106, 115, 131, 232, 88, 24, 18, 113, 233, 17, 153, 67, 50, 54, 34, 73, 36, 23, 88, 150, 203, 176, 182, 245, 194, 217, 132, 17, 82, 237, 88, 110, 195, 114, 245, 66, 100, 26, 219, 215, 74, 190, 80, 114, 242, 22, 249, 23, 212, 72, 8, 112, 113, 142, 55, 96, 23, 58, 52, 140, 254, 20, 217, 229, 27, 206, 255, 62, 146, 18, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 93, 155, 189, 186, 20, 112, 2, 41, 13, 84, 113, 40, 128, 246, 220, 15, 236, 238, 22, 171, 86, 172, 153, 220, 242, 174, 78, 198, 187, 210, 138, 221, 203, 184, 219, 110, 130, 46, 246, 22, 193, 188, 30, 69, 29, 255, 244, 232, 238, 20, 21, 224, 239, 201, 106, 146, 89, 185, 151, 41, 98, 199, 82 }, new byte[] { 145, 228, 251, 194, 157, 65, 91, 47, 98, 72, 167, 152, 69, 253, 197, 189, 88, 201, 95, 83, 241, 193, 127, 41, 184, 204, 2, 132, 29, 219, 94, 139, 79, 132, 86, 33, 78, 103, 134, 84, 221, 9, 33, 181, 77, 49, 7, 223, 220, 236, 223, 12, 30, 129, 12, 236, 60, 106, 115, 131, 232, 88, 24, 18, 113, 233, 17, 153, 67, 50, 54, 34, 73, 36, 23, 88, 150, 203, 176, 182, 245, 194, 217, 132, 17, 82, 237, 88, 110, 195, 114, 245, 66, 100, 26, 219, 215, 74, 190, 80, 114, 242, 22, 249, 23, 212, 72, 8, 112, 113, 142, 55, 96, 23, 58, 52, 140, 254, 20, 217, 229, 27, 206, 255, 62, 146, 18, 53 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 93, 155, 189, 186, 20, 112, 2, 41, 13, 84, 113, 40, 128, 246, 220, 15, 236, 238, 22, 171, 86, 172, 153, 220, 242, 174, 78, 198, 187, 210, 138, 221, 203, 184, 219, 110, 130, 46, 246, 22, 193, 188, 30, 69, 29, 255, 244, 232, 238, 20, 21, 224, 239, 201, 106, 146, 89, 185, 151, 41, 98, 199, 82 }, new byte[] { 145, 228, 251, 194, 157, 65, 91, 47, 98, 72, 167, 152, 69, 253, 197, 189, 88, 201, 95, 83, 241, 193, 127, 41, 184, 204, 2, 132, 29, 219, 94, 139, 79, 132, 86, 33, 78, 103, 134, 84, 221, 9, 33, 181, 77, 49, 7, 223, 220, 236, 223, 12, 30, 129, 12, 236, 60, 106, 115, 131, 232, 88, 24, 18, 113, 233, 17, 153, 67, 50, 54, 34, 73, 36, 23, 88, 150, 203, 176, 182, 245, 194, 217, 132, 17, 82, 237, 88, 110, 195, 114, 245, 66, 100, 26, 219, 215, 74, 190, 80, 114, 242, 22, 249, 23, 212, 72, 8, 112, 113, 142, 55, 96, 23, 58, 52, 140, 254, 20, 217, 229, 27, 206, 255, 62, 146, 18, 53 } });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentRatings_AppointmentId",
                table: "AppointmentRatings",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRatings_Appointments_AppointmentId",
                table: "AppointmentRatings",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
