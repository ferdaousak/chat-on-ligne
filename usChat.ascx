<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usChat.ascx.cs" Inherits="ChatRoom.usChat" %>
<style type="text/css">
    .auto-style1 {
        width: 62%;
        margin-left: 109px;
        margin-top: 52px;
    }
    .auto-style2 {
        margin-left: 160px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="userNom" runat="server" Text="[lblnomUser]"></asp:Label>
        </td>
        <td>
            <asp:Label ID="MsgID" runat="server" Text="[lblMsgUser]"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="dateIdlbl" runat="server" Text="[lbldate]"></asp:Label>
        </td>
    </tr>
</table>

