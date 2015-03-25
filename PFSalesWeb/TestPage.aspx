<%@ Page Title="" Language="C#" MasterPageFile="~/PFSalesMaster.master" AutoEventWireup="true"
    CodeFile="TestPage.aspx.cs" Inherits="TestPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LinkButton ID="lnkbtnTest" runat="server" Text="test" OnClick="lnkbtnTest_Click"></asp:LinkButton>
    <asp:TextBox ID="txtEncrypted" runat="server"></asp:TextBox>
    <asp:LinkButton ID="lnkbtnShowDecr" runat="server" Text="Show Decrypted" OnClick="lnkbtnShowDecr_Click"></asp:LinkButton>
    <asp:Label ID="lblDecrypted" runat="server"></asp:Label>
</asp:Content>
