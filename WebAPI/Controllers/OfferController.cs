using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost]
        public IActionResult Create(CreateOfferViewModel offer)
        {
            _offerService.Create(offer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Create(int id)
        {
            _offerService.Delete(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Create([FromBody] UpdateOfferViewModel model,int id)
        {
            _offerService.Update(model,id);
            return Ok();
        }

        [HttpPut("offeraprove/{id}")]
        public IActionResult OfferAprove(int id)
        {
            _offerService.OfferApprove(id);
            return Ok();
        }

    }
}

