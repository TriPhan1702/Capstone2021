using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.CustomerDTO;
using HairCutAppAPI.DTOs.UserDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Email;
using HairCutAppAPI.Utilities.Errors;
using HairCutAppAPI.Utilities.GoogleAuth;
using HairCutAppAPI.Utilities.JWTToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace HairCutAppAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public UserService(IRepositoryWrapper repositoryWrapper, ITokenService tokenService, IConfiguration configuration, IEmailSender emailSender, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _tokenService = tokenService;
            _configuration = configuration;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateUser(CreateUserDTO createUserDTO, string role)
        {
            //Check if User exists
            if (await UserExists(createUserDTO.Email))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Email Already Exists");
            }
            //Check if Role is valid
            if (!GlobalVariables.UserRolesWithoutSeparateTable.Contains(role.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Role invalid, must be: " + string.Join(", ", GlobalVariables.UserRolesWithoutSeparateTable));
            }
        
            // from Dto to AppUser
            var newUser = createUserDTO.ToNewUser(createUserDTO.Password, role);
        
            //Save New User to Database
            var result = await _repositoryWrapper.User.CreateAsync(newUser);
        
            return new CustomHttpCodeResponse(200, "Manager Created", result.Id);
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetUsers()
        {
            var users = await _repositoryWrapper.User.FindAllAsync();
            return new CustomHttpCodeResponse(200, "",users.ToList()); 
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetUsers(AdvancedGetUserDTO advancedGetUserDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetUserDTO.SortBy) && !AdvancedGetUserDTO.OrderingParams.Contains(advancedGetUserDTO.SortBy.ToLower()))
            {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", AdvancedGetUserDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.User.AdvancedGetUsers(advancedGetUserDTO);
            return new CustomHttpCodeResponse(200, "" , result);
        }
        
        public async Task<ActionResult<AppUser>> FindById(int id)
        {
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.Id == id);
            return user;
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> Login(LoginDTO loginDto)
        {
            //Check if user exists
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.Email.Trim() == loginDto.Email.ToLower());
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Invalid Email");
            }

            //Check Password
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (var i = 0; i < user.PasswordHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Invalid Password");
                }
            }
            
            //If Device Token exist, add to user's device
            // if (!string.IsNullOrWhiteSpace(loginDto.DeviceToken))
            // {
            //     await CheckUserDevice(loginDto, user.Id);
            // }
            
            return new CustomHttpCodeResponse(200, "User Logged in", new CurrentUserDTO()
            {
                Email = user.Email,
                Token = await _tokenService.CreateToken(user)
            });
        }
        
        // private async Task CheckUserDevice(LoginDTO loginDTO, int userId)
        // {
        //     var devices = await _repositoryWrapper.Device.FindByConditionAsync(d => d.UserId == userId);
        //     //If it hasn't existed, save to database
        //     if (devices is null)
        //     {
        //         await _repositoryWrapper.Device.CreateAsync(new Device()
        //         {
        //             Status = GlobalVariables.DeviceStatuses[0],
        //             DeviceToken = loginDTO.DeviceToken,
        //             DeviceId = loginDTO.DeviceId,
        //             UserId = userId
        //         });
        //     }
        // }
        //
        // public async Task<ActionResult<CustomHttpCodeResponse>> ForgetPassword(string email)
        // {
        //     //Search if user with this email exists
        //     var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.Email == email);
        //     if (user is null)
        //     {
        //         throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Invalid Password");
        //     }
        //     
        //     //Generate Password Reset Token
        //     var token = await _repositoryWrapper.User.GeneratePasswordResetTokenAsync(user);
        //      //Encode token again because the generated token sometimes contain special characters
        //     var validToken = EncodeToken(token);
        //     
        //     //Generate Url to change password an sen it to user's email
        //     //TODO: Change AppUrl to a valid one once the front end web site is up 
        //     var url = $"{_configuration["AppUrl"]}/ResetPassword?email={email}&token={validToken}";
        //     var message = new EmailMessage(email, "Forget Password for HairCut App", $"To change your password go to the following link: <a href='{url}'>Click Here</a>");
        //     await _emailSender.SendEmailAsync(message);
        //     return new CustomHttpCodeResponse(200, "Email Sent");
        // }
        //
        // //Reset user's password
        // public async Task<ActionResult<CustomHttpCodeResponse>> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        // {
        //     //Find if user exists
        //     var user = await _repositoryWrapper.User.FindByEmailAsync(resetPasswordDTO.Email);
        //     if (user is null)
        //     {
        //         return new BadRequestObjectResult("User with this email doesn't exist");
        //     }
        //
        //     //Change password through UserManager
        //     var result =
        //         await _repositoryWrapper.User.ResetPasswordAsync(user, DecodeToken(resetPasswordDTO.Token),
        //             resetPasswordDTO.NewPassword);
        //     if (!result.Succeeded)
        //     {
        //         return new BadRequestObjectResult(result.Errors);
        //     }
        //     return new CustomHttpCodeResponse(200,"User's Password Changed");
        // }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> LoginByGoogle(string idToken)
        {
            var idTokenResponse = await GetReponseFromGoogleAPI(idToken);
            if (string.IsNullOrWhiteSpace(idTokenResponse.Aud))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"IdToken is not valid");
            }
        
            var user = await _repositoryWrapper.User.GetUserByEmailAsync(idTokenResponse.Email);
            //Check if user is found in database
            if (user is null)
            {
                return new BadRequestObjectResult("This account doesn't exist");
                
                // from Dto to AppUser
                // var newUser = new AppUser()
                // {
                //     Role = GlobalVariables.CustomerRole,
                //     Email = idTokenResponse.Email,
                //     Status = GlobalVariables.NewUserStatus,
                //     
                // };
                //
                // var customer = new Customer()
                // {
                //     User = newUser,
                //     FullName = dto.FullName,
                // };
                //
                // //Save New User to Database
                // var result = await _repositoryWrapper.Customer.CreateAsync(customer);
                // var user =  await _repositoryWrapper.User.FindSingleByConditionAsync(u =>u.Id == result.Id);
            }
            
            //Return Ok Result
            return new CustomHttpCodeResponse(200,"",new CurrentUserDTO()
            {
                Email = user.Email,
                Token = await _tokenService.CreateToken(user)
            }); 
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> LoginByFacebook(string accessToken)
        {
            var tokenValidationResult = await ValidateFacebookAccessToken(accessToken);
        
            if (!tokenValidationResult)
            {
                return new BadRequestObjectResult("Access Token is not from a valid app");
            }
        
            var user = await CheckFacebookAccessToken(accessToken);
            if (user is null)
            {
                // return new BadRequestObjectResult("User with this email not found");
            }
            
            //Return Ok Result
            return new CustomHttpCodeResponse(200,"", new CurrentUserDTO()
            {
                Email = user.Email,
                Token = await _tokenService.CreateToken(user)
            });
        }
        
        #region private functions
        
        //Check if user exists by username and email
        private async Task<bool> UserExists(string email)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.Email == email.ToLower() || u.Email == email);
        }
        
        //Turn a token provided by Identity Framework, which sometimes has special characters into normalized token that the browser and parse
        private string EncodeToken(string token)
        {
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);
            return validToken;
        }
        
        //Turn normalized token back into the original token
        private string DecodeToken(string token)
        {
            var decodedToken = WebEncoders.Base64UrlDecode(token);
            var originalToken = Encoding.UTF8.GetString(decodedToken);
            return originalToken;
        }
        
        /// <summary>
        /// Send idToken to google api, check the response if idToken came from the right Client, and return user from database with the same email
        /// </summary>
        private async Task<GoogleIdTokenResponse> GetReponseFromGoogleAPI(string idToken)
        {
            var idTokenResponseJson = await CallSocialAuthenticationApis(_configuration["GoogleApiTokenInfoUrl"] + idToken);
            
            try
            {
                //Covert Json to IdToken
                var idTokenResponse = JsonConvert.DeserializeObject<GoogleIdTokenResponse>(idTokenResponseJson);
        
                //Check if AppId for response is the same as AppId of client app
                // if (idTokenResponse.Aud != _configuration["GoogleClientId"])
                // {
                //     throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Google API Token Info aud not containing the required client i");
                // }
                
                //Find User with the same email in database
                // return await _repositoryWrapper.User.GetUserByEmailAsync(idTokenResponse.Email);

                return idTokenResponse;
            }
        
            catch (JsonSerializationException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"UserService: Could not deserialize Json message from Google API");
            }
        }
        
        private async Task<bool> ValidateFacebookAccessToken(string accessToken)
        {
            var result = false;
            
            //Prepare Url with access token, App Id, App Secret
            var formattedUrl = string.Format(_configuration["FacebookApiTokenValidationUrl"], accessToken,
                _configuration["FacebookAppId"], _configuration["FacebookAppSecret"]);
        
            var idTokenValidationResponseJson = await CallSocialAuthenticationApis(formattedUrl);
            
            try
            {
                //Covert Json to IdToken
                var accessTokenValidationResponse = JsonConvert.DeserializeObject<FacebookTokenValidationResponse>(idTokenValidationResponseJson);
        
                //True if the app id matches
                result = accessTokenValidationResponse.Data.AppId == _configuration["FacebookAppId"];
            }
            catch (JsonSerializationException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"UserService: Could not deserialize Json message from Facebook API");
            }
        
            return result;
        }
        
        private async Task<AppUser> CheckFacebookAccessToken(string accessToken)
        {
            var url = string.Format(_configuration["FacebookApiTokenInfoUrl"] + accessToken);
        
            var accessTokenResponseJson = await CallSocialAuthenticationApis(url);
            
            try
            {
                //Covert Json
                var accessTokenResponse = JsonConvert.DeserializeObject<FacebookAccessTokenResponse>(accessTokenResponseJson);
        
                //Find User with the same email in database
                return await _repositoryWrapper.User.GetUserByEmailAsync(accessTokenResponse.Email);
            }
            catch (JsonSerializationException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"UserService: Could not deserialize Json message from Facebook API");
            }
        }
        
        /// <summary>
        /// Call api and return response as string
        /// </summary>
        private async Task<string> CallSocialAuthenticationApis(string url)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
        
        #endregion private functions
    }
}