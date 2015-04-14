<%@ Page Title="<%$ Resources:PFSalesResource,Searchprosp%>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" EnableEventValidation="false" CodeFile="SearchProspect.aspx.cs"
    Inherits="SearchProspect" ValidateRequest="false" %>

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

    <script type="text/javascript">
        function TestSecCheckBox() {
            var TargetChildControl = "chkSelect";
            var Inputs = (document.getElementById('<%= this.gvprosp.ClientID %>')).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.match('chkSelect') &&
            Inputs[n].checked) {
                    Count = Count + 1;
                }
            }
            if (Count == 0) {
                alert('Please Select At least One Lead for Removal!');
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <script type="text/javascript">
        function TestCheckBox() {
            var TargetChildControl = "chkSelect";
            var Inputs = (document.getElementById('<%= this.gvprosp.ClientID %>')).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.match('chkSelect') &&
            Inputs[n].checked) {
                    Count = Count + 1;
                }
            }
            if (Count == 0) {
                alert('Please Select At least One Lead for Reassign!');
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <script type="text/javascript">
        function ReasTestCheckBox() {
            var TargetChildControl = "chkSelect";
            var Inputs = (document.getElementById('<%= this.gvAllocate.ClientID %>')).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.match('chkSelect') &&
            Inputs[n].checked) {
                    Count = Count + 1;
                }
            }
            if (Count == 0) {
                alert('Please Select At least One Consultant for Reassign!');
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <asp:UpdatePanel ID="UpPanPrspect" runat="server">
        <ContentTemplate>
            <div class="error" id="dvadderror" runat="server" visible="false">
                <asp:Label ID="lblAddErrMsg" runat="server"></asp:Label>
            </div>
            <div class="success" id="dvaddSucc" runat="server" visible="false">
                <asp:Label ID="lblAddSucMsg" runat="server"></asp:Label>
            </div>
            <asp:Panel ID="pnlSearchprosp" runat="server" DefaultButton="lnkbtnAdSearch">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,Contacts %>"></asp:Label>
                </div>
                <div class="dilContener">
                    <asp:Panel ID="pnlAdminSearch" runat="server">
                        <dl class="dealerRagisterThree">
                            <dt>
                                <asp:Label ID="lblAdSerprospName" runat="server" Text="<%$Resources:PFSalesResource,Name %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtAdserprospName" CssClass="inputClass" MaxLength="160" runat="server"
                                    TabIndex="101"></asp:TextBox>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAdtoEntFromDate" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtAdTotEntFrmDate" runat="server" Width="100" TabIndex="103" CssClass="inputClass"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtnAdCalBDate" runat="server" TabIndex="104" Style="float: left">
                                    <asp:Image ID="imgAdCalBDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="ceAdStartDate" runat="server" TargetControlID="txtAdTotEntFrmDate"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnAdCalBDate">
                                </ajax:CalendarExtender>
                                <asp:Label Style="color: Red; display: inline;" Visible="false" class="errorMsg"
                                    ID="lblAdTotEntFromDateInfo" runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                                <ajax:MaskedEditExtender ID="meeAdTotEntFrmDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                    TargetControlID="txtAdTotEntFrmDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAdserState" runat="server" Text="<%$Resources:PFSalesResource,State %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlAdserState" runat="server" TabIndex="107" CssClass="selectClass">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAdSerStatus" runat="server" Text="<%$Resources:PFSalesResource,PFStatus %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlAdStatus" TabIndex="109" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAdPhNo" runat="server" Text="<%$Resources:PFSalesResource,PhoneNo %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtAdSerPhNo" runat="server" MaxLength="20" CssClass="inputClass"
                                    TabIndex="111"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="fteAdPhNo" runat="server" TargetControlID="txtAdSerPhNo"
                                    FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                                </ajax:FilteredTextBoxExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAdPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtAdPCode" runat="server" CssClass="inputClass" TabIndex="113"
                                    MaxLength="10"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="fteAdPcode" runat="server" TargetControlID="txtAdPCode"
                                    FilterMode="ValidChars" ValidChars="0123456789">
                                </ajax:FilteredTextBoxExtender>
                            </dd>
                            <dt id="DtAd1" runat="server" visible="false">
                                <asp:Label ID="lblAdSerMemberNo" runat="server" Text="<%$ Resources:PFSalesResource,MemberNo %>"></asp:Label>
                                :</dt>
                            <dd id="DdAd1" runat="server" visible="false">
                                <asp:TextBox ID="txtAdMemNo" CssClass="inputClass" TabIndex="100" runat="server"
                                    MaxLength="50"></asp:TextBox>
                            </dd>
                        </dl>
                        <dl class="dealerRagisterThree">
                            <dt>
                                <asp:Label ID="lblAdSerCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlAdCarMake" TabIndex="102" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAdtoEntToDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtAdTotEntToDate" runat="server" Width="100" TabIndex="105" CssClass="inputClass"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtnAdTDate" runat="server" TabIndex="106" Style="float: left">
                                    <asp:Image ID="imgAdTdate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="ceAdTDate" runat="server" TargetControlID="txtAdTotEntToDate"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnAdTDate">
                                </ajax:CalendarExtender>
                                <asp:Label Style="color: Red; display: inline;" Visible="false" class="errorMsg"
                                    ID="lblAdTotEntToDateInfo" runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                                <ajax:MaskedEditExtender ID="mseAdToEntToDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                    TargetControlID="txtAdTotEntToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                            </dd>
                            <dt>
                                <%--<asp:Label ID="lblAdserCity" runat="server" Text="<%$Resources:PFSalesResource,CitySuburb %>"></asp:Label>:--%>
                                <asp:Label ID="lblAdSerConsultant" runat="server" Text="<%$Resources:PFSalesResource,Consultant %>"></asp:Label>
                            </dt>
                            <dd>
                                <%--<asp:DropDownList ID="ddlAdserCity" runat="server" CssClass="selectClass">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:DropDownList ID="ddlAdserConsultant" runat="server" TabIndex="108" CssClass="selectClass">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvAdSerCons" runat="server" ControlToValidate="ddlAdserConsultant"
                                    InitialValue="0" Display="None" ValidationGroup="ReassignContact" ErrorMessage="<%$ Resources:PFSalesResource,SelConsultantVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceAdSerCons" runat="server" TargetControlID="rfvAdSerCons"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAdSerFCStatus" runat="server" Text="<%$Resources:PFSalesResource,FCStatus %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlAdSerFCStatus" TabIndex="110" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                            <dt id="DtAd2" runat="server" visible="true">
                                <asp:Label ID="lblAdSerEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailId %>"></asp:Label>:
                            </dt>
                            <dd id="DdAd2" runat="server" visible="true">
                                <asp:TextBox ID="txtAdEmail1" CssClass="inputClass" TabIndex="112" runat="server"
                                    MaxLength="250"></asp:TextBox>
                            </dd>
                        </dl>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnAdSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                                ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" ValidationGroup="GetAdCountTot"
                                TabIndex="113" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnAdClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$Resources:PFSalesResource,Clear %>" TabIndex="114" OnClick="lnkbtnAdClear_Click"></asp:LinkButton>
                        </div>
                    </asp:Panel>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnAddNewContact" runat="server" TabIndex="115" Text="<%$ Resources:PFSalesResource,AddContact %>"
                            ToolTip="<%$ Resources:PFSalesResource,AddContact %>" OnClick="lnkbtnAddNewContact_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnRemovefromAllo" runat="server" TabIndex="116" Text="<%$ Resources:PFSalesResource,RemovefromAlloction %>"
                            ToolTip="<%$ Resources:PFSalesResource,ReomovefrmAllToolTip %>" OnClientClick="javascript:return TestSecCheckBox();"
                            OnClick="lnkbtnRemovefromAllo_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnAllContacts" runat="server" TabIndex="117" ToolTip="<%$Resources:PFSalesResource,AllContacts %>"
                            OnClick="lnkbtnAllContacts_Click" Text="<%$Resources:PFSalesResource,AllContacts %>">
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnCurrent" runat="server" TabIndex="119" ToolTip="<%$Resources:PFSalesResource,ViewCurrentContacts %>"
                            Text="<%$Resources:PFSalesResource,CurrentContacts %>" OnClick="lnkbtnCurrent_Click">
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnAllDeals" runat="server" TabIndex="118" ToolTip="<%$Resources:PFSalesResource,AllDeals %>"
                            Text="<%$Resources:PFSalesResource,AllDeals %>" OnClick="lnkbtnAllDeals_Click">
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnAllFC" runat="server" TabIndex="120" ToolTip="<%$Resources:PFSalesResource,ViewAllFCLeads %>"
                            Text="<%$Resources:PFSalesResource,AllFCContacts %>" OnClick="lnkbtnAllFC_Click">
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnExport" runat="server" TabIndex="121" ToolTip="<%$Resources:PFSalesResource,ExportToExcel %>"
                            Text="<%$Resources:PFSalesResource,ExportToExcel %>" OnClick="lnkbtnExport_Click">
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnReassign" runat="server" TabIndex="121" ToolTip="<%$Resources:PFSalesResource,ReassignDtls %>"
                            Text="<%$Resources:PFSalesResource,Reassign %>" ValidationGroup="ReassignContact"
                            OnClientClick="javascript:return TestCheckBox();" OnClick="lnkbtnReassign_Click">
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
                        AutoGenerateColumns="false" rule="none" AllowPaging="false" PageSize="50" OnRowDataBound="gvprosp_RowDataBound"
                        OnSelectedIndexChanged="gvprosp_SelectedIndexChanged" AllowSorting="true" OnSorting="gvprosp_Soring">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAll" runat="server" onclick="CheckAllGridCheckbox('gvprosp', this.id, 'chkSelect')" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%#Bind("Id") %>' />
                                    <asp:HiddenField ID="hdfConsultantId" runat="server" Value='<%#Bind("ConsultantId") %>' />
                                    <asp:HiddenField ID="hdfFinConsultantId" runat="server" Value='<%#Bind("FinanceConsultantId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                    <asp:HiddenField ID="hdfForW" runat="server" Value='<%#Bind("ForW") %>' />
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
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFNotes %>">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNotes" runat="server" Text='<%#Bind("NOTES") %>' BackColor="Transparent"
                                        BorderColor="Transparent" BorderStyle="None" BorderWidth="0px" MaxLength="50"
                                        ToolTip='<%#Bind("NOTES") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFstatus %>" SortExpression="status">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfPropStatusId" runat="server" Value='<%#Bind("StatusId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCstatus %>" SortExpression="FCStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCstatus" runat="server" Text='<%#Bind("FCStatus") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfFCPropStatusId" runat="server" Value='<%#Bind("FCStatusId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FinanceType %>" SortExpression="FinanceType">
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
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FleetTeamLead %>" SortExpression="IsFleetLead">
                                <ItemTemplate>
                                    <asp:Image ID="imgFTLead" runat="server" ImageUrl="~/Images/fl.png" Visible="false"
                                        Style="float: left; margin-right: 2px;" />
                                    <asp:HiddenField ID="hdfFTLead" runat="server" Value='<%#Bind("IsFleetLead") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Manage %>">
                                <ItemTemplate>
                                    <asp:Image ID="imgWALead" runat="server" ImageUrl="~/Images/wa.png" Visible="false"
                                        Style="float: left; margin-right: 2px;" />
                                    <asp:LinkButton ID="lnkbtnManageAct" runat="server" ToolTip="<%$Resources:PFSalesResource,ManageActivities %>"
                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnManageAct_Click">
                                               <img src="Images/m.png"/>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Reassign %>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnReassignAct" runat="server" ToolTip="<%$Resources:PFSalesResource,ReassignDtls %>"
                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnReassignAct_Click">
                                               <img src="Images/R.png"/>
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
            <asp:Panel ID="pnlRallocation" runat="server" Visible="false">
                <div class="pop-up" style="z-index: 10025;">
                </div>
                <div class="contentPopUp" style="z-index: 10030; top: 1%;">
                    <div class="popHeader">
                        <asp:Label ID="lblRalocationHead" runat="server" Text="<%$ Resources:PFSalesResource,ReassignContacts%>"></asp:Label>
                        <asp:LinkButton ID="lnkbtnReassClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                            OnClick="lnkbtnReassClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                    </div>
                    <div style="overflow-y: scroll; width: 100%; max-height: 550px;">
                        <dl class="dealerRagisterTwo" style="width: 93%">
                            <dt></dt>
                            <dd style="width: 100%">
                                <asp:GridView ID="gvAllocate" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                                    border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                                    AutoGenerateColumns="false" rule="none">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="CheckAllGridCheckbox('gvAllocate', this.id, 'chkSelect')" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                <%--AutoPostBack="true" OnCheckedChanged="chkSelect_CheckChanged"--%>
                                                <asp:HiddenField ID="hdfConsultantId" runat="server" Value='<%#Bind("VirtualRoleId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                                <asp:Label ID="lblContEmailId" Visible="false" runat="server" Text='<%#Bind("EmailId") %>'></asp:Label>
                                                <asp:HiddenField ID="hdfFName" runat="server" Value='<%#Bind("FirstName") %>'></asp:HiddenField>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblltrTotl" runat="server" Text="<%$Resources:PFSalesResource,Total %>"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Leads %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtNoOfLeads" CssClass="inputClass inputTextCenterClass" Width="50px"
                                                    runat="server" Enabled="true" Text="0" MaxLength="2"></asp:TextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotlPFLead" runat="server" Text="--"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center">
                                            <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoDataFound %>"></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </dd>
                            <dt></dt>
                            <dd>
                                <div class="button">
                                    <asp:LinkButton ID="lnkbtnAllocate" runat="server" Text="<%$Resources:PFSalesResource,Allocate %>"
                                        ToolTip="<%$Resources:PFSalesResource,AllocateLeads %>" Style="padding: 7px 15px;
                                        font-size: 21px; font-weight: bold;" OnClientClick="javascript:return ReasTestCheckBox();"
                                        OnClick="lnkbtnAllocate_Click"></asp:LinkButton>
                                </div>
                            </dd>
                    </div>
                </div>
                <asp:HiddenField ID="hdfSelectedLeadCount" runat="server" Value="0" />
            </asp:Panel>
            <asp:HiddenField ID="hdfSelProspId" runat="server" />
            <asp:HiddenField ID="hdfSelProspIdForReass" runat="server" />
            <asp:HiddenField ID="hdfConsultantType" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnExport" />
        </Triggers>
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
