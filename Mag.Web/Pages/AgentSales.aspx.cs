using System;

using Autofac;

using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Web.AutofacSupport;

using Newtonsoft.Json;

namespace Mag.Web.Pages
{
    public partial class AgentSales : System.Web.UI.Page
    {
        private IAgentsRepository agentsRepository;

        private ISalesRepository salesRepository;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            var container = Context.GetContainer();

            salesRepository = container.Resolve<ISalesRepository>();
            agentsRepository = container.Resolve<IAgentsRepository>();
            
        }

        protected string JsonModel
        {
            get
            {
                var model = new
                    {
                        sales = salesRepository.ReadSales(),
                        agents = agentsRepository.List()
                    };
                return JsonConvert.SerializeObject(model, Formatting.Indented);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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