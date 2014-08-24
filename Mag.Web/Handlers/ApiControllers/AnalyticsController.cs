using System.Web;

using Mag.Business.Abstract;
using Mag.Business.Domain.Analytics;

using Newtonsoft.Json;

namespace Mag.Web.Handlers.ApiControllers
{
    public class AnalyticsController : ApiControllerBase
    {
        private readonly IAnalyticsSelector analyticsSelector;

        public AnalyticsController(HttpContext context, IAnalyticsSelector analyticsSelector) : base(context)
        {
            this.analyticsSelector = analyticsSelector;
        }

        public override void ProcessRequest()
        {
            var action = Context.Request["action"];
            switch (action)
            {
                case "list":
                    GetReport();
                    break;
            }
        }

        private void GetReport()
        {
            var filterRaw = Context.Request["object"];
            var filter = JsonConvert.DeserializeObject<AnalyticsSelectionFilter>(filterRaw);
            var results = analyticsSelector.CalculateReport(filter);

            WriteObjectAndFinish(results);
        }
    }
}