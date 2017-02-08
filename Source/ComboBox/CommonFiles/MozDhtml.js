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

var allInstantiatedFieldsByTextboxId_cb_opgeek = new Array ();
var allInstantiatedFieldsByDropdownId_cb_opgeek = new Array ();
var bLibraryInitialized_cb_opgeek = false;

var DROPDOWN_DOWN_ARROW_WIDTH = 18;

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
					alert ('txtTextbox cannot be null.');
					return;
				}

				if (ddDropdown == null)
				{
					alert ('ddDropdown for ' + txtTextbox.name + ' cannot be null.');
					return;
				}

				var insCurrentInstance = new ComboBox_cb_opgeek (txtTextbox, ddDropdown);
				allInstantiatedFieldsByTextboxId_cb_opgeek [txtTextbox.id] = insCurrentInstance;
				allInstantiatedFieldsByDropdownId_cb_opgeek [ddDropdown.id] = insCurrentInstance;

				ddDropdown.onblur = blurDropdownHandler_cb_opgeek;
				ddDropdown.onfocus = focusDropdownHandler_cb_opgeek;
				txtTextbox.onblur = blurTextboxHandler_cb_opgeek;
				txtTextbox.onfocus = focusTextboxHandler_cb_opgeek;
				txtTextbox.onkeyup = keyupHandler_cb_opgeek;
				//var controlWidth = txtTextbox.style.width.replace (/px/gi, '');
				var controlWidth = txtTextbox.offsetWidth;
				ddDropdown.style.width = controlWidth;
				ddDropdown.style.height = (txtTextbox.offsetHeight - 2) + 'px';
				ddDropdown.style.display = '';

				// Set the bounding box to be the right width.
				var boundingBox = txtTextbox.offsetParent;
				if (!boundingBox)
				{
					boundingBox = txtTextbox.parentNode;
				}
				boundingBox.style.width = controlWidth;

				// Now shrink the textbox so there's room for our dropdown arrow.
				txtTextbox.style.width = (controlWidth - DROPDOWN_DOWN_ARROW_WIDTH) + 'px';

				var txtZIndex = 0;
				if (txtTextbox.style.zIndex)
				{
					txtZIndex = txtTextbox.style.zIndex;
				}
				ddDropdown.style.zIndex = txtZIndex + 1;

				var szDropDownClippingRegion = 'rect(auto, auto, auto, ' + (controlWidth - DROPDOWN_DOWN_ARROW_WIDTH - 1) + 'px)';
				ddDropdown.style.clip = szDropDownClippingRegion;
			}
		}
	}
	catch (exCaughtException)
	{
		handleException_cb_opgeek (exCaughtException);
	}

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

function blurDropdownHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByDropdownId_cb_opgeek (eventArgs.target.id);
	return insCurrentInstance.BlurDropdown ();
}

function focusDropdownHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByDropdownId_cb_opgeek (eventArgs.target.id);
	return insCurrentInstance.FocusDropdown ();
}

function blurTextboxHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (eventArgs.target.id);
	return insCurrentInstance.BlurTextbox ();
}

function focusTextboxHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (eventArgs.target.id);
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

function fireOnChangeEventSafely_cb_opgeek
(
	szTextboxId
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (szTextboxId);
	if (!insCurrentInstance.isDropdownFocused)
	{
		try
		{
			var changeEvent = document.createEvent ('Events');
			changeEvent.initEvent ('change', true, true);
			insCurrentInstance.rawDropdownField.dispatchEvent (changeEvent)
		}
		catch (exCaughtException)
		{
			alert (exCaughtException);
		}

	}

	return;
}

function keyupHandler_cb_opgeek
(
	eventArgs
)
{
	var insCurrentInstance = getInstantiatedFieldByTextboxId_cb_opgeek (eventArgs.target.id);
	return insCurrentInstance.Keyup (eventArgs);
}

