<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="WebAppPersonManagement.Page1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Person Management</title>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function rowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" Skin="Glow"/>
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
        <div id="demo" class="demo-container no-bg">
            <telerik:RadGrid RenderMode="Lightweight" runat="server" ID="RadGrid1" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true"
                OnNeedDataSource="RadGrid1_NeedDataSource" OnUpdateCommand="RadGrid1_UpdateCommand"
                OnItemCreated="RadGrid1_ItemCreated" OnDeleteCommand="RadGrid1_DeleteCommand"
                OnInsertCommand="RadGrid1_InsertCommand" OnItemDataBound="RadGrid1_ItemDataBound"
                OnPreRender="RadGrid1_PreRender" OnItemCommand="RadGrid1_ItemCommand">
                <SortingSettings ShowNoSortIcons="true" />
                <MasterTableView DataKeyNames="ID" CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnCurrentPage">
                    <Columns>
                        <telerik:GridBoundColumn DataField="ID" HeaderText="ID" ReadOnly="true"
                            ForceExtractValue="Always" ConvertEmptyStringToNull="true" />
                        <telerik:GridBoundColumn DataField="Name" HeaderText="Name" />
                        <telerik:GridBoundColumn DataField="Age" HeaderText="Age" />
                        <telerik:GridBoundColumn DataField="PersonTypeID" HeaderText="Type" />
                        <telerik:GridButtonColumn ButtonType="FontIconButton" CommandName="Edit" />
                        <telerik:GridButtonColumn ConfirmText="Delete this product?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Delete" ButtonType="FontIconButton" CommandName="Delete" />
                        <telerik:GridButtonColumn ButtonType="PushButton" Text="Open" UniqueName="GoToPage2" CommandName="Open"/> 
                    </Columns>
                </MasterTableView>
                <PagerStyle Mode="NextPrevAndNumeric" />
                <ClientSettings>
                    <ClientEvents OnRowDblClick="rowDblClick"/>
                </ClientSettings>
            </telerik:RadGrid>
        </div>
        <telerik:RadInputManager RenderMode="Lightweight" runat="server" ID="RadInputManager1" Enabled="true">
            <telerik:TextBoxSetting BehaviorID="TextBoxSetting1">
            </telerik:TextBoxSetting>
            <telerik:NumericTextBoxSetting BehaviorID="NumericTextBoxSetting1" Type="Number"
                AllowRounding="true" DecimalDigits="0">
            </telerik:NumericTextBoxSetting>
            <telerik:NumericTextBoxSetting BehaviorID="NumericTextBoxSetting2" Type="Number"
                AllowRounding="true" DecimalDigits="0">
            </telerik:NumericTextBoxSetting>
        </telerik:RadInputManager>
        <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" />
    </form>


</body>
</html>
