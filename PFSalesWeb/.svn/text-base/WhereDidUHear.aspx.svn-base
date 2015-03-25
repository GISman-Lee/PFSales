<%@ Page Title="<%$Resources:PFSalesResource,WhereDidUHearPF %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="WhereDidUHear.aspx.cs" Inherits="WhereDidUHear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanWhereUHear" runat="server">
        <ContentTemplate>
            <div class="mainbdr">
                <asp:Panel ID="pnlSearchWhereUHear" runat="server" DefaultButton="lnkbtnSearch">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="SearchWhereUHearHead" runat="server" Text="<%$Resources:PFSalesResource,SearchWhereDidUHear %>"></asp:Label>
                        <div class="addBtn">
                            <asp:LinkButton ID="lnkbtnAddWhereUHear" runat="server" ToolTip="<%$Resources:PFSalesResource,AddWhereUHearToolTip %>"
                                OnClick="lnkbtnAddWhereUHear_Click">
                                <asp:Image ID="imgAddWhereUHear" ImageUrl="~/Images/add.png" runat="server" />
                                <asp:Label ID="lblAddWhereUHear" runat="server" Text="<%$Resources:PFSalesResource,AddWhereUHear %>">
                                </asp:Label>
                            </asp:LinkButton>
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
                                <asp:Label ID="lblWhereUHear" runat="server" Text="<%$Resources:PFSalesResource,ValueText %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtWhereUHear" CssClass="inputClass" runat="server" MaxLength="200"></asp:TextBox>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                                ToolTip="<%$Resources:PFSalesResource,SearchWhereDidUHear %>" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                        </div>
                        <div style="float: right; width: 16%">
                            <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                            <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                <%--    <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem Value="25" Text="25"></asp:ListItem>--%>
                                <asp:ListItem Value="50" Text="50" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                <asp:ListItem Value="150" Text="150"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:GridView ID="gvWhereUHear" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                            border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                            AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                            PageSize="50" OnPageIndexChanging="gvWhereUHear_PageIndexChanging" OnRowDataBound="gvWhereUHear_RowDataBound"
                            OnSorting="gvWhereUHear_Soring">
                            <Columns>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ValueforAnswer %>" SortExpression="ValueforAnswer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRefWhereUHear" runat="server" Text='<%#Bind("ValueforAnswer") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,IsFleetLead %>" SortExpression="IsFleetLead">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsFleetTeamLead" runat="server" Text='<%#Bind("IsFleetLead") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EffectiveFrom %>" SortExpression="ActFrDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFromDate" runat="server" Text='<%#Bind("ActiveFromDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EffectiveTo %>" SortExpression="ActToDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTodate" runat="server" Text='<%#Bind("ActiveToDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Edit %>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="<%$Resources:PFSalesResource,EditProspSource %>"
                                            CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnEdit_Click">
                                    <img src="Images/edit.png"/>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Delete %>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" ToolTip="<%$Resources:PFSalesResource,DeleteProspSource %>"
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
                <asp:Panel ID="pnlAddWhereUHear" runat="server" Visible="false" DefaultButton="lnkbtnSave">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="lblAddWhereUHearHead" runat="server" Text="<%$Resources:PFSalesResource,AddValueforAnswer %>"></asp:Label>
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
                                    *</label><asp:Label ID="lblvalueForAnswer" runat="server" Text="<%$Resources:PFSalesResource,ValueforAnswer %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtvalueForAnswer" CssClass="inputClass" TabIndex="1" runat="server"
                                    MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvvalueForAnswer" runat="server" ControlToValidate="txtvalueForAnswer"
                                    SetFocusOnError="true" ValidationGroup="Save" Display="None" ErrorMessage="<%$Resources:PFSalesResource,valueForAnswerVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcevalueForAnswer" runat="server" TargetControlID="rfvvalueForAnswer"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblEffectiveFromDate" runat="server" Text="<%$Resources:PFSalesResource,EffectiveFrom %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtFromDate" runat="server" TabIndex="3" Width="100" CssClass="inputClass"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtnCalFDate" runat="server" Style="float: left">
                                    <asp:Image ID="imgCalFDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtFromDate"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnCalFDate">
                                </ajax:CalendarExtender>
                                <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblFromDateInfo"
                                    runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                <ajax:MaskedEditExtender ID="meeFromDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                    TargetControlID="txtFromDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                                <ajax:MaskedEditValidator ID="mevFromDate" ControlExtender="meeFromDate" ControlToValidate="txtFromDate"
                                    runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                                    ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                    ValidationGroup="Save"></ajax:MaskedEditValidator>
                                <ajax:ValidatorCalloutExtender ID="vceFrmDate" runat="server" TargetControlID="mevFromDate"
                                    PopupPosition="TopLeft">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="cvFrmDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                    ControlToValidate="txtFromDate" ValidationGroup="Save" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                    Display="None">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceCompFrmDate" runat="server" TargetControlID="cvFrmDate"
                                    PopupPosition="TopLeft">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                        </dl>
                        <dl class="dealerRagisterThree">
                            <dt>
                                <asp:Label ID="lblIsFleetLead" runat="server" Text="<%$Resources:PFSalesResource,IsFleetLead %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkIsFleetLead" runat="server" TabIndex="2" />
                            </dd>
                            <dt>
                                <asp:Label ID="lblToDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                            </dt>
                            <dd style="width: 130px;">
                                <asp:TextBox ID="txtToDate" runat="server" TabIndex="4" Width="100" CssClass="inputClass"></asp:TextBox>
                                <asp:LinkButton ID="lnkbtncalTDate" runat="server" Style="float: left">
                                    <asp:Image ID="imgCalTDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtncalTDate">
                                </ajax:CalendarExtender>
                                <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblToDateInfo"
                                    runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>" Visible="false"></asp:Label>
                                <ajax:MaskedEditExtender ID="mseToDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                    TargetControlID="txtToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                                </ajax:MaskedEditExtender>
                                <asp:CompareValidator ID="cvToDate" runat="server" Type="Date" Operator="DataTypeCheck"
                                    ControlToValidate="txtToDate" ValidationGroup="Save" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                                    Display="None">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceToDate" runat="server" TargetControlID="cvToDate"
                                    PopupPosition="TopLeft">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:MaskedEditValidator ID="msevToDate" ControlExtender="mseToDate" ControlToValidate="txtToDate"
                                    runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                                    ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                                    ValidationGroup="Save"></ajax:MaskedEditValidator>
                                <ajax:ValidatorCalloutExtender ID="vcemseToDate" runat="server" TargetControlID="msevToDate"
                                    PopupPosition="TopLeft">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompValToDate" runat="server" ControlToValidate="txtToDate"
                                    ControlToCompare="txtFromDate" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                                    Operator="GreaterThanEqual" ValidationGroup="Save" Type="Date" Display="None"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="vceFromToDate" runat="server" TargetControlID="CompValToDate"
                                    PopupPosition="TopLeft">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSave" runat="server" Text="<%$ Resources:PFSalesResource,Save %>"
                                ToolTip="<%$ Resources:PFSalesResource,SaveWhereUHear %>" OnClick="lnkbtnSave_Click"
                                ValidationGroup="Save" TabIndex="31"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnFinalClear" runat="server" Text="<%$ Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$ Resources:PFSalesResource,Clear %>" OnClick="lnkbtnFinalClear_Click"
                                CausesValidation="false" TabIndex="32"></asp:LinkButton>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproWhereUHear" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpPanWhereUHear">
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
