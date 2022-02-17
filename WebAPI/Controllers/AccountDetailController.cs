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
            //User ID verilecek....
            _accountDetailService.GetUserOffer(1);
            return Ok();
        }

        [HttpGet("getuserproductoffer")]
        public IActionResult GetOffersOnUserProducts()
        {
            //User ID verilecek....
            _accountDetailService.GetOffersOnUserProducts(1);
            return Ok();
        }
    }
}
