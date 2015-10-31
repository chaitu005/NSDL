<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterSearch.aspx.cs" Inherits="NSDL.MasterSearch" %>

<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="width: 100%; vertical-align: middle;">
            <fieldset>
                <legend><span>Search </span></legend>
                <table style="width: 100%;">
                    <tr>
                        <td class="lable">
                            <asp:Label ID="txtsearchby" runat="server" Text="Searchby"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbsort1" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbcondition" AutoPostBack="true" runat="server">
                                <asp:ListItem Value="sc_like_name" Selected="True" runat="server">Like</asp:ListItem>
                                <asp:ListItem Value="sc_equal_name" runat="server">Equal</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtlike" CssClass="TextBOX" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" class="style1">
                            <asp:Button ID="btngo" runat="server" CssClass="button" Text="......." OnClick="btngo_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <div align="center" style="overflow: scroll; width: auto; height: 500px; left: auto">
                                <table id="tbl11" runat="server">
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="upt1" runat="server" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBounds"
                                                        OnRowCommand="GridView1_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Code">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Code") %>' runat="server"></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
