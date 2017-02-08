<%@ Page Language="C#" EnableSessionState="false" debug="true"%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en">
<html>
	<head>
		<title>combo_test</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body ms_positioning="flowlayout">
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<asp:panel  wrap=True id="Panel1" style="overflow:auto; position:absolute" runat="server"
				width="176px" height="208px">
				<opgeek:combobox id="insert_Name" runat="server" width="200px"></opgeek:combobox>
			</asp:panel>
		</form>
	</body>
</html>
