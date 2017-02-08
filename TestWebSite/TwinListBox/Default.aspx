<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>TwinListBox test</title>
	</head>
	<body>
		<h2>
			TwinListBox
		</h2>
		<form name="myForm" runat="server">
			<opgeek:TwinListBox id="widget" name="widget" runat="server" selectionmode="Multiple">
				<asp:listitem text="Fred" value="Fred"/>
				<asp:listitem text="Wilma" value="Wilma"/>
				<asp:listitem text="Barney" value="Barney"/>
				<asp:listitem text="Betty" value="Betty"/>
			</opgeek:twinlistbox>
			<br>
			<input type="submit" runat="server" name="submit_button" value="Test!" />
		</form>
		Moved items: <blockquote>
		<%
			foreach (ListItem liItem in widget.Destination.Items)
			{
				Response.Write (liItem.Text + "<br />");
			}
		%></blockquote>
	</body>
</html>
