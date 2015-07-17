<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#logout").hide();
            $("#profile").hide();
        });
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="sidebar_1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
        <div id="Login" title="Login" 
            style="border: thin none #000000; float: left; color: #000000; font-weight: bold;"><h3>Login:</h3>
            <p title="Login:" style="color: #000000; font-weight: bold; width: 350px;">
                <span style="padding-right: 5em;">Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </span><span style="word-spacing: 2em;">Password:</span></p>
            <p title="Login:" style="color: #000000; font-weight: bold; width: 350px;">
                <asp:TextBox ID="TbEmail" runat="server">test@hotmail.com</asp:TextBox>
                &nbsp;
                <asp:TextBox ID="TbPass" runat="server" MaxLength="16" TextMode="Password"></asp:TextBox>
                <br /><br />
                <asp:Button ID="BtnLogin" runat="server" Text="Log in" 
                    onclick="BtnLogin_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelLoginFalse" runat="server" 
                    Text="Email or password is incorrect" Visible="False"></asp:Label>
            </p>
            <p title="Login:" style="color: #000000; font-weight: bold; width: 350px;">
                &nbsp;</p>
        </div>
        <div style="border: medium none #000000; width: 368px; float: left; color: #000000; font-weight: bold;">
            <div style="color: #000000; font-weight: bold; width: 350px; float: right;">
                <h3>Or sign up:</h3>
            </div>
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TbNewEmail" runat="server"></asp:TextBox>
            &nbsp;
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
                Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="TbName" runat="server"></asp:TextBox>
                
            &nbsp;&nbsp;
            <br /><br />
            <asp:Button ID="BtnSignup" runat="server" Text="Sign up" 
                onclick="BtnSignup_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelSignUp" runat="server" Text="Email already in use" 
                Visible="False" ForeColor="Black"></asp:Label>
        </div>
    </asp:Content>
