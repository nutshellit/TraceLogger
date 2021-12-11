using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Nutshell.TraceLogger
{
    public class TraceLogger : ILogger
    {
        private readonly string _name;

        public TraceLogger(string name) => _name = name;

        public IDisposable BeginScope<TState>(TState state) => default!;

        public bool IsEnabled(LogLevel logLevel) =>
            logLevel != LogLevel.None;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
         
            Debug.WriteLine($"@_ [{eventId.Id,2}: {logLevel,-12}] {_name} - {formatter(state, exception)}");
        }
    }
}
