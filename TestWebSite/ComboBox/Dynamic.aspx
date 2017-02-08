<%@ Page Language="vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en">
<html>
	<head>
		<title>OpGeekTest</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<script language="javascript">
function ToggleDisplay(id)
{
	var elem = document.getElementById(id);
	if (elem) 
	{
		if (elem.style.display != 'block') 
		{
			
			elem.style.display = 'block';
			elem.style.visibility = 'visible';
		} 
		else
		{
			
			elem.style.display = 'none';
			elem.style.visibility = 'hidden';
		}
	}
}
</script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellspacing="1"
				cellpadding="1" width="300" border="1">
				<tr>
					<td><input type="button" onclick="ToggleDisplay('myDiv');" value="Expand/Collapse"></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>
						<div id="myDiv" style="DISPLAY: none;Visibility:hidden;">
						<table height=200><tr><td><font size=36>Some Text</font></td></tr></table>
						</div>
					</td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>
						<br />
						<br />
						Waffle
						<br />
						Test Box: &nbsp;<opgeek:combobox id="Combobox2" runat="server"></opgeek:combobox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>
						<br />
						<br />
						Waffle
						<br />
						Test Box: &nbsp;<asp:dropdownlist id="ddl" runat="server"/></td>
					<td></td>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</html>
