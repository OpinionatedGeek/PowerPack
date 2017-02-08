<%@ Page Language="C#" EnableSessionState="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>DatePicker test</title>
	</head>
	<body>
		<h2>
			Empty DatePicker
		</h2>
		<form name="calData" runat="server">
	<p>
		<opgeek:DatePicker DefaultToCurrentDate="false" runat="server" id="demodate" />
	</p>
	<p>
		<input type="submit" runat="server" value="Test DatePicker!" />
	</p>
</form>
You picked date: <b>
	<%=demodate.Value%>
</b>
<br />
	</body>
</html>
