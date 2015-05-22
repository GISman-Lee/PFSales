<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ProspectDetails.ascx.cs"
    Inherits="UserControls_UC_ProspectDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="Edit" %>
<%@ Register Src="UC_AddEditContact.ascx" TagName="AddEditContact" TagPrefix="uc1" %>
<%--<asp:UpdatePanel ID="UpPanPrspect" runat="server">
    <ContentTemplate>--%>

<script language="javascript" type="text/javascript">
    function checkvalidMobNo(source, args) {
        args.IsValid = true;
        var smsno = document.getElementById('<%= txtSmsMobNum.ClientID %>');
        if (smsno.value != '') {
            var text = smsno.value.slice(0, 2);
            if (text == '04' && smsno.value.length == 10) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
        else {
            args.IsValid = false;
        }
        return;
    }
</script>

<div class="dilContenerTwo">
    <div class="error" id="dvadderror" runat="server" visible="false">
        <asp:Label ID="lblAddErrMsg" runat="server" Text=""></asp:Label>
    </div>
    <!--Content-Note: success Msg-->
    <div class="success" id="dvaddSucc" runat="server" visible="false">
        <asp:Label ID="lblAddSucMsg" runat="server" Text=""></asp:Label>
    </div>
    <div id="print_div">
        <div class="print">
            <div>
                <b style="float: left; font-size: 16px; margin-bottom: 10px;">
                    <asp:Label ID="lblHistoryHead" runat="server" Text="<%$Resources:PFSalesResource,EnquiryDetails %>"></asp:Label>
                </b>
            </div>
            <div style="clear: both; margin-bottom: 10px;">
            </div>
            <dl class="ProspDetails">
                <dt><b>
                    <asp:Label ID="lblltrName" runat="server" Text="<%$ Resources:PFSalesResource,Name %>"></asp:Label>:</b>
                </dt>
                <dd>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdfProspectId" runat="server" Value="0" />
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailId %>"></asp:Label>:</b>
                </dt>
                <dd>
                    <a id="aEmail" runat="server" href="" style="color: Blue; text-decoration: underline;">
                        <asp:Label ID="lblEmail1" runat="server"></asp:Label></a>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrPhoneNo" runat="server" Text="<%$ Resources:PFSalesResource,WorkPhone %>"></asp:Label></b>
                </dt>
                <dd>
                    <asp:Label ID="lblPhNo" runat="server"></asp:Label>
                </dd>
                <dt id="Dt1" runat="server" visible="false"><b>
                    <asp:Label ID="lblltrFax" runat="server" Text="<%$ Resources:PFSalesResource,Fax %>"></asp:Label>:</b>
                </dt>
                <dd id="Dd1" runat="server" visible="false">
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
                    <asp:Label ID="lblltrAddressLine1" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine1 %>"></asp:Label>:</b></dt>
                <dd>
                    <asp:Label ID="lblAddLine1" runat="server"></asp:Label>
                </dd>
                <dt id="Dt2" runat="server" visible="false"><b>
                    <asp:Label ID="lblltrAddressLine3" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine3 %>"></asp:Label>:</b></dt>
                <dd id="Dd2" runat="server" visible="false">
                    <asp:Label ID="lblAddLine3" runat="server"></asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrConsultant" runat="server" Text="<%$ Resources:PFSalesResource,Consultant %>"></asp:Label>:</b></dt>
                <dd>
                    <asp:Label ID="lblConsultant" runat="server">
                    </asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrAddStatus" runat="server" Text="<%$ Resources:PFSalesResource,PFStatus %>"></asp:Label>:</b></dt>
                <dd>
                    <asp:Label ID="lblAddStatus" runat="server">
                    </asp:Label>
                    <asp:HiddenField ID="hdfProspStatus" runat="server" Value="0" />
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrMemberNo" runat="server" Text="<%$ Resources:PFSalesResource,MemberNo %>"></asp:Label>:</b></dt>
                <dd>
                    <asp:Label ID="lblMemNo" runat="server"></asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrTradeIn" runat="server" Text="<%$ Resources:PFSalesResource,TradeIn %>"></asp:Label></b>
                </dt>
                <dd>
                    <asp:Label ID="lblTradeIn" runat="server">
                    </asp:Label>
                </dd>
                <dt id="Dt3" runat="server"><b>
                    <asp:Label ID="lblltrPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</b></dt>
                <dd id="Dd3" runat="server">
                    <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                </dd>
                <dt id="dtalCont" runat="server" style="height: auto;"><b>
                    <%--visible="false"--%>
                    <asp:Label ID="lblltrAlternateNo" runat="server" Text="<%$ Resources:PFSalesResource,HomePhone %>"></asp:Label></b>
                </dt>
                <dd id="ddalCont" runat="server">
                    <asp:Label ID="lblAltContNo" runat="server"></asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrPFAllocationDate" runat="server" Text="<%$ Resources:PFSalesResource,PFAllocationDate %>"></asp:Label></b>
                </dt>
                <dd>
                    <asp:Label ID="lblPFAllocationDate" runat="server">
                    </asp:Label>
                </dd>
                <dt style="height: auto;"><b>
                    <asp:Label ID="lblltrWDHAPF" runat="server" Text="<%$ Resources:PFSalesResource,WhereDidUHear %>"></asp:Label></b>
                </dt>
                <dd style="height: auto;">
                    <asp:Label ID="lblWDHAPF" runat="server">
                    </asp:Label>
                </dd>
            </dl>
            <dl class="ProspDetails" style="margin-bottom: 0px; margin-left: 25px; margin-right: 25px;
                margin-top: 0px;">
                <dt><b>
                    <asp:Label ID="lblltrCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:</b>
                </dt>
                <dd>
                    <asp:Label ID="lblCarMake" runat="server">
                    </asp:Label>
                    <asp:Label ID="lblActualMakeInput" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdfMakeId" runat="server" Value="0" />
                </dd>
                <dt id="Dt4" runat="server" visible="false"><b>
                    <asp:Label ID="lblltrAltEmail" runat="server" Text="<%$ Resources:PFSalesResource,AlternameEmail %>"></asp:Label>:</b>
                </dt>
                <dd id="Dd4" runat="server" visible="false">
                    <asp:Label ID="lblAlterEmail" runat="server"></asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrModel" runat="server" Text="<%$ Resources:PFSalesResource,Model %>"></asp:Label>:</b></dt>
                <dd>
                    <asp:Label ID="lblModel" runat="server"></asp:Label>
                    <asp:Label ID="lblActualModelInput" runat="server"></asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrMobile" runat="server" Text="<%$ Resources:PFSalesResource,MobileNo %>"></asp:Label>:</b>
                </dt>
                <dd>
                    <asp:Label ID="lblMobile" runat="server"></asp:Label><%-- OnClick="lblMobile_Click"--%>
                </dd>
                <dt id="Dt5" runat="server" visible="false"><b>
                    <asp:Label ID="lblltrCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country %>"></asp:Label>:</b></dt>
                <dd id="Dd5" runat="server" visible="false">
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
                <dt id="Dt6" runat="server" visible="false"><b>
                    <asp:Label ID="lblltrAddressLine2" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine2 %>"></asp:Label>:</b></dt>
                <dd id="Dd6" runat="server" visible="false">
                    <asp:Label ID="lblAddLine2" runat="server"></asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrFConsultant" runat="server" Text="<%$ Resources:PFSalesResource,FConsultant %>"></asp:Label></b></dt>
                <dd>
                    <asp:Label ID="lblFConsultant" runat="server"></asp:Label>
                </dd>
                <dt style="min-height: 30px;"><b>
                    <asp:Label ID="lblltrSource" runat="server" Text="<%$ Resources:PFSalesResource,ProspectSrc %>"></asp:Label>:</b>
                </dt>
                <dd style="min-height: 30px;">
                    <asp:Label ID="lblSource" runat="server">
                    </asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrFCStatus" runat="server" Text="<%$ Resources:PFSalesResource,FCStatus %>"></asp:Label></b>
                </dt>
                <dd>
                    <asp:Label ID="lblFCStatus" runat="server">
                    </asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrCreatedDate" runat="server" Text="<%$ Resources:PFSalesResource,EnquiryDate %>"></asp:Label></b>
                </dt>
                <dd>
                    <asp:Label ID="lblEnqDate" runat="server">
                    </asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrComments" runat="server" Text="<%$ Resources:PFSalesResource,Comments %>"></asp:Label></b>
                </dt>
                <dd style="height: auto;">
                    <asp:Label ID="lblComments" runat="server" Style="min-height: 20px;">
                    </asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrFinance" runat="server" Text="<%$ Resources:PFSalesResource,Finance %>"></asp:Label></b>
                </dt>
                <dd>
                    <asp:Label ID="lblFinance" runat="server">
                    </asp:Label>
                </dd>
                <dt id="Dt7" runat="server" visible="false"><b>
                    <asp:Label ID="lblltrNovtedLease" runat="server" Text="<%$ Resources:PFSalesResource,NovatedLease %>">:</asp:Label>
                </b></dt>
                <dd id="Dd7" runat="server" visible="false">
                    <asp:Label ID="lblNovtedLease" runat="server" Text="--"></asp:Label>
                </dd>
                <dt><b>
                    <asp:Label ID="lblltrFCAllocationDate" runat="server" Text="<%$ Resources:PFSalesResource,FCAllocationDate %>"></asp:Label></b>
                </dt>
                <dd>
                    <asp:Label ID="lblFCAllocationDate" runat="server">
                    </asp:Label>
                </dd>
            </dl>
            <asp:Panel ID="pnlFCDetails" runat="server" Visible="false" Style="float: left; width: 100%;
                height: auto;">
                <div class="headText">
                </div>
                <dl class="ProspDetails">
                    <dt><b>
                        <asp:Label ID="lblltrFinanceRequired" runat="server" Text="<%$ Resources:PFSalesResource,FinanceRequired %>"></asp:Label>:</b>
                    </dt>
                    <dd>
                        <asp:Label ID="lblFinanceRequired" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdfFCId" runat="server" Value="0" />
                    </dd>
                    <dt><b>
                        <asp:Label ID="lblltrCreditHistory" runat="server" Text="<%$ Resources:PFSalesResource,CreditHistory %>"></asp:Label>:</b>
                    </dt>
                    <dd>
                        <asp:Label ID="lblCreditHistory" runat="server"></asp:Label>
                    </dd>
                    <dt><b>
                        <asp:Label ID="lblltrEstFin" runat="server" Text="<%$ Resources:PFSalesResource,EstimatedFinance %>"></asp:Label>:</b>
                    </dt>
                    <dd>
                        <asp:Label ID="lblEstFin" runat="server"></asp:Label>
                    </dd>
                    <dt><b>
                        <asp:Label ID="lblltrInitialDeposit" runat="server" Text="<%$ Resources:PFSalesResource,InitialDeposit %>"></asp:Label>:</b>
                    </dt>
                    <dd>
                        <asp:Label ID="lblInitialDeposit" runat="server"></asp:Label>
                    </dd>
                    <dt><b>
                        <asp:Label ID="lblltrEmployment" runat="server" Text="<%$ Resources:PFSalesResource,Employment %>"></asp:Label>:</b>
                    </dt>
                    <dd>
                        <asp:Label ID="lblEmployment" runat="server"></asp:Label>
                    </dd>
                    <dt><b>
                        <asp:Label ID="lblltrCurrentIncome" runat="server" Text="<%$ Resources:PFSalesResource,CurrentIncome %>"></asp:Label>:</b>
                    </dt>
                    <dd>
                        <asp:Label ID="lblCurrentIncome" runat="server"></asp:Label>
                    </dd>
                    <dt style="height: auto"><b>
                        <asp:Label ID="lblltrTimeAtCurAdd" runat="server" Text="<%$ Resources:PFSalesResource,TimeAtCurAdd %>"></asp:Label></b>
                    </dt>
                    <dd style="height: auto">
                        <asp:Label ID="lblTimeAtCurAdd" runat="server"></asp:Label>
                    </dd>
                </dl>
                <dl class="ProspDetails" style="margin-bottom: 0px; margin-left: 25px; margin-right: 25px;
                    margin-top: 0px;">
                    <dt><b>
                        <asp:Label ID="lblltrTermyears" runat="server" Text="<%$ Resources:PFSalesResource,Termyears %>"></asp:Label>:</b>
                    </dt>
                    <dd>
                        <asp:Label ID="lblTermyears" runat="server"></asp:Label>
                    </dd>
                    <dt><b>
                        <asp:Label ID="lblltrResidualBallonPaymen" runat="server" Text="<%$ Resources:PFSalesResource,ResidualBallonPaymen %>"></asp:Label>:</b>
                    </dt>
                    <dd>
                        <asp:Label ID="lblResidualBallonPaymen" runat="server"></asp:Label>
                    </dd>
                    <dt style="height: auto;"><b>
                        <asp:Label ID="lblltrMessage" runat="server" Text="<%$ Resources:PFSalesResource,Message %>"></asp:Label>:</b>
                    </dt>
                    <dd style="height: auto; min-height: 20px;">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </dd>
                    <dt><b>
                        <asp:Label ID="lblltrEmployer" runat="server" Text="<%$ Resources:PFSalesResource,Employer %>"></asp:Label>:</b>
                    </dt>
                    <dd>
                        <asp:Label ID="lblEmployer" runat="server"></asp:Label>
                    </dd>
                    <dt style="height: auto"><b>
                        <asp:Label ID="lblltrTimeinCurEmp" runat="server" Text="<%$ Resources:PFSalesResource,TimeinCurEmp %>"></asp:Label></b>
                    </dt>
                    <dd style="height: auto">
                        <asp:Label ID="lblTimeinCurEmp" runat="server"></asp:Label>
                    </dd>
                    <dt id="Dt8" runat="server" visible="false"><b>
                        <asp:Label ID="lblltrFinFrom" runat="server" Text="<%$ Resources:PFSalesResource,FinanceRequestFrom %>"></asp:Label></b>
                    </dt>
                    <dd id="Dd8" runat="server" visible="false">
                        <asp:Label ID="lblFinFrom" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdfFinLeadTypeID" runat="server" Value="" />
                    </dd>
                </dl>
            </asp:Panel>
            <asp:Panel ID="pnlSendMail" runat="server" Visible="false">
                <div class="pop-up" style="z-index: 10025;">
                </div>
                <div class="contentPopUp" style="z-index: 10030; margin-left: -85%; top: 2%; width: 68%;">
                    <div class="popHeader">
                        <asp:Label ID="lblSendMail" runat="server" Text="<%$ Resources:PFSalesResource,SendUnabletoContact%>"></asp:Label>
                        <asp:LinkButton ID="lnkbtnSendMailClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                            OnClick="lnkbtnSendMailClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                    </div>
                    <dl id="dlSendMail" runat="server" style="width: 100%; float: left; padding: 10px;">
                        <dt style="width: 95%; float: left; padding-bottom: 10px;">
                            <Edit:Editor ID="EdSendEmail" runat="server" Width="100%" Height="475px" InitialCleanUp="true" />
                            <dd>
                            </dd>
                            <dt>
                                <div class="button" style="float: left;">
                                    <asp:LinkButton ID="lnkbtnSendEmail" runat="server" 
                                        OnClick="lnkbtnSendEmail_Click" 
                                        Text="<%$ Resources:PFSalesResource,SendEmail %>" 
                                        ToolTip="<%$ Resources:PFSalesResource,SendEmail %>" 
                                        ValidationGroup="SendEmail"></asp:LinkButton>
                                </div>
                            </dt>
                            <dd>
                            </dd>
                        </dt>
                    </dl>
                </div>
            </asp:Panel>
        </div>
    </div>
    <div class="button">
        <asp:LinkButton ID="lnkbtnEditContact" runat="server" Text="<%$ Resources:PFSalesResource,EditContact %>"
            ToolTip="<%$ Resources:PFSalesResource,Editprosp %>" OnClick="lnkbtnEditContact_Click"></asp:LinkButton>
        <asp:LinkButton ID="lnkbtnSendUnableToConMail" runat="server" Text="<%$ Resources:PFSalesResource,UnabletoContact %>"
            ToolTip="<%$ Resources:PFSalesResource,SendUnabletoContact %>" OnClick="lnkbtnSendUnableToConMail_Click"></asp:LinkButton>
        <asp:LinkButton ID="lnkbtnAddNewContact" Visible="false" runat="server" Text="<%$ Resources:PFSalesResource,AddContact %>"
            ToolTip="<%$ Resources:PFSalesResource,AddContact %>" OnClick="lnkbtnAddNewContact_Click"></asp:LinkButton>
        <asp:LinkButton ID="lnkbtnReferToFinance" runat="server" Visible="false" Text="<%$ Resources:PFSalesResource,Refertofinance %>"
            ToolTip="<%$ Resources:PFSalesResource,SetFinanceRequiredForContact %>" OnClick="lnkbtnReferToFinance_Click"></asp:LinkButton>
        <asp:HyperLink ID="lnkCreateQuote" runat="server" Visible="false" Text="<%$ Resources:PFSalesResource,CreateQuote %>"
            ToolTip="<%$ Resources:PFSalesResource,SetFinanceRequiredForContact %>"></asp:HyperLink>
        <%-- <asp:LinkButton ID="lnkCreateQuote" runat="server" Visible="false" Text="<%$ Resources:PFSalesResource,CreateQuote %>"
            ToolTip="<%$ Resources:PFSalesResource,SetFinanceRequiredForContact %>" OnClick="lnkCreateQuote_Click"></asp:LinkButton>--%>
        <asp:LinkButton ID="lnkbtnSMSSend" runat="server" Text="<%$ Resources:PFSalesResource,SendSMSHeader %>"
            ToolTip="<%$ Resources:PFSalesResource,SendSMSHeader %>" OnClick="lnkbtnSMSSend_Click"></asp:LinkButton>
        <asp:HyperLink ID="hplnkbtnSearchCar" runat="server" ToolTip="Search Car"></asp:HyperLink>
        <asp:LinkButton ID="lnkbtnTradeIn" runat="server" Text="<%$ Resources:PFSalesResource,TradeIn %>"
            ToolTip="<%$ Resources:PFSalesResource,TradeIn %>" OnClick="lnkbtnTradeIn_Click"></asp:LinkButton>
        <asp:LinkButton ID="lblprintsss" runat="server" OnClientClick="return PrintPanel();"
            Text="Print"></asp:LinkButton>
        <asp:LinkButton ID="lblChooseQuote" runat="server" OnClick="lnkbtnChooseQuote_Click"
            Text="Choose Quote"></asp:LinkButton>
        <asp:LinkButton ID="lblCreateContract" runat="server" OnClick="lnkbtnCreateContract_Click"
            Text="Create Contract" Visible="false"></asp:LinkButton>
    </div>
    <asp:LinkButton ID="lnkViewQuoteRequest" runat="server" Visible="false" Text="<%$ Resources:PFSalesResource,ViewQuoteRequest %>"
        ToolTip="<%$ Resources:PFSalesResource,SetFinanceRequiredForContact %>" OnClick="lnkViewQuoteRequest_Click"></asp:LinkButton>
    <div class="headText">
    </div>
    <asp:Panel ID="pnlAddContact" runat="server" Visible="false">
        <div class="pop-up" style="z-index: 10025;">
        </div>
        <div class="contentPopUp" style="z-index: 10030; margin-left: -88%; top: 1%; width: 77%;">
            <asp:Panel ID="pnlAConHead" runat="server">
                <div class="popHeader">
                    <asp:Label ID="lblAddContactHead" runat="server" Text="<%$ Resources:PFSalesResource,AddProspectDetails%>"></asp:Label>
                    <asp:LinkButton ID="lnkbtnAddContactClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                        OnClick="lnkbtnAddContactClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                </div>
            </asp:Panel>
            <div style="overflow-y: scroll; height: 550px; width: 100%">
                <uc1:AddEditContact ID="UC_AddEditContact1" runat="server" />
            </div>
        </div>
    </asp:Panel>
    <ajax:DragPanelExtender ID="dpeContact" runat="server" TargetControlID="pnlAddContact"
        DragHandleID="pnlAConHead" BehaviorID="DragPCon">
    </ajax:DragPanelExtender>
    <asp:Panel ID="pnlReftoFinance" runat="server" Visible="false">
        <div class="pop-up" style="z-index: 10025;">
        </div>
        <div class="contentPopUp" style="z-index: 10030; margin-left: -68%; top: 33%;">
            <div class="popHeader">
                <asp:Label ID="lblReferToFinHead" runat="server" Text="<%$ Resources:PFSalesResource,Refertofinance%>"></asp:Label>
                <asp:LinkButton ID="lnkbtnCloaseReferToFin" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                    OnClick="lnkbtnCloaseReferToFin_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
            </div>
            <div style="width: 100%; height: 200px; padding: 10px;">
                <dl style="width: 100%">
                    <dt style="height: auto; padding: 10px; width: 20%;">
                        <asp:Label ID="lblFinRemark" runat="server" Text="<%$ Resources:PFSalesResource,Remark%>"></asp:Label>
                    </dt>
                    <dd style="height: auto; padding: 10px; width: 70%; float: right;">
                        <asp:TextBox ID="txtFCNotes" runat="server" CssClass="inputClass" TextMode="MultiLine"
                            Rows="4" MaxLength="500" Width="240px" Style="height: auto;"></asp:TextBox>
                    </dd>
                    <dt style="padding: 10px;">
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSavetoFC" runat="server" Text="<%$ Resources:PFSalesResource,Save%>"
                                ToolTip="<%$ Resources:PFSalesResource,Save%>" OnClick="lnkbtnSavetoFC_Click"></asp:LinkButton>
                        </div>
                    </dt>
                </dl>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlSendSmS" runat="server" Visible="false">
        <%-- --%>
        <div class="pop-up" style="z-index: 10025;">
        </div>
        <div class="contentPopUp" style="z-index: 10030; width: 62%; left: 90%; top: 15%;">
            <%--class="contentPopUp"--%>
            <asp:Panel ID="dvSmsHead" runat="server">
                <div class="popHeader">
                    <asp:Label ID="lblSendSMSHead" runat="server" Text="<%$ Resources:PFSalesResource,SendSMSHeader%>"></asp:Label>
                    <asp:LinkButton ID="lnkbtnSendSmsClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                        OnClick="lnkbtnSendSmsClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                </div>
            </asp:Panel>
            <dl id="dl1" runat="server" style="width: 100%; float: left; padding-left: 10px;">
                <dt style="float: left;">
                    <label>
                        *</label><asp:Label ID="lblSmSMobNumb" runat="server" Text="<%$ Resources:PFSalesResource,MobileNo%>"></asp:Label>
                </dt>
                <dd style="float: left;">
                    <asp:TextBox ID="txtSmsMobNum" runat="server" CssClass="inputClass" MaxLength="10"></asp:TextBox>
                    <ajax:FilteredTextBoxExtender ID="fteSmsMobNo" runat="server" TargetControlID="txtSmsMobNum"
                        FilterMode="ValidChars" ValidChars="0123456789">
                    </ajax:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="rfvSenSmsMobNo" runat="server" ControlToValidate="txtSmsMobNum"
                        SetFocusOnError="true" ValidationGroup="SendSMS" Display="None" ErrorMessage="<%$ Resources:PFSalesResource,MobileNoVal%>"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="vceSmsMobNum" runat="server" TargetControlID="rfvSenSmsMobNo"
                        PopupPosition="TopLeft">
                    </ajax:ValidatorCalloutExtender>
                    <asp:CustomValidator ID="CVSmsNo" runat="server" ControlToValidate="txtSmsMobNum"
                        ClientValidationFunction="checkvalidMobNo" Display="None" ValidationGroup="SendSMS"
                        ErrorMessage="<%$ Resources:PFSalesResource,SmsMobNumVal %>" EnableClientScript="true"
                        ValidateEmptyText="false" SetFocusOnError="true"></asp:CustomValidator>
                    <ajax:ValidatorCalloutExtender ID="vceSmsNo" runat="server" TargetControlID="CVSmsNo"
                        PopupPosition="BottomRight">
                    </ajax:ValidatorCalloutExtender>
                </dd>
            </dl>
            <dl id="dl4" runat="server" style="width: 100%; float: left; padding-left: 10px;">
                <dt style="float: left;">
                    <asp:Label ID="lbltrlSendSMS" runat="server" Text="<%$ Resources:PFSalesResource,SMSText%>"></asp:Label>
                </dt>
                <dd style="height: auto; float: left;">
                    <asp:TextBox ID="txtSMS" runat="server" CssClass="inputClass" TextMode="MultiLine"
                        Style="height: auto;" Rows="6" Width="300px"></asp:TextBox>
                    <br />
                    Message (<asp:Label ID="lblSMS" runat="server" Text="160"></asp:Label>)
                </dd>
            </dl>
            <dl id="dl3" runat="server" style="width: 100%; float: left; padding-left: 10px;">
                <dt style="float: left; padding: 10px"></dt>
                <dd>
                    <asp:RadioButtonList RepeatDirection="Vertical" Width="500px" ID="radioPreset" AutoPostBack="true"
                        TextAlign="Right" runat="server" OnSelectedIndexChanged="radioPreset_SelectedIndexChanged">
                        <asp:ListItem Value="1" Text="Hi when you get a chance could you pls give me a call?"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Hi just tried 2 call re ur new car but couldn’t get through. Pls call when u get a chance"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Hi ***, Paperwork has been sent to you to confirm your *** purchase, please call *** on 1300 303 181 ext"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RadioButtonList RepeatDirection="Vertical" Width="500px" ID="radiobtnlstFC"
                        AutoPostBack="true" TextAlign="Right" runat="server" OnSelectedIndexChanged="radiobtnlstFC_SelectedIndexChanged"
                        Visible="false">
                        <asp:ListItem Value="1" Text="Hi when you get a chance could you pls give me a call?"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Hi just tried 2 call re car finance but couldn’t get through. Pls call when u get a chance"></asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
            </dl>
            <dl id="dl2" runat="server" style="width: 100%; float: left;">
                <dt></dt>
                <dd>
                    <div class="button" style="float: left;">
                        <asp:LinkButton ID="lnkbtnSendSMS" runat="server" ValidationGroup="SendSMS" OnClick="lnkbtnSendSMS_Click"
                            Text="<%$ Resources:PFSalesResource,SendSMSHeader %>" ToolTip="<%$ Resources:PFSalesResource,SendSMSHeader %>"></asp:LinkButton>
                    </div>
                </dd>
            </dl>
        </div>
    </asp:Panel>
    <ajax:DragPanelExtender ID="dpeSMS" runat="server" TargetControlID="pnlSendSmS" DragHandleID="dvSmsHead"
        BehaviorID="slider">
    </ajax:DragPanelExtender>
</div>
<asp:HiddenField ID="hdfConsultPhone" runat="server" Value="" />
<asp:HiddenField ID="hdfConsultExt" runat="server" Value="" />
<%--   </ContentTemplate>
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
</asp:UpdateProgress>--%>
