<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProtected.aspx.cs" Inherits="snip_n_stick.ViewProtected" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>This Snip is protected! Please enter Access Password.</h2>
    <asp:TextBox runat="server" ID ="passbox" TextMode="Password" CssClass="form-control" />
    <asp:Button runat="server" OnClick="Auth" Text="Access Snip" CssClass="btn btn-default" />
    <asp:Label runat="server" ID="err" CssClass="form-control" />
</asp:Content>
