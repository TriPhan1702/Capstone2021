using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAPI.Entities;

namespace HairCutAPI.Interfaces
{
    public interface ITokenService
    {
        //Take in a user's information and create a token
        Task<string> CreateToken(AppUser user);
    }
}
