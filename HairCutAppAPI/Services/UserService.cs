using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
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
using HairCutAppAPI.Utilities.ImageUpload;
using HairCutAppAPI.Utilities.JWTToken;
using Microsoft.AspNetCore.Http;
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
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IRepositoryWrapper repositoryWrapper, ITokenService tokenService, IConfiguration configuration, IEmailSender emailSender, IMapper mapper, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _tokenService = tokenService;
            _configuration = configuration;
            _emailSender = emailSender;
            _mapper = mapper;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
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
            var newUser = createUserDTO.ToNewUser(role);
            
            //If there's image
            if (createUserDTO.AvatarFile != null)
            {
                var imageUploadResult = await _photoService.AppPhotoAsync(createUserDTO.AvatarFile);
                //If there's error
                if (imageUploadResult.Error != null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,imageUploadResult.Error.Message);
                }

                newUser.AvatarUrl = imageUploadResult.SecureUrl.AbsoluteUri;
            }
        
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

            if (user.Status.ToLower() != GlobalVariables.ActiveUserStatus.ToLower())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"This account is not active");
            }
            
            if (user.Status.ToLower() == GlobalVariables.UnconfirmedUserStatus.ToLower())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"This account has not been confirmed");
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
            
            // If Device Token exist, add to user's device
             if (!string.IsNullOrWhiteSpace(loginDto.DeviceToken) && !string.IsNullOrWhiteSpace(loginDto.DeviceId))
             {
                 var devices = await _repositoryWrapper.Device.FindByConditionAsync(dev => dev.UserId == user.Id);
                 var device = devices.FirstOrDefault(dev => dev.DeviceId == loginDto.DeviceId);
                 //If hasn't had this device, register
                 if (device is null)
                 {
                     var newDevice = new Device()
                     {
                         Status = GlobalVariables.ActiveDeviceStatus,
                         DeviceId = loginDto.DeviceId,
                         DeviceToken = loginDto.DeviceToken,
                         UserId = user.Id
                     };

                     await _repositoryWrapper.Device.CreateAsync(newDevice);
                 }
                 else if (device.DeviceToken != loginDto.DeviceToken)
                 {
                     device.DeviceToken = loginDto.DeviceToken;
                     await _repositoryWrapper.Device.UpdateAsync(device, device.Id);
                 }
             }

             var result = new CurrentUserDTO()
             {
                 Email = user.Email,
                 Role = user.Role,
                 AvatarUrl = user.AvatarUrl,
                 Token = await _tokenService.CreateToken(user),
                 FullName = user.FullName
             };

             if (GlobalVariables.StaffTypes.Contains(user.Role))
             {
                 var staff = await _repositoryWrapper.Staff.FindSingleByConditionAsync(sta => sta.UserId == user.Id);
                 result.SalonId = staff.SalonId;
             }
            
            return new CustomHttpCodeResponse(200, "User Logged in", result);
        }
        
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
                // from Dto to AppUser
                var newUser = new AppUser()
                {
                    Role = GlobalVariables.CustomerRole,
                    Email = idTokenResponse.Email,
                    Status = GlobalVariables.NewUserStatus,
                    FullName = idTokenResponse.Name,
                    AvatarUrl = idTokenResponse.Picture,
                };
                
                var customer = new Customer()
                {
                    User = newUser,
                    FullName = idTokenResponse.Name,
                };
                
                //Save New User to Database
                var result = await _repositoryWrapper.Customer.CreateAsync(customer);
                var userResult =  await _repositoryWrapper.User.FindSingleByConditionAsync(u =>u.Id == result.Id);
                
                return new CustomHttpCodeResponse(200,"",new CurrentUserDTO()
                {
                    Email = userResult.Email,
                    Role = userResult.Role,
                    AvatarUrl = userResult.AvatarUrl,
                    FullName = userResult.FullName,
                    Token = await _tokenService.CreateToken(userResult)
                }); 
            }

            if (user.Status == GlobalVariables.UnconfirmedUserStatus)
            {
                user.Status = GlobalVariables.NewUserStatus;
            }

            await _repositoryWrapper.User.UpdateAsync(user, user.Id);
            
            //Return Ok Result
            return new CustomHttpCodeResponse(200,"",new CurrentUserDTO()
            {
                Email = user.Email,
                Role = user.Role,
                AvatarUrl = user.AvatarUrl,
                FullName = user.FullName,
                Token = await _tokenService.CreateToken(user)
            }); 
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> LoginByFacebook(string accessToken)
        {
            var tokenValidationResult = await ValidateFacebookAccessToken(accessToken);
            
            if (!tokenValidationResult)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Access Token is not from a valid app");
            }
        
            var facebookUserInfoResponse = await CheckFacebookAccessToken(accessToken);
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(appUser =>
                appUser.Email.ToLower() == facebookUserInfoResponse.Email);
            if (user is null)
            {
                // from Dto to AppUser
                var newUser = new AppUser()
                {
                    Role = GlobalVariables.CustomerRole,
                    Email = facebookUserInfoResponse.Email,
                    Status = GlobalVariables.NewUserStatus,
                    FullName = facebookUserInfoResponse.Name,
                    AvatarUrl = facebookUserInfoResponse.Picture,
                };
                
                var customer = new Customer()
                {
                    User = newUser,
                    FullName = facebookUserInfoResponse.Name,
                };
                
                //Save New User to Database
                var result = await _repositoryWrapper.Customer.CreateAsync(customer);
                var userResult =  await _repositoryWrapper.User.FindSingleByConditionAsync(u =>u.Id == result.Id);
                
                return new CustomHttpCodeResponse(200,"",new CurrentUserDTO()
                {
                    Email = userResult.Email,
                    Role = userResult.Role,
                    AvatarUrl = userResult.AvatarUrl,
                    FullName = userResult.FullName,
                    Token = await _tokenService.CreateToken(userResult)
                }); 
            }
            
            //Return Ok Result
            return new CustomHttpCodeResponse(200,"", new CurrentUserDTO()
            {
                Email = user.Email,
                Role = user.Role,
                AvatarUrl = user.AvatarUrl,
                FullName = user.FullName,
                Token = await _tokenService.CreateToken(user)
            });
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UploadAvatar(UploadImageDTO dto)
        {
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(appUser => appUser.Id == dto.Id);
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"User with id{dto.Id} not found");
            }

            var currentUserId = GetCurrentUserId();
            var currentUser = await 
                _repositoryWrapper.User.FindSingleByConditionAsync(appUser => appUser.Id == currentUserId);
            
            //If User is not an admin or manager, they can't upload image for others
            if (currentUser.Role!=GlobalVariables.AdministratorRole && currentUser.Role!=GlobalVariables.ManagerRole && user.Id != currentUserId)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"The current user doesn't the permission to upload the avatar of the User with the provided Id");
            }

            //Admin and Manager can't upload image for eachother
            if (currentUser.Role==GlobalVariables.ManagerRole && user.Role != GlobalVariables.StylistRole && user.Role != GlobalVariables.BeauticianRole && currentUser.Id != user.Id)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"The current user doesn't the permission to upload the avatar of the User with the provided Id");
            }
            
            var imageUploadResult = await _photoService.AppPhotoAsync(dto.ImageFile);
            //If there's error
            if (imageUploadResult.Error != null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,imageUploadResult.Error.Message);
            }

            user.AvatarUrl = imageUploadResult.SecureUrl.AbsoluteUri;
            var result = await _repositoryWrapper.User.UpdateAsync(user, user.Id);
            
            return new CustomHttpCodeResponse(200, "Avatar Uploaded", result.AvatarUrl);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UploadOwnAvatar(UploadCurrentUserAvatarDTO dto)
        {
            var currentUserId = GetCurrentUserId();
            var currentUser = await 
                _repositoryWrapper.User.FindSingleByConditionAsync(appUser => appUser.Id == currentUserId);
            var imageUploadResult = await _photoService.AppPhotoAsync(dto.ImageFile);
            
            //If there's error
            if (imageUploadResult.Error != null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,imageUploadResult.Error.Message);
            }

            currentUser.AvatarUrl = imageUploadResult.SecureUrl.AbsoluteUri;
            var result = await _repositoryWrapper.User.UpdateAsync(currentUser, currentUser.Id);
            
            return new CustomHttpCodeResponse(200, "Avatar Uploaded", result.AvatarUrl);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> DeactivateUser(int userId)
        {
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(appUser => appUser.Id == userId);
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"User with id {userId} not found");
            }

            if (user.Status.ToLower() == GlobalVariables.InActiveUserStatus.ToLower())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"User is already not active");
            }

            user.Status = GlobalVariables.InActiveUserStatus;
            var result = await _repositoryWrapper.User.UpdateAsync(user, user.Id);
            
            return new CustomHttpCodeResponse(200, "User deactivated", result.Status);
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> ActivateUser(int userId)
        {
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(appUser => appUser.Id == userId);
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"User with id {userId} not found");
            }

            if (user.Status.ToLower() == GlobalVariables.ActiveUserStatus.ToLower())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"User is already active");
            }

            user.Status = GlobalVariables.ActiveUserStatus;
            var result = await _repositoryWrapper.User.UpdateAsync(user, user.Id);
            
            return new CustomHttpCodeResponse(200, "User Activated", result.Status);
        }
        
        #region private functions
        
        private int GetCurrentUserId()
        {
            int customerId;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current customer Id
                customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return customerId;
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
        public async Task<ActionResult<CustomHttpCodeResponse>> SendConfirmEmail(string email)
        {
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(appUser =>
                appUser.Email.ToLower() == email.ToLower());
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "User not found");
            }

            if (user.Status == GlobalVariables.InActiveUserStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "This account has been deactivated");
            }
            
            if (user.Status == GlobalVariables.ActiveUserStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "This account has already been activated");
            }
            
            var key = _configuration["AuthenticationKey"];
            
            //Generate Password Reset Token
            var token = AesOperation.EncryptString(key, JsonConvert.SerializeObject(new AuthenticationToken()
            {
                Email = user.Email,
                Type = GlobalVariables.EmailConfirmationTokenType,
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(GlobalVariables.AuthenticationTokenLifeTime)
            }));
            
            //Encode token again because the generated token sometimes contain special characters
            var validToken = EncodeToken(token);
            
            //Generate Url to confirm emal an send it to user's email
            //TODO: Change AppUrl to a valid one once the front end web site is up 
            var url = $"{_configuration["AppUrl"]}/confirm_email?email={user.Email}&token={validToken}";
            var message = new EmailMessage(user.Email, "Confirm Email for HairCut App", $"To confirm your email go to the following link: <a href='{url}'>Click Here</a>");
            await _emailSender.SendEmailAsync(message);
            
            return new CustomHttpCodeResponse(200, "Email Sent");
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> ConfirmEmail(string confirmToken)
        {
            var key = _configuration["AuthenticationKey"];
            var token = DecodeToken(confirmToken);
            var decryptToken = AesOperation.DecryptString(key, token);
            var authenticationToken = JsonConvert.DeserializeObject<AuthenticationToken>(decryptToken);

            if (DateTime.Now >= authenticationToken.ExpirationDate)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"This Token has expired");
            }
            
            //Find if user exists
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(appUser => appUser.Email.ToLower() == authenticationToken.Email.ToLower());
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"User with this email doesn't exist");
            }

            user.Status = GlobalVariables.ActiveUserStatus;
            await _repositoryWrapper.User.UpdateAsync(user, user.Id);
            
            return new CustomHttpCodeResponse(200,"User's email confirmed");
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> ChangePassword()
        {
            var currentUserId = GetCurrentUserId();
            //Search if user with this email exists
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.Id == currentUserId);
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"User not found");
            }

            var key = _configuration["AuthenticationKey"];
            
            //Generate Password Reset Token
            var token = AesOperation.EncryptString(key, JsonConvert.SerializeObject(new AuthenticationToken()
            {
                Email = user.Email,
                Type = GlobalVariables.PasswordChangeTokenType,
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(GlobalVariables.AuthenticationTokenLifeTime)
            }));
            
            //Encode token again because the generated token sometimes contain special characters
            var validToken = EncodeToken(token);
            
            //Generate Url to change password an sen it to user's email
            //TODO: Change AppUrl to a valid one once the front end web site is up 
            var url = $"{_configuration["AppUrl"]}/ResetPassword?email={user.Email}&token={validToken}";
            var message = new EmailMessage(user.Email, "Change Password for HairCut App", $"To change your password go to the following link: <a href='{url}'>Click Here</a>");
            await _emailSender.SendEmailAsync(message);
            return new CustomHttpCodeResponse(200, "Email Sent");
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> ForgetPassword(string email)
        {
            //Search if user with this email exists
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.Email == email);
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"User not found");
            }

            var key = _configuration["AuthenticationKey"];
            
            //Generate Password Reset Token
            var token = AesOperation.EncryptString(key, JsonConvert.SerializeObject(new AuthenticationToken()
            {
                Email = user.Email,
                Type = GlobalVariables.PasswordChangeTokenType,
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(GlobalVariables.AuthenticationTokenLifeTime)
            }));
            
             //Encode token again because the generated token sometimes contain special characters
            var validToken = EncodeToken(token);
            
            //Generate Url to change password an sen it to user's email
            //TODO: Change AppUrl to a valid one once the front end web site is up 
            var url = $"{_configuration["AppUrl"]}/change_password?email={email}&token={validToken}";
            var message = new EmailMessage(email, "Change Password for HairCut App", $"To change your password go to the following link: <a href='{url}'>Click Here</a>");
            await _emailSender.SendEmailAsync(message);
            return new CustomHttpCodeResponse(200, "Email Sent");
        }
        
        // //Reset user's password
        public async Task<ActionResult<CustomHttpCodeResponse>> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var key = _configuration["AuthenticationKey"];
            var token = DecodeToken(resetPasswordDTO.Token);
            var decryptToken = AesOperation.DecryptString(key, token);
            var authenticationToken = JsonConvert.DeserializeObject<AuthenticationToken>(decryptToken);

            if (DateTime.Now >= authenticationToken.ExpirationDate)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"This Token has expired");
            }
            
            //Find if user exists
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(appUser => appUser.Email.ToLower() == authenticationToken.Email.ToLower());
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"User with this email doesn't exist");
            }
            
            using var hmac = new HMACSHA512();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(resetPasswordDTO.NewPassword));
            user.PasswordSalt = hmac.Key;
        
            //Change password through UserManager
            await _repositoryWrapper.User.UpdateAsync(user, user.Id);
            return new CustomHttpCodeResponse(200,"User's Password Changed");
        }
        
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
                // result = accessTokenValidationResponse.Data.AppId == _configuration["FacebookAppId"];
            }
            catch (JsonSerializationException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"UserService: Could not deserialize Json message from Facebook API");
            }
        
            return result;
        }
        
        private async Task<FacebookAccessTokenResponse> CheckFacebookAccessToken(string accessToken)
        {
            var url = string.Format(_configuration["FacebookApiTokenInfoUrl"] + accessToken);
        
            var accessTokenResponseJson = await CallSocialAuthenticationApis(url);
            
            try
            {
                //Covert Json
                return JsonConvert.DeserializeObject<FacebookAccessTokenResponse>(accessTokenResponseJson);
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