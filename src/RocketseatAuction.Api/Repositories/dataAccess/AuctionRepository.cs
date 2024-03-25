using Microsoft.EntityFrameworkCore;
using RocketseatAuction.Api.Contracts;
using RocketseatAuction.Api.Entities;

namespace RocketseatAuction.Api.Repositories.dataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;

    public AuctionRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.UtcNow;

        var auction = _dbContext.Auctions.Include(auction => auction.items)
            .FirstOrDefault(auction => today >= auction.starts.ToUniversalTime()
            && today <= auction.ends.ToUniversalTime());

        return auction;
    }
}
