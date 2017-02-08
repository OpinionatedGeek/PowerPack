<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A complete DHTML RichTextBox!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack RichTextBox Control
	</h2>

	<p>
		This control mimicks the Windows/GUI RichTextBox.  Unfortunately, only Internet Explorer supports
		this type of editing and so the control works best in IE5 or higher.  That's still a significant
		number of users though, and users of other browsers will just see the default HTML TEXTAREA field.
	</p>
	<h3>PowerPack RichTextBox Control</h3>
	<p>
		Enter some rich text:
	</p>
	<opgeek:RichTextBox id="rtfText" rows="21" columns="60" runat="server" />
	<asp:Button runat="server" text="Submit Text" ID="butSubmit"/>
	<%if (rtfText.Text != String.Empty) {%>
		<h4>
			Submitted HTML text:
		</h4>
		<p>
			<%=rtfText.Text%>
		</p>
	<%}%>
</asp:content>