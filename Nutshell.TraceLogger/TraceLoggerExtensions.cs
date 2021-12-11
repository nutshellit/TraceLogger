using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Nutshell.TraceLogger
{
    public static class TraceLoggerExtensions
    {
        public static ILoggingBuilder AddTraceLogger(
            this ILoggingBuilder builder)
        {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, TraceLoggerProvider>());

            return builder;
        }
    }
}
