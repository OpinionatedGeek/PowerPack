<%@ Page Language="C#" validaterequest="false" %>
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
					<td>
						<opgeek:TextBox runat="server" GrabFocus="true" />
					</td>
				</tr>
				<tr>
					<td valign="top">
						<opgeek:RichTextBox id="widget" rows="14" columns="70" name="test"
							font-name="Helvetica" runat="server" />
					</td>
				</tr>
			</table>
			<asp:Button runat="server" text="Test!"/>
			<div id="trace"></div>
		</form>
		<p>
			Got text:
			<%=widget.Text%>
		</p>
	</body>
</HTML>
