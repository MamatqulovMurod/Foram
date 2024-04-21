﻿//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================


using Foram.Api.Models.Foundations.Guests;
using Foram.Api.Models.Foundations.Guests.Exceptions;
using Xunit;

namespace Foram.API.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task SfouldThrowValidationExeptionOnAddIfGustIsNullAndLogitAysnc()
        {
            //given
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();
            var expectedGuestGuestValidationException =
                new GuestValidationException(nullGuestException);

            //when
            ValueTask<Guest> addGuestTask =
                this.guestService.AddGuestAsync(nullGuest);

            //then
            await Assert.ThrowsAsync<GuestValidationException>(() =>
            addGuestTask.AsTask());


        }
    }
}
A