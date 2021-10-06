﻿using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs
{
    public class SocialLoginDTO
    {
        [Required]
        public string Token { get; set; }
        
        [Required]
        public string Platform { get; set; }

        public string DeviceId;
        
        public string DeviceToken { get; set; }
    }
}