<%@ Page language="c#" AutoEventWireup="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ComboBox 100%</title>
	</HEAD>
	<body>
		<form runat="server">
			<h1>100% Width</h1>
			<opgeek:combobox id="cb1" runat="server" width="100%">
				<asp:ListItem Value="Value 1">Option 1</asp:ListItem>
				<asp:ListItem Value="Value 2">Option 2</asp:ListItem>
			</opgeek:combobox>
			<br />
			<asp:DropdownList id="dd1" runat="server" width="100%">
				<asp:listitem value="Value 1">Option 1</asp:listitem>
				<asp:listitem value="Value 2">Option 2</asp:listitem>
			</asp:DropdownList>
			<asp:textbox id="tb1" runat="server" width="100%" />
			<br />
			<select name="select" style="width: 100%">
				<option>Option 1</option>
				<option>Option 2</option>
			</select>
			<div style="width: 100%; border-width: 1px; border-style: dotted;">
				<table border="1" width="100%" style="width: 100%; display: inline; ">
					<tr>
						<td>
							<select name="select" style="width: 100%">
								<option>Option 1</option>
								<option>Option 2</option>
							</select>
						</td>
					</tr>
				</table>
			</div>

			<h1>50% Width</h1>
			<opgeek:combobox id="cb2" runat="server" width="50%">
				<asp:listitem value="Value 1">Option 1</asp:listitem>
				<asp:listitem value="Value 2">Option 2</asp:listitem>
			</opgeek:combobox>
			<br />
			<asp:dropdownlist id="dd2" runat="server" width="50%">
				<asp:listitem value="Value 1">Option 1</asp:listitem>
				<asp:listitem value="Value 2">Option 2</asp:listitem>
			</asp:dropdownlist>
			<br />
			<asp:textbox id="tb2" runat="server" width="50%" />
		</form>
	</body>
</HTML>