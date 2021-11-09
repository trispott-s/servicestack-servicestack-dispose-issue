using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ServiceStackDisposeIssueCore592
{
  class Program
  {
    private static IWebHost _webHost;

    static void Main(string[] args)
    {
      _webHost = BuildWebHost<Startup>();
      _webHost.Start();

      var listeningAddress = _webHost.ServerFeatures.Get<IServerAddressesFeature>().Addresses.Single();
      Console.WriteLine($"Listening on: {listeningAddress}");

      Console.ReadLine();
    }

    /// <summary>
    /// Builds the web host.
    /// </summary>
    internal static IWebHost BuildWebHost<StartUpType>() where StartUpType : class
    {
      var contentRootPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
      var webHostBuilder =
        WebHost.CreateDefaultBuilder()
        .ConfigureAppConfiguration((hostingContext, config) => config.Sources.Clear())
        .ConfigureLogging(loggingBuilder => loggingBuilder.ClearProviders())
        .UseContentRoot(contentRootPath)
        .UseStartup<StartUpType>();

      webHostBuilder
      .UseKestrel(options =>
      {
          options.ListenLocalhost(1235);
      });

      return webHostBuilder.Build();
    }
  }
}
