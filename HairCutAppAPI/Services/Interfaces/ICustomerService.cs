﻿using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ActionResult<CurrentUserDTO>> Register(CreateCustomerDto dto);
    }
}