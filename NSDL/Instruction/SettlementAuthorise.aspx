<%@ Page Title="" Language="C#" MasterPageFile="~/NSDL.Master" AutoEventWireup="true" CodeBehind="SettlementAuthorise.aspx.cs" Inherits="NSDL.Instruction.SettlementAuthorise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/InstructionGrid.ascx" TagPrefix="uc1" TagName="InstructionGrid" %>
<%@ Register Src="~/UserControls/SearchControl.ascx" TagPrefix="uc1" TagName="SearchControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true"></asp:ScriptManager>


    <table border="0" cellpadding="0" style="background-color: #FFFFCC; font-family: Times New Roman; font-size: small" cellspacing="0" width="100%">
        <tr>

            <td valign="top" style="font-weight: bold; background: aqua; font-size: large" colspan="6">
                <strong>Settlement Authorise</strong>
            </td>
        </tr>
        <tr>
            <td align="right" class="clsText" style="width: 15%"><strong>Instruction Type :&nbsp;</strong></td>
            <td class="clsText" style="width: 12%">
                <asp:DropDownList ID="cmbInstructiontype" Width="123px" CssClass="clsText" runat="server">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="904">Off Market</asp:ListItem>
                    <asp:ListItem Value="906">On Market</asp:ListItem>
                    <asp:ListItem Value="925">Inter Depository</asp:ListItem>
                    <asp:ListItem Value="903">Early Pay In</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right" class="clsText" style="width: 12%"><strong>Selection :&nbsp;</strong></td>
            <td class="clsText" style="width: 12%">
                <asp:DropDownList ID="cmbselection" Width="123px" CssClass="clsText" runat="server">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="A">Authorised</asp:ListItem>
                    <asp:ListItem Value="R">Rejected</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="clsText" style="width: 12%"><strong>Sort By :&nbsp;</strong></td>
            <td class="clsText" style="width: 12%">
                <asp:DropDownList ID="cmbsortby" Width="123px" CssClass="clsText" runat="server">
                    <asp:ListItem Value="R">Reference No.</asp:ListItem>
                    <asp:ListItem Value="S">Slip No.</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right" class="clsText" style="width: 12%"><strong>Filter :&nbsp;</strong></td>
            <td class="clsText" style="width: 12%">
                <asp:DropDownList ID="cmbfilter" Width="123px" CssClass="clsText" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbfilter_SelectedIndexChanged">
                    <asp:ListItem Value="S">Slip No.</asp:ListItem>
                    <asp:ListItem Value="E">Execution Date</asp:ListItem>
                    <asp:ListItem Value="T">Transaction Date</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="left"></td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:TextBox ID="txtfiltername" CssClass="clsText" runat="server" Width="100px" MaxLength="16"></asp:TextBox>
                <asp:TextBox ID="txtfilterDate" CssClass="clsText" runat="server" Width="100px" MaxLength="11" Visible="false"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" CssClass="cal_icon" Visible="false" runat="server" ImageUrl="~/Images/Calendar_scheduleHS.png" />
                <cc1:calendarextender id="CalendarExtender1" runat="server" popupbuttonid="ImageButton1" format="dd/MM/yyyy" targetcontrolid="txtfilterDate">
                </cc1:calendarextender>
            </td>

            <td align="right">
                <asp:Button ID="btnfetch" runat="server" CssClass="GoButton" Width="60px" OnClick="btnfetch_Click" Text="Fetch" />
            </td>
            <td align="left">
                <asp:Button ID="btnclear" runat="server" CssClass="GoButton" Width="60px" OnClick="btnclear_Click" Text="Clear" />
            </td>

        </tr>
        <tr>
            <td colspan="6" style="background: aqua;"></td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <div align="center">
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                        <ProgressTemplate>
                            <b>Loading..<img alt="" src="../Images/animated_progress.gif" style="width: 48px; height: 48px" width="15" />.</b>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <asp:Panel ID="PanDetail" runat="server" ScrollBars="Vertical" Height="250px">
                    <asp:GridView Visible="true" ID="Gridview1" runat="server" AutoGenerateColumns="false" Width="80%"
                        OnSelectedIndexChanged="Gridview1_SelectedIndexChanged" OnRowDataBound="Gridview1_RowDataBound">
                        <HeaderStyle CssClass="GridviewHeader" />
                        <SelectedRowStyle BackColor="LightCyan" />
                        <Columns>
                            
                            <asp:BoundField DataField="instcd" HeaderText="Instr No." ></asp:BoundField>
                            <asp:BoundField DataField="otherclid" HeaderText="Slip No."></asp:BoundField>
                            <asp:BoundField DataField="prikey" HeaderText="Sr. No."></asp:BoundField>
                            <asp:BoundField DataField="trxdate" HeaderText="Tr Date"></asp:BoundField>
                            <asp:BoundField DataField="trxdate" HeaderText="Exc Date"></asp:BoundField>
                            <asp:BoundField DataField="isin" HeaderText="ISIN"></asp:BoundField>
                            <asp:BoundField DataField="qty" HeaderText="Quantity"></asp:BoundField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="cmbgridselection" runat="server" CssClass="clsText">
                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Authorise" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="UnAuthorise" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Reject" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>

        <tr>
            <td colspan="6" align="center"></td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <asp:Button ID="btnsignature" Width="60px" runat="server" CssClass="GoButton" Text="Signature" />
                <asp:Button ID="btnsave" runat="server" CssClass="GoButton" Width="60px" Text="Save" />
            </td>
        </tr>
    </table>

</asp:Content>
