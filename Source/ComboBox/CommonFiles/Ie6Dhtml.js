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

var INITIALISATION_LAYOUT_TIMER_INTERVAL = 1;
var DROPDOWN_DOWN_ARROW_WIDTH = 18;

var allInstantiatedFieldsByTextboxId_cb_opgeek = new Array ();
var allInstantiatedFieldsByDropdownId_cb_opgeek = new Array ();
var bLibraryInitialized_cb_opgeek = false;

function runOnce_cb_opgeek
(
)
{
	if (bLibraryInitialized_cb_opgeek)
	{
		throw new Exception ('ComboBox library has already been initialized.');
	}

	bLibraryInitialized_cb_opgeek = true;

	return;
}

function initializeField_cb_opgeek
(
	txtTextbox,
	ddDropdown
)
{
	try
	{
		if (txtTextbox)
		{
			if (getInstantiatedFieldByTextboxId_cb_opgeek (txtTextbox.id) != null)
			{
				alert ('Field ' + txtTextbox.id + ' is already defined for this page.');
			}
			else
			{
				if (!bLibraryInitialized_cb_opgeek)
				{
					runOnce_cb_opgeek ();
				}

				if (txtTextbox == null)
				{
					alert ("txtTextbox cannot be null.");
					return;
				}

				if (ddDropdown == null)
				{
					alert ("ddDropdown cannot be null.");
					return;
				}

				var insCurrentInstance = new ComboBox_cb_opgeek (txtTextbox, ddDropdown);
				allInstantiatedFieldsByTextboxId_cb_opgeek [txtTextbox.id] = insCurrentInstance;
				allInstantiatedFieldsByDropdownId_cb_opgeek [ddDropdown.id] = insCurrentInstance;

				txtTextbox.onmove = layoutHandler_cb_opgeek;
				txtTextbox.onresize = layoutHandler_cb_opgeek;
				var elContainerTag = txtTextbox.offsetParent;
				while ((elContainerTag) && (elContainerTag.style.overflow != 'auto') && (elContainerTag.tagName.toUpperCase () != 'BODY'))
				{
					elContainerTag.onmove = relayoutAllComboBoxes_cb_opgeek;
					elContainerTag.onresize = relayoutAllComboBoxes_cb_opgeek;
					elContainerTag = elContainerTag.offsetParent;
				}

				ddDropdown.onblur = blurDropdownHandler_cb_opgeek;
				ddDropdown.onfocus = focusDropdownHandler_cb_opgeek;
				txtTextbox.onblur = blurTextboxHandler_cb_opgeek;
				txtTextbox.onfocus = focusTextboxHandler_cb_opgeek;
				txtTextbox.onkeyup = keyupHandler_cb_opgeek;

				insCurrentInstance.Layout ();
			}
		}
	}
	catch (exCaughtException)
	{
		handleException_cb_opgeek (exCaughtException);
	}

	return;
}

function initialiseAfterLayoutComplete_cb_opgeek
(
	szComboId
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (szComboId);
	if (insCurrentInstance.rawTextField.clientHeight > 0)
	{
		insCurrentInstance.Layout ();
	}
	else
	{
		window.setTimeout ("initialiseAfterLayoutComplete_cb_opgeek ('" + szComboId + "')", INITIALISATION_LAYOUT_TIMER_INTERVAL);
	}

	return;
}

function fireOnChangeEventSafely_cb_opgeek
(
	szComboId
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (szComboId);
	insCurrentInstance.rawDropdownField.fireEvent ('onchange');

	return;
}

function getInstantiatedFieldByTextboxId_cb_opgeek
(
	szComboName
)
{
	var insCurrentInstance = allInstantiatedFieldsByTextboxId_cb_opgeek [szComboName];
	var insReturnedInstance = null;
	if (isDefined_cb_opgeek (insCurrentInstance))
	{
		insReturnedInstance = insCurrentInstance;
	}

	return insReturnedInstance;
}

function getInstantiatedFieldByDropdownId_cb_opgeek
(
	szComboName
)
{
	var insCurrentInstance = allInstantiatedFieldsByDropdownId_cb_opgeek [szComboName];
	var insReturnedInstance = null;
	if (isDefined_cb_opgeek (insCurrentInstance))
	{
		insReturnedInstance = insCurrentInstance;
	}

	return insReturnedInstance;
}

function ieTimingBug840545Workaround_cb_opgeek
(
	szDoPostBackCall
)
{
	setTimeout (szDoPostBackCall, 1);

	return;
}

function layoutHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (event.srcElement.id);
	return insCurrentInstance.Layout ();
}

function relayoutAllComboBoxes_cb_opgeek
(
	eventArgs
)
{
	for (each in allInstantiatedFieldsByTextboxId_cb_opgeek)
	{
		allInstantiatedFieldsByTextboxId_cb_opgeek [each].Layout ();
	}

	return;
}

function blurDropdownHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByDropdownId_cb_opgeek (event.srcElement.id);
	return insCurrentInstance.BlurDropdown ();
}

function focusDropdownHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByDropdownId_cb_opgeek (event.srcElement.id);
	return insCurrentInstance.FocusDropdown ();
}

function blurTextboxHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (event.srcElement.id);
	return insCurrentInstance.BlurTextbox ();
}

function focusTextboxHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (event.srcElement.id);
	return insCurrentInstance.FocusTextbox ();
}

function dropdownChangeHandler_cb_opgeek
(
	szComboId
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (szComboId);
	var nReturnedValue = false;
	if (insCurrentInstance != null)
	{
		nReturnedValue = insCurrentInstance.DropdownChange ();
	}

	return nReturnedValue;
}

function keyupHandler_cb_opgeek
(
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (event.srcElement.id);
	return insCurrentInstance.Keyup (event);
}

function getLeftOffset_cb_opgeek
(
	objElement
)
{
	var elWorkingTag = objElement;
	var nLeftOffset = 0;
	if ((elWorkingTag) && (elWorkingTag.style.position == 'absolute'))
	{
		nLeftOffset += elWorkingTag.offsetLeft;
	}
	else
	{
		while ((elWorkingTag) && (elWorkingTag.style.overflow != 'auto') && (elWorkingTag.style.position != 'absolute') && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
		{
			nLeftOffset += elWorkingTag.offsetLeft;
			elWorkingTag = elWorkingTag.offsetParent;
		}
	}

	return nLeftOffset;
}

function getTopOffset_cb_opgeek
(
	objElement
)
{
	var elWorkingTag = objElement;
	var nTopOffset = 0;
	if ((elWorkingTag) && (elWorkingTag.style.position == 'absolute'))
	{
		nTopOffset = elWorkingTag.offsetTop;
	}
	else
	{
		while ((elWorkingTag) && (elWorkingTag.style.overflow != 'auto') && (elWorkingTag.style.position != 'absolute') && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
		{
			nTopOffset += elWorkingTag.offsetTop;
			elWorkingTag = elWorkingTag.offsetParent;
		}
	}

   return nTopOffset;
}

function isDefined_cb_opgeek
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

function handleException_cb_opgeek
(
	exCaughtException
)
{
	alert ('Caught: ' + exCaughtException.description);

	return;
}

//==========================================================
// This is where we define our ComboBox object.
//==========================================================

function ComboBox_cb_opgeek
(
	txtTextField,
	ddDropDownField
)
{
	this.id = txtTextField.id;
	this.rawTextField = txtTextField;
	this.rawDropdownField = ddDropDownField;

	this.indexToAddAt = this.rawDropdownField.children.length;

	this.textboxShrunk = false;
	this.userEdited = false;
	this.addedChild = null;
	this.enteredText = "";
	this.isDropdownFocused = false;

	this.DropdownChange ();

	return;
}

ComboBox_cb_opgeek.prototype.GetUserEditedChild = function ()
{
	var child = this.rawDropdownField.children [this.indexToAddAt];
	if (!child)
	{
		child = document.createElement ("OPTION");
		this.rawDropdownField.options.add (child);
	}

	return child;
}

ComboBox_cb_opgeek.prototype.UpdateChild = function ()
{
	this.GetUserEditedChild ().value = this.rawTextField.value;
	this.GetUserEditedChild ().text = this.rawTextField.value;
	this.GetUserEditedChild ().selected = true;

	return;
}

ComboBox_cb_opgeek.prototype.ClearChild = function ()
{
	this.rawDropdownField.removeChild (this.GetUserEditedChild ());

	return;
}

ComboBox_cb_opgeek.prototype.BlurDropdown = function ()
{
	this.isDropdownFocused = false;

	return true;
}

ComboBox_cb_opgeek.prototype.FocusDropdown = function ()
{
	this.isDropdownFocused = true;

	return true;
}

ComboBox_cb_opgeek.prototype.BlurTextbox = function ()
{
	if (this.userEdited)
	{
		window.setTimeout ("fireOnChangeEventSafely_cb_opgeek ('" + this.id + "')", 10);
		this.rawDropdownField.setActive ();
	}

	return true;
}

ComboBox_cb_opgeek.prototype.FocusTextbox = function ()
{
	this.rawTextField.select ();

	return true;
}

ComboBox_cb_opgeek.prototype.DropdownChange = function ()
{
	var iSelectedIndex = this.rawDropdownField.selectedIndex;
	if (iSelectedIndex >= 0)
	{
		var optSelectedChild = this.rawDropdownField.children [iSelectedIndex];
		this.rawTextField.value = optSelectedChild.text;
	}

	return;
}

ComboBox_cb_opgeek.prototype.Layout = function ()
{
	if (this.rawTextField.offsetWidth > 0)
	{
		var controlWidth = this.rawTextField.offsetWidth;

		// Shrink the textbox so there's room for our dropdown arrow.
		if (!this.textboxShrunk)
		{
			this.rawTextField.style.width = (controlWidth - DROPDOWN_DOWN_ARROW_WIDTH) + 'px';
			this.textboxShrunk = true;
		}

		this.rawDropdownField.style.width = (controlWidth) + 'px';

		// Set the bounding box to be the right width.
		this.rawTextField.offsetParent.style.width = (controlWidth + DROPDOWN_DOWN_ARROW_WIDTH) + 'px';

		this.rawDropdownField.style.display = '';
		if (this.rawTextField.style.position != 'absolute')
		{
			this.rawDropdownField.style.marginTop = '1px';
		}

		var szClippingRegion = 'rect (auto auto auto ' + (this.rawDropdownField.clientWidth - DROPDOWN_DOWN_ARROW_WIDTH - 1) + ')';
		this.rawDropdownField.style.overflow = 'hidden';
		this.rawDropdownField.style.clip = szClippingRegion;
	}
	else
	{
		window.setTimeout ("initialiseAfterLayoutComplete_cb_opgeek ('" + this.id + "')", INITIALISATION_LAYOUT_TIMER_INTERVAL);
	}

	return;
}

ComboBox_cb_opgeek.prototype.Keyup = function (eventArgs)
{
	this.enteredText = this.rawTextField.value;

	if (eventArgs.keyCode == 38)
	{
		this.SetIndex (this.rawDropdownField.selectedIndex - 1);
	}
	else if (eventArgs.keyCode == 40)
	{
		this.SetIndex (this.rawDropdownField.selectedIndex + 1);
	}
	else if (eventArgs.keyCode == 36) // Home
	{
		var trSelection = this.rawTextField.createTextRange ();
		trSelection.moveStart ("character", 0);
		trSelection.length = 0;
	}
	else if (
		(eventArgs.keyCode == 9)      // Tab
		|| (eventArgs.keyCode == 16)  // Shift
		|| (eventArgs.keyCode == 17)  // Control
		|| (eventArgs.keyCode == 17)  // Alt
		|| (eventArgs.keyCode == 35)  // End
		|| (eventArgs.keyCode == 37)  // Left
		|| (eventArgs.keyCode == 39)) // Right
	{
		// Ignore these keyups.
	}
	else
	{
		if (this.enteredText.length > 0)
		{
			var nFoundOption = false;
			var szNormalisedEnteredText = String (this.enteredText).toUpperCase ();
			var szCurrentOptionValue = String (this.rawDropdownField.children [this.rawDropdownField.selectedIndex].text);
			var szCurrentOptionSubstring = szCurrentOptionValue.substring (0, szNormalisedEnteredText.length);
			var iNumberOfOptions = this.rawDropdownField.children.length;
			for (iOptionCounter = 0; (iOptionCounter < iNumberOfOptions) && (nFoundOption == false); iOptionCounter++)
			{
				var szOptionValue = String (this.rawDropdownField.children [iOptionCounter].text);
				var szOptionSubstring = szOptionValue.substring (0, szNormalisedEnteredText.length);
				var szNormalisedOptionSubstring = szOptionSubstring.toUpperCase ();
				if ((szNormalisedEnteredText == szNormalisedOptionSubstring)
					&& (iOptionCounter != this.indexToAddAt))
				{
					this.rawDropdownField.selectedIndex = iOptionCounter;
					nFoundOption = true;
				}
			}

			if ((nFoundOption == true) && (eventArgs.keyCode != 46) && (eventArgs.keyCode != 8))
			{
				this.ClearChild ();
				this.userEdited = true;
				var iSelectedIndex = this.rawDropdownField.selectedIndex;
				var optSelectedChild = this.rawDropdownField.children [iSelectedIndex];
				if (this.rawTextField.value != optSelectedChild.text)
				{
					this.rawTextField.value = optSelectedChild.text;
				}
				var trSelection = this.rawTextField.createTextRange ();
				trSelection.moveStart ("character", this.enteredText.length);
				trSelection.select ();
			}
			else
			{
				this.UpdateChild ();
			}
		}
	}

	return true;
}

ComboBox_cb_opgeek.prototype.SetIndex = function (iIndexToSet)
{
	if ((iIndexToSet >= 0) && (iIndexToSet < this.rawDropdownField.children.length))
	{
		this.rawDropdownField.selectedIndex = iIndexToSet;
		var optSelectedChild = this.rawDropdownField.children [iIndexToSet];
		this.rawTextField.value = optSelectedChild.text;
		var trSelection = this.rawTextField.createTextRange ();
		trSelection.select ();
	}

	return;
}
