<%@ Page Language="C#" MasterPageFile="~/PFSalesMaster.master" AutoEventWireup="true"
    CodeFile="AddContact.aspx.cs" Inherits="AddContact" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainbdr">
        <!--Content-Note: Please Use ASP:LABEL instead of span-->
        <asp:Panel ID="pnlSearchEmployee" runat="server">
            <div class="innerHeader">
                <img src="images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="SearchEmpHead" runat="server" Text="Add Contact"></asp:Label>
                <div class="addBtn">
                    <asp:LinkButton ID="lnkbtnAddEmp" runat="server" ToolTip="Search Contact">
                        <asp:Image ID="imgAddEmp" ImageUrl="~/Images/add.png" runat="server" />
                        <asp:Label ID="lblAddEmp" runat="server" Text="Search Contact">
                        </asp:Label>
                    </asp:LinkButton>
                </div>
            </div>
            <div class="dilContener" style="margin: 2.05em 2em; width: 95%;">
                <div class="tablerBtn">
                    <asp:LinkButton ID="LinkButton1" runat="server">Basic Information </asp:LinkButton><asp:LinkButton
                        ID="LinkButton2" runat="server">Personal Information 
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" CssClass="tablerBtnActive"  runat="server">Contact Access Level</asp:LinkButton></div>
                <div class="tablerView">
                    <dl class="dealerRagisterTwo">
                        <dt>
                            <asp:Label ID="lblempName" runat="server" Text="Select Contact Access level"></asp:Label>:
                        </dt>
                        <dd style="width: 600px;">
                            <asp:RadioButtonList ID="CheckBoxList1" RepeatDirection="Horizontal" CssClass="allchklist"
                                runat="server">
                                <asp:ListItem Text="Private"></asp:ListItem>
                                <asp:ListItem Text="Public"></asp:ListItem>
                                <asp:ListItem Text="Selected list of users"></asp:ListItem>
                            </asp:RadioButtonList>
                        </dd>
                    </dl>
                    <table cellspacing="0" cellpadding="0" border="0" width="100%" class="tableGride">
                        <tbody>
                            <tr>
                                <th>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </th>
                                <th>
                                    <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="Label3" runat="server" Text="Mobile "></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="Label4" runat="server" Text="Phone"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </td>
                                <td>
                                    Title
                                </td>
                                <td>
                                    <%--Mr. Pravin Balasaheb Gholap--%>
                                </td>
                                <td>
                                    9881392684
                                </td>
                                <td>
                                    9881392684
                                </td>
                                <td>
                                    <%--pravin.gholap@mechsoftgroup.com--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBox3" runat="server" />
                                </td>
                                <td>
                                    Title
                                </td>
                                <td>
                                    <%--Mr. Pravin Balasaheb Gholap--%>
                                </td>
                                <td>
                                    9881392684
                                </td>
                                <td>
                                    9881392684
                                </td>
                                <td>
                                    <%--pravin.gholap@mechsoftgroup.com--%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="headText">
                    </div>
                    <div class="button">
                        <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="Search" ToolTip="SearchEmp"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnClear" runat="server" Text="Clear" ToolTip="Clear"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <!--Content-->
    </div>
</asp:Content>
