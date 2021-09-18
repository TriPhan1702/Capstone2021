using System.Threading.Tasks;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.Utilities.JWTToken
{
    public interface ITokenService
    {
        //Take in a user's information and create a token
        Task<string> CreateToken(AppUser user);
    }
}