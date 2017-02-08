<%@ Page language="c#" AutoEventWireup="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ComboBox Alignment</title>
	</HEAD>
	<body>
		<form runat="server">
			<TABLE id="HeaderInfo"
				tabIndex="0" border="0">
				<TR style="HEIGHT: 20px">
					<TD align="center" style="WIDTH: 150px">OpGeek ComboBox</TD>
					<TD align="center" style="WIDTH: 150px">Text Field 1</TD>
					<TD align="center" style="WIDTH: 150px">Text Field 2</TD>
				</TR>
				<TR style="HEIGHT: 25px">
					<TD style="WIDTH: 150px">
						<opgeek:combobox id="opg1" tabIndex="-1" runat="server" TextEntryEnabled="True">
							<asp:ListItem Value="Value 1">Option 1</asp:ListItem>
							<asp:ListItem Value="Value 2">Option 2</asp:ListItem>
						</opgeek:combobox>
					</TD>
					<TD style="WIDTH: 150px"><INPUT id="tf1" type="text">
					</TD>
					<TD style="WIDTH: 150px"><INPUT id="tf2" type="text">
					</TD>
					<TD style="WIDTH: 150px"></TD>
				</TR>
				<TR style="HEIGHT: 25px">
					<TD style="WIDTH: 150px">
						<opgeek:combobox id="opg2" tabIndex="-1" runat="server" TextEntryEnabled="True">
							<asp:ListItem Value="Value 1">Option 1</asp:ListItem>
							<asp:ListItem Value="Value 2">Option 2</asp:ListItem>
						</opgeek:combobox>
					</TD>
					<TD style="WIDTH: 150px"><INPUT id="tf3" type="text">
					</TD>
					<TD style="WIDTH: 150px">
						<SELECT id="sel1">
							<option>Dropdown 1</option>
							<option>Dropdown 2</option>
						</SELECT>
					</TD>
					<TD style="WIDTH: 150px"></TD>
				</TR>
			</TABLE>
			<p>&nbsp;</p>
			<table>
				<tr>
					<td>Dropdown baseline table test:</td>
					<td>
						<SELECT id="sel2">
							<option>Dropdown 1</option>
							<option>Dropdown 2</option>
						</SELECT>
					</td>
				</tr>
				<tr>
					<td>ComboBox baseline table test:</td>
					<td>
						<opgeek:combobox id="opg3" tabIndex="-1" runat="server" TextEntryEnabled="True">
							<asp:ListItem Value="Value 1">Option 1</asp:ListItem>
							<asp:ListItem Value="Value 2">Option 2</asp:ListItem>
						</opgeek:combobox>
					</td>
				</tr>
			</table>
			<p>
				Dropdown baseline inline test:
					<SELECT id="sel2">
						<option>Dropdown 1</option>
						<option>Dropdown 2</option>
					</SELECT>
			</p>
			<p>
				ComboBox baseline inline test:
					<opgeek:combobox id="opg4" tabIndex="-1" runat="server" TextEntryEnabled="True">
						<asp:ListItem Value="Value 1">Option 1</asp:ListItem>
						<asp:ListItem Value="Value 2">Option 2</asp:ListItem>
					</opgeek:combobox>
			</p>
			<p>
				Textbox baseline inline test: <span><input type="text" id="txt1" name="txt1"/></span>
			</p>
			<p>
				<asp:textbox id="txt2" width="100px" runat="server"/>
			</p>
			<p>
				<opgeek:combobox id="opg5" width="100px" runat="server"/>
			</p>
		</form>
	</body>
</HTML>