using Funq;

using ServiceStack;
using ServiceStack.Host;
using ServiceStack.Web;


namespace ServiceStackDisposeIssueCore592
{
  public class AppHost : AppHostBase
  {
    private bool _isDisposing;

    #region Properties

    static public AppHostBase ActiveAppHost { get; set; }

    #endregion Properties


    #region Constructors/Destructor

    public AppHost()
      : base("TestApp", typeof(AppHost).Assembly)
    {
    }

    #endregion Constructors/Destructor


    #region Public Methods

    public override IServiceRunner<TRequest> CreateServiceRunner<TRequest>(ActionContext actionContext)
    {
      return new MyServiceRunner<TRequest>(this, actionContext);
    }

    public override void Configure(Container container)
    {
      ConfigureHostConfig();

      UncaughtExceptionHandlers.Add(ExceptionHandler.GlobalExceptionHandler);

      OnDisposeCallbacks.Add(appHost => DoDispose());
    }

    #endregion Public Methods


    #region Private/Protected Methods

    private void ConfigureHostConfig()
    {
      var config = new HostConfig
      {
        ApiVersion = "1.0",
      };

      SetConfig(config);
    }

    /// <summary>
    /// Perform dispose operation.
    /// </summary>
    private void DoDispose()
    {
      if (!_isDisposing)
      {
        _isDisposing = true;
        OnDispose();
      }
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    private void OnDispose()
    {
      Dispose();
    }

    #endregion Private/Protected Methods
  }
}