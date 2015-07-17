<%@ Page Language="C#"  MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="WijzigGegevens.aspx.cs" Inherits="WebApplication1.WijzigGegevens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sidebar_1" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
<h1>Account</h1>
        <div style="border: medium none #000000; width: 368px; float: left; color: #000000; font-weight: bold;">
            <div style="color: #000000; font-weight: bold; width: 350px; float: right;">
                <h3>Change account information:</h3>
            </div>
            Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
            <asp:TextBox ID="TbName" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <br />
            <br />
            Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TbNewPass" runat="server" MaxLength="16" 
                TextMode="Password"></asp:TextBox>
            <br />
            <br />
            Confirm Password: &nbsp;
            <asp:TextBox ID="TbConfirmPass" runat="server" MaxLength="16" 
                TextMode="Password"></asp:TextBox>
                <br /><br />
                
            <asp:Button ID="BtnSignupChang" runat="server" Text="Change" 
                onclick="BtnSignup_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelSignUp" runat="server" Text="Information succesfully changed" 
                Visible="False" ForeColor="Black"></asp:Label>
        </div>
</asp:Content>