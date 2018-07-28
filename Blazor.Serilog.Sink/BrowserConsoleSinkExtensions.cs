using System;
using Serilog;
using Serilog.Configuration;
using Serilog.Formatting.Display;

namespace Blazor.Serilog.Sink
{
    public static class BrowserConsoleSinkExtensions
    {
        const string DefaultOutputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";

        public static LoggerConfiguration BrowserConsoleSink(this LoggerSinkConfiguration sinkConfig,
           string outputTemplate = DefaultOutputTemplate, IFormatProvider formatProvider = null, Action<string> action = null)
        {
            if (sinkConfig == null)
                throw new ArgumentException(nameof(sinkConfig));
            if (outputTemplate == null)
                throw new ArgumentException(nameof(outputTemplate));

            var formatter = new MessageTemplateTextFormatter(outputTemplate, formatProvider);

            return sinkConfig.Sink(new BrowserConsoleSink(formatter, action));
        }
    }
}