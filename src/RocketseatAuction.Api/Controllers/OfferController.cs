using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.Api.Comunications.Requests;

namespace RocketseatAuction.Api.Controllers;

public class OfferController : RocketSeatBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    
    public IActionResult CreateOffer([FromRoute]int itemId, [FromBody]RequestCreateOfferJson request)
    {
        return Created();
    }
}
