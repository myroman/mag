using System;
using System.Web.UI;

using Autofac;

using Mag.Business;
using Mag.Business.Domain;
using Mag.Web.AutofacSupport;
using Mag.Web.Business;

using Newtonsoft.Json;

namespace Mag.Web.Pages
{
    public partial class MagAnalytics : Page
    {
        private IUserServiceFacade userServiceFacade;

        protected Agent CurrentUser { get; set; }

        protected bool IsAdminNow
        {
            get { return CurrentUser != null && CurrentUser.IsAdmin.GetValueOrDefault(); }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            var container = Context.GetContainer();

            userServiceFacade = container.Resolve<IUserServiceFacade>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CurrentUser = userServiceFacade.GetCurrentUser();
        }

        protected string JsonModel
        {
            get
            {
                var model = new
                {
                    filter = Filter
                };
                return JsonConvert.SerializeObject(model, Formatting.Indented);
            }
        }

        protected object Filter
        {
            get
            {
                return new
                {
                    defaultFrom = YearBegin.ToJsDateString(),
                    defaultTo = YearEnd.ToJsDateString()
                };
            }
        }

        private DateTime YearBegin
        {
            get
            {
                var now = DateTime.Now;
                return new DateTime(now.Year, 1, 1);
            }
        }

        private DateTime YearEnd
        {
            get
            {
                var now = DateTime.Now;
                return new DateTime(now.Year, 12, 31);
            }
        }
    }
}