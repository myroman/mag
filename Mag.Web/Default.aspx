<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mag.Web.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <div class="jumbotron">
    <h1>Выбор действий</h1>
    <p>Привет<%= CurrentUser %>! Что будем делать?</p>
    <p>
      <div class='b-options'>
        <a href='/Pages/AgentSales.aspx' class="btn btn-primary btn-lg">
          <span class="glyphicon glyphicon-usd"></span>&nbsp;Мои продажи
        </a>
      </div>
    </p>
  </div>
</asp:Content>
