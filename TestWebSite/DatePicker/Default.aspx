<%@ Page Language="C#" EnableSessionState="false" debug="true" trace="false" validaterequest="false"%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<script language="C#" runat="server">
protected override void OnLoad
(
	EventArgs e
)
{
	base.OnLoad (e);

	eventtestdatepicker.DateChanged += new EventHandler (BING);

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
		<opgeek:DatePicker backcolor="red" borderwidth=2 defaulttocurrentdate=false bordercolor=blue firstyear="2005" lastyear="2007" debug="true" runat="server" id="demodate" />
	</p>
	<blockquote>
		<opgeek:DatePicker displayformat="dddd, d/MM/yy" lastyear="2005" debug="true" runat="server" id="eventtestdatepicker" />
	</blockquote>
	<p>
		<asp:textbox runat="server" id="textbox1" />
	</p>
	<p>
		<opgeek:RichTextBox id="rtb" runat="server"/>
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
