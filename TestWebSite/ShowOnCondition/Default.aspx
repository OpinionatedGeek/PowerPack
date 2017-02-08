<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>ShowOnCondition test</title>
	</head>
	<body>
		<h2>
			ShowOnCondition
		</h2>
		<form name="myForm" runat="server">
			<table border=0>
				<tr>
					<td valign=top>
						<h3>ShowOnConditionServerSide</h3>
						<p>
							<asp:RadioButtonList Runat="server" ID="rb1">
								<asp:ListItem Value="value1"/>
								<asp:ListItem Value="value2"/>
								<asp:ListItem Value="value3"/>
								<asp:ListItem Value="value4"/>
							</asp:RadioButtonList>
							<asp:Panel Runat=server ID="pan1rb1">
								This text is <b>hidden</b> when 'value3' is selected.
							</asp:Panel>
							<asp:Panel Runat=server ID="pan2rb1">
								This text is <b>shown</b> when 'value3' is selected.
							</asp:Panel>
							<asp:RequiredFieldValidator Runat=server ControlToValidate=rb1 ErrorMessage="You must select yada yada"/>
							<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan1rb1" ControlToTest="rb1" ShowOnConditionValue="value3" debug="true"/>
							<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan2rb1" ControlToTest="rb1" ShowOnConditionNotValue="value3" debug="true"/>
						</p>
						<p>
							<asp:DropDownList Runat="server" ID="dd1">
								<asp:ListItem Value="value1"/>
								<asp:ListItem Value="value2"/>
								<asp:ListItem Value="value3"/>
								<asp:ListItem Value="value4"/>
							</asp:DropDownList>
							<asp:Panel Runat=server ID="pan1DD1">
								This text is <b>hidden</b> after a postback when 'value3' is selected.
							</asp:Panel>
							<asp:Panel Runat=server ID="pan2DD1">
								This text is <b>shown</b> after a postback when 'value3' is selected.
							</asp:Panel>
							<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan1DD1" ControlToTest="dd1" ShowOnConditionValue="value3"/>
							<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan2DD1" ControlToTest="dd1" ShowOnConditionNotValue="value3"/>
						</p>
						<p>
							<asp:TextBox Runat="server" ID="txt1" />
							<asp:Panel Runat=server ID="pan1Txt1">
								This text is <b>hidden</b> after a postback when 'widget' is entered.
							</asp:Panel>
							<asp:Panel Runat=server ID="pan2Txt1">
								This text is <b>shown</b> after a postback when 'widget' is entered.
							</asp:Panel>
							<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan1Txt1" ControlToTest="txt1" ShowOnConditionValue="widget"/>
							<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan2Txt1" ControlToTest="txt1" ShowOnConditionNotValue="widget"/>

							<asp:Button Runat="server" text="PostBack" ID="butPost"/>
						</p>
					</td>
					<td valign=top>
						<h3>ShowOnConditionClientSide</h3>
						<p>
							<asp:RadioButtonList Runat="server" ID="rb2">
								<asp:ListItem Value="value1"/>
								<asp:ListItem Value="value2"/>
								<asp:ListItem Value="value3"/>
								<asp:ListItem Value="value4"/>
							</asp:RadioButtonList>
							<asp:Panel Runat=server ID="pan1rb2">
								This text is <b>hidden</b> when 'value3' is selected.
							</asp:Panel>
							<asp:Panel Runat=server ID="pan2rb2">
								This text is <b>shown</b> when 'value3' is selected.
							</asp:Panel>
							<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan1rb2" ControlToTest="rb2" ShowOnConditionValue="value3" debug="true"/>
							<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan2rb2" ControlToTest="rb2" ShowOnConditionNotValue="value3" debug="true"/>
						</p>
						<p>
							<asp:DropDownList Runat="server" ID="dd2">
								<asp:ListItem Value="value1"/>
								<asp:ListItem Value="value2"/>
								<asp:ListItem Value="value3"/>
								<asp:ListItem Value="value4"/>
							</asp:DropDownList>
							<asp:Panel Runat=server ID="pan1DD2">
								This text is <b>hidden</b> when 'value3' is selected.
							</asp:Panel>
							<asp:Panel Runat=server ID="pan2DD2">
								This text is <b>shown</b> when 'value3' is selected.
							</asp:Panel>
							<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan1DD2" ControlToTest="dd2" ShowOnConditionValue="value3" debug="true"/>
							<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan2DD2" ControlToTest="dd2" ShowOnConditionNotValue="value3" debug="true"/>
						<p>
						</p>
							<asp:TextBox Runat="server" ID="txt2" />
							<asp:Panel Runat=server ID="pan1txt2">
								This text is <b>hidden</b> when 'widget' is entered.
							</asp:Panel>
							<asp:Panel Runat=server ID="pan2txt2">
								This text is <b>shown</b> when 'widget' is entered.
							</asp:Panel>
							<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan1txt2" ControlToTest="txt2" ShowOnConditionValue="widget"/>
							<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan2txt2" ControlToTest="txt2" ShowOnConditionNotValue="widget"/>
						</p>
						<p>
							<asp:TextBox Runat="server" TextMode=MultiLine ID="txt3" />
							<asp:Panel Runat=server ID="pan1txt3">
								This text is <b>hidden</b> when the textbox is blank.
							</asp:Panel>
							<asp:Panel Runat=server ID="pan2txt3">
								This text is <b>shown</b> when the textbox is blank.
							</asp:Panel>
							<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan1txt3" ControlToTest="txt3" ShowOnConditionValue=""/>
							<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan2txt3" ControlToTest="txt3" ShowOnConditionNotValue=""/>
						</p>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
