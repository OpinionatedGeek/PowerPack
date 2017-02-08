<%@ Page Language="C#" EnableSessionState="false" debug="true"%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<script language="javascript">
function testClientSide ()
{
	var combo = document.getElementById ('cbId');
	alert ('Value: ' + combo.value);
	alert ('Text: ' + combo.children [combo.selectedIndex].innerHTML);
}
</script>
<script language=C# runat=server>
private class Datum
{
	private string _szText = null;
	private string _szValue = null;

	public Datum (string szText, string szValue)
	{
		_szText = szText;
		_szValue = szValue;

		return;
	}

	public string Text
	{
		get
		{
			return _szText;
		}
		set
		{
			_szText = value;

			return;
		}
	}

	public string Value
	{
		get
		{
			return _szValue;
		}
		set
		{
			_szValue = value;

			return;
		}
	}
}

protected override void OnLoad
(
	EventArgs e
)
{
	base.OnLoad (e);

	if (IsPostBack)
	{
		Response.Write ("<h1>Postback value is: " + cbId.SelectedValue + "</h1>");
	}
	else
	{
		ArrayList alValues = new ArrayList ();
		alValues.Add (new Datum ("HomerText", "HomerValue"));
		alValues.Add (new Datum ("MargeText", "MargeValue"));
		alValues.Add (new Datum ("BartText", "BartValue"));
		alValues.Add (new Datum ("LisaText", "LisaValue"));
		alValues.Add (new Datum ("MaggieText", "MaggieValue"));

		cbId.DataTextField = "Text";
		cbId.DataValueField = "Value";
		cbId.DataSource = alValues;
		cbId.DataBind ();
	}

	return;
}

private void Add1
(
)
{
	ListItem liComboListItem = null;

	for (int i = 0; i < 10; i++)
	{
		liComboListItem = new ListItem ("New value " + i.ToString (), i.ToString ());
		cbId.Items.Add (liComboListItem);
	}

	return;
}

private void Add2
(
)
{
	ArrayList lstItems = new ArrayList ();
	ListItem liComboListItem = null;
	for (int i = 0; i < 10; i++)
	{
		liComboListItem = new ListItem ("New value " + i.ToString (), i.ToString ());
		lstItems.Add (liComboListItem);
	}

	cbId.DataSource = lstItems;
	cbId.DataBind ();

	return;
}
</script>
<html>
	<head>
		<title>ComboBox test</title>
	</head>
	<body>
		<h1>
			ComboBox
		</h1>
		<table border="0" cellspacing="0" cellpadding="0" width="100%">
			<tr>
				<td valign="top">
					<table border="0" cellspacing="0" cellpadding="4" width="500">
						<tr>
							<td valign="top">
								<form name="myForm" runat="server">
									<h2>
										Standard ASP.NET
									</h2>
									<asp:DropDownList Runat="server">
										<asp:ListItem Text="Booger" Value="1" />
										<asp:ListItem Text="Flurble" Value="2" />
										<asp:ListItem Text="Widget" Value="3" />
									</asp:DropDownList>
									<p>
																				pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre 
									</p>
									<h2>
										An OpGeek ComboBox
									</h2>
												<opgeek:ComboBox id="cbId" runat="server" midtext="<br>or<br>">
												</opgeek:ComboBox>
													<!--<asp:ListItem Value="Booger" />
													<asp:ListItem Value="Flurble" />
													<asp:ListItem Value="Widget" />-->
									<input type="submit" runat="server" name="submit_button" value="Test!" />
									<opgeek:CollapsiblePanel runat="server" Text="PRE text">
										<pre>
											pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre pre 
										</pre>
									</opgeek:CollapsiblePanel>
									<button onclick="testClientSide ()"/>
								</form>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</html>
