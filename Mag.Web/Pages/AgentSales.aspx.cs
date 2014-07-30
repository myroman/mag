using System;

using Autofac;

using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Web.AutofacSupport;
using Mag.Web.Business;

using Newtonsoft.Json;

namespace Mag.Web.Pages
{
    public partial class AgentSales : System.Web.UI.Page
    {
        private IAgentsRepository agentsRepository;

        private ISalesRepository salesRepository;

        private IUserServiceFacade userServiceFacade;

        private Agent currentAgent;

        protected bool IsAdminNow
        {
            get { return currentAgent != null && currentAgent.IsAdmin.GetValueOrDefault(); }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            var container = Context.GetContainer();

            salesRepository = container.Resolve<ISalesRepository>();
            agentsRepository = container.Resolve<IAgentsRepository>();
            userServiceFacade = container.Resolve<IUserServiceFacade>();
            currentAgent = userServiceFacade.GetCurrentUser();
        }

        protected string JsonModel
        {
            get
            {
                var model = new
                    {
                        sales = salesRepository.ReadSales(),
                        agents = agentsRepository.List(),
                        isAdminNow = IsAdminNow
                    };
                return JsonConvert.SerializeObject(model, Formatting.Indented);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!userServiceFacade.IsAuthenticated(Context))
            {
                Response.Redirect("~/");
                return;
            }
            DataBind();
        }

        protected Sale GetSale(object item)
        {
            return (Sale)item;
        }

        protected string FullAgentName(object item)
        {
            var sale = GetSale(item);
            if (sale.Agent != null)
            {
                return sale.Agent.FullName;
            }
            return string.Empty;
        }
    }
}