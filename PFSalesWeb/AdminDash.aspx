<%@ Page Title="<%$Resources:PFSalesResource,DashBoard %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="AdminDash.aspx.cs" Inherits="AdminDash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .testGv
        {
            /*pdding-bottom: 5px;*/
            padding-left: 7px;
            padding-right: 7px;
            padding-top: 5px;
            text-align: left;
            border: none 0px Transperent;
            float: left;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Timer ID="Timer" runat="server" OnTick="Timer_Tick" Interval="60000">
    </asp:Timer>
    <asp:UpdatePanel ID="UpPanPrspect" runat="server">
        <ContentTemplate>
            <div class="innerHeader">
                <img src="images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,DashBoard %>"></asp:Label>
            </div>
            <div class="dilContener">
                <dl class="dealerRagisterTwo">
                    <dt>
                        <asp:Label ID="lblSearch" runat="server" Text="<%$Resources:PFSalesResource,serachprospect %>"></asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtSearch" runat="server" Width="180px" class="inputClass" placeholder="<%$Resources:PFSalesResource, MemberNo %>"
                            MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                        <asp:LinkButton ID="linkbtnSearch" runat="server" ToolTip="<%$Resources:PFSalesResource, serachprospect %>"
                            OnClick="linkbtnSearch_Click">
                            <img id="imgSearch" runat="server" src="~/Images/viewDetails.png" />
                        </asp:LinkButton>
                    </dd>
                </dl>
                <div style="width: 100%; float: left;">
                    <asp:Label ID="lblnotificHead" runat="server" Style="color: #000; font-size: 125%;
                        font-weight: bold; margin-bottom: 0.3em; margin-left: 0.3em; margin-right: 0.3em;
                        margin-top: 0.3em;" Text="<%$Resources:PFSalesResource,Notification %>"></asp:Label>
                </div>
                <div style="float: left; margin-left: 20px;">
                    <asp:GridView ID="gvNotifications" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                        border="0" RowStyle-CssClass="testGv" GridLines="None" AutoGenerateColumns="false"
                        rule="none" ShowHeader="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnNotification" runat="server" Text='<%#Bind("Notification") %>'
                                        ToolTip="<%$Resources:PFSalesResource,ViewDetails %>" OnClick="lnkbtnNotification_Click"></asp:LinkButton>
                                    <asp:Label ID="lblNotification" runat="server" Text="<%$Resources:PFSalesResource,newleadstoConsultant %>"></asp:Label>
                                    <asp:HiddenField ID="hdfProspMemNo" runat="server" Value='<%#Bind("MemNo") %>' />
                                    <asp:HiddenField ID="hdfprospId" runat="server" Value='<%#Bind("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div align="center">
                                <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoNotificationsForYou %>"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div class="headText">
                </div>
                <div style="width: 100%; float: left;">
                    <asp:Label ID="lblTodayActHead" runat="server" Style="color: #000; font-size: 125%;
                        font-weight: bold; margin-bottom: 0.3em; margin-left: 0.3em; margin-right: 0.3em;
                        margin-top: 0.3em;" Text="<%$Resources:PFSalesResource,TodayActivity %>"></asp:Label>
                </div>
                <div style="float: left; margin-left: 20px;">
                    <asp:GridView ID="gvActivities" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                        border="0" RowStyle-CssClass="testGv" GridLines="None" AutoGenerateColumns="false"
                        rule="none" ShowHeader="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnActivities" runat="server" Text='<%#Bind("TodayActCount")  %>'
                                        ToolTip="<%$Resources:PFSalesResource,ViewDetails %>" OnClick="lnkbtnActivities_Click"></asp:LinkButton>
                                    <asp:Label ID="lblActivities" runat="server" Text='<%#Bind("ActivityType") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfActivityTypeId" runat="server" Value='<%#Bind("ActivityTypeId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div align="center">
                                <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoActivitiesForToday %>"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproProsp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpPanPrspect">
        <ProgressTemplate>
            <div id="progressBackgroundFilter">
            </div>
            <div id="processMessage">
                <span style="text-align: center;">
                    <img src="Images/loading.gif" />
                    <br />
                    <asp:Literal ID="ltrwait" runat="server" Text="<%$Resources:PFSalesResource,PleaseWait %>"></asp:Literal>
                </span>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
