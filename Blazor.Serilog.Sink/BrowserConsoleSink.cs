using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
                    JSRuntime.Current.InvokeAsync<bool>("consoleLogFunctions.log", sw.ToString());
                }
                else
                {
                    _action(sw.ToString());
                }

            }


        }
    }
}
