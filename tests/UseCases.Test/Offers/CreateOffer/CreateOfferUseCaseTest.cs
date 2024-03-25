using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.Api.Comunications.Requests;
using RocketseatAuction.Api.Contracts;
using RocketseatAuction.Api.Entities;
using RocketseatAuction.Api.Services;
using RocketseatAuction.Api.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData (1)]
    public void Sucess(int itemId)
    {
        var request = new Faker<RequestCreateOfferJson>().RuleFor(request => request.price, faker => faker.Random.Decimal(1, 1231));


        var mock = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, mock.Object);
        
        var act = () => useCase.Execute(itemId, request);

        act.Should().NotThrow();

    }
}