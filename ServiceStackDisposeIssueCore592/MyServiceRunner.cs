using System;
using System.Threading.Tasks;

using ServiceStack;
using ServiceStack.Host;
using ServiceStack.Web;

namespace ServiceStackDisposeIssueCore592
{
  public class MyServiceRunner<TRequest> : ServiceRunner<TRequest>
  {
    public MyServiceRunner(IAppHost appHost, ActionContext actionContext)
        : base(appHost, actionContext)
    { }

    public override Task<object> HandleExceptionAsync(IRequest req, TRequest requestDto, Exception ex, object service)
    {
      // The following commented out code was our solution to this change in behavior.

      // Servicestack 5.12.0 is not properly disposing services after exceptions, so manually dispose of them here.
      // var disposable = service as IDisposable;
      // disposable?.Dispose();

      throw ex;
    }
  }
}
