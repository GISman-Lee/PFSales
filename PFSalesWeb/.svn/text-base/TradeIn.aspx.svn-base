<%@ Page Title="<%$ Resources:PFSalesResource,TradeIn%>" Language="C#" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="TradeIn.aspx.cs" MasterPageFile="~/PFSalesMaster.master"
    Inherits="AddProspects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanPrspect" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlSearchprosp" runat="server" Visible="false" DefaultButton="lnkbtnSearch">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,SearchProspect %>"></asp:Label>
                    <div class="addBtn">
                        <asp:LinkButton ID="lnkbtnAddprosp" runat="server" ToolTip="<%$Resources:PFSalesResource,ProspectList %>"
                            OnClick="lnkbtnAddprosp_Click" Visible="false">
                            <asp:Image ID="imgAddprosp" ImageUrl="~/Images/add.png" runat="server" />
                            <asp:Label ID="lblAddprosp" runat="server" Text="<%$Resources:PFSalesResource,Addprospect %>"> </asp:Label></asp:LinkButton>
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
                            <asp:Label ID="lblprospName" runat="server" Text="<%$Resources:PFSalesResource,Name %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtserprospName" CssClass="inputClass" MaxLength="160" runat="server"></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblStatus" runat="server" Text="<%$Resources:PFSalesResource,Status %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlStatus" CssClass="selectClass" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                    </dl>
                    <dl class="dealerRagisterTwo">
                        <dt>
                            <asp:Label ID="lblEmailID" runat="server" Text="<%$Resources:PFSalesResource,EmailId %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmailId" CssClass="inputClass" MaxLength="160" runat="server"></asp:TextBox>
                        </dd>
                    </dl>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                            ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                            ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                    </div>
                    <div style="float: left; width: 100%; margin-top: 10px;">
                        <div style="float: left; width: 74%">
                            <dl class="dealerRagisterTwo ">
                                <%--<dt style="width: 100px;">
                                    <asp:LinkButton ID="lnkbtnFilterAlloc" runat="server" ToolTip="<%$Resources:PFSalesResource,FinacefrmFincar %>">
                                        <div style="color: black; height: 15px; padding-bottom: 5px; padding-left: 5px; padding-right: 5px;
                                            padding-top: 5px; text-align: center; width: 130px; background-color: #D6FFBC;
                                            border: solid 1px #737373; text-align: center;">
                                            <asp:Label ID="lblAllocatedLegend" runat="server" Text="<%$Resources:PFSalesResource,FinacefrmFincar %>"></asp:Label>
                                        </div>
                                    </asp:LinkButton>
                                </dt>
                                <dd style="width: 40px;">
                                </dd>--%>
                                <dt>
                                    <asp:LinkButton ID="lnkbtnFleetTeamLead" runat="server" ToolTip="<%$Resources:PFSalesResource,FleetTeamLead %>">
                                        <div id="dvFilterFleetTeamLead" style="color: black; height: 15px; padding-bottom: 5px;
                                            padding-left: 5px; padding-right: 5px; padding-top: 5px; text-align: center;
                                            width: 130px; background-color: #FFCDCD; border: solid 1px #737373; text-align: center;"
                                            runat="server">
                                            <asp:Label ID="lblFleetTeamLead" runat="server" Text="<%$Resources:PFSalesResource,FleetTeamLead %>"></asp:Label>
                                        </div>
                                    </asp:LinkButton>
                                </dt>
                                <dd style="width: 40px;">
                                </dd>
                                <%-- <dt style="width: 100px;">
                                            <asp:LinkButton ID="lnkbtnClearFilter" runat="server" ToolTip="<%$Resources:PFSalesResource,ClearFilter %>"
                                                OnClick="lnkbtnClearFilter_Click" Visible="false">
                                                <div id="dvClearFilter" runat="server" style="color: black; height: 15px; padding-bottom: 5px;
                                                    padding-left: 5px; padding-right: 5px; padding-top: 5px; text-align: center;
                                                    width: 130px; background-color: White; border: solid 1px #737373; text-align: center;">
                                                    <asp:Label ID="lblClearFilter" runat="server" Text="<%$Resources:PFSalesResource,ClearFilter %>"></asp:Label>
                                                </div>
                                            </asp:LinkButton>
                                        </dt>--%>
                            </dl>
                        </div>
                        <div style="float: right; width: 16%">
                            <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                            <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                <%--<asp:ListItem Value="5" Text="5"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem Value="25" Text="25" Selected="True"></asp:ListItem>--%>
                                <asp:ListItem Value="50" Text="50" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                <asp:ListItem Value="150" Text="150"></asp:ListItem>
                                <asp:ListItem Value="1" Text="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <asp:GridView ID="gvprosp" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                        border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                        AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                        PageSize="50" OnPageIndexChanging="gvprosp_PageIndexChanging" OnSorting="gvprosp_Soring"
                        OnRowDataBound="gvprosp_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EnquiryDateHead %>" SortExpression="CreatedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("EnquiryDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFAllocationDate %>"
                                SortExpression="AllocatedDateSort">
                                <ItemTemplate>
                                    <asp:Label ID="lblPFAllocationDate" runat="server" Text='<%#Bind("PFAllocatedDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCAllocationDate %>"
                                SortExpression="FAlocationDateSort" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCAllocationDate" runat="server" Text='<%#Bind("FAlocationDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    <asp:HiddenField ID="_hdfTotCount" runat="server" Value='<%#Bind("TodActCnt") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CarMake %>" SortExpression="Make">
                                <ItemTemplate>
                                    <asp:Label ID="lblMake" runat="server" Text='<%#Bind("Make") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Model %>" SortExpression="Model">
                                <ItemTemplate>
                                    <asp:Label ID="lblPostalCode" runat="server" Text='<%#Bind("Model") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfStateId" runat="server" Value='<%#Bind("StateId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,State %>" SortExpression="StateName">
                                <ItemTemplate>
                                    <asp:Label ID="lblStates" runat="server" Text='<%#Bind("StateName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFConsultant %>" SortExpression="PfConsultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblPfConsultant" runat="server" Text='<%#Bind("PfConsultant") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFstatus %>" SortExpression="status">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfPropStatusId" runat="server" Value='<%#Bind("StatusId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCConsultant %>" SortExpression="FCConsultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCConsultant" runat="server" Text='<%#Bind("FCConsultant") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCstatus %>" SortExpression="FCStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCstatus" runat="server" Text='<%#Bind("FCStatus") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfFCPropStatusId" runat="server" Value='<%#Bind("FCStatusId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Edit %>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="<%$Resources:PFSalesResource,Editprosp %>"
                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnEdit_Click" Visible="false">
                                    <img src="Images/edit.png"/>
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
            <asp:Panel ID="pnlAddProsp" runat="server" DefaultButton="lnkbtnSave">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="lblAddProspHead" runat="server" Text="<%$Resources:PFSalesResource,AddTradeInDet %>"></asp:Label>
                    <div class="addBtn">
                        <asp:LinkButton ID="lnkbtnBackToSearch" runat="server" ToolTip="<%$Resources:PFSalesResource,BackToSearch %>"
                            OnClick="lnkbtnBackToSearch_Click">
                            <asp:Image ID="imgBackToSearch" ImageUrl="~/Images/back.png" runat="server" />
                            <asp:Label ID="lblBackToSearch" runat="server" Text="<%$Resources:PFSalesResource,BackToManage %>"></asp:Label></asp:LinkButton></div>
                </div>
                <div class="Mandatory">
                    <asp:Label ID="lblMandetoryinfo" runat="server" Text="<%$Resources:PFSalesResource,MandetoryInfo %>"></asp:Label>
                </div>
                <div class="dilContener">
                    <div class="error" id="dvadderror" runat="server" visible="false">
                        <asp:Label ID="lblAddErrMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <!--Content-Note: success Msg dealerRagisterThree-->
                    <div class="success" id="dvaddSucc" runat="server" visible="false">
                        <asp:Label ID="lblAddSucMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divgvTradein">
                        <asp:GridView ID="gvTradein" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                            border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                            AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                            PageSize="50" OnPageIndexChanging="gvprosp_PageIndexChanging" OnSorting="gvprosp_Soring"
                            OnRowDataBound="gvprosp_RowDataBound">
                            <Columns>
                                <%-- <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EnquiryDateHead %>" SortExpression="CreatedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("EnquiryDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFAllocationDate %>"
                                SortExpression="AllocatedDateSort">
                                <ItemTemplate>
                                    <asp:Label ID="lblPFAllocationDate" runat="server" Text='<%#Bind("PFAllocatedDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCAllocationDate %>"
                                SortExpression="FAlocationDateSort" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCAllocationDate" runat="server" Text='<%#Bind("FAlocationDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    <asp:HiddenField ID="_hdfTotCount" runat="server" Value='<%#Bind("TodActCnt") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CarMake %>" SortExpression="Make">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMake" runat="server" Text='<%#Bind("Make") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Model %>" SortExpression="Model">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostalCode" runat="server" Text='<%#Bind("Model") %>'></asp:Label>
                                        <%--<asp:HiddenField ID="hdfStateId" runat="server" Value='<%#Bind("StateId") %>' />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,TradeIn %>" SortExpression="TradeInNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTradeInNo" runat="server" Text='<%#Bind("TradeInNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFConsultant %>" SortExpression="PfConsultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblPfConsultant" runat="server" Text='<%#Bind("PfConsultant") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFstatus %>" SortExpression="status">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfPropStatusId" runat="server" Value='<%#Bind("StatusId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCConsultant %>" SortExpression="FCConsultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCConsultant" runat="server" Text='<%#Bind("FCConsultant") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCstatus %>" SortExpression="FCStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCstatus" runat="server" Text='<%#Bind("FCStatus") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfFCPropStatusId" runat="server" Value='<%#Bind("FCStatusId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Edit %>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="<%$Resources:PFSalesResource,Editprosp %>"
                                            CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnEdit_Click">
                                    <img src="Images/edit.png"/>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center">
                                    <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoTradeInDataFound %>"></asp:Label>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                   <%-- <div style="float: left; width: 90%">
                    </div>--%>
                    <div class="headText">
                        <b>
                            <asp:Literal ID="ltrProspectDetailsHead" runat="server" Text="Prospect Details"></asp:Literal>
                        </b>
                    </div>
                    <dl class="dealerRagisterThree">
                        <dt>
                            <%--<label>
                                *</label>--%>
                            <asp:Label ID="lblTitle" runat="server" Text="<%$Resources:PFSalesResource,Title %>"></asp:Label>:</dt>
                        <dd>
                            <asp:DropDownList ID="ddlTitle" TabIndex="1" CssClass="selectClass" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="ddlTitle"
                                SetFocusOnError="true" ValidationGroup="SaveContact" InitialValue="0" Display="None"
                                ErrorMessage="<%$Resources:PFSalesResource,TitleVal %>"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceTitle" runat="server" TargetControlID="rfvTitle"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%>
                        </dd>
                        <dt runat="server" visible="false">
                            <asp:Label ID="lblAddMname" runat="server" Text="<%$Resources:PFSalesResource,MName %>"></asp:Label>:
                        </dt>
                        <dd runat="server" visible="false">
                            <asp:TextBox ID="txtMName" CssClass="inputClass" runat="server" MaxLength="50"></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblAddLName" runat="server" Text="<%$Resources:PFSalesResource,LName %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtLName" CssClass="inputClass" TabIndex="3" runat="server" MaxLength="50"></asp:TextBox>
                        </dd>
                        <%--<dt>
                            <asp:Label ID="lblUsed" runat="server" Text="<%$ Resources:PFSalesResource,NewOrUsed %>"></asp:Label>
                        </dt>
                        <dd>
                            <asp:RadioButton ID="rbtnNew" CssClass="allchklist" runat="server" TabIndex="7" Text="<%$ Resources:PFSalesResource,New %>"
                                Checked="true" GroupName="NewOrUsed" />
                            <asp:RadioButton ID="rbtnUsed" runat="server" CssClass="allchklist" TabIndex="8"
                                Text="<%$ Resources:PFSalesResource,Used %>" GroupName="NewOrUsed" />
                        </dd>--%>
                        <dt>
                            <label>
                                *</label><asp:Label ID="lblEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailId %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmail1" CssClass="inputClass" TabIndex="5" runat="server" MaxLength="250"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail1"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,EmailVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="rfvEmail"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="revtxtEmailId" runat="server" ErrorMessage="<%$ Resources:PFSalesResource, invalidemail %>"
                                ControlToValidate="txtEmail1" SetFocusOnError="true" Display="None" ValidationGroup="SaveContact"
                                ValidationExpression="^\s*(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*\s*$"></asp:RegularExpressionValidator>
                            <ajax:ValidatorCalloutExtender ID="vceregEmail" runat="server" TargetControlID="revtxtEmailId"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="rfvEmailforSendMail" runat="server" ControlToValidate="txtEmail1"
                                Display="None" ValidationGroup="SendEmail" ErrorMessage="<%$ Resources:PFSalesResource,EmailVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceEmailForSendMail" runat="server" TargetControlID="rfvEmailforSendMail"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="revtxtEmailIdForSendMail" runat="server" ErrorMessage="<%$ Resources:PFSalesResource, invalidemail %>"
                                ControlToValidate="txtEmail1" SetFocusOnError="true" Display="None" ValidationGroup="SendEmail"
                                ValidationExpression="^\s*(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*\s*$"></asp:RegularExpressionValidator>
                            <ajax:ValidatorCalloutExtender ID="vceregEmailForMailSend" runat="server" TargetControlID="revtxtEmailIdForSendMail"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <%--<dt>
                            <label>
                                *</label><asp:Label ID="lblPhoneNo" runat="server" Text="<%$ Resources:PFSalesResource,PhoneNo %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtPhNo" CssClass="inputClass" TabIndex="12" Width="160" MaxLength="20"
                                runat="server"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="ftePhNo" runat="server" TargetControlID="txtPhNo"
                                FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:MaskedEditExtender ID="msePhNo" runat="server" TargetControlID="txtPhNo" BehaviorID="MEE"
                                MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                                ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnPhPopUp" runat="server" TabIndex="13" OnClick="lnkbtnPhPopUp_Click">....</asp:LinkButton>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhNo"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,PhoneNoVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vcePhone" runat="server" TargetControlID="rfvPhone"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>--%>
                        <dt id="Dt2" runat="server" visible="false">
                            <asp:Label ID="lblFax" runat="server" Text="<%$ Resources:PFSalesResource,Fax %>"></asp:Label>:
                        </dt>
                        <dd id="Dd2" runat="server" visible="false">
                            <asp:TextBox ID="txtFax" CssClass="inputClass" MaxLength="30" Width="160" runat="server"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="fteFax" runat="server" TargetControlID="txtFax"
                                FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:MaskedEditExtender ID="mseFax" runat="server" TargetControlID="txtFax" BehaviorID="MEE2"
                                MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                                ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnFax" runat="server" OnClick="lnkbtnFax_Click">....</asp:LinkButton></div>
                        </dd>
                        <dt runat="server" visible="false">
                            <label>
                                *</label>
                            <asp:Label ID="lblState" runat="server" Text="<%$ Resources:PFSalesResource,State %>"></asp:Label>:
                        </dt>
                        <dd runat="server" visible="false">
                            <asp:DropDownList ID="ddlState" CssClass="selectClass" TabIndex="15" runat="server"
                                OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                                InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,StateVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="rfvState"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%><%--TradeIn--%>
                        </dd>
                        <dt runat="server" visible="false">
                            <%--<label>
                                *</label>--%>
                            <asp:Label ID="lblCity" runat="server" Text="<%$ Resources:PFSalesResource,City %>"></asp:Label>:
                        </dt>
                        <dd runat="server" visible="false">
                            <asp:DropDownList ID="ddlCity" TabIndex="17" CssClass="selectClass" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                                InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CityVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="rfvCity"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%>
                        </dd>
                        <dt id="Dt3" runat="server" visible="false">
                            <asp:Label ID="lblAddressLine2" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine2 %>"></asp:Label>:</dt>
                        <dd id="Dd3" runat="server" visible="false">
                            <asp:TextBox ID="txtAddLine2" CssClass="inputClass" runat="server" MaxLength="250"></asp:TextBox>
                        </dd>
                        <%--<dt>
                            <label>
                                *</label>
                            <asp:Label ID="lblFinance" runat="server" Text="<%$ Resources:PFSalesResource,Finance %>"></asp:Label>:</dt>
                        <dd>
                            <asp:DropDownList ID="ddlFinance" CssClass="selectClass" TabIndex="19" runat="server">
                                
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvFinance" runat="server" ControlToValidate="ddlFinance"
                                InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,FinanceVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceFinance" runat="server" TargetControlID="rfvFinance"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>--%>
                        <dt runat="server" visible="false">
                            <asp:Label ID="lblConsultant" runat="server" Text="<%$ Resources:PFSalesResource,Consultant %>"></asp:Label>:</dt>
                        <dd runat="server" visible="false">
                            <asp:DropDownList ID="ddlConsultant" CssClass="selectClass" Enabled="false" TabIndex="21"
                                runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdfConsultID" runat="server" Value="0" />
                        </dd>
                        <%--<dt>
                            <label>
                                *</label><asp:Label ID="lblSource" runat="server" Text="<%$ Resources:PFSalesResource,ProspectSrc %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSource" CssClass="selectClass" TabIndex="23" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlSource_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvSource" runat="server" ControlToValidate="ddlSource"
                                InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,ProspectSrcVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceSource" runat="server" TargetControlID="rfvSource"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt>
                            <asp:Label ID="lblTradeIn" runat="server" Text="<%$ Resources:PFSalesResource,TradeIn %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:CheckBox ID="chkTradeIn" runat="server" TabIndex="25" />
                        </dd>
                        <dt id="dtalCont" runat="server">
                           
                            <asp:Label ID="lblAlternateNo" runat="server" Text="<%$ Resources:PFSalesResource,AlternateContNo %>"></asp:Label>
                        </dt>
                        <dd id="ddalCont" runat="server">
                           
                            <asp:TextBox ID="txtAltContNo" CssClass="inputClass" MaxLength="34" TabIndex="27"
                                Width="160" runat="server"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="fteAlteContNo" runat="server" TargetControlID="txtAltContNo"
                                FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:MaskedEditExtender ID="meeAltContNo" runat="server" TargetControlID="txtAltContNo"
                                BehaviorID="MEE1" MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                                ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnAlterContNo" runat="server" OnClick="lnkbtnAlterContNo_Click"
                                    TabIndex="28">....</asp:LinkButton></div>
                        </dd>--%>
                        <dt id="Dt1" runat="server" visible="false">
                            <asp:Label ID="lblNovtedLease" runat="server" Text="<%$ Resources:PFSalesResource,NovatedLease %>"></asp:Label>
                        </dt>
                        <dd id="Dd1" runat="server" visible="false">
                            <asp:RadioButton ID="rbtnYes" CssClass="allchklist" runat="server" TabIndex="29"
                                Text="<%$ Resources:PFSalesResource,Yes %>" Checked="true" GroupName="NewOrUsed" />
                            <asp:RadioButton ID="rbtnNo" runat="server" CssClass="allchklist" TabIndex="30" Text="<%$ Resources:PFSalesResource,No %>"
                                GroupName="NewOrUsed" />
                        </dd>
                        <dt id="Dt4" runat="server" visible="false">
                            <asp:Label ID="lblTradeInMakeModel" runat="server" Text="<%$ Resources:PFSalesResource,TradeInMakeModel %>"></asp:Label>:
                        </dt>
                        <dd id="Dd4" runat="server" visible="false">
                            <asp:TextBox ID="txtTradeInMakeModel" runat="server" TabIndex="35"></asp:TextBox>
                        </dd>
                        <%--<dt>
                            <asp:Label ID="lblPhoto" runat="server" Text="<%$ Resources:PFSalesResource,Photo %>"></asp:Label>:</dt>
                        <dd>
                            <asp:FileUpload ID="fupEmpPhoto" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvEmpPhoto" runat="server" ControlToValidate="fupEmpPhoto"
                                ErrorMessage="<%$ Resources:PFSalesResource,PhotoUploadVal %>" ValidationGroup="Upload"
                                SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="reExpValSyllabus" ControlToValidate="fupEmpPhoto"
                                Display="Dynamic" ValidationGroup="Upload" runat="Server" ErrorMessage="<%$Resources:PFSalesResource,EmpPhotoUploadVal %>"
                                ValidationExpression="[a-zA-Z0_9].*\b(.jpg|.jpeg|.Jpg|.JPG|.Jpeg|.JPEG|.png|.Png|.PNG|.bmp|.Bmp|.BMP|.gif|.Gif|.GIF)\b" />
                        </dd>--%>
                    </dl>
                    <dl class="dealerRagisterThree">
                        <dt id="Dt5" runat="server" visible="false">
                            <label>
                                *</label>
                            <asp:Label ID="lblName" runat="server" Text="<%$ Resources:PFSalesResource,Name %>"></asp:Label>:
                        </dt>
                        <dd id="Dd5" runat="server" visible="false">
                            <asp:TextBox ID="txtAddName" Enabled="false" CssClass="inputClass" runat="server"
                                MaxLength="750"></asp:TextBox>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnNamePopUp" Visible="false" runat="server" ValidationGroup="showName"
                                    OnClick="lnkbtnNamePopUp_Click">....</asp:LinkButton></div>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtAddName"
                                Display="None" Enabled="false" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,EmpNameVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceName" runat="server" TargetControlID="rfvName"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="rfvnameForPopUp" runat="server" ControlToValidate="txtAddName"
                                Display="None" ValidationGroup="showName" ErrorMessage="<%$ Resources:PFSalesResource,EmpNameVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceNameForPopUp" runat="server" TargetControlID="rfvnameForPopUp"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt>
                            <label>
                                *</label><asp:Label ID="lblAddFName" runat="server" Text="<%$Resources:PFSalesResource,FName %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtFName" CssClass="inputClass" TabIndex="2" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFName" runat="server" ControlToValidate="txtFName"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,FNameVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceFName" runat="server" TargetControlID="rfvFName"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt runat="server" visible="false">
                            <%--<label>
                                *</label>--%>
                            <asp:Label ID="lblMemberNo" runat="server" Text="<%$ Resources:PFSalesResource,MemberNo %>"></asp:Label>:</dt>
                        <dd runat="server" visible="false">
                            <asp:TextBox ID="txtMemNo" CssClass="inputClass" TabIndex="4" runat="server" MaxLength="50"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvMemNo" runat="server" ControlToValidate="txtMemNo"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,MemNoVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceMomNo" runat="server" TargetControlID="rfvMemNo"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%>
                        </dd>
                        <%--<dt>
                            <asp:Label ID="lblWhereDidUHear" runat="server" Text="<%$ Resources:PFSalesResource,WhereDidUHearabtPF %>"></asp:Label></dt>
                        <dd>
                            <asp:DropDownList ID="ddlWhereDidUHear" CssClass="selectClass" TabIndex="9" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlWhereDidUHear_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>--%>
                        <dt id="Dt6" runat="server" visible="false">
                            <asp:Label ID="lblAltEmail" runat="server" Text="<%$ Resources:PFSalesResource,AlternameEmail %>"></asp:Label>:
                        </dt>
                        <dd id="Dd6" runat="server" visible="false">
                            <asp:TextBox ID="txtAlterEmail" CssClass="inputClass" runat="server" MaxLength="250"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revAlterEmail" runat="server" ErrorMessage="<%$ Resources:PFSalesResource, invalidemail %>"
                                ControlToValidate="txtAlterEmail" SetFocusOnError="true" Display="None" ValidationGroup="SaveContact"
                                ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"></asp:RegularExpressionValidator>
                            <ajax:ValidatorCalloutExtender ID="vceAlterEmail" runat="server" TargetControlID="revAlterEmail"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt>
                            <%--<label>
                                *</label>--%>
                            <asp:Label ID="lblMobile" runat="server" Text="<%$ Resources:PFSalesResource,MobileNo %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtMobile" CssClass="inputClass" TabIndex="4" MaxLength="20" Width="160"
                                runat="server"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="fteMobile" runat="server" TargetControlID="txtMobile"
                                FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:MaskedEditExtender ID="mseMobile" runat="server" TargetControlID="txtMobile"
                                BehaviorID="MEE4" MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                                ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnMobile" runat="server" TabIndex="15" OnClick="lnkbtnMobile_Click">....</asp:LinkButton></div>
                            <%-- <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,MobileNoVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceMob" runat="server" TargetControlID="rfvMobile"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%>
                        </dd>
                        <dt runat="server" visible="false">
                            <label>
                                *</label><asp:Label ID="lblCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country %>"></asp:Label>:</dt>
                        <dd runat="server" visible="false">
                            <asp:DropDownList ID="ddlCountry" CssClass="selectClass" TabIndex="14" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                                InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CountryVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceCountry" runat="server" TargetControlID="rfvCountry"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%><%--TradeIn--%>
                        </dd>
                        <dt>
                            <label>
                                *</label><asp:Label ID="lblPhoneNo" runat="server" Text="<%$ Resources:PFSalesResource,PhoneNo %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtPhNo" CssClass="inputClass" TabIndex="6" Width="160" MaxLength="20"
                                runat="server"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="ftePhNo" runat="server" TargetControlID="txtPhNo"
                                FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:MaskedEditExtender ID="msePhNo" runat="server" TargetControlID="txtPhNo" BehaviorID="MEE"
                                MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                                ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnPhPopUp" runat="server" TabIndex="13" OnClick="lnkbtnPhPopUp_Click">....</asp:LinkButton>
                            </div>
                            <%--<asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhNo"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,PhoneNoVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                            <%--<ajax:ValidatorCalloutExtender ID="vcePhone" runat="server" TargetControlID="rfvPhone"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%>
                        </dd>
                        <dt runat="server" visible="false">
                            <label>
                                *</label><asp:Label ID="lblPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</dt>
                        <dd runat="server" visible="false">
                            <%-- <asp:DropDownList ID="ddlPostalCode" TabIndex="16" CssClass="selectClass" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlPostalCode_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>--%>
                            <%--<asp:TextBox ID="txtPostalCode" CssClass="inputClass" TabIndex="21" runat="server"
                                MaxLength="10"></asp:TextBox>--%>
                            <%--   <ajax:FilteredTextBoxExtender ID="ftePostalCode" runat="server" TargetControlID="txtPostalCode"
                                FilterType="Custom" ValidChars="0123456789">
                            </ajax:FilteredTextBoxExtender>--%>
                            <%--<asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="ddlPostalCode"
                                Display="None" InitialValue="0" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,PostalVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vcePostalCode" runat="server" TargetControlID="rfvPostalCode"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%>
                            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputClass" TabIndex="16"
                                MaxLength="4" OnTextChanged="txtPostalCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <ajax:AutoCompleteExtender ID="acePostalCode" runat="server" ServicePath="~/GetAllPcodes.asmx"
                                ServiceMethod="GetPcodeList" TargetControlID="txtPostalCode" MinimumPrefixLength="1">
                            </ajax:AutoCompleteExtender>
                            <ajax:FilteredTextBoxExtender ID="ftePostalCode" runat="server" TargetControlID="txtPostalCode"
                                FilterType="Custom" ValidChars="0123456789">
                            </ajax:FilteredTextBoxExtender>
                            <%--<asp:RequiredFieldValidator ID="rfvPCode" runat="server" ControlToValidate="txtPostalCode"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,PCodeVal %>"
                                SetFocusOnError="true" Enabled="false"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vcePCode" runat="server" TargetControlID="rfvPCode"
                                PopupPosition="TopRight">--%><%--TradeIn--%>
                            <%--</ajax:ValidatorCalloutExtender>--%>
                        </dd>
                        <dt runat="server" visible="false">
                            <asp:Label ID="lblAddressLine1" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine1 %>"></asp:Label>:</dt>
                        <dd runat="server" visible="false">
                            <asp:TextBox ID="txtAddLine1" runat="server" TabIndex="18" CssClass="inputClass"
                                MaxLength="250"></asp:TextBox>
                            <%--<asp:TextBox ID="TextBox2" CssClass="inputClass" Width="160" runat="server"></asp:TextBox>
                                <div class="popUpViewBtn">
                                    <asp:LinkButton ID="LinkButton4" runat="server">....</asp:LinkButton></div>--%>
                        </dd>
                        <dt id="Dt7" runat="server" visible="false">
                            <asp:Label ID="lblAddressLine3" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine3 %>"></asp:Label>:</dt>
                        <dd id="Dd7" runat="server" visible="false">
                            <asp:TextBox ID="txtAddLine3" CssClass="inputClass" runat="server" MaxLength="250"></asp:TextBox>
                        </dd>
                        <%--<dt>
                            <asp:Label ID="lblFConsultant" runat="server" Text="<%$ Resources:PFSalesResource,FConsultant %>"></asp:Label></dt>
                        <dd>
                            <asp:TextBox ID="txtFConsultant" runat="server" CssClass="inputClass" MaxLength="150"
                                Visible="false"></asp:TextBox>
                            <asp:DropDownList ID="ddlFConsultant" runat="server" CssClass="selectClass" Enabled="false"
                                TabIndex="20">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdfFConsultID" runat="server" Value="0" />
                        </dd>--%>
                        <dt runat="server" visible="false">
                            <label>
                                *</label><asp:Label ID="lblAddStatus" runat="server" Text="<%$ Resources:PFSalesResource,Status %>"></asp:Label>:</dt>
                        <dd runat="server" visible="false">
                            <asp:DropDownList ID="ddlAddStatus" CssClass="selectClass" TabIndex="22" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlAddStatus"
                                InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,StatusVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceStatus" runat="server" TargetControlID="rfvStatus"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%><%--TradeIn--%>
                        </dd>
                        <%--<dt>
                            <label>
                                *</label><asp:Label ID="lblRefferedBy" runat="server" Text="<%$ Resources:PFSalesResource,ReferredBy %>"></asp:Label></dt>
                        <dd>
                            <asp:TextBox ID="txtReferredBy" runat="server" TabIndex="24" CssClass="inputClass"
                                MaxLength="250"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvReferredBy" runat="server" ControlToValidate="txtReferredBy"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,ReferredByVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceReferredBy" runat="server" TargetControlID="rfvReferredBy"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt style="height: auto">
                            <asp:Label ID="lblComment" runat="server" Text="<%$ Resources:PFSalesResource,Comments %>"></asp:Label></dt>
                        <dd style="height: auto">
                            <asp:TextBox ID="txtComments" runat="server" TabIndex="26" TextMode="MultiLine" Style="height: auto"
                                Rows="4" CssClass="inputClass" MaxLength="1000"></asp:TextBox>
                        </dd>--%>
                        <%-- <dt>
                            <div class="button">
                                <asp:LinkButton ID="lnkbtnUpload" runat="server" Text="<%$ Resources:PFSalesResource,Upload %>"
                                    ToolTip="<%$ Resources:PFSalesResource,EmpPhotoUpload %>" ValidationGroup="Upload"
                                    OnClick="lnkbtnUpload_Click"></asp:LinkButton>
                            </div>
                        </dt>
                        <dd style="height: auto;">
                            <asp:Image ID="imgEmpPhoto" runat="server" CssClass="c" Style="width: 122px;" ImageUrl="~/Images/NoPhoto.png" />
                        </dd>--%>
                    </dl>
                    <dl id="dlSendMail" runat="server" style="width: 100%; float: left;">
                        <dt style="width: 58%; float: left;">
                            <%-- <Edit:Editor ID="EdSendEmail" runat="server" Width="100%" InitialCleanUp="true" />--%>
                            <dd style="width: 30%; float: left; margin-left: 25px;">
                                <div class="button" style="float: left;">
                                    <asp:LinkButton ID="lnkbtnSendEmail" runat="server" OnClick="lnkbtnSendEmail_Click"
                                        Text="<%$ Resources:PFSalesResource,SendEmail %>" ToolTip="<%$ Resources:PFSalesResource,SendEmail %>"
                                        ValidationGroup="SendEmail" TabIndex="29" Visible="false"></asp:LinkButton>
                                </div>
                            </dd>
                        </dt>
                    </dl>
                    <asp:Panel ID="pnlVehicleSpecifications" runat="server" Style="float: left; width: 100%;
                        height: auto;">
                        <div class="headText">
                        <b>
                            <asp:Literal ID="ltrlVehicleSpec" runat="server" Text="Vehicles Specifications"></asp:Literal>
                        </b>
                        </div>
                        <dl class="contactDetailsPop">
                            <dt>
                                <asp:Label ID="lblBuildPlateDate" runat="server" Text="<%$Resources:PFSalesResource,BuildPlateDate %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlMonthBuild" Width="65px" runat="server" TabIndex="6">
                                    <asp:ListItem Value="0">-Month-</asp:ListItem>
                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                    <asp:ListItem Value="9">Sept</asp:ListItem>
                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlYearBuild" Width="75px" TabIndex="8" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMonthBuild"
                                    CssClass="gvValidationError" InitialValue="0" Display="None" ErrorMessage="Please Select the Month"
                                    SetFocusOnError="True" ValidationGroup="SaveContact">
                                </asp:RequiredFieldValidator><ajax:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender100"
                                    TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlYearBuild"
                                    CssClass="gvValidationError" Display="None" ErrorMessage="Please Select the Year"
                                    SetFocusOnError="True" InitialValue="-Year-" ValidationGroup="SaveContact">
                                </asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender200" TargetControlID="RequiredFieldValidator5"
                                    HighlightCssClass="validatorCalloutHighlight" />
                                <%--<asp:TextBox ID="txtBuildPlateDate" CssClass="inputClass" TabIndex="13" Width="105px"
                                    runat="server"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtnBuildPlateDate" runat="server" Style="float: left">
                                    <asp:Image ID="imgBuildPlateDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtBuildPlateDate" 
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnBuildPlateDate">
                                </ajax:CalendarExtender>
                                <asp:Label Style="padding-left: 4px; color: Red" ID="lblDobinfo" Visible="false"
                                    runat="server" Text="<%$Resources:PFSalesResource,Setdateformat %>">
                                </asp:Label>
                                <ajax:MaskedEditExtender ID="meeDob" runat="server" MaskType="None" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                    TargetControlID="txtBuildPlateDate" MessageValidatorTip="true">
                                </ajax:MaskedEditExtender>
                                <asp:CompareValidator ID="cvDOB" runat="server" Type="Date" Operator="DataTypeCheck"
                                    ControlToValidate="txtBuildPlateDate" ValidationGroup="Save" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                    Display="None">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCompDOB" runat="server" TargetControlID="cvDOB"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:MaskedEditValidator ID="mskEValStrDate" ControlExtender="meeDob" ControlToValidate="txtBuildPlateDate"
                                    runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, DOBVal %>"
                                    ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="true"
                                    ValidationGroup="Save">
                                </ajax:MaskedEditValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDob" runat="server" TargetControlID="mskEValStrDate"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                                <%-- <asp:CompareValidator ID="CompValToTodayDate" runat="server" ControlToValidate="txtBuildPlateDate"
                                    ErrorMessage="<%$ Resources:PFSalesResource,DOBTodayVal %>" CssClass="errorMsg"
                                    ValueToCompare="" Operator="LessThan" ValidationGroup="GetCountTot" Type="Date"
                                    Display="None">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceTotToToday" runat="server" TargetControlID="CompValToTodayDate"
                                    PopupPosition="TopLeft">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt>
                                <label>
                                    *</label><asp:Label ID="lblCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlCarMake" TabIndex="11" AutoPostBack="true" OnSelectedIndexChanged="ddlCarMake_SelectedIndexChanged"
                                    CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCarMake" runat="server" ControlToValidate="ddlCarMake"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCarMake" runat="server" TargetControlID="rfvCarMake"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="lblActualMakeInput" runat="server"></asp:Label>
                            </dd>
                            <dt>
                                <asp:Label ID="lblSeies" runat="server" Text="<%$ Resources:PFSalesResource,Series %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtSeries" runat="server" TabIndex="13" CssClass="inputClass" MaxLength="20"></asp:TextBox>
                                <%--<asp:DropDownList ID="ddlfinReq" runat="server" TabIndex="31" CssClass="selectClass">
                                    <asp:ListItem Value="0">Select finance required</asp:ListItem>
                                    <asp:ListItem Value="Personal Finance">Personal Finance</asp:ListItem>
                                    <asp:ListItem Value="Business Finance">Business Finance</asp:ListItem>
                                    <asp:ListItem Value="Novated Leases">Novated Leases</asp:ListItem>
                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                </asp:DropDownList>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblOdometer" runat="server" Text="<%$ Resources:PFSalesResource,OdometerKms %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtOdometer" runat="server" TabIndex="15" CssClass="inputClass"
                                    MaxLength="20"></asp:TextBox>
                                <%--<asp:DropDownList ID="ddlCredHistory" runat="server" TabIndex="33" CssClass="selectClass">
                                    <asp:ListItem Value="0">Select credit history</asp:ListItem>
                                    <asp:ListItem Value="Good">Good</asp:ListItem>
                                    <asp:ListItem Value="Average">Average</asp:ListItem>
                                    <asp:ListItem Value="Poor">Poor</asp:ListItem>
                                </asp:DropDownList>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblBodyStyle" runat="server" Text="<%$ Resources:PFSalesResource,BodyStyle %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtBodyStyle" runat="server" TabIndex="17" CssClass="inputClass"
                                    MaxLength="20"></asp:TextBox>
                                <%-- <ajax:FilteredTextBoxExtender ID="fteEstFin" runat="server" TargetControlID="txtEstFin"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789.">
                            </ajax:FilteredTextBoxExtender>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblIntTrimColor" runat="server" Text="<%$ Resources:PFSalesResource,InteriorTrimColor %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtIntTrimColor" runat="server" TabIndex="19" CssClass="inputClass"
                                    MaxLength="20"></asp:TextBox>
                                <%-- <ajax:FilteredTextBoxExtender ID="fteInitialDep" runat="server" TargetControlID="txtInitialDep"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789.">
                            </ajax:FilteredTextBoxExtender>--%>
                            </dd>
                            <%--<dt>
                                <asp:Label ID="lblltrEmployment" runat="server" Text="<%$ Resources:PFSalesResource,Employment %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlEmployment" runat="server" TabIndex="38" CssClass="selectClass">
                                    <asp:ListItem Value="0">Select Employment</asp:ListItem>
                                    <asp:ListItem Value="Casual">Casual</asp:ListItem>
                                    <asp:ListItem Value="Full Time">Full Time</asp:ListItem>
                                    <asp:ListItem Value="Part Time">Part Time</asp:ListItem>
                                    <asp:ListItem Value="Self Employed">Self Employed</asp:ListItem>
                                    <asp:ListItem Value="Sole Trader">Sole Trader</asp:ListItem>
                                    <asp:ListItem Value="Partnership">Partnership</asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblltrCurrentIncome" runat="server" Text="<%$ Resources:PFSalesResource,CurrentIncome %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtCurrentIncome" runat="server" TabIndex="40" CssClass="inputClass"
                                    MaxLength="10"></asp:TextBox>
                            </dd>
                            <dt style="height: auto">
                                <asp:Label ID="lblltrTimeAtCurAdd" runat="server" Text="<%$ Resources:PFSalesResource,TimeAtCurAdd %>"></asp:Label>
                            </dt>
                            <dd style="height: auto">
                                <asp:DropDownList ID="ddlTimeAtCurAdd" runat="server" TabIndex="42" CssClass="selectClass">
                                    <asp:ListItem Value="0">Select Time at current address</asp:ListItem>
                                    <asp:ListItem Value="Less Than 3 years">Less Than 3 years</asp:ListItem>
                                    <asp:ListItem Value="Greater Than 3 years">Greater Than 3 years</asp:ListItem>
                                </asp:DropDownList>
                            </dd>--%>
                        </dl>
                        <dl class="contactDetailsPop">
                            <dt>
                                <asp:Label ID="lblComplianceDate" runat="server" Text="<%$Resources:PFSalesResource,ComplianceDate%>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlComplianceMonth" Width="65px" TabIndex="9" runat="server">
                                    <asp:ListItem Value="0">-Month-</asp:ListItem>
                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                    <asp:ListItem Value="9">Sept</asp:ListItem>
                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlComplianceYear" Width="75px" TabIndex="10" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlComplianceMonth"
                                    CssClass="gvValidationError" InitialValue="0" Display="None" ErrorMessage="Please Select the Month"
                                    SetFocusOnError="True" ValidationGroup="SaveContact">
                                </asp:RequiredFieldValidator><ajax:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender1"
                                    TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlComplianceYear"
                                    CssClass="gvValidationError" Display="None" ErrorMessage="Please Select the Year"
                                    SetFocusOnError="True" InitialValue="-Year-" ValidationGroup="SaveContact">
                                </asp:RequiredFieldValidator><ajax:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender4"
                                    TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight" />
                                <%--<asp:TextBox ID="txtComplianceDate" CssClass="inputClass" TabIndex="13" Width="105px"
                                    runat="server"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtnComplianceDate" runat="server" Style="float: left">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtComplianceDate"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnComplianceDate">
                                </ajax:CalendarExtender>
                                <asp:Label Style="padding-left: 4px; color: Red" ID="Label2" Visible="false" runat="server"
                                    Text="<%$Resources:PFSalesResource,Setdateformat %>">
                                </asp:Label>
                                <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date"
                                    Mask="<%$ Resources:PfSalesResource, masktype %>" TargetControlID="txtComplianceDate"
                                    MessageValidatorTip="true">
                                </ajax:MaskedEditExtender>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" Operator="DataTypeCheck"
                                    ControlToValidate="txtComplianceDate" ValidationGroup="Save" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                    Display="None">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="cvDOB"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:MaskedEditValidator ID="MaskedEditValidator1" ControlExtender="meeDob" ControlToValidate="txtComplianceDate"
                                    runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, DOBVal %>"
                                    ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="true"
                                    ValidationGroup="Save">
                                </ajax:MaskedEditValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="mskEValStrDate"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                                <%--<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDOB"
                                    ErrorMessage="<%$ Resources:PFSalesResource,DOBTodayVal %>" CssClass="errorMsg"
                                    ValueToCompare="" Operator="LessThan" ValidationGroup="GetCountTot" Type="Date"
                                    Display="None">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="CompValToTodayDate"
                                    PopupPosition="TopLeft">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt>
                                <label>
                                    *</label><asp:Label ID="lblModel" runat="server" Text="<%$ Resources:PFSalesResource,Model %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlModel" TabIndex="12" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvModel" runat="server" ControlToValidate="ddlModel"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,ModelVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceModel" runat="server" TargetControlID="rfvModel"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="lblActualModelInput" runat="server"></asp:Label>
                            </dd>
                            <dt>
                                <asp:Label ID="lblEngineType" runat="server" Text="<%$ Resources:PFSalesResource,EngineTypeSize %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtEngineType" runat="server" TabIndex="14" CssClass="inputClass"
                                    MaxLength="20"></asp:TextBox>
                                <%-- <asp:DropDownList ID="ddlTermYears" runat="server" TabIndex="32" CssClass="selectClass">
                                    <asp:ListItem Value="0">Select years</asp:ListItem>
                                    <asp:ListItem Value="1 year">1</asp:ListItem>
                                    <asp:ListItem Value="2 years">2</asp:ListItem>
                                    <asp:ListItem Value="3 years">3</asp:ListItem>
                                    <asp:ListItem Value="4 years">4</asp:ListItem>
                                    <asp:ListItem Value="5 years">5</asp:ListItem>
                                    <asp:ListItem Value="6 years">6</asp:ListItem>
                                    <asp:ListItem Value="7 years">7</asp:ListItem>
                                    <asp:ListItem Value="8 years">8</asp:ListItem>
                                    <asp:ListItem Value="9 years">9</asp:ListItem>
                                    <asp:ListItem Value="10 years">10</asp:ListItem>
                                </asp:DropDownList>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblTransmission" runat="server" Text="<%$ Resources:PFSalesResource,Transmission %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtTransmission" runat="server" TabIndex="16" CssClass="inputClass"
                                    MaxLength="20"></asp:TextBox>
                                <%-- <ajax:FilteredTextBoxExtender ID="fteResBaloon" runat="server" TargetControlID="txtResBaloon"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789.">
                            </ajax:FilteredTextBoxExtender>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblExtColor" runat="server" Text="<%$ Resources:PFSalesResource,ExteriorColor %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtExtColor" runat="server" TabIndex="18" CssClass="inputClass"
                                    MaxLength="20"></asp:TextBox>
                                <%--<asp:TextBox ID="txtFCMessage" runat="server" TabIndex="36" CssClass="inputClass"
                                    MaxLength="500" TextMode="MultiLine" Rows="3" Style="height: auto; margin-bottom: 10px;"></asp:TextBox>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblRegoExpires" runat="server" Text="<%$ Resources:PFSalesResource,RegoExpires %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtRegoExpires" runat="server" TabIndex="20" CssClass="inputClass"
                                    MaxLength="50"></asp:TextBox>
                            </dd>
                            <%--<dt style="height: auto">
                                <asp:Label ID="lblltrTimeinCurEmp" runat="server" Text="<%$ Resources:PFSalesResource,TimeinCurEmp %>"></asp:Label>
                            </dt>
                            <dd style="height: auto">
                                <asp:DropDownList ID="ddlTimeinCurEmp" runat="server" TabIndex="41" CssClass="selectClass">
                                    <asp:ListItem Value="0">Select Current Employment Time</asp:ListItem>
                                    <asp:ListItem Value="Less Than 3 months">Less Than 3 months</asp:ListItem>
                                    <asp:ListItem Value="Less Than 1 year">Less Than 1 year</asp:ListItem>
                                    <asp:ListItem Value="Less Than 3 years">Less Than 3 years</asp:ListItem>
                                    <asp:ListItem Value="Over 3 years">Over 3 years</asp:ListItem>
                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt id="Dt8" runat="server" visible="false">
                                <asp:Label ID="lblltrFinFrom" runat="server" Text="<%$ Resources:PFSalesResource,FinanceRequestFrom %>"></asp:Label>
                            </dt>
                            <dd id="Dd8" runat="server" visible="false">
                                <asp:DropDownList ID="ddlFinReqFrom" runat="server" TabIndex="42" Visible="false"
                                    CssClass="selectClass">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>--%>
                        </dl>
                    </asp:Panel>
                    <%--                    <div class="headText">
                    </div>
                    <dl class="dealerRagisterTwo">
                        <dt>
                            <asp:Label ID="lblSelContact" runat="server" Text="<%$Resources:PFSalesResource,SelectContact %>"></asp:Label>:
                        </dt>
                        <dd>
                        </dd>
                    </dl>
                    <asp:GridView ID="gvContact" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                        border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                        AutoGenerateColumns="false" rule="none" AllowSorting="true" OnSorting="gvContact_Soring"
                        OnRowCreated="gvContact_Created">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckChanged" onclick="CheckAllGridCheckbox('GvSetAlert', this.id, 'chkSelect')" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckChanged" />
                                    <asp:HiddenField ID="hdfContactId" runat="server" Value='<%#Bind("ContactId") %>' />
                                    <asp:HiddenField ID="hdfProspContId" runat="server" Value='<%#Bind("ProspConId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmailId %>" SortExpression="EmailId">
                                <ItemTemplate>
                                    <asp:Label ID="lblContEmailId" runat="server" Text='<%#Bind("EmailId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,MobileNo %>" SortExpression="MobileNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblContMobileNo" runat="server" Text='<%#Bind("MobileNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PhoneNo %>" SortExpression="PhoneNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblContPhone" runat="server" Text='<%#Bind("PhoneNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,IsPrimary %>">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbtnIsPrimary" runat="server" AutoPostBack="true" OnCheckedChanged="rbtnIsPrimary_CheckChanged" Enabled="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div align="center">
                                <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoDataFound %>"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>--%>
                    <asp:Panel ID="pnlOptionalExtras" runat="server" Style="float: left; width: 100%;
                        height: auto;">
                        <div class="headText">
                        <b>
                            <asp:Literal ID="ltrlOptionalExtras" runat="server" Text="Optional Extras"></asp:Literal>
                        </b>
                        </div>
                        <dl class="checkboxwrap">
                            <dt>
                                <asp:CheckBox ID="chkLeather" runat="server" TabIndex="21" />
                                <asp:Label ID="lblLeather" runat="server" Text="<%$Resources:PFSalesResource,Leather %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkRevSensor" runat="server" TabIndex="22" />
                                <asp:Label ID="lblRevSensor" runat="server" Text="<%$Resources:PFSalesResource,ReverseSensors %>"></asp:Label>
                            </dd>
                            <dt>
                                <asp:CheckBox ID="chkLaneChangeAssist" runat="server" TabIndex="25" />
                                <asp:Label ID="lblLaneChangeAssist" runat="server" Text="<%$Resources:PFSalesResource,LaneChangeAssist %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkProtectProduct" runat="server" TabIndex="26" />
                                <asp:Label ID="lblProtectProduct" runat="server" Text="<%$Resources:PFSalesResource,ProtectionProducts %>"></asp:Label>
                            </dd>
                            <dt>
                                <asp:CheckBox ID="chkBluetoothFactory" runat="server" TabIndex="29" />
                                <asp:Label ID="lblBluetoothFactory" runat="server" Text="<%$Resources:PFSalesResource,BluetoothFactory %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkElectricSeats" runat="server" TabIndex="30" />
                                <asp:Label ID="lblElectricSeats" runat="server" Text="<%$Resources:PFSalesResource,ElectricSeats %>"></asp:Label>
                            </dd>
                            <dt>
                                <%--<asp:CheckBox ID="chkCentralLock" runat="server" />
                                <asp:Label ID="lblCentralLock" runat="server" Text="<%$Resources:PFSalesResource,CentralLocking %>"></asp:Label>--%>
                                <asp:CheckBox ID="chkThirdRowSeats" runat="server" TabIndex="33" />
                                <asp:Label ID="lblThirdRowSeats" runat="server" Text="<%$Resources:PFSalesResource,ThirdRowSeats %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkTint" runat="server" TabIndex="34" />
                                <asp:Label ID="lblTint" runat="server" Text="<%$Resources:PFSalesResource,Tint %>"></asp:Label>
                            </dd>
                            <dt>
                                <asp:CheckBox ID="chkTV" runat="server" TabIndex="37" />
                                <asp:Label ID="lblTV" runat="server" Text="<%$Resources:PFSalesResource,TV %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkSatNav" runat="server" TabIndex="38" />
                                <asp:Label ID="lblSatNav" runat="server" Text="<%$Resources:PFSalesResource,SatNav %>"></asp:Label>
                            </dd>
                            <dt>
                                <asp:CheckBox ID="chkFourByFour" runat="server" TabIndex="41" />
                                <asp:Label ID="lblFourByFour" runat="server" Text="<%$Resources:PFSalesResource,FourByFour %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkTwoByTwo" runat="server" TabIndex="42" />
                                <asp:Label ID="lblTwoByTwo" runat="server" Text="<%$Resources:PFSalesResource,TwoByTwo %>"></asp:Label>
                            </dd>
                        </dl>
                        <dl class="checkboxwrap">
                            <dt>
                                <asp:CheckBox ID="chkTimingBeltChange" runat="server" TabIndex="23" />
                                <asp:Label ID="lblTimingBeltChange" runat="server" Text="<%$Resources:PFSalesResource,TimingBeltChanged %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkXenonLights" runat="server" TabIndex="24" />
                                <asp:Label ID="lblXenonLights" runat="server" Text="<%$Resources:PFSalesResource,XenonLights %>"></asp:Label>
                            </dd>
                            <dt>
                                <asp:CheckBox ID="chkActCruiseControl" runat="server" TabIndex="27" />
                                <asp:Label ID="lblActCruiseControl" runat="server" Text="<%$Resources:PFSalesResource,ActiveCruiseControl %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkTowBar" runat="server" TabIndex="28" />
                                <asp:Label ID="lblTowBar" runat="server" Text="<%$Resources:PFSalesResource,TowBar %>"></asp:Label>
                            </dd>
                            <dt>
                                <asp:CheckBox ID="chkReverseCamera" runat="server" TabIndex="31" />
                                <asp:Label ID="lblReverseCamera" runat="server" Text="<%$Resources:PFSalesResource,ReverseCamera %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkBullBar" runat="server" TabIndex="32" />
                                <asp:Label ID="lblBullBar" runat="server" Text="<%$Resources:PFSalesResource,BullBar %>"></asp:Label>
                            </dd>
                            <dt>
                                <asp:CheckBox ID="chkSunroof" runat="server" TabIndex="35" />
                                <asp:Label ID="lblSunroof" runat="server" Text="<%$Resources:PFSalesResource,Sunroof %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkPanoramic" runat="server" TabIndex="36" />
                                <asp:Label ID="lblPanoramic" runat="server" Text="<%$Resources:PFSalesResource,Panoramic %>"></asp:Label>
                            </dd>
                            <dt>
                                <asp:CheckBox ID="chkRoofRacks" runat="server" TabIndex="39" />
                                <asp:Label ID="lblRoofRacks" runat="server" Text="<%$Resources:PFSalesResource,RoofRacks %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkSideSteps" runat="server" TabIndex="40" />
                                <asp:Label ID="lblSideSteps" runat="server" Text="<%$Resources:PFSalesResource,SideSteps %>"></asp:Label>
                            </dd>
                            <dt>
                                <%-- <asp:CheckBox ID="chkAlarm" runat="server" />
                                <asp:Label ID="lblAlarm" runat="server" Text="<%$Resources:PFSalesResource,Alarm %>"></asp:Label>--%>
                            </dt>
                            <dd>
                                <%--<asp:CheckBox ID="chkThirdRowSeats" runat="server" />
                                <asp:Label ID="lblThirdRowSeats" runat="server" Text="<%$Resources:PFSalesResource,ThirdRowSeats %>"></asp:Label>--%>
                            </dd>
                        </dl>
                        <%--<dl class="contactDetailsPop">
                            <dt>
                                <asp:Label ID="lblCD" runat="server" Text="<%$Resources:PFSalesResource,CD %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:DropDownList runat="server" ID="ddlCD" CssClass="selectClass" Width="180px">
                                    <asp:ListItem Value="None">None</asp:ListItem>
                                    <asp:ListItem Value="Single">Single</asp:ListItem>
                                    <asp:ListItem Value="6-Stacker">6-Stacker</asp:ListItem>
                                    <asp:ListItem Value="10-Stacker">10-Stacker</asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                        </dl>
                        <dl class="contactDetailsPop">
                            <dt>
                                <asp:Label ID="lblAirBags" runat="server" Text="<%$Resources:PFSalesResource,AirBags %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:DropDownList runat="server" ID="ddlAirBags" CssClass="selectClass" Width="180px">
                                    <asp:ListItem Value="None">None</asp:ListItem>
                                    <asp:ListItem Value="Single">Single</asp:ListItem>
                                    <asp:ListItem Value="Dual">Dual</asp:ListItem>
                                    <asp:ListItem Value="Multiple">Multiple</asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                        </dl>--%>
                        <dl class="contactDetailsPop">
                            <dt>
                                <asp:Label ID="lblFuelType" runat="server" Text="<%$Resources:PFSalesResource,FuelType %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:DropDownList runat="server" ID="ddlFuelType" CssClass="selectClass" TabIndex="43"
                                    Width="180px">
                                    <asp:ListItem Value="0">None</asp:ListItem>
                                    <asp:ListItem Value="Petrol">Petrol</asp:ListItem>
                                    <asp:ListItem Value="Diesel">Diesel</asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                        </dl>
                        <dl class="contactDetailsPop">
                            <dt>
                                <asp:Label ID="lblDoor" runat="server" Text="<%$Resources:PFSalesResource,Door %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:DropDownList runat="server" ID="ddlDoor" TabIndex="44" CssClass="selectClass"
                                    Width="180px">
                                    <asp:ListItem Value="0">None</asp:ListItem>
                                    <asp:ListItem Value="2Door">2Door</asp:ListItem>
                                    <asp:ListItem Value="4Door">4Door</asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                        </dl>
                        <dl class="contactDetailsPop">
                            <dt>
                                <asp:Label ID="lblWheelsAlloys" runat="server" Text="<%$Resources:PFSalesResource,WheelsAlloys %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:DropDownList runat="server" ID="ddlWheelsAlloys" TabIndex="45" CssClass="selectClass"
                                    Width="180px">
                                    <asp:ListItem Value="0">None</asp:ListItem>
                                    <asp:ListItem Value="18">16"</asp:ListItem>
                                    <asp:ListItem Value="19">17"</asp:ListItem>
                                    <asp:ListItem Value="18">18"</asp:ListItem>
                                    <asp:ListItem Value="19">19"</asp:ListItem>
                                    <asp:ListItem Value="20">20"</asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                        </dl>
                        <dl class="twocol2">
                            <dt>
                                <asp:Label ID="lblOtherOptions" runat="server" Text="<%$ Resources:PFSalesResource,OtherOptions %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtOtherOptions" runat="server" TabIndex="46" Style="width: 60%;
                                    height: 40px;" CssClass="inputClass" MaxLength="500" TextMode="MultiLine"></asp:TextBox></dd>
                        </dl>
                    </asp:Panel>
                    <asp:Panel ID="pnlConditions" runat="server" Style="float: left; width: 100%; height: auto;">
                        <div class="headText">
                        <b>
                            <asp:Literal ID="ltrlConditions" runat="server" Text="Condition"></asp:Literal>
                        </b>
                        </div>
                        <div class="divfull">
                            <p>
                                Please rate overall condition of your vehicleout of 10 where the following apply:</p>
                            <asp:DropDownList ID="ddlRating" TabIndex="47" CssClass="selectClass" Style="float: right;
                                margin-top: -17px; margin-right: 104px;" runat="server">
                                <%--<asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>--%>
                                <%--<asp:ListItem Value="0">Select years</asp:ListItem>--%>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvRating" runat="server" ControlToValidate="ddlRating"
                                InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="rfvRating"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                            <asp:Label ID="Label57" runat="server"></asp:Label>
                        </div>
                        <dl class="twocol2">
                            <dt>
                                <asp:Label ID="lblExcellent" runat="server" Text="10=Excellent"></asp:Label>:</dt>
                            <dd>
                                <p>
                                    A vehicle in excellent condition is free of any mechanical or cosmetic damage and
                                    has full service history.</p>
                            </dd>
                            <dt>
                                <asp:Label ID="lblGood" runat="server" Text="7=Good"></asp:Label>:</dt>
                            <dd>
                                <p>
                                    A vehicle in good condition which has no mechanical problems, good service history
                                    and few if any cosmetic blemishes.</p>
                            </dd>
                            <dt>
                                <asp:Label ID="lblFair" runat="server" Text="4=Fair"></asp:Label>:</dt>
                            <dd>
                                <p>
                                    <%--A vehicle in fair condition may need body, paint and work, but can be safely driven
                                    and is assumed to have a reasonable history and is roadworking.--%>
                                    A vehicle in slightly fair condition and may need body and paint work but can be
                                    safely driven and is assumed to have a reasonable history and is roadworthy.</p>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPoor" runat="server" Text="1=Poor"></asp:Label>:</dt>
                            <dd>
                                <p>
                                    A vehicle in poor condition has mechanical and/or cosmetic damage that mey not be
                                    easily repaired. The vehicle would be unlikely to pass any roadworthy examination.</p>
                            </dd>
                        </dl>
                        <dl class="contactDetailsPop">
                            <dt>
                                <asp:Label ID="lblGlasswork" runat="server" Text="<%$Resources:PFSalesResource,Glasswork %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlGlasswork" TabIndex="48" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvGlasswork" runat="server" ControlToValidate="ddlCarMake"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rfvGlasswork"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label30" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblBodyPanels" runat="server" Text="<%$ Resources:PFSalesResource,BodyPanels %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlBodyPanels" TabIndex="50" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvBodyPanels" runat="server" ControlToValidate="ddlBodyPanels"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rfvBodyPanels"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                                <%--<asp:Label ID="Label32" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPaint" runat="server" Text="<%$ Resources:PFSalesResource,Paint %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlPaint" TabIndex="52" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="rfvPaint" runat="server" ControlToValidate="ddlPaint"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rfvPaint"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label45" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblTyres" runat="server" Text="<%$ Resources:PFSalesResource,Tyres %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlTyres" TabIndex="54" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="rfvTyres" runat="server" ControlToValidate="ddlCarMake"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="rfvTyres"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label46" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblRimsAlloys" runat="server" Text="<%$ Resources:PFSalesResource,RimsAlloys %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlRimsAlloys" TabIndex="56" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvRimsAlloys" runat="server" ControlToValidate="ddlRimsAlloys"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="rfvRimsAlloys"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label47" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblUpholstery" runat="server" Text="<%$ Resources:PFSalesResource,Upholstery %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlUpholstery" TabIndex="58" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvUpholstery" runat="server" ControlToValidate="ddlUpholstery"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="rfvUpholstery"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label48" runat="server"></asp:Label>--%>
                            </dd>
                        </dl>
                        <dl class="contactDetailsPop">
                            <dt>
                                <asp:Label ID="lblEngine" runat="server" Text="<%$Resources:PFSalesResource,Engine %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlEngine" TabIndex="49" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvEngine" runat="server" ControlToValidate="ddlEngine"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="rfvEngine"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label38" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblTransmission1" runat="server" Text="<%$ Resources:PFSalesResource,Transmission %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlTransmission" TabIndex="51" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvTransmission" runat="server" ControlToValidate="ddlTransmission"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="rfvTransmission"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label40" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblBrakes" runat="server" Text="<%$ Resources:PFSalesResource,Brakes %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlBrakes" TabIndex="53" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="rfvBrakes" runat="server" ControlToValidate="ddlBrakes"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="rfvBrakes"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label49" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAC" runat="server" Text="<%$ Resources:PFSalesResource,AirConditioning %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlAC" TabIndex="55" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvAC" runat="server" ControlToValidate="ddlAC" InitialValue="0"
                                    Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="rfvAC"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label50" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblHeadlights" runat="server" Text="<%$ Resources:PFSalesResource,Headlights %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlHeadlights" TabIndex="57" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvHeadlights" runat="server" ControlToValidate="ddlHeadlights"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="rfvHeadlights"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label51" runat="server"></asp:Label>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblSpareTyre" runat="server" Text="<%$ Resources:PFSalesResource,SpareTyre %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlSpareTyre" TabIndex="59" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="As New" Text="As New"></asp:ListItem>
                                    <asp:ListItem Value="Good" Text="Good"></asp:ListItem>
                                    <asp:ListItem Value="Requires Repair" Text="Requires Repair"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvSpareTyre" runat="server" ControlToValidate="ddlSpareTyre"
                                    InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" TargetControlID="rfvSpareTyre"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="Label52" runat="server"></asp:Label>--%>
                            </dd>
                        </dl>
                        <%--<div>--%>
                        <%--</div>--%>
                    </asp:Panel>
                    <%--<asp:LinkButton ID="lnkbtnOtherInfo" runat="server">Other Information</asp:LinkButton>--%>
                    <%-- <ajax:CollapsiblePanelExtender ID="cpeOtherInfo" runat="server" TargetControlID="pnlOtherInfo" Collapsed="True" CollapseControlID="lnkbtnOtherInfo" ExpandControlID="lnkbtnOtherInfo"></ajax:CollapsiblePanelExtender> --%>
                    <asp:Panel ID="pnlOtherInfo" runat="server" Style="float: left; width: 100%; height: auto;">
                        <div class="headText">
                        <b>
                            <asp:Literal ID="ltrlOtherInfo" runat="server" Text="Other Information"></asp:Literal>
                        </b>
                        </div>
                        <dl class="twocol">
                            <dt>
                                <asp:Label ID="lblDescDent" runat="server" Text="Please Descibe any dents, marks, scratches or unfair wear and tear on the car (including size)+ Price to repair"></asp:Label></dt>
                            <dd>
                                <asp:TextBox ID="txtDescDent" runat="server" TabIndex="60" Style="width: 100%; height: 40px;"
                                    CssClass="inputClass" MaxLength="500" TextMode="MultiLine"></asp:TextBox></dd>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAccident" runat="server" Text="Has the vehicle been in any accident, floods received hail damage or had any paintworks?"></asp:Label></dt>
                            <dd>
                                <asp:TextBox ID="txtAccident" runat="server" TabIndex="61" Style="width: 100%; height: 40px;"
                                    CssClass="inputClass" MaxLength="500" TextMode="MultiLine"></asp:TextBox></dd>
                            </dd>
                            <dt>
                                <asp:Label ID="lblOwners" runat="server" Text="How many people(including yourself) have owned this vehicle?"></asp:Label></dt>
                            <dd>
                                <asp:DropDownList runat="server" ID="ddlOwners" TabIndex="62" CssClass="selectClass"
                                    Width="180px">
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblRepalce" runat="server" Text=" Odometer when tyres last replaced"></asp:Label></dt>
                            <dd>
                                <asp:TextBox ID="txtRepalce" runat="server" TabIndex="63" Style="width: 100%; height: 40px;"
                                    CssClass="inputClass" MaxLength="500" TextMode="MultiLine"></asp:TextBox></dd>
                            </dd>
                            <dt>
                                <asp:Label ID="lblLogBook" runat="server" Text="How complete is the service history(Log books)?"></asp:Label></dt>
                            <dd>
                                <asp:DropDownList runat="server" ID="ddlLogBook" TabIndex="64" CssClass="selectClass"
                                    Width="180px">
                                    <asp:ListItem Value="Full Dealer History">Full Dealer History</asp:ListItem>
                                    <asp:ListItem Value="Full Aftermarket History">Full Aftermarket History</asp:ListItem>
                                    <asp:ListItem Value="Part Service History">Part Service History</asp:ListItem>
                                    <asp:ListItem Value="No Service History">No Service History</asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPayout" runat="server" Text="Is there a payout on the car? if so how much?"></asp:Label></dt>
                            <dd>
                                <asp:TextBox ID="txtPayout" runat="server" TabIndex="65" Style="width: 100%; height: 40px;"
                                    CssClass="inputClass" MaxLength="500" TextMode="MultiLine"></asp:TextBox></dd>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAnything" runat="server" Text="If there is anything else relevent, please add it here. (eg ex taxi, new engine etc) "></asp:Label>
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtAnything" runat="server" TabIndex="66" Style="width: 100%; height: 40px;"
                                    CssClass="inputClass" MaxLength="500" TextMode="MultiLine"></asp:TextBox></dd>
                            </dd>
                            <p style="font-family: 'Times New Roman'; font-size: x-small">
                                IF THE CAR IS PERSONAL IMPORT EX HIRE CAR OR REPAIRABLE WRITE OFF, THE CAR NEEDS
                                TO BE TAKEN TO AN INSPECTION SECTION OTHERWISE IT WILL NOT BE ABLE TO BE TRADED</p>
                        </dl>
                    </asp:Panel>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnUpdate" runat="server" TabIndex="67" Text="<%$ Resources:PFSalesResource,Update %>"
                            ToolTip="<%$ Resources:PFSalesResource,Update %>" OnClick="lnkbtnUpdate_Click"
                            Visible="false" ValidationGroup="SaveContact"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnSave" runat="server" TabIndex="68" Text="<%$ Resources:PFSalesResource,Save %>"
                            ToolTip="<%$ Resources:PFSalesResource,SaveEmployee %>" OnClick="lnkbtnSave_Click"
                            ValidationGroup="SaveContact"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnFinalClear" runat="server" Text="<%$ Resources:PFSalesResource,Clear %>"
                            ToolTip="<%$ Resources:PFSalesResource,Clear %>" TabIndex="69" CausesValidation="false"
                            OnClick="lnkbtnFinalClear_Click"></asp:LinkButton>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlphonePopUp" runat="server" Visible="false" DefaultButton="lnkbtnPhPoUpOk">
                <div class="pop-up">
                </div>
                <div class="contentPopUp">
                    <div class="popHeader">
                        <asp:Label ID="lblPhPopUpPhone" runat="server" Text="<%$ Resources:PFSalesResource,EnterPhoneNumber%>"></asp:Label>
                        <asp:LinkButton ID="lnkbtnPhPopClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                            OnClick="lnkbtnPhPopClose_Click"><img src="Images/delet.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                    </div>
                    <div class="dilContenerTwo">
                        <dl class="settled">
                            <dt>
                                <asp:Label ID="lblPhPopUpCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country%>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlPhPopUpCountry" CssClass="selectClass" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlPhPopUpCountry_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPhFormat" runat="server" Text="<%$Resources:PFSalesResource,Format %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlPhFormat" CssClass="selectClass" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlPhFormat_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvPhFormat" runat="server" ControlToValidate="ddlPhFormat"
                                    ValidationGroup="PhonePopUp" Display="None" SetFocusOnError="true" InitialValue="0"
                                    ErrorMessage="<%$Resources:PFSalesResource,PhoneFormat %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcePhFormat" runat="server" TargetControlID="rfvPhFormat"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPhPopUpPhNo" runat="server" Text="<%$Resources:PFSalesResource,PhoneNo%>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtPhPopUpPhoNo" CssClass="inputClass" runat="server"></asp:TextBox>
                                <%--  <ajax:FilteredTextBoxExtender ID="ftePhPopUpPhNo" runat="server" TargetControlID="txtPhPopUpPhoNo"
                                        FilterType="Custom" ValidChars="%()- ">
                                    </ajax:FilteredTextBoxExtender>--%>
                                <ajax:FilteredTextBoxExtender ID="ftePhPopUpPhNo" runat="server" TargetControlID="txtPhPopUpPhoNo"
                                    FilterType="Custom" ValidChars="+0123456789" Enabled="true">
                                </ajax:FilteredTextBoxExtender>
                                <ajax:MaskedEditExtender ID="msePhPopUp" runat="server" TargetControlID="txtPhPopUpPhoNo"
                                    BehaviorID="MEE5" MaskType="None" Mask="999999999999999999999999999" MessageValidatorTip="true"
                                    InputDirection="LeftToRight" ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnEditFormat" runat="server" Text="<%$Resources:PFSalesResource,EditFormats %>"
                                ToolTip="<%$Resources:PFSalesResource,EditFormatToolTip %>" Visible="false"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnPhPoUpOk" runat="server" Text="<%$Resources:PFSalesResource,OK %>"
                                ToolTip="<%$Resources:PFSalesResource,OK %>" OnClick="lnkbtnPhPoUpOk_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnPhPopUpCancel" runat="server" Text="<%$Resources:PFSalesResource,Cancel %>"
                                ToolTip="<%$Resources:PFSalesResource,Close %>" OnClick="lnkbtnPhPopClose_Click"></asp:LinkButton></div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlContactPopUp" runat="server" Visible="false" DefaultButton="lnkbtnNamePopUpOk">
                <div class="pop-up">
                </div>
                <div class="contentPopUp" style="top: 9%; width: 500px; margin-left: -74%;">
                    <div class="popHeader">
                        <asp:Label ID="lblPopupName" runat="server" Text="<%$ Resources:PFSalesResource,EmpName %>"></asp:Label>
                        <asp:LinkButton ID="lnkbtnNamePopUpClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                            OnClick="lnkbtnNamePopUpClose_Close"><img src="Images/delet.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                    </div>
                    <div class="dilContenerTwo">
                        <p>
                            PFSales! uses the First Name and Surname for sorting and lookups.</p>
                        <br />
                        <p>
                            PFSales! has determined the following to be the first Name, Middle Name, and Surname
                            of this contact. If any of these names is incorrect, select the correct name from
                            the dropdown list.</p>
                        <div class="headText">
                        </div>
                        <h5>
                            <asp:Literal ID="ltrNameDet" runat="server" Text="<%$ Resources:PFSalesResource,NameDetails %>"></asp:Literal>
                        </h5>
                        <dl class="settled">
                            <dt>
                                <asp:Label ID="lblContPopUpName" runat="server" Text="<%$ Resources:PFSalesResource,EmpName %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtPopUpName" runat="server" disabled="disabled" CssClass="inputClass"></asp:TextBox>
                            </dd>
                            <dt>
                                <asp:Label ID="LblFName" runat="server" Text="<%$Resources:PFSalesResource,FName %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlFName" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblMName" runat="server" Text="<%$Resources:PFSalesResource,MName %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlMName" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblLName" runat="server" Text="<%$Resources:PFSalesResource,LName %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlLName" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <asp:CheckBox ID="chkDefaultShow" Style="float: left; margin-top: 2px; margin-right: 6px;"
                            runat="server" />
                        <p style="width: 95%; float: left;">
                            Automatically show this dialog if the contact name contains more than two names.</p>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnNamePopUpOk" runat="server" Text="<%$Resources:PFSalesResource,OK %>"
                                ToolTip="<%$Resources:PFSalesResource,OK %>" OnClick="lnkbtnNamePopUpOk_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnNamePopUpCancel" runat="server" Text="<%$Resources:PFSalesResource,Cancel %>"
                                ToolTip="<%$Resources:PFSalesResource,Close %>" OnClick="lnkbtnNamePopUpClose_Close"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:HiddenField ID="hdfFName" runat="server" />
            <asp:HiddenField ID="hdfMName" runat="server" />
            <asp:HiddenField ID="hdfLName" runat="server" />
            <asp:HiddenField ID="hdfPhoneFormat" runat="server" />
            <asp:HiddenField ID="hdfPhPopType" runat="server" Value="" />
            <asp:HiddenField ID="hdfPhoneFormatId" runat="server" />
            <asp:HiddenField ID="hdfMobileFormatId" runat="server" />
            <asp:HiddenField ID="hdfFaxFormatId" runat="server" />
            <asp:HiddenField ID="hdfAltContactId" runat="server" />
            <asp:HiddenField ID="hdfEnquryDate" runat="server" />
            <asp:HiddenField ID="hdfIsFleetLead" runat="server" Value="false" />
            <asp:HiddenField ID="hdfFCId" runat="server" Value="0" />
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
