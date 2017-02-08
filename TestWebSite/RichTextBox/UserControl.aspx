<%@ Page Language="C#" EnableSessionState="false" debug="true" trace=true validaterequest="false" %>
<%@ Register TagPrefix="opgeek" TagName="wibble" Src="usercontrol.ascx" %>
<HTML>
	<HEAD>
		<title>RichTextBox test</title>
	</HEAD>
	<body>
		<h2>
			RichTextBox
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
