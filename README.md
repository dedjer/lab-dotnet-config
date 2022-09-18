# lab-dotnet-config
Configuration management in .NET Core 6 using [https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration]

## Prerequisites

- dotnet
- dotnet-sdk

## Goal

Setup and use .NET Core 6 ConfigurationManager to pull configuration setings from:

1. appsettings.json - using Host.CreateDefaultBuilder and WebApplication.CreateBuilder
2. appsettings.[ENVIRONEMENT].json - using WebApplication.CreateBuilder
3. Environment Variables  - using WebApplication.CreateBuilder
4. Property Files  - using WebApplication.CreateBuilder to read from appsettings.Local.json

## WebApplication Builder

We know that both the WebApplication builder object will search for the Key/Value pair across multiple sources.  This is described in: [https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0]

Excerpt:

> WebApplication.CreateBuilder initializes a new instance of the WebApplicationBuilder class with preconfigured defaults. The initialized WebApplicationBuilder (builder) provides default configuration for the app in the following order, from highest to lowest priority:
>
> - Command-line arguments using the Command-line configuration provider
> - Non-prefixed environment variables using the Non-prefixed environment variables configuration provider.
> - User secrets when the app runs in the Development environment.
> - appsettings.{Environment}.json using the JSON configuration provider. 
For example, appsettings.Production.json and appsettings.Development.json.
> - appsettings.json using the JSON configuration provider.
> - A fallback to the host configuration described in the next section.
>
> Default host configuration sources
The following list contains the default host configuration sources from highest to lowest priority:
> 
> - ASPNETCORE_-prefixed environment variables using the Environment variables configuration provider.
Command-line arguments using the Command-line configuration provider
> - DOTNET_-prefixed environment variables using the Environment variables configuration provider.
## Manual Setup

```bash
mkdir lab-dotnet-config
cd lab-dotnet-config
dotnet new webapi -o .
dotnet add package Microsoft.Extensions.Hosting
```
