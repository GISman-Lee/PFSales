<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ClearActivityDetails.ascx.cs"
    Inherits="UserControls_UC_ClearActivityDetails" %>
<div class="dilContenerTwo" style="float: left; margin: 0px;">
    <div class="tablerView" style="padding: 10px 17px; width: 92.98%;">
        <dl class="addActivityTwo">
            <dt>
                <asp:Label ID="lblltrClrActDetProsp" runat="server" Text="<%$ Resources:PFSalesResource,prospect%>"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblClrActDetProsp" runat="server" Text="Prospect"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrClrActDetActType" runat="server" Text="<%$Resources:PFSalesResource,ActivityType %>"></asp:Label></dt>
            <dd>
                <asp:Label ID="lblClrActDetActType" runat="server" Text="Activity Type"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrClrActDetReg" runat="server" Text="<%$Resources:PFSalesResource,Regarding %>"></asp:Label>:</dt>
            <dd>
                <asp:Label ID="lblClrActDetReg" runat="server" Text="Regardings"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrClrActDetPrio" runat="server" Text="<%$Resources:PFSalesResource,Priority %>"></asp:Label>:</dt>
            <dd>
                <asp:Label ID="lblClrActDetPrio" runat="server" Text="Priority"></asp:Label>
            </dd>
        </dl>
        <div class="headText" style="padding-top: 0px;">
        </div>
        <dl class="addActivityTwo">
            <dt>
                <asp:Label ID="lblltrClrActDetSDate" runat="server" Text="<%$Resources:PFSalesResource,StartDate%>"></asp:Label></dt>
            <dd>
                <asp:Label ID="lblClrActDetSDate" runat="server" Text="Start Date"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrClrActDetSTime" runat="server" Text="<%$Resources:PFSalesResource,StartTime%>"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblClrActDetSTime" runat="server" Text="Start Time"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrClrActDetEDate" runat="server" Text="<%$Resources:PFSalesResource,EndDate%>"></asp:Label></dt>
            <dd>
                <asp:Label ID="lblClrActDetEDate" runat="server" Text="End Date"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrClrActDetETime" runat="server" Text="<%$Resources:PFSalesResource,EndTime%>"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblClrActDetETime" runat="server" Text="End Time"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrClrActDetLoc" runat="server" Text="<%$ Resources:PFSalesResource,Location%>"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblClrActDetLoc" runat="server" Text="Location"></asp:Label>
            </dd>
        </dl>
        <div class="headText" style="padding-top: 0px;">
        </div>
        <dl class="addActivityFour">
            <dt>
                <asp:Label ID="LblltrClrActDetActStatus" runat="server" Text="<%$Resources:PFSalesResource,ActivityStatus %>"></asp:Label>:
            </dt>
            <dd>
                <asp:Label ID="LblClrActDetActStatus" runat="server"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="LblltrClrActDetRemark" runat="server" Text="<%$Resources:PFSalesResource,Remark %>"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="LblClrActDetRemark" runat="server"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="LblltrClrActDetAttachment" runat="server" Text="<%$Resources:PFSalesResource,Attachment %>"></asp:Label>
            </dt>
            <dd>
                <asp:LinkButton ID="lnkbtnclrActDetAttachment" runat="server" Text="<%$Resources:PFSalesResource,Download %>"
                    ToolTip="<%$Resources:PFSalesResource,DownloadAttachment %>" OnClick="lnkbtnclrActDetAttachment_Click">
                </asp:LinkButton>
            </dd>
            <dt>
                <asp:Label ID="lblltrclrActDetStatus" runat="server" Text="<%$Resources:PFSalesResource,Status %>"></asp:Label>:
            </dt>
            <dd>
                <asp:Label ID="lblclrActDetStatus" runat="server"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrclrActDetClearedDate" runat="server" Text="<%$Resources:PFSalesResource,ClearedDate %>"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblclrActDetClearedDate" runat="server"></asp:Label>
            </dd>
        </dl>
    </div>
    <asp:HiddenField ID="hdfActivityDoc" runat="server" />
</div>
