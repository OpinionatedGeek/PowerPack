<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A simple print LinkButton for web forms!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack PrintLinkButton Control
	</h2>

	<p>
		This control allows you to put a 'Print' LinkButton on any web form to bring up the 'Print' dialog.
	</p>
	<blockquote>
		<opgeek:PrintLinkButton id="lbPrint" runat="server"/>
	</blockquote>
</asp:content>