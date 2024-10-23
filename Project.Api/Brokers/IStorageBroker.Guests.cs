//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
// Free To use Comfort and peace
//=================================================
using Project.Api.Models.Foundations.Guests;

namespace Project.Api.Brokers
{
    public partial  interface IStorageBroker
    {
        ValueTask<Guest> InsertGuestAsync(Guest guest);
    }
}
