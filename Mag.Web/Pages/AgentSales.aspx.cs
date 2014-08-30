﻿using System;

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

        private IInsuranceTypesRepository insuranceTypesRepository;

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

            agentsRepository = container.Resolve<IAgentsRepository>();
            userServiceFacade = container.Resolve<IUserServiceFacade>();
            insuranceTypesRepository = container.Resolve<IInsuranceTypesRepository>();
        }

        protected string JsonModel
        {
            get
            {
                var model = new
                    {
                        sales = userServiceFacade.GetSalesForCurrentUser(),
                        agents = agentsRepository.List(),
                        isAdminNow = IsAdminNow,
                        currentUser = CurrentUser,
                        insuranceTypes = insuranceTypesRepository.List()
                    };
                
                return JsonConvert.SerializeObject(model, Formatting.Indented);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CurrentUser = userServiceFacade.GetCurrentUser();
            SetupTitle();
            if (!userServiceFacade.IsAuthenticated(Context))
            {
                Response.Redirect("~/");
                return;
            }
            DataBind();
        }

        private void SetupTitle()
        {
            if (IsAdminNow)
            {
                Page.Title = "Продажи всех агентов";
            }
            else
            {
                Page.Title = "Мои продажи";
            }
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