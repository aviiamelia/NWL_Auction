using RocketseatAuction.Api.Comunications.Requests;
using RocketseatAuction.Api.Contracts;
using RocketseatAuction.Api.Entities;
using RocketseatAuction.Api.Repositories;
using RocketseatAuction.Api.Repositories.dataAccess;
using RocketseatAuction.Api.Services;

namespace RocketseatAuction.Api.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    public readonly ILoggedUser _loggedUser;
    public readonly IOfferRepository _repository;
    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository ) { 
        _loggedUser = loggedUser;
        _repository = repository;
    }


    public int Execute(int itemId, RequestCreateOfferJson request)
    {

        var repository = new RocketseatAuctionDbContext();
        var loggedUser = _loggedUser.User();
        var offer = new Offer { createdon = DateTime.UtcNow,
            itemid = itemId,
            price = request.price,
            userid = loggedUser.id
        };
        repository.Add( offer );
        return offer.id;
    }
}
