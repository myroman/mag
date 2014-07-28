<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Mag.Web.Users.Register" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <div class="jumbotron cf">
    <form runat="server" class="form-horizontal col-lg-10">
      <h2>Регистрация</h2>
      <asp:PlaceHolder runat="server" ID="plhError">
        <div class="alert alert-dismissable alert-danger">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <asp:Label runat="server" ID="lblErrorMessage" />
        </div>
      </asp:PlaceHolder>

      <fieldset>
        <div class='form-group'>
          <asp:Label ID="Label1" runat="server" CssClass="<%# LabelCssClass %>" AssociatedControlID="txtFullName" Text="Имя и фамилия"/>
          
          <div class="<%# InputWrapperCssClass %>">
            <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" />
          </div>
          <div class="<%# ValidInputCssClass %>">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName"
              CssClass="control-label" ErrorMessage="Введите имя и фамилию." />
          </div>
        </div>

        <div class='form-group'>
          <%--todo Добавить подсказку что он будет исопльзоваться если забудете пароль--%>
          <asp:Label runat="server" CssClass="<%# LabelCssClass %>" Text="E-mail" AssociatedControlID="txtEmail"/>
          <div class='<%# InputWrapperCssClass %>'>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
          </div>
          <div class='<%# ValidInputCssClass %>'>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
              CssClass="control-label" ErrorMessage="Введите e-mail." />
            <asp:RegularExpressionValidator runat="server" ErrorMessage="Введите правильный e-mail." CssClass="control-label" 
            ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
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
            <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
              CssClass="control-label" Display="Dynamic" ErrorMessage="Введенные пароли не совпадают." />
          </div>
        </div>

        <div class='form-group'>
          <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="<%# LabelCssClass %>" Text="Подтвердите пароль" />
          <div class='<%# InputWrapperCssClass %>'>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtConfirmPassword" TextMode="Password" />            
          </div>
          <div class="<%# ValidInputCssClass %>">
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword"
              CssClass="control-label" ErrorMessage="Введите пароль." />
            <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
              CssClass="control-label" Display="Dynamic" ErrorMessage="Введенные пароли не совпадают." />
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
