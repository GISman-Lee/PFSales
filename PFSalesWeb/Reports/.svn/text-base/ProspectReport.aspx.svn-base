<%@ Page Title="" Language="C#" MasterPageFile="~/PFSalesMaster.master" AutoEventWireup="true"
    CodeFile="ProspectReport.aspx.cs" EnableEventValidation="false" Inherits="Reports_ProspectReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="uppanMyActivity" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnExcel" />
            <asp:PostBackTrigger ControlID="lnkbtnPdf" />
        </Triggers>
        <ContentTemplate>
            <div class="panCompny">
                <div class="grid">
                    <div class="tabHeading">
                        <span>
                            <asp:Image ID="imgAlertReport" ImageUrl="~/Images/sales-report.png" runat="server"/>
                            <asp:Label Text="<%$Resources:PFSalesResource,ProspectReport %>" ID="lblAlertMaster"
                                runat="server"></asp:Label>
                        </span>
                    </div>
                    <div style="width: 100%; float: right; padding-top: 10px; padding-bottom: 10px;">
                        <div style="width: 110px; float: right;">
                            <asp:LinkButton ID="lnkbtnExcel" runat="server" CssClass="TextImageExcel" Text="<%$Resources:PFSalesResource,ExportToExcel %>"
                                ToolTip="<%$Resources:PFSalesResource,ExportToExcel %>" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                        </div>
                        <div style="width: 100px; float: right;">
                            <asp:LinkButton ID="lnkbtnPdf" runat="server" CssClass="TextImagePdf" Text="<%$Resources:PFSalesResource,ExportToPdf %>"
                                ToolTip="<%$Resources:PFSalesResource,ExportToPdf %>" OnClick="lnkbtnPdf_Click"></asp:LinkButton></div>
                    </div>
                    <asp:Panel ID="pnlTabularRep" runat="server">
                        <asp:GridView ID="gvActivities" runat="server" class="tableGride" PagerStyle-CssClass="footerpaging"
                            GridLines="None" AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                            CssClass="tableGride" PageSize="10" EmptyDataText="<%$ Resources:PFSalesResource, NoDataFound %>"
                            Width="900px" OnPageIndexChanging="gvActivities_PageIndexChanging" OnSorting="gvActivities_Sorting">
                            <Columns>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ActivityTypeHead %>"
                                    SortExpression="ActivityType">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityType" runat="server" Text='<% #Bind("ActivityType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:PFSalesResource, Activity %>" SortExpression="ActivityName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityName" runat="server" Text='<% #Bind("ActivityName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:PFSalesResource, prospectHead %>" SortExpression="LeadTitle">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeadTitle" runat="server" Text='<% #Bind("LeadTitle") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,StartDateHead %>" SortExpression="StartDateTime">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartDateTime" runat="server" Text='<% #Bind("StartDateTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EndDateHead %>" SortExpression="EndDateTime">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndDateTime" runat="server" Text='<% #Bind("EndDateTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Status %>" SortExpression="ActivityStatus">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityStatus" runat="server" Text='<% #Bind("ActivityStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproEmp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="uppanMyActivity">
        <ProgressTemplate>
            <div id="progressBackgroundFilter">
            </div>
            <div id="processMessage">
                <span style="text-align: center;">
                    <img src="Images/loading.gif" />
                    <br />
                    <asp:Literal ID="ltrwait" runat="server" Text="<%$Resources:PFSalesResource,PleaseWait %>"></asp:Literal></span></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
