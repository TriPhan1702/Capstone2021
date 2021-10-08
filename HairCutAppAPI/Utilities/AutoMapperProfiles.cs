using AutoMapper;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateCustomerDto, AppUser>().ForMember(des=>des.UserName, 
                opt=>opt.MapFrom(u=>u.UserName.ToLower()));
            
        }
    }
}