<%@ Page Language="C#" EnableSessionState="false" debug="true" trace=true%>
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
			<opgeek:collapsiblepanel text="<b>This is a control.</b>"
				width="50%"
				enabled="true"
				runat="server">
				<%= DateTime.Now.ToString ("U") %>
				This control takes advantage of the configurable styles in the control to provide
				custom color and formatting. <b>Note: This control is collapsed by default.</b>
			</opgeek:collapsiblepanel>
		</p>
		<p>
			<opgeek:collapsiblepanel text="<b>This is a much simpler setup.</b>"
				enabled="true"
				backcolor="darkslateblue"	
				titlestyle-decoration="NONE"
				titlestyle-forecolor="black"
				expandbydefault="true"
				borderstyle="groove"
				borderwidth="1"
				width="100%"
				titlestyle-backcolor="lightsteelblue"
				bodystyle-backcolor="azure"
				runat="server">
				Blurt.
			</opgeek:collapsiblepanel>
		</p>
		</form>
	</body>
</html>