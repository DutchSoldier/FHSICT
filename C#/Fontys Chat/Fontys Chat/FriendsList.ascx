<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendsList.ascx.cs" Inherits="WebApplication1.FriendsList" %>
<center>
    <h3>Friends List</h3>
    <div>
    <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="5000">
    </asp:Timer>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CellPadding="5" DataSourceID="SqlDataSource1" 
    GridLines="None">
    <Columns>
        <asp:BoundField DataField="username" HeaderText="Friend" 
            SortExpression="username" />
        <asp:BoundField DataField="online" HeaderText="Online" 
            SortExpression="online" />
    </Columns>

</asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"        
        
        SelectCommand="SELECT u.username, u.online FROM [User] u WHERE u.id IN (SELECT f.friend FROM Friend f WHERE f.id = @userId);" 
        oninit="SqlDataSource1_Init">
    <SelectParameters>
        <asp:Parameter Name="userId" Type="Int32" DefaultValue="-1" />
    </SelectParameters>
    </asp:SqlDataSource>
            </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:TextBox ID="TextBox1" runat="server">Username</asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Voeg toe" 
        onclick="Button1_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" ForeColor="#CC0000"></asp:Label>
</center>

