using Npgsql;
using RocketseatAuction.Api.Contracts;
using RocketseatAuction.Api.Entities;


namespace RocketseatAuction.Api.infra.database;

public class Database
{
    private readonly IUserRepository _userRepository;
    private readonly IITemsRepository _itemsRepository;


    public Database(IUserRepository repository, IITemsRepository itemRepository) {
        _userRepository = repository;
        _itemsRepository = itemRepository;
    }


    public void Main()
    {
        try {
            var schema = new Schema();
            var connString = "Host=localhost;Username=rocketseat;Password=auction;Database=rocketseatauction";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string createSchemaSql = "CREATE SCHEMA IF NOT EXISTS rocketseat;";
                using (var cmd = new NpgsqlCommand(createSchemaSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string createTableSql = schema.CreateSchema();

                Console.WriteLine(createTableSql);

                using (var cmd = new NpgsqlCommand(createTableSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
   
            }

        }
        catch(Exception e) 
        { 
            Console.WriteLine("An error occurred: " + e.Message); 
        }
     
    }
    public void Populate()
    {
        var items = _itemsRepository.ListAll();
        if (items.Count == 0)
        {
            List<Item> itemsToAdd = new List<Item>
            {
                new Item { id = 1, name = "Galaxy S21", brand = "Samsung", condition = 0, baseprice = 800.0f, auctionid = 1 },
                new Item { id = 2, name = "Macbook Pro", brand = "Apple", condition = 1, baseprice = 1000.0f, auctionid = 1 },
                new Item { id = 3, name = "Camera Canon EOS", brand = "Canon", condition = 2, baseprice = 1200.0f, auctionid = 1 },
                new Item { id = 4, name = "Headphone WH-1000XM5", brand = "Sony", condition = 1, baseprice = 200.0f, auctionid = 1 },
                new Item { id = 5, name = "Nintendo Switch OLED", brand = "Nintendo", condition = 0, baseprice = 80.0f, auctionid = 1 },
                new Item { id = 6, name = "Drone com Camera Mavic Air 2", brand = "DJI", condition = 2, baseprice = 700.0f, auctionid = 1 },
                new Item { id = 7, name = "Kindle Paperwhite 2022", brand = "Amazon", condition = 0, baseprice = 50.0f, auctionid = 1 }
            };
            _itemsRepository.AddMany(items);
        }
        var users = _userRepository.ListAll();
        if (users.Count == 0)
        {
            List<User> usersToAdd = new List<User>
            {
                new User { id = 1, name = "Cristiano", email = "cristiano@cristiano.com" },
                new User { id = 2, name = "Tatiana", email = "tatiana@tatiana.com" },
                new User { id = 3, name = "Lucimar", email = "lucimar@lucimar.com" }
            };
            _userRepository.AddMany(usersToAdd);
        }
    }
}
