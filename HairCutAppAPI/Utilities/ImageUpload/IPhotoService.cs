using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.Utilities.ImageUpload
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AppPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}