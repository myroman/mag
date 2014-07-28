<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mag.Web.Users.Login" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <div class='jumbotron cf'>
    <form runat="server" class="form-horizontal col-lg-10">
      <h2>Вход</h2>
      <asp:PlaceHolder runat="server" ID="plhError">
        <div class="alert alert-dismissable alert-danger">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <asp:Label runat="server" ID="lblErrorMessage" />
        </div>
      </asp:PlaceHolder>

      <fieldset>
        <div class='form-group'>
          <asp:Label runat="server" CssClass="<%# LabelCssClass %>" AssociatedControlID="txtEmail" Text="E-mail" />
          <div class="<%# InputWrapperCssClass %>">
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
          </div>
          <div class="<%# ValidInputCssClass %>">
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" 
              CssClass="control-label" ErrorMessage="Введите e-mail." />
          </div>
        </div>

        <div class='form-group'>
          <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="<%# LabelCssClass %>" Text="Пароль" />
          <div class='<%# InputWrapperCssClass %>'>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
          </div>
          <div class="<%# ValidInputCssClass %>">
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
              CssClass="control-label" ErrorMessage="Введите пароль." />
          </div>
        </div>

        <div class="form-group">
          <div class="col-lg-8 col-lg-offset-3">
            <asp:Button UseSubmitBehavior="True" CssClass="btn btn-primary" runat="server" ID="btnSubmit" Text="Войти" />
            <a href="<%= ResolveClientUrl("~/Users/Register.aspx") %>" class="btn-sm">
              Я новый пользователь, хочу зарегистрироваться
            </a>
          </div>
        </div>
      </fieldset>
    </form>
  </div>
</asp:Content>
