<%@ Page Language="C#" EnableSessionState="false" debug="true" trace=true%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>

<!doctype html public "-//w3c//dtd html 4.01 transitional//en" "http://www.w3.org/tr/html4/loose.dtd">
<html>
<!-- #BeginTemplate "../../../../unbranded.dwt" -->
<head>
	<meta name="ProgId" content="SharePoint.WebPartPage.Document">
	<meta name="WebPartPageExpansion" content="full">
	<!-- #BeginEditable "doctitle" -->
<title>A complete DHTML DatePicker!</title>
	<!-- #EndEditable -->
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
	<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	<link href="../../../../opgeek.css" rel="stylesheet" type="text/css">
	<!-- #BeginEditable "clientscript" -->
	<!-- #EndEditable -->
</head>
<body bgcolor="#ffffff">
	<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
		<tr>
			<td width="766" align="left" valign="top"><table width="766"  border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td align="left" valign="top" width="766" height="110">
						<a href="/" title="OpinionatedGeek Ltd. :: Part of the solution">
						<img src="../../../../Images/title.jpg" width="766" height="110" border="0"/></a>
					</td>
				</tr>
				<tr>
					<td align="left" valign="top">
					<table width="765"  border="0" cellspacing="0" cellpadding="0" background="../../../../Images/toolbar.gif" height="70">
						<tr align="left" valign="top">
							<td width="112" height="70"><div class="buttontext">
								<a class="buttontext" href="../../../../About/default.aspx">About Us</a></div></td>
							<td width="112" height="70"><div class="buttontext">
								<a class="buttontext" href="../../default.aspx">Products</a></div></td>
							<td width="112" height="70"><div class="buttontext">
								<a class="buttontext" href="../../../Wiki/default.aspx">DotNetWiki</a></div></td>
							<td width="112" height="70"><div class="buttontext">
								<a class="buttontext" href="../../../../Support/default.aspx">Support</a></div></td>
							<td width="112" height="70"><div class="buttontext">
								<a class="buttontext" href="../../../../Contact/default.aspx">Contact</a></div></td>
							<td width="10"></td>
							<td background="../../../../Images/search_background.gif" width="195"><div style="padding-left:9px; padding-top:17px">
								<table width="100%"  border="0" cellspacing="0" cellpadding="0">
									<tr>
										<td width="42" align="left" valign="top">
										<img src="../../../../Images/magnifier.jpg" width="29" height="28"></td>
										<td align="left" valign="top"><span class="textboxprompt">
											Search:</span><br>
											<input type="text" name="textfield3" style="width:88px; height:17px; font-family:tahoma; font-size:10px "> <a href="#">
										<img src="../../../../Images/button_go.jpg" width="36" height="17" border="0" align="absmiddle"></a>
										</td>
									</tr>
								</table>
							</div></td>
						</tr>
					</table></td>
				</tr>
			</table></td>
			<td width="100%" align="left" valign="top" background="../../../../Images/title_extension.jpg" style="background-repeat:repeat-x">&nbsp;</td>
		</tr>
		<tr>
			<td width="766" align="left" valign="top"><table width="766"  border="0" cellspacing="0" cellpadding="0">
				<tr align="left" valign="top">
					<td width="176"><div style="padding-left:4px; padding-top:6px">
						<table width="153"  border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td align="left" valign="top">
									<table width="160"  border="0" cellpadding="0" cellspacing="0" background="../../../../Images/highlight_body_narrow.gif">
										<tr>
											<td align="left" width="160" height="29" background="../../../../Images/highlight_top_narrow.gif">&nbsp;<b><font face="Verdana" color="#FFFFFF" size="2"> ASP.NET PowerPack</font></b></td>
										</tr>
										<tr>
											<td align="left" valign="top"><div style="padding-left:12px; padding-top:13px; padding-right: 4px">
												<a href="../default.aspx">
												<img src="../../../../Images/laptop_cluster.jpg" border="0"></a>
												<div class="ancillarytext" style="padding-left:0px; padding-top:18px; padding-bottom:20px"> 
												<span class="emphasis">The ASP.NET PowerPack</span> contains 28 rich, cross-browser controls including:<br>
													&nbsp;- 
													<b> 
													<a class="ancillarytext" href="richtextbox.aspx">RichTextBox</a></b><br />
													&nbsp;- <b> 
												<a class="ancillarytext" href="combobox.aspx">ComboBox</a></b><br />
													&nbsp;- <b> 
												<a class="ancillarytext" href="datepicker.aspx">DatePicker</a></b><br />
													&nbsp;- 
													<b> 
													<a class="ancillarytext" href="norepostvalidator.aspx">No-Repost validator</a></b><p>
												</span>
												Try the ASP.NET PowerPack free today!<br />
												&nbsp;- <b> 
												<a class="ancillarytext" href="../default.aspx">More Info</a></b><br />
												&nbsp;-
												<b>
												<a class="ancillarytext" href="../Download.aspx">
												Download</a></b><br />
												&nbsp;-
												<b>
												<a class="ancillarytext" href="../Buy/Prices.aspx">
												Price List</a></b><br />
												&nbsp;-
												<b>
												<a class="ancillarytext" href="../Licensing.aspx">
												Licensing</a></b><br />
												&nbsp;-
												<b>
												<a class="ancillarytext" href="../Buy/Default.aspx">
												Buy Now!</a></b><br /></div>
											</div></td>
										</tr>
										<tr>
											<td align="left" valign="top" background="../../../../Images/highlight_bottom_narrow.gif" height="22">&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="left" valign="top"><div style="padding-left:0px; padding-top:8px; padding-bottom:7px">
									<table width="160"  border="0" cellpadding="0" cellspacing="0" background="../../../../Images/highlight_body_narrow.gif">
										<tr>
											<td align="left" width="160" height="29" background="../../../../Images/highlight_top_narrow.gif">&nbsp;&nbsp;&nbsp;&nbsp;<b><font size="2" face="Verdana" color="#FFFFFF">Web Tools</font></b></td>
										</tr>
										<tr>
											<td align="left" valign="top">
						                        <div style="padding-left: 14px; padding-top: 7px; padding-right: 4px">
													&nbsp;- <b>
													<a class="ancillarytext" href="../../../Wiki/default.aspx">The DotNetWiki</a></b><br />
													&nbsp;- <b>
													<a class="ancillarytext" href="../../../Tools/Colors/default.aspx">ASP.NET Colors</a></b><br />
													&nbsp;- <b>
													<a class="ancillarytext" href="../../../Tools/Base64Encode/default.aspx">Base64 Encode</a></b><br />
													&nbsp;- <b>
													<a class="ancillarytext" href="../../../Tools/Base64Decode/default.aspx">Base64 Decode</a></b><br />
													&nbsp;- <b>
													<a class="ancillarytext" href="../../../Tools/CrazyIP/default.aspx">Crazy IPs</a></b><br />
													&nbsp;- <b>
													<a class="ancillarytext" href="../../../Tools/Whois/default.aspx">Whois</a></b><br />
													<br />
												</div>
											</td>
										</tr>
										<tr>
											<td align="left" valign="top" background="../../../../Images/highlight_bottom_narrow.gif" height="22">&nbsp;</td>
										</tr>
									</table>
								</div></td>
							</tr>
							<tr>
								<td align="left" valign="top"><div style="padding-left:0px; padding-top:8px; padding-bottom:7px">
									<table width="160"  border="0" cellpadding="0" cellspacing="0" background="../../../../Images/highlight_body_narrow.gif">
										<tr>
											<td align="left" width="160" height="29" background="../../../../Images/highlight_top_narrow.gif">&nbsp;&nbsp;&nbsp;&nbsp;<b><font size="2" face="Verdana" color="#FFFFFF">Windows Tools</font></b></td>
										</tr>
										<tr>
											<td align="left" valign="top">
						                        <div style="padding-left: 14px; padding-top: 7px; padding-right: 4px">
													<b>
													<a class="ancillarytext" href="/DotNet/Products/ConnTest/">ADO.NET ConnTest</a></b><br>
													A simple, free Windows 
													program to test ADO.NET 
													connection strings.<p><b>
													<a class="ancillarytext" href="/DotNet/Products/LinesOfCSharp/">Lines of C#</a></b><br>
													Ever wanted to know how many 
													lines of C# code are in a 
													file or folder hierarchy?&nbsp; 
													This free Windows program 
													will tell you.</p>
													<p><b>
													<a class="ancillarytext" href="/DotNet/Products/XmlTools/">XmlTools</a></b><br>
													Free tools to process XML 
													files from the command line.<br />
												</div>
											</td>
										</tr>
										<tr>
											<td align="left" valign="top" background="../../../../Images/highlight_bottom_narrow.gif" height="22">&nbsp;</td>
										</tr>
									</table>
								</div></td>
							</tr>
						</table>
					</div></td>
					<td width="599">
						<form runat="server">
