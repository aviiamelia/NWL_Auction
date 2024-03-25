using RocketseatAuction.Api.Entities;

namespace RocketseatAuction.Api.Contracts;

public interface IITemsRepository
{

    List<Item> ListAll();

    void AddMany(List<Item> items);
}
