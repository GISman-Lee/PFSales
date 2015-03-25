<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ClearActivity.ascx.cs"
    Inherits="UserControls_UC_ClearActivity" %>
<div class="dilContenerTwo" style="float: left; margin: 0px;">
    <div class="tablerView" style="padding: 10px 17px 10px 18px; width: 92.98%;">
        <div class="error" id="dvclrsererror" runat="server" style="width: 91%;" visible="false">
            <asp:Label ID="lblclrSerErrMsg" runat="server"></asp:Label>
        </div>
        <div class="success" id="dvclrserSuccess" runat="server" style="width: 91%;" visible="false">
            <asp:Label ID="lblclrSerSucMsg" runat="server"></asp:Label>
        </div>
        <dl class="addActivityTwo">
            <dt>
                <asp:Label ID="lbltrclrProspect" runat="server" Text="<%$ Resources:PFSalesResource,prospect%>"></asp:Label>
                <asp:HiddenField ID="hdfclrActProsp" runat="server" />
            </dt>
            <dd>
                <asp:Label ID="lblclrActProspect" runat="server" Text="Prospect"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrclrActType" runat="server" Text="<%$Resources:PFSalesResource,ActivityType %>"></asp:Label></dt>
            <dd>
                <asp:Label ID="lblclrActType" runat="server" Text="Activity Type"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrActReg" runat="server" Text="<%$Resources:PFSalesResource,Regarding %>"></asp:Label>:</dt>
            <dd>
                <asp:Label ID="lblActReg" runat="server" Text="Regardings"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrActPrio" runat="server" Text="<%$Resources:PFSalesResource,Priority %>"></asp:Label>:</dt>
            <dd>
                <asp:Label ID="lblActPrio" runat="server" Text="Priority"></asp:Label>
            </dd>
        </dl>
        <div class="headText" style="padding-top: 0px;">
        </div>
        <dl class="addActivityTwo">
            <dt>
                <asp:Label ID="lblltrclrStartDate" runat="server" Text="<%$Resources:PFSalesResource,StartDate%>"></asp:Label></dt>
            <dd>
                <asp:Label ID="lblclrStartDate" runat="server" Text="Start Date"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrclrStartTime" runat="server" Text="<%$Resources:PFSalesResource,StartTime%>"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblclrStartTime" runat="server" Text="Start Time"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrclrEndDate" runat="server" Text="<%$Resources:PFSalesResource,EndDate%>"></asp:Label></dt>
            <dd>
                <asp:Label ID="lblclrEndDate" runat="server" Text="End Date"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrclrEndTime" runat="server" Text="<%$Resources:PFSalesResource,EndTime%>"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblclrEndTime" runat="server" Text="End Time"></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblltrclrLocation" runat="server" Text="<%$ Resources:PFSalesResource,Location%>"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblclrLocation" runat="server" Text="Location"></asp:Label>
            </dd>
        </dl>
        <div class="headText" style="padding-top: 0px;">
        </div>
        <div style="width: 100%; float: left;">
            <b style="float: left; font-size: 16px; margin-bottom: 10px;">
                <asp:Label ID="lblHistoryHead" runat="server" Text="<%$Resources:PFSalesResource,History %>"></asp:Label>
            </b>
        </div>
        <dl class="addActivityThree">
            <dt>
                <label>
                    *</label>
                <asp:Label ID="lblltrclrActStatus" runat="server" Text="<%$Resources:PFSalesResource,ActivityStatus %>"></asp:Label>:
            </dt>
            <dd>
                <asp:DropDownList ID="ddlclrActStatus" CssClass="selectClass" runat="server" Width="300px">
                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvclrActStatus" runat="server" ControlToValidate="ddlclrActStatus"
                    Display="None" InitialValue="0" ValidationGroup="ClearActt" ErrorMessage="<%$ Resources:PFSalesResource,ActStatusVal %>"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="vceclrActStatus" runat="server" TargetControlID="rfvclrActStatus"
                    PopupPosition="TopRight">
                </ajax:ValidatorCalloutExtender>
            </dd>
            <dt>
                <label>
                    *</label>
                <asp:Label ID="lblltrclrRemark" runat="server" Text="<%$Resources:PFSalesResource,Remark %>"></asp:Label>
            </dt>
            <dd>
                <asp:TextBox ID="txtclrRemark" runat="server" Style="height: auto;" CssClass="inputClass"
                    TextMode="MultiLine" Width="296px" Rows="4" MaxLength="500"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNotes" runat="server" ControlToValidate="txtclrRemark"
                    Display="None" ValidationGroup="ClearActt" ErrorMessage="<%$ Resources:PFSalesResource,NotesVal %>"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="vceNotes" runat="server" TargetControlID="rfvNotes"
                    PopupPosition="TopRight">
                </ajax:ValidatorCalloutExtender>
            </dd>
            <dt>
                <asp:Label ID="lbltrclrAttachment" runat="server" Text="<%$Resources:PFSalesResource,Attachment %>"></asp:Label>
            </dt>
            <dd>
                <asp:FileUpload ID="fpclrAttachment" runat="server" Width="320px" />
            </dd>
            <dt>
                <label>
                    *</label>
                <asp:Label ID="lblltrclrStatus" runat="server" Text="<%$Resources:PFSalesResource,Status %>"></asp:Label>:
            </dt>
            <dd>
                <asp:DropDownList ID="ddlclrStatus" CssClass="selectClass" runat="server" Width="300px">
                    <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvLeadStatus" runat="server" ControlToValidate="ddlclrStatus"
                    Display="None" InitialValue="0" ValidationGroup="ClearActt" ErrorMessage="<%$ Resources:PFSalesResource,StatusVal %>"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="vceLeadStatus" runat="server" TargetControlID="rfvLeadStatus"
                    PopupPosition="TopRight">
                </ajax:ValidatorCalloutExtender>
            </dd>
        </dl>
        <div class="headText" style="padding-top: 0px;">
        </div>
        <div class="button">
            <asp:LinkButton ID="lnkbtnclrSaveAct" runat="server" Text="<%$Resources:PFSalesResource,Save %>"
                ToolTip="<%$Resources:PFSalesResource,SaveActResult %>" ValidationGroup="ClearActt"
                OnClick="lnkbtnclrSaveAct_Click"></asp:LinkButton>
            <asp:LinkButton ID="lnkbtnclrCancel" runat="server" Visible="false" Text="<%$Resources:PFSalesResource,Clear %>"
                ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnclrCancel_Click"
                CausesValidation="false"></asp:LinkButton>
        </div>
        <asp:HiddenField ID="hdfclrActId" runat="server" />
        <asp:HiddenField ID="hdfActivityDoc" runat="server" />
    </div>
</div>
