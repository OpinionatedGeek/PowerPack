<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<%@ Page Language="c#" EnableSessionState="false" debug="true" AutoEventWireup="false" %>
<HTML>
	<HEAD>
		<title>Designer test</title>
	</HEAD>
	<body>
		<h2>Designer tests
		</h2>
		<P>&nbsp;</P>
		<form name="myForm" runat="server">
			<table border="0">
				<tr>
					<th>
						Name</th>
					<th width="456">
						OpGeek controls</th>
					<th>
						Regular controls</th></tr>
				<tr>
					<td>CollapsiblePanel
					</td>
					<td width="456"><opgeek:collapsiblepanel id="CollapsiblePanel1" runat="server" Text="Some text"></opgeek:collapsiblepanel></td>
					<td><asp:panel id="Panel1" runat="server">Panel</asp:panel>
					</td>
				</tr>
				<tr>
					<td>ComboBox
					</td>
					<td width="456"><opgeek:combobox id="ComboBox1" runat="server" MidText="Fred"></opgeek:combobox></td>
					<td></td>
				</tr>
				<tr>
					<td>DatePicker
					</td>
					<td width="456"><opgeek:datepicker id="DatePicker1" runat="server"></opgeek:datepicker></td>
					<td></td>
				</tr>
				<tr>
					<td>EmailAddressValidator
					</td>
					<td width="456"><opgeek:emailaddressvalidator id="EmailAddressValidator1" runat="server"></opgeek:emailaddressvalidator></td>
					<td></td>
				</tr>
				<tr>
					<td>HyperLink
					</td>
					<td width="456"><opgeek:hyperlink id="HyperLink1" runat="server"></opgeek:hyperlink></td>
					<td><asp:hyperlink id="HyperLink2" runat="server">HyperLink</asp:hyperlink></td>
				</tr>
				<tr>
					<td>MakeMeHomePageAutomatically
					</td>
					<td width="456"><opgeek:makemehomepageautomatically id="MakeMeHomePageAutomatically1" runat="server"></opgeek:makemehomepageautomatically></td>
					<td></td>
				</tr>
				<tr>
					<td style="height: 26px">MakeMeHomePageButton
					</td>
					<td width="456" style="height: 26px"><opgeek:makemehomepagebutton id="MakeMeHomePageButton1" runat="server"></opgeek:makemehomepagebutton></td>
					<td style="height: 26px"><asp:button id="Button1" runat="server" Text="Button"></asp:button></td>
				</tr>
				<tr>
					<td>MakeMeHomePageImageButton
					</td>
					<td width="456"><opgeek:makemehomepageimagebutton id="MakeMeHomePageImageButton1" runat="server"></opgeek:makemehomepageimagebutton></td>
					<td><asp:imagebutton id="ImageButton1" runat="server"></asp:imagebutton></td>
				</tr>
				<tr>
					<td style="height: 20px">MakeMeHomePageLinkButton
					</td>
					<td width="456" style="height: 20px"><opgeek:makemehomepagelinkbutton id="MakeMeHomePageLinkButton1" runat="server"></opgeek:makemehomepagelinkbutton></td>
					<td style="height: 20px"><asp:linkbutton id="LinkButton1" runat="server">LinkButton</asp:linkbutton></td>
				</tr>
				<tr>
					<td>NoRepostValidator
					</td>
					<td width="456"><opgeek:norepostvalidator id="NoRepostValidator1" runat="server"></opgeek:norepostvalidator></td>
					<td><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<td>Note
					</td>
					<td width="456"><opgeek:note id="Note1" runat="server" Height="65px" Width="210px"></opgeek:note></td>
					<td></td>
				</tr>
				<tr>
					<td>PopupAutomatically
					</td>
					<td width="456"><opgeek:popupautomatically id="PopupAutomatically1" runat="server"></opgeek:popupautomatically></td>
					<td></td>
				</tr>
				<tr>
					<td>PopupButton
					</td>
					<td width="456"><opgeek:popupbutton id="PopupButton1" runat="server"></opgeek:popupbutton></td>
					<td><asp:button id="Button2" runat="server" Text="Button"></asp:button></td>
				</tr>
				<tr>
					<td>PopupImageButton
					</td>
					<td width="456"><opgeek:popupimagebutton id="PopupImageButton1" runat="server"></opgeek:popupimagebutton></td>
					<td><asp:imagebutton id="ImageButton2" runat="server"></asp:imagebutton></td>
				</tr>
				<tr>
					<td>PopupLinkButton
					</td>
					<td width="456"><opgeek:popuplinkbutton id="PopupLinkButton1" runat="server"></opgeek:popuplinkbutton></td>
					<td><asp:linkbutton id="LinkButton2" runat="server">LinkButton</asp:linkbutton></td>
				</tr>
				<tr>
					<td style="height: 42px">PrintAutomatically
					</td>
					<td width="456" style="height: 42px"><opgeek:printautomatically id="PrintAutomatically1" runat="server"></opgeek:printautomatically></td>
					<td style="height: 42px"></td>
				</tr>
				<tr>
					<td>PrintButton
					</td>
					<td width="456"><opgeek:printbutton id="PrintButton1" runat="server"></opgeek:printbutton></td>
					<td><asp:button id="Button3" runat="server" Text="Button"></asp:button></td>
				</tr>
				<tr>
					<td>PrintImageButton
					</td>
					<td width="456"><opgeek:printimagebutton id="PrintImageButton1" runat="server"></opgeek:printimagebutton></td>
					<td><asp:imagebutton id="ImageButton3" runat="server"></asp:imagebutton></td>
				</tr>
				<tr>
					<td>PrintLinkButton
					</td>
					<td width="456"><opgeek:printlinkbutton id="PrintLinkButton1" runat="server"></opgeek:printlinkbutton></td>
					<td><asp:linkbutton id="LinkButton3" runat="server">LinkButton</asp:linkbutton></td>
				</tr>
				<tr>
					<td>RichTextBox
					</td>
					<td width="456"><opgeek:richtextbox id="RichTextBox1" runat="server" Width="452px" Height="267px">This is the default text for the control.</opgeek:richtextbox></td>
					<td></td>
				</tr>
				<tr>
					<td>ShowAtTime
					</td>
					<td width="456"><opgeek:showattime id="ShowAtTime1" runat="server"></opgeek:showattime></td>
					<td></td>
				</tr>
				<tr>
					<td>ShowIfInRole
					</td>
					<td width="456"><opgeek:showifinrole id="ShowIfInRole1" runat="server"></opgeek:showifinrole></td>
					<td></td>
				</tr>
				<tr>
					<td>ShowIfLoggedIn
					</td>
					<td width="456"><opgeek:showifloggedin id="ShowIfLoggedIn1" runat="server"></opgeek:showifloggedin></td>
					<td></td>
				</tr>
				<tr>
					<td>ShowIfNotLoggedIn
					</td>
					<td width="456"><opgeek:showifnotloggedin id="ShowIfNotLoggedIn1" runat="server"></opgeek:showifnotloggedin></td>
					<td></td>
				</tr>
				<tr>
					<td>ShowOnConditionClientSide
					</td>
					<td width="456"><opgeek:showonconditionclientside id="ShowOnConditionClientSide1" runat="server"></opgeek:showonconditionclientside></td>
					<td></td>
				</tr>
				<tr>
					<td>ShowOnConditionServerSide
					</td>
					<td width="456"><opgeek:showonconditionserverside id="ShowOnConditionServerSide1" runat="server"></opgeek:showonconditionserverside></td>
					<td></td>
				</tr>
				<tr>
					<td>
						SwearFilter
					</td>
					<td width="456">
						<opgeek:SwearFilter id="SwearFilter1" runat="server"></opgeek:SwearFilter>
					</td>
					<td>
					</td>
				</tr>
				<tr>
					<td>
						TextBox
					</td>
					<td width="456">
						<opgeek:TextBox id="TextBox1" runat="server"></opgeek:TextBox>
					</td>
					<td>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
