//====================================================================
//
// COPYRIGHT (C) 2003 - 2008 OPINIONATEDGEEK LTD.
//
// The contents of this file are subject to License from OpinionatedGeek;
// you may not use this file except in compliance with the License.
// You may obtain a License from OpinionatedGeek Ltd.  Software distributed
// under the License is distributed "as is" and without any warranty
// as to merchantability or fitness for a particular purpose or any
// other warranties either expressed or implied.  The author will
// not be liable for data loss, damages, loss of profits or any
// other kind of loss while using or misusing this software.
//
// For more information visit http://www.opinionatedgeek.com/
//
//====================================================================
//
//  ID:             $Id$
//
//  URL:            $URL$
//
//  Last Modified:  $Date$
//
//  Author:         $Author$
//
//  Revision:       $Revision$
//
//====================================================================

var COMMAND_NAME_SELECTALL_RTB_OPGEEK = 'SelectAll';
var COMMAND_NAME_CUT_RTB_OPGEEK = 'Cut';
var COMMAND_NAME_COPY_RTB_OPGEEK = 'Copy';
var COMMAND_NAME_PASTE_RTB_OPGEEK = 'Paste';
var COMMAND_NAME_UNDO_RTB_OPGEEK = 'Undo';
var COMMAND_NAME_REDO_RTB_OPGEEK = 'Redo';
var COMMAND_NAME_BOLD_RTB_OPGEEK = 'Bold';
var COMMAND_NAME_ITALIC_RTB_OPGEEK = 'Italic';
var COMMAND_NAME_UNDERLINE_RTB_OPGEEK = 'Underline';
var COMMAND_NAME_ALIGNLEFT_RTB_OPGEEK = 'JustifyLeft';
var COMMAND_NAME_CENTER_RTB_OPGEEK = 'JustifyCenter';
var COMMAND_NAME_ALIGNRIGHT_RTB_OPGEEK = 'JustifyRight';
var COMMAND_NAME_JUSTIFY_RTB_OPGEEK = 'JustifyFull';
var COMMAND_NAME_LINK_RTB_OPGEEK = 'CreateLink';
var COMMAND_NAME_BULLETEDLIST_RTB_OPGEEK = 'InsertUnorderedList';
var COMMAND_NAME_NUMBEREDLIST_RTB_OPGEEK = 'InsertOrderedList';
var COMMAND_NAME_INDENT_RTB_OPGEEK = 'Indent';
var COMMAND_NAME_OUTDENT_RTB_OPGEEK = 'Outdent';
var COMMAND_NAME_FONTNAME_RTB_OPGEEK = 'FontName';
var COMMAND_NAME_FONTSIZE_RTB_OPGEEK = 'FontSize';
var COMMAND_NAME_FONTCOLOR_RTB_OPGEEK = 'ForeColor';
var COMMAND_NAME_BACKCOLOR_RTB_OPGEEK = 'BackColor';
var COMMAND_NAME_RAW_HTML_OPGEEK = 'HTML';

var HTML_TAG_OPEN_RTB_OPGEEK = String.fromCharCode (0x3C);
var HTML_TAG_CLOSE_RTB_OPGEEK = String.fromCharCode (0x3E);
var QUOTE_MARK_RTB_OPGEEK = String.fromCharCode (0x22);;

var COMMAND_TITLE_SELECTALL_RTB_OPGEEK = 'Select All';
var COMMAND_TITLE_CUT_RTB_OPGEEK = 'Cut';
var COMMAND_TITLE_COPY_RTB_OPGEEK = 'Copy';
var COMMAND_TITLE_PASTE_RTB_OPGEEK = 'Paste';
var COMMAND_TITLE_UNDO_RTB_OPGEEK = 'Undo';
var COMMAND_TITLE_REDO_RTB_OPGEEK = 'Redo';
var COMMAND_TITLE_BOLD_RTB_OPGEEK = 'Bold';
var COMMAND_TITLE_ITALIC_RTB_OPGEEK = 'Italic';
var COMMAND_TITLE_UNDERLINE_RTB_OPGEEK = 'Underline';
var COMMAND_TITLE_ALIGNLEFT_RTB_OPGEEK = 'Align Left';
var COMMAND_TITLE_CENTER_RTB_OPGEEK = 'Center';
var COMMAND_TITLE_ALIGNRIGHT_RTB_OPGEEK = 'Align Right';
var COMMAND_TITLE_JUSTIFY_RTB_OPGEEK = 'Justify';
var COMMAND_TITLE_LINK_RTB_OPGEEK = 'Hyperlink';
var COMMAND_TITLE_BULLETEDLIST_RTB_OPGEEK = 'Bulleted List';
var COMMAND_TITLE_NUMBEREDLIST_RTB_OPGEEK = 'Numbered List';
var COMMAND_TITLE_INDENT_RTB_OPGEEK = 'Indent';
var COMMAND_TITLE_OUTDENT_RTB_OPGEEK = 'Outdent';

var allInstantiatedFields_rtb_opgeek = new Array ();

var bSomeElementsHidden_rtb_opgeek = false;
var bInSetState_rtb_opgeek = false;
var aHiddenSelects_rtb_opgeek = new Array ();
var aHiddenObjects_rtb_opgeek = new Array ();

var imgNormalButton_rtb_opgeek = null;
var imgUpButton_rtb_opgeek = null;
var imgDownButton_rtb_opgeek = null;

var bLibraryInitialized_rtb_opgeek = false;

function runOnce_rtb_opgeek
(
    szButtonNormalImageUrl,
    szButtonUpImageUrl,
    szButtonDownImageUrl
)
{
	if (bLibraryInitialized_rtb_opgeek)
	{
		throw new Exception ('RichText library has already been initialized.');
	}

	imgNormalButton_rtb_opgeek = szButtonNormalImageUrl;
	imgUpButton_rtb_opgeek = szButtonUpImageUrl;
	imgDownButton_rtb_opgeek = szButtonDownImageUrl;

	window.attachEvent ('onload', loadComplete_rtb_opgeek);

	bLibraryInitialized_rtb_opgeek = true;

	return;
}

function initializeField_rtb_opgeek
(
    szButtonNormalImageUrl,
    szButtonUpImageUrl,
    szButtonDownImageUrl,
	szInstanceName,
	szRealName
)
{
	try
	{
		if (isDefined_rtb_opgeek (allInstantiatedFields_rtb_opgeek [szInstanceName]))
		{
			alert ('Field ' + szInstanceName + ' is already defined for this page.');
		}
		else
		{
			if (!bLibraryInitialized_rtb_opgeek)
			{
				runOnce_rtb_opgeek (szButtonNormalImageUrl, szButtonUpImageUrl, szButtonDownImageUrl);
			}

			var insCurrentInstance = new RichText_rtb_opgeek (szInstanceName, szRealName);
			allInstantiatedFields_rtb_opgeek [szInstanceName] = insCurrentInstance;
			insCurrentInstance.Initialize ();
		}
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('initializeField_rtb_opgeek', exCaughtException);
	}

	return;
}

