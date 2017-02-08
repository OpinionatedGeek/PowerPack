<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<HTML>
	<HEAD>
		<title>NoRepostValidator test</title>
	</HEAD>
	<body>
		<h2>
			NoRepostValidator
		</h2>
		<form name="myForm" runat="server">
			<asp:ValidationSummary Runat="server"/>
			Some Value: <opgeek:TextBox id="tbEmail" runat="server" />
			<opgeek:NoRepostValidator id="noReposts"
                     ErrorMessage="You have already submitted this form"
                     runat="server">Blah</opgeek:NoRepostValidator>
			<br />
	<opgeek:NoRepostValidator id="noRepostValidator"
                ErrorMessage="You have already submitted this form"
                runat="server">*</opgeek:NoRepostValidator>
			<asp:Button runat="server" text="Test!"/>
		</form>
	</body>
</HTML>
