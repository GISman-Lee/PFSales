<%@ Page Title="<%$Resources:PFSalesResource,LeadAllocation %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="LeadAllocation.aspx.cs" Inherits="LeadAllocation"
    MaintainScrollPositionOnPostback="true" %>

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
        .tableGride
        {
            border-top: 1px solid #737373;
            border-left: 1px solid #737373;
            float: left;
            z-index: 0;
            margin-top: 20px;
            background-color: #eff9ff;
        }
        .tableGride th
        {
            background: #1687b9;
            padding: 5px !important;
            border-right: 1px solid #737373;
            border-bottom: 1px solid #737373;
            border-left: 1px solid #737373;
            border-right: 1px solid #737373;
            text-align: left;
            color: #FFFFFF;
        }
        .tableGride .borderRemove
        {
            border-right: 0px;
        }
        .tableGride th span
        {
            float: left;
        }
        .tableGride th a
        {
            color: #fff;
            float: left;
            text-decoration: none;
        }
        .tableGride th a:hover
        {
            color: #fff;
            text-decoration: none;
        }
        .tableGride td
        {
            padding: 5px !important;
            text-align: left;
            border-bottom: 1px solid #737373;
            border-right: 1px solid #737373;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function TestCheckBox() {
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

            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'text' && Inputs[n].id.match('txtNoOfLeads') &&
            Inputs[n].value != '0') {
                    totlead = parseInt(totlead) + parseInt(Inputs[n].value);
                }
            }
            if (Count == 0) {
                alert('Please Select At least One Consultant for Allocation!');
                return false;
            }
            else {
                if (parseInt(totlead) > 0)
                    return true;
                else {
                    alert('Please Select At least One Lead for Allocation!');
                    return false;
                }
            }
        }
    </script>

    <script type="text/javascript">
        function TestSecCheckBox() {
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
                alert('Please Select At least One Consultant for Allocation!');
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <script type="text/javascript">
        function TestFCSecCheckBox() {
            var TargetChildControl = "chkFCSelect";
            var Inputs = (document.getElementById('<%= this.gvFCAllocate.ClientID %>')).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.match('chkFCSelect') &&
            Inputs[n].checked) {
                    Count = Count + 1;
                }
            }
            if (Count == 0) {
                alert('Please Select At least One Consultant for Allocation!');
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <script type="text/javascript">
        function TestTextBox() {
            var TargetChildControl = "txtNoOfLeads";
            var Inputs = (document.getElementById('<%= this.gvAllocate.ClientID %>')).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'text' && Inputs[n].id.match('txtNoOfLeads') &&
            Inputs[n].value != '0') {
                    totlead = parseInt(totlead) + parseInt(Inputs[n].value);
                }
            }
            if (parseInt(totlead) > 0)
                return true;
            else {
                alert('Please Select At least One Consultant for Allocation!');
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function TestFCTextBox() {
            var TargetChildControl = "txtNoOfLeads";
            var Inputs = (document.getElementById('<%= this.gvFCAllocate.ClientID %>')).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'text' && Inputs[n].id.match('txtFCNoOfLeads') &&
            Inputs[n].value != '0') {
                    totlead = parseInt(totlead) + parseInt(Inputs[n].value);
                }
            }
            if (parseInt(totlead) > 0)
                return true;
            else {
                alert('Please Select At least One Consultant for Allocation!');
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function TestNYCCheckBox() {
            var TargetChildControl = "chkSelect";
            var Inputs = (document.getElementById('<%= this.gvNYC.ClientID %>')).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.match('chkSelect') &&
            Inputs[n].checked) {
                    Count = Count + 1;
                }
            }
            if (Count == 0) {
                alert('Please Select At least One Lead for Bulk Assignment!');
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <script type="text/javascript">
        function NTUNYCCheckBox() {
            var TargetChildControl = "chkSelect";
            var Inputs = (document.getElementById('<%= this.gvNYC.ClientID %>')).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.match('chkSelect') &&
            Inputs[n].checked) {
                    Count = Count + 1;
                }
            }
            if (Count == 0) {
                alert('Please Select At Least One Lead for Marking as NTU!');
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <script type="text/javascript">
        function TestBRFCheckBox() {
            var TargetChildControl = "chkSelect";
            var Inputs = (document.getElementById('<%= this.gvNYC.ClientID %>')).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.match('chkSelect') &&
            Inputs[n].checked) {
                    Count = Count + 1;
                }
            }
            if (Count == 0) {
                alert('Please Select At Least One Lead for Bulk Reassignment!');
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
            var Inputs = (document.getElementById('<%= this.gvBulkAllocateConsult.ClientID %>')).getElementsByTagName("input");
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

    <asp:UpdatePanel ID="upPanLeadAlloc" runat="server">
        <ContentTemplate>
            <%--  <asp:Timer ID="tmrBindFleet" runat="server" OnTick="tmrBindFleet_Tick" Interval="60000">
            </asp:Timer>--%>
            <div class="innerHeader">
                <img src="images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="lblLeadAllocHead" runat="server" Text="<%$Resources:PFSalesResource,LeadAllocation %>"></asp:Label>
            </div>
            <div class="mainbdr">
                <div class="tablerBtn">
                    <asp:LinkButton ID="lnkbtnPFAllocation" runat="server" CssClass="tablerBtnActive"
                        Text="<%$Resources:PFSalesResource,PFLeadAllocation %>" ToolTip="<%$Resources:PFSalesResource,PFLeadsAllocationToolTip %>"
                        OnClick="lnkbtnPFAllocation_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnFCAllocation" runat="server" Text="<%$Resources:PFSalesResource,FCLeadAllocation %>"
                        ToolTip="<%$Resources:PFSalesResource,FCLeadAllocationToolTip %>" OnClick="lnkbtnFCAllocation_Click"></asp:LinkButton>
                </div>
                <div class="tablerView" style="width: 95.7%;">
                    <div class="dilContener">
                        <!--Content-Note: Please Use ASP:LABEL instead of span-->
                        <asp:Panel ID="pnlLeadAllocation" runat="server" DefaultButton="lnkbtnAllocate">
                            <div class="error" id="dvsererror" runat="server" visible="false">
                                <asp:Label ID="lblSerErrMsg" runat="server"></asp:Label>
                            </div>
                            <!--Content-Note: success Msg-->
                            <div class="success" id="dvaserSuccess" runat="server" visible="false">
                                <asp:Label ID="lblSerSucMsg" runat="server"></asp:Label>
                            </div>
                            <%-- <div style="float: left; width: 90%">
                            <b>
                                <asp:Literal ID="ltrlblTotEnquiry1" runat="server" Text="<%$Resources:PFSalesResource, TodaysEnquiry%>"></asp:Literal>
                            </b>
                        </div>--%>
                            <%-- <div class="headText" style="margin-top: 0px; padding-bottom: 0px; padding-top: 0px">
                        </div>--%>
                            <dl class="dealerRagisterTwo " runat="server" visible="false">
                                <dt>
                                    <asp:Label ID="lbltoEntFromDate1" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 135px;">
                                    <asp:TextBox ID="txtTotEntFrmDate1" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnCalTFDate1" runat="server" Style="float: left">
                                        <asp:Image ID="imgCalFDate1" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceTFDate1" runat="server" TargetControlID="txtTotEntFrmDate1"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnCalTFDate1">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblTotEntFromDateInfo1"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="meeTotEntFrmDate1" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtTotEntFrmDate1" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvTotEntFrmDate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtTotEntFrmDate1" ValidationGroup="GetCountTot1" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceCompTotEntFrmDate1" runat="server" TargetControlID="cvTotEntFrmDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="mskEValStrDate1" ControlExtender="meeTotEntFrmDate1"
                                        ControlToValidate="txtTotEntFrmDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetCountTot1"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceTotEntFrmDate1" runat="server" TargetControlID="mskEValStrDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <asp:Label ID="lbltoEntToDate1" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 130px;">
                                    <asp:TextBox ID="txtTotEntToDate1" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnTTDate1" runat="server" Style="float: left">
                                        <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceTTDate1" runat="server" TargetControlID="txtTotEntToDate1"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnTTDate1">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblTotEntToDateInfo1"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="mseToEntToDate1" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtTotEntToDate1" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvtotEntToDate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtTotEntToDate1" ValidationGroup="GetCountTot1" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceToEntToDate1" runat="server" TargetControlID="cvtotEntToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="msevToEntToDate1" ControlExtender="mseToEntToDate1"
                                        ControlToValidate="txtTotEntToDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetCountTot1"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceMseToEntToDate1" runat="server" TargetControlID="msevToEntToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompValToDate1" runat="server" ControlToValidate="txtTotEntToDate1"
                                        ControlToCompare="txtTotEntFrmDate1" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                                        Operator="GreaterThanEqual" ValidationGroup="GetCountTot1" Type="Date" Display="None"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceTotFromToDate1" runat="server" TargetControlID="CompValToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnTotEntGetCount1" runat="server" Text="<%$Resources:PFSalesResource, GetCount%>"
                                            ToolTip="<%$Resources:PFSalesResource, GetTotCount%>" ValidationGroup="GetCountTot1"
                                            OnClick="lnkbtnTotEntGetCount1_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd style="width: 115px;">
                                    <%--<asp:TextBox ID="txtTodTotEnq" Width="80" CssClass="inputClass inputTextCenterClass"
                                    Text="" runat="server"></asp:TextBox>--%>
                                    <div style="width: 30%; margin: 0 auto;">
                                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:PFSalesResource,NewEnquiries %>"></asp:Label>:
                                        <asp:LinkButton ID="lnkbtnTodTotEnq1" CssClass="inputTextCenterClass" runat="server"
                                            Text="0" Enabled="false" Style="font-size: large;" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                            OnClick="lnkbtnTodTotEnq1_Click" CausesValidation="false"></asp:LinkButton>
                                    </div>
                                </dd>
                            </dl>
                            <%--  <div style="float: left; width: 90%">
                            <b>
                                <asp:Literal ID="ltrUnAlocEntries1" runat="server" Text="<%$Resources:PFSalesResource, UnallocatedEnq%>"></asp:Literal>
                            </b>
                        </div>--%>
                            <%-- <div class="headText" style="margin-top: 0px; padding-bottom: 0px; padding-top: 0px">
                        </div>--%>
                            <dl class="dealerRagisterTwo " runat="server" visible="false">
                                <dt>
                                    <asp:Label ID="lblUnAlocFromDate1" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 135px;">
                                    <asp:TextBox ID="txtUnAlocFromDate1" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnUFDate1" runat="server" Style="float: left">
                                        <asp:Image ID="Image21" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceUFDate1" runat="server" TargetControlID="txtUnAlocFromDate1"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnUFDate1">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblUnalocFrDateInfo1"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="meeUnEntFrmDate1" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtUnAlocFromDate1" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvUnEntFrmDate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtUnAlocFromDate1" ValidationGroup="GetCountUnaloc1" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <asp:CompareValidator ID="cvValForAllocate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtUnAlocFromDate1" ValidationGroup="Allocate" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceCompUnEntFrmDate1" runat="server" TargetControlID="cvUnEntFrmDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:ValidatorCalloutExtender ID="vceForAllocate1" runat="server" TargetControlID="cvValForAllocate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="mskEValUnStrDate1" ControlExtender="meeUnEntFrmDate1"
                                        ControlToValidate="txtUnAlocFromDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetCountUnaloc1"></ajax:MaskedEditValidator>
                                    <ajax:MaskedEditValidator ID="mevfromDateForAlllocate1" ControlExtender="meeUnEntFrmDate1"
                                        ControlToValidate="txtUnAlocFromDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="Allocate"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceUnEntFrmDate1" runat="server" TargetControlID="mskEValUnStrDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:ValidatorCalloutExtender ID="vcefromDateForAlllocate1" runat="server" TargetControlID="mskEValUnStrDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <asp:Label ID="lblUnAlocToDate1" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 130px;">
                                    <asp:TextBox ID="txtUnalocToDate1" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnUTDate1" runat="server" Style="float: left">
                                        <asp:Image ID="imfUTDate1" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceUTDate1" runat="server" TargetControlID="txtUnalocToDate1"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnUTDate1">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblUnalocToDateInfo1"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="mseUnEntToDate1" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtUnalocToDate1" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvUnEntToDate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtUnalocToDate1" ValidationGroup="GetCountUnaloc1" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceUnEntToDate1" runat="server" TargetControlID="cvUnEntToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="msevUnEntToDate1" ControlExtender="mseUnEntToDate"
                                        ControlToValidate="txtUnalocToDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetCountUnaloc"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceMseUnEntToDate1" runat="server" TargetControlID="msevUnEntToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvUnToFromDateVal1" runat="server" ControlToValidate="txtUnalocToDate1"
                                        ControlToCompare="txtUnAlocFromDate1" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                                        Operator="GreaterThanEqual" ValidationGroup="GetCountTot1" Type="Date" Display="None"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceUnToFromDate1" runat="server" TargetControlID="cvUnToFromDateVal1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnUnalocGetCount1" runat="server" Text="<%$Resources:PFSalesResource, GetCount%>"
                                            ToolTip="<%$Resources:PFSalesResource, GetUnalocCount%>" ValidationGroup="GetCountUnaloc1"
                                            OnClick="lnkbtnUnalocGetCount1_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd style="width: 115px;">
                                    <%--<asp:LinkButton ID="lnkbtnUnallocatedEnq1" CssClass="inputTextCenterClass" runat="server"
                                    Text="0" Enabled="false" Style="font-size: large;" CausesValidation="false" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                    OnClick="lnkbtnUnallocatedEnq1_Click"></asp:LinkButton>--%>
                                </dd>
                            </dl>
                            <div style="width: 30%; margin: 0 auto;">
                                <asp:Label ID="lblNewEntries" runat="server" Text="<%$Resources:PFSalesResource,NewEnquiries %>"></asp:Label>:
                                <asp:LinkButton ID="lnkbtnUnallocatedEnq1" CssClass="inputTextCenterClass" runat="server"
                                    Text="0" Enabled="false" Style="font-size: large;" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                    OnClick="lnkbtnUnallocatedEnq1_Click" CausesValidation="false"></asp:LinkButton>
                            </div>
                            <div style="float: left; width: 90%">
                                <b>
                                    <asp:Literal ID="ltrFleetTeamLeadAlloc" runat="server" Text="<%$Resources:PFSalesResource, FleetTeamLeadAllocation%>"></asp:Literal>
                                </b>
                            </div>
                            <div class="headText" style="margin-top: 0px; padding-bottom: 0px; padding-top: 0px">
                            </div>
                            <asp:GridView ID="gvTeamLead" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                                border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                                AutoGenerateColumns="false" rule="none" AllowSorting="true" OnRowDataBound="gvTeamLead_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProspName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                            <asp:HiddenField ID="hdfFName" runat="server" Value='<%#Bind("FirstName") %>'></asp:HiddenField>
                                            <asp:HiddenField ID="hdfProspectId" runat="server" Value='<%#Bind("Id") %>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ProspectSrc %>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProspectSrc" runat="server" Text='<%#Bind("RefSource") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Consultant %>">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlTeamLeedConsultant" runat="server" CssClass="selectClass"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlTeamLeedConsultant_SelectedIndexChanged"
                                                CausesValidation="false">
                                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvtlConsult" runat="server" ControlToValidate="ddlTeamLeedConsultant"
                                                Display="None" InitialValue="0" ValidationGroup="TeamAllocate" ErrorMessage="<%$Resources:PFSalesResource,SelConsultantVal %>"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceLConsult" runat="server" TargetControlID="rfvtlConsult"
                                                PopupPosition="TopLeft">
                                            </ajax:ValidatorCalloutExtender>
                                            <asp:HiddenField ID="hdfConsultEmail" runat="server" Value="0"></asp:HiddenField>
                                            <asp:HiddenField ID="hdfConsultFName" runat="server" Value=""></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center">
                                        <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoDataFound %>"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <div class="headText">
                            </div>
                            <div class="button" runat="server" visible="false">
                                <asp:LinkButton ID="lnkbtnLeadTeamAllocate" runat="server" Text="<%$Resources:PFSalesResource,Allocate %>"
                                    ToolTip="<%$Resources:PFSalesResource,AllocateLeads %>" ValidationGroup="TeamAllocate"
                                    OnClick="lnkbtnLeadTeamAllocate_Click"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnClearTeamAllocate" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                    ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClearTeamAllocate_Click"></asp:LinkButton>
                            </div>
                            <div class="headText">
                            </div>
                            <div style="float: left; width: 90%">
                                <b>
                                    <asp:Literal ID="ltrNormalLeadAllocHead" runat="server" Text="<%$Resources:PFSalesResource, NormalLeadAllocation%>"></asp:Literal>
                                </b>
                            </div>
                            <div class="headText" style="margin-top: 0px; padding-bottom: 0px; padding-top: 0px">
                            </div>
                            <asp:GridView ID="gvAllocate" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                                border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                                AutoGenerateColumns="false" rule="none" AllowSorting="true" OnSorting="gvAllocate_Soring"
                                OnRowCreated="gvAllocate_Created" OnRowDataBound="gvAllocate_RowDatabound" ShowFooter="true">
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
                                            <asp:HiddenField ID="hdfFName" runat="server" Value='<%#Bind("FirstName") %>'></asp:HiddenField>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblltrTotl" runat="server" Text="<%$Resources:PFSalesResource,Total %>"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Today %>" Visible="true"
                                        SortExpression="TodaysLeads">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTodaysLeads" runat="server" Text='<%#Bind("TodaysLeads") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPFTodLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,TwentyFourHr %>" Visible="true"
                                        SortExpression="24HrsLeads">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTwentyFourHr" runat="server" Text='<%#Bind("24HrsLeads") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPF24hrLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ThisWeek %>" Visible="true"
                                        SortExpression="ThisWeek">
                                        <ItemTemplate>
                                            <asp:Label ID="lblThisWeek" runat="server" Text='<%#Bind("ThisWeek") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPFWeekLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ThisMonth %>" Visible="true"
                                        SortExpression="ThisMonth">
                                        <ItemTemplate>
                                            <asp:Label ID="lblThisMonth" runat="server" Text='<%#Bind("ThisMonth") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPFMonthLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FortyEightHr %>" Visible="false"
                                        SortExpression="Before48Hrs">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContfortyEighthr" runat="server" Text='<%#Bind("Before48Hrs") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPF48Lead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,SevenDays %>" Visible="false"
                                        SortExpression="Before7Days">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContSevenDays" runat="server" Text='<%#Bind("Before7Days") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPF7DLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmailId %>" Visible="false"
                                        SortExpression="EmailId">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContEmailId" runat="server" Text='<%#Bind("EmailId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPFEmail" runat="server" Text="--"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,MobileNo %>" Visible="false"
                                        SortExpression="MobileNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContMobileNo" runat="server" Text='<%#Bind("MobileNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPFMob" runat="server" Text="--"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CurrentWorkLoad %>" SortExpression="WorkLoad">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnCurrWorkLoad" CssClass="inputTextCenterClass" runat="server"
                                                Text='<%#Bind("WorkLoad") %>' CommandArgument='<%#Bind("VirtualRoleId") %>' ToolTip="<%$Resources:PFSalesResource,ViewCurrentWorkLoad %>"
                                                OnClick="lnkbtnCurrWorkLoad_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPFCWLoad" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,LoadNotYetCalledHead %>"
                                        SortExpression="LoadNotYetCalled">
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblLoadNotYetCalled" runat="server" Text='<%#Bind("LoadNotYetCalled") %>'></asp:Label>--%>
                                            <asp:LinkButton ID="lnkbtnNYCWorkLoad" CssClass="inputTextCenterClass" runat="server"
                                                Text='<%#Bind("LoadNotYetCalled") %>' CommandArgument='<%#Bind("VirtualRoleId") %>'
                                                OnClick="lnkbtnNYCWorkLoad_Click"></asp:LinkButton>
                                            <%--    <asp:LinkButton ID="lnkbtnCurrWorkLoad" CssClass="inputTextCenterClass" runat="server"
                                            Text='<%#Bind("WorkLoad") %>' CommandArgument='<%#Bind("VirtualRoleId") %>' ToolTip="<%$Resources:PFSalesResource,ViewCurrentWorkLoad %>"
                                            OnClick="lnkbtnCurrWorkLoad_Click"></asp:LinkButton>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlPFNYC" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Leads %>">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoOfLeads" CssClass="inputClass inputTextCenterClass" Width="50px"
                                                runat="server" Enabled="true" Text="0" MaxLength="2"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="fteNoOfLeadst" runat="server" TargetControlID="txtNoOfLeads"
                                                FilterType="Custom" ValidChars="0123456789">
                                            </ajax:FilteredTextBoxExtender>
                                            <%--<asp:CustomValidator ID="cvNoOfLeadsVal" runat="server" Display="None" ValidationGroup="Allocate"
                                            ErrorMessage="<%$Resources:PFSalesResource,NoLeadsCustomVal %>" EnableClientScript="true"
                                            ControlToValidate="txtNoOfLeads" ValidateEmptyText="false" SetFocusOnError="true"
                                            OnServerValidate="checkvalidLeadCount"></asp:CustomValidator>--%>
                                            <asp:CompareValidator ID="cvNoOfLeadsVal" runat="server" Type="Integer" Operator="GreaterThan"
                                                ControlToValidate="txtNoOfLeads" ValueToCompare="0" ValidationGroup="other" ErrorMessage="<%$ Resources:PfSalesResource, ResetRangeVal%>"
                                                Display="None">
                                            </asp:CompareValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceNoOfLeadsVal" runat="server" TargetControlID="cvNoOfLeadsVal"
                                                PopupPosition="TopRight">
                                            </ajax:ValidatorCalloutExtender>
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
                            <div class="headText">
                            </div>
                            <dl class="dealerRagisterTwo ">
                                <dt>
                                    <asp:Label ID="lblResetAllTo" runat="server" Text="<%$Resources:PFSalesResource,ResetAllTo %>"></asp:Label>:
                                </dt>
                                <dd>
                                    <asp:TextBox ID="txtBulkAmt" Width="50" CssClass="inputClass inputTextCenterClass"
                                        runat="server" MaxLength="2"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fteBulkamt" runat="server" TargetControlID="txtBulkAmt"
                                        FilterType="Custom" ValidChars="0123456789">
                                    </ajax:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="rfvBulkamt" runat="server" ControlToValidate="txtBulkAmt"
                                        Display="None" ValidationGroup="Reset" ErrorMessage="<%$ Resources:PFSalesResource,ResetToAllVal %>"
                                        SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceBulkamt" runat="server" TargetControlID="rfvBulkamt"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvBulkAmt" runat="server" Type="Integer" Operator="GreaterThan"
                                        ControlToValidate="txtBulkAmt" ValueToCompare="0" ValidationGroup="Reset" ErrorMessage="<%$ Resources:PfSalesResource, ResetRangeVal%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceResetAllRange" runat="server" TargetControlID="cvBulkAmt"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <div class="button" style="margin-left: 15px;">
                                        <asp:LinkButton ID="lnkbtnSet" runat="server" Text="<%$Resources:PFSalesResource,Set %>"
                                            ToolTip="<%$Resources:PFSalesResource,SetBulkLeadCount %>" OnClientClick="javascript:return TestSecCheckBox();"
                                            ValidationGroup="Reset" OnClick="lnkbtnSet_Click"></asp:LinkButton>
                                    </div>
                                </dd>
                                <dt></dt>
                                <dd>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnAllocate" runat="server" Text="<%$Resources:PFSalesResource,Allocate %>"
                                            ToolTip="<%$Resources:PFSalesResource,AllocateLeads %>" Style="padding: 7px 15px;
                                            font-size: 21px; font-weight: bold;" ValidationGroup="Allocate" OnClick="lnkbtnAllocate_Click"
                                            OnClientClick="javascript:return TestTextBox();"></asp:LinkButton>
                                    </div>
                                </dd>
                            </dl>
                            <div class="headText">
                            </div>
                            <div style="float: left; width: 90%">
                                <b>
                                    <asp:Literal ID="ltrlblTotEnquiry" runat="server" Text="<%$Resources:PFSalesResource, TodaysEnquiry%>"></asp:Literal>
                                </b>
                            </div>
                            <div class="headText" style="margin-top: 0px; padding-bottom: 0px; padding-top: 0px">
                            </div>
                            <dl class="dealerRagisterTwo ">
                                <dt>
                                    <asp:Label ID="lbltoEntFromDate" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 135px;">
                                    <asp:TextBox ID="txtTotEntFrmDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnCalTFDate" runat="server" Style="float: left">
                                        <asp:Image ID="imgCalFDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceTFDate" runat="server" TargetControlID="txtTotEntFrmDate"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnCalTFDate">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblTotEntFromDateInfo"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="meeTotEntFrmDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtTotEntFrmDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvTotEntFrmDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtTotEntFrmDate" ValidationGroup="GetCountTot" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceCompTotEntFrmDate" runat="server" TargetControlID="cvTotEntFrmDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="mskEValStrDate" ControlExtender="meeTotEntFrmDate"
                                        ControlToValidate="txtTotEntFrmDate" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetCountTot"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceTotEntFrmDate" runat="server" TargetControlID="mskEValStrDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <asp:Label ID="lbltoEntToDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 130px;">
                                    <asp:TextBox ID="txtTotEntToDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnTTDate" runat="server" Style="float: left">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceTTDate" runat="server" TargetControlID="txtTotEntToDate"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnTTDate">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblTotEntToDateInfo"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="mseToEntToDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtTotEntToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvtotEntToDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtTotEntToDate" ValidationGroup="GetCountTot" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceToEntToDate" runat="server" TargetControlID="cvtotEntToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="msevToEntToDate" ControlExtender="mseToEntToDate" ControlToValidate="txtTotEntToDate"
                                        runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetCountTot"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceMseToEntToDate" runat="server" TargetControlID="msevToEntToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompValToDate" runat="server" ControlToValidate="txtTotEntToDate"
                                        ControlToCompare="txtTotEntFrmDate" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                                        Operator="GreaterThanEqual" ValidationGroup="GetCountTot" Type="Date" Display="None"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceTotFromToDate" runat="server" TargetControlID="CompValToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnTotEntGetCount" runat="server" Text="<%$Resources:PFSalesResource, GetCount%>"
                                            ToolTip="<%$Resources:PFSalesResource, GetTotCount%>" ValidationGroup="GetCountTot"
                                            OnClick="lnkbtnTotEntGetCount_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd style="width: 115px;">
                                    <%--<asp:TextBox ID="txtTodTotEnq" Width="80" CssClass="inputClass inputTextCenterClass"
                                    Text="" runat="server"></asp:TextBox>--%>
                                    <asp:LinkButton ID="lnkbtnTodTotEnq" CssClass="inputTextCenterClass" runat="server"
                                        Text="0" Enabled="false" Style="font-size: large;" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                        OnClick="lnkbtnTodTotEnq_Click" CausesValidation="false"></asp:LinkButton>
                                </dd>
                            </dl>
                            <%--<div style="float: left; width: 90%">
                            <b>
                                <asp:Literal ID="ltrUnAlocEntries" runat="server" Text="<%$Resources:PFSalesResource, UnallocatedEnq%>"></asp:Literal>
                            </b>
                        </div>--%>
                            <%-- <div class="headText" style="margin-top: 0px; padding-bottom: 0px; padding-top: 0px">
                        </div>--%>
                            <dl class="dealerRagisterTwo " runat="server" visible="false">
                                <dt>
                                    <asp:Label ID="lblUnAlocFromDate" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 135px;">
                                    <asp:TextBox ID="txtUnAlocFromDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnUFDate" runat="server" Style="float: left">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceUFDate" runat="server" TargetControlID="txtUnAlocFromDate"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnUFDate">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblUnalocFrDateInfo"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="meeUnEntFrmDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtUnAlocFromDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvUnEntFrmDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtUnAlocFromDate" ValidationGroup="GetCountUnaloc" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceCompUnEntFrmDate" runat="server" TargetControlID="cvUnEntFrmDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="mskEValUnStrDate" ControlExtender="meeUnEntFrmDate"
                                        ControlToValidate="txtUnAlocFromDate" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetCountUnaloc"></ajax:MaskedEditValidator>
                                    <ajax:MaskedEditValidator ID="mevfromDateForAlllocate" ControlExtender="meeUnEntFrmDate"
                                        ControlToValidate="txtUnAlocFromDate" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="Allocate"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceUnEntFrmDate" runat="server" TargetControlID="mskEValUnStrDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:ValidatorCalloutExtender ID="vcefromDateForAlllocate" runat="server" TargetControlID="mskEValUnStrDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <asp:Label ID="lblUnAlocToDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 130px;">
                                    <asp:TextBox ID="txtUnalocToDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnUTDate" runat="server" Style="float: left">
                                        <asp:Image ID="imfUTDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceUTDate" runat="server" TargetControlID="txtUnalocToDate"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnUTDate">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblUnalocToDateInfo"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="mseUnEntToDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtUnalocToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvUnEntToDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtUnalocToDate" ValidationGroup="GetCountUnaloc" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceUnEntToDate" runat="server" TargetControlID="cvUnEntToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="msevUnEntToDate" ControlExtender="mseUnEntToDate" ControlToValidate="txtUnalocToDate"
                                        runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetCountUnaloc"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceMseUnEntToDate" runat="server" TargetControlID="msevUnEntToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvUnToFromDateVal" runat="server" ControlToValidate="txtUnalocToDate"
                                        ControlToCompare="txtUnAlocFromDate" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                                        Operator="GreaterThanEqual" ValidationGroup="GetCountTot" Type="Date" Display="None"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceUnToFromDate" runat="server" TargetControlID="cvUnToFromDateVal"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnUnalocGetCount" runat="server" Text="<%$Resources:PFSalesResource, GetCount%>"
                                            ToolTip="<%$Resources:PFSalesResource, GetUnalocCount%>" ValidationGroup="GetCountUnaloc"
                                            OnClick="lnkbtnUnalocGetCount_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd style="width: 115px;">
                                    <asp:LinkButton ID="lnkbtnUnallocatedEnq" CssClass="inputTextCenterClass" runat="server"
                                        Text="0" Enabled="false" Style="font-size: large;" CausesValidation="false" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                        OnClick="lnkbtnUnallocatedEnq_Click"></asp:LinkButton>
                                </dd>
                            </dl>
                            <div class="headText">
                            </div>
                            <div class="button">
                                <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                    ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                            </div>
                        </asp:Panel>
                        <asp:HiddenField ID="hdfFTCtoAssign" runat="server" Value="0" />
                        <asp:Panel ID="pnlFCleadAllocation" runat="server" Visible="false" DefaultButton="lnkbtnAllocate">
                            <div class="error" id="dvFCserError" runat="server" visible="false">
                                <asp:Label ID="lblFCSerError" runat="server"></asp:Label>
                            </div>
                            <div class="success" id="dvFCSerSuccess" runat="server" visible="false">
                                <asp:Label ID="lblFCSerSuccess" runat="server"></asp:Label>
                            </div>
                            <dl id="Dl1" class="dealerRagisterTwo " runat="server" visible="false">
                                <dt>
                                    <asp:Label ID="lblFCtoEntFromDate1" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 135px;">
                                    <asp:TextBox ID="txtFCTotEntFrmDate1" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnFCCalTFDate1" runat="server" Style="float: left">
                                        <asp:Image ID="imgFCCalFDate1" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceFCTFDate1" runat="server" TargetControlID="txtFCTotEntFrmDate1"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnFCCalTFDate1">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblFCTotEntFromDateInfo1"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="meeFCTotEntFrmDate1" runat="server" MaskType="Date"
                                        Mask="<%$ Resources:PfSalesResource, masktype %>" TargetControlID="txtFCTotEntFrmDate1"
                                        MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvFCTotEntFrmDate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtFCTotEntFrmDate1" ValidationGroup="GetFCCountTot1" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCCompTotEntFrmDate1" runat="server" TargetControlID="cvFCTotEntFrmDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="mskEValFCStrDate1" ControlExtender="meeFCTotEntFrmDate1"
                                        ControlToValidate="txtTotFCEntFrmDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetFCCountTot1"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceTotFCEntFrmDate1" runat="server" TargetControlID="mskEValFCStrDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <asp:Label ID="lblFCtoEntToDate1" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 130px;">
                                    <asp:TextBox ID="txtFCTotEntToDate1" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnFCTTDate1" runat="server" Style="float: left">
                                        <asp:Image ID="ImageFC11" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceFCTTDate1" runat="server" TargetControlID="txtFCTotEntToDate1"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnFCTTDate1">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblFCTotEntToDateInfo1"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="mseFCToEntToDate1" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtFCTotEntToDate1" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvFCtotEntToDate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtFCTotEntToDate1" ValidationGroup="GetCountTot1" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCToEntToDate1" runat="server" TargetControlID="cvFCtotEntToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="msevFCToEntToDate1" ControlExtender="mseFCToEntToDate1"
                                        ControlToValidate="txtFCTotEntToDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetFCCountTot1"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceMseFCToEntToDate1" runat="server" TargetControlID="msevFCToEntToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompValFCToDate1" runat="server" ControlToValidate="txtFCTotEntToDate1"
                                        ControlToCompare="txtFCTotEntFrmDate1" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                                        Operator="GreaterThanEqual" ValidationGroup="GetFCCountTot1" Type="Date" Display="None"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCTotFromToDate1" runat="server" TargetControlID="CompValFCToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnFCTotEntGetCount1" runat="server" Text="<%$Resources:PFSalesResource, GetCount%>"
                                            ToolTip="<%$Resources:PFSalesResource, GetTotCount%>" ValidationGroup="GetFCCountTot1"
                                            OnClick="lnkbtnFCTotEntGetCount1_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd style="width: 115px;">
                                    <%--<asp:TextBox ID="txtTodTotEnq" Width="80" CssClass="inputClass inputTextCenterClass"
                                    Text="" runat="server"></asp:TextBox>--%>
                                    <div style="width: 30%; margin: 0 auto;">
                                        <asp:Label ID="LabelFC1" runat="server" Text="<%$Resources:PFSalesResource,NewEnquiries %>"></asp:Label>:
                                        <asp:LinkButton ID="lnkbtnFCTodTotEnq1" CssClass="inputTextCenterClass" runat="server"
                                            Text="0" Enabled="false" Style="font-size: large;" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                            OnClick="lnkbtnFCTodTotEnq1_Click" CausesValidation="false"></asp:LinkButton>
                                    </div>
                                </dd>
                            </dl>
                            <dl id="Dl2" class="dealerRagisterTwo " runat="server" visible="false">
                                <dt>
                                    <asp:Label ID="lblFCUnAlocFromDate1" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 135px;">
                                    <asp:TextBox ID="txtFCUnAlocFromDate1" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnFCUFDate1" runat="server" Style="float: left">
                                        <asp:Image ID="ImageFC21" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceFCUFDate1" runat="server" TargetControlID="txtFCUnAlocFromDate1"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnFCUFDate1">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblFCUnalocFrDateInfo1"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="meeFCUnEntFrmDate1" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtFCUnAlocFromDate1" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvFCUnEntFrmDate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtFCUnAlocFromDate1" ValidationGroup="GetFCCountUnaloc1"
                                        ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>" Display="None">
                                    </asp:CompareValidator>
                                    <asp:CompareValidator ID="cvValFCForAllocate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtFCUnAlocFromDate1" ValidationGroup="FCAllocate" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCCompUnEntFrmDate1" runat="server" TargetControlID="cvFCUnEntFrmDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:ValidatorCalloutExtender ID="vceFCForAllocate1" runat="server" TargetControlID="cvValFCForAllocate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="mskEValFCUnStrDate1" ControlExtender="meeFCUnEntFrmDate1"
                                        ControlToValidate="txtFCUnAlocFromDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetFCCountUnaloc1"></ajax:MaskedEditValidator>
                                    <ajax:MaskedEditValidator ID="mevFCfromDateForAlllocate1" ControlExtender="meeFCUnEntFrmDate1"
                                        ControlToValidate="txtFCUnAlocFromDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="FCAllocate"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCUnEntFrmDate1" runat="server" TargetControlID="mskEValFCUnStrDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:ValidatorCalloutExtender ID="vceFCfromDateForAlllocate1" runat="server" TargetControlID="mskEValFCUnStrDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <asp:Label ID="lblFCUnAlocToDate1" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 130px;">
                                    <asp:TextBox ID="txtFCUnalocToDate1" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnFCUTDate1" runat="server" Style="float: left">
                                        <asp:Image ID="imfUTDateFC1" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceFCUTDate1" runat="server" TargetControlID="txtFCUnalocToDate1"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnFCUTDate1">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblFCUnalocToDateInfo1"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="mseFCUnEntToDate1" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtFCUnalocToDate1" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvFCUnEntToDate1" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtFCUnalocToDate1" ValidationGroup="GetFCCountUnaloc1" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCUnEntToDate1" runat="server" TargetControlID="cvFCUnEntToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="msevFCUnEntToDate1" ControlExtender="mseFCUnEntToDate"
                                        ControlToValidate="txtFCUnalocToDate1" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetFCCountUnaloc"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCMseUnEntToDate1" runat="server" TargetControlID="msevFCUnEntToDate1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvFCUnToFromDateVal1" runat="server" ControlToValidate="txtFCUnalocToDate1"
                                        ControlToCompare="txtFCUnAlocFromDate1" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                                        Operator="GreaterThanEqual" ValidationGroup="GetFCCountTot1" Type="Date" Display="None"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCUnToFromDate1" runat="server" TargetControlID="cvFCUnToFromDateVal1"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnFCUnalocGetCount1" runat="server" Text="<%$Resources:PFSalesResource, GetCount%>"
                                            ToolTip="<%$Resources:PFSalesResource, GetUnalocCount%>" ValidationGroup="GetFCCountUnaloc1"
                                            OnClick="lnkbtnFCUnalocGetCount1_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd style="width: 115px;">
                                    <%--<asp:LinkButton ID="lnkbtnUnallocatedEnq1" CssClass="inputTextCenterClass" runat="server"
                                    Text="0" Enabled="false" Style="font-size: large;" CausesValidation="false" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                    OnClick="lnkbtnUnallocatedEnq1_Click"></asp:LinkButton>--%>
                                </dd>
                            </dl>
                            <div style="width: 30%; margin: 0 auto;">
                                <asp:Label ID="lblFCNewEntries" runat="server" Text="<%$Resources:PFSalesResource,NewEnquiries %>"></asp:Label>:
                                <asp:LinkButton ID="lnkbtnFCUnallocatedEnq1" CssClass="inputTextCenterClass" runat="server"
                                    Text="0" Enabled="false" Style="font-size: large;" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                    CausesValidation="false" OnClick="lnkbtnFCUnallocatedEnq1_Click"></asp:LinkButton>
                            </div>
                            <div runat="server" visible="false" style="float: left; width: 90%">
                                <b>
                                    <asp:Literal ID="ltrFCFleetTeamLeadAlloc" runat="server" Text="<%$Resources:PFSalesResource, FleetTeamLeadAllocation%>"></asp:Literal>
                                </b>
                            </div>
                            <div runat="server" visible="false" class="headText" style="margin-top: 0px; padding-bottom: 0px;
                                padding-top: 0px">
                            </div>
                            <asp:Panel runat="server" Visible="false" ID="pnlFCteamLeads">
                                <asp:GridView ID="gvFCTeamLead" runat="server" Visible="false" CellSpacing="0" Width="100%"
                                    CellPadding="0" border="0" class="tableGride" PagerStyle-CssClass="footerpaging"
                                    GridLines="None" AutoGenerateColumns="false" rule="none" AllowSorting="true">
                                    <%--OnRowDataBound="gvFCTeamLead_RowDataBound"--%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFCProspName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                                <asp:HiddenField ID="hdfFCFName" runat="server" Value='<%#Bind("FirstName") %>'>
                                                </asp:HiddenField>
                                                <asp:HiddenField ID="hdfFCProspectId" runat="server" Value='<%#Bind("Id") %>'></asp:HiddenField>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ProspectSrc %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFCProspectSrc" runat="server" Text='<%#Bind("RefSource") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Consultant %>">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlFCTeamLeedConsultant" runat="server" CssClass="selectClass"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlFCTeamLeedConsultant_SelectedIndexChanged">
                                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvFCtlConsult" runat="server" ControlToValidate="ddlFCTeamLeedConsultant"
                                                    Display="None" InitialValue="0" ValidationGroup="FCTeamAllocate" ErrorMessage="<%$Resources:PFSalesResource,SelConsultantVal %>"></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="vceFCLConsult" runat="server" TargetControlID="rfvFCtlConsult"
                                                    PopupPosition="TopLeft">
                                                </ajax:ValidatorCalloutExtender>
                                                <asp:HiddenField ID="hdfFCConsultEmail" runat="server" Value="0"></asp:HiddenField>
                                                <asp:HiddenField ID="hdfFCConsultFName" runat="server" Value=""></asp:HiddenField>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center">
                                            <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoDataFound %>"></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </asp:Panel>
                            <div class="headText" runat="server" visible="false">
                            </div>
                            <div class="button" runat="server" visible="false">
                                <asp:LinkButton ID="lnkbtnFCLeadTeamAllocate" runat="server" Text="<%$Resources:PFSalesResource,Allocate %>"
                                    ToolTip="<%$Resources:PFSalesResource,AllocateLeads %>" ValidationGroup="FCTeamAllocate"
                                    OnClick="lnkbtnFCLeadTeamAllocate_Click"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnFCClearTeamAllocate" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                    ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnFCClearTeamAllocate_Click"></asp:LinkButton>
                            </div>
                            <div class="headText" runat="server" visible="false">
                            </div>
                            <div style="float: left; width: 90%">
                                <b>
                                    <asp:Literal ID="ltrFCNormalLeadAllocHead" runat="server" Text="<%$Resources:PFSalesResource, NormalLeadAllocation%>"></asp:Literal>
                                </b>
                            </div>
                            <div class="headText" style="margin-top: 0px; padding-bottom: 0px; padding-top: 0px">
                            </div>
                            <asp:GridView ID="gvFCAllocate" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                                border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                                AutoGenerateColumns="false" rule="none" AllowSorting="true" OnSorting="gvFCAllocate_Soring"
                                OnRowCreated="gvFCAllocate_Created" OnRowDataBound="gvFCAllocate_RowDatabound"
                                ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkFCSelectAll" runat="server" onclick="CheckAllGridCheckbox('gvFCAllocate', this.id, 'chkFCSelect')" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkFCSelect" runat="server" />
                                            <asp:HiddenField ID="hdfFCConsultantId" runat="server" Value='<%#Bind("VirtualRoleId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFCConsultName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                            <asp:HiddenField ID="hdfFCFName" runat="server" Value='<%#Bind("FirstName") %>'>
                                            </asp:HiddenField>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblltrFCTotl" runat="server" Text="<%$Resources:PFSalesResource,Total %>"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Today %>" Visible="true"
                                        SortExpression="TodaysLeads">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFTodaysLeads" runat="server" Text='<%#Bind("TodaysLeads") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFCTodLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,TwentyFourHr %>" Visible="true"
                                        SortExpression="24HrsLeads">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFTwentyFourHr" runat="server" Text='<%#Bind("24HrsLeads") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFC24hrLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ThisWeek %>" Visible="true"
                                        SortExpression="ThisWeek">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFThisWeek" runat="server" Text='<%#Bind("ThisWeek") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFCWeekLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ThisMonth %>" Visible="true"
                                        SortExpression="ThisMonth">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFThisMonth" runat="server" Text='<%#Bind("ThisMonth") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFCMonthLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FortyEightHr %>" Visible="false"
                                        SortExpression="Before48Hrs">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFCContfortyEighthr" runat="server" Text='<%#Bind("Before48Hrs") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFC48Lead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,SevenDays %>" Visible="false"
                                        SortExpression="Before7Days">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFCContSevenDays" runat="server" Text='<%#Bind("Before7Days") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFC7DLead" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmailId %>" Visible="false"
                                        SortExpression="EmailId">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFCContEmailId" runat="server" Text='<%#Bind("EmailId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFCEmail" runat="server" Text="--"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,MobileNo %>" Visible="false"
                                        SortExpression="MobileNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFCContMobileNo" runat="server" Text='<%#Bind("MobileNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFCMob" runat="server" Text="--"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CurrentWorkLoad %>" SortExpression="WorkLoad">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnFCCurrWorkLoad" CssClass="inputTextCenterClass" runat="server"
                                                Text='<%#Bind("WorkLoad") %>' CommandArgument='<%#Bind("VirtualRoleId") %>' ToolTip="<%$Resources:PFSalesResource,ViewCurrentWorkLoad %>"
                                                OnClick="lnkbtnFCCurrWorkLoad_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFCCWLoad" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,LoadNotYetCalledHead %>"
                                        SortExpression="LoadNotYetCalled">
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblFCLoadNotYetCalled" runat="server" Text='<%#Bind("LoadNotYetCalled") %>'></asp:Label>--%>
                                            <asp:LinkButton ID="lnkbtnFCNotYetCalled" CssClass="inputTextCenterClass" runat="server"
                                                Text='<%#Bind("LoadNotYetCalled") %>' CommandArgument='<%#Bind("VirtualRoleId") %>'
                                                OnClick="lnkbtnFCNotYetCalled_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFCNYC" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Leads %>">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFCNoOfLeads" CssClass="inputClass inputTextCenterClass" Width="50px"
                                                runat="server" Enabled="true" Text="0" MaxLength="2"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="fteFCNoOfLeadst" runat="server" TargetControlID="txtFCNoOfLeads"
                                                FilterType="Custom" ValidChars="0123456789">
                                            </ajax:FilteredTextBoxExtender>
                                            <asp:CompareValidator ID="cvFCNoOfLeadsVal" runat="server" Type="Integer" Operator="GreaterThan"
                                                ControlToValidate="txtFCNoOfLeads" ValueToCompare="0" ValidationGroup="other"
                                                ErrorMessage="<%$ Resources:PfSalesResource, ResetRangeVal%>" Display="None">
                                            </asp:CompareValidator>
                                            <ajax:ValidatorCalloutExtender ID="vceFCNoOfLeadsVal" runat="server" TargetControlID="cvFCNoOfLeadsVal"
                                                PopupPosition="TopRight">
                                            </ajax:ValidatorCalloutExtender>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotlFCLead" runat="server" Text="--"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center">
                                        <asp:Label ID="lblFCNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoDataFound %>"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <div class="headText">
                            </div>
                            <dl class="dealerRagisterTwo ">
                                <dt>
                                    <asp:Label ID="lblFCResetAllTo" runat="server" Text="<%$Resources:PFSalesResource,ResetAllTo %>"></asp:Label>:
                                </dt>
                                <dd>
                                    <asp:TextBox ID="txtFCBulkAmt" Width="50" CssClass="inputClass inputTextCenterClass"
                                        runat="server" MaxLength="2"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fteFCBulkamt" runat="server" TargetControlID="txtFCBulkAmt"
                                        FilterType="Custom" ValidChars="0123456789">
                                    </ajax:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="rfvFCBulkamt" runat="server" ControlToValidate="txtFCBulkAmt"
                                        Display="None" ValidationGroup="FCReset" ErrorMessage="<%$ Resources:PFSalesResource,ResetToAllVal %>"
                                        SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCBulkamt" runat="server" TargetControlID="rfvFCBulkamt"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvFCBulkAmt" runat="server" Type="Integer" Operator="GreaterThan"
                                        ControlToValidate="txtFCBulkAmt" ValueToCompare="0" ValidationGroup="FCReset"
                                        ErrorMessage="<%$ Resources:PfSalesResource, ResetRangeVal%>" Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCResetAllRange" runat="server" TargetControlID="cvFCBulkAmt"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <div class="button" style="margin-left: 15px;">
                                        <asp:LinkButton ID="lnkbtnFCSet" runat="server" Text="<%$Resources:PFSalesResource,Set %>"
                                            ToolTip="<%$Resources:PFSalesResource,SetBulkLeadCount %>" OnClientClick="javascript:return TestFCSecCheckBox();"
                                            ValidationGroup="FCReset" OnClick="lnkbtnFCSet_Click"></asp:LinkButton>
                                    </div>
                                </dd>
                                <dt></dt>
                                <dd>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnFCAllocate" runat="server" Text="<%$Resources:PFSalesResource,Allocate %>"
                                            ToolTip="<%$Resources:PFSalesResource,AllocateLeads %>" Style="padding: 7px 15px;
                                            font-size: 21px; font-weight: bold;" ValidationGroup="FCAllocate" OnClick="lnkbtnFCAllocate_Click"
                                            OnClientClick="javascript:return TestFCTextBox();"></asp:LinkButton>
                                    </div>
                                </dd>
                            </dl>
                            <div class="headText">
                            </div>
                            <div style="float: left; width: 90%">
                                <b>
                                    <asp:Literal ID="ltrlblFCTotEnquiry" runat="server" Text="<%$Resources:PFSalesResource, TodaysEnquiry%>"></asp:Literal>
                                </b>
                            </div>
                            <div class="headText" style="margin-top: 0px; padding-bottom: 0px; padding-top: 0px">
                            </div>
                            <dl class="dealerRagisterTwo ">
                                <dt>
                                    <asp:Label ID="lblFCtoEntFromDate" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 135px;">
                                    <asp:TextBox ID="txtFCTotEntFrmDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnFCCalTFDate" runat="server" Style="float: left">
                                        <asp:Image ID="imgFCCalFDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceFCTFDate" runat="server" TargetControlID="txtFCTotEntFrmDate"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnFCCalTFDate">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblFCTotEntFromDateInfo"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="meeFCTotEntFrmDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtFCTotEntFrmDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvFCTotEntFrmDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtFCTotEntFrmDate" ValidationGroup="GetFCCountTot" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCCompTotEntFrmDate" runat="server" TargetControlID="cvFCTotEntFrmDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="mskEValFCStrDate" ControlExtender="meeFCTotEntFrmDate"
                                        ControlToValidate="txtFCTotEntFrmDate" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetFCCountTot"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCTotEntFrmDate" runat="server" TargetControlID="mskEValFCStrDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <asp:Label ID="lblFCtoEntToDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 130px;">
                                    <asp:TextBox ID="txtFCTotEntToDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnFCTTDate" runat="server" Style="float: left">
                                        <asp:Image ID="ImageFC1" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceFCTTDate" runat="server" TargetControlID="txtFCTotEntToDate"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnFCTTDate">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblTotFCEntToDateInfo"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="mseFCToEntToDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtFCTotEntToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvFCtotEntToDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtFCTotEntToDate" ValidationGroup="GetFCCountTot" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCToEntToDate" runat="server" TargetControlID="cvFCtotEntToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="msevFCToEntToDate" ControlExtender="mseFCToEntToDate"
                                        ControlToValidate="txtFCTotEntToDate" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetFCCountTot"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceMseFCToEntToDate" runat="server" TargetControlID="msevFCToEntToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompValFCToDate" runat="server" ControlToValidate="txtFCTotEntToDate"
                                        ControlToCompare="txtFCTotEntFrmDate" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                                        Operator="GreaterThanEqual" ValidationGroup="GetFCCountTot" Type="Date" Display="None"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCTotFromToDate" runat="server" TargetControlID="CompValFCToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnFCTotEntGetCount" runat="server" Text="<%$Resources:PFSalesResource, GetCount%>"
                                            ToolTip="<%$Resources:PFSalesResource, GetTotCount%>" ValidationGroup="GetFCCountTot"
                                            OnClick="lnkbtnFCTotEntGetCount_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd style="width: 115px;">
                                    <%--<asp:TextBox ID="txtTodTotEnq" Width="80" CssClass="inputClass inputTextCenterClass"
                                    Text="" runat="server"></asp:TextBox>--%>
                                    <asp:LinkButton ID="lnkbtnFCTodTotEnq" CssClass="inputTextCenterClass" runat="server"
                                        Text="0" Enabled="false" Style="font-size: large;" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                        OnClick="lnkbtnFCTodTotEnq_Click" CausesValidation="false"></asp:LinkButton>
                                </dd>
                            </dl>
                            <dl class="dealerRagisterTwo " runat="server" visible="false">
                                <dt>
                                    <asp:Label ID="lblFCUnAlocFromDate" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 135px;">
                                    <asp:TextBox ID="txtFCUnAlocFromDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnFCUFDate" runat="server" Style="float: left">
                                        <asp:Image ID="ImageFC2" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceFCUFDate" runat="server" TargetControlID="txtFCUnAlocFromDate"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnFCUFDate">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblFCUnalocFrDateInfo"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="meeFCUnEntFrmDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtFCUnAlocFromDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvFCUnEntFrmDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtFCUnAlocFromDate" ValidationGroup="GetFCCountUnaloc" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCCompUnEntFrmDate" runat="server" TargetControlID="cvFCUnEntFrmDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="mskEValFCUnStrDate" ControlExtender="meeFCUnEntFrmDate"
                                        ControlToValidate="txtFCUnAlocFromDate" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetFCCountUnaloc"></ajax:MaskedEditValidator>
                                    <ajax:MaskedEditValidator ID="mevFCfromDateForAlllocate" ControlExtender="meeFCUnEntFrmDate"
                                        ControlToValidate="txtFCUnAlocFromDate" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="FCAllocate"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCUnEntFrmDate" runat="server" TargetControlID="mskEValFCUnStrDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:ValidatorCalloutExtender ID="vceFCfromDateForAlllocate" runat="server" TargetControlID="mskEValFCUnStrDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <asp:Label ID="lblFCUnAlocToDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                                </dt>
                                <dd style="width: 130px;">
                                    <asp:TextBox ID="txtFCUnalocToDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                                    <asp:LinkButton ID="lnkbtnFCUTDate" runat="server" Style="float: left">
                                        <asp:Image ID="imfFCUTDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                    <ajax:CalendarExtender ID="ceFCUTDate" runat="server" TargetControlID="txtFCUnalocToDate"
                                        Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnFCUTDate">
                                    </ajax:CalendarExtender>
                                    <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblFCUnalocToDateInfo"
                                        runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                    <ajax:MaskedEditExtender ID="mseFCUnEntToDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                        TargetControlID="txtFCUnalocToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                    <asp:CompareValidator ID="cvFCUnEntToDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                        ControlToValidate="txtFCUnalocToDate" ValidationGroup="GetFCCountUnaloc" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                        Display="None">
                                    </asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCUnEntToDate" runat="server" TargetControlID="cvFCUnEntToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:MaskedEditValidator ID="msevFCUnEntToDate" ControlExtender="mseFCUnEntToDate"
                                        ControlToValidate="txtFCUnalocToDate" runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                                        ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                        ValidationGroup="GetFCCountUnaloc"></ajax:MaskedEditValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCMseUnEntToDate" runat="server" TargetControlID="msevFCUnEntToDate"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvFCUnToFromDateVal" runat="server" ControlToValidate="txtFCUnalocToDate"
                                        ControlToCompare="txtFCUnAlocFromDate" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                                        Operator="GreaterThanEqual" ValidationGroup="GetFCCountTot" Type="Date" Display="None"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="vceFCUnToFromDate" runat="server" TargetControlID="cvFCUnToFromDateVal"
                                        PopupPosition="TopLeft">
                                    </ajax:ValidatorCalloutExtender>
                                </dd>
                                <dt>
                                    <div class="button">
                                        <asp:LinkButton ID="lnkbtnFCUnalocGetCount" runat="server" Text="<%$Resources:PFSalesResource, GetCount%>"
                                            ToolTip="<%$Resources:PFSalesResource, GetUnalocCount%>" ValidationGroup="GetFCCountUnaloc"
                                            OnClick="lnkbtnFCUnalocGetCount_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd style="width: 115px;">
                                    <asp:LinkButton ID="lnkbtnFCUnallocatedEnq" CssClass="inputTextCenterClass" runat="server"
                                        Text="0" Enabled="false" Style="font-size: large;" CausesValidation="false" ToolTip="<%$Resources:PFSalesResource,ViewEnqDetails %>"
                                        OnClick="lnkbtnFCUnallocatedEnq_Click"></asp:LinkButton>
                                </dd>
                            </dl>
                            <div class="headText">
                            </div>
                            <div class="button">
                                <asp:LinkButton ID="lnkbtnFCClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                    ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnFCClear_Click"></asp:LinkButton>
                            </div>
                        </asp:Panel>
                        <asp:HiddenField ID="hdfFCFTCtoAssign" runat="server" Value="0" />
                    </div>
                </div>
                <asp:Panel ID="pnlTotLeadViewPopUp" runat="server" Visible="false">
                    <div class="pop-up">
                    </div>
                    <div class="contentPopUp" style="left: 74%; top: 15%; width: 925px;">
                        <div class="popHeader">
                            <asp:Label ID="lblTotLeadView" runat="server" Text="<%$ Resources:PFSalesResource,TodaysEnquiryDetails%>"></asp:Label>
                            <asp:LinkButton ID="lnkbtnPhPopClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                                OnClick="lnkbtnPhPopClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                        </div>
                        <div class="dilContenerTwo">
                            <div style="height: auto; width: 100%">
                                <div style="float: left; width: 74%">
                                    <dl class="dealerRagisterTwo ">
                                        <dt style="width: 100px;">
                                            <%--  <asp:Label ID="lblUnAlloCateLegend" runat="server" Text="<%$Resources:PFSalesResource,UnallocatedEnq %>"></asp:Label>--%>
                                            <asp:LinkButton ID="lnkbtnFilterUnall" runat="server" ToolTip="<%$Resources:PFSalesResource,UnallocatedEnqToolTip %>"
                                                OnClick="lnkbtnFilterUnall_Click" Visible="false">
                                                <div id="dvFilterUnAlloc" style="color: black; height: 15px; padding-bottom: 5px;
                                                    padding-left: 5px; padding-right: 5px; padding-top: 5px; text-align: center;
                                                    width: 130px; background-color: #FFCDCD; border: solid 1px #737373; text-align: center;"
                                                    runat="server" visible="false">
                                                    <asp:Label ID="lblUnallocatedlegend" runat="server" Text="<%$Resources:PFSalesResource,UnallocatedEnqLegend %>"></asp:Label>
                                                </div>
                                            </asp:LinkButton>
                                        </dt>
                                        <dd style="width: 40px;">
                                        </dd>
                                        <dt style="width: 100px;">
                                            <asp:LinkButton ID="lnkbtnFilterAlloc" runat="server" ToolTip="<%$Resources:PFSalesResource,AllocatedEnqToolTip %>"
                                                OnClick="lnkbtnFilterAlloc_Click" Visible="false">
                                                <div id="dvFilterAlloc" style="color: black; height: 15px; padding-bottom: 5px; padding-left: 5px;
                                                    padding-right: 5px; padding-top: 5px; text-align: center; width: 130px; background-color: #D6FFBC;
                                                    border: solid 1px #737373; text-align: center;" runat="server" visible="false">
                                                    <asp:Label ID="lblAllocatedLegend" runat="server" Text="<%$Resources:PFSalesResource,AllocatedEnqLegend %>"></asp:Label>
                                                </div>
                                            </asp:LinkButton>
                                        </dt>
                                        <dd style="width: 40px;">
                                        </dd>
                                        <dt style="width: 100px;">
                                            <asp:LinkButton ID="lnkbtnClearFilter" runat="server" ToolTip="<%$Resources:PFSalesResource,ClearFilter %>"
                                                OnClick="lnkbtnClearFilter_Click" Visible="false">
                                                <div id="dvClearFilter" runat="server" style="color: black; height: 15px; padding-bottom: 5px;
                                                    padding-left: 5px; padding-right: 5px; padding-top: 5px; text-align: center;
                                                    width: 130px; background-color: White; border: solid 1px #737373; text-align: center;"
                                                    visible="false">
                                                    <asp:Label ID="lblClearFilter" runat="server" Text="<%$Resources:PFSalesResource,ClearFilter %>"></asp:Label>
                                                </div>
                                            </asp:LinkButton>
                                        </dt>
                                    </dl>
                                </div>
                                <div style="float: right; width: 25%">
                                    <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                        <asp:ListItem Value="50" Text="50" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                        <asp:ListItem Value="150" Text="150"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div style="float: left; width: 100%;">
                                <asp:Panel ID="pnlVridview" runat="server" ScrollBars="Vertical" Height="350px" Width="875px">
                                    <asp:GridView ID="gvprosp" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                                        border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                                        AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                                        PageSize="50" OnRowDataBound="gvprosp_RowDataBound" OnSorting="gvprosp_Soring">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,AllocatedDateHead %>"
                                                SortExpression="AllocatedDateSort">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("AllocatedDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdfConsultantId" runat="server" Value='<%#Bind("ConsultantId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Status %>" SortExpression="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ReferelSource %>" SortExpression="RefSource"
                                                ItemStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRefSource" runat="server" Text='<%#Bind("RefSource") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ViewDetails %>">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnView" runat="server" ToolTip="<%$Resources:PFSalesResource,ViewProspDetails %>"
                                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnView_Click">
                                               <img src="Images/viewDetails.png"/>
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
                                    <div class="PagerContainer" id="div1" runat="server" width="100%">
                                        <MechPager:Class1 ID="pagerParentProsp" Visible="false" runat="server" OnCommand="pagerParentProsp_Command"
                                            GeneratePagerInfoSection="false" GenerateFirstLastSection="false" Width="100%" />
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="headText">
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlNYCViewPopUp" runat="server" Visible="false" Width="100%">
                    <div class="pop-up">
                    </div>
                    <div class="contentPopUp" style="left: 70%; top: 0%; width: 100%; height: 600px;">
                        <div class="popHeader">
                            <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:PFSalesResource,NotYetCalledDetails%>"></asp:Label>
                            <asp:LinkButton ID="lnkbtnNYCPopClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                                OnClick="lnkbtnNYCPopClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                        </div>
                        <div class="error" id="dvadderror" runat="server" visible="false">
                            <asp:Label ID="lblAddErrMsg" runat="server"></asp:Label>
                        </div>
                        <div class="success" id="dvaddSucc" runat="server" visible="false">
                            <asp:Label ID="lblAddSucMsg" runat="server"></asp:Label>
                        </div>
                        <div class="dilContenerTwo" style="margin: 20px 1px; width: 100%">
                            <div style="height: auto; width: 100%">
                                <div class="button">
                                    <asp:LinkButton ID="lnkbtnBulkAssign" runat="server" ToolTip="<%$Resources:PFSalesResource,BulkAssignTooltip %>"
                                        Text="<%$Resources:PFSalesResource,BulkAssign %>" OnClientClick="javascript:return TestNYCCheckBox();"
                                        OnClick="lnkbtnBulkAssign_Click">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBulkReAssign" runat="server" Text="<%$Resources:PFSalesResource,BulkReassign %>"
                                        ToolTip="<%$Resources:PFSalesResource,ReassignDtls %>" OnClick="lnkbtnBulkReAssign_Click"
                                        Visible="false" OnClientClick="javascript:return TestBRFCheckBox();">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBulkNTU" runat="server" ToolTip="<%$Resources:PFSalesResource,BulkNTUTooltip %>"
                                        Text="<%$Resources:PFSalesResource,BulkNTU %>" OnClientClick="javascript:return NTUNYCCheckBox();"
                                        OnClick="lnkbtnBulkNTU_Click">
                                    </asp:LinkButton>
                                </div>
                                <div style="float: right; width: 15%">
                                    <asp:Label ID="Label6" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                                    <asp:DropDownList ID="ddlPageSizeNYC" runat="server" CssClass="selectClass" Width="55px"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlPageSizeNYC_SelectedIndexChanged">
                                        <%-- <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                        <asp:ListItem Value="25" Text="25" Selected="True"></asp:ListItem>--%>
                                        <asp:ListItem Value="50" Text="50" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                        <asp:ListItem Value="150" Text="150"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="All"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div style="float: left; width: 100%;">
                                <asp:Panel ID="pnlNYCGridview" runat="server" ScrollBars="Vertical" Height="500px"
                                    Width="100%">
                                    <asp:GridView ID="gvNYC" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                                        border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                                        AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                                        PageSize="50" OnRowDataBound="gvNYC_RowDataBound" OnSorting="gvNYC_Soring">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" onclick="CheckAllGridCheckbox('gvNYC', this.id, 'chkSelect')" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%#Bind("Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <%-- <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,AllocatedDateHead %>"
                                                SortExpression="AllocatedDateSort">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAllocatedDate" runat="server" Text='<%#Bind("AllocatedDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EnquiryDateHead %>" SortExpression="CreatedDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("EnquiryDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,MemberNo %>" Visible="false"
                                                SortExpression="MemberNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMemberNo" runat="server" Text='<%#Bind("MemberNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CarMake %>" SortExpression="CarMake">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMake" runat="server" Text='<%#Bind("CarMake") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Model %>" SortExpression="Model">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPostalCode" runat="server" Text='<%#Bind("Model") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmailId %>" Visible="false"
                                                SortExpression="EmailId">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmailId" runat="server" Text='<%#Bind("Email1") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="<%$Resources:PFSalesResource,MobileNo %>" SortExpression="MobileNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%#Bind("MobileNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PhoneNo %>" SortExpression="Phone">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Bind("Phone") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Consultant %>" SortExpression="Consultant"
                                                Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblConsultant" runat="server" Text='<%#Bind("ConsultantId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,State %>" SortExpression="StateName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStates" runat="server" Text='<%#Bind("StateName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Notes %>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtNotes" runat="server" Text='<%#Bind("NOTES") %>' BackColor="Transparent"
                                                        BorderColor="Transparent" BorderStyle="None" BorderWidth="0px" MaxLength="50"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CitySuburb %>" SortExpression="CityName">
                                              <ItemTemplate>
                                                 <asp:Label ID="lblCity" runat="server" Text='<%#Bind("CityName") %>'></asp:Label>
                                              </ItemTemplate>
                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFStatus %>" SortExpression="status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdfPropStatusId" runat="server" Value='<%#Bind("StatusId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCStatus %>" SortExpression="FCStatus">
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
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Source %>" SortExpression="LeadSource">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLeadSource" runat="server" Text='<%#Bind("LeadSource") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,How %>" SortExpression="WhereDidUHear" ><%--ItemStyle-Width="10px" HeaderStyle-Width="10px"--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWhereDidUHear" runat="server" Text='<%#Bind("WhereDidUHear") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,View %>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnView" runat="server" ToolTip="<%$Resources:PFSalesResource,ViewProspDetails %>"
                                                        CommandArgument='<%#Eval("Id") %>'> OnClick="lnkbtnView_Click"
                                               <img width="20px" height="21px" src="Images/viewDetails.png"/>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdfForW" runat="server" Value='<%#Bind("ForW") %>' />
                                                    <asp:LinkButton ID="lnkbtnManageAct" runat="server" ToolTip="<%$Resources:PFSalesResource,ManageActivities %>"
                                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnManageAct_Click">
                                               <img src="Images/m.png"/>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnReassignAct" runat="server" ToolTip="<%$Resources:PFSalesResource,AssignConsultant %>"
                                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnReassignAct_Click">
                                                            <img src="Images/R.png"/>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnMarkAsDead" runat="server" ToolTip="<%$Resources:PFSalesResource,MakeStatusAsDead %>"
                                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnMarkAsDead_Click">
                                                            <img src="Images/D.png"/>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnMarkAsNTU" runat="server" ToolTip="<%$Resources:PFSalesResource,MakeStatusAsNTU %>"
                                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnMarkAsNTU_Click">
                                                            <img src="Images/N.png"/>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Add %>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnAddActivity" runat="server" ToolTip="<%$Resources:PFSalesResource,AddActivities %>"
                                                        CommandArgument='<%#Eval("Id") %>'>
                                               <img src="Images/a1.png"/>OnClick="lnkbtnAddActivity_Click"
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
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
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="headText">
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlWorkLoadDetUp" runat="server" Visible="false">
                    <div class="pop-up">
                    </div>
                    <div class="contentPopUp" style="height: 550px; left: 75%; top: 6%; width: 900px;">
                        <div class="popHeader">
                            <asp:Label ID="lblWorkload" runat="server" Text="<%$ Resources:PFSalesResource,EnquiryDetails%>"></asp:Label>
                            <asp:LinkButton ID="lnkWorkLoadClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                                OnClick="lnkWorkLoadClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                        </div>
                        <div class="dilContenerTwo">
                            <div style="height: 30px; margin-top: -10px; text-align: center; width: 80%;">
                                <b>
                                    <asp:Label ID="lblltrLeadNo" runat="server" Text="<%$Resources:PFSalesResource,LeadNo %>"></asp:Label></b>
                                <asp:Label ID="lblLeadNo" runat="server" Text="1"></asp:Label>
                            </div>
                            <dl class="dealerRagisterThree">
                                <dt><b>
                                    <asp:Label ID="lblltrName" runat="server" Text="<%$ Resources:PFSalesResource,Name %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailId %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblEmail1" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrPhoneNo" runat="server" Text="<%$ Resources:PFSalesResource,PhoneNo %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblPhNo" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrFax" runat="server" Text="<%$ Resources:PFSalesResource,Fax %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblFax" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrState" runat="server" Text="<%$ Resources:PFSalesResource,State %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblState" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrAddressLine1" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine1 %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblAddLine1" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrAddressLine3" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine3 %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblAddLine3" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrConsultant" runat="server" Text="<%$ Resources:PFSalesResource,Consultant %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblConsultant" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrAddStatus" runat="server" Text="<%$ Resources:PFSalesResource,Status %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblAddStatus" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrMemberNo" runat="server" Text="<%$ Resources:PFSalesResource,MemberNo %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblMemNo" runat="server"></asp:Label>
                                </dd>
                            </dl>
                            <dl class="dealerRagisterThree">
                                <dt><b>
                                    <asp:Label ID="lblltrCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblCarMake" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrAltEmail" runat="server" Text="<%$ Resources:PFSalesResource,AlternameEmail %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblAlterEmail" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrMobile" runat="server" Text="<%$ Resources:PFSalesResource,MobileNo %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblCountry" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrCity" runat="server" Text="<%$ Resources:PFSalesResource,City %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblCity" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrAddressLine2" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine2 %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblAddLine2" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrFConsultant" runat="server" Text="<%$ Resources:PFSalesResource,FConsultant %>"></asp:Label></dt></b>
                                <dd>
                                    <asp:Label ID="lblFConsultant" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrSource" runat="server" Text="<%$ Resources:PFSalesResource,ProspectSrc %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblSource" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrCreatedDate" runat="server" Text="<%$ Resources:PFSalesResource,EnquiryDate %>"></asp:Label></b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblEnqDate" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt id="dtalCont" runat="server" visible="false"><b>
                                    <asp:Label ID="lblltrAlternateNo" runat="server" Text="<%$ Resources:PFSalesResource,AlternateContNo %>"></asp:Label></b>
                                </dt>
                                <dd id="ddalCont" runat="server" visible="false">
                                    <asp:Label ID="lblAltContNo" runat="server"></asp:Label>
                                </dd>
                            </dl>
                            <div class="headText">
                            </div>
                            <div class="button">
                                <asp:LinkButton ID="lnkbtnPrev" runat="server" Text="<%$Resources:PFSalesResource,Previous %>"
                                    ToolTip="<%$Resources:PFSalesResource,ViewPrevEnqDet %>" OnClick="lnkbtnPrev_Click"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnNext" runat="server" Text="<%$Resources:PFSalesResource,Next %>"
                                    ToolTip="<%$Resources:PFSalesResource,ViewNextEnqDet %>" OnClick="lnkbtnNext_Click"></asp:LinkButton>
                                <asp:HiddenField ID="hdfCurrentLoadNo" runat="server" Value="1" />
                            </div>
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
                            <asp:Label ID="lblRalocationHead" runat="server" Text="<%$ Resources:PFSalesResource,BulkAssignmentOfLeads%>"></asp:Label>
                            <asp:LinkButton ID="lnkbtnReassClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                                OnClick="lnkbtnReassClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                        </div>
                        <div style="overflow-y: scroll; width: 100%; max-height: 550px;">
                            <dl class="dealerRagisterTwo" style="width: 93%">
                                <dt></dt>
                                <dd style="width: 100%">
                                    <asp:GridView ID="gvBulkAllocateConsult" runat="server" CellSpacing="0" Width="100%"
                                        CellPadding="0" border="0" class="tableGride" PagerStyle-CssClass="footerpaging"
                                        GridLines="None" AutoGenerateColumns="false" rule="none">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" onclick="CheckAllGridCheckbox('gvBulkAllocateConsult', this.id, 'chkSelect')" />
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
                                        <asp:LinkButton ID="lnkBtnBulkAllocate" runat="server" Text="<%$Resources:PFSalesResource,Allocate %>"
                                            ToolTip="<%$Resources:PFSalesResource,AllocateLeads %>" Style="padding: 7px 15px;
                                            font-size: 21px; font-weight: bold;" OnClientClick="javascript:return ReasTestCheckBox();"
                                            OnClick="lnkBtnBulkAllocate_Click"></asp:LinkButton>
                                    </div>
                                </dd>
                        </div>
                    </div>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                </asp:Panel>
            </div>
            <asp:HiddenField ID="hdfAttachmentPath" runat="server" Value="" />
            <asp:HiddenField ID="hdfSelProspIdForReass" runat="server" />
            <asp:HiddenField ID="hdfConsultantType" runat="server" />
            <asp:HiddenField ID="hdfSelectedLeadCount" runat="server" Value="0" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnAllocate" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproEmp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="upPanLeadAlloc">
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
