﻿//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================


using Foram.Api.Models.Foundations.Guests;
using Foram.Api.Models.Foundations.Guests.Exceptions;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace Foram.API.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]

        public async Task ShouldThrowCriticalDependencyExceptionOnAddIfSqlErrorOccursAndLogItAsync()
        {
            //given
            Guest someGuest = CreateRandomGuest();
            SqlException sqlException = GetSqlError();
            var  failedGuestStorageExceptioin = new FailedGuestStorageExceptioin(sqlException);
            
            var expectedGuestDependencyException =
                new GuestDependencyException(failedGuestStorageExceptioin); 

            this.storageBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(someGuest))
                .Throws(sqlException);

            //when
            ValueTask<Guest> addGuestTask =
                this.guestService.AddGuestAsync(someGuest);

            //then
            await Assert.ThrowsAsync<GuestDependencyException>(() =>
            addGuestTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(someGuest),
             Times.Once);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogCritical(It.Is(SameExceptionAs(
                expectedGuestDependencyException))),
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}