using System.Threading.Tasks;
using HairCutAppAPI.DTOs.CrewDTOs;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface ICrewService
    {
        Task<AssignCrewResponseDTO> AssignCrew(AssignCrewDTO assignCrewDTO);
    }
}