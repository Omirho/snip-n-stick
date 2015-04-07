<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MySnips.aspx.cs" Inherits="snip_n_stick.Account.MySnips" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Snips">
        <br />
            <asp:ListView ID="SnipList" ItemType="snip_n_stick.Models.Snip" runat="server" SelectMethod="GetMySnips">
            <EmptyDataTemplate> 
               <p>No data was returned.</p>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table id="SnipTable">
                <tr>
                <th>Title</th>
                <th>CreatedTime</th>		
                <th>ExpirationTime</th>
                <th>Languages</th>
                 </tr>
                <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>
                <ItemTemplate>                   
                    <tr>
                        <td><a href="https://www.ggogle.com"><%#: Item.SnipTitle %></a></td>
                        <td><%#: Item.SnipCreatedTime %></td>		
                        <td><%#: Item.SnipExpirationTime %></td>
                        <td><%#: Item.SnipLanguage %></td>
                    </tr>                   
                 </ItemTemplate>
                <ItemSeparatorTemplate> 
                    <br /> 
                </ItemSeparatorTemplate>
            </asp:ListView>
    </div>
</asp:Content>
