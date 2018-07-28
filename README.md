# Blazor-serilog-sink
This is blazor component/Serilog sink that uses Serilog to write out to the browser console.
It is really nothing more than an experiment in adding a third-party library to a blazor component.
The current version is written using Blazor 0.5.1.

## Usage
In your Blazor client application add the following to Program.Main().
```
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.BrowserConsoleSink(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj} {SourceContext}{NewLine}{Exception}"
                )
                .CreateLogger();
```
Then anyway within your code you can use Log to log out to the browser console. For example: Log.Information("this is a test message").

## Caveat:
This is a really, really rough implementation. Don't say you haven't been warned.



