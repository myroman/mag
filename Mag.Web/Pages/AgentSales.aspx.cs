﻿using System;

using Autofac;

using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Web.AutofacSupport;

namespace Mag.Web.Pages
{
    public partial class AgentSales : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // now we fetch sales for all users. this will be changed once I implement logging in.
            var container = Context.GetContainer();

            var salesProvider = container.Resolve<ISalesProvider>();
            rptSales.DataSource = salesProvider.ReadSales();
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
                return sale.Agent.FullName();
            }
            return string.Empty;
        }
    }
}