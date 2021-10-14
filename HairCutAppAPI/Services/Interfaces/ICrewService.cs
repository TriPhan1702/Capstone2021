using System.Threading.Tasks;
using HairCutAppAPI.DTOs.CrewDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface ICrewService
    {
        Task<CustomHttpCodeResponse> AssignCrew(AssignCrewDTO assignCrewDTO);
    }
}