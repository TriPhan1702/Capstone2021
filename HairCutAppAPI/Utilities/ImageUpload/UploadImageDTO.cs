using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.Utilities.ImageUpload
{
    public class UploadImageDTO
    {
        public int Id { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}