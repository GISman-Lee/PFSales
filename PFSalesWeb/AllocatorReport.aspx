<%@ Page Title="<%$Resources:PFSalesResource,AllocatorReport %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="AllocatorReport.aspx.cs" Inherits="AllocatorReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="uppanScheduler" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnExcel" />
            <asp:PostBackTrigger ControlID="lnkbtnPdf" />
        </Triggers>
        <ContentTemplate>
            <div class="innerHeader">
                <img src="Images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,AllocatorReport %>"></asp:Label>
            </div>
            <div class="dilContener">
                <dl class="dealerRagisterThree" runat="server">
                    <dt>
                        <asp:Label ID="lbltoEntFromDate" runat="server" Text="<%$Resources:PFSalesResource, fromDate%>"></asp:Label>
                    </dt>
                    <dd style="width: 135px;">
                        <asp:TextBox ID="txtUnAlocFromDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                        <asp:LinkButton ID="lnkbtnCalFDate" runat="server" Style="float: left">
                            <asp:Image ID="imgCalFDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                        <ajax:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtUnAlocFromDate"
                            Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnCalFDate">
                        </ajax:CalendarExtender>
                        <asp:Label Style="color: Red; display: inline;" class="errorMsg" ID="lblTotEntFromDateInfo"
                            runat="server" Visible="false" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                        <ajax:MaskedEditExtender ID="meeFromDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                            TargetControlID="txtUnAlocFromDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                        </ajax:MaskedEditExtender>
                        <ajax:MaskedEditValidator ID="mevFromDate" ControlExtender="meeFromDate" ControlToValidate="txtUnAlocFromDate"
                            runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, FromDateVal %>"
                            ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                            ValidationGroup="AllocReport"></ajax:MaskedEditValidator>
                        <ajax:ValidatorCalloutExtender ID="vceTotEntFrmDate" runat="server" TargetControlID="mevFromDate"
                            PopupPosition="TopLeft">
                        </ajax:ValidatorCalloutExtender>
                        <asp:CompareValidator ID="cvTotEntFrmDate" runat="server" Type="Date" Operator="DataTypeCheck"
                            ControlToValidate="txtUnAlocFromDate" ValidationGroup="AllocReport" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                            Display="None">
                        </asp:CompareValidator>
                        <ajax:ValidatorCalloutExtender ID="vceCompTotEntFrmDate" runat="server" TargetControlID="cvTotEntFrmDate"
                            PopupPosition="TopLeft">
                        </ajax:ValidatorCalloutExtender>
                    </dd>
                </dl>
                <dl class="dealerRagisterThree">
                    <dt>
                        <asp:Label ID="lbltoEntToDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                    </dt>
                    <dd style="width: 130px;">
                        <asp:TextBox ID="txtUnalocToDate" runat="server" Width="100" CssClass="inputClass"></asp:TextBox>
                        <asp:LinkButton ID="lnkbtncalTDate" runat="server" Style="float: left">
                            <asp:Image ID="imgCalTDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtUnalocToDate"
                            Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtncalTDate">
                        </ajax:CalendarExtender>
                        <asp:Label Style="color: Red; display: inline;" Visible="false" class="errorMsg"
                            ID="lblTotEntToDateInfo" runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                        <ajax:MaskedEditExtender ID="mseToEntToDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                            TargetControlID="txtUnalocToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                        </ajax:MaskedEditExtender>
                        <asp:CompareValidator ID="cvtotEntToDate" runat="server" Type="Date" Operator="DataTypeCheck"
                            ControlToValidate="txtUnalocToDate" ValidationGroup="AllocReport" ErrorMessage="<%$ Resources:PfSalesResource, ValidDate%>"
                            Display="None">
                        </asp:CompareValidator>
                        <ajax:ValidatorCalloutExtender ID="vceToEntToDate" runat="server" TargetControlID="cvtotEntToDate"
                            PopupPosition="TopLeft">
                        </ajax:ValidatorCalloutExtender>
                        <ajax:MaskedEditValidator ID="msevToEntToDate" ControlExtender="mseToEntToDate" ControlToValidate="txtUnalocToDate"
                            runat="server" Display="None" EmptyValueMessage="<%$ Resources:PFSalesResource, ToDateVal %>"
                            ErrorMessage="<%$ Resources:PFSalesResource, ValidDate %>" IsValidEmpty="False"
                            ValidationGroup="AllocReport"></ajax:MaskedEditValidator>
                        <ajax:ValidatorCalloutExtender ID="vceMseToEntToDate" runat="server" TargetControlID="msevToEntToDate"
                            PopupPosition="TopLeft">
                        </ajax:ValidatorCalloutExtender>
                        <asp:CompareValidator ID="CompValToDate" runat="server" ControlToValidate="txtUnalocToDate"
                            ControlToCompare="txtUnAlocFromDate" CssClass="errorMsg" ErrorMessage="<%$ Resources:PFSalesResource,ToFromDateVal %>"
                            Operator="GreaterThanEqual" ValidationGroup="AllocReport" Type="Date" Display="None"></asp:CompareValidator>
                        <ajax:ValidatorCalloutExtender ID="vceTotFromToDate" runat="server" TargetControlID="CompValToDate"
                            PopupPosition="TopLeft">
                        </ajax:ValidatorCalloutExtender>
                        <%--<asp:CompareValidator ID="CompValToTodayDate" runat="server" ControlToValidate="txtUnalocToDate"
                            ErrorMessage="<%$ Resources:PFSalesResource,ToTodayVal %>" CssClass="errorMsg"
                            ValueToCompare="" Operator="LessThan" ValidationGroup="GetCountTot" Type="Date"
                            Display="None"></asp:CompareValidator>
                        <ajax:ValidatorCalloutExtender ID="vceTotToToday" runat="server" TargetControlID="CompValToTodayDate"
                            PopupPosition="TopLeft">
                        </ajax:ValidatorCalloutExtender>--%>
                    </dd>
                </dl>
                <dl class="dealerRagisterThree">
                    <dt>
                        <asp:Label ID="lblserSource" runat="server" Text="<%$Resources:PFSalesResource,Consultant %>"></asp:Label>:
                    </dt>
                    <dd>
                        <asp:DropDownList ID="ddlConsultant" TabIndex="103" CssClass="selectClass" runat="server"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlConsultant_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                        </asp:DropDownList>
                    </dd>
                </dl>
                <div class="headText">
                </div>
                <div class="button">
                    <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                        ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" TabIndex="106" ValidationGroup="AllocReport"
                        OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                        ToolTip="<%$Resources:PFSalesResource,Clear %>" CausesValidation="false" TabIndex="107"
                        OnClick="lnkbtnClear_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnExcel" runat="server" Text="<%$Resources:PFSalesResource,ExportToExcel %>"
                        ToolTip="<%$Resources:PFSalesResource,ExportToExcel %>" ValidationGroup="AllocReport"
                        OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnPdf" runat="server" Text="<%$Resources:PFSalesResource,ExportToPdf %>"
                        ToolTip="<%$Resources:PFSalesResource,ExportToPdf %>" ValidationGroup="AllocReport"
                        OnClick="lnkbtnPdf_Click"></asp:LinkButton></div>
                <div style="float: right; width: 16%">
                    <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                     <%--   <asp:ListItem Value="5" Text="5"></asp:ListItem>
                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                        <asp:ListItem Value="25" Text="25" Selected="True"></asp:ListItem>--%>
                        <asp:ListItem Value="50" Text="50" Selected="True" ></asp:ListItem>
                        <asp:ListItem Value="100" Text="100"></asp:ListItem>
                         <asp:ListItem Value="150" Text="150" ></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:GridView ID="gvAllocate" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                    border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                    AutoGenerateColumns="false" rule="none" AllowSorting="true" AllowPaging="false"
                    OnSorting="gvAllocate_Soring" PageSize="50" >
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,onDate %>" SortExpression="onDate">
                            <ItemTemplate>
                                <asp:Label ID="lblonDate" runat="server" Text='<%#Bind("onDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,prospectHead %>" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblConsultName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,prospectHead %>" SortExpression="LeadName">
                            <ItemTemplate>
                                <asp:Label ID="lblAssignedLoad" runat="server" Text='<%#Bind("LeadName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmailId %>" Visible="false" SortExpression="Email1">
                            <ItemTemplate>
                                <asp:Label ID="lblContEmailId" runat="server" Text='<%#Bind("Email1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,PhoneNo %>" Visible="false" SortExpression="Phone">
                            <ItemTemplate>
                                <asp:Label ID="lblphone" runat="server" Text='<%#Bind("Phone") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--   <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,LeadsAssigned %>" SortExpression="AssignedLoad">
                            <ItemTemplate>
                                <asp:Label ID="lblAssignedLoad" runat="server" Text='<%#Bind("AssignedLoad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                    </Columns>
                    <EmptyDataTemplate>
                        No Record Found
                    </EmptyDataTemplate>
                    <%--<EmptyDataTemplate>
                        <div align="center">
                            <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoDataFound %>"></asp:Label>
                        </div>
                    </EmptyDataTemplate>--%>
                </asp:GridView>
                <asp:Panel ID="pnlWorkLoadDetUp" runat="server" Visible="false">
                    <div class="pop-up">
                    </div>
                    <div class="contentPopUp" style="height: 550px; left: 75%; top: 6%; width: 900px;">
                        <div class="popHeader">
                            <asp:Label ID="lblWorkload" runat="server" Text="<%$ Resources:PFSalesResource,EnquiryDetails%>"></asp:Label>
                            <asp:LinkButton ID="lnkWorkLoadClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                                OnClick="lnkWorkLoadClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                        </div>
                        <div class="dilContenerTwo">
                            <div style="height: 30px; margin-top: -10px; text-align: center; width: 80%;">
                                <b>
                                    <asp:Label ID="lblltrLeadNo" runat="server" Text="<%$Resources:PFSalesResource,LeadNo %>"></asp:Label></b>
                                <asp:Label ID="lblLeadNo" runat="server" Text="1"></asp:Label>
                            </div>
                            <dl class="dealerRagisterThree">
                                <dt><b>
                                    <asp:Label ID="lblltrName" runat="server" Text="<%$ Resources:PFSalesResource,Name %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrEmail1" runat="server" Text="<%$ Resources:PFSalesResource,EmailId %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblEmail1" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrPhoneNo" runat="server" Text="<%$ Resources:PFSalesResource,PhoneNo %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblPhNo" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrFax" runat="server" Text="<%$ Resources:PFSalesResource,Fax %>"></asp:Label>:</b>
                                </dt>
                                <dd>
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
                                    <asp:Label ID="lblltrAddressLine1" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine1 %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblAddLine1" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrAddressLine3" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine3 %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblAddLine3" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrConsultant" runat="server" Text="<%$ Resources:PFSalesResource,Consultant %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblConsultant" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrAddStatus" runat="server" Text="<%$ Resources:PFSalesResource,Status %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblAddStatus" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrMemberNo" runat="server" Text="<%$ Resources:PFSalesResource,MemberNo %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblMemNo" runat="server"></asp:Label>
                                </dd>
                            </dl>
                            <dl class="dealerRagisterThree">
                                <dt><b>
                                    <asp:Label ID="lblltrCarMake" runat="server" Text="<%$ Resources:PFSalesResource,CarMake %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblCarMake" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrAltEmail" runat="server" Text="<%$ Resources:PFSalesResource,AlternameEmail %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblAlterEmail" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrMobile" runat="server" Text="<%$ Resources:PFSalesResource,MobileNo %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country %>"></asp:Label>:</dt></b>
                                <dd>
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
                                <dt><b>
                                    <asp:Label ID="lblltrAddressLine2" runat="server" Text="<%$ Resources:PFSalesResource,AddressLine2 %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblAddLine2" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrPostalCode" runat="server" Text="<%$ Resources:PFSalesResource,PostalCode %>"></asp:Label>:</dt></b>
                                <dd>
                                    <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrFConsultant" runat="server" Text="<%$ Resources:PFSalesResource,FConsultant %>"></asp:Label></dt></b>
                                <dd>
                                    <asp:Label ID="lblFConsultant" runat="server"></asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrSource" runat="server" Text="<%$ Resources:PFSalesResource,ProspectSrc %>"></asp:Label>:</b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblSource" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt><b>
                                    <asp:Label ID="lblltrCreatedDate" runat="server" Text="<%$ Resources:PFSalesResource,EnquiryDate %>"></asp:Label></b>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblEnqDate" runat="server">
                                    </asp:Label>
                                </dd>
                                <dt id="dtalCont" runat="server" visible="false"><b>
                                    <asp:Label ID="lblltrAlternateNo" runat="server" Text="<%$ Resources:PFSalesResource,AlternateContNo %>"></asp:Label></b>
                                </dt>
                                <dd id="ddalCont" runat="server" visible="false">
                                    <asp:Label ID="lblAltContNo" runat="server"></asp:Label>
                                </dd>
                            </dl>
                            <div class="headText">
                            </div>
                            <div class="button">
                                <asp:LinkButton ID="lnkbtnPrev" runat="server" Text="<%$Resources:PFSalesResource,Previous %>"
                                    ToolTip="<%$Resources:PFSalesResource,ViewPrevEnqDet %>" OnClick="lnkbtnPrev_Click"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnNext" runat="server" Text="<%$Resources:PFSalesResource,Next %>"
                                    ToolTip="<%$Resources:PFSalesResource,ViewNextEnqDet %>" OnClick="lnkbtnNext_Click"></asp:LinkButton>
                                <asp:HiddenField ID="hdfCurrentLoadNo" runat="server" Value="1" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproSchedular" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="uppanScheduler">
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
