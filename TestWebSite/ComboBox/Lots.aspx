<%@ Page Language="C#" debug=true%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>

<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
	<head>
		<title>wibble :: Bug</title>
		<link media="screen" href="/alchemy_client/normal/alchemy.css" type="text/css" rel="stylesheet">
	</head>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	<table border="0" cellpadding="0" cellspacing="0">
		<tr>
			<td width="239" valign="top">
				<table width="239" height="560" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td width=239 height=102 background="/alchemy_client/normal/Images/logo.jpg"> </td>
					</tr>
					<tr>
						<td width=239 height=210>
							<img src="/alchemy_client/normal/Images/header.jpg" alt="" width=239 height=210 border="0" usemap="#Map" />
						</td>
					</tr>
					<tr>
						<td width="239" height="101">
							<a href="http://www.opinionatedgeek.com/"><img src="/alchemy_client/normal/Images/sidebar-small.jpg" alt="Visit us online for the latest Alchemy news and downloads!" width="239" height="101" border="0"/></a>
						</td>
					</tr>
					<tr>
						<td width="239" height="137" background="/alchemy_client/normal/Images/sidebar-medium.jpg">
							&nbsp;
						</td>
					</tr>
				</table>
			</td>
			<td valign="top" width="531">
				<table border="0" width="531" height="190" cellpadding="0" cellspacing="0" background="/alchemy_client/normal/Images/top.jpg">
					<tr>
						<td valign="top">
							<div class="pageheader" style="padding-left: 25; padding-top: 12">
								[geoff] wibble :: Bug
							</div>
						</td>
					</tr>
				</table>
				<div style="padding-left: 15;" class="bodytext">


	<form runat="server">

<script language="javascript">
<!--
	function __doPostBack(eventTarget, eventArgument) {
		var theform;
		if (window.navigator.appName.toLowerCase().indexOf("netscape") > -1) {
			theform = document.forms["_ctl2"];
		}
		else {
			theform = document._ctl2;
		}
		theform.__EVENTTARGET.value = eventTarget.split("$").join(":");
		theform.__EVENTARGUMENT.value = eventArgument;
		theform.submit();
	}
// -->
</script>

<script language="javascript">
<!--
function preventDoubleClick_alch_og (element)
{
	var link = document.getElementById (element.id);
	var returnValue = true;
	if ((link.disabled) || ((link.attributes ['preventDoubleClick']) && (link.attributes ['preventDoubleClick'].value)))
	{
		event.cancelBubble = true;
		returnValue = false;
	}
	else
	{
		var linkRequiresValidationAttribute = link.attributes ['requirevalidation'];
		if (linkRequiresValidationAttribute)
		{
			var alternateElement = null;
			var linkAlternateSubmitterAttribute = link.attributes ['alternatesubmitter'];
			if (linkAlternateSubmitterAttribute)
			{
				var linkAlternateSubmitter = linkAlternateSubmitterAttribute.value;
				alternateElement = document.getElementById (linkAlternateSubmitter);
			}

			var linkRequiresValidation = linkRequiresValidationAttribute.value;
			if ((linkRequiresValidation == 'True') && (typeof (Page_ClientValidate) == 'function'))
			{
				returnValue = Page_ClientValidate ();
				setLinkValue_alch_og (link, returnValue);
				if (alternateElement)
				{
					setLinkValue_alch_og (alternateElement, returnValue);
				}
			}
			else
			{
				returnValue = true;
				setLinkValue_alch_og (link, true);
				if (alternateElement)
				{
					setLinkValue_alch_og (alternateElement, true);
				}
			}
		}

		return returnValue;
	}

	function setLinkValue_alch_og (link, newValue)
	{
		if (link.tagName == 'INPUT')
		{
			link.setAttribute ('preventDoubleClick', newValue);
		}
		else
		{
			link.disabled = newValue;
		}

		return;
	}

}
-->
</script>

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

