<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>PopupAutomatically test</title>
	</head>
	<body>
		<h1>
			PopupAutomatically
		</h1>
		<form name="myForm" runat="server">
			<p>
				This is just some text.
			</p>
			<opgeek:PopupAutomatically id="testAutoPopup" popuptext="Bing!" runat="server"/>
		</form>
	</body>
</html>
