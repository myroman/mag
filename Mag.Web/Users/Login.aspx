<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mag.Web.Users.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:Label runat="server" ID="lblError" />
    <div>
      <li>
          <asp:Label runat="server" AssociatedControlID="txtUserName">Имя пользователя</asp:Label>
          <asp:TextBox runat="server" ID="txtUserName" />
          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
      </li>
      <li>
          <asp:Label runat="server" AssociatedControlID="txtPassword">Password</asp:Label>
          <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="field-validation-error" ErrorMessage="The password field is required." />
      </li>
      <li>
        <asp:Button runat="server" ID="btnSubmit" Text="Войти"/>
      </li>
    </div>
    <a href="/Users/Register.aspx">Я новый пользователь, хочу зарегистрироваться.</a>
    </form>
</body>
</html>
