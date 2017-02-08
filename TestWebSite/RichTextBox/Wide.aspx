<%@ Page Language="C#" validaterequest="false"%>
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
			<div id="trace2"></div>
			<table>
				<tr>
					<td valign="top">
						<opgeek:RichTextBox id="widget" width="800" name="test" runat="server"/>
					</td>
				</tr>
			</table>
			<asp:Button runat="server" text="Test!"/>
		</form>
		<p>
			Got text:
			<%=widget.Text%>
		</p>
	</body>
</HTML>
