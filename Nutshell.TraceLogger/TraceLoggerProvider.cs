using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Nutshell.TraceLogger
{
    [ProviderAlias("TraceLogger")]
    public sealed class TraceLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, TraceLogger> _loggers = new ConcurrentDictionary<string, TraceLogger>();

        public TraceLoggerProvider()
        {
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new TraceLogger(name));


        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
