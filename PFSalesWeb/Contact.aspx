<%@ Page Title="" Language="C#" MasterPageFile="~/PFSalesMaster.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPanPrspect" runat="server">
        <ContentTemplate>
            <div class="mainbdr">
                <asp:Panel ID="pnlSearchprosp" runat="server">
                    <%--                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="SearchprospHead" runat="server" Text="<%$Resources:PFSalesResource,SearchProspect %>"></asp:Label>
                        <div class="addBtn">
                            <asp:LinkButton ID="lnkbtnAddprosp" runat="server" ToolTip="<%$Resources:PFSalesResource,Addprospect %>"
                                OnClick="lnkbtnAddprosp_Click">
                                <asp:Image ID="imgAddprosp" ImageUrl="~/Images/add.png" runat="server" />
                                <asp:Label ID="lblAddprosp" runat="server" Text="<%$Resources:PFSalesResource,Addprospect %>"> </asp:Label></asp:LinkButton>
                        </div>
                    </div>
                    <div class="dilContener">
                        <div class="error" id="dvsererror" runat="server" visible="false">
                            <asp:Label ID="lblSerErrMsg" runat="server"></asp:Label>
                        </div>
                        <div class="success" id="dvaserSuccess" runat="server" visible="false">
                            <asp:Label ID="lblSerSucMsg" runat="server"></asp:Label>
                        </div>
                        <dl class="dealerRagisterTwo">
                            <dt>
                                <asp:Label ID="lblprospName" runat="server" Text="<%$Resources:PFSalesResource,Name %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtserprospName" CssClass="inputClass" runat="server"></asp:TextBox>
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
                        <div class="headText">
                        </div>
                        <div class="button">
                            <asp:LinkButton ID="LinkButton4" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                                ToolTip="<%$Resources:PFSalesResource,Searchprosp %>" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton5" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                ToolTip="<%$Resources:PFSalesResource,Clear %>" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                        </div>
                        <asp:GridView ID="gvprosp" runat="server" CellSpacing="0" Width="100%" CellPadding="0"
                            border="0" class="tableGride" PagerStyle-CssClass="footerpaging" GridLines="None"
                            AutoGenerateColumns="false" rule="none" AllowPaging="true" AllowSorting="true"
                            PageSize="5" OnPageIndexChanging="gvprosp_PageIndexChanging" OnSorting="gvprosp_Soring"
                            OnRowDataBound="gvprosp_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,status %>" SortExpression="status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Name %>" SortExpression="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprospName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,EmailId %>" SortExpression="EmailId">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmailId" runat="server" Text='<%#Bind("EmailId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,MobileNo %>" SortExpression="MobileNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobileNo" runat="server" Text='<%#Bind("MobileNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Edit %>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="<%$Resources:PFSalesResource,Editprosp %>"
                                            CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnEdit_Click">
                                    <img src="Images/edit.png"/>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:PFSalesResource,Delete %>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" ToolTip="<%$Resources:PFSalesResource,Deleteprosp %>"
                                            CommandArgument='<%#Eval("Id") %>' OnClick="lnkbtnDelete_Click"> 
                                    <img src="Images/delet.png"/>
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
                    </div>--%>
                </asp:Panel>
                <asp:Panel ID="pnlAddCon" runat="server" Visible="true">
                    <div class="innerHeader">
                        <img src="images/Bullate.jpg" alt="icon Img" />
                        <asp:Label ID="SearchEmpHead" runat="server" Text="<%$Resources:PfSalesResource,AddContact %>"></asp:Label>
                        <div class="addBtn">
                            <asp:LinkButton ID="lnkbtnBackToSearch" runat="server" ToolTip="<%$Resources:PFSalesResource,BackToSearch %>">
                                <asp:Image ID="imgBackToSearch" ImageUrl="~/Images/back.png" runat="server" />
                                <asp:Label ID="lblBackToSearch" runat="server" Text="<%$Resources:PFSalesResource,BackToSearch %>"></asp:Label>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="dilContener" style="margin: 2.05em 2em; width: 95%;">
                        <div class="tablerBtn">
                            <asp:LinkButton ID="lnkbtnBasicinfo" runat="server" Text="<%$Resources:PfSalesResource,BasicInfo%>"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnPersonalInfo" runat="server" Text="<%$Resources:PfSalesResource,PersonalInfo%>">
                            </asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnConAcceLevel" CssClass="tablerBtnActive" runat="server"
                                Text="<%$Resources:PfSalesResource,ContactAccessLevel%>"></asp:LinkButton>
                        </div>
                        <asp:Panel ID="pnlBasicInfo" runat="server">
                        </asp:Panel>
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
                                           <%-- Mr. Pravin Balasaheb Gholap--%>
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
                                            Mr. Pravin Balasaheb Gholap
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
                <asp:Panel ID="pnlphonePopUp" runat="server" Visible="false">
                    <%--                    <div class="pop-up">
                    </div>
                    <div class="contentPopUp">
                        <div class="popHeader">
                            <asp:Label ID="lblPhPopUpPhone" runat="server" Text="<%$ Resources:PFSalesResource,EnterPhoneNumber%>"></asp:Label>
                            <asp:LinkButton ID="lnkbtnPhPopClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                                OnClick="lnkbtnPhPopClose_Click"><img src="Images/delet.png"/></asp:LinkButton>
                        </div>
                        <div class="dilContenerTwo">
                            <dl class="settled">
                                <dt>
                                    <asp:Label ID="lblPhPopUpCountry" runat="server" Text="<%$ Resources:PFSalesResource,Country%>"></asp:Label>:</dt>
                                <dd>
                                    <asp:DropDownList ID="ddlPhPopUpCountry" CssClass="selectClass" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPhPopUpCountry_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </dd>
                                <dt>
                                    <asp:Label ID="lblPhFormat" runat="server" Text="<%$Resources:PFSalesResource,Format %>"></asp:Label>:</dt>
                                <dd>
                                    <asp:DropDownList ID="ddlPhFormat" CssClass="selectClass" runat="server">
                                        <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </dd>
                                <dt>
                                    <asp:Label ID="lblPhPopUpPhNo" runat="server" Text="<%$Resources:PFSalesResource,PhoneNo%>"></asp:Label>:</dt>
                                <dd>
                                    <asp:TextBox ID="txtPhPopUpPhoNo" CssClass="inputClass" runat="server"></asp:TextBox>
                                </dd>
                            </dl>
                            <div class="headText">
                            </div>
                            <div class="button">
                                <asp:LinkButton ID="lnkbtnEditFormat" runat="server" Text="<%$Resources:PFSalesResource,EditFormats %>"
                                    ToolTip="<%$Resources:PFSalesResource,EditFormatToolTip %>" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnPhPoUpOk" runat="server" Text="<%$Resources:PFSalesResource,OK %>"
                                    ToolTip="<%$Resources:PFSalesResource,OK %>" OnClick="lnkbtnPhPoUpOk_Click"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnPhPopUpCancel" runat="server" Text="<%$Resources:PFSalesResource,Cancel %>"
                                    ToolTip="<%$Resources:PFSalesResource,Close %>" OnClick="lnkbtnPhPopClose_Click"></asp:LinkButton></div>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdfFName" runat="server" />
                    <asp:HiddenField ID="hdfMName" runat="server" />
                    <asp:HiddenField ID="hdfLName" runat="server" />
                    <asp:HiddenField ID="hdfPhoneFormat" runat="server" />--%>
                </asp:Panel>
            </div>
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
