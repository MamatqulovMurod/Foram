//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System;

namespace Foram.Api.Brokers.Logging
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);

        void LogCritical(Exception exception);


    }
}
