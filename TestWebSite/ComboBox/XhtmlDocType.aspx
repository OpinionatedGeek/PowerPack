<%@ Page %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack" %>
<!DOCTYPE html
PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
	<head>
		<title>Strict DOCTYPE</title>
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
	<body bgcolor="#ffffff">
		<form runat="server">
			<table border="0">
				<tr>
					<td>
						Headline:
					</td>
					<td>
						<opgeek:textbox width="525" runat="server" id="headline" />
					</td>
				</tr>
				<tr>
					<td>
						Category:
					</td>
					<td>
						<opgeek:combobox name="category" runat="server" width="150">
							<asp:listitem></asp:listitem>
							<asp:listitem>.NET</asp:listitem>
							<asp:listitem>4 Word Book Reviews</asp:listitem>
							<asp:listitem>AllPodcasts</asp:listitem>
							<asp:listitem>Business Thoughts</asp:listitem>
							<asp:listitem>Clueless Idiocy</asp:listitem>
							<asp:listitem>Norn Iron</asp:listitem>
							<asp:listitem>Personal</asp:listitem>
							<asp:listitem>Podcasting</asp:listitem>
							<asp:listitem>PowerPack</asp:listitem>
							<asp:listitem>Weird Interweb Stuff</asp:listitem>
						</opgeek:combobox>
					</td>
				</tr>
				<tr>
					<td>
						Headline:
					</td>
					<td>
						<opgeek:textbox width="525" runat="server" id="headline2" />
					</td>
				</tr>
				<tr>
					<td>
						Headline:
					</td>
					<td>
						<opgeek:textbox width="525" runat="server" id="headline3" />
					</td>
				</tr>
			</table>
			<table id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 140px" cellspacing="1"
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
						Waffle
						<br />
						Test Box: &nbsp;<opgeek:combobox id="Combobox2" runat="server"></opgeek:combobox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>
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
