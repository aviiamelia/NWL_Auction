using RocketseatAuction.Api.Contracts;
using RocketseatAuction.Api.Entities;

namespace RocketseatAuction.Api.Repositories.dataAccess;

public class UserRepository : IUserRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;

    public UserRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;
    public bool ExistUserWithEmail(string email)
    {
       return _dbContext.Users.Any(user => user.email.Equals(email));
    }

    public User FindUser(string email)
    {
        var user = _dbContext.Users.First(user => user.email.Equals(email));
        return user;
    }

    public List<User> ListAll()
    {

        var users = _dbContext.Users.ToList();

        return users;

    }

    public void AddMany(List<User> users)
    {
        _dbContext.Users.AddRange(users);
        _dbContext.SaveChanges();
    }
}
