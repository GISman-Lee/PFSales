<%@ Page Title="<%$ Resources:PFSalesResource,ForgotPasswordtit %>" Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="style/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager ID="Scripty" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="upPanForgotPass" runat="server">
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
                        <!--Content-Note: error Msg-->
                        <div class="error" id="dvsererror" runat="server" visible="false">
                            <asp:Label ID="lblSerErrMsg" runat="server"></asp:Label>
                        </div>
                        <!--Content-Note: success Msg-->
                        <div class="success" id="dvaserSuccess" runat="server" visible="false">
                            <asp:Label ID="lblSerSucMsg" runat="server"></asp:Label>
                        </div>
                        <!--Content-Note: Please Use ASP:LABEL instead of span-->
                        <dl class="loginFrom">
                            <dt style="padding: 5px;">*<asp:Label ID="lblUserName" runat="server" Text="<%$ Resources:PFSalesResource,UserName %>"></asp:Label>:
                            </dt>
                            <dd style="padding: 5px;">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="inputClass" MaxLength="70"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtUserName"
                                    InitialValue="" SetFocusOnError="true" ValidationGroup="login" Display="None"
                                    EnableClientScript="true" ErrorMessage="<%$Resources:PFSalesResource, UserNameVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceUName" runat="server" TargetControlID="reqName"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator ID="revtxtEmailId" runat="server" ErrorMessage="<%$ Resources:PFSalesResource, invalidemail %>"
                                    ControlToValidate="txtUserName" SetFocusOnError="true" Display="None" ValidationGroup="login"
                                    ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="vceRegEmail" runat="server" TargetControlID="revtxtEmailId"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>
                            <%--<dt>*<asp:Label ID="lblEmail" runat="server" Text="<%$Resources:PFSalesResource,EmailId %>"></asp:Label>:
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="inputClass" MaxLength="250"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="None" ValidationGroup="Save" ErrorMessage="<%$ Resources:PFSalesResource,EmailVal %>"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="rfvEmail"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                            </dd>--%>
                            <dt style="padding: 5px;">
                                <asp:Label ID="lblCaptcha" runat="server" Text="<%$Resources:PFSalesResource,ltlEnterCharacter %>"></asp:Label>
                            </dt>
                            <dd class="subbutton" style="padding: 5px;">
                                <asp:TextBox ID="txtimgcode" runat="server" CssClass="inputClass"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvimgCode" runat="server" ControlToValidate="txtimgcode"
                                    InitialValue="" SetFocusOnError="true" ValidationGroup="login" Display="None"
                                    EnableClientScript="true" ErrorMessage="<%$Resources:PFSalesResource, CaptchaVal %>"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="vceImgCode" runat="server" TargetControlID="rfvimgCode"
                                    PopupPosition="TopRight">
                                </ajax:ValidatorCalloutExtender>
                                <asp:Label ID="lbliCaptchaInfo" CssClass="imginfo" runat="server" Text="<%$Resources:PFSalesResource,captchainfo %>"></asp:Label>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/CImage.aspx" CssClass="captchaDiv" />
                                <asp:LinkButton ID="lnkbtnRefresh" CausesValidation="false" runat="server" ToolTip="<%$Resources:PFSalesResource,CaptchaRefresh %>"
                                    OnClick="lnkbtnRefresh_Click"><img src="images/refresh.png" alt="Refresh" /></asp:LinkButton>
                            </dd>
                            <dt style="padding: 5px;"><span>&nbsp;</span></dt><dd style="padding: 5px;">
                                <div class="button">
                                    <asp:LinkButton ID="lnkbtnSubmit" runat="server" Text="<%$Resources:PFSalesResource,Submit %>"
                                        ToolTip="<%$Resources:PFSalesResource,Submit %>" ValidationGroup="login" OnClick="lnkbtnSubmit_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnCancel" runat="server" Text="<%$Resources:PFSalesResource,Cancel %>"
                                        ToolTip="<%$Resources:PFSalesResource,GotoLogin %>" CausesValidation="false"
                                        OnClick="lnkbtnCancel_Click"></asp:LinkButton>
                                    <a href="UserLogin.aspx" id="hrefLogin" runat="server" visible="false" style="margin-top: 5px;">
                                        <asp:Literal ID="ltlClickToLogin" runat="server" Text="<%$ Resources:PFSalesResource,ltlClickToLogin %>"></asp:Literal>
                                    </a>
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
    <asp:UpdateProgress ID="upproEmp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="upPanForgotPass">
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
    </form>
</body>
</html>
