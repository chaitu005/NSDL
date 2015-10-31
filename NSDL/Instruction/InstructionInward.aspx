<%@ Page Title="" Language="C#" MasterPageFile="~/NSDL.Master" AutoEventWireup="true" CodeBehind="InstructionInward.aspx.cs" Inherits="NSDL.Instruction.InstructionInward" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../UserControls/InstructionGrid.ascx" TagName="InstructionGrid" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table border="0" cellpadding="0" style="background-color: #FFFFCC; font-family: Times New Roman; font-size: small" cellspacing="0" width="100%">
        <tr style="background-image: url('../../Images/aqua-bg.gif');">
            <td align="center" class="header">Slip Inward 
            </td>
        </tr>
        <tr>
            <td colspan="4" nowrap="nowrap" style="width: 100%; background-color: White">
                <div id="divReceipt" runat="server" style="height: 150px; border: 1%; overflow: scroll;">
                    <uc1:InstructionGrid ID="InstructionGrid1" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" align="center">
                <table class="tblForm" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td align="right">Date :</td>
                            <td align="left">
                                <asp:TextBox ID="txtDt" TabIndex="1" runat="server" EnableViewState="True"
                                    Width="100px" MaxLength="10" TooTip="Please Enter the Date in yyyy-MM-dd Format">
                                </asp:TextBox>
                                <asp:ImageButton ID="imgDate" runat="server" AlternateText="Click to show calendar"
                                    ImageUrl="~/Images/Calendar_scheduleHS.png" CssClass="cal_icon" />
                                <asp:CalendarExtender ID="txtDateCalendar" PopupButtonID="imgDate" runat="server"
                                    TargetControlID="txtDt" Format="yyyy-MM-dd" />
                            </td>
                            <td align="right">Scroll:</td>
                            <td align="left"><asp:TextBox ID="txtScroll" runat="server"></asp:TextBox> </td>
                            <td>&nbsp;</td>
                            <td align="right">&nbsp;</td>
                            <td align="left" class="style1">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">Inst Type. :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlstInstmnt" Width="120px" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlstInstmnt_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="right">Avalibele Lot: </td>

                            <td align="left">
                                <asp:DropDownList ID="ddllotNo" runat="server" CssClass="clsText" AutoPostBack="true" OnSelectedIndexChanged="ddllotNo_SelectedIndexChanged">
                                </asp:DropDownList>
                                &nbsp; 
       
                            </td>
                            <td>Lot Size:</td>
                            <td>
                                <asp:TextBox ID="txtlotsize" runat="server" CssClass="WaterMarked" Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Slip No. : </td>
                            <td align="left">
                                <asp:TextBox ID="txtSrNo" TabIndex="9" runat="server" Width="79px" MaxLength="9" AutoPostBack="true" OnTextChanged="txtSlip_TextChanged">
                                </asp:TextBox>
                            </td>
                            <td align="right">Client  Id:*</td>
                            <td align="left" colspan="2">
                                <asp:TextBox ID="txtClid1" Width="100px" MaxLength="16" CssClass="WaterMarked" Enabled="false" runat="server">
                                </asp:TextBox>
                                <asp:TextBox ID="txtClid2" Width="200px" CssClass="WaterMarked" Enabled="false" runat="server">
                                </asp:TextBox>
                                <%--:Button ID="btnCid" runat="server" CssClass="button" Text="..."></asp:Button>--%>                          </td>


                            <td align="right" class="style1">Ledger Balance :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBalance" runat="server" Width="100px" AutoPostBack="true" CssClass="WaterMarked" Enabled="false"
                                    Style="text-align: right"></asp:TextBox>&nbsp;
                                    <asp:Label ID="lbldrcr" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Instructions  :</td>
                            <td align="left">
                                <asp:TextBox ID="txtinst" runat="server" Width="50px" CssClass="clsText"></asp:TextBox>
                            </td>
                            <td align="right">No of Certificates  :</td>
                            <td align="left">
                                <asp:TextBox ID="txtnoofcert" CssClass="clsText" Width="50px" runat="server">
                                </asp:TextBox>
                            </td>
                            <td></td>
                            <td align="right" class="style1">Execution Date :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtexecdt" TabIndex="1" runat="server" EnableViewState="True"
                                    Width="100px" MaxLength="10" AutoPostBack="True"
                                    ToolTip="Please Enter the Date in yyyy-MM-dd Format"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td align="right">Charges.:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtcharges" CssClass="clsText" Width="50px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">Remarks.:
                            </td>
                            <td align="left" colspan="2">
                                <asp:TextBox ID="txtremarks" CssClass="clsText" Width="350px" runat="server"></asp:TextBox>

                            </td>
                            <td align="right" class="style1">Mode of Delivery :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddl_mode_delivery" runat="server" Height="16px" Width="91px">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="S" Text="Slip"></asp:ListItem>
                                    <asp:ListItem Value="F" Text="Fax"></asp:ListItem>
                                    <asp:ListItem Value="T" Text="Telephone"></asp:ListItem>
                                    <asp:ListItem Value="O" Text="Others"></asp:ListItem>
                                    <asp:ListItem Value="E" Text="E-Mail"></asp:ListItem>
                                    <asp:ListItem Value="V" Text="Verbal"></asp:ListItem>
                                    <asp:ListItem Value="P" Text="POA"></asp:ListItem>
                                    <asp:ListItem Value="C" Text="Courier"></asp:ListItem>
                                    <asp:ListItem Value="H" Text="Hand-Delivery"></asp:ListItem>
                                    <asp:ListItem Value="D" Text="Digital"></asp:ListItem>
                                </asp:DropDownList>
                            </td>

                        </tr>

                    </tbody>
                </table>

            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Height="18px" Width="60px"
                      OnClick ="btnAdd_Click" />&nbsp;
                    <asp:Button ID="Btnupdate" runat="server" Text="Update" Height="18px" Width="60px" OnClick="Btnupdate_Click" />&nbsp;
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Height="18px" Width="60px" OnClick="btnEdit_Click" />&nbsp;
                    <asp:Button ID="btnfind" runat="server" Text="Find" Height="18px" Width="60px" OnClick="btnfind_Click" />&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Height="18px" Width="60px" OnClick="btnDelete_Click"
                         />&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" Height="18px" Width="60px"
                      OnClick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="18px" Width="60px"
                         OnClick="btnCancel_Click" />&nbsp;
                    <asp:Button ID="Btnclose" runat="server" Text="Close" Height="18px" Width="60px" OnClick="Btnclose_Click" />

            </td>

        </tr>


    </table>
</asp:Content>
