using Xeptions;

namespace Foram.Api.Models.Foundations.Guests.Exceptions
{
    public class GuestDependencyServiceException: Xeption
    {
        public GuestDependencyServiceException(Xeption innerException)
          : base(message: "Guest dependancy service error occured, contact support",
               innerException)
        { }
    }
}
