<%@ Page Title="Welcome" validateRequest="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="snip_n_stick._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Snip-N-Stick</h2>     
        <asp:TextBox id="TextArea1" runat="server" class="form-control" style="resize:none" Columns="500" Rows="20" TextMode="MultiLine"></asp:TextBox><br />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Syntax</asp:Label>
            <div class="col-md-10">
                 <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Duration</asp:Label>
            <div class="col-md-10">
                 <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <br />
       <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Exposure</asp:Label>
            <div class="col-md-10">
                 <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Password</asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" style="Margin-left:14px" Cssclass="form-control col-md-10 control-label" ></asp:TextBox>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Title </asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" style="Margin-left:14px" Cssclass="form-control col-md-10 control-label"  ></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" class="btn btn-default" OnClick="Button1_Click" Text="Submit" Width="193px" Height="37px" /> 
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    <script type ="text/javascript" >
        document.getElementById("<%= TextArea1.ClientID %>").addEventListener('keydown', function (e) {
            if (e.keyCode === 9) { // tab was pressed
                // get caret position/selection
                var start = this.selectionStart;
                var end = this.selectionEnd;

                var target = e.target;
                var value = target.value;

                // set textarea value to: text before caret + tab + text after caret
                target.value = value.substring(0, start)
                            + "\t"
                            + value.substring(end);

                // put caret at right position again (add one for the tab)
                this.selectionStart = this.selectionEnd = start + 1;

                // prevent the focus lose
                e.preventDefault();
            }
        }, false);

        </script>
</asp:Content>
