<%@ Page Title="<%$Resources:PFSalesResource,ReferelSource %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="ReferalSource.aspx.cs" Inherits="ReferalSource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanSource" runat="server">
        <ContentTemplate>
            <div class="mainbdr">
                <asp:Panel ID="pnlSearchSource" runat="server" DefaultButton="lnkbtnSearch">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="SearchSourceHead" runat="server" Text="<%$Resources:PFSalesResource,SearchProspectSource %>"></asp:Label>
                        <div class="addBtn">
                            <asp:LinkButton ID="lnkbtnAddSource" runat="server" ToolTip="<%$Resources:PFSalesResource,AddPrSrc %>"
                                OnClick="lnkbtnAddSource_Click">
                                <asp:Image ID="imgAddSource" ImageUrl="~/Images/add.png" runat="server" />
                                <asp:Label ID="lblAddSource" runat="server" Text="<%$Resources:PFSalesResource,AddPrSrc %>">
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
                                <asp:Label ID="lblPropectSource" runat="server" Text="<%$Resources:PFSalesResource,ProspectSrc %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtPrSource" CssClass="inputClass" runat="server" MaxLength="200"></asp:TextBox>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                                ToolTip="<%$Resources:PFSalesResource,SearchProspSource %>" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                        </div>
                        <div style="float: right; width: 16%">
                            <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                            <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                <asp:ListItem Value="50" Text="50" Selected="True" ></asp:ListItem>
                                <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                <asp:ListItem Value="150" Text="150"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:GridView ID="gvSource" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                            border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                            AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                            PageSize="50" OnPageIndexChanging="gvSource_PageIndexChanging" OnRowDataBound="gvSource_RowDataBound"
                            OnSorting="gvSource_Soring">
                            <Columns>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ProspectSrc %>" SortExpression="RefSource">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRefSource" runat="server" Text='<%#Bind("RefSource") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,IsFleetLead %>" SortExpression="IsFleetTeamLead">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsFleetTeamLead" runat="server" Text='<%#Bind("IsFleetTeamLead") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,description %>" HeaderStyle-Width="60%">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldescription" runat="server" Text='<%#Bind("RDescription") %>'></asp:Label>
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
                <asp:Panel ID="pnlAddSource" runat="server" Visible="false" DefaultButton="lnkbtnSave">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="lblAddSourceHead" runat="server" Text="<%$Resources:PFSalesResource,AddProspSource %>"></asp:Label>
                        <div class="addBtn">
                            <asp:LinkButton ID="lnkbtnBackToSearch" runat="server" ToolTip="<%$Resources:PFSalesResource,BackToSearch %>"
                                OnClick="lnkbtnBackToSearch_Click">
                                <asp:Image ID="imgBackToSearch" ImageUrl="~/Images/back.png" runat="server" />
                                <asp:Label ID="lblBackToSearch" runat="server" Text="<%$Resources:PFSalesResource,BackToSearch %>"></asp:Label></asp:LinkButton>
                         </div>
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
                                <label>
                                    *</label><asp:Label ID="lblProspectSrc" runat="server" Text="<%$Resources:PFSalesResource,ProspectSrc %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtPropSrc" CssClass="inputClass" TabIndex="1" runat="server" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvProspectSrc" runat="server" ControlToValidate="txtPropSrc"
                                    SetFocusOnError="true" ValidationGroup="Save" Display="None" ErrorMessage="<%$Resources:PFSalesResource,ProspectSrcEnterVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceProspectSrc" runat="server" TargetControlID="rfvProspectSrc"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblIsFleetLead" runat="server" Text="<%$Resources:PFSalesResource,IsFleetLead %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkIsFleetLead" runat="server" TabIndex="3" />
                            </dd>
                        </dl>
                        <dl class="dealerRagisterThree">
                            <dt>
                                <asp:Label ID="lblDesc" runat="server" Text="<%$Resources:PFSalesResource,description %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtDesc" CssClass="inputClass" TextMode="MultiLine" TabIndex="2"
                                    Rows="4" runat="server" MaxLength="500"></asp:TextBox>
                            </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSave" runat="server" Text="<%$ Resources:PFSalesResource,Save %>"
                                ToolTip="<%$ Resources:PFSalesResource,SaveProspSrc %>" OnClick="lnkbtnSave_Click"
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
    <asp:UpdateProgress ID="upproSource" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpPanSource">
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
