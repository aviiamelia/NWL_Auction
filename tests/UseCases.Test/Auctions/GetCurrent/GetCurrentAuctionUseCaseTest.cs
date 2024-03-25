using FluentAssertions;
using Moq;
using RocketseatAuction.Api.Contracts;
using RocketseatAuction.Api.UseCases.Auctions.GetCurrent;
using Xunit;
using RocketseatAuction.Api.Entities;
using Bogus;
using System.Diagnostics;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Sucess()
    {
        var testAuction = new Faker<Auction>().RuleFor(auction => auction.id, faker => faker.Random.Number(1, 10)).
            RuleFor(auciton => auciton.name, faker => faker.Lorem.Word()).
            RuleFor(auciton => auciton.ends, faker => faker.Date.Future()).
            RuleFor(auciton => auciton.starts, faker => faker.Date.Past()).
            RuleFor(auciton => auciton.items, faker => new List<Item>
            {
                new Item
                {
                    id = faker.Random.Number(1,10),
                    name = faker.Lorem.Word(),
                    brand = faker.Commerce.Department(),
                    baseprice = (float)faker.Random.Decimal(10,1928731923),
                    condition = faker.Random.Number(0,2),
                    auctionid = faker.Random.Number(1,1298371),
                }
            }).Generate();
            ;


        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(testAuction);

        var useCase = new GetCurrentAuctionUseCase(mock.Object);


        var auciton = useCase.Execute();
        Debug.WriteLine(auciton);
        Debug.WriteLine("ssssssssssssssssssssssssssssssssssssssssssssssssssss");

        auciton.Should().NotBeNull();
        auciton?.id.Should().Be(testAuction.id);
        auciton?.name.Should().Be(testAuction.name);

    }
}
