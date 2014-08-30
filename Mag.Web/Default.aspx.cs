using Autofac;

using Mag.Business.Domain;
using Mag.Web.AutofacSupport;
using Mag.Web.Business;

namespace Mag.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private IUserServiceFacade userServiceFacade;

        protected Agent CurrentUser { get; set; }

        protected bool IsAdminNow
        {
            get { return CurrentUser != null && CurrentUser.IsAdmin.GetValueOrDefault(); }
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            userServiceFacade = Context.GetContainer().Resolve<IUserServiceFacade>();
            CurrentUser = userServiceFacade.GetCurrentUser();
            Page.Title = "Главная";
            DataBind();
        }

        protected string CurrentUserName
        {
            get
            {
                var currentAgent = userServiceFacade.GetCurrentUser();
                if (currentAgent == null || string.IsNullOrEmpty(currentAgent.FullName))
                {
                    return string.Empty;
                }
                return ", " + currentAgent.FullName;
            }
        }
    }
}