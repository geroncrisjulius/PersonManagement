<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="WebAppPersonManagement.Page1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Person Management - Page1</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
        <%: Scripts.Render("~/bundles/jquery")  %>
        <%: Scripts.Render("~/bundles/bootstrap") %>
    </asp:PlaceHolder>


    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function rowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
        </script>
    </telerik:RadCodeBlock>
</head>
<body style="padding-top: 0px;">
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <nav class="navbar navbar-light bg-dark">
            <div class="container-fluid">
                <span class="navbar-brand mb-0 text-light h1">Person Management</span>
            </div>
        </nav>
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1">
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

        </telerik:RadScriptManager>
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false" Skin="Glow" />
        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                        <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                        <telerik:AjaxUpdatedControl ControlID="RadInputManager1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" />
        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="False" />
        <div class="ps-2 pe-2 pt-2 demo-container no-bg">
            <telerik:RadGrid RenderMode="Lightweight" runat="server" ID="RadGrid1" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                OnNeedDataSource="RadGrid1_NeedDataSource" OnUpdateCommand="RadGrid1_UpdateCommand"
                OnItemCreated="RadGrid1_ItemCreated" OnDeleteCommand="RadGrid1_DeleteCommand"
                OnInsertCommand="RadGrid1_InsertCommand" OnItemDataBound="RadGrid1_ItemDataBound"
                OnPreRender="RadGrid1_PreRender" OnItemCommand="RadGrid1_ItemCommand">
                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                <SortingSettings ShowNoSortIcons="true" />
                <MasterTableView DataKeyNames="ID" CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnCurrentPage" EditMode="InPlace">
                    <RowIndicatorColumn ShowNoSortIcon="False"></RowIndicatorColumn>

                    <ExpandCollapseColumn ShowNoSortIcon="False"></ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="ID" HeaderText="ID" ReadOnly="true"
                            ForceExtractValue="Always" ConvertEmptyStringToNull="true" />
                        <telerik:GridBoundColumn DataField="Name" HeaderText="Name" />
                        <telerik:GridBoundColumn DataField="Age" HeaderText="Age" />
                        <telerik:GridTemplateColumn HeaderText="Type" ItemStyle-Width="240px" UniqueName="Type" 
                            SortExpression="PersonTypeDescription">
                            <ItemTemplate>
                                <telerik:RadLabel ID="RadLabel1" runat="server"
                                    Text='<%#DataBinder.Eval(Container.DataItem, "PersonTypeDescription")%>' />
                                <telerik:RadLabel ID="RadLabel2" runat="server"
                                    Text='<%#DataBinder.Eval(Container.DataItem, "PersonTypeID") %>' Visible="false"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <telerik:RadDropDownList RenderMode="Lightweight" runat="server" ID="RadDropDownList1"
                                    DataTextField="Description" DataValueField="PersonTypeID" 
                                    DataSource="<%#_personTypes %>"
                                    SelectedValue='<%#Bind("PersonTypeID") %>'/>
                            </EditItemTemplate>
                            <ItemStyle Width="240px"></ItemStyle>
                        </telerik:GridTemplateColumn>
                       <%--<telerik:GridBoundColumn DataField="PersonTypeID" HeaderText="Type" Display="false" />--%>
                        <%--<telerik:GridBoundColumn DataField="PersonTypeDescription" HeaderText="Type" ReadOnly="true" />--%>
                        <telerik:GridEditCommandColumn UniqueName="EditCommandColumn" HeaderStyle-Width="100px">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </telerik:GridEditCommandColumn>
                        <%--<telerik:GridButtonColumn ButtonType="FontIconButton" CommandName="Edit" ItemStyle-Width="10px" />--%>
                        <telerik:GridButtonColumn ConfirmText="Delete this product?" ConfirmDialogType="RadWindow"
                            ConfirmTitle="Delete" ButtonType="FontIconButton" CommandName="Delete" HeaderStyle-Width="100px">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" Text="Open" UniqueName="GoToPage2" CommandName="GoToPage2"
                            ImageUrl="Images/right_arrow.png" HeaderStyle-Width="100px">

                            <HeaderStyle Width="100px"></HeaderStyle>
                        </telerik:GridButtonColumn>

                    </Columns>

                    <EditFormSettings>
                        <EditColumn ShowNoSortIcon="False" UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <PagerStyle Mode="NextPrevAndNumeric" />
                <ClientSettings>
                    <ClientEvents OnRowDblClick="rowDblClick" />
                </ClientSettings>

                <FilterMenu RenderMode="Lightweight"></FilterMenu>

                <HeaderContextMenu RenderMode="Lightweight"></HeaderContextMenu>
            </telerik:RadGrid>
        </div>
        <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" />
    </form>


</body>
</html>
