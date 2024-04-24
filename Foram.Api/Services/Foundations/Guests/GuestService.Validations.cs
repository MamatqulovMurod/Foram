//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using Foram.Api.Models.Foundations.Guests;
using Foram.Api.Models.Foundations.Guests.Exceptions;

namespace Foram.Api.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private void ValidateGuestNotNull(Guest guest)
        {
            if(guest is null)
            {
                throw new NullGuestException();
            }
        }
        
       
        
        


    }
}
