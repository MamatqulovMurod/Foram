//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System;
using Xeptions;

namespace Foram.Api.Models.Foundations.Guests.Exceptions
{
    public class NullGuestException: Xeption
    {
        public NullGuestException()
            :base(message: "Guest is null")
        {}
    }
}
