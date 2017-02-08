<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>Home Page Buttons Test</title>
	</head>
	<body>
		<h1>
			Home Page Buttons
		</h1>
		<form name="myForm" runat="server">
			<p>
				Button: <opgeek:MakeMeHomePageButton id="testButton" runat="server"/>
			</p>
			<p>
				LinkButton: <opgeek:MakeMeHomePageLinkButton id="testLinkButton" runat="server"/>
			</p>
			<p>
				ImageButton: <opgeek:MakeMeHomePageImageButton id="testImageButton" runat="server"/>
			</p>
			<p>
				ImageButton with non-existant image: <opgeek:MakeMeHomePageImageButton ImageUrl="/images/opgeek.gif" id="testImageButtonNoImage" runat="server"/>
			</p>
			<p>
				Alternatively, go <a href="autohomepage.aspx">here</a> for the auto-home page.
			</p>
		</form>
	</body>
</html>
