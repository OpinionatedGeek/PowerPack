<%@ Page Language="C#" EnableSessionState="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<script language=C# runat=server>
protected override void OnLoad
(
	EventArgs e
)
{
	base.OnLoad (e);

	dpTester.DateChanged += new EventHandler (BING);

	return;
}

private void BING
(
	object sender,
	EventArgs e
)
{
	Response.Write ("<h1>BING!</h1>");

	return;
}

</script>
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
				<opgeek:DatePicker lastyear="2005" debug="true" runat="server" ID="dpTester"/>
			</p>
			<p>
				<input type="submit" runat="server" value="Test DatePicker!" />
			</p>
		</form>
	</body>
</html>
