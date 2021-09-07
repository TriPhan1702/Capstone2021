using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAPI.Entities;

namespace HairCutAPI.Interfaces
{
    interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
