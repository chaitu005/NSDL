<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentReciept.aspx.cs" Inherits="NSDL.PaymentReciept" %>
<%@ Register Assembly="AjaxControlToolkit"  Namespace='AjaxControlToolkit'  TagPrefix="Ajax"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="divMain" style="text-align: center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>   
                <table style="width: 100%;  background-color:#FFFFCC" border="1" >
                    <tr style="background-image: url('../../Images/aqua-bg.gif');">
                        <td align="center" class="FormHeader">
                        Voucher Entry
                        </td>
                    </tr>
                    
                    <tr>
                    <td nowrap="nowrap" align="center">
                        <table style="border-left-color: #0033ff; border-bottom-color: #0033ff; border-top-color: #0033ff;
                        height: 100%; border-right-color: #0033ff" cellspacing="0" cellpadding="0" width="100%"
                        border="0" runat="server" id="tblUpper">
                        <tbody>
                        <tr>
                        <td align="right" class="clsLabel" >
                        Voucher Type. :
                        </td>
                        <td style="width: 150px" align="left" colspan="2">
                        <asp:DropDownList ID="cmbCom" runat="server" Width="80px" TabIndex="1"  CssClass="clsText" Visible="true" AutoPostBack="true" >
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="C">Receipt</asp:ListItem>
                        <asp:ListItem Value="D">Payment</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="clsLabel"></td>
                        <td class="clsLabel"></td>
                        <td class="clsLabel"></td>
                        <td align="right" class="clsLabel">
                        Financial Year
                        </td>
                        <td align="left">
                        <asp:DropDownList ID="ddlYear" runat="server" EnableViewState="true" 
                        >
                        </asp:DropDownList>
      
                        </td>
                        </tr>
                        
                        <tr>
                        <td class="clsLabel" align="right">
                        Voucher No. :
                        </td>
                        <td  align="left" colspan="2">
                        <asp:TextBox ID="txtVoucher" TabIndex="9" onkeypress="CheckNo(1);" runat="server" Width="79px"
                        MaxLength="12" AutoPostBack="true"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" Enabled="false" OnClick="btnSearch_Click" />
                        <%--<Button:Search ID="SFind" runat="server" />--%>
                        </td>
                        <td class="clsLabel" align="right" >
                        Received In :</td>
                        <td  align="left" colspan="2">
                        <asp:UpdatePanel ID="up12" runat="server">
                        <ContentTemplate>
                        <asp:DropDownList ID="cmbBank" runat="server" Width="300px" DataValueField="cm_cd">
                        </asp:DropDownList>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
                        <td align="right" class="clsLabel">
                        </td>
                        <td  align="left">
                        <%--<asp:UpdatePanel ID="up13" runat="server">
                        <ContentTemplate>
                        <asp:TextBox ID="txtVoucher" runat="server" Width="100px" MaxLength="12" AutoPostBack="true"
                            Enabled="false"></asp:TextBox>
                        </ContentTemplate>
                        </asp:UpdatePanel>--%>
                        </td>
                        </tr>
                        <tr>
                        <td  align="right" class="clsLabel">
                        Date :</td>
                        <td  align="left" colspan="2">
                        <asp:UpdatePanel ID="up14" runat="server">
                        <ContentTemplate>
                        <asp:TextBox ID="txtDt" TabIndex="1" runat="server" EnableViewState="True"
                            Width="100px" MaxLength="10" AutoPostBack="True" Enabled="false" ToolTip="Please Enter the Date in DD/MM/YYYY Format"></asp:TextBox>
                        <asp:ImageButton ID="Imagedated" runat="server" ImageUrl="~/Images/Calendar_scheduleHS.png"
                        AlternateText="Click to show calendar" />
                            
                        <ajax:calendarextender  runat="server" ID="calExtender2" PopupButtonID="Imagedated"  TargetControlID="txtDt" Format="dd/MM/yyyy">  
                        </ajax:calendarextender>
                        <%--  <UC1:Search ID="BankSrch" runat="server" ></UC1:Search>--%>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
                        <td class="clsLabel" align="right" >
                        Balance :</td>
                        <td align="left">
                        <asp:TextBox ID="txtBalance" runat="server" Width="100px" AutoPostBack="true" Style="text-align: right"></asp:TextBox>&nbsp;
                        <asp:Label ID="lbldrcr" runat="server"></asp:Label>
                        </td>
                        <td  align="right" class="clsLabel">
                        Cleared On :
                        </td>
                        <td  align="left">
                        <asp:UpdatePanel ID="up15" runat="server">
                        <ContentTemplate>
                        <asp:TextBox ID="txtClrDt" runat="server" Width="100px" AutoPostBack="true" Enabled="false" EnableViewState="True"
                        MaxLength="10" ToolTip="Please Enter the Date in DD/MM/YYYY Format"></asp:TextBox>
                        <asp:ImageButton ID="ImageClearedOn" runat="server" ImageUrl="~/Images/Calendar_scheduleHS.png"
                        AlternateText="Click to show calendar" />
                        <ajax:calendarextender  runat="server" ID="Calendarextender1" PopupButtonID="ImageClearedOn"  TargetControlID="txtClrDt" Format="dd/MM/yyyy">  
                        </ajax:calendarextender>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
                        </tr>
                        </tbody>
                        </table>
                    <%--</contenttemplate>
                    </asp:UpdatePanel>--%>
                    </td>
                    </tr>
                    <tr>
                    <%-- <td style="height: 1px">
                    </td>--%>
                    </tr>
                    <tr>
                    <td nowrap="nowrap" style="width: 100%; background-color: White">
                    <div id="divGrid" runat="server" style="width: 100%; height: 150px; overflow: auto;">
                    <table id="Table2" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                    <td>
                    <asp:GridView ID="GrdReceipt" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true"
                    Width="100%" >
                    <HeaderStyle CssClass="GridviewHeader" />
                    <SelectedRowStyle BackColor="LightCyan" />
                    <Columns>
                    <asp:BoundField DataField="rc_clientcd" HeaderText="Code" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsText" />
                    <asp:BoundField DataField="cm_name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsText" />
                    <asp:BoundField DataField="ledgerbal" HeaderText="Balance" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="right" ItemStyle-CssClass="clsText" />
                    <asp:BoundField DataField="rc_chequeno" HeaderText="Chq No." HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsText" />
                    <asp:BoundField DataField="rc_micr" HeaderText="MICR" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsText" />
                    <asp:BoundField DataField="rc_bankname" HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsText" />    
                    <asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="right" ItemStyle-CssClass="clsText" />
                    <asp:BoundField DataField="rc_particular" HeaderText="Particulars" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsText" />
                    </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                    </table>
                    </div>
                    </td>
                    </tr>

                    <tr>
                
                    <td nowrap="nowrap">
                    <%--   <asp:UpdatePanel ID="up2" runat="server">
                    <contenttemplate>--%>
                    <table style="height: 100%; font-family:Times New Roman; border-color: #0033ff; font-weight:bold; " cellspacing="0" cellpadding="0" width="100%" border="0" runat="server" id="tblBottom">
                    <tr>
                    <td  align="right" >
                    BO ID :
                    </td>
                    <td align="left" nowrap="nowrap">
                    <asp:UpdatePanel ID="up21" runat="server">
                    <contenttemplate>
                    <asp:TextBox ID="txtClFrom" runat="server" AutoPostBack="true" Width="120px" ></asp:TextBox>
                    <asp:TextBox ID="txtClFrName" runat="server" AutoPostBack="true" Width="270px" CssClass="ajaxwatermarked" Enabled ="false">
                    </asp:TextBox>
                    <asp:Button ID="btnClientSearch" runat="server" OnClientClick="return ClientInfo_FindRecord();" Width="20px" 
                    Text="..." />
                    </contenttemplate> 
                    </asp:UpdatePanel>    
                    </td>
                    <td align="right" >
                    Amount :</td>
                    <td align="left" colspan="6">
                    <asp:UpdatePanel ID="up22" runat="server">
                    <ContentTemplate>
                    <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="true" Width="120px" MaxLength="12"
                        onkeypress="CheckNo(1);" Style="text-align: right"></asp:TextBox>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    </tr>
                    <tr>
                    <td align="right">
                    Particular :</td>
                    <td align="left" >
                    <asp:UpdatePanel ID="up23" runat="server">
                    <ContentTemplate>
                    <asp:TextBox ID="txtParticular" runat="server" AutoPostBack="true" Width="360px"></asp:TextBox>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td align="right">
                    Total :</td>
                    <td align="left"  colspan="6">
                    <asp:TextBox ID="txtTotal" runat="server" AutoPostBack="true" Width="120px" Enabled="false"
                    Style="text-align: right"></asp:TextBox>&nbsp;</td>
                    </tr>
                    <tr>
                    <td align="right"  >
                    Cheque No. :</td>
                    <td align="left" >
                    <asp:UpdatePanel ID="up24" runat="server">
                    <ContentTemplate>
                    <asp:TextBox ID="txtChqNo" runat="server" AutoPostBack="true" Width="120px" MaxLength="8" TabIndex="8" onkeypress="CheckNo(1);"></asp:TextBox>&nbsp; 
                                                                                    
                    <%--<asp:DropDownList ID="cmbAccYear" runat="server" Visible="False" EnableViewState="true">
                    </asp:DropDownList>--%>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td align="right" >
                    Balance :</td>
                    <td align="left" >
                    <asp:TextBox ID="txtNewBalance" runat="server" AutoPostBack="true" Width="120px" Style="text-align: right"></asp:TextBox>
                    <asp:Label ID="lbldrcr1" runat="server"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td align="right"  >MICR & Bank Name :.</td>
                    <td align="left" nowrap="nowrap">
                    <asp:UpdatePanel ID="up25" runat="server">
                    <ContentTemplate>
                    <asp:TextBox ID="txtMicr" runat="server" AutoPostBack="true" Width="120px" MaxLength="10" TabIndex="10" onkeypress="CheckNo(1);"></asp:TextBox>
                    <asp:TextBox ID="txtbankname" runat="server" AutoPostBack="true" Width="250px" Enabled ="false"> </asp:TextBox>
                    <%--<Button:Search ID="Search1" runat="server" Enabled="false" EnableViewState="True" From="ClientMaster" Height="500" LookupWindowName="" 
                    PostBack="true" ReturnToControlID="txtClFrom" ReturnToControlID1="txtFClName" url="../Masters/MasterSearch.aspx" Width="500"  />--%>
                    <asp:Button ID="btnMICRSearch" runat="server" OnClientClick="return BankInfo_FindRecord();" Width="20px" Text="..." />
  
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td align="right">
                    Balance
                    </td>
                    <td align="left" >
                    <asp:TextBox ID="txtBal_T" runat="server" Width="120px" Visible="true" ></asp:TextBox>&nbsp;
                    <asp:Label ID="lblfr" runat ="server" Visible ="true" ></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td align="right">Cost Center :.</td>
                    <td align="left">
                    <asp:TextBox ID="txtcost" runat="server" Width="120px" CssClass="clsText" Visible="true" ></asp:TextBox>
                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" Width="250px" Enabled ="false"> </asp:TextBox>
                    <asp:Button ID="Button1" runat="server" OnClientClick="return costcenter_FindRecord();" Width="20px" Text="..." />
                    </td>
                    <td></td>
                    <td align="left">
                    <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="true" Width="250px" Enabled ="false"> </asp:TextBox>
                    <asp:Button ID="Button2" runat="server" OnClientClick="return costcenter_FindRecord();" Width="20px" Text="..." />
                    </td>
      
                    </tr>
                    </table>
                    <%-- </contenttemplate>
                    </asp:UpdatePanel>--%>
                        
                    </td>
               
                    </tr>
                    <tr>
                        <td align="center">
                        <%--   <asp:UpdatePanel ID="up3" runat="server">
                        <contenttemplate>--%>
                        
                        <asp:Button ID="btnAdd"   runat="server" CssClass="clsLabel"  Text="Add" OnClick="btnAdd_Click"  />&nbsp; 
                        <asp:Button ID="BtnUpdate" runat="server"  CssClass="clsLabel" Text="Update"  />&nbsp;
                        <asp:Button ID="BtnFind"   runat="server" Text="Find" CssClass="clsLabel" onmouseover="this.style.cursor='hand'"  Width="70px" OnClick="BtnFind_Click"  />&nbsp;
                        <asp:Button ID="btnEdit"   runat="server" Text="Edit" CssClass="clsLabel" Height="20px" Width="60px" Enabled="false" />&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="clsLabel" Height="20px"  Width="60px" Enabled="false" />&nbsp;
                        <asp:Button ID="btnSave"   runat="server" Text="Save" CssClass="clsLabel" Height="20px" Width="60px" Enabled="false" OnClick="btnSave_Click" />&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="clsLabel" Height="20px" Width="60px" Enabled="false" />&nbsp;
                        <asp:Button ID="btnClosed" runat="server" Text="Close" CssClass="clsLabel" Height="20px" Width="60px" Enabled="false" />&nbsp;
                        <asp:Button ID="btnImport" runat="server" Text="Import" CssClass="clsLabel" Height="20px" Width="60px" Enabled="false" />&nbsp;
                        <input onmouseover="this.style.cursor='hand'" style="height: 16px" onclick="GetDt('document.all.ctl00_ContentPlaceHolder1_txtreceiptDt');"
                        tabindex="6" type="button" value="?" name="cmdHlp1" />
                        <%-- </contenttemplate>
                        </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
