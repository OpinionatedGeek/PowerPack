<%@ Page Language="C#" validaterequest="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<HTML>
	<HEAD>
		<title>RichTextBox Text Changed test</title>
	</HEAD>
	<body>
		<h2>
			RichTextBox Text Changed Test
		</h2>
		<form name="myForm" runat="server">
			<div id="trace2"></div>
			<table>
				<tr>
					<td valign="top">
						<opgeek:RichTextBox id="widget" rows="14" columns="70" name="test"
							font-name="Helvetica" runat="server" OnTextChanged="TextChangedHandler" />
					</td>
				</tr>
			</table>
			<asp:Button runat="server" text="Test!"/>
		</form>
		<button onclick="alert (document.getElementById ('widgetFrameID').contentDocument.body.innerHTML);">Content</button>
		<p>
			Got text:
			<%=widget.Text%>
		</p>
	</body>
</HTML>
<script language="C#" runat="server">
private void TextChangedHandler (object sender, EventArgs e)
{
    Context.Response.Write ("<h1>Text Changed!</h1>");
    return;
}
</script>