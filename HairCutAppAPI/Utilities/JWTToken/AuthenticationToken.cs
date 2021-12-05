using System;

namespace HairCutAppAPI.Utilities.JWTToken
{
    public class AuthenticationToken
    {
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Type { get; set; }
    }
}