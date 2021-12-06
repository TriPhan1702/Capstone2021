using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CorePush.Google;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.UserDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.JWTToken;
using HairCutAppAPI.Utilities.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IPushNotification _pushNotification;

        public AdminController(IUserService userService, IPushNotification pushNotification)
        {
            _userService = userService;
            _pushNotification = pushNotification;
        }
        
        /// <summary>
        /// Used by admin to create other admin accounts
        /// </summary>
        [Authorize(Policy = GlobalVariables.AdministratorRole)]
        [HttpPost("create_admin")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateAdmin([FromForm]CreateUserDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CreateUserDTO;
            //Validate form
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return new CustomHttpCodeResponse(200,"", await _userService.CreateUser(dto, GlobalVariables.AdministratorRole));
        }
        
        [HttpGet("test_token")]
        public async Task<ActionResult<CustomHttpCodeResponse>> TestToken()
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            var newToken = new AuthenticationToken()
            {
                Email = "asfsdfsdf",
                Type = "asdasd",
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now
            };
            var objectString = JsonSerializer.Serialize(newToken);
            var token = EncryptString(key, objectString);
            var resultString = DecryptString(key, token);
            var resultobject = JsonSerializer.Deserialize<AuthenticationToken>(resultString);
            
            return new CustomHttpCodeResponse(200,"", resultobject);
        }
        
        private string EncryptString(string key, string plainText)  
        {  
            byte[] iv = new byte[16];  
            byte[] array;  
  
            using (Aes aes = Aes.Create())  
            {  
                aes.Key = Encoding.UTF8.GetBytes(key);  
                aes.IV = iv;  
  
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);  
  
                using (MemoryStream memoryStream = new MemoryStream())  
                {  
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))  
                    {  
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))  
                        {  
                            streamWriter.Write(plainText);  
                        }  
  
                        array = memoryStream.ToArray();  
                    }  
                }  
            }  
  
            return Convert.ToBase64String(array);  
        }  
  
        private string DecryptString(string key, string cipherText)  
        {  
            byte[] iv = new byte[16];  
            byte[] buffer = Convert.FromBase64String(cipherText);  
  
            using (Aes aes = Aes.Create())  
            {  
                aes.Key = Encoding.UTF8.GetBytes(key);  
                aes.IV = iv;  
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);  
  
                using (MemoryStream memoryStream = new MemoryStream(buffer))  
                {  
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))  
                    {  
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))  
                        {  
                            return streamReader.ReadToEnd();  
                        }  
                    }  
                }  
            }  
        }  
    }
}