<%@ Page Title="" Language="C#" MasterPageFile="~/PFSalesMaster.master" AutoEventWireup="true"
    CodeFile="ContactReport.aspx.cs" Inherits="ContactReport" %>

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
            <asp:Panel ID="pnlSearchprosp" runat="server" DefaultButton="lnkbtnSearch">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,SearchProspect %>"></asp:Label>
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
                    <dl class="dealerRagisterThree">
                        <dt>
                            <asp:Label ID="lblprospName" runat="server" Text="<%$Resources:PFSalesResource,Name %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtserprospName" CssClass="inputClass" MaxLength="160" runat="server"></asp:TextBox>
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
                            <asp:Label ID="lblStatus" runat="server" Text="<%$Resources:PFSalesResource,Status %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlStatus" CssClass="selectClass" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                    </dl>
                    <dl class="dealerRagisterThree">
                        <dt>
                            <asp:Label ID="lblEmailID" runat="server" Text="<%$Resources:PFSalesResource,EmailId %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmailId" CssClass="inputClass" MaxLength="160" runat="server"></asp:TextBox>
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
                    </dl>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                            ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                            ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnExport" runat="server" TabIndex="121" ToolTip="<%$Resources:PFSalesResource,ExportToExcel %>"
                            Text="<%$Resources:PFSalesResource,ExportToExcel %>" OnClick="lnkbtnExport_Click">
                        </asp:LinkButton>
                    </div>
                    <div style="float: left; width: 100%; margin-top: 10px;">
                        <div style="float: right; width: 16%">
                            <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                            <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                <%--<asp:ListItem Value="5" Text="5"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem Value="25" Text="25" Selected="True"></asp:ListItem>--%>
                                <asp:ListItem Value="50" Text="50" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                <asp:ListItem Value="150" Text="150"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <asp:GridView ID="gvprosp" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                        border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                        AutoGenerateColumns="false" rule="none" AllowPaging="false" AllowSorting="true"
                        PageSize="50" OnPageIndexChanging="gvprosp_PageIndexChanging" OnSorting="gvprosp_Soring"
                        OnRowDataBound="gvprosp_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CarMake %>" SortExpression="CarMake">
                                <ItemTemplate>
                                    <asp:Label ID="lblMake" runat="server" Text='<%#Bind("CarMake") %>'></asp:Label>
                                    <%--<asp:HiddenField ID="hdfIsFleetTeamLead" runat="server" Value='<%#Bind("IsFleetTeamLead") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Model %>" SortExpression="Model">
                                <ItemTemplate>
                                    <asp:Label ID="lblPostalCode" runat="server" Text='<%#Bind("Model") %>'></asp:Label>
                                    <%-- <asp:HiddenField ID="hdfStateId" runat="server" Value='<%#Bind("StateId") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,State %>" SortExpression="State">
                                <ItemTemplate>
                                    <asp:Label ID="lblStates" runat="server" Text='<%#Bind("State") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FinanceType %>" SortExpression="Finance_Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblFinanceType" runat="server" Text='<%#Bind("Finance_Type") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Source %>" SortExpression="Source"">
                                <ItemTemplate>
                                    <asp:Label ID="lblSource" runat="server" Text='<%#Bind("Source") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,How %>" SortExpression="How">
                                <ItemTemplate>
                                    <asp:Label ID="lblHow" runat="server" Text='<%#Bind("How") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,WhereDidUHearPF %>" SortExpression="Where_Did_You_Hear">
                                <ItemTemplate>
                                    <asp:Label ID="lblWDYH" runat="server" Text='<%#Bind("Where_Did_You_Hear") %>'></asp:Label>
                                    <%-- <asp:HiddenField ID="hdfFCPropStatusId" runat="server" Value='<%#Bind("FCStatusId") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmailId %>" SortExpression="Email_address"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmailId" runat="server" Text='<%#Bind("Email_address") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EnquiryDateHead %>" SortExpression="CreatedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("EnquiryDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFConsultant %>" SortExpression="PF_Consultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblPfConsultant" runat="server" Text='<%#Bind("PF_Consultant") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCConsultant %>" SortExpression="FC_Consultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCConsultant" runat="server" Text='<%#Bind("FC_Consultant") %>'></asp:Label>
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
