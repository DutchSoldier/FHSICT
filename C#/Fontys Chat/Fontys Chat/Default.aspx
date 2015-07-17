<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<%@ Register Src="FriendsList.ascx" TagName="FriendsList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sidebar_1" runat="server">
    <uc1:FriendsList ID="FriendsList1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <h1>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </h1>
    <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="500">
    </asp:Timer>
    <div class="chat">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
            <alternatingitemtemplate>
            <tr>
                <td>
                    <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                </td>
                <td>
                    <asp:Label ID="UsernameLabel" runat="server" Text='<%# Eval("Username") %>' />
                </td>
                <td>
                    <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("Message") %>' />
                </td>
            </tr>
        </alternatingitemtemplate>
            <edititemtemplate>
            <tr>
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                </td>
                <td>
                    <asp:TextBox ID="UsernameTextBox" runat="server" Text='<%# Bind("Username") %>' />
                </td>
                <td>
                    <asp:TextBox ID="MessageTextBox" runat="server" Text='<%# Bind("Message") %>' />
                </td>
            </tr>
        </edititemtemplate>
            <emptydatatemplate>
            <table runat="server">
                <tr>
                    <td>
                        No data was returned.
                    </td>
                </tr>
            </table>
        </emptydatatemplate>
            <insertitemtemplate>
            <tr>
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                </td>
                <td>
                    <asp:TextBox ID="UsernameTextBox" runat="server" Text='<%# Bind("Username") %>' />
                </td>
                <td>
                    <asp:TextBox ID="MessageTextBox" runat="server" Text='<%# Bind("Message") %>' />
                </td>
            </tr>
        </insertitemtemplate>
            <itemtemplate>
            <tr>
                <td>
                    <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                </td>
                <td>
                    <asp:Label ID="UsernameLabel" runat="server" Text='<%# Eval("Username") %>' />
                </td>
                <td>
                    <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("Message") %>' />
                </td>
            </tr>
        </itemtemplate>
            <layouttemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server">
                            <tr runat="server">
                                <th runat="server">
                                    Date
                                </th>
                                <th runat="server">
                                    Username
                                </th>
                                <th runat="server">
                                    Message
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: left;">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="8">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </layouttemplate>
            <selecteditemtemplate>
            <tr>
                <td>
                    <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                </td>
                <td>
                    <asp:Label ID="UsernameLabel" runat="server" Text='<%# Eval("Username") %>' />
                </td>
                <td>
                    <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("Message") %>' />
                </td>
            </tr>
        </selecteditemtemplate>
        </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="125px" TextMode="MultiLine" 
            Width="500px" ></asp:TextBox>
            <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
    <br />
    <asp:Label ID="Label2" runat="server" ForeColor="#CC0000"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT t.datetime AS Date, u.username AS Username, t.text AS Message FROM Text t, [User] u WHERE t.id = u.id;">
    </asp:SqlDataSource>
</asp:Content>
