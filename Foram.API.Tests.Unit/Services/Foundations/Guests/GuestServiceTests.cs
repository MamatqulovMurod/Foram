//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using System.Linq.Expressions;
using System.Runtime.Serialization;
using Foram.Api.Brokers.Logging;
using Foram.Api.Brokers.Strorages;
using Foram.Api.Models.Foundations.Guests;
using Foram.Api.Services.Foundations.Guests;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

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
                    storageBroker: this.storageBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object);
        }


        private static Guest CreateRandomGuest() =>
            CreateGuestFiller(date: GetRandomDateTimeOffset()).Create();


        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();



        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 9).GetValue();


        private static string GetRandomString() =>
            new MnemonicString().GetValue();


        private static SqlException GetSqlError() =>
            (SqlException)FormatterServices.GetSafeUninitializedObject(typeof(SqlException));


        private static T GetInvalidEnum<T>()
        {
             int randomNumer = GetRandomNumber();

            while(Enum.IsDefined(typeof (T), randomNumer)is true)
            {
                randomNumer = GetRandomNumber();
            }

            return (T)(object)randomNumer;
        }


        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);
        

        private static Filler<Guest> CreateGuestFiller(DateTimeOffset date)
        {
            var filler = new Filler<Guest>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
