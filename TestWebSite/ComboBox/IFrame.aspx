<%@ Page Language="C#" EnableSessionState="false" debug="true"%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<%
// This delay is introduced to enable the user to generate another
// post at the same time that this response is received.
int y = 0;
for (int x = 1; x < 10000000; x++)
{
  y = y + x/10;
}
%>
<html>
	<head>
		<title>IFRAME test</title>
	</head>
	<body>
		<h1>
			ComboBox
		</h1>
		<form id="myForm" runat="server">
			<h2>
				An OpGeek ComboBox
			</h2>
			<opgeek:combobox id="cbId" runat="server" midtext="<br>or<br>" autopostback="true">
				<asp:listitem value="Test 1" />
				<asp:listitem value="Test 2" />
				<asp:listitem value="Test 3" />
			</opgeek:combobox>
			<h2>Standard dropdown with IFRAME bug.</h2>
			<select name="ListBox1" size="3" onchange="myForm.submit()" id="ListBox1">
				<option value="Item1">Item1</option>
				<option value="Item2">Item2</option>
				<option value="Item3">Item3</option>
			</select>
		</form>
	</body>
</html>
