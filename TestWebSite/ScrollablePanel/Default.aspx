<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>ScrollablePanel Test</title>
	</head>
	<body>
		<h1>
			ScrollablePanel
		</h1>
		<form name="myForm" runat="server">
<opgeek:ScrollablePanel
	id="ScrollablePanel17"
	width="50px"
	height="50px"
	runat="server">
	     I'm a scrollable panel!
</opgeek:ScrollablePanel>
			<p>
				Regular ScrollablePanel: <opgeek:ScrollablePanel id="ScrollablePanel1" runat="server">Just some random text</opgeek:ScrollablePanel>
			</p>
			<p>
				Big ScrollablePanel: <opgeek:ScrollablePanel id="ScrollablePanel2" height="50" width="500" runat="server">
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Left aligned note<opgeek:Note id="note3" align="left" runat="server">Some more random text</opgeek:Note>
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				Blah blah blah
				</opgeek:ScrollablePanel>
			</p>
			<p>This example is derived from the W3C example:</p>
<opgeek:ScrollablePanel
	id="Scrollablepanel3"
	width="100px"
	height="100px"
	style="border: thin solid red;"
	runat="server">
	<BLOCKQUOTE style="width : 125px; height : 100px; margin-top: 50px; margin-left: 50px; border: thin dashed black;">
		<P>I didn't like the play, but then I saw
		it under adverse conditions - the curtain was up.
		<DIV style="text-align : right;">- Groucho Marx</DIV>
	</BLOCKQUOTE>
</opgeek:ScrollablePanel>
		</form>
	</body>
</html>
