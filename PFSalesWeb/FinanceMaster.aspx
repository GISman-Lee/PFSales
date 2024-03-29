﻿<%@ Page Title="<%$Resources:PFSalesResource,FinanceMaster %>" Language="C#" MasterPageFile="~/PFSalesMaster.master" AutoEventWireup="true"
    CodeFile="FinanceMaster.aspx.cs" Inherits="FinanceMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanFinance" runat="server">
        <ContentTemplate>
            <div class="mainbdr">
                <asp:Panel ID="pnlSearchFinance" runat="server" DefaultButton="lnkbtnSearch">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="SearchFinanceHead" runat="server" Text="<%$Resources:PFSalesResource,SearchFinance %>"></asp:Label>
                        <div class="addBtn">
                            <asp:LinkButton ID="lnkbtnAddFinance" runat="server" ToolTip="<%$Resources:PFSalesResource,AddFinance %>"
                                OnClick="lnkbtnAddFinance_Click">
                                <asp:Image ID="imgAddFinance" ImageUrl="~/Images/add.png" runat="server" />
                                <asp:Label ID="lblAddFinanceBtn" runat="server" Text="<%$Resources:PFSalesResource,AddFinance %>">
                                </asp:Label>
                            </asp:LinkButton>
                        </div>
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
                                <asp:Label ID="lblFinance" runat="server" Text="<%$Resources:PFSalesResource,Finance %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtFinance" CssClass="inputClass" runat="server" MaxLength="200"></asp:TextBox>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                                ToolTip="<%$Resources:PFSalesResource,SearchFinance %>" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                        </div>
                        <div style="float: right; width: 16%">
                            <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                            <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                               <%-- <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem Value="25" Text="25"></asp:ListItem>--%>
                                <asp:ListItem Value="50" Text="50" Selected="True" ></asp:ListItem>
                                <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                <asp:ListItem Value="150" Text="150"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:GridView ID="gvFinance" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                            border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                            AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                            PageSize="50" OnPageIndexChanging="gvFinance_PageIndexChanging" OnRowDataBound="gvFinance_RowDataBound"
                            OnSorting="gvFinance_Soring">
                            <Columns>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Finance %>" SortExpression="Finance">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerFinance" runat="server" Text='<%#Bind("Finance") %>'></asp:Label>
                                        <asp:HiddenField ID="hdfFinanceId" runat="server" Value='<%#Bind("Id") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,description %>" HeaderStyle-Width="70%">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldescription" runat="server" Text='<%#Bind("FDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Edit %>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="<%$Resources:PFSalesResource,EditFinance %>"
                                            CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnEdit_Click">
                                    <img src="Images/edit.png"/>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Delete %>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" ToolTip="<%$Resources:PFSalesResource,DeleteFinance %>"
                                            CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnDelete_Click">
                                    <img src="Images/delet.png"/>
                                        </asp:LinkButton>
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
                <asp:Panel ID="pnlAddFinance" runat="server" Visible="false" DefaultButton="lnkbtnSave">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="lblAddFinanceHead" runat="server" Text="<%$Resources:PFSalesResource,AddFinance%>"></asp:Label>
                        <div class="addBtn">
                            <asp:LinkButton ID="lnkbtnBackToSearch" runat="server" ToolTip="<%$Resources:PFSalesResource,BackToSearch %>"
                                OnClick="lnkbtnBackToSearch_Click">
                                <asp:Image ID="imgBackToSearch" ImageUrl="~/Images/back.png" runat="server" />
                                <asp:Label ID="lblBackToSearch" runat="server" Text="<%$Resources:PFSalesResource,BackToSearch %>"></asp:Label></asp:LinkButton></div>
                    </div>
                    <div class="Mandatory">
                        <asp:Label ID="lblMandetoryinfo" runat="server" Text="<%$Resources:PFSalesResource,MandetoryInfo %>"></asp:Label>
                    </div>
                    <div class="dilContener">
                        <div class="error" id="dvadderror" runat="server" visible="false">
                            <asp:Label ID="lblAddErrMsg" runat="server" Text=""></asp:Label>
                        </div>
                        <!--Content-Note: success Msg-->
                        <div class="success" id="dvaddSucc" runat="server" visible="false">
                            <asp:Label ID="lblAddSucMsg" runat="server" Text=""></asp:Label>
                        </div>
                        <dl class="dealerRagisterThree">
                            <dt>
                                <label>
                                    *</label><asp:Label ID="lblAddFinance" runat="server" Text="<%$Resources:PFSalesResource,Finance %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtAddFinance" CssClass="inputClass" TabIndex="1" runat="server" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAddFinance" runat="server" ControlToValidate="txtAddFinance"
                                    SetFocusOnError="true" ValidationGroup="Save" Display="None" ErrorMessage="<%$Resources:PFSalesResource,AddFinanceVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceAddFinance" runat="server" TargetControlID="rfvAddFinance"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                        </dl>
                        <dl class="dealerRagisterThree">
                            <dt>
                                <asp:Label ID="lblDesc" runat="server" Text="<%$Resources:PFSalesResource,description %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtDesc" CssClass="inputClass" TextMode="MultiLine" Rows="4" TabIndex="2"
                                    runat="server" MaxLength="500"></asp:TextBox>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSave" runat="server" Text="<%$ Resources:PFSalesResource,Save %>"
                                ToolTip="<%$ Resources:PFSalesResource,SaveFinance %>" OnClick="lnkbtnSave_Click"
                                ValidationGroup="Save" TabIndex="3"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnFinalClear" runat="server" Text="<%$ Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$ Resources:PFSalesResource,Clear %>" OnClick="lnkbtnFinalClear_Click"
                                CausesValidation="false" TabIndex="4"></asp:LinkButton>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproFinance" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpPanFinance">
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
