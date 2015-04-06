<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="snip_n_stick.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    Title&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="27px" Width="769px" BorderStyle="Solid" BorderWidth="2px" BorderColor="Black" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    Created by&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" Height="27px" Width="769px" BorderStyle="Solid" BorderWidth="2px" BorderColor="Black" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <textarea id="TextArea1" name="S1" ></textarea><p>
    <br />
    <br />
</p>
</asp:Content>
