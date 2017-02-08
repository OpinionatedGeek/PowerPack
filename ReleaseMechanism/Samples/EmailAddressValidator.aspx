<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A complete email address validation package!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack EmailAddressValidator Control
	</h2>
	<asp:ValidationSummary Runat="server"/>
	Email address: <opgeek:TextBox id="tbEmail" runat="server" />
	<opgeek:EmailAddressValidator ControlToValidate="tbEmail"
             ErrorMessage="That email address is not valid"
             Check="Server"
             runat="server">*</opgeek:EmailAddressValidator>
	<br />
	<asp:Button runat="server" text="Test!"/>
</asp:content>