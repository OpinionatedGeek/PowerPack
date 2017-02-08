<%@ Page Language="C#" debug=true%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<HTML>
	<HEAD>
		<title>ComboBox events test</title>
	</HEAD>
	<body>
		<h1>
			ComboBox Events
		</h1>
		<form name="myForm" runat="server">
			<h2>
				An OpGeek ComboBox
			</h2>
			<opgeek:ComboBox id="drinkers" onselectedindexchanged="ComboSelectionChanged" ontextchanged="ComboTextChanged" runat="server" autopostback="true">
				<asp:ListItem Value="Homer" />
				<asp:ListItem Value="Barney" />
				<asp:ListItem Value="Carl" />
			</opgeek:ComboBox>

			<opgeek:ComboBox id="simpsons" onselectedindexchanged="ComboSelectionChanged" ontextchanged="ComboTextChanged" runat="server" autopostback="false">
				<asp:listitem Text="Homer" />
				<asp:listitem Text="Marge" />
				<asp:listitem Text="Bart" />
				<asp:listitem Text="Lisa" />
				<asp:listitem Text="Maggie" />
			</opgeek:ComboBox>

			<asp:Button Runat="server" Text="Submit"/>
			<br />
			<asp:CheckBox Runat="server" Text="Test Checkbox" AutoPostBack="True" />
		</form>
	</body>
</HTML>
<script language="C#" runat="server">
private void ComboSelectionChanged (object sender, EventArgs e)
{
	Control ctl = sender as Control;
	if (ctl != null)
	{
		Response.Write ("<h3>ComboSelectionChanged for ID: " + ctl.ID + "</h3>");
	}

	return;
}

private void ComboTextChanged (object sender, EventArgs e)
{
	Control ctl = sender as Control;
	if (ctl != null)
	{
		Response.Write ("<h3>ComboTextChanged for ID: " + ctl.ID + "</h3>");
	}

	return;
}

</script>
