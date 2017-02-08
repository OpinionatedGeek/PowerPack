<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A time-dependent way of showing content!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack ShowAtTime Control
	</h2>

	<p>
		This control allows you to show specific content at a specific time.  The example below will show either
		"Good Morning", "Good Afternoon", "Good Evening" or "Good Night" depending on the time of day.
	</p>
	<opgeek:note runat="server" ID="note">
		All times are based on the server's clock.
	</opgeek:note>
	<blockquote>
		<b>
			Good
			<opgeek:ShowAtTime StartAt="01/01/2002 00:00" StopAt="01/01/2002 06:00" IgnoreDateParts="true" runat="server" ID="Showattime1" NAME="Showattime1">
			<iftemplate>Night</iftemplate>
			<elsetemplate>
				<opgeek:ShowAtTime StartAt="01/01/2002 06:00" StopAt="01/01/2002 12:00" IgnoreDateParts="true" runat="server" ID="Showattime2" NAME="Showattime2">
					<iftemplate>Morning</iftemplate>
					<elsetemplate>
						<opgeek:ShowAtTime StartAt="01/01/2002 12:00" StopAt="01/01/2002 18:00" IgnoreDateParts="true" runat="server" ID="Showattime3" NAME="Showattime3">
							<iftemplate>Afternoon</iftemplate>
							<elsetemplate>Evening</elsetemplate>
						</opgeek:ShowAtTime>
					</elsetemplate>
				</opgeek:ShowAtTime>
			</elsetemplate>
			</opgeek:ShowAtTime>
		</b>
	</blockquote>
</asp:content>
