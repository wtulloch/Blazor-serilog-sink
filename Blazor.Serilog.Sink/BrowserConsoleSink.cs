using System;
using System.IO;
using System.Text;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Microsoft.JSInterop;

namespace Blazor.Serilog.Sink
{
    public class BrowserConsoleSink : ILogEventSink
    {
        private readonly ITextFormatter _formatter;
        private readonly Action<string> _action;

        public BrowserConsoleSink(ITextFormatter formatter, Action<string> action = null)
        {
            _formatter = formatter;
            _action = action;
           
        }
        public void Emit(LogEvent logEvent)
        {
            
            using (var sw = new StringWriter(new StringBuilder(256)))
            {
               _formatter.Format(logEvent, sw);
                sw.Flush();
                if (_action == null)
                {

                    InvokeConsoleLog(sw.ToString(), logEvent.Level);
                }
                else
                {
                    _action(sw.ToString());
                }
            }
        }

        private void InvokeConsoleLog(string message, LogEventLevel logEventLevel)
        {
            var logFunctionToCall = "consoleLogFunctions.log";

            switch (logEventLevel)
            {
                case LogEventLevel.Verbose:
                case LogEventLevel.Debug:
                case LogEventLevel.Information:
                    break;
                case LogEventLevel.Warning:
                    logFunctionToCall = "consoleLogFunctions.warning";
                    break;
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    logFunctionToCall = "consoleLogFunctions.error";
                    break;
                default:
                    break;
            }

            JSRuntime.Current.InvokeAsync<bool>(logFunctionToCall, message);

        }
    }
}
