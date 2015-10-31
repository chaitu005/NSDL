<%@ Page Title="" Language="C#" MasterPageFile="~/NSDL.Master" AutoEventWireup="true"
    CodeBehind="OnMarket.aspx.cs" Inherits="NSDL.Instruction.OnMarket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/InstructionGrid.ascx" TagPrefix="uc1" TagName="InstructionGrid" %>
<%@ Register Src="~/UserControls/SearchControl.ascx" TagPrefix="uc1" TagName="SearchControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td colspan="6" class="FormHeader">
                        &nbsp;Normal Pay in
                    </td>
                </tr>
                <tr style="height: 1px; background-color: #FFFFCC;">
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Instrument Type :&nbsp;
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cmbInstructionType" AutoPostBack="false" runat="server" Width="160px"
                            CssClass="clsLabel" DataValueField="im_instcd" DataTextField="im_desc">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Normal Payin"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        Transaction Date :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTransactionDt" onkeypress="mydate(this);" AutoPostBack="true"
                            Width="80px" CssClass="clsText" MaxLength="11" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="cal_image1" CssClass="cal_icon" runat="server" ImageUrl="~/Images/Calendar_scheduleHS.png"
                            AlternateText="Click Here To Show Calender" />
                        <asp:CalendarExtender ID="cal_extender1" TargetControlID="txtTransactionDt" PopupButtonID="cal_image1"
                            runat="server" Format="dd/MM/yyyy" />
                        <td align="right">
                        </td>
                        <td align="right">
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        Internal Ref No :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtInternalRefNo" runat="server" onkeypress="CheckNo(15);" Width="90px"
                            AutoPostBack="true" CssClass="clsText" MaxLength="15" OnTextChanged="txtInternalRef_TextChanged"></asp:TextBox>
                    </td>
                    <td align="right">
                        Slip No :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtslipno" runat="server" onkeypress="CheckNo(15);" Width="90px"
                            AutoPostBack="true" CssClass="clsText" MaxLength="15" OnTextChanged="txtInternalRef_TextChanged"></asp:TextBox>
                    </td>
                    <td align="right">
                        Tarnsation No :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txttras" runat="server" Width="100px" CssClass="clsText">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        BO ID :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtClientId" runat="server" Width="100px" AutoPostBack="True" CssClass="clsText"
                            MaxLength="16" OnTextChanged="txtClientId_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtClientName" runat="server" Width="150px" MaxLength="30" CssClass="WaterMarked"></asp:TextBox>
                    </td>
                    <td align="right">
                    </td>
                    <td align="right">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Execution Date :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtExecutionDt" onkeypress="mydate(this);" Width="80px" CssClass="clsText"
                            AutoPostBack="true" MaxLength="11" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" CssClass="cal_icon" runat="server" ImageUrl="~/Images/Calendar_scheduleHS.png"
                            AlternateText="Click Here To Show Calender" />
                        <asp:CalendarExtender ID="cal_extender2" TargetControlID="txtTransactionDt" PopupButtonID="cal_image1"
                            runat="server" Format="dd/MM/yyyy" />
                    </td>
                    <td align="right">
                        Joint Holder 1 :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtjntholder1" runat="server" Width="200px" CssClass="WaterMarked">
                        </asp:TextBox>
                    </td>
                    <td align="right">
                        Lot No :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtlotno" CssClass="WaterMarked" runat="server" Width="100px">
                        </asp:TextBox>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Ledger Balance :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtBalance" runat="server" Width="100px" AutoPostBack="true" Enabled="false"
                            Style="text-align: right">
                        </asp:TextBox>&nbsp;
                        <asp:Label ID="lbldrcr" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        Joint Holder 2 :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtlblJH2" runat="server" Width="200px" CssClass="WaterMarked">
                        </asp:TextBox>
                    </td>
                    <td align="right">
                        Lot Size:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtlotsize" runat="server" CssClass="WaterMarked">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Receive Mode :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cmbReceiptMode" runat="server" CssClass="clsLabel" Width="99px"
                            AutoPostBack="False">
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
                    <td align="right">
                        <asp:CheckBox ID="chkLateFees" Font-Bold="true" AutoPostBack="True" Text=" Late Fees :"
                            runat="server" OnCheckedChanged="chkLateFees_CheckedChanged"></asp:CheckBox>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLateFees" runat="server" onkeypress="CheckNo(15);" MaxLength="7"
                            Width="110px" AutoPostBack="true" CssClass="clsText">
                        </asp:TextBox>
                    </td>
                    <td align="right">
                        No of Instruction:
                    </td>
                    <td align="left">
                        <asp:TextBox ID='txtinst' runat="server" Width="100px" CssClass="WaterMarked"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                    </td>
                    <td align="right">
                    </td>
                    <td align="right">
                    </td>
                </tr>
            </table>
            <div id="divGrid" runat="server" style="width: 100%; height: 150px; overflow: auto;">
                <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="GrdOnMarket" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true"
                                Width="90%" OnSelectedIndexChanged="GrdOnMarket_SelectedIndexChanged" OnSelectedIndexChanging="GrdOnMarket_SelectedIndexChanging"
                                DataKeyNames="cm_name,tb_trx_date,tb_exec_date,tb_client_id,oc_amt,tb_obligationid,tb_serialno,tb_trx_allow">
                                <HeaderStyle CssClass="GridviewHeader" />
                                <SelectedRowStyle BackColor="LightCyan" />
                                <Columns>
                                    <asp:BoundField DataField="tb_reference" HeaderText="Transaction Id" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="tb_pri_key" HeaderText="Sr. No." HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="tb_other_cmbp_id" HeaderText="CM ID" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="tb_isin" HeaderText="ISIN" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="sc_isinname" HeaderText="ISIN Name" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="tb_qty" HeaderText="Qty" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" DataFormatString="{0:N2}" />
                                    <asp:BoundField DataField="rate" HeaderText="Rate" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="tb_settlement" HeaderText="Settlement" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="tb_cash" HeaderText="Cash" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="value" HeaderText="Value" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" DataFormatString="{0:N2}" />
                                    <asp:BoundField DataField="tb_instreceivemode" HeaderText="Flag" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="tb_status" HeaderText="Status" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                    <asp:BoundField DataField="tb_remark" HeaderText="Remark" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <table border="0" cellpadding="0" style="background-color: #FFFFCC; font-family: Times New Roman;
                font-size: small" cellspacing="0" width="90%">
                <tr>
                    <td align="right">
                        Counter Sett :
                    </td>
                    <td align="left" style="width: 150px;">
                        <asp:TextBox ID="txtcdslstlmnt" runat="server" MaxLength="13" Width="110px" onkeypress="CheckNo(15);"
                            AutoPostBack="True" CssClass="clsText" OnTextChanged="txtcdslstlmnt_TextChanged"></asp:TextBox>
                    </td>
                    <td align="right">
                        Cash :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cmbcash" runat="server">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="N">Not Required</asp:ListItem>
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="X">None</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        Status :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtstatus" runat="server" CssClass="WaterMarked" Width="60px"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        CM /DP ID :&nbsp;
                    </td>
                    <td align="left" colspan="1" style="width: 350px">
                        <asp:TextBox ID="txtbocmid" runat="server" Width="130px" MaxLength="8" AutoPostBack="true"
                            CssClass="clsText" OnTextChanged="txtbocmid_TextChanged" onkeypress="CheckNo(11);"></asp:TextBox>
                        <asp:TextBox ID="txtbocmidName" runat="server" Width="150px" MaxLength="16" AutoPostBack="false"
                            CssClass="WaterMarked">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ISIN :
                    </td>
                    <td align="left" colspan="1" style="width: 350px">
                        <asp:TextBox ID="txtisinCode_TXT_POSTBACK" runat="server" Width="100px" MaxLength="12"
                            AutoPostBack="true" CssClass="clsText" OnTextChanged="txtisinCode_TXT_POSTBACK_TextChanged"
                            onkeypress="CheckNo(11);"></asp:TextBox>
                        <asp:TextBox ID="txtisinName" runat="server" Width="198px" MaxLength="30" AutoPostBack="false"
                            CssClass="WaterMarked"></asp:TextBox>
                    </td>
                    <td align="right">
                        Qty:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtqty" runat="server" Width="110px" MaxLength="15" CssClass="clsText"
                            AutoPostBack="true" OnTextChanged="txtisinCode_TXT_POSTBACK_TextChanged"></asp:TextBox>
                    </td>
                    <td align="right">
                        Rate :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRate" runat="server" onkeypress="CheckNo(15);" MaxLength="12"
                            Width="99px" AutoPostBack="false" CssClass="WaterMarked"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Oblig No
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtObligNo" runat="server" CssClass="clsText" Width="110px" MaxLength="6">
                        </asp:TextBox>
                    </td>
                    <td align="right">
                        Serial No :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSerialNo" runat="server" CssClass="clsText" Width="110px" MaxLength="4">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="clsLabel">
                        Reason :&nbsp;
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cmbReason" runat="server" AutoPostBack="true" CssClass="clsLabel"
                            DataTextField="rt_desc" DataValueField="rt_code" Height="23px" Width="226px">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 100px">
                        Value :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtValue" runat="server" onkeypress="CheckNo(15);" MaxLength="12"
                            Width="110px" AutoPostBack="false" CssClass="WaterMarked">
                        </asp:TextBox>
                    </td>
                </tr>
                </caption> </tr>
                <tr>
                    <td align="right">
                        Remark :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" Width="230px" AutoPostBack="false"
                            CssClass="clsText"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                    </td>
                    <td align="left">
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <br />
            <table id="Table2" runat="server" border="0" cellpadding="0" cellspacing="0" width="90%">
                <tr style="height: 1px; background-color: Silver;">
                    <td align="center">
                        <asp:Button ID="BtnAdd" Text="Add" runat="server" onmouseover="this.style.cursor='hand'"
                            Width="70px" CssClass="GoButton" OnClick="BtnAdd_Click" />&nbsp;
                        <asp:Button ID="btnUpdate" runat="server" CssClass="GoButton" OnClick="btnUpdate_Click"
                            Text="Update" />&nbsp;
                        <asp:Button ID="BtnEdit" Text="Edit" runat="server" onmouseover="this.style.cursor='hand'"
                            Width="70px" CssClass="GoButton" OnClick="BtnEdit_Click" />&nbsp;
                        <asp:Button ID="BtnDelete" Text="Delete" CssClass="GoButton" onmouseover="this.style.cursor='hand'"
                            Width="70px" runat="server" OnClick="BtnEdit_Click" />&nbsp;
                        <asp:Button ID="BtnFind" Text="Find" runat="server" onmouseover="this.style.cursor='hand'"
                            CssClass="GoButton" Width="70px" OnClick="BtnFind_Click" />&nbsp;
                        <asp:Button ID="BtnSave" Text="Save" runat="server" onmouseover="this.style.cursor='hand'"
                            CssClass="GoButton" Width="70px" OnClick="BtnSave_Click" />&nbsp;
                        <asp:Button ID="BtnClear" Text="Clear" runat="server" onmouseover="this.style.cursor='hand'"
                            CssClass="GoButton" Width="70px" OnClick="BtnClear_Click" />&nbsp;
                        <asp:Button ID="btnSignature" Width="90px" runat="server" Text="Verify Signature"
                            CssClass="GoButton" onmouseover="this.style.cursor='hand'" OnClick="btnSignature_Click" />&nbsp;
                        <asp:Button ID="btnImport" Width="90px" runat="server" Text="IMPORT" CssClass="GoButton"
                            onmouseover="this.style.cursor='hand'" OnClick="btnimport_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="clsText" Width="200px" />
                    </td>
                </tr>
                <tr style="height: 1px; background-color: #FFFFCC;">
                    <td>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
