//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and peace
//=================================================
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project.Api.Models.Foundations.Guests;

namespace Project.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }

      public  async ValueTask<Guest> InsertGuestAsync(Guest guest)
        {
            using var broker=new StorageBroker(this.configuration);

            EntityEntry<Guest> guestEntityEnty = await broker.Guests.AddAsync(guest);

            await broker.SaveChangesAsync();

            return guestEntityEnty.Entity;
        }
    }
}
