<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_AddEditContact.ascx.cs"
    Inherits="UserControls_AddEditContact" %>
<asp:UpdatePanel ID="UpPanPrspect" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlSearchprosp" runat="server" Visible="false">
            <div class="innerHeader">
                <img src="images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,SearchProspect %>"></asp:Label>
                <div class="addBtn">
                    <asp:LinkButton ID="lnkbtnAddprosp" runat="server" ToolTip="<%$Resources:PFSalesResource,ProspectList %>"
                        OnClick="lnkbtnAddprosp_Click">
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
                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                            <asp:ListItem Value="25" Text="25" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="50" Text="50"></asp:ListItem>
                            <asp:ListItem Value="100" Text="100"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <asp:GridView ID="gvprosp" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                    border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                    AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                    PageSize="25" OnPageIndexChanging="gvprosp_PageIndexChanging" OnSorting="gvprosp_Soring"
                    OnRowDataBound="gvprosp_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,status %>" SortExpression="status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                <asp:HiddenField ID="hdfFinance" runat="server" Value='<%#Bind("Finance") %>' />
                                <asp:HiddenField ID="hdfIsFleetTeamLead" runat="server" Value='<%#Bind("IsFleetLead") %>' />
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
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Edit %>">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="<%$Resources:PFSalesResource,Editprosp %>"
                                    CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnEdit_Click">
                                    <img src="Images/edit.png"/>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Delete %>">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnDelete" runat="server" ToolTip="<%$Resources:PFSalesResource,Deleteprosp %>"
                                    CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnDelete_Click"> <%--OnClientClick='JAVASCRIPT:Return (Confirm ('Are You Sure, You Want ToolTip Delete The prosployee?'))'--%>
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
        <asp:Panel ID="pnlAddProsp" runat="server">
            <div id="Div1" class="innerHeader" runat="server" visible="false">
                <img src="images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="lblAddProspHead" runat="server" Text="<%$Resources:PFSalesResource,AddProspectDetails %>"></asp:Label>
                <div class="addBtn">
                    <asp:LinkButton ID="lnkbtnBackToSearch" runat="server" ToolTip="<%$Resources:PFSalesResource,BackToSearch %>"
                        OnClick="lnkbtnBackToSearch_Click">
                        <asp:Image ID="imgBackToSearch" ImageUrl="~/Images/back.png" runat="server" />
                        <asp:Label ID="lblBackToSearch" runat="server" Text="<%$Resources:PFSalesResource,BackToSearch %>"></asp:Label></asp:LinkButton></div>
            </div>
            <div class="Mandatory" style="margin-bottom: 0px;">
                <asp:Label ID="lblMandetoryinfo" runat="server" Text="<%$Resources:PFSalesResource,MandetoryInfo %>"></asp:Label>
            </div>
            <div class="button" style="margin: 15px !important;">
                <asp:LinkButton ID="lnkbtnSave" runat="server" TabIndex="44" Text="<%$ Resources:PFSalesResource,Save %>"
                    ToolTip="<%$ Resources:PFSalesResource,SaveEmployee %>" OnClick="lnkbtnSave_Click"
                    ValidationGroup="SaveContact"></asp:LinkButton>
                <asp:LinkButton ID="lnkbtnFinalClear" TabIndex="45" runat="server" Text="<%$ Resources:PFSalesResource,Clear %>"
                    ToolTip="<%$ Resources:PFSalesResource,Clear %>" Visible="false" CausesValidation="false"
                    OnClick="lnkbtnFinalClear_Click"></asp:LinkButton>
            </div>
            <div class="dilContener" style="width: 98%; margin: 10px 15px;">
                <div class="error" id="dvadderror" runat="server" visible="false">
                    <asp:Label ID="lblAddErrMsg" runat="server" Text=""></asp:Label>
                </div>
                <!--Content-Note: success Msg-->
                <div class="success" id="dvaddSucc" runat="server" visible="false">
                    <asp:Label ID="lblAddSucMsg" runat="server" Text=""></asp:Label>
                </div>
                <dl class="contactDetailsPop">
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
                        <label>
                            *</label><asp:Label ID="lblCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:
                    </dt>
                    <dd>
                        <asp:DropDownList ID="ddlCarMake" TabIndex="5" AutoPostBack="true" OnSelectedIndexChanged="ddlCarMake_SelectedIndexChanged"
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
                        <label>
                            *</label>
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
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhNo"
                            Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,PhoneNoVal %>"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vcePhone" runat="server" TargetControlID="rfvPhone"
                            PopupPosition="TopRight">
                        </ajax:ValidatorCalloutExtender>
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
                        <label>
                            *</label>
                        <asp:Label ID="lblState" runat="server" Text="<%$ Resources:PFSalesResource,State %>"></asp:Label>:
                    </dt>
                    <dd>
                        <asp:DropDownList ID="ddlState" CssClass="selectClass" TabIndex="15" runat="server"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                            InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,StateVal %>"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="rfvState"
                            PopupPosition="TopRight">
                        </ajax:ValidatorCalloutExtender>
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
                        <label>
                            *</label>
                        <asp:Label ID="lblFinance" runat="server" Text="<%$ Resources:PFSalesResource,Finance %>"></asp:Label>:</dt>
                    <dd>
                        <asp:DropDownList ID="ddlFinance" CssClass="selectClass" TabIndex="19" runat="server"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlFinance_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvFinance" runat="server" ControlToValidate="ddlFinance"
                            InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,FinanceVal %>"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vceFinance" runat="server" TargetControlID="rfvFinance"
                            PopupPosition="TopRight">
                        </ajax:ValidatorCalloutExtender>
                    </dd>
                    <dt>
                        <asp:Label ID="lblConsultant" runat="server" Text="<%$ Resources:PFSalesResource,Consultant %>"></asp:Label>:</dt>
                    <dd>
                        <asp:DropDownList ID="ddlConsultant" CssClass="selectClass" TabIndex="21" runat="server"
                            Enabled="false" OnSelectedIndexChanged="ddlConsultant_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdfConsultID" runat="server" Value="0" />
                    </dd>
                    <dt>
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
                        <%-- visible="false"--%>
                        <asp:Label ID="lblAlternateNo" runat="server" Text="<%$ Resources:PFSalesResource,AlternateContNo %>"></asp:Label>
                    </dt>
                    <dd id="ddalCont" runat="server">
                        <%-- visible="false"--%>
                        <asp:TextBox ID="txtAltContNo" CssClass="inputClass" TabIndex="27" MaxLength="20"
                            Width="160" runat="server"></asp:TextBox>
                        <ajax:FilteredTextBoxExtender ID="fteAlteContNo" runat="server" TargetControlID="txtAltContNo"
                            FilterType="Custom" ValidChars="0123456789+" Enabled="false">
                        </ajax:FilteredTextBoxExtender>
                        <ajax:MaskedEditExtender ID="meeAltContNo" runat="server" TargetControlID="txtAltContNo"
                            BehaviorID="MEE1" MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                            ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                        </ajax:MaskedEditExtender>
                        <div class="popUpViewBtn">
                            <asp:LinkButton ID="lnkbtnAlterContNo" runat="server" TabIndex="28" OnClick="lnkbtnAlterContNo_Click">....</asp:LinkButton></div>
                    </dd>
                    <dt id="Dt4" runat="server" visible="false">
                        <asp:Label ID="lblNovtedLease" runat="server" Text="<%$ Resources:PFSalesResource,NovatedLease %>"></asp:Label>
                    </dt>
                    <dd id="Dd4" runat="server" visible="false">
                        <asp:RadioButton ID="rbtnYes" CssClass="allchklist" runat="server" TabIndex="29"
                            Text="<%$ Resources:PFSalesResource,Yes %>" Checked="true" GroupName="NewOrUsed" />
                        <asp:RadioButton ID="rbtnNo" runat="server" CssClass="allchklist" TabIndex="30" Text="<%$ Resources:PFSalesResource,No %>"
                            GroupName="NewOrUsed" />
                    </dd>
                    <dt id="Dt5" runat="server" visible="false">
                        <asp:Label ID="lblTradeInMakeModel" runat="server" Text="<%$ Resources:PFSalesResource,TradeInMakeModel %>"></asp:Label>:
                    </dt>
                    <dd id="Dd5" runat="server" visible="false">
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
                <dl class="contactDetailsPop">
                    <dt id="Dt6" runat="server" visible="false">
                        <label>
                            *</label>
                        <asp:Label ID="lblName" runat="server" Text="<%$ Resources:PFSalesResource,Name %>"></asp:Label>:
                    </dt>
                    <dd id="Dd6" runat="server" visible="false">
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
                        <label>
                            *</label><asp:Label ID="lblModel" runat="server" Text="<%$ Resources:PFSalesResource,Model %>"></asp:Label>:
                    </dt>
                    <dd>
                        <asp:DropDownList ID="ddlModel" TabIndex="6" CssClass="selectClass" runat="server">
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
                        <asp:Label ID="lblWhereDidUHear" runat="server" Text="<%$ Resources:PFSalesResource,WhereDidUHearabtPF %>"></asp:Label></dt>
                    <dd>
                        <asp:DropDownList ID="ddlWhereDidUHear" CssClass="selectClass" TabIndex="9" runat="server"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlWhereDidUHear_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                        </asp:DropDownList>
                    </dd>
                    <dt id="Dt7" runat="server" visible="false">
                        <asp:Label ID="lblAltEmail" runat="server" Text="<%$ Resources:PFSalesResource,AlternameEmail %>"></asp:Label>:
                    </dt>
                    <dd id="Dd7" runat="server" visible="false">
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
                        <label>
                            *</label><asp:Label ID="lblCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country %>"></asp:Label>:</dt>
                    <dd>
                        <asp:DropDownList ID="ddlCountry" CssClass="selectClass" TabIndex="14" runat="server"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                            InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,CountryVal %>"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vceCountry" runat="server" TargetControlID="rfvCountry"
                            PopupPosition="TopRight">
                        </ajax:ValidatorCalloutExtender>
                    </dd>
                    <dt>
                        <label>
                            *</label><asp:Label ID="lblPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</dt>
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
                        <asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="ddlPostalCode"
                            Display="None" InitialValue="0" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,PostalVal %>"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vcePostalCode" runat="server" TargetControlID="rfvPostalCode"
                            PopupPosition="TopRight">
                        </ajax:ValidatorCalloutExtender>
                        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputClass" TabIndex="16"
                            MaxLength="4" Visible="false" AutoPostBack="true" OnTextChanged="txtPostalCode_TextChanged"></asp:TextBox>
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
                        </ajax:ValidatorCalloutExtender>
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
                    <dt id="Dt8" runat="server" visible="false">
                        <asp:Label ID="lblAddressLine3" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine3 %>"></asp:Label>:</dt>
                    <dd id="Dd8" runat="server" visible="false">
                        <asp:TextBox ID="txtAddLine3" CssClass="inputClass" runat="server" MaxLength="250"></asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblFConsultant" runat="server" Text="<%$ Resources:PFSalesResource,FConsultant %>"></asp:Label></dt>
                    <dd>
                        <asp:TextBox ID="txtFConsultant" runat="server" CssClass="inputClass" MaxLength="150"
                            Visible="false"></asp:TextBox>
                        <asp:DropDownList ID="ddlFConsultant" runat="server" CssClass="selectClass" Enabled="false"
                            TabIndex="20" OnSelectedIndexChanged="ddlFConsultant_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdfFConsultID" runat="server" Value="0" />
                    </dd>
                    <dt>
                        <label>
                            *</label><asp:Label ID="lblAddStatus" runat="server" Text="<%$ Resources:PFSalesResource,Status %>"></asp:Label>:</dt>
                    <dd>
                        <asp:DropDownList ID="ddlAddStatus" CssClass="selectClass" TabIndex="22" runat="server">
                            <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlAddStatus"
                            InitialValue="0" Display="None" ValidationGroup="SaveContact" ErrorMessage="<%$ Resources:PFSalesResource,StatusVal %>"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vceStatus" runat="server" TargetControlID="rfvStatus"
                            PopupPosition="TopRight">
                        </ajax:ValidatorCalloutExtender>
                    </dd>
                    <dt>
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
                    </dd>
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
                <asp:Panel ID="pnlFCDetails" runat="server" Visible="false" Style="float: left; width: 100%;
                    height: auto;">
                    <div class="headText">
                    </div>
                    <dl class="contactDetailsPop">
                        <dt>
                            <asp:Label ID="lblltrFinanceRequired" runat="server" Text="<%$ Resources:PFSalesResource,FinanceRequired %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlfinReq" runat="server" TabIndex="31" CssClass="selectClass">
                                <asp:ListItem Value="0">Select finance required</asp:ListItem>
                                <asp:ListItem Value="Business Finance">Business Finance</asp:ListItem>
                                <asp:ListItem Value="Novated Leases">Car Loans</asp:ListItem>
                                <asp:ListItem Value="Finance Lease">Finance Lease</asp:ListItem>
                                <asp:ListItem Value="Finance Lease">Hire Purchase</asp:ListItem>
                                <asp:ListItem Value="Novated Leases">Novated Leases</asp:ListItem>
                                <asp:ListItem Value="Novated Leases">Operating Lease</asp:ListItem>
                                <asp:ListItem Value="Personal Finance">Personal Finance</asp:ListItem>
                                <asp:ListItem Value="Other">Other</asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblltrCreditHistory" runat="server" Text="<%$ Resources:PFSalesResource,CreditHistory %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCredHistory" runat="server" TabIndex="33" CssClass="selectClass">
                                <asp:ListItem Value="0">Select credit history</asp:ListItem>
                                <asp:ListItem Value="Good">Good</asp:ListItem>
                                <asp:ListItem Value="Average">Average</asp:ListItem>
                                <asp:ListItem Value="Poor">Poor</asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblltrEstFin" runat="server" Text="<%$ Resources:PFSalesResource,EstimatedFinance %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEstFin" runat="server" TabIndex="35" CssClass="inputClass" MaxLength="20"></asp:TextBox>
                            <%-- <ajax:FilteredTextBoxExtender ID="fteEstFin" runat="server" TargetControlID="txtEstFin"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789.">
                            </ajax:FilteredTextBoxExtender>--%>
                        </dd>
                        <dt>
                            <asp:Label ID="lblltrInitialDeposit" runat="server" Text="<%$ Resources:PFSalesResource,InitialDeposit %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtInitialDep" runat="server" TabIndex="37" CssClass="inputClass"
                                MaxLength="20"></asp:TextBox>
                            <%-- <ajax:FilteredTextBoxExtender ID="fteInitialDep" runat="server" TargetControlID="txtInitialDep"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789.">
                            </ajax:FilteredTextBoxExtender>--%>
                        </dd>
                        <dt>
                            <asp:Label ID="lblltrEmployment" runat="server" Text="<%$ Resources:PFSalesResource,Employment %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlEmployment" runat="server" TabIndex="39" CssClass="selectClass">
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
                            <asp:TextBox ID="txtCurrentIncome" runat="server" TabIndex="41" CssClass="inputClass"
                                MaxLength="10"></asp:TextBox>
                        </dd>
                        <dt style="height: auto">
                            <asp:Label ID="lblltrTimeAtCurAdd" runat="server" Text="<%$ Resources:PFSalesResource,TimeAtCurAdd %>"></asp:Label>
                        </dt>
                        <dd style="height: auto">
                            <asp:DropDownList ID="ddlTimeAtCurAdd" runat="server" TabIndex="43" CssClass="selectClass">
                                <asp:ListItem Value="0">Select Time at current address</asp:ListItem>
                                <asp:ListItem Value="Less Than 3 years">Less Than 3 years</asp:ListItem>
                                <asp:ListItem Value="Greater Than 3 years">Greater Than 3 years</asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                    </dl>
                    <dl class="contactDetailsPop">
                        <dt>
                            <asp:Label ID="lblltrTermyears" runat="server" Text="<%$ Resources:PFSalesResource,Termyears %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlTermYears" runat="server" TabIndex="32" CssClass="selectClass">
                                <asp:ListItem Value="0" Selected="True">Select years</asp:ListItem>
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
                                <asp:ListItem Value="11 year">11</asp:ListItem>
                                <asp:ListItem Value="12 years">12</asp:ListItem>
                                <asp:ListItem Value="13 years">13</asp:ListItem>
                                <asp:ListItem Value="14 years">14</asp:ListItem>
                                <asp:ListItem Value="15 years">15</asp:ListItem>
                                <asp:ListItem Value="16 years">16</asp:ListItem>
                                <asp:ListItem Value="17 years">17</asp:ListItem>
                                <asp:ListItem Value="18 years">18</asp:ListItem>
                                <asp:ListItem Value="19 years">19</asp:ListItem>
                                <asp:ListItem Value="20 years">20</asp:ListItem>
                                <asp:ListItem Value="21 year">21</asp:ListItem>
                                <asp:ListItem Value="22 years">22</asp:ListItem>
                                <asp:ListItem Value="23 years">23</asp:ListItem>
                                <asp:ListItem Value="24 years">24</asp:ListItem>
                                <asp:ListItem Value="25 years">25</asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblltrResidualBallonPaymen" runat="server" Text="<%$ Resources:PFSalesResource,ResidualBallonPaymen %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtResBaloon" runat="server" TabIndex="34" CssClass="inputClass"
                                MaxLength="20"></asp:TextBox>
                            <%-- <ajax:FilteredTextBoxExtender ID="fteResBaloon" runat="server" TargetControlID="txtResBaloon"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789.">
                            </ajax:FilteredTextBoxExtender>--%>
                        </dd>
                        <dt style="height: auto;">
                            <asp:Label ID="lblltrMessage" runat="server" Text="<%$ Resources:PFSalesResource,Message %>"></asp:Label>:
                        </dt>
                        <dd style="height: auto;">
                            <asp:TextBox ID="txtFCMessage" runat="server" TabIndex="36" CssClass="inputClass"
                                MaxLength="500" TextMode="MultiLine" Rows="3" Style="height: auto; margin-bottom: 10px;"></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblltrEmployer" runat="server" Text="<%$ Resources:PFSalesResource,Employer %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmployer" runat="server" TabIndex="38" CssClass="inputClass"
                                MaxLength="50"></asp:TextBox>
                        </dd>
                        <dt style="height: auto">
                            <asp:Label ID="lblltrTimeinCurEmp" runat="server" Text="<%$ Resources:PFSalesResource,TimeinCurEmp %>"></asp:Label>
                        </dt>
                        <dd style="height: auto">
                            <asp:DropDownList ID="ddlTimeinCurEmp" runat="server" TabIndex="40" CssClass="selectClass">
                                <asp:ListItem Value="0">Select Current Employment Time</asp:ListItem>
                                <asp:ListItem Value="Less Than 3 months">Less Than 3 months</asp:ListItem>
                                <asp:ListItem Value="Less Than 1 year">Less Than 1 year</asp:ListItem>
                                <asp:ListItem Value="Less Than 3 years">Less Than 3 years</asp:ListItem>
                                <asp:ListItem Value="Over 3 years">Over 3 years</asp:ListItem>
                                <asp:ListItem Value="Other">Other</asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt id="Dt9" runat="server" visible="false">
                            <asp:Label ID="lblltrFinFrom" runat="server" Text="<%$ Resources:PFSalesResource,FinanceRequestFrom %>"></asp:Label>
                        </dt>
                        <dd id="Dd9" runat="server" visible="false">
                            <asp:DropDownList ID="ddlFinReqFrom" runat="server" TabIndex="42" CssClass="selectClass">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                    </dl>
                </asp:Panel>
                <div class="headText">
                </div>
                <%-- <div class="button">
                    <asp:LinkButton ID="lnkbtnSave" runat="server" TabIndex="35" Text="<%$ Resources:PFSalesResource,Save %>"
                        ToolTip="<%$ Resources:PFSalesResource,SaveEmployee %>" OnClick="lnkbtnSave_Click"
                        ValidationGroup="SaveContact"></asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnFinalClear" TabIndex="36" runat="server" Text="<%$ Resources:PFSalesResource,Clear %>"
                        ToolTip="<%$ Resources:PFSalesResource,Clear %>" CausesValidation="false" OnClick="lnkbtnFinalClear_Click"></asp:LinkButton>
                </div>--%>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlphonePopUp" runat="server" Visible="false">
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
        <asp:Panel ID="pnlContactPopUp" runat="server" Visible="false">
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
