<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>ShowAtTime test</title>
	</head>
	<body>
		<h2>
			ShowAtTime
		</h2>
		<form name="myForm" runat="server">
			<h3>Part 1</h3>
			<p>
				<opgeek:ShowAtTime StartAt="04/01/2002 21:00" StopAt="06/01/2004 21:55" runat="server">
				    <iftemplate>
        				This is the contained body.  This example (with some code: current DateTime is <%=DateTime.Now.ToString ("U")%>) is about as simple as it gets.
				    </iftemplate>
				</opgeek:ShowAtTime>
			</p>
			<h3>Part 2</h3>
			<p>
				<opgeek:ShowAtTime StartAt="04/01/2002 21:00" StopAt="05/01/2002 21:55" runat="server">
				<iftemplate>
				This is the contained body (which should be hidden).
				</iftemplate>
				<elsetemplate>This is the else part (which should be displayed).</elsetemplate>
				</opgeek:ShowAtTime>
			</p>
			<h3>Part 3 - Daytime test</h3>
			<p>
				Good
				<opgeek:ShowAtTime StartAt="01/01/2001 00:00" StopAt="01/01/2001 06:00" IgnoreDateParts="true" runat="server">
				<iftemplate>Night</iftemplate>
				<elsetemplate>
					<opgeek:ShowAtTime StartAt="01/01/2001 06:00" StopAt="01/01/2001 12:00" IgnoreDateParts="true" runat="server">
						<iftemplate>Morning</iftemplate>
						<elsetemplate>
							<opgeek:ShowAtTime StartAt="01/01/2001 12:00" StopAt="01/01/2001 18:00" IgnoreDateParts="true" runat="server">
								<iftemplate>Afternoon</iftemplate>
								<elsetemplate>Evening</elsetemplate>
							</opgeek:ShowAtTime>
						</elsetemplate>
					</opgeek:ShowAtTime>
				</elsetemplate>
				</opgeek:ShowAtTime>
			</p>
		</form>
	</body>
</html>
