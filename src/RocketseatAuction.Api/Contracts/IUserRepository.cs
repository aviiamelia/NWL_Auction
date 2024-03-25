using RocketseatAuction.Api.Entities;

namespace RocketseatAuction.Api.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User FindUser(string email);

    List<User> ListAll();

    void AddMany(List<User> users);
}
