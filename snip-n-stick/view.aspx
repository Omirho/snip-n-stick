<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="snip_n_stick.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/highlight/styles/shThemeDefault.css" rel="stylesheet" type="text/css" />
    <link href="/Content/highlight/styles/shThemeCore.css" rel="stylesheet" type="text/css" />
    <script src="/Content/highlight/scripts/shCore.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Content/highlight/scripts/shBrushCpp.js"></script>
    <script src="/Content/highlight/scripts/shAutoloader.js" type="text/javascript"></script>
    <script>SyntaxHighlighter.all();</script>
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
            <br />
            <script type="syntaxhighlighter" class="brush: cpp">
                <![CDATA[<%#: Item.SnipContent %>]]></script>
            <br />
            <br />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
