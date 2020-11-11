using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.LoggerMonadTests
{
    #pragma warning disable CA1062 // Validate arguments of public methods
    public class TestLogger : ILogger
    {
        public IList<String> LoggedValues { get; }

        public TestLogger()
        {
            LoggedValues = new List<String>();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, String> formatter)
        {
            String loggedValue = formatter(state, exception);
            LoggedValues.Add(loggedValue);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public Boolean IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }
    }
    #pragma warning restore CA1062 // Validate arguments of public methods
}
