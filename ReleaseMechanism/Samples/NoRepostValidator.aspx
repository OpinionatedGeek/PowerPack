<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A validation control to ensure no duplicate submissions!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack NoRepostValidator Control
	</h2>
	<asp:ValidationSummary Runat="server"/>
	Some Value: <opgeek:TextBox id="tbEmail" runat="server" />
	<opgeek:NoRepostValidator
             ErrorMessage="You have already submitted this form"
             runat="server">*</opgeek:NoRepostValidator>
	<br />
	<asp:Button runat="server" text="Test!"/>
</asp:content>