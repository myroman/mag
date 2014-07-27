<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mag.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Главная</title>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" />
</head>
<body>
    <form id="form1" runat="server">
      <div class="header">
        <asp:Panel runat="server" ID="pnlUser" />
      </div>
      <div class='b-options'>
        <a href="/Users/Register.aspx">
          Зарегистрироваться
        </a>
        <a href="/Users/Login.aspx">
          Войти
        </a>
        <a href="/Handlers/Logout.ashx">
          Выйти
        </a>
        <a href='/Pages/AgentSales.aspx'>
          Мои продажи
        </a>
      </div>
    </form>
</body>
</html>
