//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using Foram.Api.Models.Foundations.Guests.Exceptions;
using Foram.Api.Models.Foundations.Guests;
using Moq;
using Xunit;
using FluentAssertions;

namespace Foram.API.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldThrowExceptionOnRetrieveByIdIfGuestIdIsInvalidAndLogItAsync()
        {
            // given
            Guid invalidGuestId = Guid.Empty;
            var invalidGuestException = new InvalidGuestException();
            invalidGuestException.AddData(key: nameof(Guest.Id), values: "Id is required");

            var guestValidationException =
                new GuestValidationException(invalidGuestException);

            // when
            ValueTask<Guest> RetrieveGuestByIdTask =
                this.guestService.RetrieveGuestByIdAsync(invalidGuestId);

            var actualGuestValidationException =
                await Assert.ThrowsAsync<GuestValidationException>(RetrieveGuestByIdTask.AsTask);

            // then 
            actualGuestValidationException.Should().BeEquivalentTo(guestValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(guestValidationException))),
                Times.Once());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectGuestByIdAsync(It.IsAny<Guid>()), Times.Never());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
