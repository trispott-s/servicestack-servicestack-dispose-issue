using ServiceStack;
using System;

namespace ServiceStackDisposeIssueCore
{
  /// <summary>
  /// A Service Implementation
  /// </summary>
  class MyService : Service
  {
    /// <summary>
    /// An endpoint.
    /// </summary>
    public MyResponseDto Get(MyDto requestDto)
    {
      // Intentionally throw error to demonstrate issue.
      throw new Exception("Exception from GET MyService MyDto");
    }

    /// <summary>
    /// Dispose override to log whether Dispose is hit at all.
    /// </summary>
    public override void Dispose()
    {
      // This line will be hit in 5.9.2, but not in 5.12.0.
      // In 5.12.0, this service never disposes on exception.
      Console.WriteLine($"Disposing {nameof(MyService)}");
      base.Dispose();
    }
  }
}
