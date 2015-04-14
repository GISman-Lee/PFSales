<%@ Page Title="<%$Resources:PFSalesResource,ManagePageAccess %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="PageAccess.aspx.cs" Inherits="PageAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function OnTreeClick(evt) {

            var src = window.event != window.undefined ? window.event.srcElement : evt.target;

            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
            if (isChkBoxClick) {
                var parentTable = GetParentByTagName("table", src);
                var nxtSibling = parentTable.nextSibling;
                if (nxtSibling && nxtSibling.nodeType == 1)//check if nxt sibling is not null & is an element node
                {
                    if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
                    {
                        //check or uncheck children at all levels
                        CheckUncheckChildren(parentTable.nextSibling, src.checked);
                    }
                }
                //check or uncheck parents at all levels
                CheckUncheckParents(src, src.checked);
            }
        }
        function CheckUncheckChildren(childContainer, check) {
            var childChkBoxes = childContainer.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            for (var i = 0; i < childChkBoxCount; i++) {
                childChkBoxes[i].checked = check;
            }
        }
        function CheckUncheckParents(srcChild, check) {

            var parentDiv = GetParentByTagName("div", srcChild);
            var parentNodeTable = parentDiv.previousSibling;

            if (parentNodeTable) {
                var checkUncheckSwitch;

                if (check) //checkbox checked
                {
                    //var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                    //if(isAllSiblingsChecked)
                    //    checkUncheckSwitch = true;
                    //else
                    //    return; //do not need to check parent if any(one or more) child not checked

                    checkUncheckSwitch = true;
                }
                else //checkbox unchecked
                {
                    /*Comments By Sujata: uncomment this code if it is required */
                    /*to uncheck parents if a single child is unchekd*/
                    /*///////////////////////////*/
                    //checkUncheckSwitch = false;


                    var isAllSiblingsChecked = AreAllSiblingsUnChecked(srcChild);
                    if (isAllSiblingsChecked)
                        checkUncheckSwitch = false;
                    else
                        return;
                }

                var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");

                if (inpElemsInParentTable.length > 0) {
                    var parentNodeChkBox = inpElemsInParentTable[0];
                    parentNodeChkBox.checked = checkUncheckSwitch;
                    //do the same recursively
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                }
            }

        }

        function AreAllSiblingsUnChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
                {
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        //if any of sibling nodes are not checked, return false
                        if (prevChkBox.checked) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        function AreAllSiblingsChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
                {
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        //if any of sibling nodes are not checked, return false
                        if (!prevChkBox.checked) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        //utility function to get the container of an element by tagname
        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            return parent;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnPage" runat="server">
        <ContentTemplate>
            <div class="mainbdr">
                <div class="innerHeader">
                    <img src="images/Bullate.jpg" alt="icon Img" />
                    <asp:Label ID="SearchEmpHead" runat="server" Text="<%$Resources:PFSalesResource,ManagePageAccess %>"></asp:Label>
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
                            <asp:Label ID="lblRoleName" runat="server" Text="<%$Resources:PFSalesResource,ltlRoleName %>"></asp:Label>:
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="selectClass" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvRole" runat="server" InitialValue="0" ControlToValidate="ddlRole"
                                ErrorMessage="<%$Resources:PFSalesResource,RoleVal %>" ValidationGroup="search"
                                Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vceRole" runat="server" TargetControlID="rfvRole"
                                PopupPosition="TopRight">
                            </ajax:ValidatorCalloutExtender>
                        </dd>
                    </dl>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                            ToolTip="<%$Resources:PFSalesResource,Search %>" OnClick="lnkSearch_Click" ValidationGroup="search"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                            ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkClear_Click"></asp:LinkButton>
                    </div>
                    <asp:Panel ID="pnlDisp" runat="server" Style="float: left; width: 100%; margin-top: 15px;"
                        Visible="false">
                        <table>
                            <%-- class="table table-bordered "--%>
                            <tbody>
                                <tr>
                                    <td>
                                        <div style="height: 400px; overflow-y: scroll;">
                                            <asp:TreeView ID="tvSHAvailable" CssClass="treeview" runat="server" ShowCheckBoxes="All"
                                                ShowLines="True">
                                            </asp:TreeView>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="lnkSave" runat="server" Text="<%$Resources:PFSalesResource,Save %>"
                                ToolTip="<%$Resources:PFSalesResource,Save %>" OnClick="lnkSave_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkCancel_Click"></asp:LinkButton>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkSave" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproEmp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="upnPage">
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
