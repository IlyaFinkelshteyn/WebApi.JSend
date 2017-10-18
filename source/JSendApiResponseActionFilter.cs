using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System;

namespace WebApi.JSend
{
    public class JSendApiResponseActionFilter : ActionFilterAttribute
    {
        private const string DefaultMessage = "There was a problem with the request.";

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var response = actionExecutedContext.Response;

            var hasCustomMediaTypeResponse = response?.Content?.Headers?.ContentType?.MediaType != null
                    && !string.Equals(response.Content.Headers.ContentType.MediaType, "application/json", StringComparison.InvariantCultureIgnoreCase);

            if (response == null || hasCustomMediaTypeResponse)
            {
                base.OnActionExecuted(actionExecutedContext);
                return;
            }

            object content;

            response.TryGetContentValue(out content);

            if (response.IsSuccessStatusCode)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(response.StatusCode, new JSendApiResonse(JSendStatus.Success, content));
                return;
            }

            var error = content as HttpError;

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(response.StatusCode, error == null
                ? new JSendApiResonse(JSendStatus.Fail, content, DefaultMessage)
                : new JSendApiResonse(JSendStatus.Fail, error.ModelState, error.Message));
        }
    }
}