//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using Foram.Api.Brokers.Strorages;
using Foram.Api.Models.Foundations.Guests;
using System.Threading.Tasks;

namespace Foram.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;



        public ValueTask<Guest> AddGuestAsync(Guest guest)=>
             this.storageBroker.InsertGuestAsync(guest);
        
    }
}
