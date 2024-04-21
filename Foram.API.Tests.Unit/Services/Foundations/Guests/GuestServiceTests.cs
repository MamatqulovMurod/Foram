//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using System;
using FluentAssertions;
using Foram.Api.Brokers.Logging;
using Foram.Api.Brokers.Strorages;
using Foram.Api.Models.Foundations.Guests;
using Foram.Api.Services.Foundations.Guests;
using Moq;
using Xunit;

namespace Foram.API.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.guestService =
                new GuestService(
                    storageBroker:this.storageBrokerMock.Object,
                    loggingBroker:this.loggingBrokerMock.Object );
        }

        [Fact]

        public async Task ShouldAddGuestAsync()
        {
            //Arrange 
            Guest randomGuest = new Guest()
            {
                Id = Guid.NewGuid(),
                FirstName = "Alex",
                LastName = "Doe",
                Adress = "Brooks.Str.#12",
                DateOfBirth = new DateTime(),
                Email = "ramdom@mail.ru",
                Gender = GenderType.Male,
                PhoneNumber = "12312312",
            };

            this.storageBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(randomGuest))
                .ReturnsAsync(randomGuest);

            //Act
            Guest actual = await this.guestService.AddGuestAsync(randomGuest);

            //Assert
            actual.Should().BeEquivalentTo(randomGuest);
        }
    }
}
