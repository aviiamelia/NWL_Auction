using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.Api.Comunications.Requests;
using RocketseatAuction.Api.Filters;
using RocketseatAuction.Api.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.Api.Controllers;

public class OfferController : RocketSeatBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public IActionResult CreateOffer([FromRoute]int itemId,
        [FromBody]RequestCreateOfferJson request, 
        [FromServices] CreateOfferUseCase useCase)
    {


        var id = useCase.Execute(itemId, request);
        return Created(string.Empty, id);
    }
}