<script language="javascript" src="/aspnet_client/system_web/1_1_4322/WebUIValidation.js"></script>


		<div id="bug">
	
			<div>
		
					<table id="_ctl7" class="og-toolbar" cellspacing="2" cellpadding="0" border="0" style="width:100%;">
			<tr>
				<td class="og-toolbar"><table cellpadding=1 cellspacing=0 border=0> <tr> <td class="ms-toolbar" nowrap><input type="image" name="_ctl10" onclick="return preventDoubleClick_alch_og (this);if (typeof(Page_ClientValidate) == 'function') Page_ClientValidate(); " language="javascript" id="_ctl10" title="Save" requirevalidation="True" alternatesubmitter="_ctl11" src="/alchemy_client/normal/images/save.gif" border="0" style="height:16px;width:16px;" /></td> <td nowrap> <a id="_ctl11" title="Save" class="og-toolbar" onclick="return preventDoubleClick_alch_og (this);" requirevalidation="True" alternatesubmitter="_ctl10" href="javascript:{if (typeof(Page_ClientValidate) != 'function' ||  Page_ClientValidate()) __doPostBack('_ctl11','')} ">Save</a></td></tr></table></td><td class="og-separator">|</td><td class="og-toolbar"><table cellpadding=1 cellspacing=0 border=0> <tr> <td class="ms-toolbar" nowrap><input type="image" name="_ctl12" id="_ctl12" title="Cancel" onclick="return preventDoubleClick_alch_og (this);" requirevalidation="False" alternatesubmitter="_ctl13" src="/alchemy_client/normal/images/cancel.gif" border="0" style="height:16px;width:16px;" /></td> <td nowrap> <a id="_ctl13" title="Cancel" class="og-toolbar" onclick="return preventDoubleClick_alch_og (this);" requirevalidation="False" alternatesubmitter="_ctl12" href="javascript:__doPostBack('_ctl13','')">Cancel</a></td></tr></table></td><td class="og-toolbar" nowrap="nowrap" align="Right" style="width:99%;">&nbsp;</td>
			</tr>
		</table>
				
	</div>

			
				<h2>New Bug</h2>
						<table border="0" class="fieldtitle" width="450">
				<tr>
					<td valign="top" width="115">
						Product:
					</td>
					<td valign="top" width="100">
						<opgeek:combobox width="100" name="Product" runat="server"/>
					</td>
					<td width="20">
					</td>
					<td valign="top" width="115">
						Date Reported:
					</td>
					<td valign="top" width="100">
						<opgeek:combobox width="100" name="DateReported" runat="server"/>
					</td>
				</tr>
				<tr>
					<td valign="top">
						Version:
					</td>
					<td valign="top">
						<opgeek:combobox width="100" name="IssueInVersion" runat="server"/>
					</td>
					<td>
					</td>
					<td valign="top">
						Reported By:
					</td>
					<td valign="top">
						<opgeek:combobox width="100" name="ReportedBy" runat="server"/>
					</td>
				</tr>
				<tr>
					<td valign="top">
						Cause:
					</td>
					<td valign="top">
						<opgeek:combobox width="100" name="Cause" runat="server"/>
					</td>
					<td>
					</td>
					<td valign="top">
						Assigned To:
					</td>
					<td valign="top">
						<opgeek:combobox width="100" name="AssignedTo" runat="server"/>
					</td>
				</tr>
				<tr>
					<td valign="top">
						Status:
					</td>
					<td valign="top">
						<opgeek:combobox width="100" id="status" name="Status" runat="server"/>
					</td>
					<td>
					</td>
					<td valign="top">
						Fix Due:
					</td>
					<td valign="top">
						<opgeek:combobox width="100" id="targetrelease" name="TargetRelease" runat="server"/>
					</td>
				</tr>
				<tr>
					<td valign="top">
						Title:
					</td>
					<td valign="top" colspan="4">
						<opgeek:combobox name="Title" id="titletest" width="347" runat="server"/>
					</td>
				</tr>
				<tr>
					<td colspan="5" valign="top">
						<br />
						<opgeek:collapsiblepanel runat="server" text="Details (click to expand/collapse)" titlecssclass="subsectiontitle" cssclass="sectionbody" cellpadding="0" cellspacing="0" expandbydefault="true">
							<div class="fieldtitle">
								<br />
								Description:
								<br />
								<opgeek:richtextbox name="Description" width="440" cssclass="sectionbody" runat="server" id="Richtextfield1"/>
							</div>
						</opgeek:collapsiblepanel>
					</td>
				</tr>
				<tr>
					<td colspan="5" valign="top">
						<br />
						<opgeek:collapsiblepanel runat="server" text="Resolution Information (click to expand/collapse)" titlecssclass="subsectiontitle" cssclass="sectionbody" cellpadding="0" cellspacing="0" expandbydefault="true">
							<div class="fieldtitle">
								<br />
								Resolution:
								<br />
								<opgeek:richtextbox name="Resolution" width="440" cssclass="sectionbody" runat="server"/>
								<br />
							</div>
							<table border="0" class="fieldtitle" width="440" cellpadding="0" cellspacing="0">
								<tr>
									<td valign="top" width="115">
										Fix Started:
									</td>
									<td valign="top" width="100">
										<opgeek:datepicker width="100" name="FixStarted" runat="server"/>
									</td>
									<td width="20">
									</td>
									<td valign="top" width="115">
										Time To Fix:
									</td>
									<td valign="top" width="100">
										<opgeek:combobox width="100" id="timetofix" name="TimeToFix" runat="server"/>
									</td>
								</tr>
								<tr>
									<td valign="top">
										Fix Completed:
									</td>
									<td valign="top">
										<opgeek:combobox width="100" id="fixcompleted" name="FixCompleted" runat="server"/>
									</td>
									<td>
									</td>
									<td valign="top">
									</td>
									<td valign="top">
									</td>
								</tr>
							</table>
						</opgeek:collapsiblepanel>
					</td>
				</tr>
			</table>
			</table>
		