function activateField_rtb_opgeek
(
	szInstanceName,
	nSetFocus
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.SetFocus = getBoolean_rtb_opgeek (nSetFocus);
		insCurrentInstance.Activate ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('activateField_rtb_opgeek', exCaughtException);
	}

	return;
}

function finaliseFieldReadiness_rtb_opgeek
(
	szInstanceName,
	szFontName,
	szFontSize,
	szForeColor,
	szBackColor
)
{
	try
	{
	    var frame = frames [szInstanceName + 'FrameID'];
		frame.document.execCommand (COMMAND_NAME_FONTNAME_RTB_OPGEEK, false, szFontName);
		frame.document.execCommand (COMMAND_NAME_FONTSIZE_RTB_OPGEEK, false, szFontSize);
        frame.fgColor = szForeColor;
        frame.bgColor = szBackColor;
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.FinaliseReadiness ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('finaliseFieldReadiness_rtb_opgeek', exCaughtException);
	}

	return;
}

function loadComplete_rtb_opgeek
(
)
{
	try
	{
		for (each in allInstantiatedFields_rtb_opgeek)
		{
			if (isDefined_rtb_opgeek (each))
			{
				allInstantiatedFields_rtb_opgeek [each].LoadComplete ();
			}
		}
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('loadComplete_rtb_opgeek', exCaughtException);
	}

	return;
}

function showContextMenu_rtb_opgeek
(
	szInstanceName
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.ShowContextMenu ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('showContextMenu_rtb_opgeek', exCaughtException);
	}

	return;
}

function hideAllContextMenus_rtb_opgeek
(
)
{
	try
	{
		for (each in allInstantiatedFields_rtb_opgeek)
		{
			if (isDefined_rtb_opgeek (each))
			{
				allInstantiatedFields_rtb_opgeek [each].ContextMenu.Hide ();
				allInstantiatedFields_rtb_opgeek [each].SetState ();
			}
		}
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('hideAllContextMenus_rtb_opgeek', exCaughtException);
	}

	return;
}

function highlightMenuItem_rtb_opgeek
(
)
{
	if (event.srcElement.className == 'menuitem_rtb_opgeek')
	{
		event.srcElement.style.backgroundColor = 'highlight';
		event.srcElement.style.color = 'highlighttext';
	}

	return true;
}

function unhighlightMenuItem_rtb_opgeek
(
)
{
	if (event.srcElement.className == 'menuitem_rtb_opgeek')
	{
		event.srcElement.style.backgroundColor = '';
		event.srcElement.style.color = '';
	}

	return true;
}

function setFontName_rtb_opgeek
(
	szInstanceName
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.SetFontName ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('setFontName_rtb_opgeek', exCaughtException);
	}

	return;
}

function setFontSize_rtb_opgeek
(
	szInstanceName
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.SetFontSize ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('setFontSize_rtb_opgeek', exCaughtException);
	}

	return;
}

function setFontColor_rtb_opgeek
(
	szInstanceName
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.SetFontColor ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('setFontColor_rtb_opgeek', exCaughtException);
	}

	return;
}

function setBackColor_rtb_opgeek
(
	szInstanceName
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.SetBackColor ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('setBackColor_rtb_opgeek', exCaughtException);
	}

	return;
}

function setState_rtb_opgeek
(
	szInstanceName
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.SetState ();
		insCurrentInstance.Update ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('setState_rtb_opgeek', exCaughtException);
	}

	return;
}

function update_rtb_opgeek
(
)
{
	try
	{
		for (each in allInstantiatedFields_rtb_opgeek)
		{
			if (isDefined_rtb_opgeek (each))
			{
				allInstantiatedFields_rtb_opgeek [each].Update ();
			}
		}
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('update_rtb_opgeek', exCaughtException);
	}

	return;
}

function prepareForSubmission_rtb_opgeek
(
)
{
	try
	{
		for (each in allInstantiatedFields_rtb_opgeek)
		{
			if (isDefined_rtb_opgeek (each))
			{
				allInstantiatedFields_rtb_opgeek [each].PrepareForSubmission ();
			}
		}
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('prepareForSubmission_rtb_opgeek', exCaughtException);
	}

	return;
}

function flipImage_rtb_opgeek
(
	szImageTagName,
	imgNewImageUrl
)
{
	if (document.images)
	{
        document [szImageTagName].src = imgNewImageUrl;
	}

	return;
}

function isDefined_rtb_opgeek
(
	objDoesThisExist
)
{
	var bIsDefined = true;
	if (('' + objDoesThisExist) == 'undefined')
	{
		bIsDefined = false;
	}
	
	return bIsDefined;
}

function handleMouseOver_rtb_opgeek
(
	szControlName,
	szButtonName
)
{
	try
	{
		flipImage_rtb_opgeek (szControlName + szButtonName, imgUpButton_rtb_opgeek);
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('handleMouseOver_rtb_opgeek', exCaughtException);
	}

	return false;
}

function handleDependentMouseOver_rtb_opgeek
(
	szControlName,
	szButtonName
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szControlName];
		if (!insCurrentInstance.IsActive (szButtonName))
		{
			flipImage_rtb_opgeek (szControlName + szButtonName, imgUpButton_rtb_opgeek);
		}
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('handleDependentMouseOver_rtb_opgeek', exCaughtException);
	}

	return false;
}

function handleMouseClick_rtb_opgeek
(
	szControlName,
	szButtonName
)
{
	try
	{
		flipImage_rtb_opgeek (szControlName + szButtonName, imgDownButton_rtb_opgeek);
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szControlName];
		insCurrentInstance.SetStyle (szButtonName);
		insCurrentInstance.Update ();
		insCurrentInstance.Focus ();
		hideAllContextMenus_rtb_opgeek ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('handleMouseClick_rtb_opgeek', exCaughtException);
	}

	return false;
}

function handleMouseOut_rtb_opgeek
(
	szControlName,
	szButtonName
)
{
	try
	{
		flipImage_rtb_opgeek (szControlName + szButtonName, imgNormalButton_rtb_opgeek);
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szControlName];
		insCurrentInstance.SetState ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('handleMouseOut_rtb_opgeek', exCaughtException);
	}

	return false;
}

function handleMouseUp_rtb_opgeek
(
	szControlName,
	szButtonName
)
{
	try
	{
		flipImage_rtb_opgeek (szControlName + szButtonName, imgUpButton_rtb_opgeek);
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('handleMouseUp_rtb_opgeek', exCaughtException);
	}

	return false;
}

