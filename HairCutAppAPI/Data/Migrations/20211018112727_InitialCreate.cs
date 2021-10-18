using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionalCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUniversal = table.Column<bool>(type: "bit", nullable: false),
                    UsesPerCustomer = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionalCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlotsOfDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotsOfDay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalonsCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonId = table.Column<int>(type: "int", nullable: false),
                    CodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonsCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalonsCodes_PromotionalCodes_CodeId",
                        column: x => x.CodeId,
                        principalTable: "PromotionalCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalonsCodes_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboDetails_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboDetails_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Rating = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AppointmentsNumber = table.Column<int>(type: "int", nullable: false),
                    SuccessfulAppointmentsNumber = table.Column<int>(type: "int", nullable: false),
                    StaffType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SalonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: true),
                    AppointmentDetailId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PromotionalCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComboId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CodeId = table.Column<int>(type: "int", nullable: false),
                    TimesUsed = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersCodes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersCodes_PromotionalCodes_CodeId",
                        column: x => x.CodeId,
                        principalTable: "PromotionalCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrewDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewDetails_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewDetails_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    SlotOfDayId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSlots_SlotsOfDay_SlotOfDayId",
                        column: x => x.SlotOfDayId,
                        principalTable: "SlotsOfDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkSlots_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    CrewId = table.Column<int>(type: "int", nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    RatingComment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentRatings_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "CreatedDate", "Description", "Duration", "LastUpdated", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt Tóc", 1, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt Tóc", "active" },
                    { 2, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt Tóc Gội Đầu", 2, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt Tóc Gội Đầu", "active" },
                    { 3, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt Tóc Gội Đầu Rửa Mặt", 2, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt Tóc Gội Đầu Rửa Mặt", "active" },
                    { 4, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt Tóc, Ráy Táy, Gội Đầu, Rửa Mặt, Dắp mặt", 3, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Chăm sóc đầy đử", "active" },
                    { 5, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt Tóc, Ráy Táy", 1, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt tóc ráy tai", "active" }
                });

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "Id", "AvatarUrl", "CreatedDate", "Description", "LastUpdate", "Latitude", "Longitude", "Name", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Salon 1", new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), null, null, "Salon 1", "active" },
                    { 2, null, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Salon 2", new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), null, null, "Salon 2", "active" },
                    { 3, null, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Salon 3", new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), null, null, "Salon 3", "active" },
                    { 4, null, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Salon 4", new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), null, null, "Salon 4", "active" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdated", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Đắp Mặt", new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Đắp Mặt", 20000m, "active" },
                    { 3, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Ráy tai", new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Ráy tai", 10000m, "active" },
                    { 4, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Gội Đầu", new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Rửa Mặt", 20000m, "active" },
                    { 1, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt tóc", new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Cắt tóc", 50000m, "active" },
                    { 2, new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Gội Đầu", new DateTime(2021, 10, 18, 18, 27, 27, 418, DateTimeKind.Local).AddTicks(809), "Gội Đầu", 20000m, "active" }
                });

            migrationBuilder.InsertData(
                table: "SlotsOfDay",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 15, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 25, new TimeSpan(0, 19, 30, 0, 0), new TimeSpan(0, 19, 0, 0, 0) },
                    { 24, new TimeSpan(0, 19, 0, 0, 0), new TimeSpan(0, 18, 30, 0, 0) },
                    { 23, new TimeSpan(0, 18, 30, 0, 0), new TimeSpan(0, 18, 0, 0, 0) },
                    { 22, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 17, 30, 0, 0) },
                    { 21, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 17, 0, 0, 0) },
                    { 20, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 16, 30, 0, 0) },
                    { 19, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 18, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { 17, new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 16, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 14, 30, 0, 0) },
                    { 14, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 7, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 12, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 11, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 12, 0, 0, 0) },
                    { 10, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 9, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 8, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 26, new TimeSpan(0, 20, 0, 0, 0), new TimeSpan(0, 19, 30, 0, 0) },
                    { 6, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 5, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 4, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 3, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 1, new TimeSpan(0, 7, 30, 0, 0), new TimeSpan(0, 7, 0, 0, 0) },
                    { 13, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 27, new TimeSpan(0, 20, 30, 0, 0), new TimeSpan(0, 20, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "ComboDetails",
                columns: new[] { "Id", "ComboId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 4, 3, 1 },
                    { 7, 4, 1 },
                    { 12, 5, 1 },
                    { 3, 2, 2 },
                    { 5, 3, 2 },
                    { 8, 4, 2 },
                    { 9, 4, 3 },
                    { 13, 5, 3 },
                    { 6, 3, 4 },
                    { 10, 4, 4 },
                    { 11, 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_AppointmentId",
                table: "AppointmentDetails",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_ComboId",
                table: "AppointmentDetails",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_CrewId",
                table: "AppointmentDetails",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentRatings_AppointmentId",
                table: "AppointmentRatings",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ComboId",
                table: "Appointments",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SalonId",
                table: "Appointments",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetails_ComboId",
                table: "ComboDetails",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetails_ServiceId",
                table: "ComboDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewDetails_CrewId",
                table: "CrewDetails",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewDetails_StaffId",
                table: "CrewDetails",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersCodes_CodeId",
                table: "CustomersCodes",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersCodes_CustomerId",
                table: "CustomersCodes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SalonId",
                table: "Reviews",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_SalonsCodes_CodeId",
                table: "SalonsCodes",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalonsCodes_SalonId",
                table: "SalonsCodes",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_SalonId",
                table: "Staff",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_UserId",
                table: "Staff",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSlots_SlotOfDayId",
                table: "WorkSlots",
                column: "SlotOfDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSlots_StaffId",
                table: "WorkSlots",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentDetails");

            migrationBuilder.DropTable(
                name: "AppointmentRatings");

            migrationBuilder.DropTable(
                name: "ComboDetails");

            migrationBuilder.DropTable(
                name: "CrewDetails");

            migrationBuilder.DropTable(
                name: "CustomersCodes");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SalonsCodes");

            migrationBuilder.DropTable(
                name: "WorkSlots");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "PromotionalCodes");

            migrationBuilder.DropTable(
                name: "SlotsOfDay");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Salons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
