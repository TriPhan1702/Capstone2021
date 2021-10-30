using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.Utilities.ImageUpload
{
    public class UploadCurrentUserAvatarDTO
    {
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}