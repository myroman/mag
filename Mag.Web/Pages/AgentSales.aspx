<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgentSales.aspx.cs" Inherits="Mag.Web.Pages.AgentSales" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
  <link rel="stylesheet" href="<%= ResolveClientUrl("~/Content/Site.css") %>" />
  <link rel="stylesheet" href="<%= ResolveClientUrl("~/content/jquery-ui/jquery-ui.css") %>" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <h2>Журнал продаж</h2>
  <form id="form1" runat="server">
    <div class="col-lg-12 b-sales" data-model='<%= JsonModel %>'>
      <div class="well well-sm b-sales__controls-panel">
        <a href="javascript:void(0)" class="btn btn-success b-sales" data-bind='click: saveNewItem'>Добавить</a>
        <asp:PlaceHolder runat="server" Visible="<%# true %>">
          <a href="javascript:void(0)" class='btn btn-warning' data-bind='css: getClassForDelete, click: deleteSelected'>Удалить выделенные</a>
        </asp:PlaceHolder>
      </div>
      
      <div id="table-wrapper">
        <div class='table-scroll'>
          <table class="table table-striped table-hover table-condensed b-table">
            <thead>
              <tr>
                <th data-bind='visible: $root.isAdminNow'></th>
                <th title='Номер по порядку'>№</th>
                <asp:PlaceHolder runat="server" Visible="<%# IsAdminNow %>">
                  <th title='ФИО Агента'>Агент</th>
                </asp:PlaceHolder>
                <th title='Номер отчета'>Номер отчета</th>
                <th title='Дата'>Дата</th>
                <th title='Вид страхования'>Вид страхования</th>
                <th title='Количество договоров, шт.'>Кол-во договоров</th>
                <th title='Начисленная премия, руб.'>Премия</th>
                <th title='Количество оплат, шт.'>Кол-во оплат</th>
                <th title='Оплаченная премия, руб.'>Оплач. прем.</th>
                <th title='Процент вознаграждения'>% вознагр.</th>
                <th title='Сумма комиссионного вознаграждения, руб.'>Сумма КВ</th>
                <th title='Примечание'>Прим.</th>
                <th title='% дополнительного вознаграждения'>% доп. вознагр.</th>
                <th title='Сумма дополнительного вознаграждения, руб.'>Сумма д.в., руб</th>
              </tr>
            </thead>
            <tbody data-bind='foreach: items'>
              <tr data-bind="template: { name: 'view-sale-template', data: $data }, css: {danger: checked}"></tr>
            </tbody>
            <tfoot>
              <tr data-bind="template: { name: 'add-sale-template', data: editedSaleData }"></tr>
            </tfoot>
          </table>
        </div>
      </div>
    </div>
  </form>

  <script type="text/html" id="view-sale-template">
    <td data-bind='visible: $root.isAdminNow'>
      <input type="checkbox" data-bind='checked: checked'/>
    </td>
    <td data-bind='text: id'></td>
    <asp:PlaceHolder runat="server" Visible="<%# IsAdminNow %>">
      <td data-bind='text: agent().fullName'></td>
    </asp:PlaceHolder>
    <td data-bind='text: reportCode'></td>
    <td data-bind='text: create'></td>
    <td data-bind='text: insurance().name'></td>
    <td data-bind='text: contractsNumber'></td>
    <td data-bind='text: premium'></td>
    <td data-bind='text: paymentsNumber'></td>
    <td data-bind='text: paidSum'></td>
    <td data-bind='text: feePc'></td>
    <td data-bind='text: fee'></td>
    <td data-bind='text: comment'></td>
    <td data-bind='text: addFeePc'></td>
    <td data-bind='text: addFee'></td>    
  </script>
  <script type="text/html" id="add-sale-template">
    <td data-bind='visible: $root.isAdminNow'></td>
    <td>...</td>    
    <asp:PlaceHolder runat="server" Visible="<%# IsAdminNow %>">
      <td><%# CurrentUser.FullName %></td>
    </asp:PlaceHolder>    
    <td>
      <input type="text" class="inp-lg" data-bind='value: reportCode' /></td>
    <td>
      <input type="text" class="inp-lg" data-bind='datepicker: true, value: create' />
    </td>
    <td>
      <select class="inp-lg" data-bind="options: $root.insuranceTypes, optionsText: 'name', value: $root.editedInsurance, optionsCaption: 'Выберите...'"></select>
    </td>
    <td>
      <input type="text" class="inp-sm" data-bind="value: contractsNumber"/>
    </td>
    <td>
      <input type="text" data-bind="value: premium"/>
    </td>
    <td>
      <input type="text" class="inp-sm" data-bind="value: paymentsNumber"/>
    </td>
    <td>
      <input type="text" data-bind="value: paidSum"/>
    </td>
    <td>
      <input type="text" class="inp-sm" data-bind="value: feePc"/>
    </td>
    <td>
      <input type="text" data-bind="value: fee"/>
    </td>
    <td>
      <input type="text" class="inp-lg" data-bind="value: comment"/>
    </td>
    <td>
      <input type="text" class="inp-sm" data-bind="value: addFeePc"/>
    </td>
    <td>
      <input type="text" data-bind="value: addFee"/>
    </td>
  </script>
</asp:Content>
