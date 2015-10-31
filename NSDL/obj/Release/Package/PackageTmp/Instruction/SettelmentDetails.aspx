<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SettelmentDetails.aspx.cs" Inherits="NSDL.Instruction.SettelmentDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" cellspacing="0" >
            <tr>	
     <td>Date</td>
     <td><asp:Label runat="server" ID="lbl_set_date"></asp:Label> </td>	
     <td>Scroll</td>
     <td><asp:Label runat="server" ID="lbl_set_scrollNo"></asp:Label> </td>
     <td></td>
     <td></td>
</tr>
<tr>	
     <td>Inst Type.</td>
     <td><asp:Label runat="server" ID="lbl_set_insType"></asp:Label></td>	
     <td>Avalibele Lot:</td>
     <td><asp:Label runat="server" ID="lbl_set_avblLot"></asp:Label></td>
     <td>Lot Size:</td>
     <td><asp:Label runat="server" ID="lbl_set_lotSize"></asp:Label></td>
</tr>
<tr>	
     <td>Slip No.</td>
     <td><asp:Label runat="server" ID="lbl_set_slipNo"></asp:Label></td>	
     <td>Client Id: <asp:Label runat="server" ID="lbl_set_clientCode"></asp:Label></td>
     <td>Client Name: <asp:Label runat="server" ID="lbl_set_clientName"></asp:Label></td>
     <td></td>
     <td></td>
</tr>
<tr>	
     <td>Instructions </td>
     <td><asp:Label runat="server" ID="lbl_set_instructions"></asp:Label></td>	
     <td>No of Certificates</td>
     <td><asp:Label runat="server" ID="lbl_set_noofcerts"></asp:Label></td>
     <td>Execution Date</td>
     <td><asp:Label runat="server" ID="lbl_set_execDate"></asp:Label></td>
</tr>
<tr>	
     <td>Charges</td>
     <td><asp:Label runat="server" ID="lbl_set_charges"></asp:Label></td>	
     <td>Remarks</td>
     <td><asp:Label runat="server" ID="lbl_set_remarks"></asp:Label></td>
     <td>Mode of Delivery </td>
     <td><asp:Label runat="server" ID="lbl_set_mod"></asp:Label></td>
</tr>

        </table>
    </div>
    </form>
</body>
</html>
