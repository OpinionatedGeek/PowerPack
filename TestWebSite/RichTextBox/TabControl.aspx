<%@ Page Language="C#" validaterequest="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<HTML>
	<head runat="server">
		<title>RichTextBox test</title>
	</head>
	<body>
		<h2>
			RichTextBox
		</h2>
		<form name="myForm" runat="server">
		    <asp:ScriptManager runat="server" />
            <ajaxToolkit:TabContainer runat="server" ID="Tabs" Height="138px" Width="402px">
                <ajaxToolkit:TabPanel runat="server" ID="Panel1" HeaderText="RichTextBox 1">
                    <ContentTemplate>
					    <opgeek:RichTextBox id="RichTextBox1" rows="14" columns="70" name="test"
						    font-name="Helvetica" runat="server" />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" ID="Panel2" HeaderText="RichTextBox 2">
                    <ContentTemplate>
					    <opgeek:RichTextBox id="RichTextBox2" rows="14" columns="70" name="test"
						    font-name="Helvetica" runat="server" />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
			<asp:Button runat="server" text="Test!"/>
		</form>
		<p>
			Got text 1:
			<%=RichTextBox1.Text%>
		</p>
		<p>
			Got text 2:
			<%=RichTextBox2.Text%>
		</p>
	</body>
</HTML>
