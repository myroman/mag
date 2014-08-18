<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MagAnalytics.aspx.cs" Inherits="Mag.Web.Pages.MagAnalytics" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
  <link rel="stylesheet" href="<%= ResolveClientUrl("~/Content/Site.css") %>" />
  <link rel="stylesheet" href="<%= ResolveClientUrl("~/content/jquery-ui/jquery-ui.css") %>" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
  <h2>Аналитика по агентской группе</h2>

  <div class="col-lg-12 b-anls" data-model='<%= JsonModel %>'>
    <form runat="server" class="form-horizontal col-lg-10">
      <div class="well well-sm cf">
        <div class='form-group-sm'>
          <div class='col-lg-2'>
            <a href="javascript:void(0)" class="form-control btn btn-success" data-bind='click: refresh'>
              <span class='glyphicon glyphicon-refresh'></span>&nbsp;Фильтровать
            </a>
          </div>

          <label for='dtFrom' class='col-lg-1 control-label'>От</label>
          <div class='col-lg-2'>
            <input id='dtFrom' type="text" data-bind='datepicker: true, value: filter.from' class='form-control' />
          </div>
          <label for='dtTo' class='col-lg1 control-label'>До</label>
          <div class='col-lg-2'>
            <input id='dtTo' type="text" data-bind='datepicker: true, value: filter.to' class='form-control' />
          </div>

          <div class='col-lg-4'>
            <div class="btn-group">
              <a href="#" class="btn btn-info btn-sm disabled">За квартал</a>
              <a href="#" class="btn btn-info btn-sm dropdown-toggle disabled" data-toggle="dropdown">
                <span class="caret"></span>
              </a>
              <ul class="dropdown-menu">
                <li><a class='quart1' href="#">1-й квартал</a></li>
                <li><a class='quart2' href="#">2-й квартал</a></li>
                <li><a class='quart3' href="#">3-й квартал</a></li>
                <li><a class='quart4' href="#">4-й квартал</a></li>
                <li class="divider"></li>
                <li><a class='year' href="#">Год</a></li>
              </ul>
            </div>
          </div>
        </div>
      </div>

      <div class=''>
        <table class='table table-striped table-hover table-condensed table-bordered b-table'>
          <thead>
            <tr>
              <th title='Виды страхования'>Виды страхования</th>
              <th title='Сумма продаж по всем агентам, руб.'>Сумма продаж, руб.</th>
              <th title='Количество договоров по всем агентам, шт.'>Кол-во договоров</th>
            </tr>
          </thead>

          <tbody data-bind='foreach: reportItems'>
            <tr data-bind="template: { name: 'report-template', data: $data }"></tr>
          </tbody>
        </table>
        <div class='loader'>
          <img src='<%= ResolveClientUrl("~/Content/spinner.gif") %>' />
        </div>
      </div>
    </form>

    <script type="text/html" id="report-template">
      <td data-bind='text: insuranceType'></td>
      <td data-bind='text: totalSum'></td>
      <td data-bind='text: totalContractsNumber'></td>
    </script>
  </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="BottomContent" runat="server">
</asp:Content>
