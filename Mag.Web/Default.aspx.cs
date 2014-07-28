using Autofac;

using Mag.Business.Abstract;
using Mag.Web.AutofacSupport;
using Mag.Web.Business;

namespace Mag.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private IUserServiceFacade userService;

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            userService = Context.GetContainer().Resolve<IUserServiceFacade>();
        }

        protected string CurrentUser
        {
            get
            {
                var currentAgent = userService.GetCurrentUser();
                if (currentAgent == null || string.IsNullOrEmpty(currentAgent.FullName))
                {
                    return string.Empty;
                }
                return ", " + currentAgent.FullName;
            }
        }
    }
}