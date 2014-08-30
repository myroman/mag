using System;
using System.Web;
using System.Web.UI;

using Autofac;

using Mag.Business;
using Mag.Business.Domain;
using Mag.Web.AutofacSupport;
using Mag.Web.Business;

namespace Mag.Web.Users
{
    public partial class Login : Page
    {
        private IUserServiceFacade userServiceFacade;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            userServiceFacade = Context.GetContainer().Resolve<IUserServiceFacade>();
            Page.Title = "Вход";
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
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };
            try
            {
                userServiceFacade.LoginUser(user);
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