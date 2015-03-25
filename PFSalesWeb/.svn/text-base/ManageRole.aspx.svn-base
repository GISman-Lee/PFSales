<%@ Page Title="<%$Resources:PFSalesResource,ManageRole %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="ManageRole.aspx.cs" Inherits="ManageRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnRoleMaster" runat="server">
        <ContentTemplate>
            <div class="mainbdr">
                <asp:Panel ID="pnlView" runat="server" DefaultButton="lnkSearchRole">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="SearchRoleHead" runat="server" Text="<%$Resources:PFSalesResource,SearchRole %>"></asp:Label>
                        <div class="addBtn">
                            <asp:LinkButton ID="lnkAddRole" runat="server" ToolTip="<%$Resources:PFSalesResource,AddRole %>"
                                OnClick="lnkAddRole_Click">
                                <asp:Image ID="imgAddFinance" ImageUrl="~/Images/add.png" runat="server" />
                                <asp:Label ID="lblAddFinanceBtn" runat="server" Text="<%$Resources:PFSalesResource,AddRole %>">
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
                                <asp:Label ID="lblRoleName" runat="server" Text="<%$ Resources:PFSalesResource, ltlRoleName %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtSearchRole" runat="server" CssClass="inputClass" MaxLength="50"></asp:TextBox>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkSearchRole" runat="server" Text="<%$ Resources:PFSalesResource, search %>"
                                ToolTip="<%$ Resources:PFSalesResource, search %>" OnClick="lnkSearchRole_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkClearRole" runat="server" Text="<%$ Resources:PFSalesResource, clear %>"
                                ToolTip="<%$ Resources:PFSalesResource, clear %>" OnClick="lnkClearRole_Click"></asp:LinkButton>
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
                                <asp:ListItem Value="150" Text="150" ></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:GridView ID="gvRoleList" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                            border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                            AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                            PageSize="50" ToolTip="<%$ Resources:PFSalesResource, hdrRoleList %>" OnPageIndexChanging="gvRoleList_PageIndexChanging"
                            OnSorting="gvRoleList_Sorting">
                            <Columns>
                                <asp:TemplateField HeaderText="<%$ Resources:PFSalesResource, SMRole %>" SortExpression="Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRole" runat="server" Text='<%#Bind("Role")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:PFSalesResource, description %>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc" runat="server" Text='<%#Bind("Description")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="30" HeaderText="<%$ Resources:PFSalesResource, Edit %>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEditRole" runat="server" ToolTip="<%$Resources:PFSalesResource,EditRole %>"
                                            OnClick="lnkEditRole_Click" CommandArgument='<%#Bind("RoleId")%>'><img src="Images/edit.png"/</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="40" HeaderText="<%$ Resources:PFSalesResource, Delete %>"
                                    Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDeleteRole" runat="server" Text="" OnClick="lnkDeleteRole_Click"
                                            OnClientClick="javascript:return confirm('Are Your Sure To delete this Role..?') "
                                            CommandArgument='<%#Bind("RoleId")%>' CssClass="delete"></asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></div></asp:Panel><asp:Panel ID="pnlAdd" runat="server" Visible="false" DefaultButton="lnkSaveRole">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="lblAddManageRoleHeader" runat="server" Text="<%$Resources:PFSalesResource,AddRoleDet%>"></asp:Label><div
                            class="addBtn">
                            <asp:LinkButton ID="lnkGotoSearch" runat="server" ToolTip="<%$Resources:PFSalesResource,BackToSearch %>"
                                OnClick="lnkGotoSearch_Click">

                            <asp:Image ID="imgBackToSearch" ImageUrl="~/Images/back.png" runat="server" />
 
                            
                            <asp:Label ID="lblBackToSearch" runat="server" Text="<%$Resources:PFSalesResource,BackToSearch %>"></asp:Label></asp:LinkButton></div></div><div class="Mandatory">
                        <asp:Label ID="lblMandetoryinfo" runat="server" Text="<%$Resources:PFSalesResource,MandetoryInfo %>"></asp:Label></div><div class="dilContener">
                        <div class="error" id="dvadderror" runat="server" visible="false">
                            <asp:Label ID="lblAddErrMsg" runat="server" Text=""></asp:Label></div><div class="success" id="dvaddSucc" runat="server" visible="false">
                            <asp:Label ID="lblAddSucMsg" runat="server" Text=""></asp:Label></div><dl class="dealerRagisterThree">
                            <dt>
                                <asp:Label ID="lblAddRoleName" runat="server" Text="<%$ Resources:PFSalesResource, ltlRoleName %>"></asp:Label><label>*</label>
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtRoleName" runat="server" CssClass="inputClass" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvRoleName" runat="server" ControlToValidate="txtRoleName" ErrorMessage="<%$ Resources:PFSalesResource, RoleNameRequired %>"
                                    Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator></dd><dt runat="server"
                                        visible="false">
                                        <asp:Label ID="lblAddCode" runat="server" Text="<%$ Resources:PFSalesResource, code %>"></asp:Label><label>*</label>
                                    </dt>
                            <dd runat="server" visible="false">
                                <asp:TextBox ID="txtCode" runat="server" CssClass="inputClass"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvtxtCode" runat="server" ControlToValidate="txtCode" ErrorMessage="<%$ Resources:PFSalesResource, CodeRequired %>"
                                    Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator></dd><dt>
                                        <asp:Label ID="lblAddDescription" runat="server" Text="<%$ Resources:PFSalesResource, description %>"></asp:Label></dt><dd
                                            style="height: 100px;">
                                            <asp:TextBox ID="txtDescription" CssClass="inputClass" Style="height: auto;" runat="server"
                                                Rows="4" TextMode="MultiLine"></asp:TextBox></dd></dl><div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkSaveRole" runat="server" Text="<%$ Resources:PFSalesResource, Save %>"
                                ToolTip="<%$ Resources:PFSalesResource, Save %>" OnClick="lnkSaveRole_Click"
                                ValidationGroup="save"></asp:LinkButton><asp:LinkButton ID="lnkCancelRole" runat="server"
                                    Text="<%$ Resources:PFSalesResource, Clear %>" ToolTip="<%$ Resources:PFSalesResource, Clear %>"
                                    OnClick="lnkCancelRole_Click"></asp:LinkButton></div></div></asp:Panel></div></ContentTemplate></asp:UpdatePanel><asp:UpdateProgress ID="upproProsp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="upnRoleMaster">
        <ProgressTemplate>
            <div id="progressBackgroundFilter">
            </div>
            <div id="processMessage">
                <span style="text-align: center;">
                    <img src="Images/loading.gif" />
                    <br />
                    <asp:Literal ID="ltrwait" runat="server" Text="<%$Resources:PFSalesResource,PleaseWait %>"></asp:Literal></span></div></ProgressTemplate></asp:UpdateProgress></asp:Content>