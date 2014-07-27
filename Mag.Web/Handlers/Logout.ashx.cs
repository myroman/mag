using System;
using System.Web;

namespace Mag.Web.Handlers
{
    public class Logout : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var exitCookie = new HttpCookie("hash");
            exitCookie.Expires = DateTime.Now.AddDays(-1);
            context.Response.AppendCookie(exitCookie);

            context.Response.Redirect("~/");
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}