function handleException_rtb_opgeek
(
	szFunctionName,
	exCaughtException
)
{
	alert ('Caught: "' + exCaughtException.description + '" in ' + szFunctionName);

	return;
}

function getBoolean_rtb_opgeek
(
	szBooleanValue
)
{
	var nValue = false;
	var szBoolean = szBooleanValue.toUpperCase();
	if (szBoolean == 'TRUE')
	{
		nValue = true;
	}

	return;
}

function trace_rtb_opgeek
(
	szTraceMessage
)
{
	var traceElement = document.getElementById ('trace');
	if (traceElement)
	{
		traceElement.innerHTML += szTraceMessage + '<br />';
	}

	return;
}

function traceEnter_rtb_opgeek
(
	szFunctionName
)
{
	trace_rtb_opgeek ('Entered (' + szFunctionName + ')');
}

function traceInfo_rtb_opgeek
(
	szFunctionName,
	szInfo
)
{
	trace_rtb_opgeek ('Info (' + szFunctionName + '): ' + szInfo);
}

function traceError_rtb_opgeek
(
	szFunctionName,
	szError
)
{
	trace_rtb_opgeek ('Error (' + szFunctionName + '): <font color="red">' + szError + '</font>');
}

function traceExit_rtb_opgeek
(
	szFunctionName
)
{
	trace_rtb_opgeek ('Exited (' + szFunctionName + ')');
}

function traceDump_rtb_opgeek
(
	szRTBName
)
{
	traceInfo_rtb_opgeek ('traceDump_rtb_opgeek', document.getElementById (szRTBName).value);
}

//====================================================================
// RichText Field object.
//====================================================================

function RichText_rtb_opgeek
(
	szInstanceName,
	szRealName
)
{
	this.Name = szInstanceName;
	this.RealName = szRealName;
	this.Activated = false;
	this.PromptActivated = false;

	this.SetFocus = false;
	this.InitialisationComplete = false;
	this.PromptDelivered = false;

	this.CutEnabled = false;
	this.CopyEnabled = false;
	this.PasteEnabled = false;
	this.UndoEnabled = false;
	this.RedoEnabled = true;

	this.Bold = false;
	this.Italic = false;
	this.Underline = false;
	this.AlignLeft = false;
	this.Center = false;
	this.AlignRight = true;
	this.Justify = false;
	this.Linked = false;
	this.BulletedList = false;
	this.NumberedList = false;

	this.StashedTextRange = null;

	this.CurrentFontName = '';
	this.CurrentFontSize = '';
	this.CurrentFontColor = '';
	this.CurrentBackColor = '';

	this.HiddenField = null;

	this.RawHtmlMode = false;

	return;
}

RichText_rtb_opgeek.prototype.Check = function ()
{
	traceInfo_rtb_opgeek ('Check', this.GetSelection ().queryCommandValue (COMMAND_NAME_FONTNAME_RTB_OPGEEK));
}

RichText_rtb_opgeek.prototype.GetFrame = function ()
{
	return document.getElementById (this.Name + 'FrameID');
}

RichText_rtb_opgeek.prototype.GetFrameWindow = function ()
{
	return frames [this.Name + 'FrameID'];
}

RichText_rtb_opgeek.prototype.GetFrameDocument = function ()
{
	return frames [this.Name + 'FrameID'].document;
}

RichText_rtb_opgeek.prototype.GetContentContainer = function ()
{
	return document.getElementById (this.Name + 'ContentID');
}

RichText_rtb_opgeek.prototype.GetPromptContainer = function ()
{
	return document.getElementById (this.Name + 'PromptID');
}

RichText_rtb_opgeek.prototype.GetHiddenField = function ()
{
	if (this.HiddenField == null)
	{
		try
		{
			this.HiddenField = document.all [this.RealName];
		}
		catch (exIgnoredException)
		{
		}
	}

	return this.HiddenField;
}

RichText_rtb_opgeek.prototype.GetForeColorDropdown = function ()
{
	return document.all [this.Name + COMMAND_NAME_FONTCOLOR_RTB_OPGEEK];
}

RichText_rtb_opgeek.prototype.GetBackColorDropdown = function ()
{
	return document.all [this.Name + COMMAND_NAME_BACKCOLOR_RTB_OPGEEK];
}

RichText_rtb_opgeek.prototype.GetFontNameDropdown = function ()
{
	return document.getElementById (this.Name + COMMAND_NAME_FONTNAME_RTB_OPGEEK);
}

RichText_rtb_opgeek.prototype.GetFontSizeDropdown = function ()
{
	return document.getElementById (this.Name + COMMAND_NAME_FONTSIZE_RTB_OPGEEK);
}

RichText_rtb_opgeek.prototype.Focus = function ()
{
	if (this.PromptDelivered)
	{
		this.GetFrameWindow ().focus ();
	}

	return;
}

RichText_rtb_opgeek.prototype.ClearPrompt = function ()
{
	try
	{
		if ((!this.PromptDelivered) && (this.PromptActivated))
		{
			this.Activated = false;

			var elEditDocument = this.GetFrameDocument ();
			var elPromptField = this.GetPromptContainer ();
			var elContentField = this.GetContentContainer ();
			if ((elPromptField != null) && (elContentField.innerHTML != ''))
			{
				elEditDocument.body.innerHTML = elContentField.innerHTML;
			}

			this.PromptDelivered = true;
			this.Activated = true;
		}
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('clearPrompt_o_rtb_opgeek', exCaughtException);
	}

	return;
}

RichText_rtb_opgeek.prototype.Activate = function ()
{
	try
	{
		this.GetFrameDocument ().designMode = 'On';
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('activate_o_rtb_opgeek', exCaughtException);
	}

	return;
}

RichText_rtb_opgeek.prototype.FinaliseReadiness = function ()
{
	this.Activated = true;

	return;
}

