# Fuyu.Launcher.Core

Contains the Launcher functionality. Can be used as a starting point if you
want to make your own launcher.

## Fuyu.Launcher.Core.Services

### ProcessService

`ProcessService` is a quick way to get a new EFT instance up and running. There
are a couple of things you need to provide:

- `cwd`: Current working directory. This is also where `EscapeFromTarkov.exe`
  must be located.
- `sessionId`: The user's login session.
- `address`: Main server address.

```cs
using System;
using Fuyu.Launcher.Core;

public class Program
{
    static void Main()
    {
        var cwd = Environment.CurrentDirectory;
        var sessionId = "1234567890abcdef";
        var address = "http://localhost:8010";

        using (var process = ProcessService.StartEft(cwd, sessionId, address))
        {
            process.Start();
        }
    }
}
```
