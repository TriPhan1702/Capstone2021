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
        
        public HDBContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            using var hmac = new HMACSHA512();
            
            builder.Entity<Appointment>()
                .HasOne(a => a.Rating)
                .WithOne(r => r.Appointment)
                .HasForeignKey<AppointmentRating>(b => b.AppointmentId);

            #region SeedData

            //Get Current time
            var now = DateTime.Now;

            //Seed Admin
            builder.Entity<AppUser>().HasData
            (
                new AppUser(){
                    Id = 1, 
                    Status = "Active",
                    Email = "tphan2883@gmail.com", 
                    PhoneNumber = "0869190061",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Test123")),
                    PasswordSalt = hmac.Key,
                    Role = GlobalVariables.ManagerRole,
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
                new Combo(){Id = 1, Name = "Cắt Tóc",Description = "Cắt Tóc", Duration = 1, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now, Price = 40000},
                new Combo(){Id = 2, Name = "Cắt Tóc Gội Đầu",Description = "Cắt Tóc Gội Đầu", Duration = 2, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now},
                new Combo(){Id = 3, Name = "Cắt Tóc Gội Đầu Rửa Mặt",Description = "Cắt Tóc Gội Đầu Rửa Mặt", Duration = 2, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now},
                new Combo(){Id = 4, Name = "Chăm sóc đầy đử",Description = "Cắt Tóc, Ráy Táy, Gội Đầu, Rửa Mặt, Dắp mặt", Duration = 3, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now},
                new Combo(){Id = 5, Name = "Cắt tóc ráy tai",Description = "Cắt Tóc, Ráy Táy", Duration = 1, Status = GlobalVariables.ComboStatuses[0],CreatedDate = now, LastUpdated = now}
            );
            
            //Seed ComboDetail
            builder.Entity<ComboDetail>().HasData
            (
                new ComboDetail(){Id = 1,ComboId = 1, ServiceId = 1, Order = 1},
                new ComboDetail(){Id = 2,ComboId = 2, ServiceId = 1, Order = 1},
                new ComboDetail(){Id = 3,ComboId = 2, ServiceId = 2, Order = 2},
                new ComboDetail(){Id = 4,ComboId = 3, ServiceId = 1, Order = 1},
                new ComboDetail(){Id = 5,ComboId = 3, ServiceId = 2, Order = 2},
                new ComboDetail(){Id = 6,ComboId = 3, ServiceId = 4, Order = 3},
                new ComboDetail(){Id = 7,ComboId = 4, ServiceId = 1, Order = 1},
                new ComboDetail(){Id = 8,ComboId = 4, ServiceId = 2, Order = 2},
                new ComboDetail(){Id = 9,ComboId = 4, ServiceId = 3, Order = 3},
                new ComboDetail(){Id = 10,ComboId = 4, ServiceId = 4, Order = 4},
                new ComboDetail(){Id = 11,ComboId = 4, ServiceId = 5, Order = 5},
                new ComboDetail(){Id = 12,ComboId = 5, ServiceId = 1, Order = 1},
                new ComboDetail(){Id = 13,ComboId = 5, ServiceId = 3, Order = 2}
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
            
            //Seed Salon
            builder.Entity<Salon>().HasData
            (
                new Salon(){Id = 1, Name = "Salon 1", Description = "Salon 1", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 2, Name = "Salon 2", Description = "Salon 2", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 3, Name = "Salon 3", Description = "Salon 3", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus},
                new Salon(){Id = 4, Name = "Salon 4", Description = "Salon 4", CreatedDate = now, LastUpdate = now, Status = GlobalVariables.NewSalonStatus}
            );

            #endregion SeedData

        }
    }
}