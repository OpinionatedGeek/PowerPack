<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A simple swear-filter control!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack SwearFilter Control
	</h2>

	<p>
		This control allows filtering of the tag's contents, no matter where the contents came from - static HTML,
		database tables, or programmed control content.
	</p>
	<blockquote>
		<opgeek:note runat="server" ID="note">
			The tag is currently filtering:
				<ul>
					<li>Homer (replaced with 'DOh!')</li>
					<li>Marge (default replacement)</li>
					<li>Bart (replaced with 'Bartholomew')</li>
					<li>Lisa (default replacement)</li>
					<li>Maggie (default replacement)</li>
				</ul>
		</opgeek:note>
	</blockquote>

	<opgeek:RichTextBox height="200" width="400" id="rtfText" contents="" selectedfont="helvetica" runat="server"/>
	<br>
	<asp:Button runat="server" Text="Test!" id="butSubmit"/>

	<% if (rtfText.Text != String.Empty) {%>
		<h3>Filtered Text:</h3>
		<p>
			<opgeek:SwearFilter id="filter" runat="server">
				<%=rtfText.Text%>
			</opgeek:SwearFilter>
		</p>
	<%}%>
</asp:content>