function getLeftOffset_cb_opgeek
(
	objElement
)
{
	var elWorkingTag = objElement;
	var iLeftOffset = 0;
	while ((elWorkingTag) && (elWorkingTag.style.position != 'absolute') && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
	{
		iLeftOffset += elWorkingTag.offsetLeft;
		elWorkingTag = elWorkingTag.offsetParent;
	}

	return iLeftOffset;
}

function getTopOffset_cb_opgeek
(
	objElement
)
{
	var elWorkingTag = objElement;
	var iTopOffset = 0;
	while ((elWorkingTag) && (elWorkingTag.style.position != 'absolute') && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
	{
		iTopOffset += elWorkingTag.offsetTop;
		elWorkingTag = elWorkingTag.offsetParent;
	}

	return iTopOffset;
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
	alert ('Caught: ' + exCaughtException);

	return;
}

//==========================================================
// This is where we define our ComboBox object.
//==========================================================

function ComboBox_cb_opgeek
(
	txtTextboxField,
	ddDropDownField
)
{
	this.id = txtTextboxField.id;
	this.rawTextField = txtTextboxField;
	this.rawDropdownField = ddDropDownField;

	this.indexToAddAt = this.rawDropdownField.options.length;

	this.addedChild = null;
	this.enteredText = "";
	this.isDropdownFocused = false;

	this.DropdownChange ();

	return;
}

ComboBox_cb_opgeek.prototype.GetUserEditedChild = function ()
{
	var child = this.rawDropdownField.options [this.indexToAddAt];
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
	this.rawDropdownField.needsblur = false;
	if (this.textValueWhenFocused != this.rawTextField.value)
	{
		window.setTimeout ("fireOnChangeEventSafely_cb_opgeek ('" + this.rawTextField.id + "')", 100);
	}

	return true;
}

ComboBox_cb_opgeek.prototype.FocusTextbox = function ()
{
	this.rawDropdownField.needsblur = true;
	this.textValueWhenFocused = this.rawTextField.value;

	this.rawTextField.select ();

	return true;
}

ComboBox_cb_opgeek.prototype.DropdownChange = function ()
{
	var iSelectedIndex = this.rawDropdownField.selectedIndex;
	if (iSelectedIndex >= 0)
	{
		var optSelectedChild = null;
		if (this.rawDropdownField.options)
		{
			// Firefox 1.5
			optSelectedChild = this.rawDropdownField.options [iSelectedIndex];
		}
		else
		{
			// Older Moz
			optSelectedChild = this.rawDropdownField.options [iSelectedIndex];
		}
		this.rawTextField.value = optSelectedChild.text;
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
		var szNormalisedEnteredText = String (this.enteredText).toUpperCase ();
		var nFoundOption = false;
		var szCurrentOptionValue = String (this.rawDropdownField.options [this.rawDropdownField.selectedIndex].text);
		var szCurrentOptionSubstring = szCurrentOptionValue.substring (0, szNormalisedEnteredText.length);
		var iNumberOfOptions = this.rawDropdownField.options.length;
		for (iOptionCounter = 0; (iOptionCounter < iNumberOfOptions) && (nFoundOption == false); iOptionCounter++)
		{
			var szOptionValue = String (this.rawDropdownField.options [iOptionCounter].text);
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
			var iSelectedIndex = this.rawDropdownField.selectedIndex;
			var optSelectedChild = this.rawDropdownField.options [iSelectedIndex];
			if (this.rawTextField.value != optSelectedChild.text)
			{
				this.rawTextField.value = optSelectedChild.text;
			}
			this.rawTextField.setSelectionRange (this.enteredText.length, optSelectedChild.text.length);
		}
		else
		{
			this.UpdateChild ();
		}
	}

	return true;
}

ComboBox_cb_opgeek.prototype.SetIndex = function (iIndexToSet)
{
	if ((iIndexToSet >= 0) && (iIndexToSet < this.rawDropdownField.options.length))
	{
		this.rawDropdownField.selectedIndex = iIndexToSet;
		var optSelectedChild = this.rawDropdownField.options [iIndexToSet];
		this.rawTextField.value = optSelectedChild.text;
		this.rawTextField.setSelectionRange (0, optSelectedChild.text.length);
	}

	return;
}
