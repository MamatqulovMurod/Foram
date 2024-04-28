//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System.Threading.Tasks;
using Foram.Api.Models.Foundations.Guests;
using Foram.Api.Models.Foundations.Guests.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Xeptions;

namespace Foram.Api.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private delegate ValueTask<Guest> ReturningGuestFunction();

        private async ValueTask<Guest> TryCatch(ReturningGuestFunction returnigGuestFunction)
        {
            try
            {
                return await returnigGuestFunction();
            }

            catch (NullGuestException nullGuestExection)
            {

                throw CreateAndLogValidationException(nullGuestExection);
            }
            catch(InvalidGuestException invalidGuestException)
            {
                throw CreateAndLogValidationException(invalidGuestException);
            }
            catch(SqlException sqlException)
            {
                var failedGuestSrorageException = new FailedGuestStorageExceptioin(sqlException);

                throw CreateAndLogCriticalDependencyException(failedGuestSrorageException);
            }
        }

        private GuestValidationException CreateAndLogValidationException(Xeption exception)
        {
            var guestValidationException =
                    new GuestValidationException(exception);

            this.loggingBroker.LogError(guestValidationException);

            return guestValidationException;
        }

        private GuestDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var guestDependencyExceptoin = new GuestDependencyException(exception);
            this.loggingBroker.LogCritical(guestDependencyExceptoin);

            return guestDependencyExceptoin;
        }

    }
}
