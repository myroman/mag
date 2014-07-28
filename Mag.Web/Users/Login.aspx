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
        <%--<legend>Вход</legend>--%>

        <div class='form-group'>
          <asp:Label runat="server" CssClass="<%# LabelCssClass %>" AssociatedControlID="txtUserName">
          Имя пользователя
          </asp:Label>
          <div class="<%# InputWrapperCssClass %>">
            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control"
              placeholder='Имя пользователя' />
          </div>
          <div class="<%# ValidInputCssClass %>">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
              CssClass="control-label has-error" ErrorMessage="Введите имя агента." />
          </div>
        </div>

        <div class='form-group'>
          <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="<%# LabelCssClass %>">
          Пароль
          </asp:Label>
          <div class='<%# InputWrapperCssClass %>'>
            <asp:TextBox runat="server" CssClass="form-control" placeholder='Пароль' ID="txtPassword"
              TextMode="Password" />
          </div>
          <div class="<%# ValidInputCssClass %>">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
              CssClass="control-label has-error" ErrorMessage="Введите пароль." />
          </div>
        </div>

        <div class="form-group">
          <div class="col-lg-8 col-lg-offset-2">
            <asp:Button UseSubmitBehavior="True" CssClass="btn btn-primary" runat="server" ID="btnSubmit" Text="Войти" />
            <a href="<%= ResolveClientUrl("~/Users/Register.aspx") %>" class="btn btn-success">
              Я новый пользователь, хочу зарегистрироваться
            </a>
          </div>
        </div>
      </fieldset>
    </form>
  </div>
</asp:Content>
