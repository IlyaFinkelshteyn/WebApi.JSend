using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi.JSend
{
    public class JSendAuthorizationAttribute : AuthorizeAttribute
    {
        private const string DefaultMessage = "Authorization has been denied for this request.";

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new JSendApiResonse(JSendStatus.Fail, null, DefaultMessage));
        }
    }
}