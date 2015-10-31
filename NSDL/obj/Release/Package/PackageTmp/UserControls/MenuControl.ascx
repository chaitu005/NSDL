<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="NSDL.UserControls.MenuControl" %>
<link href="../Styles/KyCDefault.css" rel="stylesheet" type="text/css" />
<table width="100%">
    <tr>
        <td style="width: 100%">
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
                DynamicEnableDefaultPopOutImage="False" StaticEnableDefaultPopOutImage="False">
                <StaticMenuStyle CssClass="StaticMenuStyle" />
                <StaticMenuItemStyle CssClass="StaticMenuItemStyle" />
                <DynamicMenuStyle CssClass="DynamicMenuStyle" />
                <DynamicMenuItemStyle CssClass="DynamicMenuItemStyle" />
            </asp:Menu>

        </td>
    </tr>
</table>