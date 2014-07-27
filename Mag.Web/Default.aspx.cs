using System;
using System.Web.UI.WebControls;

using Autofac;

using Mag.Business.Abstract;
using Mag.Web.AutofacSupport;

namespace Mag.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private IUserService userService;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            userService = Context.GetContainer().Resolve<IUserService>();

            var hashCookie = Context.Request.Cookies["hash"];
            if (hashCookie != null)
            {
                var currentUser = userService.GetCurrentUserByHash(hashCookie.Value);
                if (currentUser != null)
                {
                    CreateForCurrentUser();
                    return;
                }
            }
            CreateIfNoCurrentUser();
        }

        private void CreateForCurrentUser()
        {
            pnlUser.Controls.Add(new HyperLink
                {
                    NavigateUrl = "~/Handlers/Logout.ashx",
                    Text = "Выйти"
                });
        }

        private void CreateIfNoCurrentUser()
        {
            pnlUser.Controls.Add(new HyperLink
                {
                    NavigateUrl = "~/Users/Login.aspx",
                    Text = "Войти"
                });
            pnlUser.Controls.Add(new HyperLink
                {
                    NavigateUrl = "~/Users/Register.aspx",
                    Text = "Зарегистрироваться"
                });
        }
    }
}