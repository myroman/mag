<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Mag.Web.Users.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:Label runat="server" ID="lblError" />

      <asp:Panel runat="server">
        <label for="<%# txtUserName.ClientID %>">Юзер</label>
        <asp:TextBox runat="server" ID="txtUserName" />
        <br />
        <label for="<%# txtPassword.ClientID %>">Пароль</label>
        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"/>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
        CssClass="field-validation-error" ErrorMessage="The password field is required." />
        <br />
        <label for="<%# txtConfirmPassword.ClientID %>">Подтвердите пароль</label>
        <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password"/>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword"
      CssClass="field-validation-error" Display="Dynamic" 
      ErrorMessage="The confirm password field is required." />
      <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
      CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
        <br />
        <asp:Button runat="server" ID="btnRegister" Text="Зарегистрироваться"/>
      </asp:Panel>  
    </form>
</body>
</html>