<input type="hidden" name="dpSample" value="1" />
<input type="hidden" name="__VIEWSTATE" value="dDwxOTM3NzQ2OTg5O3Q8O2w8aTwxPjs+O2w8dDw7bDxpPDA+O2k8Mj47PjtsPHQ8cDxwPGw8Q2hvc2VuRGF0ZVZhbHVlOz47bDxTeXN0ZW0uRGF0ZVRpbWUsIG1zY29ybGliLCBWZXJzaW9uPTEuMC4zMzAwLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OTwwNy8wOC8yMDA0IDE5OjUzOjIzPjs+Pjs+Ozs+O3Q8O2w8aTwwPjtpPDE+Oz47bDx0PHA8cDxsPEZvbnRfQm9sZDtCYWNrQ29sb3I7Rm9yZUNvbG9yO18hU0I7PjtsPG88dD47MjwyNTUsIDE1MywgMD47MjxXaGl0ZT47aTwyMDYxPjs+Pjs+O2w8aTwwPjs+O2w8dDw7bDxpPDA+Oz47bDx0PHA8cDxsPE5hdmlnYXRlVXJsO1Rvb2xUaXA7Rm9udF9Cb2xkO0JhY2tDb2xvcjtGb3JlQ29sb3I7XyFTQjs+O2w8IztDbGljayB0byBleHBhbmQvY29sbGFwc2U7bzx0PjsyPDI1NSwgMTUzLCAwPjsyPFdoaXRlPjtpPDIwNjE+Oz4+O3A8bDxvbmNsaWNrO29ubW91c2VvdmVyO29ubW91c2VvdXQ7c3R5bGU7PjtsPHJldHVybiB0b2dnbGVfZXhjX29wZ2VlayAoJ19jdGwxX19jdGwwJywgJ19jdGwxX19jdGwyJyk7d2luZG93LnN0YXR1cyA9ICdDbGljayB0byBleHBhbmQvY29sbGFwc2UnXDsgcmV0dXJuIHRydWU7d2luZG93LnN0YXR1cyA9ICcnXDsgcmV0dXJuIHRydWU7dGV4dC1kZWNvcmF0aW9uOiBub25lOz4+Pjs7Pjs+Pjs+Pjt0PHA8cDxsPEJhY2tDb2xvcjtfIVNCOz47bDwyPDI0OSwgMjQ5LCAyNDk+O2k8OT47Pj47PjtsPGk8MD47PjtsPHQ8cDxwPGw8QmFja0NvbG9yO18hU0I7PjtsPDI8MjQ5LCAyNDksIDI0OT47aTwyNjU+Oz4+Oz47Oz47Pj47Pj47Pj47Pj47PkCBy6kVPl5gXhzsjx4SXKSSJm/e" />
	<script language='Javascript'>
