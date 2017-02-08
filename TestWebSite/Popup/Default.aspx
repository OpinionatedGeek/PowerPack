<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>PopupButton test</title>
	</head>
	<body>
		<form name="myForm" runat="server">
			<h2>
				PopupButton
			</h2>
			<opgeek:PopupButton id="PopupButton" AlertOnly="True" PopupText="Fred was here..." Text="Press Me!" runat="server" />
			<h2>
				PopupImageButton
			</h2>
			<opgeek:PopupImageButton id="PopupImageButton" ImageUrl="/images/opgeek.gif" AlertOnly="false" runat="server" />
			<h2>
				PopupLinkButton
			</h2>
			<opgeek:PopupLinkButton id="PopupLinkButton" PopupText="Fred wasn't here at all..." Text="Press Me!" runat="server" />
		</form>
	</body>
</html>
