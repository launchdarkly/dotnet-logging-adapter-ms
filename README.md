# LaunchDarkly Logging API for .NET - Microsoft.Extensions.Logging Adapter

[![NuGet](https://img.shields.io/nuget/v/LaunchDarkly.Logging.Microsoft.svg?style=flat-square)](https://www.nuget.org/packages/LaunchDarkly.Logging.Microsoft/)
[![CircleCI](https://circleci.com/gh/launchdarkly/dotnet-logging-adapter-ms.svg?style=shield)](https://circleci.com/gh/launchdarkly/dotnet-logging-adapter-ms)
[![Documentation](https://img.shields.io/static/v1?label=GitHub+Pages&message=reference&color=00add8)](https://launchdarkly.github.io/dotnet-logging-adapter-ms)

## Overview

This .NET package provides integration from the [`LaunchDarkly.Logging`](https://launchdarkly.github.io/dotnet-logging) API that is used by the LaunchDarkly [.NET SDK](https://github.com/launchdarkly/dotnet-server-sdk), [Xamarin SDK](https://github.com/launchdarkly/xamarin-client-sdk), and other LaunchDarkly libraries, to the Microsoft logging framework [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging?view=dotnet-plat-ext-5.0).

For more information and examples, see the [API documentation](https://launchdarkly.github.io/dotnet-logging-adapter-ms).

## Supported .NET versions

The 1.x version of the package, which references `Microsoft.Extensions.Logging` version 3.x, is built for two target frameworks (the only ones where `Microsoft.Extensions.Logging` 3.x is available):

* .NET Core 3.1: runs in .NET Core 3.1 and above, or in .NET 5.0 and above.
* .NET Standard 2.0: runs in .NET Core 2.x, or in .NET Framework 4.6.1 and above, or in library code that is targeted to .NET Standard 2.x.

The .NET build tools should automatically load the most appropriate build of the library for whatever platform your application or library is targeted to.

Higher major versions of `LaunchDarkly.Logging.Microsoft` can be used with later versions of `Microsoft.Extensions.Logging`.

## Contributing

See [Contributing](https://github.com/launchdarkly/dotnet-logging-adapter-ms/blob/master/CONTRIBUTING.md).

## Signing

The published version of this assembly is digitally signed with Authenticode and [strong-named](https://docs.microsoft.com/en-us/dotnet/framework/app-domains/strong-named-assemblies). Building the code locally in the default Debug configuration does not use strong-naming and does not require a key file. The public key file is in this repo at `LaunchDarkly.Logging.pk` as well as here:

```
Public Key:
2400000080040000009400000206000024000000535231410400000000010001
afcbfe1e33dbb0c823ca71ef053aed35a49a7f1e601d9ee27fe86b78062b1d83
30814ed41ccaf3817ff3f699766e5debb3dd46fd75f7439fc2fe390fcee65465
a8a17f69f1bef56e253fc9166096c907514ab74b812d041faa04712e2bcb243d
1038eed2b0023a35a41782d70c65cb4b51d189576df0b7846e9378a5d0758a39

Public Key Token: d9182e4b0afd33e7
```

## About LaunchDarkly
 
* LaunchDarkly is a continuous delivery platform that provides feature flags as a service and allows developers to iterate quickly and safely. We allow you to easily flag your features and manage them from the LaunchDarkly dashboard.  With LaunchDarkly, you can:
    * Roll out a new feature to a subset of your users (like a group of users who opt-in to a beta tester group), gathering feedback and bug reports from real-world use cases.
    * Gradually roll out a feature to an increasing percentage of users, and track the effect that the feature has on key metrics (for instance, how likely is a user to complete a purchase if they have feature A versus feature B?).
    * Turn off a feature that you realize is causing performance problems in production, without needing to re-deploy, or even restart the application with a changed configuration file.
    * Grant access to certain features based on user attributes, like payment plan (eg: users on the ‘gold’ plan get access to more features than users in the ‘silver’ plan). Disable parts of your application to facilitate maintenance, without taking everything offline.
* LaunchDarkly provides feature flag SDKs for a wide variety of languages and technologies. Check out [our documentation](https://docs.launchdarkly.com/docs) for a complete list.
* Explore LaunchDarkly
    * [launchdarkly.com](https://www.launchdarkly.com/ "LaunchDarkly Main Website") for more information
    * [docs.launchdarkly.com](https://docs.launchdarkly.com/  "LaunchDarkly Documentation") for our documentation and SDK reference guides
    * [apidocs.launchdarkly.com](https://apidocs.launchdarkly.com/  "LaunchDarkly API Documentation") for our API documentation
    * [blog.launchdarkly.com](https://blog.launchdarkly.com/  "LaunchDarkly Blog Documentation") for the latest product updates
