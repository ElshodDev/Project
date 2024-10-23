//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
// Free To use Comfort and peace
//=================================================
using Microsoft.EntityFrameworkCore;
using Project.Api.Models.Foundations.Guests;

namespace Project.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }
    }
}
