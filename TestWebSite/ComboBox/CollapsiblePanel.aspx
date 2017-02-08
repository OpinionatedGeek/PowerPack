<%@ Page Language="C#" EnableSessionState="false" debug="true" trace="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>Collapsible Panel + ComboBox test</title>
	</head>
	<body>
		<h2>
			Collapsible Panel + ComboBox
		</h2>
		<form name="myForm" runat="server" ID="Form1">
			<p>
				<opgeek:collapsiblepanel text="<b>Click here to expand/collapse.</b>"
					width="50%"
					enabled="true"
					runat="server">
					<opgeek:combobox name="test" runat="server" width="150" ID="test">
						<asp:listitem></asp:listitem>
						<asp:listitem>Fred</asp:listitem>
						<asp:listitem>Barney</asp:listitem>
						<asp:listitem>Wilma</asp:listitem>
						<asp:listitem>Betty</asp:listitem>
					</opgeek:combobox>
				</opgeek:collapsiblepanel>
			</p>
			<asp:Button Runat="server" Text="Submit" />

		</form>
	</body>
</html>