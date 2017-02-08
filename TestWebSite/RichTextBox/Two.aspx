<%@ Page Language="C#" EnableSessionState="false" debug="true" trace=true validaterequest="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<HTML>
	<HEAD>
		<title>RichTextBox test</title>
	</HEAD>
	<body>
		<h2>
			RichTextBox
		</h2>
		<form name="myForm" runat="server">
			<table>
				<tr>
					<td valign="top">
						<opgeek:RichTextBox id="widget" prompt="Testing..." rows="21" columns="45" name="test" font-name="Helvetica" runat="server">
					Some 
					<b>more</b>
					designer default contents</opgeek:RichTextBox>
					</td>
				</tr>
				<tr>
					<td valign="top">
						<opgeek:RichTextBox id="widget2" rows="21" cols="70" name="test" font-name="Helvetica" runat="server" debug="true">
					Second RTB</opgeek:RichTextBox>
					</td>
				</tr>
			</table>
			<br>
			<asp:Button runat="server" text="Test!"/>
		</form>
		<p>
			Got text:
			<%=widget.Text%>
		</p>
	</body>
</HTML>
