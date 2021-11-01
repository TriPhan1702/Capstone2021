using System.Threading.Tasks;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        //For saving multiple changes
        Task<bool> SaveAllAsync();

        void DeleteChanges();

        bool HasChanged();

        IUserRepository User { get; }
        ICustomerRepository Customer { get; }
        IStaffRepository Staff { get; }
        ISalonRepository Salon { get; }
        IServiceRepository Service { get; }
        IComboRepository Combo { get; }
        IReviewRepository Review { get;}
        IDeviceRepository Device { get; }
        IComboDetailRepository ComboDetail { get; }
        ISlotOfDayRepository SlotOfDay { get; }
        IWorkSlotRepository WorkSlot { get; }
        IAppointmentRepository Appointment { get; }
        IAppointmentDetailRepository AppointmentDetail { get; }
        IAppointmentRatingRepository AppointmentRating { get; }
        IPromotionalCodeRepository PromotionalCode { get; }
        ISalonsCodesRepository SalonsCodes { get; }
        ICustomersCodesRepository CustomersCodes { get; }
        IArticleRepository Article { get; }
    }
}