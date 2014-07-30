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
        <asp:PlaceHolder runat="server" Visible="<%# IsAdminNow %>">
          <a href="javascript:void(0)" class='btn btn-warning' data-bind='css: getClassForDelete, click: deleteSelected'>Удалить выделенные</a>
        </asp:PlaceHolder>
      </div>
      <div id="table-wrapper">
        <div class='table-scroll'>
          <table class="table table-striped table-hover b-table">
            <thead>
              <tr>
                <th data-bind='visible: isAdminNow'></th>
                <th title='Номер по порядку'>№</th>
                <th title='ФИО Агента'>Агент</th>
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
              <tr data-bind="template: { name: 'sale-view-template', data: $data }, css: {danger: checked}"></tr>
            </tbody>
            <tfoot>
              <tr data-bind="template: { name: 'sale-template', data: editedSaleData }"></tr>
            </tfoot>
          </table>
        </div>
      </div>
    </div>
  </form>

  <script type="text/html" id="sale-view-template">
    <td data-bind='visible: $root.isAdminNow'>
      <input type="checkbox" data-bind='checked: checked'/>
    </td>
    <td data-bind='text: id'></td>
    <td data-bind='text: agent().fullName'></td>
    <td data-bind='text: reportCode'></td>
    <td data-bind='text: create'></td>
    <%--<td><%# GetSale(Container.DataItem).Insurance %></td>
      <td><%# GetSale(Container.DataItem).ContractsNumber %></td>
      <td><%# GetSale(Container.DataItem).Premium %></td>
      <td><%# GetSale(Container.DataItem).PaymentsNumber %></td>
      <td><%# GetSale(Container.DataItem).PaidSum %></td>
      <td><%# GetSale(Container.DataItem).FeePercent %></td>
      <td><%# GetSale(Container.DataItem).Fee %></td>
      <td><%# GetSale(Container.DataItem).Comment %></td>
      <td><%# GetSale(Container.DataItem).AddFeePercent %></td>
      <td><%# GetSale(Container.DataItem).AddFee %></td>--%>
  </script>
  <script type="text/html" id="sale-template">
    <td data-bind='visible: $root.isAdminNow'></td>
    <td>...</td>
    <td>
      <select data-bind="options: $root.agents, optionsText: 'fullName', value: $root.editedAgent, optionsCaption: 'Выберите...'"></select>
    </td>
    <td>
      <input type="text" data-bind='value: reportCode' /></td>
    <td>
      <input type="text" data-bind='datepicker: true, value: create' />
    </td>
  </script>
</asp:Content>
