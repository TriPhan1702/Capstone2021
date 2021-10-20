using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.StaffDTOs;
using HairCutAppAPI.DTOs.UserDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        private readonly HDBContext _hdbContext;
        
        public StaffRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<Staff> GetStaffDetail(int userId)
        {
            return await _hdbContext.Staff.Include(staff => staff.User).FirstOrDefaultAsync(staff => staff.UserId == userId);
        }

        public async Task<PagedList<AdvancedGetStaffResponseDTO>> AdvancedGetStaffs(AdvancedGetStaffDTO advancedGetStaffsDTO)
        {
            var query = _hdbContext.Staff.Include(staff => staff.User).Include(staff => staff.Salon).AsQueryable();
            //If There's UserId Filtering
            if (advancedGetStaffsDTO.UserIds != null && advancedGetStaffsDTO.UserIds.Any())
            {
                query = query.Where(staff => advancedGetStaffsDTO.UserIds.Contains(staff.UserId));
            }
            //If There's StaffId Filtering
            if (advancedGetStaffsDTO.StaffIds != null && advancedGetStaffsDTO.StaffIds.Any())
            {
                query = query.Where(staff => advancedGetStaffsDTO.StaffIds.Contains(staff.Id));
            }
            //If There's SalonId Filtering
            if (advancedGetStaffsDTO.SalonIds != null && advancedGetStaffsDTO.SalonIds.Any())
            {
                query = query.Where(staff => advancedGetStaffsDTO.SalonIds.Contains(staff.Salon.Id));
            }
            //If There's FullName Filtering
            if (!string.IsNullOrWhiteSpace(advancedGetStaffsDTO.FullName))
            {
                query = query.Where(staff => advancedGetStaffsDTO.FullName.ToLower().Contains(staff.FullName.ToLower()));
            }
            //If There's SalonName Filtering
            if (!string.IsNullOrWhiteSpace(advancedGetStaffsDTO.SalonName))
            {
                query = query.Where(staff => advancedGetStaffsDTO.SalonName.ToLower().Contains(staff.Salon.Name.ToLower()));
            }
            //If There's SalonName Filtering
            if (!string.IsNullOrWhiteSpace(advancedGetStaffsDTO.Email))
            {
                query = query.Where(staff => advancedGetStaffsDTO.Email.ToLower().Contains(staff.User.Email.ToLower()));
            }
            //If there's StaffType filtering
            if (advancedGetStaffsDTO.StaffTypes != null && advancedGetStaffsDTO.StaffTypes.Any())
            {
                query = query.Where(staff => advancedGetStaffsDTO.StaffTypes.Select(type=>type.ToLower()).Contains(staff.StaffType.ToLower()));
            }
            //If there's status filtering
            if (advancedGetStaffsDTO.Statuses != null && advancedGetStaffsDTO.Statuses.Any())
            {
                query = query.Where(staff => advancedGetStaffsDTO.Statuses.Select(status=>status.ToLower()).Contains(staff.User.Status.ToLower()));
            }
            

            //If there's sorting
            if (!string.IsNullOrWhiteSpace(advancedGetStaffsDTO.SortBy))
            {
                query = advancedGetStaffsDTO.SortBy switch
                {
                    "userid_asc" => query.OrderBy(staff => staff.UserId),
                    "userid_desc" => query.OrderByDescending(staff => staff.UserId),
                    "fullname_asc" => query.OrderBy(staff => staff.FullName),
                    "fullname_desc" => query.OrderByDescending(staff => staff.FullName),
                    "staffid_asc" => query.OrderBy(staff => staff.Id),
                    "staffid_desc" => query.OrderByDescending(staff => staff.Id),
                    "salonid_asc" => query.OrderBy(staff => staff.SalonId),
                    "salonid_desc" => query.OrderByDescending(staff => staff.SalonId),
                    "salonname_asc" => query.OrderBy(staff => staff.Salon.Name),
                    "salonname_desc" => query.OrderByDescending(staff => staff.Salon.Name),
                    "email_asc" => query.OrderBy(staff => staff.User.Email),
                    "email_desc" => query.OrderByDescending(staff => staff.User.Email),
                    "status_asc"  => query.OrderBy(staff => staff.User.Status),
                    "status_desc" => query.OrderByDescending(staff => staff.User.Status),
                    "stafftypes_asc"  => query.OrderBy(staff => staff.StaffType),
                    "stafftype_desc" => query.OrderByDescending(staff => staff.StaffType),
                    _ => query
                };
            }
            
            return await PagedList<AdvancedGetStaffResponseDTO>.CreateAsync(query.Select(staff => staff.ToAdvancedGetStaffResponseDTO()), advancedGetStaffsDTO.PageNumber,
                advancedGetStaffsDTO.PageSize);
        }
    }
}