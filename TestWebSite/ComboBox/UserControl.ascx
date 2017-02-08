<%@ Control Language="c#" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
			<opgeek:combobox id="cbId" runat="server" midtext="<br>or<br>" autopostback="true">
				<asp:listitem value="Test 1" />
				<asp:listitem value="Test 2" />
				<asp:listitem value="Test 3" />
			</opgeek:combobox>
