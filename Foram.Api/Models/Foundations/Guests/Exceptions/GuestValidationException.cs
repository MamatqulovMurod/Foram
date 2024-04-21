//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using Xeptions;

namespace Foram.Api.Models.Foundations.Guests.Exceptions
{
    public class GuestValidationException: Xeption
    {
        public GuestValidationException(Xeption innerException)
            : base(message: "Guest Validation occured fix the error and try again",
                  innerException)
        {}
    }
}