function toggle_exc_opgeek (controlId, statefield)
{
	var control = document.all [controlId].style;
	var expandstate = document.all [statefield];

	if (control.display == 'none')
	{
		control.display = '';
		expandstate.value = 'true';
	}
	else
	{
		control.display = 'none';
		expandstate.value = 'false';
	}

	return false;
}
</script>

	



							<!-- #BeginEditable "ServerFormOpen" -->
							<!-- #EndEditable -->
							<div class="bodytext" style="padding-left:4px; padding-top:7px">
								<table width="584" border="0" cellpadding="0" cellspacing="0" height="100%">
									<tr>
										<td width="29" height="29" background="../../../../Images/body_top_middle.gif" align="left">
										<img src="../../../../Images/body_top_left.gif" width="29" height="29"></td>
										<td background="../../../../Images/body_top_middle.gif" width="526" height="29"><div style="width: 526px; height: 17px; overflow: hidden; overflow-x: hidden; overflow-y: hidden;">
											<b><font face="Verdana" color="#FFFFFF" size="2">
											<!-- #BeginEditable "Title" -->
ASP.NET PowerPack DatePicker Control
											<!-- #EndEditable -->
											</font></b></div></td>
										<td width="29" height="29" background="../../../../Images/body_top_middle.gif" align="right">
										<img src="../../../../Images/body_top_right.gif" width="29" height="29"></td>
									</tr>
									<tr>
										<td colspan="3" align="left" valign="top" background="../../../../Images/body_bottom_middle.gif">
											<div style="padding-left:7px; padding-top:2px">
												<!-- #BeginEditable "Body" -->
													<p>
														This control allows you to pick a single date using a GUI-like control.  This control looks
														much neater on a web form than the default .NET calendar control.
													</p>
													<p>
<opgeek:DatePicker firstyear="2005" lastyear="2007" debug="true" runat="server" id="demodate" />
													</p>
													<p>
														<input name="butSubmit" id="butSubmit" type="submit" value="Test DatePicker!" />
													</p>
													
<!-- CollapsiblePanel v1.0.0.13 from Opinionated Geek - visit http://www.opinionatedgeek.com/ for more info -->
<table style="background-color:#FF9900;width:100%;">
	<tr style="color:White;background-color:#FF9900;font-weight:bold;">
		<td><a id="_ctl1__ctl1" title="Click to expand/collapse" onclick="return toggle_exc_opgeek ('_ctl1__ctl0', '_ctl1__ctl2')" onmouseover="window.status = 'Click to expand/collapse'; return true" onmouseout="window.status = ''; return true" href="/DotNet/Products/PowerPack/Examples/#" style="color:White;background-color:#FF9900;font-weight:bold;text-decoration: none"> View ASPX Source (click to expand)</a><input name="_ctl1:_ctl2" id="_ctl1__ctl2" type="hidden" value="False" /></td>
	</tr><tr style="background-color:#F9F9F9;">
		<td id="_ctl1__ctl0" id="_ctl0" style="background-color:#F9F9F9;width:100%;display:none;"><pre><span style="background-color: yellow;"><font color="blue">&lt;</font>%@ Page language="c#" %<font color="blue">&gt;</font></span>
