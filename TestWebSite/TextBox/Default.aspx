<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>TextBox test</title>
	</head>
	<body>
		<h2>
			TextBox
		</h2>
		<form name="myForm" runat="server">
			<table>
				<tr>
					<td valign=top>
						<opgeek:TextBox id="widget" prompt="Click me!" rows=21 columns=60 name="test" forecolor="#10101" backcolor="#e0e0e0" text="Some default contents" font-name="Helvetica" runat="server" />
					</td>
					<td valign=top>
						<asp:TextBox id="tbCompare" rows=21 columns=60 forecolor="#10101" backcolor="#e0e0e0" text="Some default contents" font-name="Helvetica" runat="server" TextMode=MultiLine />
					</td>
				</tr>
			</table>
			<br>
			<input type="submit" runat="server" name="submit_button" value="Test!" />
		</form>
		<p>
			Got text:
			<%=widget.Text%>
		</p>
	</body>
</html>
