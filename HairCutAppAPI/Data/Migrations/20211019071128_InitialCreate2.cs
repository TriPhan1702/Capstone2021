using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Description", "FullName", "SalonId", "StaffType", "UserId" },
                values: new object[,]
                {
                    { 6, "Beautician 2", "Beautician 2", 1, "beautician", 6 },
                    { 5, "Stylist 2", "Stylist 2", 1, "stylist", 5 },
                    { 4, "Beautician 1", "Beautician 1", 1, "beautician", 4 },
                    { 3, "Stylist 1", "Stylist 1", 1, "stylist", 3 },
                    { 2, "Manager 1", "Manager 1", 1, "manager", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { "admin123@gmail.com", new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 } });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Status" },
                values: new object[,]
                {
                    { 8, null, "customer2@gmail.com", new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 }, "0869190061", "customer", "Active" },
                    { 9, null, "customer3@gmail.com", new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 }, "0869190061", "customer", "Active" },
                    { 7, null, "customer1@gmail.com", new byte[] { 251, 152, 38, 20, 225, 210, 26, 63, 156, 116, 172, 236, 20, 172, 251, 93, 88, 57, 216, 96, 194, 205, 251, 63, 229, 59, 109, 217, 94, 110, 76, 131, 115, 85, 203, 177, 117, 118, 171, 176, 175, 173, 75, 236, 177, 124, 183, 101, 156, 71, 23, 31, 140, 227, 72, 245, 113, 33, 132, 226, 131, 168, 213, 231 }, new byte[] { 84, 250, 17, 202, 47, 254, 234, 208, 175, 175, 15, 96, 254, 63, 154, 176, 170, 194, 230, 25, 236, 173, 87, 63, 151, 29, 222, 54, 179, 198, 165, 40, 53, 237, 73, 27, 140, 212, 233, 225, 206, 236, 53, 1, 31, 224, 57, 35, 206, 161, 43, 146, 115, 18, 246, 67, 10, 192, 15, 125, 118, 254, 107, 159, 48, 169, 9, 130, 172, 71, 73, 141, 32, 193, 245, 80, 153, 76, 178, 98, 156, 103, 66, 74, 59, 46, 154, 81, 30, 46, 171, 34, 65, 0, 175, 30, 189, 146, 73, 47, 142, 127, 222, 189, 125, 85, 50, 203, 48, 44, 135, 154, 61, 196, 101, 38, 205, 201, 86, 89, 99, 232, 75, 231, 195, 42, 118, 255 }, "0869190061", "customer", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FullName", "UserId" },
                values: new object[] { 7, "Customer 1", 7 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FullName", "UserId" },
                values: new object[] { 8, "Customer 2", 8 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FullName", "UserId" },
                values: new object[] { 9, "Customer 3", 9 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Salons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdate" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828), new DateTime(2021, 10, 19, 14, 2, 40, 529, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { "tphan2883@gmail.com", new byte[] { 2, 173, 7, 188, 66, 227, 205, 28, 169, 204, 198, 137, 5, 52, 101, 66, 168, 51, 90, 0, 126, 82, 203, 160, 182, 59, 235, 208, 111, 98, 40, 106, 44, 210, 100, 99, 252, 222, 229, 128, 138, 94, 179, 162, 250, 95, 52, 121, 199, 253, 193, 220, 40, 79, 202, 4, 105, 215, 148, 129, 94, 174, 47, 197 }, new byte[] { 154, 92, 109, 57, 121, 2, 203, 223, 141, 206, 42, 66, 93, 134, 65, 40, 15, 219, 206, 13, 178, 132, 105, 116, 243, 77, 38, 4, 230, 12, 41, 151, 77, 85, 87, 102, 89, 165, 2, 9, 251, 66, 43, 180, 109, 123, 93, 148, 237, 154, 136, 251, 37, 149, 98, 79, 135, 221, 223, 246, 79, 74, 79, 117, 251, 62, 44, 55, 28, 0, 0, 83, 234, 134, 54, 172, 72, 38, 197, 209, 220, 142, 246, 1, 117, 188, 31, 201, 188, 8, 53, 232, 82, 219, 168, 38, 16, 93, 137, 131, 37, 170, 238, 165, 197, 118, 93, 44, 29, 45, 99, 7, 72, 126, 167, 201, 211, 20, 87, 167, 189, 25, 118, 215, 0, 158, 183, 29 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 173, 7, 188, 66, 227, 205, 28, 169, 204, 198, 137, 5, 52, 101, 66, 168, 51, 90, 0, 126, 82, 203, 160, 182, 59, 235, 208, 111, 98, 40, 106, 44, 210, 100, 99, 252, 222, 229, 128, 138, 94, 179, 162, 250, 95, 52, 121, 199, 253, 193, 220, 40, 79, 202, 4, 105, 215, 148, 129, 94, 174, 47, 197 }, new byte[] { 154, 92, 109, 57, 121, 2, 203, 223, 141, 206, 42, 66, 93, 134, 65, 40, 15, 219, 206, 13, 178, 132, 105, 116, 243, 77, 38, 4, 230, 12, 41, 151, 77, 85, 87, 102, 89, 165, 2, 9, 251, 66, 43, 180, 109, 123, 93, 148, 237, 154, 136, 251, 37, 149, 98, 79, 135, 221, 223, 246, 79, 74, 79, 117, 251, 62, 44, 55, 28, 0, 0, 83, 234, 134, 54, 172, 72, 38, 197, 209, 220, 142, 246, 1, 117, 188, 31, 201, 188, 8, 53, 232, 82, 219, 168, 38, 16, 93, 137, 131, 37, 170, 238, 165, 197, 118, 93, 44, 29, 45, 99, 7, 72, 126, 167, 201, 211, 20, 87, 167, 189, 25, 118, 215, 0, 158, 183, 29 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 173, 7, 188, 66, 227, 205, 28, 169, 204, 198, 137, 5, 52, 101, 66, 168, 51, 90, 0, 126, 82, 203, 160, 182, 59, 235, 208, 111, 98, 40, 106, 44, 210, 100, 99, 252, 222, 229, 128, 138, 94, 179, 162, 250, 95, 52, 121, 199, 253, 193, 220, 40, 79, 202, 4, 105, 215, 148, 129, 94, 174, 47, 197 }, new byte[] { 154, 92, 109, 57, 121, 2, 203, 223, 141, 206, 42, 66, 93, 134, 65, 40, 15, 219, 206, 13, 178, 132, 105, 116, 243, 77, 38, 4, 230, 12, 41, 151, 77, 85, 87, 102, 89, 165, 2, 9, 251, 66, 43, 180, 109, 123, 93, 148, 237, 154, 136, 251, 37, 149, 98, 79, 135, 221, 223, 246, 79, 74, 79, 117, 251, 62, 44, 55, 28, 0, 0, 83, 234, 134, 54, 172, 72, 38, 197, 209, 220, 142, 246, 1, 117, 188, 31, 201, 188, 8, 53, 232, 82, 219, 168, 38, 16, 93, 137, 131, 37, 170, 238, 165, 197, 118, 93, 44, 29, 45, 99, 7, 72, 126, 167, 201, 211, 20, 87, 167, 189, 25, 118, 215, 0, 158, 183, 29 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 173, 7, 188, 66, 227, 205, 28, 169, 204, 198, 137, 5, 52, 101, 66, 168, 51, 90, 0, 126, 82, 203, 160, 182, 59, 235, 208, 111, 98, 40, 106, 44, 210, 100, 99, 252, 222, 229, 128, 138, 94, 179, 162, 250, 95, 52, 121, 199, 253, 193, 220, 40, 79, 202, 4, 105, 215, 148, 129, 94, 174, 47, 197 }, new byte[] { 154, 92, 109, 57, 121, 2, 203, 223, 141, 206, 42, 66, 93, 134, 65, 40, 15, 219, 206, 13, 178, 132, 105, 116, 243, 77, 38, 4, 230, 12, 41, 151, 77, 85, 87, 102, 89, 165, 2, 9, 251, 66, 43, 180, 109, 123, 93, 148, 237, 154, 136, 251, 37, 149, 98, 79, 135, 221, 223, 246, 79, 74, 79, 117, 251, 62, 44, 55, 28, 0, 0, 83, 234, 134, 54, 172, 72, 38, 197, 209, 220, 142, 246, 1, 117, 188, 31, 201, 188, 8, 53, 232, 82, 219, 168, 38, 16, 93, 137, 131, 37, 170, 238, 165, 197, 118, 93, 44, 29, 45, 99, 7, 72, 126, 167, 201, 211, 20, 87, 167, 189, 25, 118, 215, 0, 158, 183, 29 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 173, 7, 188, 66, 227, 205, 28, 169, 204, 198, 137, 5, 52, 101, 66, 168, 51, 90, 0, 126, 82, 203, 160, 182, 59, 235, 208, 111, 98, 40, 106, 44, 210, 100, 99, 252, 222, 229, 128, 138, 94, 179, 162, 250, 95, 52, 121, 199, 253, 193, 220, 40, 79, 202, 4, 105, 215, 148, 129, 94, 174, 47, 197 }, new byte[] { 154, 92, 109, 57, 121, 2, 203, 223, 141, 206, 42, 66, 93, 134, 65, 40, 15, 219, 206, 13, 178, 132, 105, 116, 243, 77, 38, 4, 230, 12, 41, 151, 77, 85, 87, 102, 89, 165, 2, 9, 251, 66, 43, 180, 109, 123, 93, 148, 237, 154, 136, 251, 37, 149, 98, 79, 135, 221, 223, 246, 79, 74, 79, 117, 251, 62, 44, 55, 28, 0, 0, 83, 234, 134, 54, 172, 72, 38, 197, 209, 220, 142, 246, 1, 117, 188, 31, 201, 188, 8, 53, 232, 82, 219, 168, 38, 16, 93, 137, 131, 37, 170, 238, 165, 197, 118, 93, 44, 29, 45, 99, 7, 72, 126, 167, 201, 211, 20, 87, 167, 189, 25, 118, 215, 0, 158, 183, 29 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 173, 7, 188, 66, 227, 205, 28, 169, 204, 198, 137, 5, 52, 101, 66, 168, 51, 90, 0, 126, 82, 203, 160, 182, 59, 235, 208, 111, 98, 40, 106, 44, 210, 100, 99, 252, 222, 229, 128, 138, 94, 179, 162, 250, 95, 52, 121, 199, 253, 193, 220, 40, 79, 202, 4, 105, 215, 148, 129, 94, 174, 47, 197 }, new byte[] { 154, 92, 109, 57, 121, 2, 203, 223, 141, 206, 42, 66, 93, 134, 65, 40, 15, 219, 206, 13, 178, 132, 105, 116, 243, 77, 38, 4, 230, 12, 41, 151, 77, 85, 87, 102, 89, 165, 2, 9, 251, 66, 43, 180, 109, 123, 93, 148, 237, 154, 136, 251, 37, 149, 98, 79, 135, 221, 223, 246, 79, 74, 79, 117, 251, 62, 44, 55, 28, 0, 0, 83, 234, 134, 54, 172, 72, 38, 197, 209, 220, 142, 246, 1, 117, 188, 31, 201, 188, 8, 53, 232, 82, 219, 168, 38, 16, 93, 137, 131, 37, 170, 238, 165, 197, 118, 93, 44, 29, 45, 99, 7, 72, 126, 167, 201, 211, 20, 87, 167, 189, 25, 118, 215, 0, 158, 183, 29 } });
        }
    }
}
