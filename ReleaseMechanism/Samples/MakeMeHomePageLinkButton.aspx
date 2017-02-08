<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A LinkButton to set the user's home page!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack MakeMeHomePageLinkButton Control
	</h2>
	
	<p>
		When pressed, this LInkButton automatically brings up a prompt to the user to make the
		current page their home page.
	</p>
	<p>
		In all other respects, this button works just like the default LinkButton WebControl.
	</p>
	<p>
		Click below for a demonstration:
	</p>
	<blockquote>
		<opgeek:MakeMeHomePageLinkButton id="lbHomepage" enabled="true" runat="server"/>
	</blockquote>
</asp:content>