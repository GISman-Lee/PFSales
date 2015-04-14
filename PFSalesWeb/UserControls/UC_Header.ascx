<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Header.ascx.cs" Inherits="User_Controls_UC_Header" %>

<script language="javascript" type="text/javascript">
    function fireServerButtonEvent() {//alert('dsf');
        document.getElementById('<%= lnkBtnLogOut.ClientID %>').click();
    } 
</script>

<script type="text/javascript">
    $(document).ready(function() {
        //$(".mm-content-base li ul.subNav").css('display','none');



        var myDiv = $(".megamenu li:last").find("div");
        $(".megamenu li:last").find("a").hover(function() {
            $(myDiv).css("display", "none");
        }, function() {
            $(myDiv).css("display", "none");
        });
    });
</script>

<div class="topnavd" id="dvHtmlMenu" runat="server">
</div>
<asp:LinkButton ID="lnkBtnLogOut" runat="server" Text="logout" CssClass="logout"
    OnClick="lnkbtnLogout_Click" Style="display: none;"></asp:LinkButton>
