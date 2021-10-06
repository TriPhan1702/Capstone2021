using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string DeviceId { get; set; }
        
        public string DeviceToken { get; set; }
    }
}