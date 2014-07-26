using System.Net;
using System.Web;

using Newtonsoft.Json;

namespace Mag.Web.Handlers.ApiControllers
{
    public abstract class ApiControllerBase : IApiController
    {
        protected readonly HttpContext Context;

        protected ApiControllerBase(HttpContext context)
        {
            Context = context;
        }

        public abstract void ProcessRequest();

        protected void WriteObjectAndFinish(object objToWrite)
        {
            var response = JsonConvert.SerializeObject(objToWrite);

            Context.Response.Write(response);
            Context.Response.StatusCode = (int)HttpStatusCode.OK;
            Context.Response.ContentType = "text/json";
            Context.Response.End();
        }
    }
}