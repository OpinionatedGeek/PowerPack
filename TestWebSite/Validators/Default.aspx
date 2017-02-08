<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<HTML>
	<HEAD>
		<title>EmailAddressValidator test</title>
	</HEAD>
	<body>
		<h2>
			EmailAddressValidator
		</h2>
		<form name="myForm" runat="server">
			<asp:ValidationSummary Runat="server"/>
			Email address: <opgeek:TextBox id="tbEmail" runat="server" />
			<opgeek:EmailAddressValidator ControlToValidate="tbEmail"
                     ErrorMessage="That email address is not valid"
                     Check="Server"
                     DnsServer="194.74.223.62"
                     runat="server">Blah</opgeek:EmailAddressValidator>
			<br />
			<asp:Button runat="server" text="Test!"/>
		</form>
	</body>
</HTML>
