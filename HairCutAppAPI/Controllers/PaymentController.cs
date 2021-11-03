using System.Threading.Tasks;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class PaymentController : BaseApiController
    {
        /// <summary>
        /// for registered to get all payment types
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllPaymentTypes()
        {
            return new CustomHttpCodeResponse(200,"", GlobalVariables.PaymentTypes);
        }
    }
}