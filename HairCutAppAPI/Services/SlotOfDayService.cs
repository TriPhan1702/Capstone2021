using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SlotOfDayDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class SlotOfDayService : ISlotOfDayService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SlotOfDayService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllSlotsOfDay()
        {
            var slots = await _repositoryWrapper.SlotOfDay.FindAllAsync();
            return new CustomHttpCodeResponse(200, "", slots.Select(s => s.ToSlotOfDayDTO()).ToList());
        }
    }
}