<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    An ImageButton MessageBox prompt to the user!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack PopupImageButton Control
	</h2>

	<p>
		This control brings up an 'OK' MessageBox-type prompt (with designer-specified text) to the user when
		the button is pressed.
	</p>
	<blockquote>
		<opgeek:PopupImageButton id="ibPopupAlert" AlertOnly="True" PopupText="This is just an alert - you can only press 'OK'" runat="server" />
	</blockquote>
	<p>
		This control brings up an 'OK/Cancel' MessageBox-type prompt (with designer-specified text) to the user
		when the button is pressed, allowing the user to cancel out of an operation.
	</p>
	<blockquote>
		<opgeek:PopupImageButton id="ibPopupConfirm" AlertOnly="False" PopupText="This is just a confirmation request - you can press 'OK' or 'Cancel'" runat="server" />
	</blockquote>
</asp:content>