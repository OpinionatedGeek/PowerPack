<%@ Page Language="C#" EnableSessionState="false" debug="true" ValidateRequest="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>Swear Filter test</title>
	</head>
	<body>
		<h2>
			Swear Filter
		</h2>
	<p>
		The tag is currently filtering:
		<ul>
			<li>Homer (replaced with "D'Oh!")</li>
			<li>Marge (default replacement)</li>
			<li>Bart (replaced with "Bartholomew")</li>
			<li>Lisa (default replacement)</li>
			<li>Maggie (default replacement)</li>
		</ul>
	</p>

	<form name="myForm" runat="server">
		<opgeek:RichTextBox height="200" width="400" id="rtfText" contents="" selectedfont="helvetica" runat="server"/>
		<br>
		<input type="submit" runat="server" name="submit_button" value="Test!"/>
	</form>

	<h3>Filtered Text:</h3>
	<p>
		<opgeek:SwearFilter id="filter" runat="server">
			<%=rtfText.Text%>
		</opgeek:SwearFilter>
	</p>
	</body>
</html>
