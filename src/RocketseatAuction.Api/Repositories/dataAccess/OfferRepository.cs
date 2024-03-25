using RocketseatAuction.Api.Contracts;

namespace RocketseatAuction.Api.Repositories.dataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;

    public OfferRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;
    public void Add()
    {
        _dbContext.Offers.Add(offer);
        _dbContext.SaveChanges();
    }
}
