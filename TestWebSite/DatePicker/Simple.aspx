<%@ Page Language="C#" EnableSessionState="false" debug="true" trace=true%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>DatePicker test</title>
	</head>
	<body>
		<h2>
			DatePicker
		</h2>
		<form name="calData" runat="server">
	<p>
		<opgeek:DatePicker backcolor="red" borderwidth=2 defaulttocurrentdate=false bordercolor=blue firstyear="2005" lastyear="2007" debug="true" runat="server" id="demodate" />
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
