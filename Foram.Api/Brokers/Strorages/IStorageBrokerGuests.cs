//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free To Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System.Threading.Tasks;
using Foram.Api.Models.Foundations.Guests;

namespace Foram.Api.Brokers.Strorages
{
    public partial interface IStorageBrokerGuests
    {
        public ValueTask<Guest> InsertGuestAysnc(Guest guest);


    }
}
