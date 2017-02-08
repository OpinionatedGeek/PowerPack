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
var COMMAND_NAME_BACKCOLOR_RTB_OPGEEK = 'HiliteColor';
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

var bInSetState_rtb_opgeek = false;

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

	window.addEventListener ('load', activateAllFields_rtb_opgeek, false);

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
		if (!bLibraryInitialized_rtb_opgeek)
		{
			runOnce_rtb_opgeek (szButtonNormalImageUrl, szButtonUpImageUrl, szButtonDownImageUrl);
		}

		if (isDefined_rtb_opgeek (allInstantiatedFields_rtb_opgeek [szInstanceName]))
		{
			alert ('Field ' + szInstanceName + ' is already defined for this page.');
		}
		else
		{
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

function activateAllFields_rtb_opgeek
(
)
{
	for (szFieldName in allInstantiatedFields_rtb_opgeek)
	{
		allInstantiatedFields_rtb_opgeek [szFieldName].Activate ();
	}

	return;
}

function activateField_rtb_opgeek
(
	szInstanceName,
	nSetFocus
)
{
	var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
	insCurrentInstance.SetFocus = nSetFocus;

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
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.ForegroundColor = szForeColor;
		insCurrentInstance.BackgroundColor = szBackColor;
		insCurrentInstance.CurrentFontName = szFontName;
		insCurrentInstance.CurrentFontSize = szFontSize;
		var frameDocument = insCurrentInstance.GetFrameDocument ();
		frameDocument.open ();
		frameDocument.close ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('finaliseFieldReadiness_rtb_opgeek', exCaughtException);
	}

	return;
}

function showContextMenu_rtb_opgeek
(
	szInstanceName,
	eventArgs
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.ShowContextMenu (eventArgs);
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
	eventArgs
)
{
	if (eventArgs.target.className == 'menuitem_rtb_opgeek')
	{
		eventArgs.target.style.backgroundColor = 'highlight';
		eventArgs.target.style.color = 'highlighttext';
	}

	return true;
}

