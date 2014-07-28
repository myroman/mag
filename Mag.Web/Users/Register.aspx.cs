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
    public partial class Register : Page
    {
        private IUserService userService;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            userService = Context.GetContainer().Resolve<IUserService>();
            btnRegister.Click += BtnRegisterOnClick;

            if (!IsPostBack)
            {
                plhError.Visible = false;
            }

            DataBind();
        }

        private void BtnRegisterOnClick(object sender, EventArgs eventArgs)
        {
            var newAgent = new Agent
                {
                    Name = txtUserName.Text,
                    Password = txtPassword.Text
                };
            try
            {
                userService.RegisterUser(newAgent);
                if (!string.IsNullOrEmpty(newAgent.PasswordHash))
                {
                    Context.Response.AppendCookie(new HttpCookie("hash", newAgent.PasswordHash));
                }
                Context.Response.Redirect("~/");
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