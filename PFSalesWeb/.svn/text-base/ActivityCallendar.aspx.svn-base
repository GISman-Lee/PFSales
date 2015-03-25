<%@ Page Title="<%$Resources:PFSalesResource,ActCallendar %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="ActivityCallendar.aspx.cs" Inherits="ActivityCallendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpActCallendar" runat="server">
        <ContentTemplate>
            <div class="innerHeader">
                <img src="images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="ActCallendarHead" runat="server" Text="<%$Resources:PFSalesResource,ActCallendar %>"></asp:Label>
            </div>
            <asp:Panel ID="pnlCallendar" runat="server">
                <div class="dilContener">
                    <asp:Calendar ID="calActivity" runat="server" Style="margin-left: 12px" Font-Bold="false"
                        BorderColor="#5b8bc9" BorderWidth="1px" BorderStyle="Solid" Height="210px" SelectionMode="Day"
                        DayNameFormat="FirstTwoLetters" OnSelectionChanged="calActivity_SelectionChanged"
                        NextMonthText='<img src ="images/nextCalendarImg.png" />' PrevMonthText='<img src ="images/previousCalendarImg.png" />'
                        Width="220" OnDayRender="calActivity_DayRender" BackColor="White" TitleStyle-BackColor="White"
                        Font-Size="11px">
                        <TodayDayStyle ForeColor="#367cad" BackColor="#fffbde" BorderColor=" #41aeda" BorderWidth="1px">
                        </TodayDayStyle>
                    </asp:Calendar>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlCallDetails" runat="server" Visible="false">
                <div class="dilContener">
                    <dl class="dealerRagisterThree">
                        <dt>
                            <asp:Label ID="lblltrSelectedDate" runat="server" Text="<%$Resources:PFSalesResource,SelecteDate %>"></asp:Label>
                        </dt>
                        <dd>
                            <asp:Label ID="lblSelectedDate" runat="server"></asp:Label>
                        </dd>
                    </dl>
                    <asp:GridView ID="gvHours" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                        border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                        AutoGenerateColumns="false" OnRowCommand="gvHours_onRowCommand" rule="none" ShowHeader="false"
                        AllowPaging="true" AllowSorting="true" OnRowDataBound="gvHours_onRowDataBound" PageSize="25">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EnquiryDateHead %>" SortExpression="CreatedDate">
                                <ItemStyle Width="5%" BackColor="#148dbc" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHrName" runat="server" Text='<%#Bind("Hours") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EnquiryDateHead %>" SortExpression="CreatedDate">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnAdd" runat="server" Width="100%" CommandName="ClickableDiv"></asp:LinkButton>
                                    <div id="dvCallDetails" runat="server">
                                    </div>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproProsp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpActCallendar">
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