RichText_rtb_opgeek.prototype.LoadComplete = function ()
{
	try
	{
		var elEditDocument = this.GetFrameDocument ();
		var elContentField = this.GetPromptContainer ();
		var szContent = '';

		if ((elContentField == null) || (elContentField.innerHTML == ''))
		{
			elContentField = this.GetHiddenField ();
			szContent = elContentField.value;
			this.PromptDelivered = true;
		}
		else
		{
			szContent = elContentField.innerHTML;
		}

		elEditDocument.open ();
		elEditDocument.write (szContent);
		elEditDocument.close ();

		elEditDocument.oncontextmenu = new Function ("showContextMenu_rtb_opgeek ('" + this.Name + "'); return false;");
		elEditDocument.onclick = hideAllContextMenus_rtb_opgeek;
		elEditDocument.onbeforeeditfocus = new Function ("setState_rtb_opgeek ('" + this.Name + "'); return true;");
		elEditDocument.onkeyup = new Function ("setState_rtb_opgeek ('" + this.Name + "'); return true;");
		elEditDocument.onkeydown = new Function ("setState_rtb_opgeek ('" + this.Name + "'); return true;");
		elEditDocument.onkeypress = new Function ("setState_rtb_opgeek ('" + this.Name + "'); return true;");

		var taHiddenField = this.GetHiddenField ();
		var frFrame = this.GetFrame ();
		taHiddenField.style.width = Math.max (0, frFrame.offsetWidth) + 'px';
		taHiddenField.style.height = Math.max (0, frFrame.offsetHeight - 2) + 'px';

		this.SetFontName ();
		this.SetFontSize ();
		this.SetFontColor ();
		this.SetBackColor ();

		if (this.SetFocus)
		{
			this.Focus ();
		}

		this.PromptActivated = true;
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('loadComplete_o_rtb_opgeek', exCaughtException);
	}

	return;
}

RichText_rtb_opgeek.prototype.Initialize = function ()
{
	try
	{
		this.ContextMenu = new ContextMenu_rtb_opgeek (this.Name);
		this.ContextMenu.Initialize ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('initialize_o_rtb_opgeek', exCaughtException);
	}

	return;
}

RichText_rtb_opgeek.prototype.Update = function ()
{
	return;
}

