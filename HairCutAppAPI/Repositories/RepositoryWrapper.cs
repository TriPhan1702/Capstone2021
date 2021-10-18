using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly HDBContext _context;
        private IUserRepository _user;
        private ICustomerRepository _customer;
        private IStaffRepository _staff;
        private ISalonRepository _salon;
        private IServiceRepository _service;
        private IComboRepository _combo;
        private IReviewRepository _review;
        private IDeviceRepository _device;
        private IComboDetailRepository _comboDetail;
        private ISlotOfDayRepository _slotOfDay;
        private IWorkSlotRepository _workSlot;
        private IAppointmentRepository _appointment;
        private IAppointmentDetailRepository _appointmentDetail;
        private IAppointmentRatingRepository _appointmentRating;
        private ICrewRepository _crew;
        private ICrewDetailRepository _crewDetail;

        public RepositoryWrapper( HDBContext context)
        {
            _context = context;
        }

        #region Create concrete repositories if there aren't
        
        public IUserRepository User => _user ??= new UserRepository(_context);
        public ICustomerRepository Customer => _customer ??= new CustomerRepository(_context);
        public IStaffRepository Staff => _staff ??= new StaffRepository(_context);
        public ISalonRepository Salon => _salon ??= new SalonRepository(_context);
        public IServiceRepository Service => _service ??= new ServiceRepository(_context);
        public IComboRepository Combo => _combo ??= new ComboRepository(_context);
        public IReviewRepository Review => _review ??= new ReviewRepository(_context);
        public IDeviceRepository Device => _device ??= new DeviceRepository(_context);
        public IComboDetailRepository ComboDetail => _comboDetail ??= new ComboDetailRepository(_context);
        public ISlotOfDayRepository SlotOfDay => _slotOfDay ??= new SlotOfDayRepository(_context);
        public IWorkSlotRepository WorkSlot => _workSlot ??= new WorkSlotRepository(_context);
        public IAppointmentRepository Appointment => _appointment ??= new AppointmentRepository(_context);
        public IAppointmentDetailRepository AppointmentDetail => _appointmentDetail ??= new AppointmentDetailRepository(_context);
        public IAppointmentRatingRepository AppointmentRating => _appointmentRating ??= new AppointmentRatingRepository(_context);
        public ICrewRepository Crew => _crew ??= new CrewRepository(_context);
        public ICrewDetailRepository CrewDetail => _crewDetail ??= new CrewDetailRepository(_context);
        
        #endregion Create concrete repositories if there aren't

        //For saving multiple changes, if lower than 0 -> no changes
        public async Task<bool> SaveAllAsync()
        { 
            return await _context.SaveChangesAsync() > 0;
        }
        
        public bool HasChanged()
        {
            return _context.ChangeTracker.HasChanges();
        }

        
        public void DeleteChanges()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        
    }
}