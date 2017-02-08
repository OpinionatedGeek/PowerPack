<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    Show content only to users assigned specific roles!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack ShowIfInRole Control
	</h2>
	
	<p>
		This control allows you to show or hide content based on whether the user is assigned a specific role.
	</p>
	<p>
		This example is set to show the phrase <b>"This is shown only to users who are in the 'user' role."</b>
		below if you are a member of the 'user' role:
	</p>
	<opgeek:ShowIfInRole roles="user" runat="server" ID="siirShow">
		<blockquote>
				<font color="red">This is shown only to users who are in the 'user' role.</font>
		</blockquote>
	</opgeek:ShowIfInRole>
</asp:content>