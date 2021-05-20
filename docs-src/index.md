This .NET package provides integration from the [`LaunchDarkly.Logging`](https://launchdarkly.github.io/dotnet-logging) API that is used by the LaunchDarkly [.NET SDK](https://github.com/launchdarkly/dotnet-server-sdk), [Xamarin SDK](https://github.com/launchdarkly/xamarin-client-sdk), and other LaunchDarkly libraries, to the Microsoft logging framework [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging?view=dotnet-plat-ext-5.0).

This adapter is published as a separate NuGet package to avoid unwanted dependencies on `Microsoft.Extensions.Logging` in the LaunchDarkly SDKs and in applications that do not use that framework.

The [`LaunchDarkly.Logging`](https://launchdarkly.github.io/dotnet-logging/) also contains a version of this adapter, `Logs.CoreLogging`, which was implemented only in the .NET Core target framework and always uses version 5.x of `Microsoft.Extensions.Logging`. `LaunchDarkly.Logging.Microsoft` is the more broadly compatible version of that.

## Usage

The **<xref:LaunchDarkly.Logging.LdMicrosoftLogging>** adapter is provided by the NuGet package [**`LaunchDarkly.Logging.Microsoft`**](https://nuget.org/packages/LaunchDarkly.Logging.Microsoft). Version 2.x of the package works with `Microsoft.Extensions.Logging` version 5.x. New versions of `LaunchDarkly.Logging.Microsoft` will be released as necessary to support higher versions of `Microsoft.Extensions.Logging` as they become available.

Like `LaunchDarkly.Logging`, `Microsoft.Extensions.Logging` is a facade that can delegate to various destinations. These are configured with the [`LoggerFactory`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggerfactory?view=dotnet-plat-ext-5.0) or by dependency injection mechanisms that provide an `ILoggerFactory`. 

`LaunchDarkly.Logging` already has adapters of its own for some of the same basic destinations that `Microsoft.Extensions.Logging` can write to. For instance, to send log output from LaunchDarkly components to the console, or to a file, you do not need to use `Microsoft.Extensions.Logging`; you can simply use the methods in `LaunchDarkly.Logging.Logs`. This adapter is mainly useful if you require the more advanced configuration that `Microsoft.Extensions.Logging` provides, or if you have an application that is already using `Microsoft.Extensions.Logging`.

To use the adapter:

1. Add the NuGet package `LaunchDarkly.Logging.Microsoft` to your project. Make sure you also have a dependency on a compatible version of [`Microsoft.Extensions.Logging`](https://nuget.org/packages/Microsoft.Extensions.Logging).

2. Use the property [**LdMicrosoftLogging.Adapter**](xref:LaunchDarkly.Logging.LdMicrosoftLogging.Adapter) in any LaunchDarkly library configuration that accepts a `LaunchDarkly.Logging.ILogAdapter` object. It requires an `ILoggerFactory`, which in .NET Core is often obtained by dependency injection. For instance, if you are configuring the LaunchDarkly .NET SDK in a component that uses dependency injection:

```csharp
using LaunchDarkly.Logging;
using LaunchDarkly.Sdk.Server;
using Microsoft.Extensions.Logging;

public class MyApplicationComponent
{
    private LdClient ldClient;

    public MyApplicationComponent(ILoggerFactory loggerFactory)
    {
        var config = Configuration.Builder("my-sdk-key")
            .Logging(LdMicrosoftLogging.Adapter(loggerFactory))
            .Build();
        ldClient = new LdClient(config);
    }
}
```
