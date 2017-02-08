<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    An enhanced TextBox control!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
    <h2>
		ASP.NET PowerPack TextBox Control
	</h2>
	
	<p>
		This control builds on the default ASP.NET TextBox control to provide two new features:
		<ol>
			<li>You can now tell a textbox to take the default focus when the page loads.</li>
			<li>You can specify some 'prompt' text which disappears when the user clicks on the field.</li>
		</ol>
	</p>
	<p>
		This field takes the default focus when the page loads:
	</p>
	<blockquote>
		<opgeek:TextBox id="txtFocus" GrabFocus="True" runat="server" />
	</blockquote>
	<p>
		This field displays the prompt text "Click Me!", until the user enters that field.
	</p>
	<blockquote>
		<opgeek:TextBox id="txtPrompt" prompt="Click Me!" runat="server" />
	</blockquote>
</asp:content>