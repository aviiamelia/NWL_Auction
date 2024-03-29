﻿using Microsoft.EntityFrameworkCore;
using RocketseatAuction.Api.Entities;

namespace RocketseatAuction.Api.Repositories;

public class RocketseatAuctionDbContext : DbContext
{

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=rocketseatauction;Username=rocketseat;Password=auction;");
    }
}
