<%@ Page Title="" Language="C#" MasterPageFile="~/NSDL.Master" AutoEventWireup="true" CodeBehind="InterDP.aspx.cs" Inherits="NSDL.Instruction.InterDP" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/InstructionGrid.ascx" TagPrefix="uc1" TagName="InstructionGrid" %>
<%@ Register Src="~/UserControls/SearchControl.ascx" TagPrefix="uc1" TagName="SearchControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true"></asp:ScriptManager>
    <table class="tblForm" border="0" cellpadding="0" cellspacing="0" width="90%">
        <tr>
            <td colspan="4" class="FormHeader">Inter DP Instruction[904/905]</td>
        </tr>
        <tr>
            <td align="right">Transaction Date :</td>
            <td align="left">
                <asp:TextBox ID="txtTransactionDt" ReadOnly="true" CssClass="clsText" runat="server"></asp:TextBox>
                <asp:ImageButton ID="cal_image1" CssClass="cal_icon" runat="server" ImageUrl="~/Images/Calendar_scheduleHS.png" AlternateText="Click Here To Show Calender" />
                <asp:CalendarExtender ID="cal_extender1" TargetControlID="txtTransactionDt" PopupButtonID="cal_image1" runat="server" Format="dd/MM/yyyy" />

                <%--<asp:DropDownList ID="cmbBranch" runat="server" CssClass="clsLabel" AutoPostBack="false" Width="100px">
                </asp:DropDownList> --%>
                
            </td>
            <td align="right">Execution Date :</td>
            <td align="left">
                <asp:TextBox ID="txtExecutionDt" CssClass="clsText" runat="server"></asp:TextBox>
                <asp:ImageButton ID="cal_image2" CssClass="cal_icon" runat="server" ImageUrl="~/Images/Calendar_scheduleHS.png" AlternateText="Click Here To Show Calender" />
                <asp:CalendarExtender ID="cal_extender2" TargetControlID="txtExecutionDt" PopupButtonID="cal_image2" runat="server" Format="dd/MM/yyyy" />
            </td>
        </tr>
        <tr>
            <td align="right">Internal Ref No :</td>
            <td align="left">
                <asp:TextBox ID="txtInternalRefNo" runat="server" AutoPostBack="true" CssClass="clsText" MaxLength="4" OnTextChanged="txtInternalRefNo_TextChanged">
                </asp:TextBox>
                <asp:HyperLink ID = "lnk_interdp_search" runat = "server" onclick="javascript:w=window.open('../InterDPSearch.aspx','','location=0,status=0,scrollbars=yes,resizable=no,width=500,height=500');"  Text = "..."></asp:HyperLink>
                <%--<uc1:SearchControl ID="SearchControl6" runat="server" Enabled="false" EnableViewState="True"
                    From="InterDPSearch" Height="500" LookupWindowName="" PostBack="true"
                    ReturnToControlID="txtInternalRefNo" 
                    url="../MasterSearch.aspx" Width="500"></uc1:SearchControl>--%>

                <%--<asp:TextBox ID="txtClCd" TabIndex="1" runat="server" Width="125px" MaxLength="16"
                        Enable="True" EnableViewState="True" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="txtClName" runat="server" Width="199px" Enabled="False"
                        EnableViewState="True" TabIndex="2"></asp:TextBox>

                <uc1:SearchControl ID="search_client_control" runat="server" Enabled="true" EnableViewState="True"
                        From="ClientShortMaster" Height="500" LookupWindowName="" PostBack="true"
                        ReturnToControlID="txtClCd" ReturnToControlID1="txtClName" selection="Bank"
                        url="../MasterSearch.aspx" Width="500"></uc1:SearchControl>--%>


            </td>
            <%----%>
        </tr>
        <tr>
            <td align="right">Slip No :</td>
            <td align="left">
                <asp:TextBox ID="txtslipno" runat="server" AutoPostBack="true" CssClass="clsText" MaxLength="15"></asp:TextBox>
                <%--<uc1:CodeSearch ID="CodeSearch1" runat="server" />--%>
                <%--<asp:TextBox id="txtInternalRefNo" Visible="false" runat="server" Width="90px" AutoPostBack="false" CssClass="clsLabel" MaxLength="4" >
                     </asp:TextBox>--%>
            </td>
        </tr>
        <tr>
            <td align="right">Instrument Type :</td>
            <td align="left">
                <asp:DropDownList ID="cmbInstructionType" AutoPostBack="true" runat="server" Width="160px" CssClass="clsLabel" OnSelectedIndexChanged="ddlstInstmnt_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="right">Lot No :
            </td>
            <td align="left">
                <asp:TextBox ID="txtlotno" runat="server" CssClass="WaterMarked">
                </asp:TextBox>
            </td>
        </tr>
        <tr>

            <td align="right">BO ID :</td>
            <td align="left">
                <asp:TextBox ID="txtClientId" runat="server" Enabled="false" Width="100px" AutoPostBack="True" CssClass="clsText" MaxLength="16" OnTextChanged="txtClientId_TextChanged"></asp:TextBox>
                <asp:TextBox ID="txtClientName" runat="server" Width="180px" CssClass="WaterMarked"></asp:TextBox>
                <uc1:SearchControl ID="search_client_control" runat="server" Enabled="false" EnableViewState="True"
                    From="ClientShortMaster" Height="500" LookupWindowName="" PostBack="true"
                    ReturnToControlID="txtClientId" ReturnToControlID1="txtClientName" selection="ClientShortMaster"
                    url="../MasterSearch.aspx" Width="500"></uc1:SearchControl>

            </td>
            <td align="right">Ledger Balance :</td>
            <td align="left">
                <asp:TextBox ID="txtBalance" runat="server" Width="100px" AutoPostBack="true" CssClass="WaterMarked" Enabled="false" Style="text-align: right">
                </asp:TextBox>
                <asp:Label ID="lbldrcr" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>

            <td align="right">Joint Holder 1 :
            </td>
            <td align="left">
                <asp:TextBox ID="txtjntholder1" runat="server" CssClass="clsText WaterMarked">
                </asp:TextBox>

            </td>

        </tr>
        <tr>

            <td align="right">Joint Holder 2 :
            </td>
            <td align="left">
                <asp:TextBox ID="txtlblJH2" runat="server" CssClass="clsText WaterMarked">
                </asp:TextBox>

            </td>
        </tr>
        <tr>
            <td align="right">Receive Mode :
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbReceiptMode" runat="server" CssClass="clsLabel" Width="99px" AutoPostBack="False">
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
                <asp:TextBox ID="txtReceiptMode" runat="server" Width="100px" CssClass="WaterMarked">
                </asp:TextBox>

            </td>
            <td align="right">
                <asp:CheckBox ID="chkLateFees" Font-Bold="true" AutoPostBack="True" Text="Late Fees" runat="server"></asp:CheckBox>
            </td>
            <td align="left">

                <asp:TextBox ID="txtLateFees" runat="server" onkeypress="CheckNo(15);" MaxLength="7" Width="110px" AutoPostBack="true" CssClass="clsText">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>


        <tr>
            <td colspan="4" nowrap="nowrap" style="width: 100%; background-color: White">
                <%-- <div id="divReceipt" runat="server" style="height: 150px; border: 1%; overflow: scroll">
                    <uc1:InstructionGrid runat="server" ID="InstructionGrid" />
                </div>--%>

                <div id="divGrid" runat="server" style="width: 100%; height: 150px; overflow: auto;">
                    <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="GrdOnMarket" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AutoGenerateSelectButton="true"
                                    Width="100%" onselectedindexchanged="GrdOnMarket_SelectedIndexChanged" onselectedindexchanging="GrdOnMarket_SelectedIndexChanging" >
                                    <HeaderStyle CssClass="GridviewHeader" />
                                    <SelectedRowStyle BackColor="LightCyan" />
                                    <Columns>
                                        <asp:BoundField DataField="id_internalrefno" HeaderText="Transact Id" />
                                        <asp:BoundField DataField="id_pri_key" HeaderText="Sr. No." />
                                        <asp:BoundField DataField="id_otherclientid" HeaderText="BO/CM ID" />
                                        <asp:BoundField DataField="id_isin" HeaderText="ISIN"/>
                                        <asp:BoundField DataField="id_settlementno" HeaderText="Sett No" />
                                        <asp:BoundField DataField="id_settlementno" HeaderText="CDSL Stlmnt" />
                                        <asp:BoundField DataField="id_qty" HeaderText="Qty" />
                                        <asp:BoundField DataField="sc_rate" HeaderText="Rate" />
                                        <asp:BoundField DataField="id_qty" HeaderText="Cash" />
                                        <asp:BoundField DataField="id_value" HeaderText="Value"/>
                                        <asp:BoundField DataField="id_allow" HeaderText="Flag" />
                                        <asp:BoundField DataField="id_remarks" HeaderText="Remark"/>
                                        <asp:BoundField DataField="id_remarks" HeaderText="Reason" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>


            </td>
        </tr>


        <tr>
            <td>DP ID : </td>
            <td>
                <asp:TextBox ID="txtdpid" runat="server" AutoPostBack="True" CssClass="clsText"
                    Enabled="true" MaxLength="8" Width="100px" OnTextChanged="txtdpid_TextChanged"></asp:TextBox>
                <asp:TextBox ID="txtdpname" runat="server" AutoPostBack="false"
                    CssClass="WaterMarked" MaxLength="16" Width="180px" ReadOnly="false" ></asp:TextBox>
                <uc1:SearchControl ID="SearchControl2" runat="server" Enabled="true" EnableViewState="True"
                    From="ClientShortMaster" Height="500" LookupWindowName="" PostBack="true"
                    ReturnToControlID="txtdpid" ReturnToControlID1="txtdpname" selection="ClientShortMaster"
                    url="../MasterSearch.aspx" Width="500"></uc1:SearchControl>
            </td>
        </tr>
        <tr>
            <td>From Sett No. :</td>
            <td>
                <asp:TextBox ID="txtSettNo" runat="server" MaxLength="12" Width="110px" AutoPostBack="true" CssClass="clsText" OnTextChanged="txtSettNo_TextChanged">
                </asp:TextBox>
                <uc1:SearchControl ID="SearchControl1" runat="server" Enabled="true" EnableViewState="True"
                    From="Settlementcalender" Height="500" LookupWindowName="" PostBack="true"
                    ReturnToControlID="txtSettNo" selection="Settlementcalender"
                    url="../MasterSearch.aspx" Width="500"></uc1:SearchControl>
            </td>
            <td align="right">Cash : </td>
            <td align="left">
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="X">Not Required</asp:ListItem>
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                </asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td>Counter BO ID :</td>
            <td>
                <asp:TextBox ID="txtbocmid" runat="server" Width="100px" MaxLength="8" AutoPostBack="true" CssClass="clsText">
                </asp:TextBox>
            </td>
            <td>Counter Sett :</td>
            <td align="left">
                <asp:TextBox ID="txtcdslstlmnt" runat="server" AutoPostBack="True" CssClass="clsText" MaxLength="13" Width="110px" OnTextChanged="txtcdslstlmnt_TextChanged">
                </asp:TextBox>
                <uc1:SearchControl ID="SearchControl4" runat="server" Enabled="true" EnableViewState="True"
                    From="Settlementcalender" Height="500" LookupWindowName="" PostBack="true"
                    ReturnToControlID="txtcdslstlmnt" selection="Settlementcalender"
                    url="../MasterSearch.aspx" Width="500"></uc1:SearchControl>
            </td>
            <td align="right">Rate :
            </td>
            <td align="left">

                <asp:TextBox ID="txtrate" runat="server" ReadOnly="false" CssClass="WaterMarked"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">ISIN :</td>
            <td align="left" colspan="1" style="width: 350px">
                <asp:TextBox ID="txtisinCode_TXT_POSTBACK" runat="server" AutoPostBack="true"
                    CssClass="clsText" MaxLength="12" Width="100px" OnTextChanged="txtisinCode_TXT_POSTBACK_TextChanged"></asp:TextBox>
                <asp:TextBox ID="txtisinName" runat="server" AutoPostBack="false"
                    CssClass="WaterMarked" MaxLength="30" ReadOnly="false" Width="180px"></asp:TextBox>
                <uc1:SearchControl ID="SearchControl5" runat="server" Enabled="true" EnableViewState="True"
                    From="Isinlist" Height="500" LookupWindowName="" PostBack="true"
                    ReturnToControlID="txtisinCode_TXT_POSTBACK" ReturnToControlID1="txtisinName" selection="Isinlist"
                    url="../MasterSearch.aspx" Width="500"></uc1:SearchControl>

            </td>
            <td align="right" style="width: 170px">Qty :</td>
            <td align="left">
                <asp:TextBox ID="txtqty" runat="server" AutoPostBack="true" CssClass="clsText"
                    MaxLength="15" Width="110px" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
            </td>
            <td align="right">Value :
            </td>
            <td align="left">
                <asp:TextBox ID="txtValue" runat="server" Width="100px" ReadOnly="false" AutoPostBack="false" CssClass="WaterMarked">
                </asp:TextBox>
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td align="right">Reason :&nbsp;</td>
            <td align="left" colspan="1">
                <asp:DropDownList ID="cmbReason" runat="server" AutoPostBack="true" CssClass="clsLabel" DataTextField="rt_desc" DataValueField="rt_code"
                    Height="23px" Width="226px">
                </asp:DropDownList>
            </td>
            <td align="left">&nbsp;</td>
        </tr>
        <tr>
            <td align="right">Remark :&nbsp;</td>
            <td align="left">
                <asp:TextBox ID="txtRemark" runat="server" AutoPostBack="false"
                    CssClass="clsText" MaxLength="50" Width="230px"></asp:TextBox>
            </td>
            <td></td>
            <td align="right" class="clsLabel"></td>
            <td align="left"></td>
            <td></td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <div class="formBtnSet">
                    <asp:Button ID="btnAdd" CssClass="btnForm" runat="server" Text="Add" OnClick="btnAdd_Click" />&nbsp;
                    <asp:Button ID="Btnupdate" CssClass="btnForm" OnClick="btnUpdate_Click" runat="server" Text="Update" Enabled="false" />&nbsp;
                    <asp:Button ID="btnEdit" CssClass="btnForm" runat="server" Text="Edit" Enabled="false" OnClick="btnEdit_Click" />&nbsp;
                    <asp:Button ID="btnfind" CssClass="btnForm" OnClick="btnFind_Click" runat="server" Text="Find" Enabled="false" />&nbsp;
                    <asp:Button ID="btnDelete" CssClass="btnForm" runat="server" Text="Delete" Enabled="false" OnClick="btnDelete_Click"  />&nbsp;
                    <asp:Button ID="btnSave" CssClass="btnForm" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnCancel" CssClass="btnForm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />&nbsp;
                    <asp:Button ID="Btnclose" CssClass="btnForm" runat="server" Text="Close" OnClick="btnClose_Click" />
                </div>
            </td>

        </tr>
    </table>

</asp:Content>
