<%@ Page Language="C#" EnableSessionState="false" debug="true" trace="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Custom Formatting Test</title>
	</HEAD>
	<body>
		<form runat="server">
			<table>
				<tr>
					<td>Date Picker:</td>
					<td>
						<opgeek:DatePicker id="test" runat="server" DisplayFormat="MMM dd, yyyy" />
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
