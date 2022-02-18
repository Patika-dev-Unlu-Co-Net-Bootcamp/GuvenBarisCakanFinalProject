using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailController : ControllerBase
    {
        private readonly IAccountDetailService _accountDetailService;

        public AccountDetailController(IAccountDetailService accountDetailService)
        {
            _accountDetailService = accountDetailService;
        }

        [HttpGet("getuseroffers")]
        public IActionResult GetUserOffer()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            return Ok(_accountDetailService.GetUserOffer(userId));
        }

        [HttpGet("getuserproductoffer")]
        public IActionResult GetOffersOnUserProducts()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            return Ok(_accountDetailService.GetOffersOnUserProducts(userId));

        }
    }
}
