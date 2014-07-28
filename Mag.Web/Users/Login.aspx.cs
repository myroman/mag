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

            if (!IsPostBack)
            {
                plhError.Visible = false;
            }

            DataBind();
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
                plhError.Visible = true;
                lblErrorMessage.Text = exc.Message;
            }
        }

        protected string LabelCssClass
        {
            get { return "col-lg-3 control-label"; }
        }

        protected string InputWrapperCssClass
        {
            get { return "col-lg-5"; }
        }

        protected string ValidInputCssClass
        {
            get { return "col-lg-4 valid-wrapper has-error"; }
        }
    }
}