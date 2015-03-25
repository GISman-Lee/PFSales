<%@ Page Title="<%$Resources:PFSalesResource,Employee %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="AddEmployee"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanEmployee" runat="server">
        <ContentTemplate>
            <div class="mainbdr">
                <!--Content-Note: Please Use ASP:LABEL instead of span-->
                <asp:Panel ID="pnlSearchEmployee" runat="server" DefaultButton="lnkbtnSearch">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="SearchEmpHead" runat="server" Text="<%$Resources:PFSalesResource,SearchEmp %>"></asp:Label>
                        <div class="addBtn" style="display: none">
                            <asp:LinkButton ID="lnkbtnAddEmp" runat="server" ToolTip="<%$Resources:PFSalesResource,AddEmployee %>"
                                OnClick="lnkbtnAddEmp_Click">
                                <asp:Image ID="imgAddEmp" ImageUrl="~/Images/add.png" runat="server" />
                                <asp:Label ID="lblAddEmp" runat="server" Text="<%$Resources:PFSalesResource,AddEmployee %>">
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
                                <asp:Label ID="lblempName" runat="server" Text="<%$Resources:PFSalesResource,EmpName %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtempName" CssClass="inputClass" runat="server" MaxLength="750"></asp:TextBox>
                            </dd>
                            <dt>
                                <asp:Label ID="lblRole" runat="server" Text="<%$Resources:PFSalesResource,Role %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlRoles" CssClass="selectClass" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                                ToolTip="<%$Resources:PFSalesResource,SearchEmp %>" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                        </div>
                        <div style="float: right; width: 16%">
                            <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                            <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                               <%-- <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="25" Text="25"></asp:ListItem>--%>
                                <asp:ListItem Value="50" Text="50" Selected="True" ></asp:ListItem>
                                <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                 <asp:ListItem Value="150" Text="150" ></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:GridView ID="gvEmp" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                            border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                            AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                            PageSize="50" OnPageIndexChanging="gvEmp_PageIndexChanging" OnRowDataBound="gvEmp_RowDataBound"
                            OnSorting="gvEmp_Soring">
                            <Columns>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmpName %>" SortExpression="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                        <asp:HiddenField ID="hdfUserId" runat="server" Value='<%#Bind("UserId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Role %>" SortExpression="RoleName"
                                    HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoleName" runat="server" Text='<%#Bind("RoleName") %>'></asp:Label>
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
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="<%$Resources:PFSalesResource,EditEmp %>"
                                            CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnEdit_Click">
                                    <img src="Images/edit.png"/>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Delete %>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" ToolTip="<%$Resources:PFSalesResource,DeleteEmp %>"
                                            CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnDelete_Click"> <%--OnClientClick='JAVASCRIPT:Return (Confirm ('Are You Sure, You Want ToolTip Delete The Employee?'))'--%>
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
                <asp:Panel ID="pnlAddEmployee" runat="server" Visible="false" DefaultButton="lnkbtnSave">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="lblAddEmpHead" runat="server" Text="<%$Resources:PFSalesResource,AddEmpDetails %>"></asp:Label>
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
                                <%--<label>
                                    *</label>--%><asp:Label ID="lblTitle" runat="server" Text="<%$Resources:PFSalesResource,Title %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlTitle" Enabled="false" TabIndex="1" CssClass="selectClass"
                                    runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="ddlTitle"
                                    SetFocusOnError="true" ValidationGroup="Save" InitialValue="0" Display="None"
                                    ErrorMessage="<%$Resources:PFSalesResource,TitleVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceTitle" runat="server" TargetControlID="rfvTitle"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt>
                                <label>
                                    *</label><asp:Label ID="lblAddFName" runat="server" Text="<%$Resources:PFSalesResource,FName %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtFName" Enabled="false" CssClass="inputClass" TabIndex="3" runat="server"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFName" runat="server" ControlToValidate="txtFName"
                                    Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,FNameVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceFName" runat="server" TargetControlID="rfvFName"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAddLName" runat="server" Text="<%$Resources:PFSalesResource,LName %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtLName" Enabled="false" CssClass="inputClass" TabIndex="5" runat="server"
                                    MaxLength="50"></asp:TextBox>
                            </dd>
                            <dt>
                                <label>
                                    *</label><asp:Label ID="lblEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailUserName %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtEmail1" Enabled="false" CssClass="inputClass" TabIndex="7" runat="server"
                                    MaxLength="250"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail1"
                                    Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,EmailVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="rfvEmail"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator ID="revtxtEmailId" runat="server" ErrorMessage="<%$ Resources:PFSalesResource, invalidemail %>"
                                    ControlToValidate="txtEmail1" SetFocusOnError="true" Display="None" ValidationGroup="Save"
                                    ValidationExpression="^\s*(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*\s*$"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceRegEmail" runat="server" TargetControlID="revtxtEmailId"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPhoneNo" runat="server" Text="<%$ Resources:PFSalesResource,PhoneNo %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtPhNo" Enabled="false" CssClass="inputClass" TabIndex="9" Width="80"
                                    MaxLength="20" runat="server"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="ftePhNo" runat="server" TargetControlID="txtPhNo"
                                    FilterType="Custom" ValidChars="0123456789+" Enabled="true">
                                </ajax:FilteredTextBoxExtender>
                                <ajax:MaskedEditExtender ID="msePhNo" runat="server" TargetControlID="txtPhNo" BehaviorID="MEE"
                                    MaskType="Date" Mask="99999999999999999999" MessageValidatorTip="true" InputDirection="LeftToRight"
                                    ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                                <div class="popUpViewBtn">
                                    <asp:LinkButton ID="lnkbtnPhPopUp" Enabled="false" runat="server" TabIndex="10" OnClick="lnkbtnPhPopUp_Click">....</asp:LinkButton>
                                </div>
                                <asp:Label ID="lblExtention" runat="server" Style="padding-bottom: 2px; padding-left: 2px;
                                    padding-right: 2px; padding-top: 5px;" Text="<%$Resources:PFSalesResource,Ext %>"></asp:Label>
                                <asp:TextBox ID="txtExt" Enabled="false" CssClass="inputClass" TabIndex="9" Width="50"
                                    MaxLength="6" runat="server"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="fteExt" runat="server" TargetControlID="txtExt"
                                    FilterType="Custom" ValidChars="0123456789" Enabled="true">
                                </ajax:FilteredTextBoxExtender>
                            </dd>
                            <dt>
                                <%--   <label>
                                    *</label>--%><asp:Label ID="lblDob" runat="server" Text="<%$Resources:PFSalesResource,DOB %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtDOB" CssClass="inputClass" TabIndex="13" Width="105px" runat="server"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtnCalBDate" runat="server" Style="float: left">
                                    <asp:Image ID="imgCalBDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtDOB" Format="dd/MM/yyyy"
                                    PopupPosition="TopLeft" PopupButtonID="lnkbtnCalBDate">
                                </ajax:CalendarExtender>
                                <asp:Label Style="padding-left: 4px; color: Red" ID="lblDobinfo" Visible="false" runat="server" Text="<%$Resources:PFSalesResource,Setdateformat %>">
                                </asp:Label>
                                <ajax:MaskedEditExtender ID="meeDob" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                    TargetControlID="txtDOB" MessageValidatorTip="true">
                                </ajax:MaskedEditExtender>
                                <asp:CompareValidator ID="cvDOB" runat="server" Type="Date" Operator="DataTypeCheck"
                                    ControlToValidate="txtDOB" ValidationGroup="Save" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                    Display="None">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCompDOB" runat="server" TargetControlID="cvDOB"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:MaskedEditValidator ID="mskEValStrDate" ControlExtender="meeDob" ControlToValidate="txtDOB"
                                    runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, DOBVal %>"
                                    ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="true"
                                    ValidationGroup="Save">
                                </ajax:MaskedEditValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDob" runat="server" TargetControlID="mskEValStrDate"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompValToTodayDate" runat="server" ControlToValidate="txtDOB"
                                    ErrorMessage="<%$ Resources:PFSalesResource,DOBTodayVal %>" CssClass="errorMsg"
                                    ValueToCompare="" Operator="LessThan" ValidationGroup="GetCountTot" Type="Date"
                                    Display="None">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceTotToToday" runat="server" TargetControlID="CompValToTodayDate"
                                    PopupPosition="TopLeft">
                                </ajax:ValidatorCalloutExtender>
                                <%-- <div class="popUpViewBtn">
                                    <asp:LinkButton ID="LinkButton3" runat="server">....</asp:LinkButton></div>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblFax" runat="server" Text="<%$ Resources:PFSalesResource,Fax %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtFax" CssClass="inputClass" TabIndex="15" MaxLength="30" Width="160"
                                    runat="server"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="fteFax" runat="server" TargetControlID="txtFax"
                                    FilterType="Custom" ValidChars="0123456789+" Enabled="true">
                                </ajax:FilteredTextBoxExtender>
                                <ajax:MaskedEditExtender ID="mseFax" runat="server" TargetControlID="txtFax" BehaviorID="MEE2"
                                    MaskType="None" Mask="999999999999999999999999999999" MessageValidatorTip="true"
                                    InputDirection="LeftToRight" ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                                <div class="popUpViewBtn">
                                    <asp:LinkButton ID="lnkbtnFax" TabIndex="16" runat="server" OnClick="lnkbtnFax_Click">....</asp:LinkButton></div>
                            </dd>
                            <dt>
                                <%-- <label>
                                    *</label>--%><asp:Label ID="lblState" runat="server" Text="<%$ Resources:PFSalesResource,State %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlState" TabIndex="18" CssClass="selectClass" runat="server"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                                    InitialValue="0" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,StateVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceState" runat="server" TargetControlID="rfvState"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt>
                                <%--<label>
                                    *</label>--%><asp:Label ID="lblCity" runat="server" Text="<%$ Resources:PFSalesResource,City %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlCity" TabIndex="20" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                                    InitialValue="0" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,CityVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="rfvCity"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAddressLine2" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine2 %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtAddLine2" Enabled="false" CssClass="inputClass" TabIndex="22"
                                    runat="server" MaxLength="250"></asp:TextBox>
                            </dd>
                            <dt>
                                <label>
                                    *</label><asp:Label ID="lblRoleId" runat="server" Text="<%$ Resources:PFSalesResource,Role %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlAddRole" Enabled="false" CssClass="selectClass" TabIndex="24"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlAddRole_SelectedIndexChanged"
                                    runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvAddRole" runat="server" ControlToValidate="ddlAddRole"
                                    InitialValue="0" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,RoleVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceRole" runat="server" TargetControlID="rfvAddRole"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblPhoto" runat="server" Text="<%$ Resources:PFSalesResource,EmpPhoto %>"></asp:Label>:</dt>
                            <dd>
                                <asp:FileUpload ID="fupEmpPhoto" runat="server" TabIndex="27" />
                                <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblImageFormat"
                                    runat="server" Text="<%$ Resources:PFSalesResource,UpImageInfo %>"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvEmpPhoto" runat="server" ControlToValidate="fupEmpPhoto"
                                    ErrorMessage="<%$ Resources:PFSalesResource,PhotoUploadVal %>" ValidationGroup="Upload"
                                    SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcePhoto" runat="server" TargetControlID="rfvEmpPhoto"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator ID="reExpValSyllabus" ControlToValidate="fupEmpPhoto"
                                    Display="None" ValidationGroup="Upload" runat="Server" ErrorMessage="<%$Resources:PFSalesResource,EmpPhotoUploadVal %>"
                                    ValidationExpression="([a-zA-Z012345678_9].*)+(.jpg|.jpeg|.Jpg|.JPG|.Jpeg|.JPEG|.png|.Png|.PNG|.bmp|.Bmp|.BMP|.gif|.Gif|.GIF)$" />
                                <ajax:ValidatorCalloutExtender ID="vceRegPhoto" runat="server" TargetControlID="reExpValSyllabus"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblIsInFleetLead" runat="server" Text="<%$ Resources:PFSalesResource,IsInFleetLead %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkIsInFleetLead" runat="server" TabIndex="29" />
                            </dd>
                            <dt>
                                <asp:Label ID="lblReplaceExisting" runat="server" Text="<%$ Resources:PFSalesResource,ReplaceExistingEmp %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkRepExisting" runat="server" TabIndex="31" AutoPostBack="true"
                                    OnCheckedChanged="chkRepExisting_CheckChanged" />
                            </dd>
                            <dt id="dtvirtualPerson" runat="server" visible="false">
                                <label>
                                    *</label><asp:Label ID="lblSelectVirtualPerson" runat="server" Text="<%$ Resources:PFSalesResource,SelectEmpToReplace %>"></asp:Label>
                            </dt>
                            <dd id="ddvirtualPerson" runat="server" visible="false">
                                <asp:DropDownList ID="ddlVirtualPersons" runat="server" TabIndex="33" CssClass="selectClass">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblRepPerUserName" runat="server"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvVirtualPer" runat="server" ControlToValidate="ddlVirtualPersons"
                                    SetFocusOnError="true" ValidationGroup="Save" InitialValue="0" Display="None"
                                    ErrorMessage="<%$Resources:PFSalesResource,VirtualPerVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceRepUser" runat="server" TargetControlID="rfvVirtualPer"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                        </dl>
                        <dl class="dealerRagisterThree">
                            <dt>
                                <label>
                                    *</label><asp:Label ID="lblName" runat="server" Text="<%$ Resources:PFSalesResource,Name %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtAddName" Enabled="false" TabIndex="2" CssClass="inputClass" runat="server"
                                    MaxLength="750"></asp:TextBox>
                                <div class="popUpViewBtn">
                                    <asp:LinkButton ID="lnkbtnNamePopUp" Visible="false" runat="server" ValidationGroup="showName"
                                        OnClick="lnkbtnNamePopUp_Click">....</asp:LinkButton></div>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtAddName"
                                    Display="None" Enabled="false" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,EmpNameVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceName" runat="server" TargetControlID="rfvName"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfvnameForPopUp" runat="server" ControlToValidate="txtAddName"
                                    Display="None" Enabled="false" ValidationGroup="showName" ErrorMessage="<%$ Resources:PFSalesResource,EmpNameVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceNameForPopUp" runat="server" TargetControlID="rfvnameForPopUp"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAddMname" runat="server" Text="<%$Resources:PFSalesResource,MName %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtMName" Enabled="false" CssClass="inputClass" TabIndex="4" runat="server"
                                    MaxLength="50"></asp:TextBox>
                            </dd>
                            <dt>
                                <%--<label>
                                    *</label>--%><asp:Label ID="lblGender" runat="server" Text="<%$ Resources:PFSalesResource,Gender %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlGender" TabIndex="6" CssClass="selectClass" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="ddlGender"
                                    InitialValue="0" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,GenderVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceGender" runat="server" TargetControlID="rfvGender"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblEmail2" runat="server" Text="<%$ Resources:PFSalesResource,AlternameEmail %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtEmail2" CssClass="inputClass" TabIndex="8" runat="server" MaxLength="250"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revAltEmailId" runat="server" ErrorMessage="<%$ Resources:PFSalesResource, invalidemail %>"
                                    ControlToValidate="txtEmail2" SetFocusOnError="true" Display="None" ValidationGroup="Save"
                                    ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceAlterEmail" runat="server" TargetControlID="revAltEmailId"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <%-- <label>
                                    *</label>--%><asp:Label ID="lblMobile" runat="server" Text="<%$ Resources:PFSalesResource,MobileNo %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtMobile" Enabled="false" CssClass="inputClass" TabIndex="11" MaxLength="20"
                                    Width="160" runat="server"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="fteMobile" runat="server" TargetControlID="txtMobile"
                                    FilterType="Custom" ValidChars="0123456789+" Enabled="true">
                                </ajax:FilteredTextBoxExtender>
                                <ajax:MaskedEditExtender ID="mseMobile" runat="server" TargetControlID="txtMobile"
                                    MaskType="Date" Mask="99999999999999999999" BehaviorID="MEE1" MessageValidatorTip="true"
                                    InputDirection="LeftToRight" ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                                <div class="popUpViewBtn">
                                    <asp:LinkButton ID="lnkbtnMobile" Enabled="false" runat="server" TabIndex="12" OnClick="lnkbtnMobile_Click">....</asp:LinkButton></div>
                                <%--    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile"
                                    Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,MobileNoVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMobile" runat="server" TargetControlID="rfvMobile"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt>
                                <%--<label>
                                    *</label>--%><asp:Label ID="lblDOJ" runat="server" Text="<%$ Resources:PFSalesResource,DOJ %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtDOJ" CssClass="inputClass" TabIndex="14" Width="105px" runat="server"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtnCalDOJ" runat="server" Style="float: left">
                                    <asp:Image ID="imgCalDOJ" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="calDOJ" runat="server" TargetControlID="txtDOJ" Format="dd/MM/yyyy"
                                    PopupPosition="TopLeft" PopupButtonID="lnkbtnCalDOJ">
                                </ajax:CalendarExtender>
                                <asp:Label Visible="false" Style="padding-left: 4px; color: Red" ID="Label1" runat="server" Text="<%$Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                                <ajax:MaskedEditExtender ID="mseDOJ" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                    TargetControlID="txtDOJ" MessageValidatorTip="true">
                                </ajax:MaskedEditExtender>
                                <asp:CompareValidator ID="cmDOJ" runat="server" Type="Date" Operator="DataTypeCheck"
                                    ControlToValidate="txtDOJ" ValidationGroup="Save" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                    Display="None">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDOJ" runat="server" TargetControlID="cmDOJ"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:MaskedEditValidator ID="mevDOJ" ControlExtender="mseDOJ" ControlToValidate="txtDOB"
                                    runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, DOJVal %>"
                                    ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="true"
                                    ValidationGroup="Save"></ajax:MaskedEditValidator>
                                <ajax:ValidatorCalloutExtender ID="vceMevDOJ" runat="server" TargetControlID="mevDOJ"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <%--<label>
                                    *</label>--%><asp:Label ID="lblCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlCountry" CssClass="selectClass" TabIndex="17" runat="server"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                                    InitialValue="0" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,CountryVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCountry" runat="server" TargetControlID="rfvCountry"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt>
                                <%--<label>
                                    *</label>--%><asp:Label ID="lblPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlPostalCode" TabIndex="19" CssClass="selectClass" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlPostalCode_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="txtPostalCode" CssClass="inputClass" TabIndex="21" runat="server"
                                MaxLength="10"></asp:TextBox>--%>
                                <%--   <ajax:FilteredTextBoxExtender ID="ftePostalCode" runat="server" TargetControlID="txtPostalCode"
                                FilterType="Custom" ValidChars="0123456789">
                            </ajax:FilteredTextBoxExtender>--%>
                                <%-- <asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="ddlPostalCode"
                                    Display="None" InitialValue="0" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,PostalVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcePostalCode" runat="server" TargetControlID="rfvPostalCode"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAddressLine1" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine1 %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtAddLine1" Enabled="false" runat="server" TabIndex="21" CssClass="inputClass"
                                    MaxLength="250"></asp:TextBox>
                                <%--<asp:TextBox ID="TextBox2" CssClass="inputClass" Width="160" runat="server"></asp:TextBox>
                                <div class="popUpViewBtn">
                                    <asp:LinkButton ID="LinkButton4" runat="server">....</asp:LinkButton></div>--%>
                            </dd>
                            <dt>
                                <asp:Label ID="lblAddressLine3" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine3 %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtAddLine3" Enabled="false" CssClass="inputClass" TabIndex="23"
                                    runat="server" MaxLength="250"></asp:TextBox>
                            </dd>
                            <dt>
                                <%--<label>
                                    *</label>--%><asp:Label ID="lblDesig" runat="server" Text="<%$ Resources:PFSalesResource,Designation %>"></asp:Label>:</dt>
                            <dd>
                                <asp:DropDownList ID="ddlDesig" CssClass="selectClass" runat="server" TabIndex="25"
                                    Width="170px">
                                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvDesig" runat="server" ControlToValidate="ddlDesig"
                                    InitialValue="0" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,DesigVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceDesig" runat="server" TargetControlID="rfvDesig"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                                <asp:TextBox ID="txtDesig" runat="server" CssClass="inputClass" Width="167px" Visible="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNewDesig" runat="server" ControlToValidate="txtDesig"
                                    InitialValue="" Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,NewDesigVal %>"
                                    SetFocusOnError="true" Enabled="false"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceNewDesig" runat="server" TargetControlID="rfvNewDesig"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:LinkButton ID="lnkbtnAddDesig" runat="server" TabIndex="26" OnClick="lnkbtnAddDesig_Click"
                                    ToolTip="<%$Resources:PFSalesResource,AddDesig %>"><img src="Images/addDesig.png" style="margin-bottom:-6px; margin-left:2px;" /></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnMinusDesig" runat="server" ToolTip="<%$Resources:PFSalesResource,Cancel %>"
                                    Visible="false" OnClick="lnkbtnMinusDesig_Click"><img src="Images/MinusDesig.png" style="margin-top:1px; margin-left:3px;" /></asp:LinkButton>
                            </dd>
                            <dt>
                                <div class="button">
                                    <asp:LinkButton ID="lnkbtnUpload" runat="server" TabIndex="28" Text="<%$ Resources:PFSalesResource,Upload %>"
                                        ToolTip="<%$ Resources:PFSalesResource,EmpPhotoUpload %>" ValidationGroup="Upload"
                                        OnClick="lnkbtnUpload_Click"></asp:LinkButton>
                                </div>
                            </dt>
                            <dd style="height: auto;">
                                <asp:Image ID="imgEmpPhoto" runat="server" Style="width: 122px; border: solid 1px #7F9DB9;"
                                    ImageUrl="~/Images/NoPhoto.png" />
                                <div style="float: right; width: 47%;">
                                    <asp:LinkButton ID="lnkbtnRemove" runat="server" ToolTip="<%$Resources:PFSalesResource,Remove %>"
                                        Visible="false" OnClick="lnkbtnRemove_click"><img src="Images/MinusDesig.png" /></asp:LinkButton>
                                </div>
                            </dd>
                            <dt>
                                <asp:Label ID="lblIsActive" runat="server" Text="<%$ Resources:PFSalesResource,ActivateUser %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkIsActive" TabIndex="30" runat="server" Checked="true" />
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSave" runat="server" Text="<%$ Resources:PFSalesResource,Save %>"
                                ToolTip="<%$ Resources:PFSalesResource,SaveEmployee %>" OnClick="lnkbtnSave_Click"
                                ValidationGroup="Save" TabIndex="34"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnFinalClear" runat="server" Text="<%$ Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$ Resources:PFSalesResource,Clear %>" OnClick="lnkbtnFinalClear_Click"
                                CausesValidation="false" TabIndex="35"></asp:LinkButton>
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
                                OnClick="lnkbtnNamePopUpClose_Close"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
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
                <asp:Panel ID="pnlphonePopUp" runat="server" Visible="false" DefaultButton="lnkbtnPhPoUpOk">
                    <div class="pop-up">
                    </div>
                    <div class="contentPopUp">
                        <div class="popHeader">
                            <asp:Label ID="lblPhPopUpPhone" runat="server" Text="<%$ Resources:PFSalesResource,EnterPhoneNumber%>"></asp:Label>
                            <asp:LinkButton ID="lnkbtnPhPopClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                                OnClick="lnkbtnPhPopClose_Close"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
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
                                        BehaviorID="MEE4" MaskType="None" Mask="99" MessageValidatorTip="true" InputDirection="LeftToRight"
                                        ErrorTooltipEnabled="True" ClearMaskOnLostFocus="false">
                                    </ajax:MaskedEditExtender>
                                </dd>
                            </dl>
                            <div class="headText">
                            </div>
                            <div class="button">
                                <asp:LinkButton ID="lnkbtnEditFormat" runat="server" Text="<%$Resources:PFSalesResource,EditFormats %>"
                                    ToolTip="<%$Resources:PFSalesResource,EditFormatToolTip %>" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnPhPoUpOk" runat="server" Text="<%$Resources:PFSalesResource,OK %>"
                                    ToolTip="<%$Resources:PFSalesResource,OK %>" OnClick="lnkbtnPhPoUpOk_Click" ValidationGroup="PhonePopUp"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnPhPopUpCancel" runat="server" Text="<%$Resources:PFSalesResource,Cancel %>"
                                    ToolTip="<%$Resources:PFSalesResource,Close %>" CausesValidation="false" OnClick="lnkbtnPhPopClose_Close"></asp:LinkButton></div>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnEmployeePhoto" runat="server" Value="" />
                    <asp:HiddenField ID="hdfFName" runat="server" />
                    <asp:HiddenField ID="hdfMName" runat="server" />
                    <asp:HiddenField ID="hdfLName" runat="server" />
                    <asp:HiddenField ID="hdfPhoneFormat" runat="server" />
                    <asp:HiddenField ID="hdfUserId" runat="server" />
                    <asp:HiddenField ID="hdfPhPopType" runat="server" Value="" />
                </asp:Panel>
                <!--Content-->
            </div>
            <asp:HiddenField ID="hdfUserVRId" runat="server" Value="0" />
            <asp:HiddenField ID="hdfPhoneFormatId" runat="server" />
            <asp:HiddenField ID="hdfMobileFormatId" runat="server" />
            <asp:HiddenField ID="hdfFaxFormatId" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnUpload" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproEmp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpPanEmployee">
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
