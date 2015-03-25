<%@ Page Title="<%$Resources:PFSalesResource,DealerMaster %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="Dealer.aspx.cs" Inherits="Dealer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanPrspect" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlSearchDealer" runat="server" DefaultButton="lnkbtnSearch">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="SearchDealerHead" runat="server" Text="<%$Resources:PFSalesResource,SearchDealer %>"></asp:Label>
                    <div class="addBtn">
                        <asp:LinkButton ID="lnkbtnAddDealer" runat="server" ToolTip="<%$Resources:PFSalesResource,AddDealer %>"
                            OnClick="lnkbtnAddDealer_Click">
                            <asp:Image ID="imgAddDealer" ImageUrl="~/Images/add.png" runat="server" />
                            <asp:Label ID="lblAddDealer" runat="server" Text="<%$Resources:PFSalesResource,AddDealer %>"> </asp:Label></asp:LinkButton>
                    </div>
                </div>
                <div class="dilContener">
                    <div class="error" id="dvsererror" runat="server" visible="false">
                        <asp:Label ID="lblSerErrMsg" runat="server"></asp:Label>
                    </div>
                    <div class="success" id="dvaserSuccess" runat="server" visible="false">
                        <asp:Label ID="lblSerSucMsg" runat="server"></asp:Label>
                    </div>
                    <dl class="dealerRagisterTwo">
                        <dt>
                            <asp:Label ID="lblDealerName" runat="server" Text="<%$Resources:PFSalesResource,Name %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtserDealerName" CssClass="inputClass" MaxLength="160" runat="server"></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblMake" runat="server" Text="<%$Resources:PFSalesResource,CarMake %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCarMake" CssClass="selectClass" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlCarMake_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:PFSalesResource,company %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtserCompany" CssClass="inputClass" MaxLength="160" runat="server"></asp:TextBox>
                        </dd>
                    </dl>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                            ToolTip="<%$Resources:PFSalesResource,SearchDealer %>" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                            ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                    </div>
                    <div style="float: left; width: 100%; margin-top: 10px;">
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
                                <asp:ListItem Value="1" Text="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <asp:GridView ID="gvDealer" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                        border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                        AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                        PageSize="50" OnPageIndexChanging="gvDealer_PageIndexChanging" OnSorting="gvDealer_Soring"
                        OnRowDataBound="gvDealer_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDealerName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmailId %>" SortExpression="EmailId">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmailId" runat="server" Text='<%#Bind("EmailId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,MobileNo %>" SortExpression="MobileNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%#Bind("MobileNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PostalCode %>" SortExpression="PosptalCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosptalCode" runat="server" Text='<%#Bind("PosptalCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Company %>" SortExpression="Company">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany" runat="server" Text='<%#Bind("Company") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,AddDuplicate %>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnDuplicate" runat="server" ToolTip="<%$Resources:PFSalesResource,AddDuplicateDealer %>"
                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnDuplicate_Click">
                                        <div style ="text-align :center; width:100%"><img src="Images/duplicate.png" /></div>
                                    
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Edit %>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="<%$Resources:PFSalesResource,EditDealer %>"
                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnEdit_Click">
                                    <img src="Images/edit.png"/>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Delete %>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnDelete" runat="server" ToolTip="<%$Resources:PFSalesResource,DeleteDealer %>"
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
            <asp:Panel ID="pnlAddDealer" runat="server" Visible="false" DefaultButton="lnkbtnSave">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="lblAddDealerHead" runat="server" Text="<%$Resources:PFSalesResource,AddDealerDetails %>"></asp:Label>
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
                    <div class="success" id="dvaddSucc" runat="server" visible="false">
                        <asp:Label ID="lblAddSucMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <dl class="dealerRagisterThree">
                        <dt>
                            <label>
                                *</label><asp:Label ID="lblAddFName" runat="server" Text="<%$Resources:PFSalesResource,FName %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtFName" CssClass="inputClass" TabIndex="1" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFName" runat="server" ControlToValidate="txtFName"
                                Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,FNameVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceFName" runat="server" TargetControlID="rfvFName"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt>
                            <label>
                                *</label><asp:Label ID="lblPhoneNo" runat="server" Text="<%$ Resources:PFSalesResource,PhoneNo %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtPhNo" CssClass="inputClass" TabIndex="3" Width="160" MaxLength="20"
                                runat="server"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="ftePhNo" runat="server" TargetControlID="txtPhNo"
                                FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:MaskedEditExtender ID="msePhNo" runat="server" TargetControlID="txtPhNo" BehaviorID="MEE"
                                MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                                ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnPhPopUp" runat="server" TabIndex="4" OnClick="lnkbtnPhPopUp_Click">....</asp:LinkButton>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhNo"
                                Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,PhoneNoVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vcePhone" runat="server" TargetControlID="rfvPhone"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt>
                            <asp:Label ID="lblFax" runat="server" Text="<%$ Resources:PFSalesResource,Fax %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtFax" CssClass="inputClass" TabIndex="7" MaxLength="30" Width="160"
                                runat="server"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="fteFax" runat="server" TargetControlID="txtFax"
                                FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:MaskedEditExtender ID="mseFax" runat="server" TargetControlID="txtFax" BehaviorID="MEE2"
                                MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                                ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnFax" runat="server" TabIndex="8" OnClick="lnkbtnFax_Click">....</asp:LinkButton></div>
                        </dd>
                        <dt>
                            <%-- <label>
                                *</label><asp:Label ID="lblCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country %>" Visible="false"></asp:Label>:--%>
                            <asp:Label ID="lblAddressLine1" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine1 %>"></asp:Label></dt>
                        <dd>
                            <asp:TextBox ID="txtAddLine1" runat="server" TabIndex="10" CssClass="inputClass"
                                MaxLength="500"></asp:TextBox>
                            <asp:DropDownList ID="ddlCountry" CssClass="selectClass" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" Visible="false">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                                InitialValue="0" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,CountryVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceCountry" runat="server" TargetControlID="rfvCountry"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt>
                            <label>
                                *</label><asp:Label ID="lblPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</dt>
                        <dd>
                            <asp:DropDownList ID="ddlPostalCode" TabIndex="12" CssClass="selectClass" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlPostalCode_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="ddlPostalCode"
                                Display="None" InitialValue="0" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,PostalVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vcePostalCode" runat="server" TargetControlID="rfvPostalCode"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt>
                            <asp:Label ID="lblSecState" runat="server" Text="<%$ Resources:PFSalesResource,SecState %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSecState" CssClass="selectClass" TabIndex="14" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblCompany" runat="server" Text="<%$ Resources:PFSalesResource,Company %>"></asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtCompany" runat="server" TabIndex="16" CssClass="inputClass" MaxLength="200"></asp:TextBox>
                        </dd>
                        <dt style="height: auto;">
                            <label>
                                *</label><asp:Label ID="lblCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:
                        </dt>
                        <dd style="height: auto;">
                            <%--<asp:ListBox ID="lstCarMake" TabIndex="18" SelectionMode="Multiple" CssClass="selectClass"
                                runat="server" Style="height: auto;">
                                <asp:ListItem Value="0" Selected="True" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:ListBox>--%>
                            <asp:DropDownList ID="ddlCarMake1" TabIndex="18" CssClass="selectClass" runat="server">
                                <asp:ListItem Value="0" Selected="True" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCarMake" runat="server" ControlToValidate="ddlCarMake1"
                                InitialValue="0" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,CarMakeVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceCarMake" runat="server" TargetControlID="rfvCarMake"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                    </dl>
                    <dl class="dealerRagisterThree">
                        <dt>
                            <asp:Label ID="lblAddLName" runat="server" Text="<%$Resources:PFSalesResource,LName %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtLName" CssClass="inputClass" TabIndex="2" runat="server" MaxLength="50"></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblMobile" runat="server" Text="<%$ Resources:PFSalesResource,MobileNo %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtMobile" CssClass="inputClass" TabIndex="5" MaxLength="20" Width="160"
                                runat="server"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="fteMobile" runat="server" TargetControlID="txtMobile"
                                FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:MaskedEditExtender ID="mseMobile" runat="server" TargetControlID="txtMobile"
                                BehaviorID="MEE4" MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                                ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                            <div class="popUpViewBtn">
                                <asp:LinkButton ID="lnkbtnMobile" runat="server" TabIndex="6" OnClick="lnkbtnMobile_Click">....</asp:LinkButton></div>
                        </dd>
                        <dt>
                            <label>
                                *</label><asp:Label ID="lblEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailId %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmail1" CssClass="inputClass" TabIndex="9" runat="server" MaxLength="250"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail1"
                                Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,EmailVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="rfvEmail"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="revtxtEmailId" runat="server" ErrorMessage="<%$ Resources:PFSalesResource, invalidemail %>"
                                ControlToValidate="txtEmail1" SetFocusOnError="true" Display="None" ValidationGroup="Save"
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
                            <label>
                                *</label>
                            <asp:Label ID="lblState" runat="server" Text="<%$ Resources:PFSalesResource,State %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlState" CssClass="selectClass" TabIndex="11" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                                InitialValue="0" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,StateVal %>"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="rfvState"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                        <dt>
                            <asp:Label ID="lblCity" runat="server" Text="<%$ Resources:PFSalesResource,City %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCity" TabIndex="13" CssClass="selectClass" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt style="height: auto">
                            <asp:Label ID="lblNotes" runat="server" Text="<%$ Resources:PFSalesResource,Notes %>"></asp:Label>:
                        </dt>
                        <dd style="height: auto">
                            <asp:TextBox ID="txtNotes" runat="server" CssClass="inputClass" Rows="4" TabIndex="15"
                                TextMode="MultiLine" Style="height: auto"></asp:TextBox>
                        </dd>
                    </dl>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnSave" runat="server" TabIndex="19" Text="<%$ Resources:PFSalesResource,Save %>"
                            ToolTip="<%$ Resources:PFSalesResource,SaveEmployee %>" OnClick="lnkbtnSave_Click"
                            ValidationGroup="Save" OnClientClick="javascript:return TestCheckBox();"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnFinalClear" TabIndex="20" runat="server" Text="<%$ Resources:PFSalesResource,Clear %>"
                            ToolTip="<%$ Resources:PFSalesResource,Clear %>" CausesValidation="false" OnClick="lnkbtnFinalClear_Click"></asp:LinkButton>
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
       </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproDealer" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpPanPrspect">
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
