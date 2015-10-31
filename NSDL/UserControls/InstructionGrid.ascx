<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstructionGrid.ascx.cs" Inherits="NSDL.UserControls.InstructionGrid" %>
<asp:GridView ID="grdReceipts" runat="server" AutoGenerateColumns="False" BorderColor="#FFE1E1"
    BackColor="Beige" ForeColor="Black" Style="width: 98%; overflow: scroll">
    <SelectedRowStyle BackColor="Beige" Font-Bold="true" />
    <HeaderStyle BackColor="#CC3300" ForeColor="White" Font-Bold="True"></HeaderStyle>
    <Columns>
        <asp:BoundField DataField="ie_lotno" HeaderText="Lot No." HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <%--<asp:BoundField DataField="tb_other_cmbp_id" HeaderText="Inst Type" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />--%>
        <asp:BoundField DataField="ie_slipno" HeaderText="Slip No" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <asp:BoundField DataField="ie_cmcd" HeaderText="Client id" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <%--<asp:BoundField DataField="cm_name" HeaderText="Client Name " HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />--%>
        <asp:BoundField DataField="ie_execdt" HeaderText="Exec Date" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="ie_nooftrx" HeaderText="No of Inst" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <asp:BoundField DataField="ie_noofcert" HeaderText="No of Cert" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <asp:BoundField DataField="ie_rejected" HeaderText="Rejected" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="ie_trxtype" HeaderText="TrType" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <asp:BoundField DataField="ie_instno" HeaderText="Inst No " HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <asp:BoundField DataField="ie_mode" HeaderText="Mode" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <asp:BoundField DataField="ie_remark" HeaderText="Remarks " HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <asp:BoundField DataField="ie_charge" HeaderText="Charge " HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
        <asp:BoundField DataField="ie_pri_key" HeaderText="PriKey " HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="clsLabel" />
    </Columns>

</asp:GridView>
