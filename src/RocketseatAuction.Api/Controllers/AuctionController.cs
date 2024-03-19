using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.Api.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCurrentAuction()
    {
        var useCase = new GetCurrentAuctionUseCase();

        var result = useCase.Execute();

        return Ok(result);
    }
}
