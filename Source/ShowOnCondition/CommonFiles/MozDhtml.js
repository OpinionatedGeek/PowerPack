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

var allInstantiatedHideIfFields_hi_opgeek = new Array ();

var bLibraryInitialized_hi_opgeek = false;
function runOnce_hi_opgeek
(
)
{
	if (bLibraryInitialized_hi_opgeek)
	{
		throw new Exception ('HideIf library has already been initialized.');
	}

	bLibraryInitialized_hi_opgeek = true;

	return;
}

function initialize_hi_opgeek
(
	szInstanceName,
	szControlToCheckId,
	szControlToHideId,
	szHideIfValue,
	szHideIfNotValue
)
{
	if (!bLibraryInitialized_hi_opgeek)
	{
		runOnce_hi_opgeek ();
	}

	if (isDefined_hi_opgeek (allInstantiatedHideIfFields_hi_opgeek [szInstanceName]))
	{
		alert ('Field ' + strInstanceName + ' is already defined for this page.');
	}
	else
	{
		var insCurrentInstance = new HideIf_hi_opgeek (szInstanceName, szControlToCheckId, szControlToHideId, szHideIfValue, szHideIfNotValue);
		allInstantiatedHideIfFields_hi_opgeek [szInstanceName] = insCurrentInstance;
		checkAllHideIfs_hi_opgeek ();
	}

	return;
}

function checkAllHideIfs_hi_opgeek
(
)
{
	for (each in allInstantiatedHideIfFields_hi_opgeek)
	{
		if (isDefined_hi_opgeek (each))
		{
			allInstantiatedHideIfFields_hi_opgeek [each].Check ();
		}
	}

	return;
}

function getHandlerForEvent_hi_opgeek
(
	ehExistingHandler
)
{
	var ehCompleteHandler;
	try
	{
		if ((isDefined_hi_opgeek (ehExistingHandler)) && (typeof (ehExistingHandler) == "function"))
		{
			var szHandlerCode = ehExistingHandler.toString ();
			szHandlerCode = szHandlerCode.substring (szHandlerCode.indexOf ("{") + 1, szHandlerCode.lastIndexOf ("}"));
			ehCompleteHandler = new Function ("checkAllHideIfs_hi_opgeek (); " + szHandlerCode);
		}
		else
		{
			ehCompleteHandler = checkAllHideIfs_hi_opgeek;
		}
	}
	catch (exCaughtException)
	{
		handleException_hi_opgeek (exCaughtException);
	}

	return ehCompleteHandler;
}

function hookUpControl_hi_opgeek
(
	ctlControlToCheck
)
{
	if (ctlControlToCheck.type == "radio")
	{
		ctlControlToCheck.onclick = getHandlerForEvent_hi_opgeek (ctlControlToCheck.onclick);
	}
	else
	{
		ctlControlToCheck.onchange = getHandlerForEvent_hi_opgeek (ctlControlToCheck.onchange);
	}

    for (var iChildCounter = 0; iChildCounter < ctlControlToCheck.childNodes.length; iChildCounter++)
    {
		hookUpControl_hi_opgeek (ctlControlToCheck.childNodes [iChildCounter]);
    }

	return;
}

function isDefined_hi_opgeek
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

function handleException_hi_opgeek
(
	exCaughtException
)
{
	alert ('Caught: ' + exCaughtException.description);

	return;
}

//======================================================================
// HideIf object
//======================================================================

function HideIf_hi_opgeek
(
	szInstanceName,
	szControlToCheckId,
	szControlToHideId,
	szHideIfValue,
	szHideIfNotValue
)
{
	this.InstanceName = szInstanceName;
	this.ControlToCheckId = szControlToCheckId;
	this.ControlToHideId = szControlToHideId;
	this.HideIfValue = szHideIfValue;
	this.HideIfNotValue = szHideIfNotValue;

	this.WeHidThisControl = false;

	this.DisplaySetting = 'block';

	var ctlControlToCheck = document.getElementById (this.ControlToCheckId);
	hookUpControl_hi_opgeek (ctlControlToCheck);

	return;
}

HideIf_hi_opgeek.prototype.Check = function ()
{
	if ((isDefined_hi_opgeek (this.HideIfValue)) && (this.HideIfValue != "OpGeek_Unset"))
	{
		var ctlControlToCheck = document.getElementById (this.ControlToCheckId);
		var ctlControlToHide = document.getElementById (this.ControlToHideId);
		if ((isDefined_hi_opgeek (ctlControlToCheck)) && (isDefined_hi_opgeek (ctlControlToHide)))
		{
			if (this.GetValue (ctlControlToCheck) == this.HideIfValue)
			{
				this.HideControl (ctlControlToHide);
			}
			else if (this.WeHidThisControl)
			{
				this.ShowControl (ctlControlToHide);
			}
		}
	}
	else if ((isDefined_hi_opgeek (this.HideIfNotValue)) && (this.HideIfNotValue != "OpGeek_Unset"))
	{
		var ctlControlToCheck = document.getElementById (this.ControlToCheckId);
		var ctlControlToHide = document.getElementById (this.ControlToHideId);
		if ((isDefined_hi_opgeek (ctlControlToCheck)) && (isDefined_hi_opgeek (ctlControlToHide)))
		{
			if (this.GetValue (ctlControlToCheck) != this.HideIfNotValue)
			{
				this.HideControl (ctlControlToHide);
			}
			else if (this.WeHidThisControl)
			{
				this.ShowControl (ctlControlToHide);
			}
		}
	}

	return;
}

HideIf_hi_opgeek.prototype.GetValue = function (ctlCurrent)
{
	var szValue = "";

	if (typeof (ctlCurrent.value) == "string" && this.AreWeFieldOrSelected (ctlCurrent))
	{
		szValue = ctlCurrent.value;
	}
	else
	{
		var szTemporaryValue;
		for (var iChildCounter = 0; iChildCounter < ctlCurrent.childNodes.length; iChildCounter++)
		{
			szTemporaryValue = this.GetValue (ctlCurrent.childNodes [iChildCounter]);
			if (szTemporaryValue != "")
			{
				szValue = szTemporaryValue;
				iChildCounter = ctlCurrent.childNodes.length;
			}
		}
	}

	return szValue;
}

HideIf_hi_opgeek.prototype.ShowControl = function (ctlControlToShow)
{
	ctlControlToShow.style.display = this.DisplaySetting;
	this.WeHidThisControl = false;

	return;
}

HideIf_hi_opgeek.prototype.HideControl = function (ctlControlToHide)
{
	ctlControlToHide.style.display = 'none';
	this.WeHidThisControl = true;

	return;
}

HideIf_hi_opgeek.prototype.AreWeFieldOrSelected = function (ctlCurrent)
{
	var bWeAre = false;
	if ((ctlCurrent.type != "radio") || (ctlCurrent.checked == true))
	{
		bWeAre = true;
	}

	return bWeAre;
}
