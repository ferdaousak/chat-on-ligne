<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="ChatRoom.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 500px;
        }
        .auto-style2 {
            height: 19px;
            width: 149px;
            margin-left: 106px;
            margin-top: 33px;
        }
        .auto-style3 {
            width: 221%;
            height: 271px;
            margin-left: 0px;
            margin-top: 46px;
        }
        .auto-style4 {
            width: 111px;
        }
        .auto-style5 {
            color: #FF0000;
        }
        .auto-style6 {
            width: 203px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <p class="auto-style2">
                Inscription<table class="auto-style3">
                    <tr>
                        <td class="auto-style4">Nom complet</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="nom" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                            <br />
                            <asp:Label ID="nomVer" runat="server" Text="vous devez saisir votre nom" CssClass="auto-style5" Visible="False" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">E-mail</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="email" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="emailVer" runat="server" CssClass="auto-style5" Text="vous devez saisir votre email" Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="invalide" runat="server" CssClass="auto-style5" Text="email invalide!" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">username</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="username" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="userVer" runat="server" CssClass="auto-style5" Text="vous devez saisir un username" Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="userExiste" runat="server" CssClass="auto-style5" Text="username déja existe!" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">mot de passe</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="mdp" runat="server" TextMode="Password"></asp:TextBox>
                            <br />
                            <asp:Label ID="mdpVer" runat="server" CssClass="auto-style5" Text="vous devez saisir mdp" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">confirmer mot de passe</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="confirmeMdp" runat="server" TextMode="Password"></asp:TextBox>
                            <br />
                            <asp:Label ID="confirmVer" runat="server" CssClass="auto-style5" Text="vous devez saisir le mdp a nouveau" Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="mdpIncc" runat="server" CssClass="auto-style5" Text="le mdp n'est pas correct" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style6">
                            <asp:Button ID="inscrire" runat="server" OnClick="Button1_Click1" Text="s'inscrire" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:HyperLink ID="connecter" runat="server" NavigateUrl="~/Auth.aspx">déja un compte? se connecter</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </p>
        </div>
    </form>
</body>
</html>
