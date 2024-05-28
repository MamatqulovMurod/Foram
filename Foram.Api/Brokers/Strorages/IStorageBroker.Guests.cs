//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free To Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System.Linq;
using System;
using System.Threading.Tasks;
using Foram.Api.Models.Foundations.Guests;

namespace Foram.Api.Brokers.Strorages
{
    public partial interface IStorageBroker
    {
        ValueTask<Guest> InsertGuestAsync(Guest guest);
        IQueryable<Guest> SelectAllGuests();
        ValueTask<Guest> SelectGuestByIdAsync(Guid Id);
        ValueTask<Guest> UpdateGuestAsync(Guest guest);
        ValueTask<Guest> DeleteGuestAsync(Guest guest);

    }
}
