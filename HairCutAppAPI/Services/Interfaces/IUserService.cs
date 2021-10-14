using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CreateUser(CreateUserDTO createUserDTO, string role);
        Task<ActionResult<CustomHttpCodeResponse>> GetUsers();
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetUsers(PaginationParams paginationParams);
        Task<ActionResult<AppUser>> FindById(int id);
        Task<ActionResult<CustomHttpCodeResponse>> Login(LoginDTO loginDto);
        Task<ActionResult<CustomHttpCodeResponse>> ForgetPassword(string email);
        Task<ActionResult<CustomHttpCodeResponse>> ResetPassword(ResetPasswordDTO resetPasswordDTO);
        Task<ActionResult<CustomHttpCodeResponse>> LoginByGoogle(string idToken);
        Task<ActionResult<CustomHttpCodeResponse>> LoginByFacebook(string accessToken);
    }
}