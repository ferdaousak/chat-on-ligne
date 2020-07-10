<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usSalon.ascx.cs" Inherits="ChatRoom.usSalon" %>
<style type="text/css">
    .auto-style1 {
        width: 50%;
        margin-left: 86px;
        margin-top: 48px;
    }
    .auto-style2 {
        margin-left: 40px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="salonId" runat="server" Text="[lblSalon]"></asp:Label>
            <asp:Label ID="nomId" runat="server" Text="[lblNom]"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="desId" runat="server" Text="[lblDes]"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>Creer le :
            <asp:Label ID="dateId" runat="server" Text="[lblDate]"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Participer</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="LinkMd" runat="server" OnClick="LinkMd_Click">Modifier</asp:LinkButton>
            <asp:Label ID="idProfil" runat="server" Text="[lblIdProfil]"></asp:Label>
            <asp:LinkButton ID="LinkSp" runat="server" OnClick="LinkSp_Click">Supprimer</asp:LinkButton>
        </td>
    </tr>
</table>

