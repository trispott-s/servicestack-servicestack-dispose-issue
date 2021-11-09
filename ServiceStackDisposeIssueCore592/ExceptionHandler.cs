using ServiceStack;
using ServiceStack.Web;
using System;

namespace ServiceStackDisposeIssueCore592
{
  internal static class ExceptionHandler
  {
    /// <summary>
    /// Global unhandled exception handler.
    /// </summary>
    /// <param name="request">The HTTP request.</param>
    /// <param name="response">The HTTP response.</param>
    /// <param name="opName">Name of the operation.</param>
    /// <param name="exception">The exception thrown.</param>
    internal static void GlobalExceptionHandler(IRequest request, IResponse response,
      string opName, Exception exception)
    {
      try
      {
        response.StatusCode = 500;
        response.StatusDescription = "Error";
        response.ContentType = request.ResponseContentType;

        Console.WriteLine($"Exception: {exception.Message}");
      }
      catch
      {
        // ignored
      }
      finally
      {
        response.EndRequest(skipHeaders: true);
      }
    }
  }
}
