<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    Fixed-width regions on your page!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack ScrollablePanel Control
	</h2>

	<p>
		At heart, this is a simple panel control that allows you to fix its width and height.  It's really
		simple, you just treat it like a Panel, give it a width and height, and if the content is too big
		for that region, scroll bars appear.
	</p>
	<p>
		Borders are shown on all these ScrollablePanels just to show you what's going on - they're not a
		requirement for the control.
	</p>
	<opgeek:scrollablepanel style="border: thin solid red;" runat="server">
		This is a scrollable panel with no width or height specified - just a regular panel.
	</opgeek:scrollablepanel>
	<p>
		This sample has both width and height specified, but since the content still fits within the region,
		scroll bars are unnecessary.
	</p>
	<opgeek:scrollablepanel style="border: thin solid red;" width="100" height="100" runat="server">
		This is a simple 100x100 scrollable panel.
	</opgeek:scrollablepanel>
	<p>
		Again, this sample has width and height specified, but this time there is too much content within the
		region so a scroll bar appears on the right of the panel to allow the user to see all the content.
	</p>
	<opgeek:scrollablepanel style="border: thin solid red;" width="100" height="100" runat="server">
		Lots of content.
		Lots of content.
		Lots of content.
		Lots of content.
		Lots of content.
		Lots of content.
		Lots of content.
		Lots of content.
		Lots of content.
	</opgeek:scrollablepanel>
	<p>
		This time the content is too wide for the region, so a vertical scroll bar appears.
	</p>
	<opgeek:scrollablepanel style="border: thin solid red;" width="100" height="100" runat="server">
		ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz
	</opgeek:scrollablepanel>
	<p>
		And finally, this example is derived from the W3C's 'overflow' example:
	</p>
	<opgeek:ScrollablePanel
	    id="Scrollablepanel3"
	    width="100px"
	    height="100px"
	    style="border: thin solid red;"
	    runat="server">
	    <BLOCKQUOTE style="width : 125px; height : 100px; margin-top: 50px; margin-left: 50px; border: thin dashed black;">
		    <P>I didn't like the play, but then I saw
		    it under adverse conditions - the curtain was up.
		    <DIV style="text-align : right;">- Groucho Marx</DIV>
	    </BLOCKQUOTE>
    </opgeek:ScrollablePanel>

	<br clear="right" />
</asp:content>