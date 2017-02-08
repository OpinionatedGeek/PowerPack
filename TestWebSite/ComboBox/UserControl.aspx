<%@ Page Language="C#" EnableSessionState="false" debug="true"%>
<%@ Register TagPrefix="uc" TagName="UserControl" Src="UserControl.ascx" %>
<html>
	<head>
		<title>UserControl test</title>
	</head>
	<body>
		<h1>
			UserControl
		</h1>
		<form name="myForm" runat="server">
			<h2>
				An OpGeek UserControl
			</h2>
			<uc:UserControl id="cbId" runat="server"/>
		</form>
	</body>
</html>
