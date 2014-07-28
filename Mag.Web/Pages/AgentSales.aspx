<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentSales.aspx.cs" Inherits="Mag.Web.Pages.AgentSales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Мои продажи</title>
  <link rel="stylesheet" href="<%= ResolveClientUrl("~/Content/Site.css") %>"/>
  <link rel="stylesheet" href="<%= ResolveClientUrl("~/content/jquery-ui/jquery-ui.css") %>"/>
</head>
<body>
  <form id="form1" runat="server">
    <div class="b-sales" data-model='<%= JsonModel %>'>
      <div class="b-sales__controls-panel">
        <a href="javascript:void(0)" class="button b-sales" data-bind='click: saveNewItem'>Добавить</a>
      </div>
      <table class="b-table">
        <thead>
          <tr>
            <th>№</th>
            <th>Агент</th>
            <th>Номер отчета</th>
            <th>Дата</th>
            <%--            <th>Вид страхования</th>
            <th>Кол-во договоров, шт.</th>
            <th>Начисленная премия, руб.</th>
            <th>Кол-во оплат, шт.</th>
            <th>Оплаченная премия, руб.</th>
            <th>% вознаграждения</th>
            <th>Сумма КВ, руб.</th>
            <th>Примечание</th>
            <th>% доп. вознагр.</th>
            <th>Сумма доп. вознагр., руб</th>--%>
          </tr>
        </thead>
        <tbody data-bind='foreach: items'>
          <tr data-bind="template: {name: 'sale-view-template', data: $data }"></tr>
        </tbody>
        <tfoot>
          <tr data-bind="template: { name: 'sale-template', data: editedSaleData }"></tr>
        </tfoot>
      </table>
    </div>
  </form>
  
  <script type="text/html" id="sale-view-template">
    <td data-bind='text: id'></td>
    <td data-bind='text: agent().name'></td>
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
    <td>...</td>
    <td>
      <select data-bind="options: $root.agents, optionsText: 'name', value:$root.editedAgent, optionsCaption: 'Выберите...'"></select>
    </td>
    <td>
      <input type="text" data-bind='value: reportCode' /></td>
    <td>
      <input type="text" data-bind='datepicker: true, value: create' />
    </td>
  </script>
  
  <asp:PlaceHolder runat="server">
    <%= Scripts.Render("~/bundles/js/all") %>
  </asp:PlaceHolder>
</body>
</html>
