﻿using System;
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

            DataBind();
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
                    defaultFrom = DateHelper.YearBegin.ToJsDateString(),
                    defaultTo = DateHelper.YearEnd.ToJsDateString(),
                    quarters = new[]
                    {
                        new
                        {
                            from = DateHelper.Quart1.ToJsDateString(),
                            to = DateHelper.Quart2.AddDays(-1).ToJsDateString(),
                        },
                        new
                        {
                            from = DateHelper.Quart2.ToJsDateString(),
                            to = DateHelper.Quart3.AddDays(-1).ToJsDateString(),
                        },
                        new
                        {
                            from = DateHelper.Quart3.ToJsDateString(),
                            to = DateHelper.Quart4.AddDays(-1).ToJsDateString(),
                        },
                        new
                        {
                            from = DateHelper.Quart4.ToJsDateString(),
                            to = DateHelper.YearEnd.ToJsDateString(),
                        },
                        new
                        {
                            from = DateHelper.Quart1.ToJsDateString(),
                            to = DateHelper.YearEnd.ToJsDateString(),
                        }
                    }
                };
            }
        }
    }
}