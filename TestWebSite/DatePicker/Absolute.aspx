<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack" %>
<%@ Page language="c#" AutoEventWireup="false" %>
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
			<asp:Label id="Label3" style="Z-INDEX: 107; LEFT: 88px; POSITION: absolute; TOP: 80px" runat="server" Width="60px" Height="24px" ForeColor="#0000C0">Date</asp:Label>
			<opgeek:DatePicker id="DatePicker1" style="Z-INDEX: 106; LEFT: 168px; POSITION: absolute; TOP: 74px" runat="server" Width="496px" />
		</form>
	</body>
</HTML>
