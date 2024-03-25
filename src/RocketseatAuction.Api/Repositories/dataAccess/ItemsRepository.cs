using RocketseatAuction.Api.Contracts;
using RocketseatAuction.Api.Entities;

namespace RocketseatAuction.Api.Repositories.dataAccess;

public class ItemsRepository : IITemsRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;

    public ItemsRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public List<Item> ListAll()
    {

        var items = _dbContext.Items.ToList();

        return items;

    }

    public void AddMany(List<Item> items)
    {
        _dbContext.Items.AddRange(items);
        _dbContext.SaveChanges();
    }
}
