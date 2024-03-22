using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.Api.Comunications.Requests;
using RocketseatAuction.Api.Filters;

namespace RocketseatAuction.Api.Controllers;

public class OfferController : RocketSeatBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public IActionResult CreateOffer([FromRoute]int itemId, [FromBody]RequestCreateOfferJson request)
    {
        return Created();
    }
}
