using RocketseatAuction.Api.Entities;
using RocketseatAuction.Api.Repositories;

namespace RocketseatAuction.Api.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction Execute()
    {

        var repository = new RocketseatAuctionDbContext();

        var auction = repository.Auctions.First();

        return auction;
    }
}
