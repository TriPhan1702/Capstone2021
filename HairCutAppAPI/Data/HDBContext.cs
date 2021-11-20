using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Data
{
    //Make sure that User, Role and UserRole have int as ID
    public class HDBContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<WorkSlot> WorkSlots { get; set; }
        public DbSet<SlotOfDay> SlotsOfDay { get; set; }
        public DbSet<ComboDetail> ComboDetails { get; set; }
        public DbSet<PromotionalCode> PromotionalCodes { get; set; }
        public DbSet<CustomersCodes> CustomersCodes { get; set; }
        public DbSet<SalonsCodes> SalonsCodes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<AppointmentRating> AppointmentRatings { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        
        public HDBContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            using var hmac = new HMACSHA512();
            
            builder.Entity<Appointment>()
                .HasOne(a => a.ChosenStaff)
                .WithMany(staff => staff.Appointments)
                .OnDelete(DeleteBehavior.Restrict);

            #region SeedData

            //Get Current time
            var now = DateTime.Now;
            
            //Seed Salon
            builder.Entity<Salon>().HasData
            (
                new Salon(){Id = 1, Name = "Salon Quận Gò Vấp", Description = "Salon Quận Gò Vấp", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 2, Name = "Salon Quan 1", Description = "Salon Quan 1", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 3, Name = "Salon Quang Trung", Description = "Salon Quang Trung", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 4, Name = "Salon 4", Description = "Salon 4", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 5, Name = "Salon Quan 5", Description = "Salon 5", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 6, Name = "Salon Quan 6", Description = "Salon 6", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 7, Name = "Salon Thu Duc", Description = "Salon Thu Duc", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 8, Name = "Salon Binh Chanh", Description = "Salon Binh Chanh", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus}
            );

            //Seed Admin
            builder.Entity<AppUser>().HasData
            (
                new AppUser(){
                    Id = 1, 
                    Status = GlobalVariables.ActiveUserStatus,
                    Email = "admin123@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.AdministratorRole,
                    FullName = "Phan Anh Tuấn",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 2, 
                    Status = GlobalVariables.ActiveUserStatus,
                    Email = "manager123@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.ManagerRole,
                    FullName = "Đặng Trọng Hà",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 3, 
                    Status = GlobalVariables.ActiveUserStatus,
                    Email = "stylist123@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Phạm Quang Tú",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 4, 
                    Status = GlobalVariables.ActiveUserStatus,
                    Email = "beautician123@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Phạm Thụy Trinh",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 5, 
                    Status = GlobalVariables.ActiveUserStatus,
                    Email = "stylist1234@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Phạm Nhật Dũng",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 6, 
                    Status = GlobalVariables.ActiveUserStatus,
                    Email = "beautician1234@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Đặng Hà Giang",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 7, 
                    Status = GlobalVariables.ActiveUserStatus,
                    Email = "customer1@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "Hồ Kim Thông",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 8, 
                    Status = GlobalVariables.ActiveUserStatus,
                    Email = "customer2@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "Phạm Nguyên Phong",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 9, 
                    Status = GlobalVariables.ActiveUserStatus,
                    Email = "customer3@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "Lý Thanh Thế",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 10, 
                    Status = "Active",
                    Email = "slyteplayer@gmail.com", 
                    PhoneNumber = "0348073007",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "Le Thanh nghia",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 11, 
                    Status = "Active",
                    Email = "thanhnghiale1312@gmail.com", 
                    PhoneNumber = "0986721721",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "Le thanh nghia",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 12, 
                    Status = "Active",
                    Email = "anhdaovo1967@gmail.com", 
                    PhoneNumber = "0914001728",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "Vo thi anh dao",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 13, 
                    Status = "Active",
                    Email = "lethanhan1963@gmail.com", 
                    PhoneNumber = "0906541022",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "le thanh an",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 14, 
                    Status = "Active",
                    Email = "lethanhan0101@gmail.com", 
                    PhoneNumber = "0905413695",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "le thanh an",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 15, 
                    Status = "Active",
                    Email = "phangiabao97@gmail.com", 
                    PhoneNumber = "0327882535",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "phan gia bao",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 16, 
                    Status = "Active",
                    Email = "uyennuy1997@gmail.com", 
                    PhoneNumber = "0986099088",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "phan vu nhu uyen",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 17, 
                    Status = "Active",
                    Email = "alta.sharp@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "le van tan",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 18, 
                    Status = "Active",
                    Email = "minhthuan.tang@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "tang minh thuan",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 19, 
                    Status = "Active",
                    Email = "customer3@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "Customer 3",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 20, 
                    Status = "Active",
                    Email = "duythanh_pham19@hotmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "pham duy thanh",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 21, 
                    Status = "Active",
                    Email = "trihung_dang15@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "dang tri hung",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 22, 
                    Status = "Active",
                    Email = "thaomai.mai65@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "mai thi ngoc mai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 23, 
                    Status = "Active",
                    Email = "haonhien.dinh0@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "dinh hao nhien",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 24, 
                    Status = "Active",
                    Email = "khanhhoan_do@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "do hoang khanh",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 25, 
                    Status = "Active",
                    Email = "thusuong_phan54@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "phan thi thu suong",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 26, 
                    Status = "Active",
                    Email = "quynhchi.ngo83@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "Ngo quynh chi",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 27, 
                    Status = "Active",
                    Email = "bangbang73@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "pham bang bang",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 28, 
                    Status = "Active",
                    Email = "vietnhan6@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "le hoang viet nhan",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 29, 
                    Status = "Active",
                    Email = "huyenanh.hoang48@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "nguyen hoang huyen anh",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 30, 
                    Status = "Active",
                    Email = "baohan69@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "truong bao han",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 31, 
                    Status = "Active",
                    Email = "tanlong.nguyen33@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "long van tan",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 32, 
                    Status = "Active",
                    Email = "ngantruc76@hotmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "ngan thanh truc",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 33, 
                    Status = "Active",
                    Email = "linhgiang.ngo63@hotmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "ngo linh giang",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 34, 
                    Status = "Active",
                    Email = "thiyen_ho98@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "ho thi yen",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 35, 
                    Status = "Active",
                    Email = "duyhung.mai@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "mai duy hung",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 36, 
                    Status = "Active",
                    Email = "viethong_phung@hotmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "phung viet thong",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 37, 
                    Status = "Active",
                    Email = "tuananh76@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "nguyen anh tuan",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 38, 
                    Status = "Active",
                    Email = "phiphuong1@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "nguyen duy phuong",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 39, 
                    Status = "Active",
                    Email = "tieubao33@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "ngo tieu bao",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 40, 
                    Status = "Active",
                    Email = "thusuong_phan99@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "nguyen thi truc suong",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 41, 
                    Status = "Active",
                    Email = "huutuong30@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "giang huu tuong",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 42, 
                    Status = "Active",
                    Email = "gianguyen33@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "nguyen gia anh",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"  
                },
                new AppUser(){
                    Id = 43, 
                    Status = "Active",
                    Email = "nghiahoa.phung75@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.CustomerRole,
                    FullName = "phung ngoc hoa",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 44, 
                    Status = "Active",
                    Email = "Beautician13@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautician mot ba",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 45, 
                    Status = "Active",
                    Email = "Manager2@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.ManagerRole,
                    FullName = "Manager hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 46, 
                    Status = "Active",
                    Email = "Stylist21@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist hai mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 47, 
                    Status = "Active",
                    Email = "Stylist22@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist hai hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 48, 
                    Status = "Active",
                    Email = "Beautician21@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautican hai mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 49, 
                    Status = "Active",
                    Email = "Beautician22@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautician hai hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 50, 
                    Status = "Active",
                    Email = "Manager3@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.ManagerRole,
                    FullName = "Manager ba",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 51, 
                    Status = "Active",
                    Email = "Stylist31@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist ba mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 52, 
                    Status = "Active",
                    Email = "Stylist32@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist ba hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 53, 
                    Status = "Active",
                    Email = "Beautician31@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautician ba mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 54, 
                    Status = "Active",
                    Email = "Beautician32@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautician ba hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 55, 
                    Status = "Active",
                    Email = "Manager4@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.ManagerRole,
                    FullName = "Manager bon",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 56, 
                    Status = "Active",
                    Email = "Stylist41@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist bon mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 57, 
                    Status = "Active",
                    Email = "Stylist42@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist bon hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 58, 
                    Status = "Active",
                    Email = "Beautician41@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautician bon mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 59, 
                    Status = "Active",
                    Email = "Beautician42@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautician bon hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 60, 
                    Status = "Active",
                    Email = "Manager5@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.ManagerRole,
                    FullName = "Manager nam",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 61, 
                    Status = "Active",
                    Email = "Stylist51@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist nam mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 62, 
                    Status = "Active",
                    Email = "Stylist52@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist nam hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 63, 
                    Status = "Active",
                    Email = "Beautician51@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautician nam mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 64, 
                    Status = "Active",
                    Email = "Beautician52@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautician nam hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 65, 
                    Status = "Active",
                    Email = "Manager6@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.ManagerRole,
                    FullName = "Manager sau",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 66, 
                    Status = "Active",
                    Email = "Stylist61@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist sau mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 67, 
                    Status = "Active",
                    Email = "Stylist62@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.StylistRole,
                    FullName = "Stylist sau hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 68, 
                    Status = "Active",
                    Email = "Beautician61@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautician sau mot",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                },
                new AppUser(){
                    Id = 69, 
                    Status = "Active",
                    Email = "Beautician62@yahoo.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.BeauticianRole,
                    FullName = "Beautican sau hai",
                    AvatarUrl = "https://thispersondoesnotexist.com/image"
                }
            );
            
            //Seed Staff
            builder.Entity<Staff>().HasData(
                new Staff(){Id = 2, UserId = 2, FullName = "Đặng Trọng Hà", Description = "Đặng Trọng Hà", SalonId = 1, StaffType = GlobalVariables.ManagerRole},
                new Staff(){Id = 3, UserId = 3, FullName = "Phạm Quang Tú", Description = "Phạm Quang Tú", SalonId = 1, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 4, UserId = 4, FullName = "Phạm Thụy Trinh", Description = "Phạm Thụy Trinh", SalonId = 1, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 5, UserId = 5, FullName = "Phạm Nhật Dũng", Description = "Phạm Nhật Dũng", SalonId = 1, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 6, UserId = 6, FullName = "Đặng Hà Giang", Description = "Đặng Hà Giang", SalonId = 1, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 7, UserId = 44, FullName = "Beautician 13", Description = "Beautician 13", SalonId = 1, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 8, UserId = 45, FullName = "Manager 2", Description = "Manager 2", SalonId = 2, StaffType = GlobalVariables.ManagerRole},
                new Staff(){Id = 9, UserId = 46, FullName = "Stylist 21", Description = "Stylist 21", SalonId = 2, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 10, UserId = 47, FullName = "Stylist 22", Description = "Stylist 22", SalonId = 2, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 11, UserId = 48, FullName = "Beutician 21", Description = "Beutician 21", SalonId = 2, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 12, UserId = 49, FullName = "Beautician 22", Description = "Beautician 22", SalonId = 2, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 13, UserId = 50, FullName = "Manager 3", Description = "Manager 3", SalonId = 3, StaffType = GlobalVariables.ManagerRole},
                new Staff(){Id = 14, UserId = 51, FullName = "Stylist 31", Description = "Stylist 31", SalonId = 3, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 15, UserId = 52, FullName = "Stylist 32", Description = "Stylist 32", SalonId = 3, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 16, UserId = 53, FullName = "Beutician 31", Description = "Beautician 31", SalonId = 3, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 17, UserId = 54, FullName = "Beautician 32", Description = "Beautician 32", SalonId = 3, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 18, UserId = 55, FullName = "Manager 4", Description = "Manager 4", SalonId = 3, StaffType = GlobalVariables.ManagerRole},
                new Staff(){Id = 19, UserId = 56, FullName = "Stylist 41", Description = "Stylist 41", SalonId = 3, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 20, UserId = 57, FullName = "Stylist 42", Description = "Stylist 42", SalonId = 3, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 21, UserId = 58, FullName = "Beutician 41", Description = "Beautician 41", SalonId = 3, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 22, UserId = 59, FullName = "Beautician 42", Description = "Beautician 42", SalonId = 3, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 23, UserId = 60, FullName = "Manager 5", Description = "Manager quan 5", SalonId = 3, StaffType = GlobalVariables.ManagerRole},
                new Staff(){Id = 24, UserId = 61, FullName = "Stylist 51", Description = "Stylist 51", SalonId = 3, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 25, UserId = 62, FullName = "Stylist 52", Description = "Stylist 52", SalonId = 3, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 26, UserId = 63, FullName = "Beutician 51", Description = "Beautician 51", SalonId = 3, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 27, UserId = 64, FullName = "Beautician 52", Description = "Beautician 52", SalonId = 3, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 28, UserId = 65, FullName = "Manager 6", Description = "Manager quan 6", SalonId = 3, StaffType = GlobalVariables.ManagerRole},
                new Staff(){Id = 29, UserId = 66, FullName = "Stylist 61", Description = "Stylist 61", SalonId = 3, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 30, UserId = 67, FullName = "Stylist 62", Description = "Stylist 62", SalonId = 3, StaffType = GlobalVariables.StylistRole},
                new Staff(){Id = 31, UserId = 68, FullName = "Beutician 61", Description = "Beautician 61", SalonId = 3, StaffType = GlobalVariables.BeauticianRole},
                new Staff(){Id = 32, UserId = 69, FullName = "Beautician 62", Description = "Beautician 62", SalonId = 3, StaffType = GlobalVariables.BeauticianRole}
            );
            
            //Seed Customer
            builder.Entity<Customer>().HasData(
                new Customer(){Id = 7, UserId = 7, FullName = "Hồ Kim Thông"},
                new Customer(){Id = 8, UserId = 8, FullName = "Phạm Nguyên Phong"},
                new Customer(){Id = 9, UserId = 9, FullName = "Lý Thanh Thế"},
                new Customer(){Id = 10, UserId = 10, FullName = "Le thanh nghia"},
                new Customer(){Id = 11, UserId = 11, FullName = "Le thanh nghia"},
                new Customer(){Id = 12, UserId = 12, FullName = "Vo thi anh dao"},
                new Customer(){Id = 13, UserId = 13, FullName = "le thanh an"},
                new Customer(){Id = 14, UserId = 14, FullName = "le thanh an"},
                new Customer(){Id = 15, UserId = 15, FullName = "phan gia bao"},
                new Customer(){Id = 16, UserId = 16, FullName = "phan vu nhu uyen"},
                new Customer(){Id = 17, UserId = 17, FullName = "le van tan"},
                new Customer(){Id = 18, UserId = 18, FullName = "tang minh thuan"},
                new Customer(){Id = 19, UserId = 19, FullName = "Customer 3"},
                new Customer(){Id = 20, UserId = 20, FullName = "pham duy thanh"},
                new Customer(){Id = 21, UserId = 21, FullName = "dang tri hung"},
                new Customer(){Id = 22, UserId = 22, FullName = "mai thi ngoc mai"},
                new Customer(){Id = 23, UserId = 23, FullName = "dinh hao nhien"},
                new Customer(){Id = 24, UserId = 24, FullName = "do hoang khanh"},
                new Customer(){Id = 25, UserId = 25, FullName = "phan thi thu suong"},
                new Customer(){Id = 26, UserId = 26, FullName = "Ngo quynh chi"},
                new Customer(){Id = 27, UserId = 27, FullName = "pham bang bang"},
                new Customer(){Id = 28, UserId = 28, FullName = "le hoang viet nhan"},
                new Customer(){Id = 29, UserId = 29, FullName = "nguyen hoang huyen anh"},
                new Customer(){Id = 30, UserId = 30, FullName = "truong bao han"},
                new Customer(){Id = 31, UserId = 31, FullName = "long van tan"},
                new Customer(){Id = 32, UserId = 32, FullName = "ngan thanh truc"},
                new Customer(){Id = 33, UserId = 33, FullName = "ngo linh giang"},
                new Customer(){Id = 34, UserId = 34, FullName = "ho thi yen"},
                new Customer(){Id = 35, UserId = 35, FullName = "mai duy hung"},
                new Customer(){Id = 36, UserId = 36, FullName = "phung viet thong"},
                new Customer(){Id = 37, UserId = 37, FullName = "nguyen anh tuan"},
                new Customer(){Id = 38, UserId = 38, FullName = "nguyen duy phuong"},
                new Customer(){Id = 39, UserId = 39, FullName = "ngo tieu bao"},
                new Customer(){Id = 40, UserId = 40, FullName = "nguyen thi truc suong"},
                new Customer(){Id = 41, UserId = 41, FullName = "giang huu tuong"},
                new Customer(){Id = 42, UserId = 42, FullName = "nguyen gia anh"},
                new Customer(){Id = 43, UserId = 43, FullName = "phung ngoc hoa"}
                );
            
            //Seed Services
            builder.Entity<Service>().HasData
            (
                new Service(){Id = 1, Name = "Cắt tóc", Description = "Cắt tóc", Price = 50000, CreatedDate = now, LastUpdated = now, Duration = 3},
                new Service(){Id = 2, Name = "Gội Đầu", Description = "Gội Đầu", Price = 20000, CreatedDate = now, LastUpdated = now, Duration = 3},
                new Service(){Id = 3, Name = "Ráy tai", Description = "Ráy tai", Price = 10000, CreatedDate = now, LastUpdated = now, Duration = 1},
                new Service(){Id = 4, Name = "Chăm Sóc Da Mặt", Description = "Gội Đầu", Price = 20000, CreatedDate = now, LastUpdated = now, Duration = 2},
                new Service(){Id = 5, Name = "Đắp Mặt", Description = "Đắp Mặt", Price = 20000, CreatedDate = now, LastUpdated = now, Duration = 3},
                new Service(){Id = 6, Name = "Nhuộm tóc", Description = "Nhuộm tóc", Price = 150000, CreatedDate = now, LastUpdated = now, Duration = 4},
                new Service(){Id = 7, Name = "Uốn tóc", Description = "Uốn tóc", Price = 50000, CreatedDate = now, LastUpdated = now, Duration = 3},
                new Service(){Id = 8, Name = "Tạo kiểu", Description = "Tạo kiểu", Price = 20000, CreatedDate = now, LastUpdated = now, Duration = 3}
            );
            
            //Seed Combo
            builder.Entity<Combo>().HasData
            (
                new Combo(){Id = 1, Name = "Cắt Tóc",Description = "Cắt Tóc", Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now, Price = 45000, AvatarUrl = "https://placeimg.com/500/500/tech"},
                new Combo(){Id = 2, Name = "Cắt Tóc Gội Đầu",Description = "Cắt Tóc Gội Đầu", Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now, Price = 60000, AvatarUrl = "https://placeimg.com/500/500/tech"},
                new Combo(){Id = 3, Name = "Cắt Tóc Gội Đầu Chăm Sóc Da Mặt",Description = "Cắt Tóc Gội Đầu Rửa Mặt", Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now, Price = 80000, AvatarUrl = "https://placeimg.com/500/500/tech"},
                new Combo(){Id = 4, Name = "Chăm sóc đầy đử",Description = "Cắt Tóc, Ráy Táy, Gội Đầu, Rửa Mặt, Dắp mặt", Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now, Price = 100000, AvatarUrl = "https://placeimg.com/500/500/tech"},
                new Combo(){Id = 5, Name = "Cắt tóc ráy tai",Description = "Cắt Tóc, Ráy Táy", Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now, Price = 60000, AvatarUrl = "https://placeimg.com/500/500/tech"},
                new Combo(){Id = 6, Name = "Nhuộm tóc",Description = "Nhuộm tóc", Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now, Price = 140000, AvatarUrl = "https://placeimg.com/500/500/tech"},
                new Combo(){Id = 7, Name = "Uốn tóc",Description = "Uốn tóc", Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now, Price = 40000, AvatarUrl = "https://placeimg.com/500/500/tech"}
            );
            
            //Seed ComboDetail
            builder.Entity<ComboDetail>().HasData
            (
                new ComboDetail(){Id = 1,ComboId = 1, ServiceId = 1, IsDoneByStylist = true, ServiceOrder = 1},
                new ComboDetail(){Id = 2,ComboId = 2, ServiceId = 1, IsDoneByStylist = true, ServiceOrder = 1},
                new ComboDetail(){Id = 3,ComboId = 2, ServiceId = 2, IsDoneByStylist = false, ServiceOrder = 2},
                new ComboDetail(){Id = 4,ComboId = 3, ServiceId = 1, IsDoneByStylist = true, ServiceOrder = 1},
                new ComboDetail(){Id = 5,ComboId = 3, ServiceId = 2, IsDoneByStylist = false, ServiceOrder = 2},
                new ComboDetail(){Id = 6,ComboId = 3, ServiceId = 4, IsDoneByStylist = false, ServiceOrder = 3},
                new ComboDetail(){Id = 7,ComboId = 4, ServiceId = 1, IsDoneByStylist = true, ServiceOrder = 1},
                new ComboDetail(){Id = 8,ComboId = 4, ServiceId = 2, IsDoneByStylist = false, ServiceOrder = 2},
                new ComboDetail(){Id = 9,ComboId = 4, ServiceId = 3, IsDoneByStylist = false, ServiceOrder = 3},
                new ComboDetail(){Id = 10,ComboId = 4, ServiceId = 4, IsDoneByStylist = false, ServiceOrder = 4},
                new ComboDetail(){Id = 11,ComboId = 4, ServiceId = 5, IsDoneByStylist = false, ServiceOrder = 5},
                new ComboDetail(){Id = 12,ComboId = 5, ServiceId = 1, IsDoneByStylist = true, ServiceOrder = 1},
                new ComboDetail(){Id = 13,ComboId = 5, ServiceId = 3, IsDoneByStylist = false, ServiceOrder = 2}
            );
            
            //Seed SlotOfDay
            builder.Entity<SlotOfDay>().HasData
                (
                    new SlotOfDay() {Id = 1, StartTime = new TimeSpan(7,00,0), EndTime = new TimeSpan(7,10,0)},
                    new SlotOfDay() {Id = 2, StartTime = new TimeSpan(7,10,0), EndTime = new TimeSpan(7,20,0)},
                    new SlotOfDay() {Id = 3, StartTime = new TimeSpan(7,20,0), EndTime = new TimeSpan(7,30,0)},
                    new SlotOfDay() {Id = 4, StartTime = new TimeSpan(7,30,0), EndTime = new TimeSpan(7,40,0)},
                    new SlotOfDay() {Id = 5, StartTime = new TimeSpan(7,40,0), EndTime = new TimeSpan(7,50,0)},
                    new SlotOfDay() {Id = 6, StartTime = new TimeSpan(7,50,0), EndTime = new TimeSpan(8,00,0)},
                    new SlotOfDay() {Id = 7, StartTime = new TimeSpan(8,00,0), EndTime = new TimeSpan(8,10,0)},
                    new SlotOfDay() {Id = 8, StartTime = new TimeSpan(8,10,0), EndTime = new TimeSpan(8,20,0)},
                    new SlotOfDay() {Id = 9, StartTime = new TimeSpan(8,20,0), EndTime = new TimeSpan(8,30,0)},
                    new SlotOfDay() {Id = 10, StartTime = new TimeSpan(8,30,0), EndTime = new TimeSpan(8,40,0)},
                    new SlotOfDay() {Id = 11, StartTime = new TimeSpan(8,40,0), EndTime = new TimeSpan(8,50,0)},
                    new SlotOfDay() {Id = 12, StartTime = new TimeSpan(8,50,0), EndTime = new TimeSpan(9,00,0)},
                    new SlotOfDay() {Id = 13, StartTime = new TimeSpan(9,00,0), EndTime = new TimeSpan(9,10,0)},
                    new SlotOfDay() {Id = 14, StartTime = new TimeSpan(9,10,0), EndTime = new TimeSpan(9,20,0)},
                    new SlotOfDay() {Id = 15, StartTime = new TimeSpan(9,20,0), EndTime = new TimeSpan(9,30,0)},
                    new SlotOfDay() {Id = 16, StartTime = new TimeSpan(9,30,0), EndTime = new TimeSpan(9,40,0)},
                    new SlotOfDay() {Id = 17, StartTime = new TimeSpan(9,40,0), EndTime = new TimeSpan(9,50,0)},
                    new SlotOfDay() {Id = 18, StartTime = new TimeSpan(9,50,0), EndTime = new TimeSpan(10,00,0)},
                    new SlotOfDay() {Id = 19, StartTime = new TimeSpan(10,00,0), EndTime = new TimeSpan(10,10,0)},
                    new SlotOfDay() {Id = 20, StartTime = new TimeSpan(10,10,0), EndTime = new TimeSpan(10,20,0)},
                    new SlotOfDay() {Id = 21, StartTime = new TimeSpan(10,20,0), EndTime = new TimeSpan(10,30,0)},
                    new SlotOfDay() {Id = 22, StartTime = new TimeSpan(10,30,0), EndTime = new TimeSpan(10,40,0)},
                    new SlotOfDay() {Id = 23, StartTime = new TimeSpan(10,40,0), EndTime = new TimeSpan(10,50,0)},
                    new SlotOfDay() {Id = 24, StartTime = new TimeSpan(10,50,0), EndTime = new TimeSpan(11,00,0)},
                    new SlotOfDay() {Id = 25, StartTime = new TimeSpan(11,00,0), EndTime = new TimeSpan(11,10,0)},
                    new SlotOfDay() {Id = 26, StartTime = new TimeSpan(11,10,0), EndTime = new TimeSpan(11,20,0)},
                    new SlotOfDay() {Id = 27, StartTime = new TimeSpan(11,20,0), EndTime = new TimeSpan(11,30,0)},
                    new SlotOfDay() {Id = 28, StartTime = new TimeSpan(11,30,0), EndTime = new TimeSpan(11,40,0)},
                    new SlotOfDay() {Id = 29, StartTime = new TimeSpan(11,40,0), EndTime = new TimeSpan(11,50,0)},
                    new SlotOfDay() {Id = 30, StartTime = new TimeSpan(11,50,0), EndTime = new TimeSpan(12,00,0)},
                    new SlotOfDay() {Id = 31, StartTime = new TimeSpan(12,00,0), EndTime = new TimeSpan(12,10,0)},
                    new SlotOfDay() {Id = 32, StartTime = new TimeSpan(12,10,0), EndTime = new TimeSpan(12,20,0)},
                    new SlotOfDay() {Id = 33, StartTime = new TimeSpan(12,20,0), EndTime = new TimeSpan(12,30,0)},
                    new SlotOfDay() {Id = 34, StartTime = new TimeSpan(12,30,0), EndTime = new TimeSpan(12,40,0)},
                    new SlotOfDay() {Id = 35, StartTime = new TimeSpan(12,40,0), EndTime = new TimeSpan(12,50,0)},
                    new SlotOfDay() {Id = 36, StartTime = new TimeSpan(12,50,0), EndTime = new TimeSpan(13,00,0)},
                    new SlotOfDay() {Id = 37, StartTime = new TimeSpan(13,00,0), EndTime = new TimeSpan(13,10,0)},
                    new SlotOfDay() {Id = 38, StartTime = new TimeSpan(13,10,0), EndTime = new TimeSpan(13,20,0)},
                    new SlotOfDay() {Id = 39, StartTime = new TimeSpan(13,20,0), EndTime = new TimeSpan(13,30,0)},
                    new SlotOfDay() {Id = 40, StartTime = new TimeSpan(13,30,0), EndTime = new TimeSpan(13,40,0)},
                    new SlotOfDay() {Id = 41, StartTime = new TimeSpan(13,40,0), EndTime = new TimeSpan(13,50,0)},
                    new SlotOfDay() {Id = 42, StartTime = new TimeSpan(13,50,0), EndTime = new TimeSpan(14,00,0)},
                    new SlotOfDay() {Id = 43, StartTime = new TimeSpan(14,00,0), EndTime = new TimeSpan(14,10,0)},
                    new SlotOfDay() {Id = 44, StartTime = new TimeSpan(14,10,0), EndTime = new TimeSpan(14,20,0)},
                    new SlotOfDay() {Id = 45, StartTime = new TimeSpan(14,20,0), EndTime = new TimeSpan(14,30,0)},
                    new SlotOfDay() {Id = 46, StartTime = new TimeSpan(14,30,0), EndTime = new TimeSpan(14,40,0)},
                    new SlotOfDay() {Id = 47, StartTime = new TimeSpan(14,40,0), EndTime = new TimeSpan(14,50,0)},
                    new SlotOfDay() {Id = 48, StartTime = new TimeSpan(14,50,0), EndTime = new TimeSpan(15,00,0)},
                    new SlotOfDay() {Id = 49, StartTime = new TimeSpan(15,00,0), EndTime = new TimeSpan(15,10,0)},
                    new SlotOfDay() {Id = 50, StartTime = new TimeSpan(15,10,0), EndTime = new TimeSpan(15,20,0)},
                    new SlotOfDay() {Id = 51, StartTime = new TimeSpan(15,20,0), EndTime = new TimeSpan(15,30,0)},
                    new SlotOfDay() {Id = 52, StartTime = new TimeSpan(15,30,0), EndTime = new TimeSpan(15,40,0)},
                    new SlotOfDay() {Id = 53, StartTime = new TimeSpan(15,40,0), EndTime = new TimeSpan(15,50,0)},
                    new SlotOfDay() {Id = 54, StartTime = new TimeSpan(15,50,0), EndTime = new TimeSpan(16,00,0)},
                    new SlotOfDay() {Id = 55, StartTime = new TimeSpan(16,00,0), EndTime = new TimeSpan(16,10,0)},
                    new SlotOfDay() {Id = 56, StartTime = new TimeSpan(16,10,0), EndTime = new TimeSpan(16,20,0)},
                    new SlotOfDay() {Id = 57, StartTime = new TimeSpan(16,20,0), EndTime = new TimeSpan(16,30,0)},
                    new SlotOfDay() {Id = 58, StartTime = new TimeSpan(16,30,0), EndTime = new TimeSpan(16,40,0)},
                    new SlotOfDay() {Id = 59, StartTime = new TimeSpan(16,40,0), EndTime = new TimeSpan(16,50,0)},
                    new SlotOfDay() {Id = 60, StartTime = new TimeSpan(16,50,0), EndTime = new TimeSpan(17,00,0)},
                    new SlotOfDay() {Id = 61, StartTime = new TimeSpan(17,00,0), EndTime = new TimeSpan(17,10,0)},
                    new SlotOfDay() {Id = 62, StartTime = new TimeSpan(17,10,0), EndTime = new TimeSpan(17,20,0)},
                    new SlotOfDay() {Id = 63, StartTime = new TimeSpan(17,20,0), EndTime = new TimeSpan(17,30,0)},
                    new SlotOfDay() {Id = 64, StartTime = new TimeSpan(17,30,0), EndTime = new TimeSpan(17,40,0)},
                    new SlotOfDay() {Id = 65, StartTime = new TimeSpan(17,40,0), EndTime = new TimeSpan(17,50,0)},
                    new SlotOfDay() {Id = 67, StartTime = new TimeSpan(17,50,0), EndTime = new TimeSpan(18,00,0)},
                    new SlotOfDay() {Id = 68, StartTime = new TimeSpan(18,00,0), EndTime = new TimeSpan(18,10,0)},
                    new SlotOfDay() {Id = 69, StartTime = new TimeSpan(18,10,0), EndTime = new TimeSpan(18,20,0)},
                    new SlotOfDay() {Id = 70, StartTime = new TimeSpan(18,20,0), EndTime = new TimeSpan(18,30,0)},
                    new SlotOfDay() {Id = 71, StartTime = new TimeSpan(18,30,0), EndTime = new TimeSpan(18,40,0)},
                    new SlotOfDay() {Id = 72, StartTime = new TimeSpan(18,40,0), EndTime = new TimeSpan(18,50,0)},
                    new SlotOfDay() {Id = 73, StartTime = new TimeSpan(18,50,0), EndTime = new TimeSpan(19,00,0)},
                    new SlotOfDay() {Id = 74, StartTime = new TimeSpan(19,00,0), EndTime = new TimeSpan(19,10,0)},
                    new SlotOfDay() {Id = 75, StartTime = new TimeSpan(19,10,0), EndTime = new TimeSpan(19,20,0)},
                    new SlotOfDay() {Id = 76, StartTime = new TimeSpan(19,20,0), EndTime = new TimeSpan(19,30,0)},
                    new SlotOfDay() {Id = 77, StartTime = new TimeSpan(19,30,0), EndTime = new TimeSpan(19,40,0)},
                    new SlotOfDay() {Id = 78, StartTime = new TimeSpan(19,40,0), EndTime = new TimeSpan(19,50,0)},
                    new SlotOfDay() {Id = 79, StartTime = new TimeSpan(19,50,0), EndTime = new TimeSpan(20,00,0)}
                );

            #endregion SeedData

        }
    }
}