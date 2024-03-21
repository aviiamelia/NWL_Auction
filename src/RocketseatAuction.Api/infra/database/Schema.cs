namespace RocketseatAuction.Api.infra.database;

public class Schema
{
   public string CreateSchema()
    {
        string createTablesSql = @"
    CREATE TABLE IF NOT EXISTS ""Users"" (
        Id SERIAL PRIMARY KEY,
        Name VARCHAR(255) NOT NULL,
        Email VARCHAR(255) NOT NULL
    );

    CREATE TABLE IF NOT EXISTS ""Auctions"" (
        Id SERIAL PRIMARY KEY,
        Name VARCHAR(255) NOT NULL,
        Starts TIMESTAMP NOT NULL,
        Ends TIMESTAMP NOT NULL
    );

    CREATE TABLE IF NOT EXISTS ""Items"" (
        Id SERIAL PRIMARY KEY,
        Name VARCHAR(255) NOT NULL,
        Brand VARCHAR(255) NOT NULL,
        Condition INT NOT NULL,
        BasePrice FLOAT NOT NULL,
        AuctionId INT NOT NULL,
        FOREIGN KEY (AuctionId) REFERENCES ""Auctions""(Id)
    );

    CREATE TABLE IF NOT EXISTS ""Offers"" (
        Id SERIAL PRIMARY KEY,
        CreatedOn TIMESTAMP NOT NULL,
        Price REAL NOT NULL,
        ItemId INT NOT NULL,
        UserId INT NOT NULL,
        FOREIGN KEY (ItemId) REFERENCES ""Items""(Id),
        FOREIGN KEY (UserId) REFERENCES ""Users""(Id)
    );

";
        return createTablesSql;
    }

}
