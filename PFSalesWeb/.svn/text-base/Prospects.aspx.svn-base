<%@ Page Title="<%$Resources:PFSalesResource,Prospects %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="Prospects.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Prospects" %>

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
                    <dl class="dealerRagisterTwo">
                        <dt>
                            <asp:Label ID="lblEmailID" runat="server" Text="<%$Resources:PFSalesResource,EmailId %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmailId" CssClass="inputClass" MaxLength="160" runat="server"></asp:TextBox>
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
                                    <asp:LinkButton ID="lnkbtnFleetTeamLead" runat="server" ToolTip="<%$Resources:PFSalesResource,FleetTeamLead %>"
                                        OnClick="lnkbtnFleetTeamLead_Click">
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
                                <dt style="width: 100px;">
                                    <asp:LinkButton ID="lnkbtnClearFilter" runat="server" ToolTip="<%$Resources:PFSalesResource,ClearFilter %>"
                                        OnClick="lnkbtnClearFilter_Click" Visible="false">
                                        <div id="dvClearFilter" runat="server" style="color: black; height: 15px; padding-bottom: 5px;
                                            padding-left: 5px; padding-right: 5px; padding-top: 5px; text-align: center;
                                            width: 130px; background-color: White; border: solid 1px #737373; text-align: center;">
                                            <asp:Label ID="lblClearFilter" runat="server" Text="<%$Resources:PFSalesResource,ClearFilter %>"></asp:Label>
                                        </div>
                                    </asp:LinkButton>
                                </dt>
                            </dl>
                        </div>
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
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EnquiryDateHead %>" SortExpression="CreatedDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("EnquiryDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFAllocationDate %>"
                                SortExpression="AllocatedDateSort">
                                <ItemTemplate>
                                    <asp:Label ID="lblPFAllocationDate" runat="server" Text='<%#Bind("PFAllocatedDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCAllocationDate %>"
                                SortExpression="FAlocationDateSort" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCAllocationDate" runat="server" Text='<%#Bind("FAlocationDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    <asp:HiddenField ID="_hdfTotCount" runat="server" Value='<%#Bind("TodActCnt") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,CarMake %>" SortExpression="Make">
                                <ItemTemplate>
                                    <asp:Label ID="lblMake" runat="server" Text='<%#Bind("Make") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfIsFleetTeamLead" runat="server" Value='<%#Bind("IsFleetTeamLead") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Model %>" SortExpression="Model">
                                <ItemTemplate>
                                    <asp:Label ID="lblPostalCode" runat="server" Text='<%#Bind("Model") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfStateId" runat="server" Value='<%#Bind("StateId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,State %>" SortExpression="StateName">
                                <ItemTemplate>
                                    <asp:Label ID="lblStates" runat="server" Text='<%#Bind("StateName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFConsultant %>" SortExpression="PfConsultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblPfConsultant" runat="server" Text='<%#Bind("PfConsultant") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfConsultant" runat="server" Value='<%#Bind("ConsultantId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PFstatus %>" SortExpression="status">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfPropStatusId" runat="server" Value='<%#Bind("StatusId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCConsultant %>" SortExpression="FCConsultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCConsultant" runat="server" Text='<%#Bind("FCConsultant") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfFCConsultant" runat="server" Value='<%#Bind("FinanceConsultantId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FCstatus %>" SortExpression="FCStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCstatus" runat="server" Text='<%#Bind("FCStatus") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfFCPropStatusId" runat="server" Value='<%#Bind("FCStatusId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,View %>">
                                <ItemTemplate>
                                    <asp:Image ID="imgWALead" runat="server" ImageUrl="~/Images/viewDetails.png" Visible="false"
                                        Style="float: left; margin-right: 2px;" />
                                    <asp:LinkButton ID="lnkbtnManageAct" runat="server" ToolTip="<%$Resources:PFSalesResource,ManageActivities %>"
                                        CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnManageAct_Click">
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
                    <div class="PagerContainer" id="divPaging" runat="server" width="100%">
                        <MechPager:Class1 ID="pagerParent" Visible="false" runat="server" OnCommand="pagerParent_Command"
                            GeneratePagerInfoSection="false" GenerateFirstLastSection="false" Width="100%" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlViewContact" runat="server" Visible="false">
                <div class="pop-up" style="z-index: 10025;">
                </div>
                <div class="contentPopUp" style="z-index: 10030; margin-left: -94%; top: 1%; width: 87%;">
                    <div class="popHeader">
                        <asp:Label ID="lblAddContactHead" runat="server" Text="<%$ Resources:PFSalesResource,ViewEnqDetails%>"></asp:Label>
                        <asp:LinkButton ID="lnkbtnAddContactClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                            OnClick="lnkbtnAddContactClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                    </div>
                    <div style="overflow-y: scroll; height: 550px; width: 100%">
                        <div class="dilContenerTwo">
                            <div class="error" id="dvadderror" runat="server" visible="false">
                                <asp:Label ID="lblAddErrMsg" runat="server" Text=""></asp:Label>
                            </div>
                            <!--Content-Note: success Msg-->
                            <div class="success" id="dvaddSucc" runat="server" visible="false">
                                <asp:Label ID="lblAddSucMsg" runat="server" Text=""></asp:Label>
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
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
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
                            <div class="headText">
                            </div>
                            <b style="float: left; font-size: 16px; margin-bottom: 10px;">
                                <asp:Label ID="lblOldActDetHead" runat="server" Text="<%$Resources:PFSalesResource,Summary %>"></asp:Label>
                            </b>
                            <asp:Panel ID="pnlMangActGrid" runat="server" ScrollBars="Vertical" 
                                Style="margin-top: 15px;" Width="100%">
                                <asp:GridView ID="gvActivity" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                                    border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                                    AutoGenerateColumns="false" rule="none" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,onDate %>" SortExpression="StartDateTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActDate" runat="server" Text='<%#Bind("SDT") %>'></asp:Label>
                                                <asp:HiddenField ID="hdfClrId" runat="server" Value='<%#Bind("ClearId") %>' />
                                                <asp:HiddenField ID="hdfActId" runat="server" Value='<%#Bind("ActId") %>' />
                                                <asp:HiddenField ID="hdfNotesId" runat="server" Value='<%#Bind("Id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Activity %>" SortExpression="Regarding">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActStatus" runat="server" Text='<%#Bind("Regarding") %>'></asp:Label>
                                                <%-- <b>
                                <asp:Literal ID="ltrActivity" runat="server" Text="Activity:"></asp:Literal></b><asp:Label
                                    ID="lblActReg" runat="server" Text='<%#Bind("name") %>'></asp:Label>
                            <br />
                            <b>
                                <asp:Literal ID="ltrStartTime" runat="server" Text="Start Time:"></asp:Literal></b><asp:Label
                                    ID="lblStartDtTime" runat="server" Text='<%#Bind("start") %>'></asp:Label><br />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Notes %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemBeforeAct" runat="server" Text='<%#Bind("Notes") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Consultant %>" SortExpression="Consultant">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemAfterAct" runat="server" Text='<%#Bind("Consultant") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Details %>">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnViewActDet" runat="server" ToolTip="<%$Resources:PFSalesResource,ViewActDetails %>"
                                                    CommandArgument='<%#Eval("ActId") %>' >
                                               <img width="20px" height="21px" src="Images/viewDetails.png"/>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,ClearAct %>">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnClearActDet" runat="server" ToolTip="<%$Resources:PFSalesResource,ClearReminder %>"
                                                    CommandArgument='<%#Eval("ActId") %>' >
                                               <img width="20px" height="21px" src="Images/c.png"/>
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
                            </asp:Panel>
                        </div>
                        <asp:HiddenField ID="hdfConsultPhone" runat="server" Value="" />
                        <asp:HiddenField ID="hdfConsultExt" runat="server" Value="" />
                    </div>
                </div>
            </asp:Panel>
            <asp:HiddenField ID="hdfSelProspId" runat="server" />
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
