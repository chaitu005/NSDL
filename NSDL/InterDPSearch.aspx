<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterDPSearch.aspx.cs" Inherits="NSDL.Instruction.InterDPSearch" %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div>
            <table border='0' width='70%'>
                <tr>
                    <td width="20">&nbsp;</td>
                    <td>Search on :</td>
                    <td>
                        <asp:DropDownList ID="optSelect" runat="server" onselect="document.IntDepSearch.txtSearch.focus();">
                            <asp:ListItem Text="Internal ref. no" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Scroll No." Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td>
                        <asp:TextBox ID="txtSearch" runat="server" size="18" MaxLength="16"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="cmdSearch" runat="server" Text="Search" Style="color: #FFFFFF; background-color: #000080; position: relative; width: 60px; height: 21px; font-size: 10px" OnClick="cmdSearch_Click" />
                    </td>
                </tr>
            </table>

        </div>
        <div>
            <asp:UpdatePanel ID="upt1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:GridView ID="grd_Search" ShowHeaderWhenEmpty="true" runat="server" OnRowDataBound="grd_Search_RowDataBounds" OnRowCommand="grd_Search_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Code") %>' runat="server">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </form>
</body>
</html>
