<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    An auto-print facility for web forms!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack PrintAutomatically Control
	</h2>

	<p>
		This control allows any web form to automatically bring up the 'Print' dialog once the page is loaded.
		This can be useful for invoices etc.
	</p>
	<opgeek:note runat="server" ID="note">
		This control has no UI of its own, but you should have seen the print dialog appear as soon as the page loaded.
	</opgeek:note>
	<opgeek:PrintAutomatically id="paAutoPrint" runat="server"/>
</asp:content>