</div>
		
<!-- NoRepostValidator v1.0.0.12 from Opinionated Geek - visit http://www.opinionatedgeek.com/ for more info -->
<span id="_ctl34" controltovalidate="_ctl34" errormessage="You have already saved this bug." style="color:Red;visibility:hidden;">You have already saved this bug.</span>
	
<script language="javascript">
<!--
	var Page_Validators =  new Array(document.all["_ctl30"], document.all["_ctl34"]);
		// -->
</script>

			<script language="Javascript">
	var txtTextbox = document.getElementById ('_ctl26_TextBox_opgeek');
	var ddDropdown = document.getElementById ('_ctl26');
	var spanSpacer = document.getElementById ('_ctl26Spacer_opgeek');
	if (ddDropdown != null)
	{
		initializeField_cb_opgeek (txtTextbox, ddDropdown, spanSpacer);
	}
</script>


			<script language="Javascript">
	var txtTextbox = document.getElementById ('_ctl23_TextBox_opgeek');
	var ddDropdown = document.getElementById ('_ctl23');
	var spanSpacer = document.getElementById ('_ctl23Spacer_opgeek');
	if (ddDropdown != null)
	{
		initializeField_cb_opgeek (txtTextbox, ddDropdown, spanSpacer);
	}
</script>


			<script language="Javascript">
	var txtTextbox = document.getElementById ('_ctl24_TextBox_opgeek');
	var ddDropdown = document.getElementById ('_ctl24');
	var spanSpacer = document.getElementById ('_ctl24Spacer_opgeek');
	if (ddDropdown != null)
	{
		initializeField_cb_opgeek (txtTextbox, ddDropdown, spanSpacer);
	}
</script>


			<script language="Javascript">
	var txtTextbox = document.getElementById ('_ctl19_TextBox_opgeek');
	var ddDropdown = document.getElementById ('_ctl19');
	var spanSpacer = document.getElementById ('_ctl19Spacer_opgeek');
	if (ddDropdown != null)
	{
		initializeField_cb_opgeek (txtTextbox, ddDropdown, spanSpacer);
	}
</script>


			<script language="Javascript">
	var txtTextbox = document.getElementById ('_ctl27_TextBox_opgeek');
	var ddDropdown = document.getElementById ('_ctl27');
	var spanSpacer = document.getElementById ('_ctl27Spacer_opgeek');
	if (ddDropdown != null)
	{
		initializeField_cb_opgeek (txtTextbox, ddDropdown, spanSpacer);
	}
