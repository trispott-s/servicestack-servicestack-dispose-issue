using ServiceStack;
using System.Runtime.Serialization;

namespace ServiceStackDisposeIssueCore
{
  [Route("/resource", "GET")]
  [DataContract]
  [Api(Description = "Gets a resource.")]
  class MyDto : IReturn<MyResponseDto>
  {
    public int MyProperty1 { get; set; }
    public string MyProperty2 { get; set; }
  }

  [DataContract]
  [Api(Description = "A resource.")]
  class MyResponseDto
  {
    public int MyProperty1 { get; set; }
    public string MyProperty2 { get; set; }
  }
}
