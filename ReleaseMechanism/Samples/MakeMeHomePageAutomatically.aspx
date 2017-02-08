<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    An automatic prompt to set the user's home page!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack MakeMeHomePageAutomatically Control
	</h2>

	<p>
		This control automatically brings up a prompt to the user to make the current page their home page.
	</p>
	<p>
		Some people will hate this control, especially if it's over-used.  Please be nice!
	</p>
	<opgeek:note runat="server" ID="note">
		This control has no UI of its own, but you should have received the prompt text when the page loaded.
	</opgeek:note>
	<opgeek:MakeMeHomePageAutomatically id="testAutoHomepage" enabled="true" runat="server"/>
</asp:content>