RichText_rtb_opgeek.prototype.PrepareForSubmission = function ()
{
	if (this.Activated)
	{
		try
		{
			this.ClearPrompt ();

			if ((this.GetFrameDocument ().body != null) && (document.all [this.RealName] != null))
			{
				var szCurrentContents = String (this.GetFrameDocument ().body.innerHTML);
				if (szCurrentContents == "<P>&nbsp;</P>")
				{
					szCurrentContents = "";
				}

				this.GetHiddenField ().value = szCurrentContents;
			}
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('update_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.IsActive = function (szAction)
{
	var bActive = false;
	if (this.Activated)
	{
		switch (szAction)
		{
			case COMMAND_NAME_BOLD_RTB_OPGEEK:
				bActive = this.Bold;
				break;

			case COMMAND_NAME_ITALIC_RTB_OPGEEK:
				bActive = this.Italic;
				break;

			case COMMAND_NAME_UNDERLINE_RTB_OPGEEK:
				bActive = this.Underline;
				break;

			case COMMAND_NAME_ALIGNLEFT_RTB_OPGEEK:
				bActive = this.AlignLeft;
				break;

			case COMMAND_NAME_CENTER_RTB_OPGEEK:
				bActive = this.Center;
				break;

			case COMMAND_NAME_ALIGNRIGHT_RTB_OPGEEK:
				bActive = this.AlignRight;
				break;

			case COMMAND_NAME_JUSTIFY_RTB_OPGEEK:
				bActive = this.Justify;
				break;

			case COMMAND_NAME_LINK_RTB_OPGEEK:
				bActive = this.Linked;
				break;

			case COMMAND_NAME_BULLETEDLIST_RTB_OPGEEK:
				bActive = this.BulletedList;
				break;

			case COMMAND_NAME_NUMBEREDLIST_RTB_OPGEEK:
				bActive = this.NumberedList;
				break;

			case COMMAND_NAME_RAW_HTML_OPGEEK:
				bActive = this.RawHtmlMode;
				break;
		}
	}

	return bActive;
}

RichText_rtb_opgeek.prototype.GetSelection = function ()
{
	var slCurrentSelection = null;
	if (this.Activated)
	{
		try
		{
			slCurrentSelection = this.GetFrameDocument ().selection.createRange ();
			if (slCurrentSelection.text == '')
			{
				slCurrentSelection = this.GetFrameDocument ();
			}
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('getSelection_o_rtb_opgeek', exCaughtException);
		}
	}

	return slCurrentSelection;
}

RichText_rtb_opgeek.prototype.GetHiddenSelection = function ()
{
	var slCurrentSelection = null;
	if (this.Activated)
	{
		try
		{
			slCurrentSelection = this.StashedTextRange;
			slCurrentSelection.select ();
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('getHiddenSelection_o_rtb_opgeek', exCaughtException);
		}
	}

	return slCurrentSelection;
}

RichText_rtb_opgeek.prototype.SetStyle = function (szNewStyle)
{
	if (this.Activated)
	{
		try
		{
			if (szNewStyle == COMMAND_NAME_RAW_HTML_OPGEEK)
			{
				if (this.RawHtmlMode)
				{
					this.RawHtmlMode = false;
					this.GetFrameDocument ().body.innerHTML = this.GetHiddenField ().value;
					this.GetHiddenField ().style.display = 'none';
					this.GetFrame ().style.display = '';
					this.DisableButton (COMMAND_NAME_CUT_RTB_OPGEEK, this.CutEnabled);
					this.DisableButton (COMMAND_NAME_COPY_RTB_OPGEEK, this.CopyEnabled);
					this.DisableButton (COMMAND_NAME_PASTE_RTB_OPGEEK, this.PasteEnabled);
					this.DisableButton (COMMAND_NAME_UNDO_RTB_OPGEEK, this.UndoEnabled);
					this.DisableButton (COMMAND_NAME_REDO_RTB_OPGEEK, this.RedoEnabled);
				}
				else
				{
					this.RawHtmlMode = true;
					this.ClearPrompt ();
					this.GetFrame ().style.display = 'none';
					this.GetHiddenField ().style.display = '';
					this.GetHiddenField ().focus ();
					this.DisableButton (COMMAND_NAME_CUT_RTB_OPGEEK, false);
					this.DisableButton (COMMAND_NAME_COPY_RTB_OPGEEK, false);
					this.DisableButton (COMMAND_NAME_PASTE_RTB_OPGEEK, false);
					this.DisableButton (COMMAND_NAME_UNDO_RTB_OPGEEK, false);
					this.DisableButton (COMMAND_NAME_REDO_RTB_OPGEEK, false);
				}

				this.GetForeColorDropdown ().disabled = this.RawHtmlMode;
				this.GetBackColorDropdown ().disabled = this.RawHtmlMode;
				this.GetFontNameDropdown ().disabled = this.RawHtmlMode;
				this.GetFontSizeDropdown ().disabled = this.RawHtmlMode;
				this.DisableButton (COMMAND_NAME_BOLD_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_ITALIC_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_UNDERLINE_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_ALIGNLEFT_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_CENTER_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_ALIGNRIGHT_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_JUSTIFY_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_BULLETEDLIST_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_NUMBEREDLIST_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_INDENT_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_OUTDENT_RTB_OPGEEK, !this.RawHtmlMode);
				this.DisableButton (COMMAND_NAME_LINK_RTB_OPGEEK, !this.RawHtmlMode);
			}
			else
			{
				var slCurrentSelection;
				if ((this.ContextMenu.IsActive == true) && (szNewStyle != COMMAND_NAME_UNDO_RTB_OPGEEK) && (szNewStyle != COMMAND_NAME_REDO_RTB_OPGEEK))
				{
					slCurrentSelection = this.GetHiddenSelection ();
				}
				else
				{
					slCurrentSelection = this.GetSelection ();
				}
				this.ContextMenu.Hide ();
				slCurrentSelection.execCommand (szNewStyle, true, null);
			}
			this.PrepareForSubmission ();
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('setStyle_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.SetFontSize = function ()
{
	if (this.Activated)
	{
		try
		{
			var iNewSizeIndex = this.GetFontSizeDropdown ().selectedIndex;
			var szNewFontSize = this.GetFontSizeDropdown ().options [iNewSizeIndex].value;
			var slCurrentSelection = this.GetSelection ();
			var iCurrentBackground = slCurrentSelection.queryCommandValue (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK);
			slCurrentSelection.execCommand (COMMAND_NAME_FONTSIZE_RTB_OPGEEK, false, szNewFontSize);
			slCurrentSelection.execCommand (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK, false, iCurrentBackground);
			this.PrepareForSubmission ();
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('setFontSize_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.SetFontName = function ()
{
	if (this.Activated)
	{
		try
		{
			var iNewFontIndex = this.GetFontNameDropdown ().selectedIndex;
			var szNewFontName = this.GetFontNameDropdown ().options [iNewFontIndex].value;
			var slCurrentSelection = this.GetSelection ();
			var iCurrentBackground = slCurrentSelection.queryCommandValue (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK);
			slCurrentSelection.execCommand (COMMAND_NAME_FONTNAME_RTB_OPGEEK, false, szNewFontName);
			slCurrentSelection.execCommand (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK, false, iCurrentBackground);
			this.PrepareForSubmission ();
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('setFontName_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.SetFontColor = function ()
{
	if (this.Activated)
	{
		try
		{
			var iNewColorIndex = this.GetForeColorDropdown ().selectedIndex;
			var szNewColorName = this.GetForeColorDropdown ().options [iNewColorIndex].value;
			var slCurrentSelection = this.GetSelection ();
			var iCurrentBackground = slCurrentSelection.queryCommandValue (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK);
			slCurrentSelection.execCommand (COMMAND_NAME_FONTCOLOR_RTB_OPGEEK, false, szNewColorName);
			slCurrentSelection.execCommand (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK, false, iCurrentBackground);
			this.PrepareForSubmission ();
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('setFontColor_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.SetBackColor = function ()
{
	if (this.Activated)
	{
		try
		{
			var iNewBackColorIndex = this.GetBackColorDropdown ().selectedIndex;
			var szNewBackColorName = this.GetBackColorDropdown ().options [iNewBackColorIndex].value;
			var slCurrentSelection = this.GetSelection ();
			slCurrentSelection.execCommand (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK, false, szNewBackColorName);
			this.PrepareForSubmission ();
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('setBackColor_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.SetState = function ()
{
	if (this.Activated)
	{
		if (bInSetState_rtb_opgeek == true)
		{
			return true;
		}
		else
		{
			bInSetState_rtb_opgeek = true;
		}

		try
		{
			var slCurrentSelection = this.GetSelection ();

			this.Bold = slCurrentSelection.queryCommandState (COMMAND_NAME_BOLD_RTB_OPGEEK);
			this.Italic = slCurrentSelection.queryCommandState (COMMAND_NAME_ITALIC_RTB_OPGEEK);
			this.Underline = slCurrentSelection.queryCommandState (COMMAND_NAME_UNDERLINE_RTB_OPGEEK);
			this.AlignLeft = slCurrentSelection.queryCommandState (COMMAND_NAME_ALIGNLEFT_RTB_OPGEEK);
			this.Center = slCurrentSelection.queryCommandState (COMMAND_NAME_CENTER_RTB_OPGEEK);
			this.AlignRight = slCurrentSelection.queryCommandState (COMMAND_NAME_ALIGNRIGHT_RTB_OPGEEK);
			this.Justify = slCurrentSelection.queryCommandState (COMMAND_NAME_JUSTIFY_RTB_OPGEEK);
			this.BulletedList = slCurrentSelection.queryCommandState (COMMAND_NAME_BULLETEDLIST_RTB_OPGEEK);
			this.NumberedList = slCurrentSelection.queryCommandState (COMMAND_NAME_NUMBEREDLIST_RTB_OPGEEK);
			this.Linked = slCurrentSelection.queryCommandEnabled (COMMAND_NAME_LINK_RTB_OPGEEK);

			this.CurrentFontName = slCurrentSelection.queryCommandValue (COMMAND_NAME_FONTNAME_RTB_OPGEEK);
			this.CurrentFontSize = slCurrentSelection.queryCommandValue (COMMAND_NAME_FONTSIZE_RTB_OPGEEK);
			this.CurrentFontColor = slCurrentSelection.queryCommandValue (COMMAND_NAME_FONTCOLOR_RTB_OPGEEK);
			this.CurrentBackColor = slCurrentSelection.queryCommandValue (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK);

			if (this.RawHtmlMode)
			{
				this.CutEnabled = false;
				this.CopyEnabled = false;
				this.PasteEnabled = false;
				this.UndoEnabled = false;
				this.RedoEnabled = false;
			}
			else
			{
				this.CutEnabled = slCurrentSelection.queryCommandEnabled (COMMAND_NAME_CUT_RTB_OPGEEK);
				this.CopyEnabled = slCurrentSelection.queryCommandEnabled (COMMAND_NAME_COPY_RTB_OPGEEK);
				this.PasteEnabled = slCurrentSelection.queryCommandEnabled (COMMAND_NAME_PASTE_RTB_OPGEEK);
				this.UndoEnabled = slCurrentSelection.queryCommandEnabled (COMMAND_NAME_UNDO_RTB_OPGEEK);
				this.RedoEnabled = slCurrentSelection.queryCommandEnabled (COMMAND_NAME_REDO_RTB_OPGEEK);
			}

			this.DisableButton (COMMAND_NAME_CUT_RTB_OPGEEK, this.CutEnabled);
			this.DisableButton (COMMAND_NAME_COPY_RTB_OPGEEK, this.CopyEnabled);
			this.DisableButton (COMMAND_NAME_PASTE_RTB_OPGEEK, this.PasteEnabled);
			this.DisableButton (COMMAND_NAME_UNDO_RTB_OPGEEK, this.UndoEnabled);
			this.DisableButton (COMMAND_NAME_REDO_RTB_OPGEEK, this.RedoEnabled);

			if (!this.AlignLeft && !this.Center && !this.AlignRight && !this.Justify)
			{
				this.AlignLeft = true;
			}

			this.SetButton (COMMAND_NAME_BOLD_RTB_OPGEEK, this.Bold);
			this.SetButton (COMMAND_NAME_ITALIC_RTB_OPGEEK, this.Italic);
			this.SetButton (COMMAND_NAME_UNDERLINE_RTB_OPGEEK, this.Underline);
			this.SetButton (COMMAND_NAME_ALIGNLEFT_RTB_OPGEEK, this.AlignLeft);
			this.SetButton (COMMAND_NAME_CENTER_RTB_OPGEEK, this.Center);
			this.SetButton (COMMAND_NAME_ALIGNRIGHT_RTB_OPGEEK, this.AlignRight);
			this.SetButton (COMMAND_NAME_JUSTIFY_RTB_OPGEEK, this.Justify);
			this.SetButton (COMMAND_NAME_BULLETEDLIST_RTB_OPGEEK, this.BulletedList);
			this.SetButton (COMMAND_NAME_NUMBEREDLIST_RTB_OPGEEK, this.NumberedList);
			this.SetButton (COMMAND_NAME_LINK_RTB_OPGEEK, this.Linked);
			this.SetButton (COMMAND_NAME_RAW_HTML_OPGEEK, this.RawHtmlMode);

			this.SetFontDropdown (COMMAND_NAME_FONTNAME_RTB_OPGEEK, this.CurrentFontName);
			this.SetFontDropdown (COMMAND_NAME_FONTSIZE_RTB_OPGEEK, this.CurrentFontSize);
			this.SetColorDropdown (COMMAND_NAME_FONTCOLOR_RTB_OPGEEK, this.CurrentFontColor, false);
			this.SetColorDropdown (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK, this.CurrentBackColor, true);

			bInSetState_rtb_opgeek = false;
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('setState_o_rtb_opgeek', exCaughtException);
			bInSetState_rtb_opgeek = false;
		}
	}

	return true;
}

RichText_rtb_opgeek.prototype.DisableButton = function (szButtonID, bEnabled)
{
	if (this.Activated)
	{
		try
		{
			if (bEnabled)
			{
				document.all [this.Name + szButtonID + 'Disabled'].style.display = 'none'
			}
			else
			{
				document.all [this.Name + szButtonID + 'Disabled'].style.display = ''
			}
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('disableButton_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.MungeColorCode = function (szDodgyColorCode)
{
	var szRealColorCode;
	var szCodeWithoutHash = String (szDodgyColorCode);
	if (String (szCodeWithoutHash).charAt (0) == '#')
	{
		szRealColorCode = szDodgyColorCode;
	}
	else
	{
		var szCodeInHex;
		var szCodeInDecimal;
		szCodeInDecimal = Number (szCodeWithoutHash);

		if (isNaN (szCodeInDecimal))
		{
			szCodeInHex = parseInt (szCodeWithoutHash, 16).toString (16);
		}
		else
		{
			szCodeInHex = szCodeInDecimal.toString (16);
		}

		var szSixDigitCodeInHex;
		var bFourDigitMunged = false;
		var bReversed = false;
		var bMultiPadded = false;
		if (szCodeInHex.length == 6)
		{
			bReversed = true;
			szSixDigitCodeInHex = szCodeInHex.substr (4, 2) + szCodeInHex.substr (2, 2) + szCodeInHex.substr (0, 2);
		}
		else
		{
			if (szCodeInHex.length == 4)
			{
				bFourDigitMunged = true;
				if (parseInt (szCodeInHex.substr (2, 2), 16) >= parseInt (szCodeInHex.substr (0, 2), 16))
				{
					szSixDigitCodeInHex = szCodeInHex + '00';
				}
				else
				{
					szSixDigitCodeInHex = '00' + szCodeInHex;
				}
			}
			else
			{
				bMultiPadded = true;
				szSixDigitCodeInHex = szCodeInHex;
				while (szSixDigitCodeInHex.length < 6)
				{
					szSixDigitCodeInHex = szSixDigitCodeInHex + '0';
				}
			}
		}

		var szUpperCaseCode = szSixDigitCodeInHex.toUpperCase ();
		szRealColorCode = '#' + szUpperCaseCode;
	}

//alert ('State was ' + szDodgyColorCode
//	+ ', without hash: ' + szCodeWithoutHash
//	+ ', in hex: ' + szCodeInHex
//	+ ', 4-digit: ' + bFourDigitMunged
//	+ ', revesed: ' + bReversed
//	+ ', multipadded: ' + bMultiPadded
//	+ ', padded and reversed: ' + szSixDigitCodeInHex
//	+ ', uppercased: ' + szUpperCaseCode
//	+ ' and finally ' + szRealColorCode);

	return szRealColorCode;
}

RichText_rtb_opgeek.prototype.SetColorDropdown = function (szDropdownName, szState, nBackground)
{
	if (this.Activated)
	{
		try
		{
			var control = document.all [this.Name + szDropdownName];

			szState = this.MungeColorCode (szState);
			if (control != null)
			{
				if (nBackground)
				{
					var szBackground = this.GetFrameDocument ().bgColor.toUpperCase ();
					if (szBackground == szState.toUpperCase ())
					{
						szState = 'transparent';
					}
				}
				else
				{
					var szForeground = this.GetFrameDocument ().fgColor.toUpperCase ();
					if (szForeground == szState.toUpperCase ())
					{
						szState = 'transparent';
					}
				}

				var nDefiniteMatchAt = -1;
				var currentOption = '';
				for (var nCounter = 0; (nCounter < control.options.length) && (nDefiniteMatchAt == -1); nCounter++)
				{
					currentOption = control.options [nCounter].value;
					if (currentOption.toUpperCase () == szState.toUpperCase ())
					{
						nDefiniteMatchAt = nCounter;
					}
				}

				if (nDefiniteMatchAt != -1)
				{
					control.options.selectedIndex = nDefiniteMatchAt;
				}
			}
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('setColorDropdown_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.SetFontDropdown = function (szDropdownName, szState)
{
	if (this.Activated)
	{
		try
		{
			var control = document.all [this.Name + szDropdownName];

			if (szState == '')
			{
				control.selectedIndex = 0;
			}
			else
			{
				var nDefiniteMatchAt = -1;

				var aszAllStates = null;
				szState = String (szState);
				if (szState.indexOf (',') > -1)
				{
					aszAllStates = szState.split (',');
				}
				else
				{
					aszAllStates = new Array ();
					aszAllStates [0] = szState;
				}

				for (var nCounter = 0; (nCounter < control.options.length) && (nDefiniteMatchAt == -1); nCounter++)
				{
					if (control.options [nCounter].value == szState)
					{
						nDefiniteMatchAt = nCounter;
					}
					else if (control.options [nCounter].text == szState)
					{
						nDefiniteMatchAt = nCounter;
					}

					if (nDefiniteMatchAt == -1)
					{
						var aszOptionStates = control.options [nCounter].value.split (',');
						for (iStateSegment in aszAllStates)
						{
							var szStateSegment = aszAllStates [iStateSegment].toLowerCase ();
							for (iOptionSegment in aszOptionStates)
							{
								if (szStateSegment == aszOptionStates [iOptionSegment].toLowerCase ())
								{
									nDefiniteMatchAt = nCounter;
								}
							}
						}
					}
				}

				if (nDefiniteMatchAt != -1)
				{
					control.options.selectedIndex = nDefiniteMatchAt;
				}
			}
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('setFontDropdown_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.SetButton = function (szButtonID, bState)
{
	if (this.Activated)
	{
		try
		{
			if (bState)
			{
				flipImage_rtb_opgeek (this.Name + szButtonID, imgDownButton_rtb_opgeek);
			}
			else
			{
				flipImage_rtb_opgeek (this.Name + szButtonID, imgNormalButton_rtb_opgeek);
			}
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('setButton_o_rtb_opgeek', exCaughtException);
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.GetLeftOffset = function (objElement)
{
	var elWorkingTag = objElement;
	var nLeftOffset = 0;
	while ((elWorkingTag) && (elWorkingTag.style.position != 'absolute') && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
	{
		nLeftOffset += elWorkingTag.offsetLeft;
		elWorkingTag = elWorkingTag.offsetParent;
	}

	return nLeftOffset;
}

RichText_rtb_opgeek.prototype.GetTopOffset = function (objElement)
{
	var elWorkingTag = objElement;
	var nTopOffset = 0;
	while ((elWorkingTag) && (elWorkingTag.style.position != 'absolute') && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
	{
		nTopOffset += elWorkingTag.offsetTop;
		elWorkingTag = elWorkingTag.offsetParent;
	}

	return nTopOffset;
}

RichText_rtb_opgeek.prototype.ShowContextMenu = function ()
{
	if (this.Activated)
	{
		hideAllContextMenus_rtb_opgeek ();
		try
		{
			var objElement = this.GetFrame ();
			var iElementLeft = this.GetLeftOffset (objElement);
			var iElementTop = this.GetTopOffset (objElement);

			this.StashedTextRange = this.GetFrameDocument ().selection.createRange ();

			var iControlOffsetLeft = this.GetFrameWindow ().event.clientX + iElementLeft;
			var iControlOffsetTop = this.GetFrameWindow ().event.clientY + iElementTop;
			var iRemainingWidth = document.body.clientWidth - this.GetFrameWindow ().event.clientX - iElementLeft;
			var iRemainingHeight = document.body.clientHeight - this.GetFrameWindow ().event.clientY - iElementTop;

			var iMenuWidth = this.ContextMenu.GetWidth ();
			var iMenuHeight = this.ContextMenu.GetHeight ();

			var iMenuLeft = iControlOffsetLeft;
			if (iRemainingWidth < iMenuWidth)
			{
				iMenuLeft = Math.min (document.body.clientWidth - iMenuWidth, iControlOffsetLeft - iMenuWidth);
				iMenuLeft = (iMenuLeft <  0 ? 0 : iMenuLeft);
			}

			var iMenuTop = iControlOffsetTop;
			if (iRemainingHeight < iMenuHeight)
			{
				iMenuTop = Math.min (document.body.clientHeight - iMenuHeight, iControlOffsetTop - iMenuHeight);
				iMenuTop = (iMenuTop <  0 ? 0 : iMenuTop);
			}

			this.ContextMenu.Show (iMenuLeft, iMenuTop);
		}
		catch (exCaughtException)
		{
			handleException_rtb_opgeek ('showContextMenu_o_rtb_opgeek', exCaughtException);
		}
	}

	return false;
}

//====================================================================
// ContextMenu object.
//====================================================================

function ContextMenu_rtb_opgeek
(
	szParentName
)
{
	this.IsActive = false;
	this.ParentName = szParentName;

	this.HiddenSelects = new Array ();
	this.HiddenObjects = new Array ();

	return;
}

ContextMenu_rtb_opgeek.prototype.GetContextMenuElement = function ()
{
	return document.getElementById (this.ParentName + 'ContextMenu_rtb_opgeek');
}

ContextMenu_rtb_opgeek.prototype.Initialize = function ()
{
	document.write (this.GetMenu ());

	return;
}

ContextMenu_rtb_opgeek.prototype.GetWidth = function ()
{
	return this.GetContextMenuElement ().offsetWidth;
}

ContextMenu_rtb_opgeek.prototype.GetHeight = function ()
{
	return this.GetContextMenuElement ().offsetHeight;
}

ContextMenu_rtb_opgeek.prototype.Show = function (iLeft, iTop)
{
	this.IsActive = true;
	var mnContextMenu = this.GetContextMenuElement ();

	mnContextMenu.style.left = iLeft;
	mnContextMenu.style.top = iTop;
	mnContextMenu.style.visibility = 'visible';

	if (bSomeElementsHidden_rtb_opgeek)
	{
		this.ShowProblematicElements (this.HiddenSelects);
		this.ShowProblematicElements (this.HiddenObjects);
	}
	this.HideProblematicElements ('SELECT', this.HiddenSelects);
	this.HideProblematicElements ('OBJECT', this.HiddenObjects);

	return;
}

ContextMenu_rtb_opgeek.prototype.Hide = function ()
{
	var mnContextMenu = this.GetContextMenuElement ();
	mnContextMenu.style.visibility = 'hidden';

	this.IsActive = false;

	if (bSomeElementsHidden_rtb_opgeek)
	{
		this.ShowProblematicElements (this.HiddenSelects);
		this.ShowProblematicElements (this.HiddenObjects);
	}

	return;
}

ContextMenu_rtb_opgeek.prototype.GetMenuItem = function (szItemID, szTitle)
{
	var szHTMLout = '';
	szHTMLout += HTML_TAG_OPEN_RTB_OPGEEK + 'div class=\'menuitem_rtb_opgeek\' style=\'padding-left: 5px; padding-right: 5px; padding-top: 1px; padding-bottom: 2px;\' id=\'' + this.ParentName + 'Menu' + szItemID + '\'';
	szHTMLout += ' onclick=\'return handleMouseClick_rtb_opgeek (' + QUOTE_MARK_RTB_OPGEEK + this.ParentName + QUOTE_MARK_RTB_OPGEEK + ', ' + QUOTE_MARK_RTB_OPGEEK + szItemID + QUOTE_MARK_RTB_OPGEEK + ');\'' + HTML_TAG_CLOSE_RTB_OPGEEK;
	szHTMLout += '&nbsp;&nbsp;&nbsp;&nbsp;';
	szHTMLout += szTitle;
	szHTMLout += HTML_TAG_OPEN_RTB_OPGEEK + '/div' + HTML_TAG_CLOSE_RTB_OPGEEK;

	return szHTMLout;
}

ContextMenu_rtb_opgeek.prototype.GetSeparator = function ()
{
	return HTML_TAG_OPEN_RTB_OPGEEK + 'hr style="border: 0; height: 1px; background-color: black;"/' + HTML_TAG_CLOSE_RTB_OPGEEK;
}

ContextMenu_rtb_opgeek.prototype.GetMenu = function ()
{
	var szMenu = '';

	szMenu += HTML_TAG_OPEN_RTB_OPGEEK + 'div id=\'' + this.ParentName + 'ContextMenu_rtb_opgeek\' ';
	szMenu += 'onmouseover=\'return highlightMenuItem_rtb_opgeek (event);\' onmouseout=\'return unhighlightMenuItem_rtb_opgeek (event);\' ';
	szMenu += 'style=\'visibility: hidden; z-index: 200; cursor: default; position: absolute; font-size: 8pt; ';
	szMenu += 'font-family: Tahoma, sans-serif; color: black; background-color: menu; ';
	szMenu += 'width: 150px; padding-top: 2px; padding-bottom: 2px; padding-left: 1px; padding-right: 1px; ';
	szMenu += 'border: 2px outset buttonhighlight;\'' + HTML_TAG_CLOSE_RTB_OPGEEK;

	szMenu += this.GetMenuItem (COMMAND_NAME_UNDO_RTB_OPGEEK, COMMAND_TITLE_UNDO_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_REDO_RTB_OPGEEK, COMMAND_TITLE_REDO_RTB_OPGEEK);
	szMenu += this.GetSeparator ()

	szMenu += this.GetMenuItem (COMMAND_NAME_SELECTALL_RTB_OPGEEK, COMMAND_TITLE_SELECTALL_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_COPY_RTB_OPGEEK, COMMAND_TITLE_COPY_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_CUT_RTB_OPGEEK, COMMAND_TITLE_CUT_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_PASTE_RTB_OPGEEK, COMMAND_TITLE_PASTE_RTB_OPGEEK);
	szMenu += this.GetSeparator ()

	szMenu += this.GetMenuItem (COMMAND_NAME_BOLD_RTB_OPGEEK, COMMAND_TITLE_BOLD_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_ITALIC_RTB_OPGEEK, COMMAND_TITLE_ITALIC_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_UNDERLINE_RTB_OPGEEK, COMMAND_TITLE_UNDERLINE_RTB_OPGEEK);
	szMenu += this.GetSeparator ()

	szMenu += this.GetMenuItem (COMMAND_NAME_ALIGNLEFT_RTB_OPGEEK, COMMAND_TITLE_ALIGNLEFT_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_CENTER_RTB_OPGEEK, COMMAND_TITLE_CENTER_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_ALIGNRIGHT_RTB_OPGEEK, COMMAND_TITLE_ALIGNRIGHT_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_JUSTIFY_RTB_OPGEEK, COMMAND_TITLE_JUSTIFY_RTB_OPGEEK);
	szMenu += this.GetSeparator ()

	szMenu += this.GetMenuItem (COMMAND_NAME_LINK_RTB_OPGEEK, COMMAND_TITLE_LINK_RTB_OPGEEK);
	szMenu += this.GetSeparator ()

	szMenu += this.GetMenuItem (COMMAND_NAME_BULLETEDLIST_RTB_OPGEEK, COMMAND_TITLE_BULLETEDLIST_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_NUMBEREDLIST_RTB_OPGEEK, COMMAND_TITLE_NUMBEREDLIST_RTB_OPGEEK);
	szMenu += this.GetSeparator ()

	szMenu += this.GetMenuItem (COMMAND_NAME_INDENT_RTB_OPGEEK, COMMAND_TITLE_INDENT_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_OUTDENT_RTB_OPGEEK, COMMAND_TITLE_OUTDENT_RTB_OPGEEK);

	szMenu += HTML_TAG_OPEN_RTB_OPGEEK + '/div' + HTML_TAG_CLOSE_RTB_OPGEEK;

	return szMenu;
}

ContextMenu_rtb_opgeek.prototype.ShowProblematicElements = function (aHiddenElements)
{
	for (var nCounter = 0; nCounter < aHiddenElements.length; nCounter++)
	{
		document.all [aHiddenElements [nCounter]].style.visibility = 'visible';
	}

	return;
}

ContextMenu_rtb_opgeek.prototype.HideProblematicElements = function (szElementName, aHiddenElements)
{
	var mnContextMenu = this.GetContextMenuElement ();

	var nMenuLeft = parseInt (mnContextMenu.style.left);
	var nMenuRight = nMenuLeft + parseInt (mnContextMenu.clientWidth);
	var nMenuTop = parseInt (mnContextMenu.style.top);
	var nMenuBottom = nMenuTop + parseInt (mnContextMenu.clientHeight);

	aHiddenElements.length = 0

	var objElement;
	var objElementParent;
	var nElementLeft;
	var nElementRight;
	var nElementTop;
	var nElementBottom;
	for (nCounter = 0; nCounter < document.all.tags (szElementName).length; nCounter++)
	{
		objElement = document.all.tags (szElementName) [nCounter];
		if (!objElement || !objElement.offsetParent)
		{
			continue;
		}

		nElementLeft = objElement.offsetLeft;
		nElementTop = objElement.offsetTop;
		objElementParent = objElement.offsetParent;

		while ((objElementParent) && (objElementParent.tagName.toUpperCase() != 'BODY'))
		{
			nElementLeft += objElementParent.offsetLeft;
			nElementTop += objElementParent.offsetTop;
			objElementParent = objElementParent.offsetParent;
		}

		nElementRight = nElementLeft + objElement.offsetWidth;
		nElementBottom = nElementTop + objElement.offsetHeight;

		if (!(nMenuLeft > nElementRight)
			&& !(nMenuRight < nElementLeft)
			&& !(nMenuTop > nElementBottom)
			&& !(nMenuBottom < nElementTop))
		{
			objElement.style.visibility = 'hidden';
			aHiddenElements [aHiddenElements.length] = objElement.name;
		}
	}

	bSomeElementsHidden_rtb_opgeek = true;

	return;
}
