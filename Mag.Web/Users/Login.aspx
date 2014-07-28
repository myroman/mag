<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mag.Web.Users.Login" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <div class='jumbotron cf'>
    
    <asp:PlaceHolder runat="server" ID="plhError">
      <div class="alert alert-dismissable alert-danger">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <asp:Label runat="server" ID="lblErrorMessage" />
      </div>
    </asp:PlaceHolder>
    <form runat="server" class="form-horizontal col-lg-6">
      <fieldset>
        <legend>Вход</legend>

        <div class='form-group'>
          <asp:Label runat="server" CssClass="col-lg-4 control-label" AssociatedControlID="txtUserName">
          Имя пользователя
          </asp:Label>
          <div class="col-lg-7">
            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder='Имя пользователя' />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
              CssClass="field-validation-error" ErrorMessage="Введите имя агента." />
          </div>
        </div>

        <div class='form-group'>
          <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-lg-4 control-label">
          Пароль
          </asp:Label>
          <div class='col-lg-7'>
            <asp:TextBox runat="server" CssClass="form-control" placeholder='Пароль' ID="txtPassword"
              TextMode="Password" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
              CssClass="field-validation-error" ErrorMessage="Введите пароль." />
          </div>
        </div>

        <div class="form-group">
          <div class="col-lg-10">
            <asp:Button UseSubmitBehavior="True" CssClass="btn btn-primary" runat="server" ID="btnSubmit" Text="Войти" />
            <asp:Button CssClass="btn btn-warning" runat="server" ID="btnRedirectToRegister" Text="Зарегистрироваться" />
          </div>
        </div>
      </fieldset>
    </form>
  </div>
</asp:Content>
