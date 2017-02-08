<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A complete HTML/DHTML collapsible panel!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack CollapsiblePanel Control
	</h2>

	<p>
		This control allows you to have subsections of your form or page that are immediately available to your
		users, but aren't shown by default.  Here's a simple example:
	</p>
	<p>
		<opgeek:CollapsiblePanel Text="This is a simple collapsible panel (click to expand)." runat="server" ID="crPanel1">
			This is the body of the panel, which is shown when the title of the panel is clicked.
			This example is as simple as it gets.
		</opgeek:CollapsiblePanel>
	</p>
	<p>
		The CollapsiblePanel control takes full advantage of ASP.NET's built in Style functionality.  You can set
		the style for the title, the body, or the whole panel exactly the same way you always specify styles.
	</p>
	<p>
		<opgeek:CollapsiblePanel Text="This is another control, with some styles set."
			BackColor="darkslateblue"	
			TitleStyle-Decoration="NONE"
			TitleStyle-ForeColor="black"
			TitleStyle-Font-Bold="true"
			ExpandByDefault="true"
			BorderStyle="groove"
			BorderWidth="1"
			TitleStyle-BackColor="lightsteelblue"
			BodyStyle-BackColor="azure"
			runat="server" ID="CollapsiblePanel2">
			This control takes advantage of the configurable styles in the control to provide
			custom color and formatting. <b>Note: This control is expanded by default.</b>
		</opgeek:CollapsiblePanel>
	</p>
	<p>
	Of course, things can get pretty ugly...
	</p>
	<p>
		<opgeek:CollapsiblePanel Text="This is an ugly control"
			BackColor="brown"
			TitleStyle-Decoration="none"
			TitleStyle-ForeColor="white"
			TitleStyle-Font-Bold="true"
			BorderStyle="dotted"
			Width="500"
			TitleStyle-BackColor="cadetblue"
			BodyStyle-BackColor="antiquewhite"
			runat="server" ID="CollapsiblePanel3">
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
		<opgeek:CollapsiblePanel Text="This panel includes some nested controls."
			BackColor="LimeGreen"	
			TitleStyle-Decoration="NONE"
			TitleStyle-ForeColor="black"
			TitleStyle-Font-Bold="true"
			ExpandByDefault="false"
			BorderStyle="groove"
			BorderWidth="1"
			TitleStyle-BackColor="DarkSeaGreen"
			BodyStyle-BackColor="PaleGreen"
			runat="server" ID="CollapsiblePanel4">
			<p>
				Just to show it&#146;s possible, here&#146;s a collapsible panel <b>within</b> a
				collapsible panel.
				<blockquote>
				<opgeek:CollapsiblePanel Text="This is a simple nested control" 
					BackColor="silver"	
					BorderStyle="groove"
					BorderWidth="1"
					BodyStyle-BackColor="snow"
					runat="server" ID="CollapsiblePanel5">
					<p>
						This is the nested control&#146;s text.
					</p>
					<blockquote>
					<opgeek:CollapsiblePanel Text="This is another nested control" 
						BackColor="PaleGoldenrod"	
						BorderStyle="groove"
						BorderWidth="1"
						BodyStyle-BackColor="LightGoldenrodYellow"
						runat="server" ID="CollapsiblePanel6">
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
							runat="server" ID="CollapsiblePanel7">
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
	</p>
</asp:content>