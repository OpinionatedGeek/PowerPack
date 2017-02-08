<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>MakeMeHomePageAutomatically test</title>
	</head>
	<body>
		<h1>
			MakeMeHomePageAutomatically
		</h1>
		<form name="myForm" runat="server">
			<p>
				This is just some text.
			</p>
			<opgeek:MakeMeHomePageAutomatically id="testAutoHomepage" enabled="true" runat="server"/>
		</form>
	</body>
</html>