function unhighlightMenuItem_rtb_opgeek
(
	eventArgs
)
{
	if (eventArgs.target.className == 'menuitem_rtb_opgeek')
	{
		eventArgs.target.style.backgroundColor = '';
		eventArgs.target.style.color = '';
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
		insCurrentInstance.Update ();
		insCurrentInstance.Focus ();
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
		insCurrentInstance.Update ();
		insCurrentInstance.Focus ();
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
		insCurrentInstance.Update ();
		insCurrentInstance.Focus ();
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
		insCurrentInstance.Update ();
		insCurrentInstance.Focus ();
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

function clearPrompt_rtb_opgeek
(
	szInstanceName
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.ClearPrompt ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('clearPrompt_rtb_opgeek', exCaughtException);
	}

	return;
}

function handleKeyPress_rtb_opgeek
(
	szInstanceName,
	eventArgs
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.HandleKeyPress (eventArgs);
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('handleKeyPress_rtb_opgeek', exCaughtException);
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

function updateField_rtb_opgeek
(
	fieldname
)
{
	try
	{
		var insCurrentInstance = allInstantiatedFields_rtb_opgeek [szInstanceName];
		insCurrentInstance.Update ();
	}
	catch (exCaughtException)
	{
		handleException_rtb_opgeek ('updateField_rtb_opgeek', exCaughtException);
	}

	return;
}

function flipImage_rtb_opgeek (szImageTagName, imgNewImageObject)
{
	if (document.images)
	{
		document [szImageTagName].src = imgNewImageObject;
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
		flipImage_rtb_opgeek (szControlName + szButtonName, imgNormalButton_rtb_opgeek);
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

function trace_rtb_opgeek
(
	szTraceMessage
)
{
//	var traceElement = document.getElementById ('trace');
//	if (traceElement)
//	{
//		traceElement.innerHTML += szTraceMessage + '<br />';
//	}
//
//	return;
}

function traceEnter_rtb_opgeek
(
	szFunctionName
)
{
//	trace_rtb_opgeek ('Entered (' + szFunctionName + ')');
}

function traceInfo_rtb_opgeek
(
	szFunctionName,
	szInfo
)
{
//	trace_rtb_opgeek ('Info (' + szFunctionName + '): ' + szInfo);
}


function traceError_rtb_opgeek
(
	szFunctionName,
	szError
)
{
//	trace_rtb_opgeek ('Error (' + szFunctionName + '): <font color="red">' + szError + '</font>');
}

function traceExit_rtb_opgeek
(
	szFunctionName
)
{
//	trace_rtb_opgeek ('Exited (' + szFunctionName + ')');
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

	this.CurrentFontName = '';
	this.CurrentFontSize = '';
	this.CurrentFontColor = '#000000';
	this.CurrentBackColor = '#ffffff';

	this.StashedFontData = false;

	this.HiddenSelects = new Array ();
	this.HiddenObjects = new Array ();

	this.RawHtmlMode = false;

	return;
}

RichText_rtb_opgeek.prototype.GetFrame = function ()
{
	return document.getElementById (this.Name + 'FrameID');
}

RichText_rtb_opgeek.prototype.GetFrameWindow = function ()
{
	return this.GetFrame ().contentWindow;
}

RichText_rtb_opgeek.prototype.GetFrameDocument = function ()
{
	return this.GetFrame ().contentDocument;
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
	return document.getElementById (this.RealName);
}

RichText_rtb_opgeek.prototype.GetForeColorDropdown = function ()
{
	return document.getElementById (this.Name + COMMAND_NAME_FONTCOLOR_RTB_OPGEEK);
}

RichText_rtb_opgeek.prototype.GetBackColorDropdown = function ()
{
	return document.getElementById (this.Name + COMMAND_NAME_BACKCOLOR_RTB_OPGEEK);
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
	if (!this.PromptDelivered)
	{
		this.Activated = false;

		var elContentField = this.GetContentContainer ();
		var elEditDocument = this.GetFrameDocument ();
		var elEditBody = null;
		try
		{
			elEditBody = elEditDocument.body;
		}
		catch (exIgnored)
		{
		}

		if (elEditBody != null)
		{
			elEditBody.innerHTML = elContentField.innerHTML;
			this.PromptDelivered = true;
			this.Activated = true;
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.Activate = function ()
{
	var elEditDocument = this.GetFrameDocument ();
	var elContentField = this.GetPromptContainer ();
	if ((elContentField == null) || (elContentField.innerHTML == ''))
	{
		elContentField = this.GetContentContainer ();
		this.PromptDelivered = true;
	}

	var nBackButton = false;
	try
	{
		var elEditBody = elEditDocument.body;
	}
	catch (exIgnoredException)
	{
		nBackButton = true;
		elContentField = this.GetHiddenField ();
		this.PromptDelivered = true;
	}

	try
	{
		//alert (nBackButton + ': Content HTML: ' + elContentField.innerHTML);
		//alert (nBackButton + ': Content value: ' + elContentField.value);
		if (nBackButton)
		{
			if (elContentField.value != '')
			{
				elEditDocument.body.innerHTML = elContentField.value;
			}
		}
		else
		{
			elEditDocument.body.innerHTML = elContentField.innerHTML;
		}

		if (elEditDocument.designMode != 'on')
		{
			elEditDocument.designMode = 'on';
		}

		this.Activated = true;

		var taHiddenField = this.GetHiddenField ();
		var frFrame = this.GetFrame ();
		taHiddenField.style.width = frFrame.offsetWidth + 'px';
		taHiddenField.style.height = (frFrame.offsetHeight - 2) + 'px';

		elEditDocument.body.style.backgroundColor = this.CurrentBackColor;
		elEditDocument.body.style.color = this.CurrentFontColor;
		elEditDocument.body.style.fontFamily = this.CurrentFontName;
		this.SetFontDropdown (COMMAND_NAME_FONTNAME_RTB_OPGEEK, this.CurrentFontName);
		elEditDocument.body.style.fontSize = this.CurrentFontSize;
		this.SetFontDropdown (COMMAND_NAME_FONTSIZE_RTB_OPGEEK, this.CurrentFontSize);
	}
	catch (exPotentialException)
	{
		handleException_rtb_opgeek ('activate_o_rtb_opgeek', exPotentialException);
	}

	var ctlForeColorDropdown = this.GetForeColorDropdown ();
	ctlForeColorDropdown.selectedIndex = 0;
	var ctlBackColorDropdown = this.GetBackColorDropdown ();
	ctlBackColorDropdown.selectedIndex = 0;

	this.SetFontName ();
	this.SetFontSize ();
	this.SetFontColor ();
	this.SetBackColor ();

	this.SetState ();

	if (this.SetFocus)
	{
		this.Focus ();
	}

	this.Update ();

	return;
}

RichText_rtb_opgeek.prototype.Initialize = function ()
{
	this.ContextMenu = new ContextMenu_rtb_opgeek (this.Name);
	this.ContextMenu.Initialize ();

	return;
}

RichText_rtb_opgeek.prototype.Update = function ()
{
	if (this.Activated)
	{
		if ((this.GetFrameDocument ().body != null) && (this.GetHiddenField () != null))
		{
			var szCurrentContents = String (this.GetFrameDocument ().body.innerHTML);
			if (szCurrentContents == "<P>&nbsp;</P>")
			{
				szCurrentContents = "";
			}
			this.GetHiddenField ().value = szCurrentContents;
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
		slCurrentSelection = this.GetFrameDocument ();
	}

	return slCurrentSelection;
}

RichText_rtb_opgeek.prototype.StashFontData = function ()
{
	var slCurrentSelection = this.GetSelection ();
	this.StashedFontName = slCurrentSelection.queryCommandValue (COMMAND_NAME_FONTNAME_RTB_OPGEEK);
	this.StashedFontSize = slCurrentSelection.queryCommandValue (COMMAND_NAME_FONTSIZE_RTB_OPGEEK);
	this.StashedFontData = true;

	return;
}

RichText_rtb_opgeek.prototype.UnstashFontData = function ()
{
	if (this.StashedFontData)
	{
		var slCurrentSelection = this.GetSelection ();
		slCurrentSelection.execCommand (COMMAND_NAME_FONTNAME_RTB_OPGEEK, false, this.StashedFontName);
		slCurrentSelection.execCommand (COMMAND_NAME_FONTSIZE_RTB_OPGEEK, false, this.StashedFontSize);
		this.StashedFontName = null;
		this.StashedFontSize = null;
		this.StashedFontData = false;
	}

	return;
}

RichText_rtb_opgeek.prototype.HandleKeyPress = function (eventArgs)
{
	if (this.Activated)
	{
		if (eventArgs.keyCode == 13)
		{
			this.StashFontData ();
		}

		if (eventArgs.ctrlKey && !eventArgs.altKey && !eventArgs.shiftKey)
		{
			var nCancelEvent = false;
			switch (eventArgs.charCode)
			{
				case 98:
					this.SetStyle (COMMAND_NAME_BOLD_RTB_OPGEEK);
					nCancelEvent = true;
					break;

				case 105:
					this.SetStyle (COMMAND_NAME_ITALIC_RTB_OPGEEK);
					nCancelEvent = true;
					break;

				case 107:
					this.SetStyle (COMMAND_NAME_LINK_RTB_OPGEEK);
					nCancelEvent = true;
					break;

				case 117:
					this.SetStyle (COMMAND_NAME_UNDERLINE_RTB_OPGEEK);
					nCancelEvent = true;
					break;
			}

			if (nCancelEvent)
			{
				eventArgs.preventDefault ();
			}
		}

		this.Update ();
	}

	return;
}

RichText_rtb_opgeek.prototype.SetStyle = function (szNewStyle)
{
	if (this.Activated)
	{
		var oParam = null;
		if (szNewStyle.toLowerCase () == 'createlink')
		{
			oParam = prompt ('Enter a URL (delete contents below to remove link):', 'http://');
			if (oParam != null)
			{
				if ((oParam != '') && (oParam != 'http://'))
				{
					this.GetSelection ().execCommand (szNewStyle, false, oParam);
				}
				else
				{
					this.GetSelection ().execCommand ('unlink', false, oParam);
				}
			}
		}
		else if (szNewStyle.toLowerCase () == 'html')
		{
			if (this.RawHtmlMode)
			{
				this.RawHtmlMode = false;
				this.GetFrameDocument ().body.innerHTML = this.GetHiddenField ().value;
				this.GetHiddenField ().style.display = 'none';
				this.GetFrame ().style.display = '';
				this.GetFrameDocument ().designMode = 'on';
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
			this.GetSelection ().execCommand (szNewStyle, false, "");
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.SetFontSize = function ()
{
	if (this.Activated)
	{
		var slCurrentSelection = this.GetSelection ();
		var ctlDropdown = this.GetFontSizeDropdown ();
		var szNewSizeIndex = ctlDropdown.selectedIndex;
		var szNewFontSize = ctlDropdown.options [szNewSizeIndex].value;

		slCurrentSelection.execCommand (COMMAND_NAME_FONTSIZE_RTB_OPGEEK, false, szNewFontSize);
	}

	return;
}

RichText_rtb_opgeek.prototype.SetFontName = function ()
{
	if (this.Activated)
	{
		var slCurrentSelection = this.GetSelection ();
		var ctlDropdown = this.GetFontNameDropdown ();
		var szNewFontIndex = ctlDropdown.selectedIndex;
		var szNewFontName = ctlDropdown.options [szNewFontIndex].value;

		slCurrentSelection.execCommand (COMMAND_NAME_FONTNAME_RTB_OPGEEK, false, szNewFontName);
	}

	return;
}

RichText_rtb_opgeek.prototype.SetFontColor = function ()
{
	if (this.Activated)
	{
		var slCurrentSelection = this.GetSelection ();
		var ctlDropdown = this.GetForeColorDropdown ();
		var szNewColorIndex = ctlDropdown.selectedIndex;
		var szNewColorName = ctlDropdown.options [szNewColorIndex].value;
		if (szNewColorName == 'transparent')
		{
			szNewColorName = 'inherit';
		}

		slCurrentSelection.execCommand (COMMAND_NAME_FONTCOLOR_RTB_OPGEEK, false, szNewColorName);
		ctlDropdown.style.color = szNewColorName;
	}

	return;
}

RichText_rtb_opgeek.prototype.SetBackColor = function ()
{
	if (this.Activated)
	{
		var slCurrentSelection = this.GetSelection ();
		var ctlDropdown = this.GetBackColorDropdown ();
		var szNewBackColorIndex = ctlDropdown.selectedIndex;
		var szNewBackColorName = ctlDropdown.options [szNewBackColorIndex].value;

		slCurrentSelection.execCommand (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK, false, szNewBackColorName);
		ctlDropdown.style.backgroundColor = szNewBackColorName;
	}

	return;
}

RichText_rtb_opgeek.prototype.SetState = function ()
{
	if (this.Activated)
	{
		if (bInSetState_rtb_opgeek == true)
		{
			return false;
		}
		else
		{
			bInSetState_rtb_opgeek = true;
		}

		try
		{
			this.UnstashFontData ();

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

            try
            {
    			this.Linked = slCurrentSelection.queryCommandState (COMMAND_NAME_LINK_RTB_OPGEEK);
            }
            catch (ignoredException)
            {
                this.Linked = false;
            }

			this.CurrentFontName = slCurrentSelection.queryCommandValue (COMMAND_NAME_FONTNAME_RTB_OPGEEK);
			this.CurrentFontSize = slCurrentSelection.queryCommandValue (COMMAND_NAME_FONTSIZE_RTB_OPGEEK);
			this.CurrentFontColor = slCurrentSelection.queryCommandValue (COMMAND_NAME_FONTCOLOR_RTB_OPGEEK);
			this.CurrentBackColor = slCurrentSelection.queryCommandValue (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK);

			this.CutEnabled = false;//slCurrentSelection.queryCommandEnabled (COMMAND_NAME_CUT_RTB_OPGEEK);
			this.CopyEnabled = false;//slCurrentSelection.queryCommandEnabled (COMMAND_NAME_COPY_RTB_OPGEEK);
			this.PasteEnabled = false;//slCurrentSelection.queryCommandEnabled (COMMAND_NAME_PASTE_RTB_OPGEEK);
			this.UndoEnabled = slCurrentSelection.queryCommandEnabled (COMMAND_NAME_UNDO_RTB_OPGEEK);
			this.RedoEnabled = slCurrentSelection.queryCommandEnabled (COMMAND_NAME_REDO_RTB_OPGEEK);

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

			if ((this.CurrentFontName ==  null) || (this.CurrentFontName == ''))
			{
				var elEditDocument = this.GetFrameDocument ();
				this.CurrentFontName = elEditDocument.body.style.fontFamily;
				this.SetFontDropdown (COMMAND_NAME_FONTNAME_RTB_OPGEEK, this.CurrentFontName);
				this.SetFontName ();
			}
			else
			{
				this.SetFontDropdown (COMMAND_NAME_FONTNAME_RTB_OPGEEK, this.CurrentFontName);
			}

			if ((this.CurrentFontSize ==  null) || (this.CurrentFontSize == ''))
			{
				var editDocument = this.GetFrameDocument ();
				this.CurrentFontSize = editDocument.body.style.fontSize;
				this.SetFontDropdown (COMMAND_NAME_FONTSIZE_RTB_OPGEEK, this.CurrentFontSize);
				this.SetFontSize ();
			}
			else
			{
				this.SetFontDropdown (COMMAND_NAME_FONTSIZE_RTB_OPGEEK, this.CurrentFontSize);
			}

			if ((this.CurrentFontColor ==  null) || (this.CurrentFontColor == ''))
			{
				this.CurrentFontColor = this.ForegroundColor;
				this.SetColorDropdown (COMMAND_NAME_FONTCOLOR_RTB_OPGEEK, this.CurrentFontColor, false);
				this.SetFontColor ();
			}
			else
			{
				this.SetColorDropdown (COMMAND_NAME_FONTCOLOR_RTB_OPGEEK, this.CurrentFontColor, false);
			}

			if ((this.CurrentBackColor ==  null) || (this.CurrentBackColor == ''))
			{
				this.CurrentBackColor = this.BackgroundColor;
				this.SetColorDropdown (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK, this.CurrentBackColor, true);
				this.SetBackColor ();
			}
			else
			{
				this.SetColorDropdown (COMMAND_NAME_BACKCOLOR_RTB_OPGEEK, this.CurrentBackColor, true);
			}

			bInSetState_rtb_opgeek = false;
		}
		catch (exCaughtException)
		{
			bInSetState_rtb_opgeek = false;
			alert (exCaughtException);
		}
	}

	return true;
}

RichText_rtb_opgeek.prototype.DisableButton = function (szButtonID, bEnabled)
{
	if (this.Activated)
	{
		var elDisabledButton = document.getElementById (this.Name + szButtonID + 'Disabled');
		if (bEnabled)
		{
			elDisabledButton.style.display = 'none'
		}
		else
		{
			elDisabledButton.style.display = ''
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.MungeColorCode = function (szDodgyColorCode)
{
	var szRealColorCode;
	var szCodeWithoutHash = String (szDodgyColorCode);
	if ((String (szCodeWithoutHash).charAt (0) == '#') || (szCodeWithoutHash == 'transparent'))
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

	return szRealColorCode;
}

RichText_rtb_opgeek.prototype.MungeRgbColorCode = function (szRgbCode)
{
	var szHtmlCode = 'transparent';

	var iStart = szRgbCode.indexOf ('(');
	var iEnd = szRgbCode.indexOf (')');
	var szColor = szRgbCode.substring (iStart + 1, iEnd);
	var aszColorParts = szColor.split (',');
	if (aszColorParts.length == 3)
	{
		var szRed = aszColorParts [0];
		var szGreen = aszColorParts [1];
		var szBlue = aszColorParts [2];
		var iRed = parseInt (szRed);
		var iGreen = parseInt (szGreen);
		var iBlue = parseInt (szBlue);
		if (iRed < 16)
		{
			szRed = '0' + iRed.toString (16);
		}
		else
		{
			szRed = iRed.toString (16);
		}

		if (iGreen < 16)
		{
			szGreen = '0' + iGreen.toString (16);
		}
		else
		{
			szGreen = iGreen.toString (16);
		}

		if (iBlue < 16)
		{
			szBlue = '0' + iBlue.toString (16);
		}
		else
		{
			szBlue = iBlue.toString (16);
		}

		szHtmlCode = '#' + szRed + szGreen + szBlue;
	}

	return szHtmlCode;
}

RichText_rtb_opgeek.prototype.SetColorDropdown = function (szDropdownName, szState, nSetBackground)
{
	if (this.Activated)
	{
		var control = document.getElementById (this.Name + szDropdownName);
		if (control != null)
		{
			if (szState == '')
			{
				control.options.selectedIndex = 0;
				if (nSetBackground)
				{
					control.style.backgroundColor = control.options [0].value;
				}
				else
				{
					control.style.color = control.options [0].value;
				}
			}
			else
			{
				if (szState.indexOf ('rgb') > -1)
				{
					szState = this.MungeRgbColorCode (szState);
				}
				else
				{
					szState = this.MungeColorCode (szState);
				}

				szState = szState.toUpperCase ();
				if (!nSetBackground)
				{
					//alert (szState == this.ForegroundColor);
				}

				var nDefiniteMatchAt = -1;
				var currentOption = '';
				for (var nCounter = 0; (nCounter < control.options.length) && (nDefiniteMatchAt == -1); nCounter++)
				{
					currentOption = control.options [nCounter].value;
					if (currentOption.toUpperCase () == szState)
					{
						nDefiniteMatchAt = nCounter;
					}
				}

				if (nDefiniteMatchAt != -1)
				{
					control.options.selectedIndex = nDefiniteMatchAt;
					if (nSetBackground)
					{
						control.style.backgroundColor = szState;
					}
					else
					{
						control.style.color = szState;
					}
				}
				else
				{
					var optNewValue = this.GetFrameDocument ().createElement ('OPTION', szState);
					control.options.add (optNewValue);
					control.options [control.options.length - 1].value = szState;
					control.options [control.options.length - 1].text = control.options [1].text;
				}
			}
		}
	}

	return;
}

RichText_rtb_opgeek.prototype.SetFontDropdown = function (szDropdownName, szState)
{
	if (this.Activated)
	{
		var control = document.getElementById (this.Name + szDropdownName);

		if (szState == '')
		{
			control.selectedIndex = 0;
		}
		else
		{
			var nDefiniteMatchAt = -1;

			var aszAllStates = szState.split (',');

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

	return;
}

RichText_rtb_opgeek.prototype.SetButton = function (szButtonID, bState)
{
	if (this.Activated)
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

	return;
}

RichText_rtb_opgeek.prototype.GetLeftOffset = function (objElement)
{
	var elWorkingTag = objElement;
	var nLeftOffset = 0;
	while ((elWorkingTag) && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
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
	while ((elWorkingTag) && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
	{
		nTopOffset += elWorkingTag.offsetTop;
		elWorkingTag = elWorkingTag.offsetParent;
	}

	return nTopOffset;
}

RichText_rtb_opgeek.prototype.ShowContextMenu = function (eventArgs)
{
	if (this.Activated)
	{
		hideAllContextMenus_rtb_opgeek ();
		eventArgs.preventDefault ();
		eventArgs.stopPropagation ();

		var objElement = this.GetFrame ();
		var iElementLeft = this.GetLeftOffset (objElement);
		var iElementTop = this.GetTopOffset (objElement);

		var iControlOffsetLeft = eventArgs.clientX + iElementLeft;
		var iControlOffsetTop = eventArgs.clientY + iElementTop;

		var iRemainingWidth = document.body.clientWidth - eventArgs.clientX - iElementLeft;
		var iRemainingHeight = document.body.clientHeight - eventArgs.clientY - iElementTop;

		var iMenuWidth = this.ContextMenu.GetWidth ();
		var iMenuHeight = this.ContextMenu.GetHeight ();

		var iMenuLeft = iControlOffsetLeft;
		if (iRemainingWidth < iMenuWidth)
		{
			var iLeftDiff = iMenuWidth - iRemainingWidth;
			iMenuLeft = iMenuLeft - iLeftDiff;
		}

		var iMenuTop = iControlOffsetTop;
		if (iRemainingHeight < iMenuHeight)
		{
			var iTopDiff = iMenuHeight - iRemainingHeight;
			iMenuTop = iMenuTop - iTopDiff;
		}

		this.ContextMenu.Show (iMenuLeft, iMenuTop);
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

	return;
}

ContextMenu_rtb_opgeek.prototype.Hide = function ()
{
	var mnContextMenu = this.GetContextMenuElement ();
	mnContextMenu.style.visibility = 'hidden';

	this.IsActive = false;

	return;
}

ContextMenu_rtb_opgeek.prototype.GetMenuItem = function (szItemID, szTitle)
{
	var szHTMLout = '';
	szHTMLout += HTML_TAG_OPEN_RTB_OPGEEK + 'div class=\'menuitem_rtb_opgeek\' id=\'' + this.ParentName + 'Menu' + szItemID + '\'';
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
	szMenu += 'font-family: Tahoma, sans-serif; color: black; background-color: #E0E0E0; ';
	szMenu += 'width: 150px; padding-top: 2px; padding-bottom: 2px; padding-left: 1px; padding-right: 1px; ';
	szMenu += 'border: 2px outset buttonhighlight;\'' + HTML_TAG_CLOSE_RTB_OPGEEK;

	szMenu += this.GetMenuItem (COMMAND_NAME_UNDO_RTB_OPGEEK, COMMAND_TITLE_UNDO_RTB_OPGEEK);
	szMenu += this.GetMenuItem (COMMAND_NAME_REDO_RTB_OPGEEK, COMMAND_TITLE_REDO_RTB_OPGEEK);
	szMenu += this.GetSeparator ()

//	szMenu += this.GetMenuItem (COMMAND_NAME_SELECTALL_RTB_OPGEEK, COMMAND_TITLE_SELECTALL_RTB_OPGEEK);
//	szMenu += this.GetMenuItem (COMMAND_NAME_COPY_RTB_OPGEEK, COMMAND_TITLE_COPY_RTB_OPGEEK);
//	szMenu += this.GetMenuItem (COMMAND_NAME_CUT_RTB_OPGEEK, COMMAND_TITLE_CUT_RTB_OPGEEK);
//	szMenu += this.GetMenuItem (COMMAND_NAME_PASTE_RTB_OPGEEK, COMMAND_TITLE_PASTE_RTB_OPGEEK);
//	szMenu += this.GetSeparator ()

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
