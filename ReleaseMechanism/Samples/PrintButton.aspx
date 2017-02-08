<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A simple print button for web forms!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack PrintButton Control
	</h2>

	<p>
		This control allows you to put a 'Print' button on any web form to bring up the 'Print' dialog.
	</p>
	<blockquote>
		<opgeek:PrintButton id="butPrint" runat="server"/>
	</blockquote>
</asp:content>