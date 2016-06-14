WebApi.JSend
=======

Simple implementation of JSON responses in JSend format for ASP.NET Web API.

[More information](https://labs.omniti.com/labs/jsend) about the JSend specification.

### Using WebApi.JSend

	var config = new HttpConfiguration();

    config.Filters.Add(new ApiExceptionToJSendApiResponseActionFilter());
    config.Filters.Add(new JSendApiResponseActionFilter());
    config.Filters.Add(new JSendAuthorizationAttribute());

This command from Package Manager Console will download and install WebApi.JSend and all required dependencies.