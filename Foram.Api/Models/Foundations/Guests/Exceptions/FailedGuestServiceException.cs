//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System;
using Xeptions;

namespace Foram.Api.Models.Foundations.Guests.Exceptions
{
    public class FailedGuestServiceException: Xeption 
    {
        public FailedGuestServiceException(Exception innerException)
            :base(message:"Failed guest service error occured, contanct support",
                 innerException)
        { }
    }

}
