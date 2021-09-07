using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAPI.Data;

namespace HairCutAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly HDBContext _context;

        public UsersController(HDBContext _context)
        {
            this._context = _context;
        }
    }
}
