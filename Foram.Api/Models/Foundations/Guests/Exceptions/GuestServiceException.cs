﻿//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using Xeptions;

namespace Foram.Api.Models.Foundations.Guests.Exceptions
{
    public class GuestServiceException: Xeption
    {
        public GuestServiceException(Xeption innerException)
            : base(message: "Guest service error occured, contact support",
                 innerException)
        { }
    }
}
