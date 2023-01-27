<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="WebAppPersonManagement.Page2" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Person Management - Page2</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
        <%: Scripts.Render("~/bundles/jquery")  %>
        <%: Scripts.Render("~/bundles/bootstrap") %>
        <%--<script src="Scripts/Highcharts-4.0.1/js/highcharts.js"></script>--%>
<%--        <script src="~/Scripts/Highcharts-4.0.1/js/highcharts.js"></script>--%>
        <script src="https://code.highcharts.com/highcharts.js"></script>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
            </Scripts>
        </asp:ScriptManager>

        <div class="card m-4">
            <div class="d-flex d-inline card-title">
                <div class="col-4">
                    <h2 class="text-left p-2 "><%:name %></h2>
                </div>
                <div class="col-4">
                    <h2 class="text-center p-2"><%:age %></h2>
                </div>
                <div class="col-4">
                    <h2 class="text-end p-2"><%:persontype %></h2>
                </div>
            </div>
            <div class="card-body">
                <%--<%:chart %>--%>
                <div id="container" style="width:100%; height:400px;"></div>
            </div>

        </div>


    </form>

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const chart = Highcharts.chart('container', {
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Sample HighChart'
                },
                xAxis: {
                    categories: ['Apples', 'Bananas', 'Oranges']
                },
                yAxis: {
                    title: {
                        text: 'Random'
                    },
                    min: 0,
                    max: 110
                },
                series: [{
                    data: [1, 0, 4]
                }]
            });
        });
    </script>
</body>
</html>
