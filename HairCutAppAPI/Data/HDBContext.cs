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
        }
    }
}