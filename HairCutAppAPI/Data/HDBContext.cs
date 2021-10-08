using System;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Data
{
    //Make sure that User, Role and UserRole have int as ID
    public class HDBContext : IdentityDbContext<AppUser, AppRole, int
        , IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IPasswordHasher<AppUser> _passwordHasher;
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
        public DbSet<Crew> Crews { get; set; }
        public DbSet<CrewDetail> CrewDetails { get; set; }
        
        public HDBContext(DbContextOptions options, IPasswordHasher<AppUser> passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Relationship between in Many-Many tables
            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRole)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRole)
                .WithOne(r => r.Role)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            
            builder.Entity<Appointment>()
                .HasOne(a => a.AppointmentDetail)
                .WithOne(d => d.Appointment)
                .HasForeignKey<AppointmentDetail>(d => d.AppointmentId);
            
            builder.Entity<Appointment>()
                .HasOne(a => a.Rating)
                .WithOne(r => r.Appointment)
                .HasForeignKey<AppointmentRating>(b => b.AppointmentId);

            #region SeedData

            //Get Current time
            var now = DateTime.Now;
            
            //Seed Role
            builder.Entity<AppRole>().HasData
            (
                new AppRole() {Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR",},
                new AppRole() {Id = 2, Name = "Manager", NormalizedName = "MANAGER",},
                new AppRole() {Id = 3, Name = "Stylist", NormalizedName = "STYLIST",},
                new AppRole() {Id = 4, Name = "Beautician", NormalizedName = "BEAUTICIAN",},
                new AppRole() {Id = 5, Name = "Customer", NormalizedName = "CUSTOMER",}
            );
            
            //Seed User
            builder.Entity<AppUser>().HasData
            (
                new AppUser(){
                    Id = 1, 
                    Status = "Active",
                    UserName = "admin123",
                    NormalizedUserName = "ADMIN123", 
                    Email = "tphan2883@gmail.com", 
                    NormalizedEmail = "TPHAN2882@GMAIL.COM",
                    EmailConfirmed = false, 
                    PhoneNumber = "0869190061",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    PasswordHash = _passwordHasher.HashPassword(null,"Test123"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );
            
            //Seed Services
            builder.Entity<Service>().HasData
            (
                new Service(){Id = 1, Name = "Cắt tóc", Description = "Cắt tóc", Price = 50000, Status = GlobalVariables.ServiceStatuses[0], CreatedDate = now, LastUpdated = now},
                new Service(){Id = 2, Name = "Gội Đầu", Description = "Gội Đầu", Price = 20000, Status = GlobalVariables.ServiceStatuses[0], CreatedDate = now, LastUpdated = now},
                new Service(){Id = 3, Name = "Ráy tai", Description = "Ráy tai", Price = 10000, Status = GlobalVariables.ServiceStatuses[0], CreatedDate = now, LastUpdated = now},
                new Service(){Id = 4, Name = "Rửa Mặt", Description = "Gội Đầu", Price = 20000, Status = GlobalVariables.ServiceStatuses[0], CreatedDate = now, LastUpdated = now},
                new Service(){Id = 5, Name = "Đắp Mặt", Description = "Đắp Mặt", Price = 20000, Status = GlobalVariables.ServiceStatuses[0], CreatedDate = now, LastUpdated = now}
            );
            
            //Seed Combo
            builder.Entity<Combo>().HasData
            (
                new Combo(){Id = 1, Name = "Cắt Tóc",Description = "Cắt Tóc", Duration = 1, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now},
                new Combo(){Id = 2, Name = "Cắt Tóc Gội Đầu",Description = "Cắt Tóc Gội Đầu", Duration = 2, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now},
                new Combo(){Id = 3, Name = "Cắt Tóc Gội Đầu Rửa Mặt",Description = "Cắt Tóc Gội Đầu Rửa Mặt", Duration = 2, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now},
                new Combo(){Id = 4, Name = "Chăm sóc đầy đử",Description = "Cắt Tóc, Ráy Táy, Gội Đầu, Rửa Mặt, Dắp mặt", Duration = 3, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now},
                new Combo(){Id = 5, Name = "Cắt tóc ráy tai",Description = "Cắt Tóc, Ráy Táy", Duration = 1, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now}
            );
            
            //Seed ComboDetail
            builder.Entity<ComboDetail>().HasData
            (
                new ComboDetail(){Id = 1,ComboId = 1, ServiceId = 1},
                new ComboDetail(){Id = 2,ComboId = 2, ServiceId = 1},
                new ComboDetail(){Id = 3,ComboId = 2, ServiceId = 2},
                new ComboDetail(){Id = 4,ComboId = 3, ServiceId = 1},
                new ComboDetail(){Id = 5,ComboId = 3, ServiceId = 2},
                new ComboDetail(){Id = 6,ComboId = 3, ServiceId = 4},
                new ComboDetail(){Id = 7,ComboId = 4, ServiceId = 1},
                new ComboDetail(){Id = 8,ComboId = 4, ServiceId = 2},
                new ComboDetail(){Id = 9,ComboId = 4, ServiceId = 3},
                new ComboDetail(){Id = 10,ComboId = 4, ServiceId = 4},
                new ComboDetail(){Id = 11,ComboId = 4, ServiceId = 5},
                new ComboDetail(){Id = 12,ComboId = 5, ServiceId = 1},
                new ComboDetail(){Id = 13,ComboId = 5, ServiceId = 3}
            );
            
            //Seed SlotOfDay
            builder.Entity<SlotOfDay>().HasData
                (
                    new SlotOfDay() {Id = 1, StartTime = new TimeSpan(7,00,0), EndTime = new TimeSpan(7,30,0)},
                    new SlotOfDay() {Id = 2, StartTime = new TimeSpan(7,30,0), EndTime = new TimeSpan(8,00,0)},
                    new SlotOfDay() {Id = 3, StartTime = new TimeSpan(8,00,0), EndTime = new TimeSpan(8,30,0)},
                    new SlotOfDay() {Id = 4, StartTime = new TimeSpan(8,30,0), EndTime = new TimeSpan(9,00,0)},
                    new SlotOfDay() {Id = 5, StartTime = new TimeSpan(9,00,0), EndTime = new TimeSpan(9,30,0)},
                    new SlotOfDay() {Id = 6, StartTime = new TimeSpan(9,30,0), EndTime = new TimeSpan(10,00,0)},
                    new SlotOfDay() {Id = 7, StartTime = new TimeSpan(10,00,0), EndTime = new TimeSpan(10,30,0)},
                    new SlotOfDay() {Id = 8, StartTime = new TimeSpan(10,30,0), EndTime = new TimeSpan(11,00,0)},
                    new SlotOfDay() {Id = 9, StartTime = new TimeSpan(11,00,0), EndTime = new TimeSpan(11,30,0)},
                    new SlotOfDay() {Id = 10, StartTime = new TimeSpan(11,30,0), EndTime = new TimeSpan(12,00,0)},
                    new SlotOfDay() {Id = 11, StartTime = new TimeSpan(12,00,0), EndTime = new TimeSpan(12,30,0)},
                    new SlotOfDay() {Id = 12, StartTime = new TimeSpan(12,30,0), EndTime = new TimeSpan(13,00,0)},
                    new SlotOfDay() {Id = 13, StartTime = new TimeSpan(13,00,0), EndTime = new TimeSpan(13,30,0)},
                    new SlotOfDay() {Id = 14, StartTime = new TimeSpan(13,30,0), EndTime = new TimeSpan(14,00,0)},
                    new SlotOfDay() {Id = 15, StartTime = new TimeSpan(14,00,0), EndTime = new TimeSpan(14,30,0)},
                    new SlotOfDay() {Id = 16, StartTime = new TimeSpan(14,30,0), EndTime = new TimeSpan(15,00,0)},
                    new SlotOfDay() {Id = 17, StartTime = new TimeSpan(15,00,0), EndTime = new TimeSpan(15,30,0)},
                    new SlotOfDay() {Id = 18, StartTime = new TimeSpan(15,30,0), EndTime = new TimeSpan(16,00,0)},
                    new SlotOfDay() {Id = 19, StartTime = new TimeSpan(16,00,0), EndTime = new TimeSpan(16,30,0)},
                    new SlotOfDay() {Id = 20, StartTime = new TimeSpan(16,30,0), EndTime = new TimeSpan(17,00,0)},
                    new SlotOfDay() {Id = 21, StartTime = new TimeSpan(17,00,0), EndTime = new TimeSpan(17,30,0)},
                    new SlotOfDay() {Id = 22, StartTime = new TimeSpan(17,30,0), EndTime = new TimeSpan(18,00,0)},
                    new SlotOfDay() {Id = 23, StartTime = new TimeSpan(18,00,0), EndTime = new TimeSpan(18,30,0)},
                    new SlotOfDay() {Id = 24, StartTime = new TimeSpan(18,30,0), EndTime = new TimeSpan(19,00,0)},
                    new SlotOfDay() {Id = 25, StartTime = new TimeSpan(19,00,0), EndTime = new TimeSpan(19,30,0)},
                    new SlotOfDay() {Id = 26, StartTime = new TimeSpan(19,30,0), EndTime = new TimeSpan(20,00,0)},
                    new SlotOfDay() {Id = 27, StartTime = new TimeSpan(20,00,0), EndTime = new TimeSpan(20,30,0)}
                );
            #endregion SeedData
            
        }
    }
}