﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="snip_n_stick.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
            <textarea id="TextArea1" name="S1" >
                <%#: Item.SnipContent %>
            </textarea>
            <br />
            <br />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
