//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System;

namespace Foram.Api.Brokers.Logging
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;

        public LoggingBroker(ILogger<LoggingBroker> logger) =>
            this.logger = logger;


        public void LogError(Exception exception) =>
            this.logger.LogError(exception, exception.Message);

        public void LogCritical(Exception exception) =>
            this.logger.LogCritical(exception, exception.Message);

        public void LogWarning(Exception exception) =>
            this.logger.LogWarning(exception, exception.Message);

        public void LogInformation(Exception exception) =>
            this.logger.LogInformation(exception, exception.Message);

        public void LogDebug(Exception exception) =>
            this.logger.LogDebug(exception, exception.Message);
    }
}
