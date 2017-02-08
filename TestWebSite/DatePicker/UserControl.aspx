<%@ Page Language="C#" EnableSessionState="false" debug="true" trace="true" %>
<%@ Register TagPrefix="opgeek" TagName="wibble" Src="usercontrol.ascx" %>
<HTML>
	<HEAD>
		<title>DatePicker UserControl Test</title>
	</HEAD>
	<body>
		<h2>
			DatePicker UserControl Test
		</h2>
		<form name="myForm" runat="server">
			<opgeek:wibble runat="server"/>
			<br>
			<opgeek:wibble runat="server"/>
			<br>
			<asp:Button runat="server" text="Test!"/>
		</form>
	</body>
</HTML>
