<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MySnips.aspx.cs" Inherits="snip_n_stick.Account.MySnips" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Snips">
        <asp:ListView ID="SnipList" ItemType="snip_n_stick.Models.Snip" runat="server" SelectMethod="GetMySnips">
            <ItemTemplate>
                <%#: Item.SnipTitle %>
            </ItemTemplate>
            <ItemSeparatorTemplate> <br /> </ItemSeparatorTemplate>
        </asp:ListView>
    </div>
</asp:Content>
