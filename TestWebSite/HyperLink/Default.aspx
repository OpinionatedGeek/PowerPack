<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>HyperLink Test</title>
	</head>
	<body>
		<h1>
			HyperLink
		</h1>
		<form name="myForm" runat="server">
			<p>
				<asp:HyperLink bordercolor="Brown" borderstyle="Solid" id="hlRegular" forecolor="green" NavigateUrl="http://www.opinionatedgeek.com/" Text="A regular link to somewhere else" runat="server"/>.
			</p>
			<p>
				<opgeek:HyperLink bordercolor="Brown" borderstyle="Solid" id="hlDifferentPage" forecolor="green" NavigateUrl="http://www.opinionatedgeek.com/" Text="An OpGeek link to somewhere else" runat="server"/>.
			</p>
			<p>
				<opgeek:HyperLink bordercolor="Brown" borderstyle="Solid" id="hlThisPage" forecolor="green" NavigateUrl="/HyperLink/default.aspx" Text="A link to this page" runat="server"/>.
			</p>
			<p>
				<opgeek:HyperLink bordercolor="Brown" borderstyle="Solid" id="HyperLink1" forecolor="green" NavigateUrl="/HyperLink/default.aspx?url=http://trancefuryradio.com/podcasts.php" Text="A link to this page with a querystring after it" runat="server"/>.
			</p>
			<p>
				<opgeek:HyperLink id="hlThisPageAgain" forecolor="green" NavigateUrl="./" Text="A link to this page" runat="server"/>.
			</p>
		</form>
	</body>
</html>
