namespace RocketseatAuction.Api.Entities;

public class Auction
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public DateTime starts { get; set; }
    public DateTime ends { get; set; }
    public List<Item> items { get; set; } = [];
}
