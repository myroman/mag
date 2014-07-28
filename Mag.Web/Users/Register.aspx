<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Mag.Web.Users.Register" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <div class="jumbotron cf">
    <asp:PlaceHolder runat="server" ID="plhError">
      <div class="alert alert-dismissable alert-danger">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <asp:Label runat="server" ID="lblErrorMessage" />
      </div>
    </asp:PlaceHolder>
    
    <form id="Form2" runat="server" class="form-horizontal col-lg-6">
      <fieldset>
        <legend>Вход</legend>

        <div class='form-group'>
          <asp:Label ID="Label1" runat="server" CssClass="col-lg-4 control-label" AssociatedControlID="txtUserName">
          Имя пользователя
          </asp:Label>
          <div class="col-lg-7">
            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder='Имя пользователя' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
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
            <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
      CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
          </div>
        </div>
        
        <div class='form-group'>
          <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-lg-4 control-label">
            Подтвердите пароль
          </asp:Label>
          <div class='col-lg-7'>
            <asp:TextBox runat="server" CssClass="form-control" placeholder='Пароль' ID="txtConfirmPassword"
              TextMode="Password" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword"
              CssClass="field-validation-error" ErrorMessage="Введите пароль." />
            <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
              CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Введенные пароли не совпадают." />
          </div>
        </div>

        <div class="form-group">
          <div class="col-lg-10">
            <asp:Button CssClass="btn btn-primary" runat="server" ID="btnRegister" Text="Хочу зарегистрироваться" />
          </div>
        </div>
      </fieldset>
    </form>
  </div>
</asp:Content>