<span style="background-color: yellow;"><font color="blue">&lt;</font>%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%<font color="blue">&gt;</font></span>
<span style="background-color: yellow;"><font color="blue">&lt;</font>%@ Register TagPrefix="site" Namespace="OpinionatedGeek.Site" Assembly="OpinionatedGeek.Site"%<font color="blue">&gt;</font></span>
<font color="maroon"><font color="blue">&lt;</font>!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;</font>html<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;</font>!-- #BeginTemplate "../../../../unbranded.dwt" --<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;</font>head<font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>meta <font color="red">name</font><font color="blue">="ProgId"</font> <font color="red">content</font><font color="blue">="SharePoint.WebPartPage.Document"</font><font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>meta <font color="red">name</font><font color="blue">="WebPartPageExpansion"</font> <font color="red">content</font><font color="blue">="full"</font><font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>!-- #BeginEditable "doctitle" --<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;</font>title<font color="blue">&gt;</font></font>A complete DHTML DatePicker!<font color="maroon"><font color="blue">&lt;/</font>title<font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>!-- #EndEditable --<font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>meta <font color="red">http-equiv</font><font color="blue">="Content-Type"</font> <font color="red">content</font><font color="blue">="text/html; charset=windows-1251"</font><font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>meta <font color="red">name</font><font color="blue">=vs_targetSchema content="</font>http://schemas.microsoft.com/intellisense/ie5"<font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>link <font color="red">href</font><font color="blue">="../../../../opgeek.css"</font> <font color="red">rel</font><font color="blue">="stylesheet"</font> <font color="red">type</font><font color="blue">="text/css"</font><font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>!-- #BeginEditable "clientscript" --<font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>!-- #EndEditable --<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;/</font>head<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;</font>body <font color="red">bgcolor</font><font color="blue">="#ffffff"</font><font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="100%"</font> <font color="red">height</font><font color="blue">="100%"</font> <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font><font color="blue">&gt;</font></font>
		<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="766"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="766"</font>  <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font><font color="blue">&gt;</font></font>
				<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">width</font><font color="blue">="766"</font> <font color="red">height</font><font color="blue">="110"</font><font color="blue">&gt;</font></font>
						<font color="maroon"><font color="blue">&lt;</font>a <font color="red">href</font><font color="blue">="/"</font> <font color="red">title</font><font color="blue">="OpinionatedGeek Ltd. :: Part of the solution"</font><font color="blue">&gt;</font></font>
						<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/title.jpg"</font> <font color="red">width</font><font color="blue">="766"</font> <font color="red">height</font><font color="blue">="110"</font> <font color="red">border</font><font color="blue">="0"</font><font color="blue">/&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
				<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
				<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="765"</font>  <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font> <font color="red">background</font><font color="blue">="../../../../Images/toolbar.gif"</font> <font color="red">height</font><font color="blue">="70"</font><font color="blue">&gt;</font></font>
						<font color="maroon"><font color="blue">&lt;</font>tr <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="112"</font> <font color="red">height</font><font color="blue">="70"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">class</font><font color="blue">="buttontext"</font><font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="buttontext"</font> <font color="red">href</font><font color="blue">="../../../../About/default.aspx"</font><font color="blue">&gt;</font></font>About Us<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="112"</font> <font color="red">height</font><font color="blue">="70"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">class</font><font color="blue">="buttontext"</font><font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="buttontext"</font> <font color="red">href</font><font color="blue">="../../default.aspx"</font><font color="blue">&gt;</font></font>Products<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="112"</font> <font color="red">height</font><font color="blue">="70"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">class</font><font color="blue">="buttontext"</font><font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="buttontext"</font> <font color="red">href</font><font color="blue">="../../../Wiki/default.aspx"</font><font color="blue">&gt;</font></font>DotNetWiki<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="112"</font> <font color="red">height</font><font color="blue">="70"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">class</font><font color="blue">="buttontext"</font><font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="buttontext"</font> <font color="red">href</font><font color="blue">="../../../../Support/default.aspx"</font><font color="blue">&gt;</font></font>Support<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="112"</font> <font color="red">height</font><font color="blue">="70"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">class</font><font color="blue">="buttontext"</font><font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="buttontext"</font> <font color="red">href</font><font color="blue">="../../../../Contact/default.aspx"</font><font color="blue">&gt;</font></font>Contact<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="10"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>td <font color="red">background</font><font color="blue">="../../../../Images/search_background.gif"</font> <font color="red">width</font><font color="blue">="195"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">style</font><font color="blue">="padding-left:9px; padding-top:17px"</font><font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="100%"</font>  <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font><font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="42"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/magnifier.jpg"</font> <font color="red">width</font><font color="blue">="29"</font> <font color="red">height</font><font color="blue">="28"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>span <font color="red">class</font><font color="blue">="textboxprompt"</font><font color="blue">&gt;</font></font>
											Search:<font color="maroon"><font color="blue">&lt;/</font>span<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>input <font color="red">type</font><font color="blue">="text"</font> <font color="red">name</font><font color="blue">="textfield3"</font> <font color="red">style</font><font color="blue">="width:88px; height:17px; font-family:tahoma; font-size:10px "</font><font color="blue">&gt;</font></font> <font color="maroon"><font color="blue">&lt;</font>a <font color="red">href</font><font color="blue">="#"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/button_go.jpg"</font> <font color="red">width</font><font color="blue">="36"</font> <font color="red">height</font><font color="blue">="17"</font> <font color="red">border</font><font color="blue">="0"</font> <font color="red">align</font><font color="blue">="absmiddle"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
						<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
				<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="100%"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">background</font><font color="blue">="../../../../Images/title_extension.jpg"</font> <font color="red">style</font><font color="blue">="background-repeat:repeat-x"</font><font color="blue">&gt;</font></font>&amp;nbsp;<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
		<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
		<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="766"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="766"</font>  <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font><font color="blue">&gt;</font></font>
				<font color="maroon"><font color="blue">&lt;</font>tr <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="176"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">style</font><font color="blue">="padding-left:4px; padding-top:6px"</font><font color="blue">&gt;</font></font>
						<font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="153"</font>  <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font><font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="160"</font>  <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font> <font color="red">background</font><font color="blue">="../../../../Images/highlight_body_narrow.gif"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">width</font><font color="blue">="160"</font> <font color="red">height</font><font color="blue">="29"</font> <font color="red">background</font><font color="blue">="../../../../Images/highlight_top_narrow.gif"</font><font color="blue">&gt;</font></font>&amp;nbsp;<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>font <font color="red">face</font><font color="blue">="Verdana"</font> <font color="red">color</font><font color="blue">="#FFFFFF"</font> <font color="red">size</font><font color="blue">="2"</font><font color="blue">&gt;</font></font> ASP.NET PowerPack<font color="maroon"><font color="blue">&lt;/</font>font<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">style</font><font color="blue">="padding-left:12px; padding-top:13px; padding-right: 4px"</font><font color="blue">&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;</font>a <font color="red">href</font><font color="blue">="../default.aspx"</font><font color="blue">&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/laptop_cluster.jpg"</font> <font color="red">border</font><font color="blue">="0"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;</font>div <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">style</font><font color="blue">="padding-left:0px; padding-top:18px; padding-bottom:20px"</font><font color="blue">&gt;</font></font> 
												<font color="maroon"><font color="blue">&lt;</font>span <font color="red">class</font><font color="blue">="emphasis"</font><font color="blue">&gt;</font></font>The ASP.NET PowerPack<font color="maroon"><font color="blue">&lt;/</font>span<font color="blue">&gt;</font></font> contains 28 rich, cross-browser controls including:<font color="maroon"><font color="blue">&lt;</font>br<font color="blue">&gt;</font></font>
													&amp;nbsp;- 
													<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font> 
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="richtextbox.aspx"</font><font color="blue">&gt;</font></font>RichTextBox<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
													&amp;nbsp;- <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font> 
												<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="combobox.aspx"</font><font color="blue">&gt;</font></font>ComboBox<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
													&amp;nbsp;- <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font> 
												<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="datepicker.aspx"</font><font color="blue">&gt;</font></font>DatePicker<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
													&amp;nbsp;- 
													<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font> 
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="norepostvalidator.aspx"</font><font color="blue">&gt;</font></font>No-Repost validator<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>p<font color="blue">&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;/</font>span<font color="blue">&gt;</font></font>
												Try the ASP.NET PowerPack free today!<font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
												&amp;nbsp;- <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font> 
												<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../default.aspx"</font><font color="blue">&gt;</font></font>More Info<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
												&amp;nbsp;-
												<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../Download.aspx"</font><font color="blue">&gt;</font></font>
												Download<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
												&amp;nbsp;-
												<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../Buy/Prices.aspx"</font><font color="blue">&gt;</font></font>
												Price List<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
												&amp;nbsp;-
												<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../Licensing.aspx"</font><font color="blue">&gt;</font></font>
												Licensing<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
												&amp;nbsp;-
												<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../Buy/Default.aspx"</font><font color="blue">&gt;</font></font>
												Buy Now!<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">background</font><font color="blue">="../../../../Images/highlight_bottom_narrow.gif"</font> <font color="red">height</font><font color="blue">="22"</font><font color="blue">&gt;</font></font>&amp;nbsp;<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">style</font><font color="blue">="padding-left:0px; padding-top:8px; padding-bottom:7px"</font><font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="160"</font>  <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font> <font color="red">background</font><font color="blue">="../../../../Images/highlight_body_narrow.gif"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">width</font><font color="blue">="160"</font> <font color="red">height</font><font color="blue">="29"</font> <font color="red">background</font><font color="blue">="../../../../Images/highlight_top_narrow.gif"</font><font color="blue">&gt;</font></font>&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>font <font color="red">size</font><font color="blue">="2"</font> <font color="red">face</font><font color="blue">="Verdana"</font> <font color="red">color</font><font color="blue">="#FFFFFF"</font><font color="blue">&gt;</font></font>Web Tools<font color="maroon"><font color="blue">&lt;/</font>font<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font>
						                        <font color="maroon"><font color="blue">&lt;</font>div <font color="red">style</font><font color="blue">="padding-left: 14px; padding-top: 7px; padding-right: 4px"</font><font color="blue">&gt;</font></font>
													&amp;nbsp;- <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../../../Wiki/default.aspx"</font><font color="blue">&gt;</font></font>The DotNetWiki<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
													&amp;nbsp;- <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../../../Tools/Colors/default.aspx"</font><font color="blue">&gt;</font></font>ASP.NET Colors<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
													&amp;nbsp;- <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../../../Tools/Base64Encode/default.aspx"</font><font color="blue">&gt;</font></font>Base64 Encode<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
													&amp;nbsp;- <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../../../Tools/Base64Decode/default.aspx"</font><font color="blue">&gt;</font></font>Base64 Decode<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
													&amp;nbsp;- <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../../../Tools/CrazyIP/default.aspx"</font><font color="blue">&gt;</font></font>Crazy IPs<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
													&amp;nbsp;- <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="../../../Tools/Whois/default.aspx"</font><font color="blue">&gt;</font></font>Whois<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">background</font><font color="blue">="../../../../Images/highlight_bottom_narrow.gif"</font> <font color="red">height</font><font color="blue">="22"</font><font color="blue">&gt;</font></font>&amp;nbsp;<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">style</font><font color="blue">="padding-left:0px; padding-top:8px; padding-bottom:7px"</font><font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="160"</font>  <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font> <font color="red">background</font><font color="blue">="../../../../Images/highlight_body_narrow.gif"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">width</font><font color="blue">="160"</font> <font color="red">height</font><font color="blue">="29"</font> <font color="red">background</font><font color="blue">="../../../../Images/highlight_top_narrow.gif"</font><font color="blue">&gt;</font></font>&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>font <font color="red">size</font><font color="blue">="2"</font> <font color="red">face</font><font color="blue">="Verdana"</font> <font color="red">color</font><font color="blue">="#FFFFFF"</font><font color="blue">&gt;</font></font>Windows Tools<font color="maroon"><font color="blue">&lt;/</font>font<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font>
						                        <font color="maroon"><font color="blue">&lt;</font>div <font color="red">style</font><font color="blue">="padding-left: 14px; padding-top: 7px; padding-right: 4px"</font><font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="/DotNet/Products/ConnTest/"</font><font color="blue">&gt;</font></font>ADO.NET ConnTest<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br<font color="blue">&gt;</font></font>
													A simple, free Windows 
													program to test ADO.NET 
													connection strings.<font color="maroon"><font color="blue">&lt;</font>p<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="/DotNet/Products/LinesOfCSharp/"</font><font color="blue">&gt;</font></font>Lines of C#<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br<font color="blue">&gt;</font></font>
													Ever wanted to know how many 
													lines of C# code are in a 
													file or folder hierarchy?&amp;nbsp; 
													This free Windows program 
													will tell you.<font color="maroon"><font color="blue">&lt;/</font>p<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>p<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>a <font color="red">class</font><font color="blue">="ancillarytext"</font> <font color="red">href</font><font color="blue">="/DotNet/Products/XmlTools/"</font><font color="blue">&gt;</font></font>XmlTools<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>br<font color="blue">&gt;</font></font>
													Free tools to process XML 
													files from the command line.<font color="maroon"><font color="blue">&lt;</font>br <font color="blue">/&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>td <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">background</font><font color="blue">="../../../../Images/highlight_bottom_narrow.gif"</font> <font color="red">height</font><font color="blue">="22"</font><font color="blue">&gt;</font></font>&amp;nbsp;<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
						<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="599"</font><font color="blue">&gt;</font></font>
						<font color="maroon"><font color="blue">&lt;</font>form <font color="red">runat</font><font color="blue">="server"</font><font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>!-- #BeginEditable "ServerFormOpen" --<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>!-- #EndEditable --<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>div <font color="red">class</font><font color="blue">="bodytext"</font> <font color="red">style</font><font color="blue">="padding-left:4px; padding-top:7px"</font><font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;</font>table <font color="red">width</font><font color="blue">="584"</font> <font color="red">border</font><font color="blue">="0"</font> <font color="red">cellpadding</font><font color="blue">="0"</font> <font color="red">cellspacing</font><font color="blue">="0"</font> <font color="red">height</font><font color="blue">="100%"</font><font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="29"</font> <font color="red">height</font><font color="blue">="29"</font> <font color="red">background</font><font color="blue">="../../../../Images/body_top_middle.gif"</font> <font color="red">align</font><font color="blue">="left"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/body_top_left.gif"</font> <font color="red">width</font><font color="blue">="29"</font> <font color="red">height</font><font color="blue">="29"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>td <font color="red">background</font><font color="blue">="../../../../Images/body_top_middle.gif"</font> <font color="red">width</font><font color="blue">="526"</font> <font color="red">height</font><font color="blue">="29"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>div <font color="red">style</font><font color="blue">="width: 526px; height: 17px; overflow: hidden; overflow-x: hidden; overflow-y: hidden;"</font><font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;</font>font <font color="red">face</font><font color="blue">="Verdana"</font> <font color="red">color</font><font color="blue">="#FFFFFF"</font> <font color="red">size</font><font color="blue">="2"</font><font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>!-- #BeginEditable "Title" --<font color="blue">&gt;</font></font>
