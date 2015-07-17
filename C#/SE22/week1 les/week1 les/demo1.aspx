<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo1.aspx.cs" Inherits="week1_les.demo1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Remi" runat="server" Text="Maak aan" onclick="Remi_Click" />
    </div>
    <p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="geslacht" 
            Text="M" />
&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="geslacht" 
            Text="V" />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
&nbsp;<p>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
    </p>
    </form>
</body>
</html>
