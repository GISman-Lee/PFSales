<%@ Page Title="<%$Resources:PFSalesResource, UserLogin %>" Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="style/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager ID="scripty" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="upPanLogin" runat="server">
        <ContentTemplate>
            <div id="wrapper">
                <!--Header-->
                <div class="header">
                    <div class="logo">
                    </div>
                    <div class="banner">
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <!--Header-->
                <!--Menu-->
                <div class="topnavd">
                    <div class="logout">
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <!--Menu-->
                <!--Content Main-->
                <div class="maincontaint">
                    <div class="mainbdr">
                        <div class="error" style="margin-left: 8px; width: 94%;" id="dvsererror" runat="server"
                            visible="false">
                            <asp:Label ID="lblSerErrMsg" runat="server"></asp:Label>
                        </div>
                        <!--Content-Note: Please Use ASP:LABEL instead of span-->
                        <dl class="loginFrom">
                            <%-- <dt><span>&nbsp;</span></dt>
                    <dd>
                        <div class="orgText">
                            LEAD SALES</div>
                    </dd>--%>
                            <dt style="padding: 5px;">
                                <asp:Label ID="lblUserName" runat="server" Text="<%$Resources:PFSalesResource, UserName %>"></asp:Label>
                            </dt>
                            <dd style="padding: 5px;">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="inputClass" placeholder="<%$Resources:PFSalesResource, UserName %>"
                                    MaxLength="70" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtUsername"
                                    InitialValue="" SetFocusOnError="true" ValidationGroup="login" Display="None"
                                    EnableClientScript="true" ErrorMessage="<%$Resources:PFSalesResource, UserNameVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceUName" runat="server" TargetControlID="reqName"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                               <%-- <asp:RegularExpressionValidator ID="revtxtEmailId" runat="server" ErrorMessage="<%$ Resources:PFSalesResource, invalidemail %>"
                                    ControlToValidate="txtUsername" SetFocusOnError="true" Display="None" ValidationGroup="login"
                                    ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceRegEmail" runat="server" TargetControlID="revtxtEmailId"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>--%>
                            </dd>
                            <dt style="padding: 5px;">
                                <asp:Label ID="lblPassword" runat="server" Text="<%$Resources:PFSalesResource, Password %>"></asp:Label>
                            </dt>
                            <dd style="padding: 5px;">
                                <asp:TextBox ID="txtPassword" runat="server" class="inputClass" placeholder="<%$Resources:PFSalesResource, Password %>"
                                    MaxLength="90" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqPass" runat="server" ControlToValidate="txtPassword"
                                    InitialValue="" Display="None" SetFocusOnError="true" ValidationGroup="login"
                                    EnableClientScript="true" ErrorMessage="<%$Resources:PFSalesResource, PasswordVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vcePassword" runat="server" TargetControlID="reqPass"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <dt style="padding: 5px;"><span>&nbsp;</span></dt>
                            <dd class="subbutton" style="padding: 5px;">
                                <asp:CheckBox ID="chkRememberMe" runat="server" Text="<%$Resources:PFSalesResource, RememberMe %>" />
                            </dd>
                            <dt><span>&nbsp;</span></dt>
                            <dd class="subbuttonTwo">
                                <asp:LinkButton ID="lnkbtnForgotPass" runat="server" Text="<%$Resources:PFSalesResource, ForgotPassword %>"
                                    OnClick="lnkbtnForgotPass_Click" CausesValidation="false"></asp:LinkButton>
                            </dd>
                            <dt style="padding: 5px;"><span>&nbsp;</span></dt>
                            <dd style="padding-right: 5px; padding-left:120px;padding-top: 5px;padding-bottom: 5px;">
                                <div class="button">
                                    <asp:LinkButton ID="lnkbtnSubmit" runat="server" ValidationGroup="login" Text="<%$Resources:PFSalesResource, Submit %>"
                                        OnClick="lnkbtnSubmit_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnCancel" runat="server" CausesValidation="false" Text="<%$Resources:PFSalesResource, Cancel %>"
                                        OnClick="lnkbtnCancel_Click"></asp:LinkButton>
                                    <%--   <a href="#">Submit</a> <a href="#">Cancel</a>--%>
                                </div>
                            </dd>
                        </dl>
                        <!--Content-->
                    </div>
                </div>
                <!--Content Main-->
                <div class="clear">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproProsp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="upPanLogin">
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
    </form>
</body>
</html>
