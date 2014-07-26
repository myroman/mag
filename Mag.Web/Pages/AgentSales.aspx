<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentSales.aspx.cs" Inherits="Mag.Web.Pages.AgentSales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Мои продажи</title>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" /> 
</head>
<body>
    <form id="form1" runat="server">
      <div class="b-table-controls">
       
      </div>
      <table class="b-table">
      <thead>
        <tr>
          <th>№</th>
          <th>Агент</th>
          <th>Номер отчета</th>
          <th>Дата</th>
          <th>Вид страхования</th>
          <th>Кол-во договоров, шт.</th>
          <th>Начисленная премия, руб.</th>
          <th>Кол-во оплат, шт.</th>
          <th>Оплаченная премия, руб.</th>
          <th>% вознаграждения</th>
          <th>Сумма КВ, руб.</th>
          <th>Примечание</th>
          <th>% доп. вознагр.</th>
          <th>Сумма доп. вознагр., руб</th>
        </tr>
      </thead>
      <tbody>
        <asp:Repeater ID="rptSales" runat="server">
          <ItemTemplate>
            <tr>
            <td><%# Container.ItemIndex + 1 %></td>
            <td><%# FullAgentName(Container.DataItem) %></td>
            <td><%# GetSale(Container.DataItem).ReportCode %></td>
            <td><%# GetSale(Container.DataItem).CreateDate.ToString() %></td>
            <td><%# GetSale(Container.DataItem).Insurance %></td>
            <td><%# GetSale(Container.DataItem).ContractsNumber %></td> 
            <td><%# GetSale(Container.DataItem).Premium %></td>
            <td><%# GetSale(Container.DataItem).PaymentsNumber %></td>
            <td><%# GetSale(Container.DataItem).PaidSum %></td>
            <td><%# GetSale(Container.DataItem).FeePercent %></td>
            <td><%# GetSale(Container.DataItem).Fee %></td>
            <td><%# GetSale(Container.DataItem).Comment %></td>
            <td><%# GetSale(Container.DataItem).AddFeePercent %></td>
            <td><%# GetSale(Container.DataItem).AddFee %></td>
          </tr>
          </ItemTemplate>
        </asp:Repeater>
      </tbody>
    </table>
    </form>
</body>
</html>