<%@ Page Language="C#" MasterPageFile="~/Master.master" EnableSessionState="false" debug="true" trace=true validaterequest="false" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<form runat="server">
		<opgeek:RichTextBox id="widget" prompt="Testing..." rows="21" columns="45" name="test" font-name="Helvetica" runat="server">
			Some 
			<b>more</b>
			designer default contents</opgeek:RichTextBox>
		<asp:Button text="Submit" runat="server"/>
		<p>
			Got text:
			<%=widget.Text%>
		</p>
	</form>
</asp:content>