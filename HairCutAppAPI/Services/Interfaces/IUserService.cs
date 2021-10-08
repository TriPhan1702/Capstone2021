using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<int>> CreateUser(CreateUserDTO createUserDTO, string role);
        Task<ActionResult<IEnumerable<AppUser>>> GetUsers();
        Task<ActionResult<AppUser>> FindById(int id);
        Task<ActionResult<UserDTO>> Login(LoginDTO loginDto);
        Task<ActionResult> ForgetPassword(string email);
        Task<ActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO);
        Task<ActionResult<UserDTO>> LoginByGoogle(string idToken);
        Task<ActionResult<UserDTO>> LoginByFacebook(string accessToken);
    }
}