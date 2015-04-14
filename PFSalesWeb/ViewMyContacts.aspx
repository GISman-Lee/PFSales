<%@ Page Title="<%$ Resources:PFSalesResource,Searchprosp%>" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/PFSalesMaster.master" EnableEventValidation="false" CodeFile="ViewMyContacts.aspx.cs"
    Inherits="ViewMyContacts" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/UC_AddEditContact.ascx" TagName="AddEditContact"
    TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .PagerContainer
        {
            background: #f7f5f6;
            border-bottom: 1px solid #C5C5C5 !important;
            border-left: 1px solid #C5C5C5 !important;
            border-right: 1px solid #C5C5C5 !important; /*text-indent: 15px;*/
            width: 99.8%;
            float: left;
            height: 35px;
        }
        .PagerContainerTable
        {
            padding: 5px 0px;
            margin-left: 10px;
        }
        .PagerContainerTable tr td
        {
            padding: 0px 3px;
        }
        .PagerContainerTable tr td a, .PagerContainerTable tr td a:hover
        {
            text-decoration: underline;
            color: #006699;
            margin: 0px 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanPrspect" runat="server">
        <ContentTemplate>
            <div class="error" id="dvadderror" runat="server" visible="false">
                <asp:Label ID="lblAddErrMsg" runat="server"></asp:Label>
            </div>
            <div class="success" id="dvaddSucc" runat="server" visible="false">
                <asp:Label ID="lblAddSucMsg" runat="server"></asp:Label>
            </div>
            <asp:Panel ID="pnlSearchprosp" runat="server" DefaultButton="lnkbtnSearch">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,Contacts %>"></asp:Label>
                </div>
                <div class="dilContener">
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnAddNewContact" runat="server" TabIndex="115" Text="<%$ Resources:PFSalesResource,AddContact %>"
                            ToolTip="<%$ Resources:PFSalesResource,AddContact %>" OnClick="lnkbtnAddNewContact_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnAllContacts" runat="server" TabIndex="117" ToolTip="<%$Resources:PFSalesResource,AllContacts %>"
                            OnClick="lnkbtnAllContacts_Click" Text="<%$Resources:PFSalesResource,AllMyContacts %>">
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnCurrent" runat="server" TabIndex="119" ToolTip="<%$Resources:PFSalesResource,ViewCurrentContacts %>"
                            Text="<%$Resources:PFSalesResource,MyCurrentContacts %>" OnClick="lnkbtnCurrent_Click">
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnAllDeals" runat="server" TabIndex="118" ToolTip="<%$Resources:PFSalesResource,AllDeals %>"
                            Text="<%$Resources:PFSalesResource,MyClients %>" OnClick="lnkbtnAllDeals_Click">
                        </asp:LinkButton>
                    </div>
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
                    <asp:GridView ID="gvprosp" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                        border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                        AutoGenerateColumns="false" rule="none" AllowPaging="true" PageSize="50" OnRowDataBound="gvprosp_RowDataBound"
                        OnSelectedIndexChanged="gvprosp_SelectedIndexChanged" AllowSorting="true" OnSorting="gvprosp_Soring">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EnquiryDateHead %>" SortExpression="CreatedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("EnquiryDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    <asp:HiddenField ID="_hdfTotCount" runat="server" Value='<%#Bind("TodActCnt") %>' />
                                    <asp:HiddenField ID="_hdfIsTender" runat="server" Value='<%#Bind("IsTender") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CarMake %>" SortExpression="Make">
                                <ItemTemplate>
                                    <asp:Label ID="lblMake" runat="server" Text='<%#Bind("Make") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfIsPForFC" runat="server" Value='<%#Bind("FinanceSource") %>' />
                                    <asp:HiddenField ID="hdfIsFinanceSource" runat="server" Value='<%#Bind("IsFinanceSource") %>' />
                                    <asp:HiddenField ID="hdfRefSource" runat="server" Value='<%#Bind("RefSource") %>' />
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
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Notes %>">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNotes" runat="server" Text='<%#Bind("NOTES") %>' BackColor="Transparent"
                                        BorderColor="Transparent" BorderStyle="None" BorderWidth="0px" MaxLength="50"
                                        ToolTip='<%#Bind("NOTES") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFStatus %>" SortExpression="status">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfPropStatusId" runat="server" Value='<%#Bind("StatusId") %>' />
                                    <asp:Image ID="imgPureFCLead" runat="server" ImageUrl="~/Images/F.png" Visible="false"
                                        Style="float: left; margin-right: 2px;" ToolTip="<%$Resources:PFSalesResource,FincarLead %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCStatus %>" SortExpression="FCStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCstatus" runat="server" Text='<%#Bind("FCStatus") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfFCPropStatusId" runat="server" Value='<%#Bind("FCStatusId") %>' />
                                    <asp:Image ID="imgPurePfLead" runat="server" ImageUrl="~/Images/P.png" Visible="false"
                                        Style="float: left; margin-right: 2px;" ToolTip="<%$Resources:PFSalesResource,PFLead %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FinanceType %>" SortExpression="FinanceType"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFinanceType" runat="server" Text='<%#Bind("FinanceType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,LastContactedDate %>"
                                Visible="false">
                                <ItemTemplate>
                                    <%--    <asp:Label ID="lblLastContactDate" runat="server" Text='<%#Bind("LastContactDate") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FollowUpDate %>" SortExpression="FolloUpDateSorting">
                                <ItemTemplate>
                                    <asp:Label ID="lblFollowupDate" runat="server" Text='<%#Bind("NextContactDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,IsFleetLead %>" SortExpression="IsFleetLead">
                                <ItemTemplate>
                                    <asp:Image ID="imgFTLead" runat="server" ImageUrl="~/Images/fl.png" Visible="false"
                                        Style="float: left; margin-right: 2px;" />
                                    <asp:HiddenField ID="hdfFTLead" runat="server" Value='<%#Bind("IsFleetLead")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Manage %>">
                                <ItemTemplate>
                                    <asp:Image ID="imgIM" runat="server" ImageUrl="~/Images/im.png" Visible="false" Style="float: left;
                                        margin-right: 2px;" />
                                    <asp:Image ID="imgE" runat="server" ImageUrl="~/Images/e.png" Visible="false" Style="float: left;
                                        margin-right: 2px;" />
                                    <asp:Image ID="imgWALead" runat="server" ImageUrl="~/Images/wa.png" Visible="false"
                                        Style="float: left; margin-right: 2px;" />
                                    <asp:LinkButton ID="lnkbtnManageAct" runat="server" ToolTip="<%$Resources:PFSalesResource,ManageActivities %>"
                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnManageAct_Click">
                                               <img src="Images/m.png"/>
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
                    <div class="PagerContainer" id="divPaging" runat="server" width="100%">
                        <MechPager:Class1 ID="pagerParent" Visible="false" runat="server" OnCommand="pagerParent_Command"
                            GeneratePagerInfoSection="false" GenerateFirstLastSection="false" Width="100%" />
                    </div>
                    <asp:Panel ID="pnlConsultSearch" runat="server">
                        <div class="headText">
                        </div>
                        <dl class="dealerRagisterThree">
                            <dt>
                                <asp:Label ID="lblSerprospName" runat="server" Text="<%$Resources:PFSalesResource,Name %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtserprospName" CssClass="inputClass" MaxLength="160" runat="server"
                                    TabIndex="122"></asp:TextBox>
                            </dd>
                            <dt>
                                <asp:Label ID="lbltoEntFromDate" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtTotEntFrmDate" runat="server" Width="100" TabIndex="124" CssClass="inputClass"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtnCalBDate" runat="server" TabIndex="125" Style="float: left">
                                    <asp:Image ID="imgCalBDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtTotEntFrmDate"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnCalBDate">
                                </ajax:CalendarExtender>
                                <asp:Label Style="color: Red; display: inline;" Visible="false" class="errorMsg"
                                    ID="lblTotEntFromDateInfo" runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                                <ajax:MaskedEditExtender ID="meeTotEntFrmDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                    TargetControlID="txtTotEntFrmDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblserState" runat="server" Text="<%$Resources:PFSalesResource,State %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlserState" runat="server" TabIndex="128" CssClass="selectClass"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlserState_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblSerStatus" runat="server" Text="<%$Resources:PFSalesResource,Status %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlStatus" TabIndex="130" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPhNo" runat="server" Text="<%$Resources:PFSalesResource,PhoneNo %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtSerPhNo" runat="server" MaxLength="20" CssClass="inputClass"
                                    TabIndex="132"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="ftePhNo" runat="server" TargetControlID="txtSerPhNo"
                                    FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                                </ajax:FilteredTextBoxExtender>
                            </dd>
                            <dt id="Dt1" runat="server" visible="false">
                                <asp:Label ID="lblSerMemberNo" runat="server" Text="<%$ Resources:PFSalesResource,MemberNo %>"></asp:Label>
                                :</dt>
                            <dd id="Dd1" runat="server" visible="false">
                                <asp:TextBox ID="txtMemNo" CssClass="inputClass" TabIndex="100" runat="server" MaxLength="50"></asp:TextBox>
                            </dd>
                        </dl>
                        <dl class="dealerRagisterThree">
                            <dt>
                                <asp:Label ID="lblSerCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlCarMake" TabIndex="123" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lbltoEntToDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtTotEntToDate" runat="server" Width="100" TabIndex="126" CssClass="inputClass"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtnTDate" runat="server" TabIndex="127" Style="float: left">
                                    <asp:Image ID="imgTdate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="ceTDate" runat="server" TargetControlID="txtTotEntToDate"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnTDate">
                                </ajax:CalendarExtender>
                                <asp:Label Style="color: Red; display: inline;" Visible="false" class="errorMsg"
                                    ID="lblTotEntToDateInfo" runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                                <ajax:MaskedEditExtender ID="mseToEntToDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                    TargetControlID="txtTotEntToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblserCity" runat="server" Text="<%$Resources:PFSalesResource,CitySuburb %>"></asp:Label>:
                                <asp:Label ID="lblSerConsultant" runat="server" Text="<%$Resources:PFSalesResource,Consultant %>"
                                    Visible="false"></asp:Label>
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlserCity" runat="server" TabIndex="129" CssClass="selectClass">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlserConsultant" runat="server" CssClass="selectClass" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlserConsultant_SelectedIndexChanged" Visible="false">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt id="Dt2" runat="server" visible="true">
                                <asp:Label ID="lblSerEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailId %>"></asp:Label>:
                            </dt>
                            <dd id="Dd2" runat="server" visible="true">
                                <asp:TextBox ID="txtEmail1" CssClass="inputClass" TabIndex="131" runat="server" MaxLength="250"></asp:TextBox>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtPCode" runat="server" CssClass="inputClass" TabIndex="133" MaxLength="10"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="ftePcode" runat="server" TargetControlID="txtPCode"
                                    FilterMode="ValidChars" ValidChars="0123456789">
                                </ajax:FilteredTextBoxExtender>
                            </dd>
                        </dl>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSearch" runat="server" TabIndex="134" Text="<%$Resources:PFSalesResource,Search %>"
                                ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" ValidationGroup="GetCountTot"
                                OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnClear" runat="server" TabIndex="135" Text="<%$Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                        </div>
                    </asp:Panel>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlAddContact" runat="server" Visible="false">
                <div class="pop-up" style="z-index: 10025;">
                </div>
                <div class="contentPopUp" style="z-index: 10030; margin-left: -88%; top: 1%; width: 77%;">
                    <div class="popHeader">
                        <asp:Label ID="lblAddContactHead" runat="server" Text="<%$ Resources:PFSalesResource,AddProspectDetails%>"></asp:Label>
                        <asp:LinkButton ID="lnkbtnAddContactClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                            OnClick="lnkbtnAddContactClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                    </div>
                    <div style="overflow-y: scroll; height: 550px; width: 100%">
                        <uc5:AddEditContact ID="UC_AddEditContact1" runat="server" />
                    </div>
                </div>
            </asp:Panel>
            <asp:HiddenField ID="hdfSelProspId" runat="server" />
        </ContentTemplate>
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnExport" />
        </Triggers>--%>
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