ASP.NET PowerPack DatePicker Control
											<font color="maroon"><font color="blue">&lt;</font>!-- #EndEditable --<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;/</font>font<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="29"</font> <font color="red">height</font><font color="blue">="29"</font> <font color="red">background</font><font color="blue">="../../../../Images/body_top_middle.gif"</font> <font color="red">align</font><font color="blue">="right"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/body_top_right.gif"</font> <font color="red">width</font><font color="blue">="29"</font> <font color="red">height</font><font color="blue">="29"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>td <font color="red">colspan</font><font color="blue">="3"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">background</font><font color="blue">="../../../../Images/body_bottom_middle.gif"</font><font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;</font>div <font color="red">style</font><font color="blue">="padding-left:7px; padding-top:2px"</font><font color="blue">&gt;</font></font>
												<font color="maroon"><font color="blue">&lt;</font>!-- #BeginEditable "Body" --<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>p<font color="blue">&gt;</font></font>
														This control allows you to pick a single date using a GUI-like control.  This control looks
														much neater on a web form than the default .NET calendar control.
													<font color="maroon"><font color="blue">&lt;/</font>p<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>p<font color="blue">&gt;</font></font>
														<font color="maroon"><font color="blue">&lt;</font>opgeek:DatePicker <font color="red">id</font><font color="blue">="dpSample"</font> <font color="red">firstyear</font><font color="blue">="2000"</font> <font color="red">lastyear</font><font color="blue">="2004"</font> <font color="red">runat</font><font color="blue">="server"</font> <font color="blue">/&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;/</font>p<font color="blue">&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;</font>p<font color="blue">&gt;</font></font>
														<font color="maroon"><font color="blue">&lt;</font>input <font color="red">type</font><font color="blue">="submit"</font> <font color="red">runat</font><font color="blue">="server"</font> <font color="red">value</font><font color="blue">="Test DatePicker!"</font> <font color="red">ID</font><font color="blue">="butSubmit"</font> <font color="blue">/&gt;</font></font>
													<font color="maroon"><font color="blue">&lt;/</font>p<font color="blue">&gt;</font></font>
													<span style="background-color: yellow;"><font color="blue">&lt;</font>%if (Request.Form ["dpSample"] != null) {%<font color="blue">&gt;</font></span>
														<font color="maroon"><font color="blue">&lt;</font>p<font color="blue">&gt;</font></font>
															You picked date: <font color="maroon"><font color="blue">&lt;</font>b<font color="blue">&gt;</font></font><span style="background-color: yellow;"><font color="blue">&lt;</font>%=dpSample.Value.ToString ("dddd, d MMMM yyyy")%<font color="blue">&gt;</font></span><font color="maroon"><font color="blue">&lt;/</font>b<font color="blue">&gt;</font></font>
														<font color="maroon"><font color="blue">&lt;/</font>p<font color="blue">&gt;</font></font>
													<span style="background-color: yellow;"><font color="blue">&lt;</font>%}%<font color="blue">&gt;</font></span>

													<font color="maroon"><font color="blue">&lt;</font>site:ViewSource <font color="red">runat</font><font color="blue">="server"</font><font color="blue">/&gt;</font></font>

												<font color="maroon"><font color="blue">&lt;</font>!-- #EndEditable --<font color="blue">&gt;</font></font>
											<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="29"</font> <font color="red">height</font><font color="blue">="16"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/body_bottom_left.gif"</font> <font color="red">width</font><font color="blue">="29"</font> <font color="red">height</font><font color="blue">="16"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>td <font color="red">background</font><font color="blue">="../../../../Images/body_bottom_middle.gif"</font> <font color="red">width</font><font color="blue">="526"</font> <font color="red">height</font><font color="blue">="16"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/body_bottom_middle.gif"</font> <font color="red">width</font><font color="blue">="526"</font> <font color="red">height</font><font color="blue">="16"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="29"</font> <font color="red">height</font><font color="blue">="16"</font><font color="blue">&gt;</font></font>
										<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/body_bottom_right.gif"</font> <font color="red">width</font><font color="blue">="29"</font> <font color="red">height</font><font color="blue">="16"</font><font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
									<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
								<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>!-- #BeginEditable "ServerFormClose" --<font color="blue">&gt;</font></font>
							<font color="maroon"><font color="blue">&lt;</font>!-- #EndEditable --<font color="blue">&gt;</font></font>
						<font color="maroon"><font color="blue">&lt;/</font>form<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
				<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font><font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="100%"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font><font color="blue">&gt;</font></font>&amp;nbsp;<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
		<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
		<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;</font>td <font color="red">height</font><font color="blue">="39"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">background</font><font color="blue">="../../../../Images/footer_extension.jpg"</font> <font color="red">class</font><font color="blue">="footer"</font><font color="blue">&gt;</font></font>
				<font color="maroon"><font color="blue">&lt;</font>div <font color="red">align</font><font color="blue">="center"</font> <font color="red">style</font><font color="blue">="padding-top:8px "</font><font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>a <font color="red">href</font><font color="blue">="../../../../About/default.aspx"</font> <font color="red">class</font><font color="blue">="footer"</font><font color="blue">&gt;</font></font>About Us<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/division.jpg"</font> <font color="red">width</font><font color="blue">="1"</font> <font color="red">height</font><font color="blue">="5"</font> <font color="red">hspace</font><font color="blue">="11"</font><font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>a <font color="red">href</font><font color="blue">="../../default.aspx"</font> <font color="red">class</font><font color="blue">="footer"</font><font color="blue">&gt;</font></font>Products<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/division.jpg"</font> <font color="red">width</font><font color="blue">="1"</font> <font color="red">height</font><font color="blue">="5"</font> <font color="red">hspace</font><font color="blue">="11"</font><font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>a <font color="red">href</font><font color="blue">="../../../Wiki/default.aspx"</font> <font color="red">class</font><font color="blue">="footer"</font><font color="blue">&gt;</font></font>DotNetWiki<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/division.jpg"</font> <font color="red">width</font><font color="blue">="1"</font> <font color="red">height</font><font color="blue">="5"</font> <font color="red">hspace</font><font color="blue">="11"</font><font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>a <font color="red">href</font><font color="blue">="../../../../Support/default.aspx"</font> <font color="red">class</font><font color="blue">="footer"</font><font color="blue">&gt;</font></font>Support<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>img <font color="red">src</font><font color="blue">="../../../../Images/division.jpg"</font> <font color="red">width</font><font color="blue">="1"</font> <font color="red">height</font><font color="blue">="5"</font> <font color="red">hspace</font><font color="blue">="11"</font><font color="blue">&gt;</font></font>
					<font color="maroon"><font color="blue">&lt;</font>a <font color="red">href</font><font color="blue">="../../../../Contact/default.aspx"</font> <font color="red">class</font><font color="blue">="footer"</font><font color="blue">&gt;</font></font>Contact<font color="maroon"><font color="blue">&lt;/</font>a<font color="blue">&gt;</font></font>
				<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="100%"</font> <font color="red">height</font><font color="blue">="39"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">background</font><font color="blue">="../../../../Images/footer_extension.jpg"</font> <font color="red">class</font><font color="blue">="footer"</font><font color="blue">&gt;</font></font>
				&amp;nbsp;
			<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
		<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
		<font color="maroon"><font color="blue">&lt;</font>tr<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;</font>td <font color="red">height</font><font color="blue">="100%"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">bgcolor</font><font color="blue">="#FF831F"</font> <font color="red">class</font><font color="blue">="copyright"</font><font color="blue">&gt;</font></font>
				<font color="maroon"><font color="blue">&lt;</font>div <font color="red">align</font><font color="blue">="center"</font> <font color="red">style</font><font color="blue">="padding-top:15px "</font><font color="blue">&gt;</font></font>
					Copyright  2004 OpinionatedGeek Ltd.
				<font color="maroon"><font color="blue">&lt;/</font>div<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
			<font color="maroon"><font color="blue">&lt;</font>td <font color="red">width</font><font color="blue">="100%"</font> <font color="red">height</font><font color="blue">="100%"</font> <font color="red">align</font><font color="blue">="left"</font> <font color="red">valign</font><font color="blue">="top"</font> <font color="red">bgcolor</font><font color="blue">="#FF831F"</font> <font color="red">class</font><font color="blue">="footer"</font><font color="blue">&gt;</font></font>
				&amp;nbsp;
			<font color="maroon"><font color="blue">&lt;/</font>td<font color="blue">&gt;</font></font>
		<font color="maroon"><font color="blue">&lt;/</font>tr<font color="blue">&gt;</font></font>
	<font color="maroon"><font color="blue">&lt;/</font>table<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;</font>!-- #BeginEditable "serverscript" --<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;</font>script <font color="red">language</font><font color="blue">="C#"</font> <font color="red">runat</font><font color="blue">="server"</font><font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;/</font>script<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;</font>!-- #EndEditable --<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;/</font>body<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;</font>!-- #EndTemplate --<font color="blue">&gt;</font></font>
