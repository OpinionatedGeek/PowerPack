<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Import namespace="OpinionatedGeek.Web.PowerPack.Licensing"%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>Note Test</title>
	</head>
	<body>
		<h1>
			Note
		</h1>
		<form name="myForm" runat="server">
			<p>
				Regular Note: <opgeek:Note id="note1" runat="server">Just some random text</opgeek:Note>
			</p>
			<p>
				Note with title: <opgeek:Note id="note2" Title="Note" runat="server">Some text with a note.</opgeek:Note>
			</p>
			<p>
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
			</p>
			<p>
				Blah blah blah
				Right aligned note: <opgeek:Note id="note4" align="right" runat="server">Just some random text</opgeek:Note>
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
			</p>
			<p>
				Styled note: <opgeek:Note id="note5" font-name="helvetica" backcolor="red" forecolor="white" runat="server">Some styled text</opgeek:Note>
			</p>
			<p>
				Styled panel: <asp:panel id="Note7" font-name="helvetica" backcolor="red" forecolor="white" runat="server">Some styled text</asp:panel>
			</p>
			<p>
				Aligned note: <opgeek:Note id="note6" font-name="helvetica" width="200" horizontalalign="right" runat="server">Some text some text some text some text some text some text some text some text some text some text some text some text some text some text some text some text some text </opgeek:Note>
			</p>
		</form>
	</body>
</html>
<script runat="server" language="c#">
    protected override void OnLoad (EventArgs e)
    {
        base.OnLoad (e);

        //NoteLicenseProvider license = new NoteLicenseProvider ();
        //Response.Write ("<h1>Success - " + license.ToString () + "</h1>");

        return;
    }
</script>