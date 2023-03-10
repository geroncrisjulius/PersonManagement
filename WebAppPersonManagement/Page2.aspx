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
    </asp:PlaceHolder>
    <script src="Scripts/Highcharts-10.3.3/code/highcharts.js"></script>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body style="padding-top: 0px;">
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
        <nav class="navbar navbar-light bg-dark">
            <div class="container-fluid">
                <span class="navbar-brand mb-0 text-light h1">Person Management</span>
            </div>
        </nav>
        <div class="card m-4 text-white bg-dark">
            <div class="d-flex d-inline card-header bg-secondary">
                <div class="col-4">
                    <h2 class="text-left"><%:name %></h2>
                </div>
                <div class="col-4">
                    <h2 class="text-center"><%:age %></h2>
                </div>
                <div class="col-4 ">
                    <h2 class="text-end "><%:persontype %></h2>
                </div>
            </div>
            <div class="card-body">
                <div id="container" style="width: 100%; height: 400px;"></div>
            </div>

        </div>


    </form>

    <script>
        document.addEventListener('DOMContentLoaded', GenerateChart);

        function padTo2Digits(num) {
            return num.toString().padStart(2, '0');
        }

        function formatDate(date) {
            return [
                padTo2Digits(date.getMonth() + 1),
                padTo2Digits(date.getDate()),
                date.getFullYear(),
            ].join('/');
        }

        function GenerateChart() {
            var rndInt = [];
            var dates = [];
            var dt = new Date();
            for (var i = 0; i < 10; i++) {
                rndInt[i] = Math.floor(Math.random() * 100);
                dt.setDate(dt.getDate() + 1);
                var str = formatDate(dt);
                dates[i] = str;
            }

            const chart = Highcharts.chart('container', {
                chart: {
                    type: 'column',
                    backgroundColor: '#4F4F4F'
                },
                title: {
                    text: 'Sample HighChart',
                    style: {
                        color: '#DEDEDE',
                        fontWeight: 'bold'
                    }
                },
                xAxis: {
                    categories: dates,
                    labels: {
                        style: {
                            color: '#FFFFFF'
                        }
                    }
                },
                yAxis: {
                    title: {
                        text: 'Value',
                        style: {
                            color: '#FFFFFF'
                        }
                    },
                    labels: {
                        style: {
                            color: '#FFFFFF'
                        }
                    },
                    min: 0,
                    max: 110
                },
                legend: {
                    enabled: false
                },
                series: [{
                    name: 'Random',
                    data: rndInt,
                    color: '#44B300'
                }]
            });
        }
    </script>
</body>
</html>
