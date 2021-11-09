Demonstration of the issue described in https://forums.servicestack.net/t/exceptions-thrown-in-services-no-longer-close-connection-after-upgrade-to-5-12/10040/2.

The projects ServiceStackDisposeIssueCore and ServiceStackDisposeIssueCore592 are identical other than their listening port and Servicestack versions. 

ServiceStackDisposeIssueCore has Servciestack version 5.12.0 and can be accessed at http://localhost:1236/resource.
ServiceStackDisposeIssueCore592 has Servciestack version 5.9.2 and can be accessed at http://localhost:1235/resource.

You can attempt to hit the endpoint for both of these (which instantly throws an exception), and observe that the Dispose method is called on in 5.9.2, but not 5.12.0 by looking at the logging written to the console. 
