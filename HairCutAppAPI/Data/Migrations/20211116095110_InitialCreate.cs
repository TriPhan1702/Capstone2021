using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    RatingComment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Params",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumberValue = table.Column<int>(type: "int", nullable: false),
                    TextValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Params", x => x.Id);
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
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Duration = table.Column<int>(type: "int", nullable: false),
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
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    IsDoneByStylist = table.Column<bool>(type: "bit", nullable: false),
                    ServiceOrder = table.Column<int>(type: "int", nullable: false)
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
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StaffType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HasAutoSchedule = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Rating = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
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
                    ChosenStaffId = table.Column<int>(type: "int", nullable: true),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PromotionalCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentRatings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "AppointmentRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Appointments_Staff_ChosenStaffId",
                        column: x => x.ChosenStaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    IsDoneByStylist = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                        name: "FK_AppointmentDetails_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "WorkSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDetailId = table.Column<int>(type: "int", nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    SlotOfDayId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSlots_AppointmentDetails_AppointmentDetailId",
                        column: x => x.AppointmentDetailId,
                        principalTable: "AppointmentDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkSlots_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "AvatarUrl", "CreatedDate", "Description", "LastUpdated", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 2, "https://placeimg.com/500/500/tech", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt Tóc Gội Đầu", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt Tóc Gội Đầu", 60000m, "active" },
                    { 1, "https://placeimg.com/500/500/tech", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt Tóc", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt Tóc", 45000m, "active" },
                    { 3, "https://placeimg.com/500/500/tech", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt Tóc Gội Đầu Rửa Mặt", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt Tóc Gội Đầu Chăm Sóc Da Mặt", 80000m, "active" },
                    { 4, "https://placeimg.com/500/500/tech", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt Tóc, Ráy Táy, Gội Đầu, Rửa Mặt, Dắp mặt", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Chăm sóc đầy đử", 100000m, "active" },
                    { 5, "https://placeimg.com/500/500/tech", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt Tóc, Ráy Táy", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt tóc ráy tai", 60000m, "active" },
                    { 6, "https://placeimg.com/500/500/tech", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Nhuộm tóc", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Nhuộm tóc", 140000m, "active" },
                    { 7, "https://placeimg.com/500/500/tech", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Uốn tóc", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Uốn tóc", 40000m, "active" }
                });

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "Id", "Address", "AvatarUrl", "CreatedDate", "Description", "LastUpdate", "Latitude", "Longitude", "Name", "Status" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Salon Quận Gò Vấp", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), null, null, "Salon Quận Gò Vấp", "active" },
                    { 2, null, null, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Salon Quan 1", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), null, null, "Salon Quan 1", "active" },
                    { 3, null, null, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Salon Quang Trung", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), null, null, "Salon Quang Trung", "active" },
                    { 8, null, null, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Salon Binh Chanh", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), null, null, "Salon Binh Chanh", "active" },
                    { 7, null, null, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Salon Thu Duc", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), null, null, "Salon Thu Duc", "active" },
                    { 6, null, null, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Salon 6", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), null, null, "Salon Quan 6", "active" },
                    { 5, null, null, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Salon 5", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), null, null, "Salon Quan 5", "active" },
                    { 4, null, null, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Salon 4", new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), null, null, "Salon 4", "active" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "Duration", "LastUpdated", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt tóc", 3, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Cắt tóc", 50000m },
                    { 2, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Gội Đầu", 3, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Gội Đầu", 20000m },
                    { 3, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Ráy tai", 1, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Ráy tai", 10000m },
                    { 4, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Gội Đầu", 2, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Chăm Sóc Da Mặt", 20000m },
                    { 5, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Đắp Mặt", 3, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Đắp Mặt", 20000m },
                    { 6, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Nhuộm tóc", 4, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Nhuộm tóc", 150000m },
                    { 7, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Uốn tóc", 3, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Uốn tóc", 50000m },
                    { 8, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Tạo kiểu", 3, new DateTime(2021, 11, 16, 16, 51, 10, 332, DateTimeKind.Local).AddTicks(3207), "Tạo kiểu", 20000m }
                });

            migrationBuilder.InsertData(
                table: "SlotsOfDay",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 20, new TimeSpan(0, 10, 20, 0, 0), new TimeSpan(0, 10, 10, 0, 0) },
                    { 21, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 10, 20, 0, 0) },
                    { 22, new TimeSpan(0, 10, 40, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 23, new TimeSpan(0, 10, 50, 0, 0), new TimeSpan(0, 10, 40, 0, 0) },
                    { 27, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 11, 20, 0, 0) },
                    { 25, new TimeSpan(0, 11, 10, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 26, new TimeSpan(0, 11, 20, 0, 0), new TimeSpan(0, 11, 10, 0, 0) },
                    { 19, new TimeSpan(0, 10, 10, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 28, new TimeSpan(0, 11, 40, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 24, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 10, 50, 0, 0) },
                    { 18, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 9, 50, 0, 0) },
                    { 15, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 9, 20, 0, 0) },
                    { 16, new TimeSpan(0, 9, 40, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 8, new TimeSpan(0, 8, 20, 0, 0), new TimeSpan(0, 8, 10, 0, 0) },
                    { 14, new TimeSpan(0, 9, 20, 0, 0), new TimeSpan(0, 9, 10, 0, 0) },
                    { 13, new TimeSpan(0, 9, 10, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 12, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 8, 50, 0, 0) },
                    { 11, new TimeSpan(0, 8, 50, 0, 0), new TimeSpan(0, 8, 40, 0, 0) },
                    { 10, new TimeSpan(0, 8, 40, 0, 0), new TimeSpan(0, 8, 30, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "SlotsOfDay",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 9, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 8, 20, 0, 0) },
                    { 7, new TimeSpan(0, 8, 10, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 29, new TimeSpan(0, 11, 50, 0, 0), new TimeSpan(0, 11, 40, 0, 0) },
                    { 17, new TimeSpan(0, 9, 50, 0, 0), new TimeSpan(0, 9, 40, 0, 0) },
                    { 6, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 7, 50, 0, 0) },
                    { 30, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 11, 50, 0, 0) },
                    { 32, new TimeSpan(0, 12, 20, 0, 0), new TimeSpan(0, 12, 10, 0, 0) },
                    { 57, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 16, 20, 0, 0) },
                    { 58, new TimeSpan(0, 16, 40, 0, 0), new TimeSpan(0, 16, 30, 0, 0) },
                    { 59, new TimeSpan(0, 16, 50, 0, 0), new TimeSpan(0, 16, 40, 0, 0) },
                    { 60, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 16, 50, 0, 0) },
                    { 61, new TimeSpan(0, 17, 10, 0, 0), new TimeSpan(0, 17, 0, 0, 0) },
                    { 62, new TimeSpan(0, 17, 20, 0, 0), new TimeSpan(0, 17, 10, 0, 0) },
                    { 63, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 17, 20, 0, 0) },
                    { 64, new TimeSpan(0, 17, 40, 0, 0), new TimeSpan(0, 17, 30, 0, 0) },
                    { 65, new TimeSpan(0, 17, 50, 0, 0), new TimeSpan(0, 17, 40, 0, 0) },
                    { 56, new TimeSpan(0, 16, 20, 0, 0), new TimeSpan(0, 16, 10, 0, 0) },
                    { 67, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 17, 50, 0, 0) },
                    { 69, new TimeSpan(0, 18, 20, 0, 0), new TimeSpan(0, 18, 10, 0, 0) },
                    { 70, new TimeSpan(0, 18, 30, 0, 0), new TimeSpan(0, 18, 20, 0, 0) },
                    { 71, new TimeSpan(0, 18, 40, 0, 0), new TimeSpan(0, 18, 30, 0, 0) },
                    { 72, new TimeSpan(0, 18, 50, 0, 0), new TimeSpan(0, 18, 40, 0, 0) },
                    { 73, new TimeSpan(0, 19, 0, 0, 0), new TimeSpan(0, 18, 50, 0, 0) },
                    { 74, new TimeSpan(0, 19, 10, 0, 0), new TimeSpan(0, 19, 0, 0, 0) },
                    { 75, new TimeSpan(0, 19, 20, 0, 0), new TimeSpan(0, 19, 10, 0, 0) },
                    { 76, new TimeSpan(0, 19, 30, 0, 0), new TimeSpan(0, 19, 20, 0, 0) },
                    { 77, new TimeSpan(0, 19, 40, 0, 0), new TimeSpan(0, 19, 30, 0, 0) },
                    { 68, new TimeSpan(0, 18, 10, 0, 0), new TimeSpan(0, 18, 0, 0, 0) },
                    { 31, new TimeSpan(0, 12, 10, 0, 0), new TimeSpan(0, 12, 0, 0, 0) },
                    { 55, new TimeSpan(0, 16, 10, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 53, new TimeSpan(0, 15, 50, 0, 0), new TimeSpan(0, 15, 40, 0, 0) },
                    { 33, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 12, 20, 0, 0) },
                    { 34, new TimeSpan(0, 12, 40, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 35, new TimeSpan(0, 12, 50, 0, 0), new TimeSpan(0, 12, 40, 0, 0) },
                    { 36, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 50, 0, 0) },
                    { 37, new TimeSpan(0, 13, 10, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 38, new TimeSpan(0, 13, 20, 0, 0), new TimeSpan(0, 13, 10, 0, 0) },
                    { 39, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 13, 20, 0, 0) },
                    { 40, new TimeSpan(0, 13, 40, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 41, new TimeSpan(0, 13, 50, 0, 0), new TimeSpan(0, 13, 40, 0, 0) },
                    { 54, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 15, 50, 0, 0) },
                    { 42, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 50, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "SlotsOfDay",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 44, new TimeSpan(0, 14, 20, 0, 0), new TimeSpan(0, 14, 10, 0, 0) },
                    { 45, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 14, 20, 0, 0) },
                    { 46, new TimeSpan(0, 14, 40, 0, 0), new TimeSpan(0, 14, 30, 0, 0) },
                    { 47, new TimeSpan(0, 14, 50, 0, 0), new TimeSpan(0, 14, 40, 0, 0) },
                    { 48, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 14, 50, 0, 0) },
                    { 49, new TimeSpan(0, 15, 10, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 50, new TimeSpan(0, 15, 20, 0, 0), new TimeSpan(0, 15, 10, 0, 0) },
                    { 51, new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 15, 20, 0, 0) },
                    { 52, new TimeSpan(0, 15, 40, 0, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { 43, new TimeSpan(0, 14, 10, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 5, new TimeSpan(0, 7, 50, 0, 0), new TimeSpan(0, 7, 40, 0, 0) },
                    { 79, new TimeSpan(0, 20, 0, 0, 0), new TimeSpan(0, 19, 50, 0, 0) },
                    { 3, new TimeSpan(0, 7, 30, 0, 0), new TimeSpan(0, 7, 20, 0, 0) },
                    { 2, new TimeSpan(0, 7, 20, 0, 0), new TimeSpan(0, 7, 10, 0, 0) },
                    { 1, new TimeSpan(0, 7, 10, 0, 0), new TimeSpan(0, 7, 0, 0, 0) },
                    { 78, new TimeSpan(0, 19, 50, 0, 0), new TimeSpan(0, 19, 40, 0, 0) },
                    { 4, new TimeSpan(0, 7, 40, 0, 0), new TimeSpan(0, 7, 30, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "FullName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Status" },
                values: new object[,]
                {
                    { 20, "https://thispersondoesnotexist.com/image", "duythanh_pham19@hotmail.com", "pham duy thanh", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 21, "https://thispersondoesnotexist.com/image", "trihung_dang15@yahoo.com", "dang tri hung", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 22, "https://thispersondoesnotexist.com/image", "thaomai.mai65@gmail.com", "mai thi ngoc mai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 23, "https://thispersondoesnotexist.com/image", "haonhien.dinh0@gmail.com", "dinh hao nhien", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 24, "https://thispersondoesnotexist.com/image", "khanhhoan_do@gmail.com", "do hoang khanh", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 25, "https://thispersondoesnotexist.com/image", "thusuong_phan54@yahoo.com", "phan thi thu suong", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 28, "https://thispersondoesnotexist.com/image", "vietnhan6@gmail.com", "le hoang viet nhan", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 27, "https://thispersondoesnotexist.com/image", "bangbang73@gmail.com", "pham bang bang", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 29, "https://thispersondoesnotexist.com/image", "huyenanh.hoang48@gmail.com", "nguyen hoang huyen anh", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 30, "https://thispersondoesnotexist.com/image", "baohan69@yahoo.com", "truong bao han", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 31, "https://thispersondoesnotexist.com/image", "tanlong.nguyen33@yahoo.com", "long van tan", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 32, "https://thispersondoesnotexist.com/image", "ngantruc76@hotmail.com", "ngan thanh truc", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 33, "https://thispersondoesnotexist.com/image", "linhgiang.ngo63@hotmail.com", "ngo linh giang", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 26, "https://thispersondoesnotexist.com/image", "quynhchi.ngo83@gmail.com", "Ngo quynh chi", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 19, "https://thispersondoesnotexist.com/image", "customer3@gmail.com", "Customer 3", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 16, "https://thispersondoesnotexist.com/image", "uyennuy1997@gmail.com", "phan vu nhu uyen", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0986099088", "customer", "Active" },
                    { 17, "https://thispersondoesnotexist.com/image", "alta.sharp@gmail.com", "le van tan", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 2, "https://thispersondoesnotexist.com/image", "manager123@gmail.com", "Đặng Trọng Hà", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "manager", "active" },
                    { 3, "https://thispersondoesnotexist.com/image", "stylist123@gmail.com", "Phạm Quang Tú", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "active" },
                    { 4, "https://thispersondoesnotexist.com/image", "beautician123@gmail.com", "Phạm Thụy Trinh", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "active" },
                    { 5, "https://thispersondoesnotexist.com/image", "stylist1234@gmail.com", "Phạm Nhật Dũng", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "active" },
                    { 6, "https://thispersondoesnotexist.com/image", "beautician1234@gmail.com", "Đặng Hà Giang", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "active" },
                    { 7, "https://thispersondoesnotexist.com/image", "customer1@gmail.com", "Hồ Kim Thông", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "active" },
                    { 18, "https://thispersondoesnotexist.com/image", "minhthuan.tang@gmail.com", "tang minh thuan", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 8, "https://thispersondoesnotexist.com/image", "customer2@gmail.com", "Phạm Nguyên Phong", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "active" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "FullName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Status" },
                values: new object[,]
                {
                    { 10, "https://thispersondoesnotexist.com/image", "slyteplayer@gmail.com", "Le Thanh nghia", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0348073007", "customer", "Active" },
                    { 11, "https://thispersondoesnotexist.com/image", "thanhnghiale1312@gmail.com", "Le thanh nghia", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0986721721", "customer", "Active" },
                    { 12, "https://thispersondoesnotexist.com/image", "anhdaovo1967@gmail.com", "Vo thi anh dao", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0914001728", "customer", "Active" },
                    { 13, "https://thispersondoesnotexist.com/image", "lethanhan1963@gmail.com", "le thanh an", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0906541022", "customer", "Active" },
                    { 14, "https://thispersondoesnotexist.com/image", "lethanhan0101@gmail.com", "le thanh an", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0905413695", "customer", "Active" },
                    { 15, "https://thispersondoesnotexist.com/image", "phangiabao97@gmail.com", "phan gia bao", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0327882535", "customer", "Active" },
                    { 9, "https://thispersondoesnotexist.com/image", "customer3@gmail.com", "Lý Thanh Thế", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "active" },
                    { 34, "https://thispersondoesnotexist.com/image", "thiyen_ho98@gmail.com", "ho thi yen", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 37, "https://thispersondoesnotexist.com/image", "tuananh76@gmail.com", "nguyen anh tuan", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 36, "https://thispersondoesnotexist.com/image", "viethong_phung@hotmail.com", "phung viet thong", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 56, "https://thispersondoesnotexist.com/image", "Stylist41@yahoo.com", "Stylist bon mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" },
                    { 57, "https://thispersondoesnotexist.com/image", "Stylist42@yahoo.com", "Stylist bon hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" },
                    { 58, "https://thispersondoesnotexist.com/image", "Beautician41@yahoo.com", "Beautician bon mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 59, "https://thispersondoesnotexist.com/image", "Beautician42@yahoo.com", "Beautician bon hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 60, "https://thispersondoesnotexist.com/image", "Manager5@yahoo.com", "Manager nam", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "manager", "Active" },
                    { 61, "https://thispersondoesnotexist.com/image", "Stylist51@yahoo.com", "Stylist nam mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" },
                    { 55, "https://thispersondoesnotexist.com/image", "Manager4@yahoo.com", "Manager bon", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "manager", "Active" },
                    { 62, "https://thispersondoesnotexist.com/image", "Stylist52@yahoo.com", "Stylist nam hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" },
                    { 64, "https://thispersondoesnotexist.com/image", "Beautician52@yahoo.com", "Beautician nam hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 65, "https://thispersondoesnotexist.com/image", "Manager6@yahoo.com", "Manager sau", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "manager", "Active" },
                    { 66, "https://thispersondoesnotexist.com/image", "Stylist61@yahoo.com", "Stylist sau mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" },
                    { 67, "https://thispersondoesnotexist.com/image", "Stylist62@yahoo.com", "Stylist sau hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" },
                    { 68, "https://thispersondoesnotexist.com/image", "Beautician61@yahoo.com", "Beautician sau mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 69, "https://thispersondoesnotexist.com/image", "Beautician62@yahoo.com", "Beautican sau hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 63, "https://thispersondoesnotexist.com/image", "Beautician51@yahoo.com", "Beautician nam mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 35, "https://thispersondoesnotexist.com/image", "duyhung.mai@gmail.com", "mai duy hung", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 54, "https://thispersondoesnotexist.com/image", "Beautician32@yahoo.com", "Beautician ba hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 52, "https://thispersondoesnotexist.com/image", "Stylist32@yahoo.com", "Stylist ba hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" },
                    { 38, "https://thispersondoesnotexist.com/image", "phiphuong1@gmail.com", "nguyen duy phuong", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 39, "https://thispersondoesnotexist.com/image", "tieubao33@yahoo.com", "ngo tieu bao", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 40, "https://thispersondoesnotexist.com/image", "thusuong_phan99@yahoo.com", "nguyen thi truc suong", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 41, "https://thispersondoesnotexist.com/image", "huutuong30@gmail.com", "giang huu tuong", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 42, "https://thispersondoesnotexist.com/image", "gianguyen33@gmail.com", "nguyen gia anh", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 43, "https://thispersondoesnotexist.com/image", "nghiahoa.phung75@yahoo.com", "phung ngoc hoa", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "customer", "Active" },
                    { 53, "https://thispersondoesnotexist.com/image", "Beautician31@yahoo.com", "Beautician ba mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 44, "https://thispersondoesnotexist.com/image", "Beautician13@gmail.com", "Beautician mot ba", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 46, "https://thispersondoesnotexist.com/image", "Stylist21@yahoo.com", "Stylist hai mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" },
                    { 47, "https://thispersondoesnotexist.com/image", "Stylist22@yahoo.com", "Stylist hai hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" },
                    { 48, "https://thispersondoesnotexist.com/image", "Beautician21@yahoo.com", "Beautican hai mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 49, "https://thispersondoesnotexist.com/image", "Beautician22@yahoo.com", "Beautician hai hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "beautician", "Active" },
                    { 50, "https://thispersondoesnotexist.com/image", "Manager3@yahoo.com", "Manager ba", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "manager", "Active" },
                    { 51, "https://thispersondoesnotexist.com/image", "Stylist31@yahoo.com", "Stylist ba mot", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "stylist", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "FullName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Status" },
                values: new object[] { 45, "https://thispersondoesnotexist.com/image", "Manager2@yahoo.com", "Manager hai", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "manager", "Active" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "FullName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Status" },
                values: new object[] { 1, "https://thispersondoesnotexist.com/image", "admin123@gmail.com", "Phan Anh Tuấn", new byte[] { 88, 5, 186, 114, 119, 207, 237, 62, 119, 153, 85, 97, 21, 214, 79, 180, 11, 196, 129, 225, 70, 67, 248, 75, 186, 219, 26, 187, 23, 197, 74, 243, 121, 254, 4, 39, 114, 200, 128, 191, 177, 27, 153, 180, 160, 187, 159, 84, 101, 15, 157, 110, 185, 148, 182, 5, 108, 20, 134, 145, 115, 205, 64, 212 }, new byte[] { 57, 49, 164, 38, 228, 13, 75, 27, 233, 236, 188, 136, 165, 156, 219, 27, 39, 255, 237, 64, 251, 115, 114, 61, 32, 26, 151, 181, 38, 234, 97, 141, 123, 58, 169, 0, 213, 56, 203, 65, 29, 200, 62, 192, 219, 89, 139, 211, 203, 136, 30, 170, 94, 196, 206, 65, 211, 245, 128, 239, 149, 221, 132, 80, 214, 5, 120, 145, 212, 173, 90, 141, 79, 15, 39, 79, 204, 50, 174, 239, 189, 78, 179, 44, 218, 159, 157, 246, 230, 40, 72, 176, 34, 184, 32, 46, 191, 173, 241, 102, 242, 92, 135, 169, 100, 10, 41, 110, 184, 190, 4, 65, 230, 195, 13, 148, 230, 62, 187, 129, 140, 145, 189, 223, 232, 27, 145, 129 }, "0869190061", "administrator", "active" });

            migrationBuilder.InsertData(
                table: "ComboDetails",
                columns: new[] { "Id", "ComboId", "IsDoneByStylist", "ServiceId", "ServiceOrder" },
                values: new object[,]
                {
                    { 11, 4, false, 5, 5 },
                    { 1, 1, true, 1, 1 },
                    { 2, 2, true, 1, 1 },
                    { 4, 3, true, 1, 1 },
                    { 7, 4, true, 1, 1 },
                    { 12, 5, true, 1, 1 },
                    { 10, 4, false, 4, 4 },
                    { 5, 3, false, 2, 2 },
                    { 8, 4, false, 2, 2 },
                    { 9, 4, false, 3, 3 },
                    { 13, 5, false, 3, 2 },
                    { 6, 3, false, 4, 3 },
                    { 3, 2, false, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FullName", "UserId" },
                values: new object[,]
                {
                    { 34, "ho thi yen", 34 },
                    { 35, "mai duy hung", 35 },
                    { 36, "phung viet thong", 36 },
                    { 37, "nguyen anh tuan", 37 },
                    { 38, "nguyen duy phuong", 38 },
                    { 41, "giang huu tuong", 41 },
                    { 40, "nguyen thi truc suong", 40 },
                    { 42, "nguyen gia anh", 42 },
                    { 43, "phung ngoc hoa", 43 },
                    { 33, "ngo linh giang", 33 },
                    { 39, "ngo tieu bao", 39 },
                    { 32, "ngan thanh truc", 32 },
                    { 7, "Hồ Kim Thông", 7 },
                    { 30, "truong bao han", 30 },
                    { 31, "long van tan", 31 },
                    { 18, "tang minh thuan", 18 },
                    { 17, "le van tan", 17 },
                    { 16, "phan vu nhu uyen", 16 },
                    { 15, "phan gia bao", 15 },
                    { 14, "le thanh an", 14 },
                    { 13, "le thanh an", 13 },
                    { 11, "Le thanh nghia", 11 },
                    { 19, "Customer 3", 19 },
                    { 10, "Le thanh nghia", 10 },
                    { 9, "Lý Thanh Thế", 9 },
                    { 12, "Vo thi anh dao", 12 },
                    { 20, "pham duy thanh", 20 },
                    { 29, "nguyen hoang huyen anh", 29 },
                    { 8, "Phạm Nguyên Phong", 8 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FullName", "UserId" },
                values: new object[,]
                {
                    { 27, "pham bang bang", 27 },
                    { 26, "Ngo quynh chi", 26 },
                    { 25, "phan thi thu suong", 25 },
                    { 28, "le hoang viet nhan", 28 },
                    { 23, "dinh hao nhien", 23 },
                    { 22, "mai thi ngoc mai", 22 },
                    { 21, "dang tri hung", 21 },
                    { 24, "do hoang khanh", 24 }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Description", "FullName", "HasAutoSchedule", "SalonId", "StaffType", "UserId" },
                values: new object[,]
                {
                    { 25, "Stylist 52", "Stylist 52", false, 3, "stylist", 62 },
                    { 32, "Beautician 62", "Beautician 62", false, 3, "beautician", 69 },
                    { 31, "Beautician 61", "Beutician 61", false, 3, "beautician", 68 },
                    { 30, "Stylist 62", "Stylist 62", false, 3, "stylist", 67 },
                    { 29, "Stylist 61", "Stylist 61", false, 3, "stylist", 66 },
                    { 28, "Manager quan 6", "Manager 6", false, 3, "manager", 65 },
                    { 27, "Beautician 52", "Beautician 52", false, 3, "beautician", 64 },
                    { 26, "Beautician 51", "Beutician 51", false, 3, "beautician", 63 },
                    { 24, "Stylist 51", "Stylist 51", false, 3, "stylist", 61 },
                    { 18, "Manager 4", "Manager 4", false, 3, "manager", 55 },
                    { 22, "Beautician 42", "Beautician 42", false, 3, "beautician", 59 },
                    { 2, "Đặng Trọng Hà", "Đặng Trọng Hà", false, 1, "manager", 2 },
                    { 3, "Phạm Quang Tú", "Phạm Quang Tú", false, 1, "stylist", 3 },
                    { 4, "Phạm Thụy Trinh", "Phạm Thụy Trinh", false, 1, "beautician", 4 },
                    { 6, "Đặng Hà Giang", "Đặng Hà Giang", false, 1, "beautician", 6 },
                    { 7, "Beautician 13", "Beautician 13", false, 1, "beautician", 44 },
                    { 8, "Manager 2", "Manager 2", false, 2, "manager", 45 },
                    { 9, "Stylist 21", "Stylist 21", false, 2, "stylist", 46 },
                    { 10, "Stylist 22", "Stylist 22", false, 2, "stylist", 47 },
                    { 23, "Manager quan 5", "Manager 5", false, 3, "manager", 60 },
                    { 11, "Beutician 21", "Beutician 21", false, 2, "beautician", 48 },
                    { 13, "Manager 3", "Manager 3", false, 3, "manager", 50 },
                    { 14, "Stylist 31", "Stylist 31", false, 3, "stylist", 51 },
                    { 15, "Stylist 32", "Stylist 32", false, 3, "stylist", 52 },
                    { 16, "Beautician 31", "Beutician 31", false, 3, "beautician", 53 },
                    { 17, "Beautician 32", "Beautician 32", false, 3, "beautician", 54 },
                    { 19, "Stylist 41", "Stylist 41", false, 3, "stylist", 56 },
                    { 20, "Stylist 42", "Stylist 42", false, 3, "stylist", 57 },
                    { 21, "Beautician 41", "Beutician 41", false, 3, "beautician", 58 },
                    { 12, "Beautician 22", "Beautician 22", false, 2, "beautician", 49 },
                    { 5, "Phạm Nhật Dũng", "Phạm Nhật Dũng", false, 1, "stylist", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_AppointmentId",
                table: "AppointmentDetails",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_ServiceId",
                table: "AppointmentDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_StaffId",
                table: "AppointmentDetails",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ChosenStaffId",
                table: "Appointments",
                column: "ChosenStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ComboId",
                table: "Appointments",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RatingId",
                table: "Appointments",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SalonId",
                table: "Appointments",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorUserId",
                table: "Articles",
                column: "AuthorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetails_ComboId",
                table: "ComboDetails",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetails_ServiceId",
                table: "ComboDetails",
                column: "ServiceId");

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
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AppointmentId",
                table: "Notifications",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

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
                name: "IX_WorkSlots_AppointmentDetailId",
                table: "WorkSlots",
                column: "AppointmentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSlots_AppointmentId",
                table: "WorkSlots",
                column: "AppointmentId");

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
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ComboDetails");

            migrationBuilder.DropTable(
                name: "CustomersCodes");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Params");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SalonsCodes");

            migrationBuilder.DropTable(
                name: "WorkSlots");

            migrationBuilder.DropTable(
                name: "PromotionalCodes");

            migrationBuilder.DropTable(
                name: "AppointmentDetails");

            migrationBuilder.DropTable(
                name: "SlotsOfDay");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AppointmentRatings");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Salons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
