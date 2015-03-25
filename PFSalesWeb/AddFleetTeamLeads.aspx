<%@ Page Title="Add Fleet Team Leads" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="AddFleetTeamLeads.aspx.cs" Inherits="AddFleetTeamLeads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanPrspect" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlAddProsp" runat="server" DefaultButton="lnkbtnSave">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="lblAddProspHead" runat="server" Text="<%$Resources:PFSalesResource,AddProspectDetails %>"></asp:Label>
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
                        <dt id="Dt1" runat="server" visible="false">
                            <asp:Label ID="lblAddMname" runat="server" Text="<%$Resources:PFSalesResource,MName %>"></asp:Label>:
                        </dt>
                        <dd id="Dd1" runat="server" visible="false">
                            <asp:TextBox ID="txtMName" CssClass="inputClass" runat="server" MaxLength="50"></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblAddLName" runat="server" Text="<%$Resources:PFSalesResource,LName %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtLName" CssClass="inputClass" TabIndex="3" runat="server" MaxLength="50"></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCarMake" TabIndex="5" AutoPostBack="true" OnSelectedIndexChanged="ddlCarMake_SelectedIndexChanged"
                                CssClass="selectClass" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblActualMakeInput" runat="server"></asp:Label>
                        </dd>
                        <dt>
                            <asp:Label ID="lblUsed" runat="server" Text="<%$ Resources:PFSalesResource,NewOrUsed %>"></asp:Label>
                        </dt>
                        <dd>
                            <asp:RadioButton ID="rbtnNew" CssClass="allchklist" runat="server" TabIndex="7" Text="<%$ Resources:PFSalesResource,New %>"
                                Checked="true" GroupName="NewOrUsed" />
                            <asp:RadioButton ID="rbtnUsed" runat="server" CssClass="allchklist" TabIndex="8"
                                Text="<%$ Resources:PFSalesResource,Used %>" GroupName="NewOrUsed" />
                        </dd>
                        <dt>
                            <label>
                                *</label><asp:Label ID="lblEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailId %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmail1" CssClass="inputClass" TabIndex="10" runat="server" MaxLength="250"></asp:TextBox>
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
                        <dt>
                            <asp:Label ID="lblPhoneNo" runat="server" Text="<%$ Resources:PFSalesResource,PhoneNo %>"></asp:Label>:
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
                        </dd>
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
                        <dt>
                            <asp:Label ID="lblState" runat="server" Text="<%$ Resources:PFSalesResource,State %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlState" CssClass="selectClass" TabIndex="15" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <%--<label>
                                *</label>--%>
                            <asp:Label ID="lblCity" runat="server" Text="<%$ Resources:PFSalesResource,City %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCity" TabIndex="17" CssClass="selectClass" Style="float: left;"
                                Width="160 px" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnCityPop" runat="server" OnClick="lnkbtnCityPop_Click">....</asp:LinkButton></div>
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
                        <dt>
                            <asp:Label ID="lblFinance" runat="server" Text="<%$ Resources:PFSalesResource,Finance %>"></asp:Label>:</dt>
                        <dd>
                            <asp:DropDownList ID="ddlFinance" CssClass="selectClass" TabIndex="19" runat="server">
                                <%--AutoPostBack="true" OnSelectedIndexChanged="ddlFinance_SelectedIndexChanged"--%>
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblConsultant" runat="server" Text="<%$ Resources:PFSalesResource,Consultant %>"></asp:Label>:</dt>
                        <dd>
                            <asp:DropDownList ID="ddlConsultant" CssClass="selectClass" Enabled="false" TabIndex="21"
                                runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdfConsultID" runat="server" Value="0" />
                        </dd>
                        <dt>
                            <label>
                                *</label><asp:Label ID="lblSource" runat="server" Text="<%$ Resources:PFSalesResource,ProspectSrc %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSource" CssClass="selectClass" TabIndex="23" runat="server">
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
                            <%-- visible="false"--%>
                            <asp:Label ID="lblAlternateNo" runat="server" Text="<%$ Resources:PFSalesResource,AlternateContNo %>"></asp:Label>
                        </dt>
                        <dd id="ddalCont" runat="server">
                            <%--visible="false"--%>
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
                        <dt>
                            <%--<label>
                                *</label>--%>
                            <asp:Label ID="lblMemberNo" runat="server" Text="<%$ Resources:PFSalesResource,MemberNo %>"></asp:Label>:</dt>
                        <dd>
                            <asp:TextBox ID="txtMemNo" CssClass="inputClass" TabIndex="4" runat="server" MaxLength="50"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvMemNo" runat="server" ControlToValidate="txtMemNo"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,MemNoVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceMomNo" runat="server" TargetControlID="rfvMemNo"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%>
                        </dd>
                        <dt>
                            <asp:Label ID="lblModel" runat="server" Text="<%$ Resources:PFSalesResource,Model %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlModel" TabIndex="6" CssClass="selectClass" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblActualModelInput" runat="server"></asp:Label>
                        </dd>
                        <dt>
                            <asp:Label ID="lblWhereDidUHear" runat="server" Text="<%$ Resources:PFSalesResource,WhereDidUHearabtPF %>"></asp:Label></dt>
                        <dd>
                            <asp:DropDownList ID="ddlWhereDidUHear" CssClass="selectClass" TabIndex="9" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlWhereDidUHear_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
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
                            <asp:TextBox ID="txtMobile" CssClass="inputClass" TabIndex="11" MaxLength="20" Width="160"
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
                        <dt>
                            <asp:Label ID="lblCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country %>"></asp:Label>:</dt>
                        <dd>
                            <asp:DropDownList ID="ddlCountry" CssClass="selectClass" TabIndex="14" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</dt>
                        <dd>
                            <asp:DropDownList ID="ddlPostalCode" TabIndex="16" CssClass="selectClass" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlPostalCode_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="txtPostalCode" CssClass="inputClass" TabIndex="21" runat="server"
                                MaxLength="10"></asp:TextBox>--%>
                            <%--   <ajax:FilteredTextBoxExtender ID="ftePostalCode" runat="server" TargetControlID="txtPostalCode"
                                FilterType="Custom" ValidChars="0123456789">
                            </ajax:FilteredTextBoxExtender>--%>
                            <%--   <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputClass" TabIndex="16"
                                MaxLength="4" Visible="false"></asp:TextBox>
                            <ajax:AutoCompleteExtender ID="acePostalCode" runat="server" ServicePath="~/GetAllPcodes.asmx"
                                ServiceMethod="GetPcodeList" TargetControlID="txtPostalCode" MinimumPrefixLength="1">
                            </ajax:AutoCompleteExtender>
                            <ajax:FilteredTextBoxExtender ID="ftePostalCode" runat="server" TargetControlID="txtPostalCode"
                                FilterType="Custom" ValidChars="0123456789">
                            </ajax:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="rfvPCode" runat="server" ControlToValidate="txtPostalCode"
                                Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,PCodeVal %>"
                                SetFocusOnError="true" Enabled="false"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vcePCode" runat="server" TargetControlID="rfvPCode"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>--%>
                        </dd>
                        <dt>
                            <asp:Label ID="lblAddressLine1" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine1 %>"></asp:Label>:</dt>
                        <dd>
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
                        <dt>
                            <asp:Label ID="lblFConsultant" runat="server" Text="<%$ Resources:PFSalesResource,FConsultant %>"></asp:Label></dt>
                        <dd>
                            <asp:TextBox ID="txtFConsultant" runat="server" CssClass="inputClass" MaxLength="150"
                                Visible="false"></asp:TextBox>
                            <asp:DropDownList ID="ddlFConsultant" runat="server" CssClass="selectClass" Enabled="false"
                                TabIndex="20">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdfFConsultID" runat="server" Value="0" />
                        </dd>
                        <dt>
                            <asp:Label ID="lblAddStatus" runat="server" Text="<%$ Resources:PFSalesResource,Status %>"></asp:Label>:</dt>
                        <dd>
                            <asp:DropDownList ID="ddlAddStatus" CssClass="selectClass" TabIndex="22" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblRefferedBy" runat="server" Text="<%$ Resources:PFSalesResource,ReferredBy %>"></asp:Label></dt>
                        <dd>
                            <asp:TextBox ID="txtReferredBy" runat="server" TabIndex="24" CssClass="inputClass"
                                MaxLength="250"></asp:TextBox>
                        </dd>
                        <dt style="height: auto">
                            <asp:Label ID="lblComment" runat="server" Text="<%$ Resources:PFSalesResource,Comments %>"></asp:Label></dt>
                        <dd style="height: auto">
                            <asp:TextBox ID="txtComments" runat="server" TabIndex="26" TextMode="MultiLine" Style="height: auto"
                                Rows="4" CssClass="inputClass" MaxLength="1000"></asp:TextBox>
                        </dd>
                    </dl>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnSave" runat="server" TabIndex="43" Text="<%$ Resources:PFSalesResource,Save %>"
                            ToolTip="<%$ Resources:PFSalesResource,SaveEmployee %>" OnClick="lnkbtnSave_Click"
                            ValidationGroup="SaveContact"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnFinalClear" runat="server" Text="<%$ Resources:PFSalesResource,Clear %>"
                            ToolTip="<%$ Resources:PFSalesResource,Clear %>" TabIndex="44" CausesValidation="false"
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
            <asp:Panel ID="pnlPostalCityPopUp" runat="server" Visible="false">
                <div class="pop-up">
                </div>
                <div class="contentPopUp">
                    <div class="popHeader">
                        <asp:Label ID="lblCityPopUpHead" runat="server" Text="<%$ Resources:PFSalesResource,EnterCity%>"></asp:Label>
                        <asp:LinkButton ID="lnkbtnCityPopClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                            OnClick="lnkbtnCityPopClose_Click"><img src="Images/delet.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                    </div>
                    <div class="dilContenerTwo">
                        <dl class="settled">
                            <dt>
                                <asp:Label ID="lblStateCityPop" runat="server" Text="<%$Resources:PFSalesResource,State %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlStateCityPop" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvStateCityPop" runat="server" ControlToValidate="ddlStateCityPop"
                                    ValidationGroup="CityPopUp" Display="None" SetFocusOnError="true" InitialValue="0"
                                    ErrorMessage="<%$Resources:PFSalesResource,StateVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceStateCityPop" runat="server" TargetControlID="rfvStateCityPop"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPostalCodePop" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode%>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtPostalPopup" CssClass="inputClass" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtPostalPop" runat="server" ControlToValidate="txtPostalPopup"
                                    ValidationGroup="CityPopUp" Display="None" SetFocusOnError="true" InitialValue="0"
                                    ErrorMessage="<%$Resources:PFSalesResource,PCodeVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcetxtPostalPop" runat="server" TargetControlID="rfvtxtPostalPop"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="cvtxtPostalPop" runat="server" Operator="DataTypeCheck"
                                    Type="Integer" ControlToValidate="txtPostalPopup" ErrorMessage="<%$Resources:PFSalesResource,NumValue %>" />
                                <ajax:ValidatorCalloutExtender ID="vcetxtPostalPop2" runat="server" TargetControlID="cvtxtPostalPop"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblCityPop" runat="server" Text="<%$Resources:PFSalesResource,City %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtCityPopup" CssClass="inputClass" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtCityPop" runat="server" ControlToValidate="txtCityPopup"
                                    ValidationGroup="CityPopUp" Display="None" SetFocusOnError="true" InitialValue="0"
                                    ErrorMessage="<%$Resources:PFSalesResource,EnterCity %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcetxtCityPop" runat="server" TargetControlID="rfvtxtCityPop"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnCityPoUpEdit" runat="server" Text="<%$Resources:PFSalesResource,EditFormats %>"
                                ToolTip="<%$Resources:PFSalesResource,EditFormatToolTip %>" Visible="false"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnCityPoUpSave" runat="server" Text="<%$Resources:PFSalesResource,Save %>"
                                ToolTip="<%$Resources:PFSalesResource,OK %>" ValidationGroup="CityPopUp" OnClick="lnkbtnCityPoUpSave_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnCityPoUpClose" runat="server" Text="<%$Resources:PFSalesResource,Cancel %>"
                                ToolTip="<%$Resources:PFSalesResource,Close %>" OnClick="lnkbtnCityPoUpClose_Click"></asp:LinkButton></div>
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
