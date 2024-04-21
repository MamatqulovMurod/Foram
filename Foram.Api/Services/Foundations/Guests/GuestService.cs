//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using Foram.Api.Brokers.Logging;
using Foram.Api.Brokers.Strorages;
using Foram.Api.Models.Foundations.Guests;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Threading.Tasks;

namespace Foram.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(IStorageBroker storageBroker)
        {
        }

        public GuestService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }


        public async ValueTask<Guest> AddGuestAsync(Guest guest)
        {
            this.loggingBroker.LogError(new Exception("somothing"));

            return await this.storageBroker.InsertGuestAsync(guest);
        }
    }
}
