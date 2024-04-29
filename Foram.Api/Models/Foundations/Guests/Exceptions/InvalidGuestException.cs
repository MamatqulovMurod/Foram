//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using Xeptions;

namespace Foram.Api.Models.Foundations.Guests.Exceptions
{
    public class InvalidGuestException : Xeption
    {
        public InvalidGuestException()
            : base(message: "Guest is invalid")
        { }
    }
}
