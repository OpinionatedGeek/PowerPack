<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>Print Buttons Test</title>
	</head>
	<body>
		<h1>
			Print Buttons
		</h1>
		<form name="myForm" runat="server">
			<p>
				Button: <opgeek:PrintButton id="testButton" runat="server"/>
			</p>
			<p>
				LinkButton: <opgeek:PrintLinkButton id="testLinkButton" runat="server"/>
			</p>
			<p>
				ImageButton: <opgeek:PrintImageButton id="testImageButton" runat="server"/>
			</p>
			<p>
				Alternatively, go <a href="autoprint.aspx">here</a> for the auto-printing page.
			</p>
		</form>
	</body>
</html>
