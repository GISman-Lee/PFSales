<%@ Page Title="<%$Resources:PFSalesResource,ProspectReport %>" Language="C#" AutoEventWireup="true"
    CodeFile="ProspectReport.aspx.cs" EnableEventValidation="false" MasterPageFile="~/PFSalesMaster.master"
    Inherits="Reports_ProspectReport" %>

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
    <asp:UpdatePanel ID="uppanProspect" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnExcel" />
            <asp:PostBackTrigger ControlID="lnkbtnPdf" />
        </Triggers>
        <ContentTemplate>
            <div class="innerHeader">
                <img src="Images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,ProspectReport %>"></asp:Label>
            </div>
            <asp:Panel ID="pnlTabularRep" runat="server" DefaultButton="lnkbtnSearch">
                <div class="dilContener">
                    <dl class="dealerRagisterThree">
                        <dt>
                            <asp:Label ID="lblSerprospName" runat="server" Text="<%$Resources:PFSalesResource,Name %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtserprospName" CssClass="inputClass" MaxLength="160" runat="server"
                                TabIndex="101"></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lbltoEntFromDate" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtTotEntFrmDate" runat="server" Width="100" TabIndex="103" CssClass="inputClass"></asp:TextBox>
                            <asp:LinkButton ID="lnkbtnCalBDate" runat="server" Style="float: left" TabIndex="104">
                                <asp:Image ID="imgCalBDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                            <ajax:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtTotEntFrmDate"
                                Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnCalBDate">
                            </ajax:CalendarExtender>
                            <asp:Label Style="color: Red; display: inline;" Visible="false" class="errorMsg"
                                ID="lblTotEntFromDateInfo" runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                            <ajax:MaskedEditExtender ID="meeTotEntFrmDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                TargetControlID="txtTotEntFrmDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                        </dd>
                        <dt>
                            <asp:Label ID="lblserState" runat="server" Text="<%$Resources:PFSalesResource,State %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlserState" runat="server" CssClass="selectClass" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlserState_SelectedIndexChanged" TabIndex="107">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblSerStatus" runat="server" Text="<%$Resources:PFSalesResource,Status %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlStatus" TabIndex="109" CssClass="selectClass" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt id="Dt1" runat="server" visible="false">
                            <asp:Label ID="lblSerMemberNo" runat="server" Text="<%$ Resources:PFSalesResource,MemberNo %>"></asp:Label>
                            :</dt>
                        <dd id="Dd1" runat="server" visible="false">
                            <asp:TextBox ID="txtMemNo" CssClass="inputClass" TabIndex="100" runat="server" MaxLength="50"></asp:TextBox>
                        </dd>
                        <dt id="Dt2" runat="server" visible="true">
                            <asp:Label ID="lblSerEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailId %>"></asp:Label>:
                        </dt>
                        <dd id="Dd2" runat="server" visible="true">
                            <asp:TextBox ID="txtEmail1" CssClass="inputClass" TabIndex="111" runat="server" MaxLength="250"></asp:TextBox>
                        </dd>
                    </dl>
                    <dl class="dealerRagisterThree">
                        <dt>
                            <asp:Label ID="lblSerCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCarMake" AutoPostBack="true" TabIndex="102" OnSelectedIndexChanged="ddlCarMake_SelectedIndexChanged"
                                CssClass="selectClass" runat="server">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lbltoEntToDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtTotEntToDate" runat="server" Width="100" TabIndex="105" CssClass="inputClass"></asp:TextBox>
                            <asp:LinkButton ID="lnkbtnTDate" runat="server" Style="float: left" TabIndex="106">
                                <asp:Image ID="imgTdate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                            <ajax:CalendarExtender ID="ceTDate" runat="server" TargetControlID="txtTotEntToDate"
                                Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnTDate">
                            </ajax:CalendarExtender>
                            <asp:Label Style="color: Red; display: inline;" Visible="false" class="errorMsg"
                                ID="lblTotEntToDateInfo" runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                            <ajax:MaskedEditExtender ID="mseToEntToDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                TargetControlID="txtTotEntToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                        </dd>
                        <dt>
                            <asp:Label ID="lblserCity" runat="server" Text="<%$Resources:PFSalesResource,CitySuburb %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlserCity" runat="server" CssClass="selectClass" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlserCity_SelectedIndexChanged" TabIndex="108">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblserSource" runat="server" Text="<%$Resources:PFSalesResource,ProspectSrc %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSource" TabIndex="110" CssClass="selectClass" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlSource_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                    </dl>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                            ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" TabIndex="112" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                            ToolTip="<%$Resources:PFSalesResource,Clear %>" TabIndex="113" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnExcel" runat="server" Text="<%$Resources:PFSalesResource,ExportToExcel %>"
                            ToolTip="<%$Resources:PFSalesResource,ExportToExcel %>" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                        <%-- <div style="width: 110px; float: right;"></div>
                        <div style="width: 100px; float: right;"></div>--%>
                        <asp:LinkButton ID="lnkbtnPdf" runat="server" Text="<%$Resources:PFSalesResource,ExportToPdf %>"
                            ToolTip="<%$Resources:PFSalesResource,ExportToPdf %>" OnClick="lnkbtnPdf_Click"></asp:LinkButton></div>
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
                        AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                        PageSize="50"  OnSorting="gvprosp_Soring">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EnquiryDateHead %>" SortExpression="CreatedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("EnquiryDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,prospectHead %>" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,MemberNo %>" Visible="false"
                                SortExpression="MemberNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblMemberNo" runat="server" Text='<%#Bind("MemberNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,status %>" SortExpression="status">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfPropStatusId" runat="server" Value='<%#Bind("StatusId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CarMake %>" SortExpression="Make">
                                <ItemTemplate>
                                    <asp:Label ID="lblMake" runat="server" Text='<%#Bind("Make") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmailId %>" Visible="false"
                                SortExpression="EmailId">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmailId" runat="server" Text='<%#Bind("EmailId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PhoneNo %>" SortExpression="Phone">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Bind("Phone") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ProspectSrc %>" SortExpression="RefSource">
                                <ItemTemplate>
                                    <asp:Label ID="lblStates" runat="server" Text='<%#Bind("RefSource") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,IsAllocated %>" SortExpression="IsAllocated">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsAllocated" runat="server" Text='<%#Bind("IsAllocated") %>'></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproProspect" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="uppanProspect">
        <ProgressTemplate>
            <div id="progressBackgroundFilter">
            </div>
            <div id="processMessage">
                <span style="text-align: center;">
                    <img src="Images/loading.gif" />
                    <br />
                    <asp:Literal ID="ltrwait" runat="server" Text="<%$Resources:PFSalesResource,PleaseWait %>"></asp:Literal></span></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
