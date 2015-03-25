<%@ Page Title="<%$Resources:PFSalesResource,Resource %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="Resources.aspx.cs"
    Inherits="Resource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" language="javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete Document?")) {
                confirm_value.value = "Yes";
                return true;
            } else {
                confirm_value.value = "No";
                return false;
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpReSource" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkbtnSave" />
            <asp:PostBackTrigger ControlID="lnkbtnAddSource" />
            <asp:PostBackTrigger ControlID="grvDocs" />
        </Triggers>
        <ContentTemplate>
            <div class="mainbdr">
                <asp:Panel ID="pnlSearchSource" runat="server" DefaultButton="lnkbtnSearch">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="SearchSourceHead" runat="server" Text="<%$Resources:PFSalesResource,SearchResource %>"></asp:Label>
                        <div class="addBtn">
                            <asp:LinkButton ID="lnkbtnAddSource" Visible="false" runat="server" ToolTip="<%$Resources:PFSalesResource,AddResrc %>"
                                OnClick="lnkbtnAddSource_Click">
                                <asp:Image ID="imgAddSource" ImageUrl="~/Images/add.png" runat="server" />
                                <asp:Label ID="lblAddSource" runat="server" Text="<%$Resources:PFSalesResource,AddResrc %>">
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
                                <asp:Label ID="lblPropectSource" runat="server" Text="<%$Resources:PFSalesResource,Resource %>"></asp:Label>:
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
                                <asp:ListItem Value="50" Text="50" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                <asp:ListItem Value="150" Text="150"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="divGridDocs">
                            <asp:GridView ID="grvDocs" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                                border="0"  PagerStyle-CssClass="footerpaging" GridLines="None" class="tableGride"
                                AutoGenerateColumns="false" OnRowDataBound="grvDocs_RowDataBound" rule="none"
                                AllowPaging="true" AllowSorting="true" PageSize="50" OnPageIndexChanging="gvSource_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,No %>"  Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Resource %>" SortExpression="ReDocName" ItemStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFileName" runat="server" Text='<%#Bind("ReDocName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,description %>" ItemStyle-Width="40%" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblFilePath" runat="server" Text='<%#Bind("ReDocDesc") %>'></asp:Label>
                                            <asp:HiddenField ID="hdfFilePath" runat="server" Value='<%#Bind("ReDocPath") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Edit %>" Visible="false" ItemStyle-Width="10%" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="<%$Resources:PFSalesResource,EditResource %>"
                                                CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnEdit_Click">
                                    <img src="Images/edit.png"/>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Delete %>" Visible="false" ItemStyle-Width="10%"  >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnDelete" runat="server" ToolTip="<%$Resources:PFSalesResource,Delete %>"
                                                CommandArgument='<%#Eval("Id") %>' OnClientClick="javascript:return Confirm();"
                                                OnClick="lnkbtnDelete_Click">
                                    <img src="Images/delet.png"/>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Download %>"  ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnDownload" runat="server" ToolTip="<%$Resources:PFSalesResource,Download %>"
                                                CommandArgument='<%#Eval("ReDocPath") %>' OnClick="lnkbtnDownload_Click">
                                    <img src="Images/download.png"/>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center">
                                        <asp:Label ID="lblNoDataFound" runat="server" Text="<%$Resources:PFSalesResource,NoResrcFound %>"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlAddSource" runat="server" Visible="false">
                    <%--DefaultButton="lnkbtnSave"--%>
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="lblAddSourceHead" runat="server" Text="<%$Resources:PFSalesResource,AddResrc %>"></asp:Label>
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
                                    *</label><asp:Label ID="lblResrcName" runat="server" Text="<%$Resources:PFSalesResource,ResrcName %>"></asp:Label>:</dt>
                            <dd>
                                <asp:TextBox ID="txtResrcName" CssClass="inputClass" TabIndex="1" runat="server"
                                    MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvResrcName" runat="server" ControlToValidate="txtResrcName"
                                    SetFocusOnError="true" ValidationGroup="Save" Display="None" ErrorMessage="<%$Resources:PFSalesResource,ResrcEnterVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceResrcName" runat="server" TargetControlID="rfvResrcName"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt>
                                <asp:Label ID="lblResrcDoc" runat="server" Text="<%$Resources:PFSalesResource,ResrcDoc %>"></asp:Label>
                            </dt>
                            <dd>
                                <asp:FileUpload ID="fupDocs" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvEmpPhoto" runat="server" ControlToValidate="fupDocs"
                                    ErrorMessage="<%$ Resources:PFSalesResource,MsgSelFileToUpload %>" ValidationGroup="Save"
                                    SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:Label ID="lblResrcDoctxt" runat="server" Visible="false"></asp:Label>
                                <%--<asp:CheckBox ID="chkIsFleetLead" runat="server" TabIndex="3" />--%>
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
    <asp:UpdateProgress ID="upproSource" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpReSource">
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
