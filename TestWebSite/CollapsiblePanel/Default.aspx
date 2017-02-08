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
			<opgeek:CollapsiblePanel
				runat="server" ID="Collapsiblepanel0" NAME="CollapsiblePanel0">
				This has no text set.
			</opgeek:CollapsiblePanel>
		</p>
		<p>
			<opgeek:CollapsiblePanel Text="This is a simple collapsible panel in the default style."
				runat="server" ID="CollapsiblePanel1" NAME="CollapsiblePanel1">
				This is the contained body.  This example is as simple as it gets.
			</opgeek:CollapsiblePanel>
		</p>

		<p>
			<opgeek:CollapsiblePanel Text="<b>This is another control, with some styles set.</b>"
				enabled="true"
				BackColor="darkslateblue"	
				TitleStyle-Decoration="NONE"
				TitleStyle-ForeColor="black"
				ExpandByDefault="true"
				BorderStyle="groove"
				BorderWidth="1"
				Width="100%"
				TitleStyle-BackColor="lightsteelblue"
				BodyStyle-BackColor="azure"
				runat="server" ID="CollapsiblePanel2" NAME="CollapsiblePanel2">
				<%= DateTime.Now.ToString ("U") %>
				This control takes advantage of the configurable styles in the control to provide
				custom color and formatting. <b>Note: This control is expanded by default.</b>
			</opgeek:CollapsiblePanel>
		</p>

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

		<p>
		<opgeek:CollapsiblePanel Text="<b>This panel includes some nested controls.</b>"
			BackColor="LimeGreen"	
			TitleStyle-Decoration="NONE"
			TitleStyle-ForeColor="black"
			ExpandByDefault="false"
			BorderStyle="groove"
			BorderWidth="1"
			Width="100%"
			TitleStyle-BackColor="DarkSeaGreen"
			BodyStyle-BackColor="PaleGreen"
			runat="server" ID="CollapsiblePanel4" NAME="CollapsiblePanel4">
			<p>
				Just to show it&#146;s possible, here&#146;s a collapsible panel <b>within</b> a
				collapsible panel.
				<blockquote>
				<opgeek:CollapsiblePanel Text="This is a simple nested control" 
					BackColor="silver"	
					BorderStyle="groove"
					BorderWidth="1"
					BodyStyle-BackColor="snow"
					runat="server" ID="CollapsiblePanel5" NAME="CollapsiblePanel5">
					<p>
						This is the nested control&#146;s text.
					</p>
					<blockquote>
					<opgeek:CollapsiblePanel Text="This is another nested control" 
						BackColor="PaleGoldenrod"	
						BorderStyle="groove"
						BorderWidth="1"
						BodyStyle-BackColor="LightGoldenrodYellow"
						runat="server" ID="CollapsiblePanel6" NAME="CollapsiblePanel6">
						<p>
							This is the second nested control&#146;s text.
						</p>
						<blockquote>
						<opgeek:CollapsiblePanel Text="And another control" 
							TitleStyle-ForeColor="white"
							BackColor="MediumPurple"	
							BorderStyle="groove"
							BorderWidth="1"
							BodyStyle-BackColor="AliceBlue"
							runat="server" ID="CollapsiblePanel7" NAME="CollapsiblePanel7">
							<p>
								This is the text of the third nested control.
							</p>
						</opgeek:CollapsiblePanel>
						</blockquote>
					</opgeek:CollapsiblePanel>
					</blockquote>
				</opgeek:CollapsiblePanel>
				</blockquote>
		</opgeek:CollapsiblePanel>
		
		
		<table width="100%" border="0" bgcolor="red">
			<tr>
				<td>
							<opgeek:CollapsiblePanel Text="<b>Blah</b>"
								BackColor="darkslateblue"	
								TitleStyle-Decoration="NONE"
								TitleStyle-ForeColor="black"
								ExpandByDefault="true"
								BorderStyle="groove"
								BorderWidth="1"
								Width="70%"
								Height="300"
								TitleStyle-BackColor="lightsteelblue"
								BodyStyle-BackColor="azure"
								TitleVerticalAlign="top"
								BodyVerticalAlign="bottom"
								runat="server" ID="Collapsiblepanel8" NAME="CollapsiblePanel8">
								Widget
							</opgeek:CollapsiblePanel>

				</td>
			</tr>
		</table>
		</form>
	</body>
</html>