<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>PrintAutomatically test</title>
	</head>
	<body>
		<h1>
			PrintAutomatically
		</h1>
		<form name="myForm" runat="server">
			<p>
				This is just some text.
			</p>
			<opgeek:PrintAutomatically id="testAutoPrint" runat="server"/>
		</form>
	</body>
</html>