</script>


			<script language="Javascript">
	var txtTextbox = document.getElementById ('_ctl28_TextBox_opgeek');
	var ddDropdown = document.getElementById ('_ctl28');
	var spanSpacer = document.getElementById ('_ctl28Spacer_opgeek');
	if (ddDropdown != null)
	{
		initializeField_cb_opgeek (txtTextbox, ddDropdown, spanSpacer);
	}
</script>


			<script language="Javascript">
	var txtTextbox = document.getElementById ('_ctl25_TextBox_opgeek');
	var ddDropdown = document.getElementById ('_ctl25');
	var spanSpacer = document.getElementById ('_ctl25Spacer_opgeek');
	if (ddDropdown != null)
	{
		initializeField_cb_opgeek (txtTextbox, ddDropdown, spanSpacer);
	}
</script>


			
<script language="javascript">
<!--
var Page_ValidationActive = false;
if (typeof(clientInformation) != "undefined" && clientInformation.appName.indexOf("Explorer") != -1) {
    if (typeof(Page_ValidationVer) == "undefined")
        alert("Unable to find script library '/aspnet_client/system_web/1_1_4322/WebUIValidation.js'. Try placing this file manually, or reinstall by running 'aspnet_regiis -c'.");
    else if (Page_ValidationVer != "125")
        alert("This page uses an incorrect version of WebUIValidation.js. The page expects version 125. The script library is " + Page_ValidationVer + ".");
    else
        ValidatorOnLoad();
}

function ValidatorOnSubmit() {
    if (Page_ValidationActive) {
        ValidatorCommonOnSubmit();
    }
}
// -->
</script>
        

			<script language="Javascript">
	var txtTextbox = document.getElementById ('_ctl22_TextBox_opgeek');
	var ddDropdown = document.getElementById ('_ctl22');
	var spanSpacer = document.getElementById ('_ctl22Spacer_opgeek');
	if (ddDropdown != null)
	{
		initializeField_cb_opgeek (txtTextbox, ddDropdown, spanSpacer);
	}
</script>


			<script language="Javascript">
	var txtTextbox = document.getElementById ('_ctl29_TextBox_opgeek');
	var ddDropdown = document.getElementById ('_ctl29');
	var spanSpacer = document.getElementById ('_ctl29Spacer_opgeek');
	if (ddDropdown != null)
	{
		initializeField_cb_opgeek (txtTextbox, ddDropdown, spanSpacer);
	}
</script>


		</form>

				</div>
			</td>
			<td width="1" bgcolor="#000000">
				<img src="/alchemy_client/normal/Images/spacer.gif" alt="" />
			</td>
			<td width="100%" background="/alchemy_client/normal/Images/bg.jpg">
				<img src="/alchemy_client/normal/Images/spacer.gif" alt="" />
			</td>
		</tr>


		<tr>
			<td></td>
			<td align="right">
				<img src="/alchemy_client/normal/Images/footer.jpg" width="523" height="102" border="0" usemap="#PoweredByMap">
				<br />
			</td>
			<td width="1" bgcolor="#000000">
				<img src="/alchemy_client/normal/Images/spacer.gif" alt="" />
			</td>
			<td background="/alchemy_client/normal/Images/bg.jpg">
				<img src="/alchemy_client/normal/Images/spacer.gif" alt="" />
			</td>
		</tr>
	</table>
	<map name="Map">
		<area shape="rect" coords="46,21,212,43" href="#">
		<area shape="rect" coords="44,52,214,71" href="#">
		<area shape="rect" coords="45,82,209,105" href="#">
		<area shape="rect" coords="42,113,207,134" href="#">
		<area shape="rect" coords="42,141,208,165" href="#">
	</map>
	<map name="PoweredByMap">
		<area shape="rect" coords="353,40,500,55" href="http://www.opinionatedgeek.com/">
		<area shape="rect" coords="358,55,520,70" href="mailto:support@opinionatedgeek.com/">
	</map>
</body>
</html>