<font color="maroon"><font color="blue">&lt;/</font>html<font color="blue">&gt;</font></font></pre></td>
	</tr>
</table>

												<!-- #EndEditable -->
											</div>
										</td>
									</tr>
									<tr>
										<td width="29" height="16">
										<img src="../../../../Images/body_bottom_left.gif" width="29" height="16"></td>
										<td background="../../../../Images/body_bottom_middle.gif" width="526" height="16">
										<img src="../../../../Images/body_bottom_middle.gif" width="526" height="16"></td>
										<td width="29" height="16">
										<img src="../../../../Images/body_bottom_right.gif" width="29" height="16"></td>
									</tr>
								</table>
							</div>
							<!-- #BeginEditable "ServerFormClose" -->
							<!-- #EndEditable -->
						</form>
					</td>
				</tr>
			</table></td>
			<td width="100%" align="left" valign="top">&nbsp;</td>
		</tr>
		<tr>
			<td height="39" align="left" valign="top" background="../../../../Images/footer_extension.jpg" class="footer">
				<div align="center" style="padding-top:8px ">
					<a href="../../../../About/default.aspx" class="footer">About Us</a>
					<img src="../../../../Images/division.jpg" width="1" height="5" hspace="11">
					<a href="../../default.aspx" class="footer">Products</a>
					<img src="../../../../Images/division.jpg" width="1" height="5" hspace="11">
					<a href="../../../Wiki/default.aspx" class="footer">DotNetWiki</a>
					<img src="../../../../Images/division.jpg" width="1" height="5" hspace="11">
					<a href="../../../../Support/default.aspx" class="footer">Support</a>
					<img src="../../../../Images/division.jpg" width="1" height="5" hspace="11">
					<a href="../../../../Contact/default.aspx" class="footer">Contact</a>
				</div>
			</td>
			<td width="100%" height="39" align="left" valign="top" background="../../../../Images/footer_extension.jpg" class="footer">
				&nbsp;
			</td>
		</tr>
		<tr>
			<td height="100%" align="left" valign="top" bgcolor="#FF831F" class="copyright">
				<div align="center" style="padding-top:15px ">
					Copyright © 2004 OpinionatedGeek Ltd.
				</div>
			</td>
			<td width="100%" height="100%" align="left" valign="top" bgcolor="#FF831F" class="footer">
				&nbsp;
			</td>
		</tr>
	</table>
<!-- #BeginEditable "serverscript" -->

<!-- #EndEditable -->
</body>
<!-- #EndTemplate -->
</html>