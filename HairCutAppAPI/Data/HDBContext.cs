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
        public DbSet<Service> Services { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<WorkSlot> WorkSlots { get; set; }
        public DbSet<SlotOfDay> SlotsOfDay { get; set; }
        public DbSet<ServicesStaffs> ServicesStaffs { get; set; }
        public DbSet<CombosServices> CombosServices { get; set; }
        public DbSet<PromotionalCode> PromotionalCodes { get; set; }
        public DbSet<CustomersCodes> CustomersCodes { get; set; }
        public DbSet<SalonsCodes> SalonsCodes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentsServices> AppointmentsServices { get; set; }
        
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
            
            builder.Entity<Staff>()
                .HasMany(ur => ur.AppointmentsServices)
                .WithOne(u => u.Staff)
                .HasForeignKey(ur => ur.StaffId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            
            builder.Entity<Appointment>()
                .HasMany(ur => ur.AppointmentsServices)
                .WithOne(u => u.Appointment)
                .HasForeignKey(ur => ur.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<Notification>()
                .HasOne(c => c.TargetUser)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            
            //Configure Composite key
            builder.Entity<AppointmentsServices>().HasKey(x => new {
                x.AppointmentId,
                x.ServiceId
            });
            builder.Entity<CombosServices>().HasKey(x => new {
                x.ComboId,
                x.ServiceId
            });
            builder.Entity<CustomersCodes>().HasKey(x => new {
                x.CustomerId,
                x.CodeId
            });
            builder.Entity<SalonsCodes>().HasKey(x => new {
                x.SalonId,
                x.CodeId
            });
            builder.Entity<ServicesStaffs>().HasKey(x => new {
                x.ServiceId,
                x.StaffId
            });
        }
    }
}