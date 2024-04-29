//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System;
using Xeptions;

namespace Foram.Api.Models.Foundations.Guests.Exceptions
{
    public class FailedGuestStorageExceptioin : Xeption
    {
        public FailedGuestStorageExceptioin(Exception innerException)
            : base(message: "Failed guest storage error occured, contact support",
                  innerException)
        { }
    }
}
