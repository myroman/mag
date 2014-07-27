using System;
using System.Web;
using System.Web.UI;

using Autofac;

using Mag.Business;
using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Web.AutofacSupport;

namespace Mag.Web.Users
{
    public partial class Login : Page
    {
        private IUserService userService;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            userService = Context.GetContainer().Resolve<IUserService>();

            btnSubmit.Click += BtnSubmitOnClick;
        }

        private void BtnSubmitOnClick(object sender, EventArgs eventArgs)
        {
            var user = new Agent
                {
                    Name = txtUserName.Text,
                    Password = txtPassword.Text
                };
            try
            {
                userService.Login(user);

                Response.AppendCookie(new HttpCookie("hash", user.PasswordHash));
                Response.Redirect("~/");
            }
            catch (DomainException exc)
            {
                lblError.Text = exc.Message;
            }
        }
    }
}