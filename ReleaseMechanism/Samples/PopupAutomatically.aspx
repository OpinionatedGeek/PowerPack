<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    An automatic prompt to the user!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack PopupAutomatically Control
	</h2>

	<p>
		This control automatically brings up a specified prompt to the user when the page loads.
	</p>
	<opgeek:note runat="server" ID="note">
		This control has no UI of its own, but you should have received the prompt text 'This is an automatic popup!' as the page loaded.
	</opgeek:note>
	<opgeek:PopupAutomatically id="paAutoPopup" popuptext="This is an automatic popup!" runat="server"/>
</asp:content>