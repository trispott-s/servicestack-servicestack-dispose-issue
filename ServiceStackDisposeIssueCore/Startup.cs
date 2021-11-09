using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ServiceStack;

namespace ServiceStackDisposeIssueCore
{
  /// <summary>
  /// Responsible for configuring the applications services and processing pipeline.
  /// </summary>
  public class Startup
  {
    #region Properties

    public IConfiguration Configuration { get; }

    #endregion Properties


    #region Constructors

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="configuration">The application configuration properties.</param>
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    #endregion Constructors


    #region Public Methods

    /// <summary>
    /// Called by the runtime.  Used to configure the applications HTTP request pipeline.
    /// </summary>
    /// <param name="app">The application request pipeline configuration.</param>
    /// <param name="hostingEnvironment">The hosting environment the application is running in.</param>
    public void Configure(IApplicationBuilder app, IHostingEnvironment hostingEnvironment)
    {
      if (hostingEnvironment.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      AppHost.ActiveAppHost = new AppHost { AppSettings = new NetCoreAppSettings(Configuration) };

      app.UseServiceStack(AppHost.ActiveAppHost);
    }

    #endregion Public Methods
  }
}
