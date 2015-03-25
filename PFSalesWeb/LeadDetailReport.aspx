<%@ Page Title="<%$Resources:PFSalesResource,LeadDetailReport %>" Language="C#" MasterPageFile="~/PFSalesMaster.master" AutoEventWireup="true"
    CodeFile="LeadDetailReport.aspx.cs" Inherits="LeadDetailReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="uppanProspect" runat="server">
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnExcel" />
            <asp:PostBackTrigger ControlID="lnkbtnPdf" />
        </Triggers>--%>
        <ContentTemplate>
            <div class="innerHeader">
                <img src="Images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,LeadDetailReport %>"></asp:Label>
            </div>
            <asp:Panel ID="pnlLeadDetialsRep" runat="server" DefaultButton="lnkbtnSearch">
                <div class="dilContener">
                    <dl class="dealerRagisterThree">
                        <dt>
                            <asp:Label ID="lblSerprospName" runat="server" Text="<%$Resources:PFSalesResource,fromDate %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtFromDate" Width="100"  CssClass="inputClass" runat="server"
                                TabIndex="101"></asp:TextBox>
                                 <asp:LinkButton ID="lnkbtnCalFrmDate" runat="server" Style="float: left" TabIndex="104">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnCalFrmDate">
                            </ajax:CalendarExtender>
                            <asp:Label Style="color: Red; display: inline;" Visible="false" class="errorMsg"
                                ID="Label1" runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                            <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                TargetControlID="txtFromDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                        </dd>
                        <dt>
                            <asp:Label ID="lbltoEntFromDate" runat="server" Text="<%$Resources:PFSalesResource, ToDate%>"></asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtToDate" runat="server" Width="100" TabIndex="103" CssClass="inputClass"></asp:TextBox>
                            <asp:LinkButton ID="lnkbtnCalBDate" runat="server" Style="float: left" TabIndex="104">
                                <asp:Image ID="imgCalBDate" runat="server" ImageUrl="~/Images/calendar-month.png" /></asp:LinkButton>
                            <ajax:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtToDate"
                                Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="lnkbtnCalBDate">
                            </ajax:CalendarExtender>
                            <asp:Label Style="color: Red; display: inline;" Visible="false" class="errorMsg"
                                ID="lblTotEntFromDateInfo" runat="server" Text="<%$ Resources:PFSalesResource,Setdateformat %>"></asp:Label>
                            <ajax:MaskedEditExtender ID="meeTotEntFrmDate" runat="server" MaskType="Date" Mask="<%$ Resources:PfSalesResource, masktype %>"
                                TargetControlID="txtToDate" MessageValidatorTip="true" ClearMaskOnLostFocus="false">
                            </ajax:MaskedEditExtender>
                        </dd>
                        </dl>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                                ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" TabIndex="112" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$Resources:PFSalesResource,Clear %>" TabIndex="113" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                          </div>
                           <div style="float: right; width: 16%">
                                <asp:Label ID="lblPageSize" runat="server" Text="<%$Resources:PFSalesResource,ViewRecords %>"></asp:Label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="selectClass" Width="55px"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                    <asp:ListItem Value="50" Text="50" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                    <asp:ListItem Value="150" Text="150"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:GridView ID="gvprosp" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                                border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                                AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                                PageSize="50" OnPageIndexChanging="gvprosp_PageIndexChanging" OnSorting="gvprosp_Soring">
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Manufacture %>" SortExpression="CreatedDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("Make") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Source %>" SortExpression="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Leadsource") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,TotalLead  %>" 
                                        SortExpression="MemberNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemberNo" runat="server" Text='<%#Bind("leads") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Allocated  %>" SortExpression="status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("AllocatedCount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,UnAllocated %>" SortExpression="CreatedDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnquiryDate" runat="server" Text='<%#Bind("UnallocatedCount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,DuplicatedCount %>" SortExpression="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("DuplicateCount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,DuplicatedCountReported %>" 
                                        SortExpression="MemberNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemberNo" runat="server" Text='<%#Bind("DuplicateRportCount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,RemovedAllocation %>" SortExpression="status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("RemFrmAllocCount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,FinCarCount %>" SortExpression="status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("FromFinCarCount") %>'></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
