using RocketseatAuction.Api.Comunications.Requests;
using RocketseatAuction.Api.Entities;
using RocketseatAuction.Api.Repositories;
using RocketseatAuction.Api.Services;

namespace RocketseatAuction.Api.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    public readonly LoggedUser _loggedUser;
    public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;

    public int Execute(int itemId, RequestCreateOfferJson request)
    {

        var repository = new RocketseatAuctionDbContext();
        var loggedUser = _loggedUser.User();
        var offer = new Offer { createdon = DateTime.UtcNow,
            itemid = itemId,
            price = request.price,
            userid = loggedUser.id
        };

        repository.Offers.Add(offer);
        repository.SaveChanges();
        return offer.id;
    }
}
