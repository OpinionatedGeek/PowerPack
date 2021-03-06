<%@ Page Language="C#" debug=true%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>ComboBox tests</title>
	</head>
	<body>
		<h1>
			ComboBox Tests
		</h1>
		<table>
			<tr>
				<td valign="top">Simple ComboBox:</td>
				<td valign="top">
					<form runat="server">
						<opgeek:combobox name="test" runat="server" width="150" ID="test">
							<asp:listitem></asp:listitem>
							<asp:listitem>Fred</asp:listitem>
							<asp:listitem>Barney</asp:listitem>
							<asp:listitem>Wilma</asp:listitem>
							<asp:listitem>Betty</asp:listitem>
						</opgeek:combobox>
						<asp:DropDownList Runat="server" ID="test2">
							<asp:listitem>3"</asp:listitem>
							<asp:listitem>4</asp:listitem>
						</asp:DropDownList>
						<asp:Button Runat="server" Text="Submit" />
					</form>
				</td>
			</tr>
		</table>
	</body>
</html>
