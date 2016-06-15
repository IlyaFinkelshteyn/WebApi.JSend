WebApi.JSend
=======

[![Build status](https://ci.appveyor.com/api/projects/status/oyd8ktawb0ur9ah0?svg=true)](https://ci.appveyor.com/project/sakopov/webapi-jsend)

Simple implementation of JSON responses in JSend format for ASP.NET Web API.

[More information](https://labs.omniti.com/labs/jsend) about the JSend specification.

### Installing WebApi.JSend

You should install [WebApi.JSend with NuGet](https://www.nuget.org/packages/WebApi.JSend):

    Install-Package WebApi.JSend

This command from Package Manager Console will download and install WebApi.JSend and all required dependencies.

### Using WebApi.JSend

The projects ships with `JSendApiResponseActionFilter` which wraps your response into a JSend JSON. This is all that's necessary to configure basic JSend responses:

    var config = new HttpConfiguration();

    config.Filters.Add(new JSendApiResponseActionFilter());
    
If you'd like to convert authorization errors to JSend format, add `JSendAuthorizationAttribute` either globally as shown below or on each controller/action like you would with regular `AuthorizationAttribute`.    
    
    config.Filters.Add(new JSendAuthorizationAttribute());
    
Finally, I found it handy to be able to throw exceptions from the service layer and have them convert to a JSend failure response. If you'd like this functionality simply add `ApiExceptionToJSendApiResponseActionFilter` to your filters.
    
    config.Filters.Add(new ApiExceptionToJSendApiResponseActionFilter());

You can then create your custom exception types as shown below:

    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        { }
    }
