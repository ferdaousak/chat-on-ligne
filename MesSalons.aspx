<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MesSalons.aspx.cs" Inherits="ChatRoom.MesSalons" %>

<%@ Register Src="~/usSalon.ascx" tagPrefix="uc1" tagName="usSalon" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Les salons
        </p>
        <div>
            <asp:Button ID="btnAddSalon" runat="server" OnClick="btnAddSalon_Click" Text="Ajouter un salon" />
        </div>
        <div>
            <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updateSalons" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger  ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Repeater ID="repeaterSalon" runat="server" OnItemDataBound="RepeaterSalon_ItemDataBound">
                    <ItemTemplate>
                        <div id="rpt">
                            <uc1:usSalon runat="server" id="usSalon" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="500">
        </asp:Timer>
    </form>
</body>
</html>
