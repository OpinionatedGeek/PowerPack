<%@ Page Language="C#" EnableSessionState="false" debug="true" trace=true %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>Collapsible Panel test</title>
	</head>
	<body>
		<h2>
			Collapsible Panel
		</h2>
		<form name="myForm" runat="server" ID="Form1">
		<p>
			<opgeek:CollapsiblePanel Text="<b>This is an ugly control</b>"
				BackColor="brown"	
				TitleStyle-Decoration="none"
				TitleStyle-ForeColor="white"
				ExpandByDefault="true"
				BorderStyle="dotted"
				EnableClientScript="false"
				BorderWidth="1"
				Width="100%"
				TitleStyle-BackColor="cadetblue"
				BodyStyle-BackColor="antiquewhite"
				runat="server" ID="CollapsiblePanel3" NAME="CollapsiblePanel3">
				<p>
					OK, the CollapsiblePanel tag gives you a lot of control over the styles you
					can use as well as how you can apply them.  That means it&#146;s possible to
					come up with really ugly controls (like this hideous one) as well as
					beautiful ones.
				</p>
				<p>
					Sorry about that!
				</p>
				<p></p>
			</opgeek:CollapsiblePanel>
		</p>
		</form>
	</body>
</html>