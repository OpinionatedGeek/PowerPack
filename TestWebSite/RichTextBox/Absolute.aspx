<%@ Page language="c#" AutoEventWireup="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Absolute Positioning Test</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body MS_POSITIONING="GridLayout">
        <form id="Form1" method="post" runat="server">
            <asp:Label id="Label3" style="Z-INDEX: 107; LEFT: 88px; POSITION: absolute; TOP: 80px" runat="server" Width="60px" Height="24px" ForeColor="#0000C0">Subject</asp:Label>
            <asp:TextBox id="TextBox1" style="Z-INDEX: 106; LEFT: 172px; POSITION: absolute; TOP: 52px" runat="server" Width="496px">mike.salway@marlborough-stirling.com</asp:TextBox>
            <asp:TextBox id="TextBox2" style="Z-INDEX: 103; LEFT: 172px; POSITION: absolute; TOP: 24px" runat="server" Width="496px">mike.salway@marlborough-stirling.com</asp:TextBox>
            <opgeek:RichTextBox id="RichTextBox1" style="Z-INDEX: 101; LEFT: 172px; POSITION: absolute; TOP: 112px" runat="server" Width="497px" Height="224px"></opgeek:RichTextBox>
            <asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 172px; POSITION: absolute; TOP: 412px" runat="server" Width="120px" Height="28px" Text="Send"></asp:Button>
            <asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 88px; POSITION: absolute; TOP: 24px" runat="server" Width="60px" Height="24px" ForeColor="#0000C0">To</asp:Label>
            <asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 88px; POSITION: absolute; TOP: 52px" runat="server" Width="60px" Height="24px" ForeColor="#0000C0">From</asp:Label>
            <asp:TextBox id="TextBox3" style="Z-INDEX: 108; LEFT: 172px; POSITION: absolute; TOP: 80px" runat="server" Width="496px" Height="24px">Test</asp:TextBox>
            <asp:Panel id="pnl" style="Z-INDEX: 109; LEFT: 764px; POSITION: absolute; TOP: 192px" runat="server" Width="80px" Height="48px">Panel</asp:Panel>
        </form>
    </body>
</HTML>