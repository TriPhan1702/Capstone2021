using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "WorkSlots",
                type: "int",
                nullable: true);

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
                name: "IX_WorkSlots_AppointmentId",
                table: "WorkSlots",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSlots_Appointments_AppointmentId",
                table: "WorkSlots",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSlots_Appointments_AppointmentId",
                table: "WorkSlots");

            migrationBuilder.DropIndex(
                name: "IX_WorkSlots_AppointmentId",
                table: "WorkSlots");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "WorkSlots");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691), new DateTime(2021, 10, 27, 19, 22, 18, 145, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 184, 26, 177, 119, 62, 199, 235, 174, 84, 102, 111, 249, 100, 176, 147, 21, 176, 145, 217, 168, 119, 29, 3, 102, 115, 0, 127, 7, 146, 47, 122, 82, 75, 41, 5, 56, 65, 204, 113, 220, 136, 128, 197, 153, 40, 182, 7, 29, 187, 124, 84, 150, 106, 49, 87, 242, 195, 18, 96, 19, 67, 144, 237 }, new byte[] { 153, 86, 74, 189, 200, 44, 59, 29, 215, 9, 170, 162, 174, 73, 57, 20, 100, 106, 183, 181, 151, 160, 244, 222, 90, 37, 122, 196, 246, 227, 238, 65, 124, 250, 117, 62, 213, 10, 18, 72, 60, 125, 68, 100, 10, 240, 10, 150, 255, 2, 2, 36, 175, 231, 137, 247, 9, 52, 153, 30, 89, 237, 44, 6, 99, 219, 185, 236, 103, 190, 84, 134, 106, 80, 119, 213, 150, 247, 197, 215, 244, 148, 107, 211, 228, 205, 145, 133, 0, 104, 108, 197, 79, 98, 164, 201, 227, 229, 64, 152, 197, 94, 219, 94, 182, 202, 252, 222, 174, 233, 174, 161, 112, 114, 74, 215, 87, 244, 108, 200, 25, 28, 193, 3, 220, 3, 90, 212 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 184, 26, 177, 119, 62, 199, 235, 174, 84, 102, 111, 249, 100, 176, 147, 21, 176, 145, 217, 168, 119, 29, 3, 102, 115, 0, 127, 7, 146, 47, 122, 82, 75, 41, 5, 56, 65, 204, 113, 220, 136, 128, 197, 153, 40, 182, 7, 29, 187, 124, 84, 150, 106, 49, 87, 242, 195, 18, 96, 19, 67, 144, 237 }, new byte[] { 153, 86, 74, 189, 200, 44, 59, 29, 215, 9, 170, 162, 174, 73, 57, 20, 100, 106, 183, 181, 151, 160, 244, 222, 90, 37, 122, 196, 246, 227, 238, 65, 124, 250, 117, 62, 213, 10, 18, 72, 60, 125, 68, 100, 10, 240, 10, 150, 255, 2, 2, 36, 175, 231, 137, 247, 9, 52, 153, 30, 89, 237, 44, 6, 99, 219, 185, 236, 103, 190, 84, 134, 106, 80, 119, 213, 150, 247, 197, 215, 244, 148, 107, 211, 228, 205, 145, 133, 0, 104, 108, 197, 79, 98, 164, 201, 227, 229, 64, 152, 197, 94, 219, 94, 182, 202, 252, 222, 174, 233, 174, 161, 112, 114, 74, 215, 87, 244, 108, 200, 25, 28, 193, 3, 220, 3, 90, 212 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 184, 26, 177, 119, 62, 199, 235, 174, 84, 102, 111, 249, 100, 176, 147, 21, 176, 145, 217, 168, 119, 29, 3, 102, 115, 0, 127, 7, 146, 47, 122, 82, 75, 41, 5, 56, 65, 204, 113, 220, 136, 128, 197, 153, 40, 182, 7, 29, 187, 124, 84, 150, 106, 49, 87, 242, 195, 18, 96, 19, 67, 144, 237 }, new byte[] { 153, 86, 74, 189, 200, 44, 59, 29, 215, 9, 170, 162, 174, 73, 57, 20, 100, 106, 183, 181, 151, 160, 244, 222, 90, 37, 122, 196, 246, 227, 238, 65, 124, 250, 117, 62, 213, 10, 18, 72, 60, 125, 68, 100, 10, 240, 10, 150, 255, 2, 2, 36, 175, 231, 137, 247, 9, 52, 153, 30, 89, 237, 44, 6, 99, 219, 185, 236, 103, 190, 84, 134, 106, 80, 119, 213, 150, 247, 197, 215, 244, 148, 107, 211, 228, 205, 145, 133, 0, 104, 108, 197, 79, 98, 164, 201, 227, 229, 64, 152, 197, 94, 219, 94, 182, 202, 252, 222, 174, 233, 174, 161, 112, 114, 74, 215, 87, 244, 108, 200, 25, 28, 193, 3, 220, 3, 90, 212 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 184, 26, 177, 119, 62, 199, 235, 174, 84, 102, 111, 249, 100, 176, 147, 21, 176, 145, 217, 168, 119, 29, 3, 102, 115, 0, 127, 7, 146, 47, 122, 82, 75, 41, 5, 56, 65, 204, 113, 220, 136, 128, 197, 153, 40, 182, 7, 29, 187, 124, 84, 150, 106, 49, 87, 242, 195, 18, 96, 19, 67, 144, 237 }, new byte[] { 153, 86, 74, 189, 200, 44, 59, 29, 215, 9, 170, 162, 174, 73, 57, 20, 100, 106, 183, 181, 151, 160, 244, 222, 90, 37, 122, 196, 246, 227, 238, 65, 124, 250, 117, 62, 213, 10, 18, 72, 60, 125, 68, 100, 10, 240, 10, 150, 255, 2, 2, 36, 175, 231, 137, 247, 9, 52, 153, 30, 89, 237, 44, 6, 99, 219, 185, 236, 103, 190, 84, 134, 106, 80, 119, 213, 150, 247, 197, 215, 244, 148, 107, 211, 228, 205, 145, 133, 0, 104, 108, 197, 79, 98, 164, 201, 227, 229, 64, 152, 197, 94, 219, 94, 182, 202, 252, 222, 174, 233, 174, 161, 112, 114, 74, 215, 87, 244, 108, 200, 25, 28, 193, 3, 220, 3, 90, 212 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 184, 26, 177, 119, 62, 199, 235, 174, 84, 102, 111, 249, 100, 176, 147, 21, 176, 145, 217, 168, 119, 29, 3, 102, 115, 0, 127, 7, 146, 47, 122, 82, 75, 41, 5, 56, 65, 204, 113, 220, 136, 128, 197, 153, 40, 182, 7, 29, 187, 124, 84, 150, 106, 49, 87, 242, 195, 18, 96, 19, 67, 144, 237 }, new byte[] { 153, 86, 74, 189, 200, 44, 59, 29, 215, 9, 170, 162, 174, 73, 57, 20, 100, 106, 183, 181, 151, 160, 244, 222, 90, 37, 122, 196, 246, 227, 238, 65, 124, 250, 117, 62, 213, 10, 18, 72, 60, 125, 68, 100, 10, 240, 10, 150, 255, 2, 2, 36, 175, 231, 137, 247, 9, 52, 153, 30, 89, 237, 44, 6, 99, 219, 185, 236, 103, 190, 84, 134, 106, 80, 119, 213, 150, 247, 197, 215, 244, 148, 107, 211, 228, 205, 145, 133, 0, 104, 108, 197, 79, 98, 164, 201, 227, 229, 64, 152, 197, 94, 219, 94, 182, 202, 252, 222, 174, 233, 174, 161, 112, 114, 74, 215, 87, 244, 108, 200, 25, 28, 193, 3, 220, 3, 90, 212 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 184, 26, 177, 119, 62, 199, 235, 174, 84, 102, 111, 249, 100, 176, 147, 21, 176, 145, 217, 168, 119, 29, 3, 102, 115, 0, 127, 7, 146, 47, 122, 82, 75, 41, 5, 56, 65, 204, 113, 220, 136, 128, 197, 153, 40, 182, 7, 29, 187, 124, 84, 150, 106, 49, 87, 242, 195, 18, 96, 19, 67, 144, 237 }, new byte[] { 153, 86, 74, 189, 200, 44, 59, 29, 215, 9, 170, 162, 174, 73, 57, 20, 100, 106, 183, 181, 151, 160, 244, 222, 90, 37, 122, 196, 246, 227, 238, 65, 124, 250, 117, 62, 213, 10, 18, 72, 60, 125, 68, 100, 10, 240, 10, 150, 255, 2, 2, 36, 175, 231, 137, 247, 9, 52, 153, 30, 89, 237, 44, 6, 99, 219, 185, 236, 103, 190, 84, 134, 106, 80, 119, 213, 150, 247, 197, 215, 244, 148, 107, 211, 228, 205, 145, 133, 0, 104, 108, 197, 79, 98, 164, 201, 227, 229, 64, 152, 197, 94, 219, 94, 182, 202, 252, 222, 174, 233, 174, 161, 112, 114, 74, 215, 87, 244, 108, 200, 25, 28, 193, 3, 220, 3, 90, 212 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 184, 26, 177, 119, 62, 199, 235, 174, 84, 102, 111, 249, 100, 176, 147, 21, 176, 145, 217, 168, 119, 29, 3, 102, 115, 0, 127, 7, 146, 47, 122, 82, 75, 41, 5, 56, 65, 204, 113, 220, 136, 128, 197, 153, 40, 182, 7, 29, 187, 124, 84, 150, 106, 49, 87, 242, 195, 18, 96, 19, 67, 144, 237 }, new byte[] { 153, 86, 74, 189, 200, 44, 59, 29, 215, 9, 170, 162, 174, 73, 57, 20, 100, 106, 183, 181, 151, 160, 244, 222, 90, 37, 122, 196, 246, 227, 238, 65, 124, 250, 117, 62, 213, 10, 18, 72, 60, 125, 68, 100, 10, 240, 10, 150, 255, 2, 2, 36, 175, 231, 137, 247, 9, 52, 153, 30, 89, 237, 44, 6, 99, 219, 185, 236, 103, 190, 84, 134, 106, 80, 119, 213, 150, 247, 197, 215, 244, 148, 107, 211, 228, 205, 145, 133, 0, 104, 108, 197, 79, 98, 164, 201, 227, 229, 64, 152, 197, 94, 219, 94, 182, 202, 252, 222, 174, 233, 174, 161, 112, 114, 74, 215, 87, 244, 108, 200, 25, 28, 193, 3, 220, 3, 90, 212 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 184, 26, 177, 119, 62, 199, 235, 174, 84, 102, 111, 249, 100, 176, 147, 21, 176, 145, 217, 168, 119, 29, 3, 102, 115, 0, 127, 7, 146, 47, 122, 82, 75, 41, 5, 56, 65, 204, 113, 220, 136, 128, 197, 153, 40, 182, 7, 29, 187, 124, 84, 150, 106, 49, 87, 242, 195, 18, 96, 19, 67, 144, 237 }, new byte[] { 153, 86, 74, 189, 200, 44, 59, 29, 215, 9, 170, 162, 174, 73, 57, 20, 100, 106, 183, 181, 151, 160, 244, 222, 90, 37, 122, 196, 246, 227, 238, 65, 124, 250, 117, 62, 213, 10, 18, 72, 60, 125, 68, 100, 10, 240, 10, 150, 255, 2, 2, 36, 175, 231, 137, 247, 9, 52, 153, 30, 89, 237, 44, 6, 99, 219, 185, 236, 103, 190, 84, 134, 106, 80, 119, 213, 150, 247, 197, 215, 244, 148, 107, 211, 228, 205, 145, 133, 0, 104, 108, 197, 79, 98, 164, 201, 227, 229, 64, 152, 197, 94, 219, 94, 182, 202, 252, 222, 174, 233, 174, 161, 112, 114, 74, 215, 87, 244, 108, 200, 25, 28, 193, 3, 220, 3, 90, 212 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 184, 26, 177, 119, 62, 199, 235, 174, 84, 102, 111, 249, 100, 176, 147, 21, 176, 145, 217, 168, 119, 29, 3, 102, 115, 0, 127, 7, 146, 47, 122, 82, 75, 41, 5, 56, 65, 204, 113, 220, 136, 128, 197, 153, 40, 182, 7, 29, 187, 124, 84, 150, 106, 49, 87, 242, 195, 18, 96, 19, 67, 144, 237 }, new byte[] { 153, 86, 74, 189, 200, 44, 59, 29, 215, 9, 170, 162, 174, 73, 57, 20, 100, 106, 183, 181, 151, 160, 244, 222, 90, 37, 122, 196, 246, 227, 238, 65, 124, 250, 117, 62, 213, 10, 18, 72, 60, 125, 68, 100, 10, 240, 10, 150, 255, 2, 2, 36, 175, 231, 137, 247, 9, 52, 153, 30, 89, 237, 44, 6, 99, 219, 185, 236, 103, 190, 84, 134, 106, 80, 119, 213, 150, 247, 197, 215, 244, 148, 107, 211, 228, 205, 145, 133, 0, 104, 108, 197, 79, 98, 164, 201, 227, 229, 64, 152, 197, 94, 219, 94, 182, 202, 252, 222, 174, 233, 174, 161, 112, 114, 74, 215, 87, 244, 108, 200, 25, 28, 193, 3, 220, 3, 90, 212 } });
        }
    }
}
