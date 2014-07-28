<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mag.Web.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <div class="jumbotron">
    <h1>Выбор действий</h1>
    <p>Привет! Что мы хотим сделать?</p>
    <p>
      <div class='b-options'>
        <a href="/Users/Register.aspx" class="btn btn-primary btn-lg">Зарегистрироваться</a>
        <a href="/Users/Login.aspx" class="btn btn-primary btn-lg">Войти</a>
        <a href="/Handlers/Logout.ashx" class="btn btn-primary btn-lg">Выйти</a>
        <a href='/Pages/AgentSales.aspx' class="btn btn-primary btn-lg">Мои продажи</a>
      </div>
    </p>
  </div>
</asp:Content>
