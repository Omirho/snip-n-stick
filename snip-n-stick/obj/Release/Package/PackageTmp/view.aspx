<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="snip_n_stick.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/highlight.js/8.5/styles/default.min.css">
    <script src="//cdnjs.cloudflare.com/ajax/libs/highlight.js/8.5/highlight.min.js"></script>
    <script>hljs.initHighlightingOnLoad();</script>
    <asp:FormView ID="form" runat="server" ItemType="snip_n_stick.Models.Snip" SelectMethod="GetSnip">
        <EmptyDataTemplate> 
               <p>No data was returned.</p>
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
            <br /><div style ="
    float: left;
    width: 75em;
    padding: 1em;
    background: none repeat scroll 0% 0% #500;
    border-width: 1px;
    border-style: solid;
    border-color: #400 #700 #700 #400;
"><pre><code><%#: Item.SnipContent %></code></pre></div>
            <br />
            <br />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
