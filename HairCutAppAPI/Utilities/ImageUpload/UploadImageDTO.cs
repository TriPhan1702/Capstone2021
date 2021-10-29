using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.Utilities.ImageUpload
{
    public class UploadImageDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}