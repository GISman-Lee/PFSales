<%@ Page Title="<%$Resources:PFSalesResource,Claim101 %>" Language="C#" MasterPageFile="~/PFSalesMaster.master" AutoEventWireup="true"
    CodeFile="Claim101.aspx.cs" Inherits="Claim101" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanPrspect" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlSearchprosp" runat="server" DefaultButton="lnkbtnClaim101">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="lblClaim101" runat="server" Text="<%$Resources:PFSalesResource,Claim101 %>"></asp:Label>
                </div>
                <div class="dilContener">
                    <!--Content-Note: error Msg-->
                    <div class="error" id="dvsererror" runat="server" visible="false">
                        <asp:Label ID="lblSerErrMsg" runat="server"></asp:Label>
                    </div>
                    <!--Content-Note: success Msg-->
                    <div class="success" id="dvaserSuccess" runat="server" visible="false">
                        <asp:Label ID="lblSerSucMsg" runat="server"></asp:Label>
                    </div>
                    <dl class="dealerRagisterTwo">
                        <dt>
                            <asp:Label ID="lblEmailID" runat="server" Text="<%$Resources:PFSalesResource,EmailId %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmailId" CssClass="inputClass" MaxLength="160" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtEmailId"
                                SetFocusOnError="true" ValidationGroup="claim101" Display="None" EnableClientScript="true"
                                ErrorMessage="Email Required"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceUName" runat="server" TargetControlID="reqName"
                                PopupPosition="Right">
                            </ajax:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="revtxtEmailId" runat="server" ErrorMessage="<%$ Resources:PFSalesResource, invalidemail %>"
                                ControlToValidate="txtEmailId" SetFocusOnError="true" Display="None" ValidationGroup="claim101"
                                ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*">
                            </asp:RegularExpressionValidator>
                            <ajax:ValidatorCalloutExtender ID="vceRegEmail" runat="server" TargetControlID="revtxtEmailId"
                                PopupPosition="Right">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                    </dl>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnClaim101" runat="server" Text="<%$Resources:PFSalesResource,Claim101 %>"
                            ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" OnClick="lnkbtnClaim101_Click"
                            ValidationGroup="claim101" CausesValidation="true"></asp:LinkButton>
                    </div>
                    <asp:GridView ID="gvprosp" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                        border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                        AutoGenerateColumns="false" rule="none" AllowPaging="false" AllowSorting="false"
                        PageSize="25">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,status %>" SortExpression="status">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfConsultant" runat="server" Value='<%#Bind("ConsultantId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfFinance" runat="server" Value='<%#Bind("Finance") %>' />
                                    <asp:HiddenField ID="hdfIsFleetTeamLead" runat="server" Value='<%#Bind("IsFleetTeamLead") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CarMake %>" SortExpression="Make">
                                <ItemTemplate>
                                    <asp:Label ID="lblCarMake" runat="server" Text='<%#Bind("Make") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,State %>" SortExpression="StateName">
                                <ItemTemplate>
                                    <asp:Label ID="lblState" runat="server" Text='<%#Bind("StateName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Consultant %>" SortExpression="Consultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblConsultant" runat="server" Text='<%#Bind("Consultant") %>'></asp:Label>
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
