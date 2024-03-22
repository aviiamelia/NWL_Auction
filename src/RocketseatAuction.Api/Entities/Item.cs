using RocketseatAuction.Api.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketseatAuction.Api.Entities;

[Table("Items")]
public class Item
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string brand { get; set; } = string.Empty;
    public int condition {  get; set; }
    public float baseprice { get; set; }
    public int auctionid { get; set; }
}
