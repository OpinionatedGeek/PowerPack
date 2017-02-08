<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A complete DHTML ComboBox!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack ComboBox Control
	</h2>

	<p>
		This control mimicks the Windows/GUI ComboBox.  It's a combination of a dropdown and
		a textbox.  Normal HTML only allows you to have one or other.  This PowerPack control
		uses sophisticated Dynamic HTML to provide a richer web form experience.
	</p>
	<h3>PowerPack ComboBox Control</h3>
	<p>
		This control will allow you to pick from any of the listed items, <b>or</b> it will
		allow you to type in a new value.
	</p>
	<blockquote><b>
		<opgeek:ComboBox id="cbDemoCombo" runat="server" midtext="<br>or<br>">
			<asp:listitem Text="Homer" />
			<asp:listitem Text="Marge" />
			<asp:listitem Text="Bart" />
			<asp:listitem Text="Lisa" />
			<asp:listitem Text="Maggie" />
		</opgeek:ComboBox>
		<asp:Button runat="server" id="submit_button" Text="Test!" />
		<br />
		ComboBox value:
		<%=cbDemoCombo.SelectedItem == null ? "" : cbDemoCombo.SelectedItem.Text%>
	</b></blockquote>
	<h3>Default HTML Control</h3>
	<p>
		Contrast the ASP.NET PowerPack ComboBox control with the default HTML control below.
		This default HTML control will only allow you to pick from any of the listed items.  If you need to enter
		a new value - you can't!
	</p>
	<blockquote><b>
		<asp:DropDownList id="ddDefault" runat="server">
			<asp:listitem Text="Homer" />
			<asp:listitem Text="Marge" />
			<asp:listitem Text="Bart" />
			<asp:listitem Text="Lisa" />
			<asp:listitem Text="Maggie" />
		</asp:DropDownList>
		<asp:Button runat="server" id="submit_button2" Text="Test!" />
		<br />
		DropDown value:
		<%=ddDefault.SelectedItem == null ? "" : ddDefault.SelectedItem.Text%>
	</b></blockquote>
</asp:content>