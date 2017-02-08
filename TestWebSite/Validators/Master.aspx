<%@ Page Language="C#" EnableSessionState="false" debug="true" MasterPageFile="~/Validators/Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content id="HeaderTitleContent" contentplaceholderid="HeaderTitle" runat="server">
	NoRepostValidator test
</asp:content>
<asp:content id="TitleContent" contentplaceholderid="PageTitle" runat="server">
    NoRepostValidator
</asp:content>
<asp:content id="BodyContent" contentplaceholderid="Body" runat="server">
			<asp:ValidationSummary Runat="server"/>
			Some Value: <opgeek:TextBox id="tbEmail" runat="server" />
			<opgeek:NoRepostValidator
                ErrorMessage="You have already submitted this form"
                runat="server">*</opgeek:NoRepostValidator>
			<br />
			<asp:Button runat="server" text="Test!"/>
</asp:content>