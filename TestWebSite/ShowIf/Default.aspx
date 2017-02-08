<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>ShowIf test</title>
	</head>
	<body>
		<h2>
			ShowIf
		</h2>
		<form name="myForm" runat="server">
			<h3>ShowIfLoggedIn</h3>
			<p>
				<opgeek:ShowIfLoggedIn runat="server">
					<blockquote>
						This is the contained body.  Current DateTime is <%=DateTime.Now.ToString ("U")%>.
					</blockquote>
				</opgeek:ShowIfLoggedIn>
			</p>
			<h3>ShowIfNotLoggedIn</h3>
			<p>
				<opgeek:ShowIfNotLoggedIn runat="server">
					<blockquote>
						This is the contained body.  Current DateTime is <%=DateTime.Now.ToString ("U")%>.
					</blockquote>
				</opgeek:ShowIfNotLoggedIn>
			</p>
			<h3>ShowIfInRole</h3>
			<p>
				<opgeek:ShowIfInRole roles="HAVOC\roletest" runat="server">
					<blockquote>
						This is shown for role "HAVOC\roletest".  Current DateTime is <%=DateTime.Now.ToString ("U")%>.
					</blockquote>
				</opgeek:ShowIfInRole>
				<opgeek:ShowIfInRole roles="widget" runat="server">
					<blockquote>
						This is shown for roles "widget".  Current DateTime is <%=DateTime.Now.ToString ("U")%>.
					</blockquote>
				</opgeek:ShowIfInRole>
			</p>
		</form>
	</body>
</html>
