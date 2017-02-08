<%@ Control Language="C#" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
		<table>
			<tr>
				<td valign="top">
					<opgeek:RichTextBox id="widget" prompt="Test" rows="21" columns="60" name="test" text="Some default contents" font-name="Helvetica" runat="server" debug="true">
				Some designer default contents</opgeek:RichTextBox>
				</td>
				<td>
					<asp:TextBox Runat="server" ID="wibble" />
				</td>
			</tr>
			<tr>
				<td valign="top">
					<opgeek:RichTextBox id="widget2" rows="21" columns="60" name="test" font-name="Helvetica" runat="server" debug="true">
				Second RTB</opgeek:RichTextBox>
				</td>
				<td>
					<asp:TextBox Runat="server" ID="wibble2" />
				</td>
			</tr>
		</table>
	</body>
</HTML>
