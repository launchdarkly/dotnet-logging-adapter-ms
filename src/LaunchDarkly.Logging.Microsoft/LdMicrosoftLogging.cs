using Microsoft.Extensions.Logging;

namespace LaunchDarkly.Logging
{
    /// <summary>
    /// Provides integration between the LaunchDarkly SDK's logging framework and
    /// the <c>Microsoft.Extensions.Logging</c> API.
    /// </summary>
    public static class LdMicrosoftLogging
    {
        /// <summary>
        /// A logging implementation that delegates to the <c>Microsoft.Extensions.Logging</c> framework.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is only available when your target framework is .NET Core. It causes
        /// the <c>LaunchDarkly.Logging</c> APIs to delegate to the <c>Microsoft.Extensions.Logging</c>
        /// framework. The <c>ILoggerFactory</c> is the main configuration object for
        /// <c>Microsoft.Extensions.Logging</c>; application code can construct it programmatically,
        /// or can obtain it by dependency injection. For more information, see
        /// <see href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging">Logging
        /// in .NET Core and ASP.NET Core</see>.
        /// </para>
        /// <para>
        /// The <c>Microsoft.Extensions.Logging</c> framework has its own mechanisms for filtering log
        /// output by level or other criteria. If you add a level filter with
        /// <see cref="ILogAdapterExtensions.Level(ILogAdapter, LogLevel)"/>, it will filter
        /// out messages below that level before they reach the Microsoft logger.
        /// </para>
        /// </remarks>
        /// <param name="loggerFactory">the factory object for Microsoft logging</param>
        /// <returns>a logging adapter</returns>
        public static ILogAdapter Adapter(ILoggerFactory loggerFactory) =>
            new MicrosoftLoggingAdapter(loggerFactory);
    }

    internal sealed class MicrosoftLoggingAdapter : ILogAdapter
    {
        private readonly ILoggerFactory _factory;

        internal MicrosoftLoggingAdapter(ILoggerFactory factory)
        {
            _factory = factory;
        }

        public IChannel NewChannel(string name) =>
            new ChannelImpl(_factory.CreateLogger(name));
   
        private class ChannelImpl : IChannel
        {
            private readonly ILogger _logger;

            internal ChannelImpl(ILogger logger)
            {
                _logger = logger;
            }

            private static Microsoft.Extensions.Logging.LogLevel Level(LogLevel level)
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        return Microsoft.Extensions.Logging.LogLevel.Debug;
                    case LogLevel.Info:
                        return Microsoft.Extensions.Logging.LogLevel.Information;
                    case LogLevel.Warn:
                        return Microsoft.Extensions.Logging.LogLevel.Warning;
                    case LogLevel.Error:
                        return Microsoft.Extensions.Logging.LogLevel.Error;
                    default:
                        return Microsoft.Extensions.Logging.LogLevel.None;
                }
            }

            public bool IsEnabled(LogLevel level) => _logger.IsEnabled(Level(level));

            public void Log(LogLevel level, object message)
            {
                var msLevel = Level(level);
                if (_logger.IsEnabled(msLevel))
                {
                    _logger.Log(msLevel, message.ToString(), null);
                }
            }

            public void Log(LogLevel level, string format, object param)
            {
                var msLevel = Level(level);
                if (_logger.IsEnabled(msLevel))
                {
                    _logger.Log(msLevel, format, param);
                }
            }

            public void Log(LogLevel level, string format, object param1, object param2)
            {
                var msLevel = Level(level);
                if (_logger.IsEnabled(msLevel))
                {
                    _logger.Log(msLevel, format, param1, param2);
                }
            }

            public void Log(LogLevel level, string format, params object[] allParams)
            {
                var msLevel = Level(level);
                if (_logger.IsEnabled(msLevel))
                {
                    _logger.Log(msLevel, format, allParams);
                }
            }
        }
    }
}
