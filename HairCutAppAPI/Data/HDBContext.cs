using System;
using HairCutAppAPI.Entities;
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
        
        public HDBContext(DbContextOptions options) : base(options)
        {
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
            builder.Entity<AppRole>().HasData
            (
                new AppRole() {Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR",},
                new AppRole() {Id = 2, Name = "Manager", NormalizedName = "MANAGER",},
                new AppRole() {Id = 3, Name = "Stylist", NormalizedName = "STYLIST",},
                new AppRole() {Id = 4, Name = "Beautician", NormalizedName = "BEAUTICIAN",},
                new AppRole() {Id = 5, Name = "Customer", NormalizedName = "CUSTOMER",}
            );
            
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