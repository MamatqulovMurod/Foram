//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================


using Foram.Api.Models.Foundations.Guests;
using Foram.Api.Models.Foundations.Guests.Exceptions;
using Moq;
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
            var expectedGuestValidationException =
                new GuestValidationException(nullGuestException);

            //when
            ValueTask<Guest> addGuestTask =
                this.guestService.AddGuestAsync(nullGuest);

            //then
            await Assert.ThrowsAsync<GuestValidationException>(() =>
            addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedGuestValidationException))),
            Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(It.IsAny<Guest>()),
            Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
