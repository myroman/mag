using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Autofac;

using Mag.Business.Abstract;
using Mag.Web.AutofacSupport;
using Mag.Web.Business;

namespace Mag.Web
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";

        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";

        private string antiXsrfTokenValue;

        private IUserServiceFacade userServiceFacade;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            userServiceFacade = Context.GetContainer().Resolve<IUserServiceFacade>();

            if (!userServiceFacade.IsAuthenticated(Context))
            {
                CreateForCurrentUser();
                return;
            }
            CreateIfNoCurrentUser();
        }

        private void CreateForCurrentUser()
        {
            var li = CreateLi();
            li.Controls.Add(new HyperLink
            {
                NavigateUrl = "~/Handlers/Logout.ashx",
                Text = "Выйти"
            });
            plhUser.Controls.Add(li);
        }

        private Control CreateLi()
        {
            return new HtmlGenericControl("li");
        }

        private void CreateIfNoCurrentUser()
        {
            var li = CreateLi();
            li.Controls.Add(new HyperLink
                {
                    NavigateUrl = "~/Users/Login.aspx",
                    Text = "Войти"
                });
            plhUser.Controls.Add(li);
            li = CreateLi();
            li.Controls.Add(new HyperLink
                {
                    NavigateUrl = "~/Users/Register.aspx",
                    Text = "Зарегистрироваться"
                });
            plhUser.Controls.Add(li);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                    {
                        HttpOnly = true,
                        Value = antiXsrfTokenValue
                    };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}