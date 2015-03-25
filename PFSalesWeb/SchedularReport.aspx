<%@ Page Title="<%$Resources:PFSalesResource,SchedularReport %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="SchedularReport.aspx.cs" Inherits="SchedularReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="uppanScheduler" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnExcel" />
            <asp:PostBackTrigger ControlID="lnkbtnPdf" />
        </Triggers>
        <ContentTemplate>
            <div class="innerHeader">
                <img src="Images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,UpcomingScedular %>"></asp:Label>
            </div>
            <div class="dilContener">
                <dl class="dealerRagisterThree">
                    <dt>
                        <asp:Label ID="lblserSource" runat="server" Text="<%$Resources:PFSalesResource,Consultant %>"></asp:Label>:
                    </dt>
                    <dd>
                        <asp:DropDownList ID="ddlConsultant" TabIndex="103" CssClass="selectClass" runat="server"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlConsultant_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                        </asp:DropDownList>
                    </dd>
                </dl>
                <div class="headText">
                </div>
                <div class="button">
                    <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                        ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" TabIndex="106" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                        ToolTip="<%$Resources:PFSalesResource,Clear %>" TabIndex="107" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnExcel" runat="server" Text="<%$Resources:PFSalesResource,ExportToExcel %>"
                        ToolTip="<%$Resources:PFSalesResource,ExportToExcel %>" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnPdf" runat="server" Text="<%$Resources:PFSalesResource,ExportToPdf %>"
                        ToolTip="<%$Resources:PFSalesResource,ExportToPdf %>" OnClick="lnkbtnPdf_Click"></asp:LinkButton></div>
                <div style="float: right; width: 16%">
                    <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                        <%-- <asp:ListItem Value="5" Text="5"></asp:ListItem>
                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                        <asp:ListItem Value="25" Text="25" Selected="True"></asp:ListItem>--%>
                        <asp:ListItem Value="50" Text="50" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="100" Text="100"></asp:ListItem>
                        <asp:ListItem Value="150" Text="150"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:GridView ID="gvScheduler" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                    border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                    AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                    PageSize="50" OnPageIndexChanging="gvScheduler_PageIndexChanging" OnSorting="gvScheduler_Soring">
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Activity %>" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblActivity" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false" HeaderText="<%$Resources:PFSalesResource,ActivityTypeHead %>"
                            SortExpression="ActivityType">
                            <ItemTemplate>
                                <asp:Label ID="lblActivityType" runat="server" Text='<%#Eval("ActivityType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Consultant %>" SortExpression="Consultant">
                            <ItemTemplate>
                                <asp:Label ID="lblConsultant" runat="server" Text='<%#Eval("Consultant") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,StartDateHead %>" SortExpression="StartDateTime">
                            <ItemTemplate>
                                <asp:Label ID="lblStime" runat="server" Text='<%#Eval("StartDateTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,prospectHead %>" Visible="false"
                            SortExpression="ProspName">
                            <ItemTemplate>
                                <asp:Label ID="lblETime" runat="server" Text='<%#Eval("ProspName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ProspectStatusHead %>"
                            SortExpression="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center">
                            <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoDataFound %>"></asp:Label>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproSchedular" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="uppanScheduler">
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
