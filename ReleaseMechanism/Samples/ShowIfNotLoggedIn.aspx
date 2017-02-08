<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    Show content only to anonymous users!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack ShowIfNotLoggedIn Control
	</h2>
	
	<p>
		This control allows you to show or hide content based on whether the user is logged in or not.
	</p>
	<p>
		If you have <b>not</b> logged in to your site, you will see the phrase "This is shown only to users who have <b>not</b> logged in." below:
	</p>
	<opgeek:ShowIfNotLoggedIn runat="server" ID="sinliShow">
		<blockquote>
				<font color="red">This is shown only to users who have <b>not</b> logged in.</font>
		</blockquote>
	</opgeek:ShowIfNotLoggedIn>
	<opgeek:note runat="server">
		Compare this behaviour with that of the <a href='ShowIfLoggedIn.aspx'>ShowIfLoggedIn</a> control.
	</opgeek:note>
</asp:content>