//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System.Linq;
using System;
using System.Threading.Tasks;
using Foram.Api.Models.Foundations.Guests;

namespace Foram.Api.Services.Foundations.Guests
{
    public interface IGuestService
    {
        ValueTask<Guest> AddGuestAsync(Guest guest);
        IQueryable<Guest> RetrieveAllGuests();
        ValueTask<Guest> RetrieveGuestByIdAsync(Guid id);
        ValueTask<Guest> ModifyGuestAsync(Guest guest);
        ValueTask<Guest> RemoveGuestAsync(Guid id);
    }
}
