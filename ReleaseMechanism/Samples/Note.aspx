<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    Sticky Notes on your web pages!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack Note Control
	</h2>

	<p>
		At heart, this is a simple sticky-note control.  It's really simple, you just treat it like a Panel
		and it separates out its contents into a highlighted yellow rectangle.
	</p>
	<opgeek:note runat="server">This is a sample note.</opgeek:note>
	<p>
		It's a bit more effective than a regular panel because it separates out the contents and draws attention
		to them.  It's particularly effective when it's used as a sidebar with the text flowing around it:
	</p>
	<p>
		<opgeek:note runat="server" width="200" align="right">A sample note aligned on the right.</opgeek:note>
		Sample text. Sample text. Sample text. Sample text. Sample text. Sample text. Sample text. Sample text.
		Sample text. Sample text. Sample text. Sample text. Sample text. Sample text. Sample text. Sample text.
		<opgeek:note runat="server" width="200" align="left">A sample note aligned on the left.</opgeek:note>
		Sample text. Sample text. Sample text. Sample text. Sample text. Sample text. Sample text. Sample text.
		Sample text. Sample text. Sample text. Sample text. Sample text. Sample text. Sample text. Sample text.
	</p>
	<p>
		And if you don't like the default color our style, you can of course change them.
	</p>
	<opgeek:note runat="server" backcolor="LightGreen" font-name="verdana" align="right" BorderWidth="7" horizontalalign="right" width="200">
		This is a sample note with a green backcolor, a different font (verdana), a bigger border,
		and the contained text aligned on the right.
	</opgeek:note>

	<br clear="right" />
</asp:content>