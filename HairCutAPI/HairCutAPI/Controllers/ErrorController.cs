using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace HairCutAPI.Controllers
{
    /// <summary>
    /// Example Controller for testing what error response will look like
    /// </summary>
    public class ErrorController : BaseApiController
    {
        private readonly HDBContext _context;

        public ErrorController(HDBContext context)
        {
            _context = context;
        }

        [HttpGet("BadRequest")]
        public ActionResult<string> GetNumber()
        {
            int number = Int32.Parse("asdasdasdasd");
            return number.ToString();
        }
    }
}
