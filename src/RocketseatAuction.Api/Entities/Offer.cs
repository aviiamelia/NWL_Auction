namespace RocketseatAuction.Api.Entities;

public class Offer
{
    public int id {  get; set; }
    public DateTime createdon { get; set; }
    public decimal price { get; set; } 
    public int itemid { get; set; } 
    public int userid { get; set; } 

}
