//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using Xeptions;

namespace Foram.Api.Models.Foundations.Guests.Exceptions
{
    public class GuestDependencyException: Xeption
    {
        public GuestDependencyException(Xeption innerException)
            : base(message: "Guest dependancy error occured, contact support",
                 innerException)
        { }
    }
}
