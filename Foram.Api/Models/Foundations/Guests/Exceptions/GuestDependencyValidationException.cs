//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using Xeptions;

namespace Foram.Api.Models.Foundations.Guests.Exceptions
{
    public class GuestDependencyValidationException: Xeption 
    {
       public GuestDependencyValidationException(Xeption innerException)
        :base(message: "Guest dependency validation error occured, fix the error and try again",
             innerException)
        { }
    }
}
