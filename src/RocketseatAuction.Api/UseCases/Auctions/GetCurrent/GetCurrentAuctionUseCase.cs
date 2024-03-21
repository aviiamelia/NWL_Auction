using Microsoft.EntityFrameworkCore;
using RocketseatAuction.Api.Entities;
using RocketseatAuction.Api.Repositories;

namespace RocketseatAuction.Api.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {

        var repository = new RocketseatAuctionDbContext();
        var today = DateTime.UtcNow;

        var auction = repository.Auctions.Include(auction => auction.items)
            .FirstOrDefault(auction => today >= auction.starts.ToUniversalTime() 
            && today <= auction.ends.ToUniversalTime());

        return auction;
    }
}
