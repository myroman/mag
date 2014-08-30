using System;
using System.Web.UI;

using Autofac;

using Mag.Business;
using Mag.Business.Domain;
using Mag.Web.AutofacSupport;
using Mag.Web.Business;

namespace Mag.Web.Users
{
    public partial class Register : Page
    {
        private IUserServiceFacade userServiceFacade;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.Title = "Регистрация нового пользователя";
            userServiceFacade = Context.GetContainer().Resolve<IUserServiceFacade>();
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
                Email = txtEmail.Text,
                FullName = txtFullName.Text,
                Password = txtPassword.Text,
                AccessCode = txtAccessCode.Text
            };
            try
            {
                userServiceFacade.RegisterUser(newAgent);
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