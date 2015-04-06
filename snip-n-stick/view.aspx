<%@ Page Title="View" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="snip_n_stick.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://google-code-prettify.googlecode.com/svn/loader/run_prettify.js?skin=sons-of-obsidian"></script>
    <style>
li.L0, li.L1, li.L2, li.L3,
li.L5, li.L6, li.L7, li.L8
{ list-style-type: decimal !important }
</style>
    <asp:FormView ID="form" runat="server" ItemType="snip_n_stick.Models.Snip" SelectMethod="GetSnip" Width="100%">
        <EmptyDataTemplate> 
               <p>The requested Snip has expired!</p>
        </EmptyDataTemplate>
        <ItemTemplate>
            <br />
                Title&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <TextBox ID="TextBox1" runat="server" Height="27px" Width="769px" BorderStyle="Solid" BorderWidth="2px" BorderColor="Black" ReadOnly="True">
                <%#: Item.SnipTitle %>
            </TextBox>
            <br />
            <br />
             Created by&nbsp;&nbsp;&nbsp;&nbsp;
            <TextBox ID="TextBox2" runat="server" Height="27px" Width="769px" BorderStyle="Solid" BorderWidth="2px" BorderColor="Black" ReadOnly="True">
                <%#: Item.SnipCreatedBy %> &nbsp;&nbsp;&nbsp; <%#: Item.SnipCreatedTime %>
            </TextBox>
            <br />
            <br />
            <pre class="prettyprint linenums"><%#: Item.SnipContent %></pre>
            <br />
            <br />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
