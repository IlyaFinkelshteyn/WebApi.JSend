using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebApi.JSend
{
    public class ApiExceptionToJSendApiResponseActionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ApiException)
            {
                var exception = context.Exception as ApiException;

                context.Response = context.Request.CreateResponse(exception.StatusCode, new JSendApiResonse(JSendStatus.Fail, null, exception.Message));
            }
            else
            {
                var exception = context.Exception;

#if DEBUG
                var message = string.Format("{0} {1}", exception.Message, exception.StackTrace);
#else

                var message = exception.Message;
#endif

                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, new JSendApiResonse(JSendStatus.Error, null, message));
            }
        }
    }
}