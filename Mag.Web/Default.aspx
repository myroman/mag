<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mag.Web.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <div class="jumbotron">
    <h1>Выбор действий</h1>
    <p>Привет<%= CurrentUserName %>! Что будем делать?</p>
    <p>
      <div class='b-options'>
        <a href='/Pages/AgentSales.aspx' class="btn btn-primary btn-lg">
          <span class="glyphicon glyphicon-usd"></span>&nbsp;Мои продажи
        </a>
        <asp:PlaceHolder runat="server" Visible="<%# IsAdminNow %>">
          <a href='/Pages/MagAnalytics.aspx' class='btn btn-primary btn-lg'>
            <span class='glyphicon glyphicon-cloud-upload'></span>
            Аналитика по МАГу
          </a>
        </asp:PlaceHolder>
      </div>
    </p>
  </div>
</asp:Content>
