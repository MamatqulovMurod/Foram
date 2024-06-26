﻿//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using FluentAssertions;
using Foram.Api.Models.Foundations.Guests;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace Foram.API.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {

        [Fact]
        public async Task ShouldAddGuestAsync()
        {
            //given
            Guest randomGuest = CreateRandomGuest();
            Guest inputGuest = randomGuest;
            Guest storageGuest = inputGuest;
            Guest expectedGuest = storageGuest.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(inputGuest))
                .ReturnsAsync(expectedGuest);
            //when
            Guest actualGuest =
                await this.guestService.AddGuestAsync(inputGuest);
            //then
            actualGuest.Should().BeEquivalentTo(expectedGuest);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGuestAsync(It.IsAny<Guest>()),
                Times.Once); 

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();

        }
    }
}
