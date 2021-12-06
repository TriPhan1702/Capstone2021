using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.UserDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.ImageUpload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CreateUser(CreateUserDTO createUserDTO, string role);
        Task<ActionResult<CustomHttpCodeResponse>> GetUsers();
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetUsers(AdvancedGetUserDTO advancedGetUserDTO);
        Task<ActionResult<AppUser>> FindById(int id);
        Task<ActionResult<CustomHttpCodeResponse>> Login(LoginDTO loginDto);
        Task<ActionResult<CustomHttpCodeResponse>> SendConfirmEmail(string email);
        Task<ActionResult<CustomHttpCodeResponse>> ConfirmEmail(string confirmToken);
        Task<ActionResult<CustomHttpCodeResponse>> ChangePassword();
        Task<ActionResult<CustomHttpCodeResponse>> ForgetPassword(string email);
        Task<ActionResult<CustomHttpCodeResponse>> ResetPassword(ResetPasswordDTO resetPasswordDTO);
        Task<ActionResult<CustomHttpCodeResponse>> LoginByGoogle(string idToken);
        Task<ActionResult<CustomHttpCodeResponse>> LoginByFacebook(string accessToken);
        Task<ActionResult<CustomHttpCodeResponse>> UploadAvatar(UploadImageDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> UploadOwnAvatar(UploadCurrentUserAvatarDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> DeactivateUser(int userId);
        Task<ActionResult<CustomHttpCodeResponse>> ActivateUser(int userId);
    }
}