<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        Try weather service:</p>
    <p>
        Enter zip:
        <asp:TextBox ID="zipBox" runat="server"></asp:TextBox>
        <asp:Button ID="accptBtn" runat="server" onclick="accptBtn_Click" 
            style="margin-top: 34px" Text="Submit" />
    </p>
    <p>
        <asp:TextBox ID="outputBox" runat="server" Height="425px" Width="902px" 
            Wrap="False"></asp:TextBox>
    </p>
</asp:Content>
