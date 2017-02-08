<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    An enhanced HyperLink Control!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack HyperLink Control
	</h2>
	
	<p>
		This control builds on the default ASP.NET HyperLink control to provide one new feature: by default
		the control doesn't generate a link if the NavigateUrl property points to the current page.  Instead
		it just generates the styled text (as is the default HyperLink behaviour if no NavigateUrl property
		is specified).
	</p>
	<p>
		This link goes to a different page, so will be shown as a link:
	</p>
	<blockquote>
		<opgeek:HyperLink id="hlDifferentPage" navigateurl="http://www.opinionatedgeek.com/" text="A different page" runat="server" />
	</blockquote>
	<p>
		This link goes to the current page, so will <b>not</b> be shown as a link:
	</p>
	<blockquote>
		<opgeek:HyperLink id="hlSamePage" navigateurl="HyperLink.aspx" text="The current page" runat="server" />
	</blockquote>
	<p>
		This link goes to the current page, but has a different querystring component and so will be shown as a link:
	</p>
	<blockquote>
		<opgeek:HyperLink id="hlSamePageWithQueryString" navigateurl="HyperLink.aspx?widget=1" text="The current page, but with a querystring" runat="server" />
	</blockquote>
</asp:content>