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

var POPUP_HEIGHT_DP_OPGEEK = 155;
var POPUP_WIDTH_DP_OPGEEK = 185;
var BUTTON_HEIGHT_DP_OPGEEK = 22;
var BUTTON_WIDTH_DP_OPGEEK = 22;

var HTML_TAG_OPEN_DP_OPGEEK = String.fromCharCode (0x3C);
var HTML_TAG_CLOSE_DP_OPGEEK = String.fromCharCode (0x3E);
var QUOTE_MARK_DP_OPGEEK = String.fromCharCode (0x22);;

var POPUP_FONT_STYLES_DP_OPGEEK = 'font-family: Tahoma, sans-serif; font-size: 8pt; font-weight: normal;';
var MONTH_FORWARDBACK_STYLES_DP_OPGEEK = 'font-weight: bold; font-size: 10pt; font-family: Arial, sans-serif;';

var astrMonthNames_dp_opgeek = new Array   ('January',
											'February',
											'March',
											'April',
											'May',
											'June',
											'July',
											'August',
											'September',
											'October',
											'November',
											'December');

var astrMonthNamesAbbrev_dp_opgeek = new Array	('Jan',
												'Feb',
												'Mar',
												'Apr',
												'May',
												'Jun',
												'Jul',
												'Aug',
												'Sep',
												'Oct',
												'Nov',
												'Dec');

var astrDayNames_dp_opgeek = new Array ('Sunday',
										'Monday',
										'Tuesday',
										'Wednesday',
										'Thursday',
										'Friday',
										'Saturday');

var astrDayNamesAbbrev_dp_opgeek = new Array	('Sun',
												'Mon',
												'Tue',
												'Wed',
												'Thu',
												'Fri',
												'Sat');

var anDaysInMonth_dp_opgeek = new Array    (31,
											28,
											31,
											30,
											31,
											30,
											31,
											31,
											30,
											31,
											30,
											31);

var allInstantiatedDatePickerFields_dp_opgeek = new Array ();

var aobjHiddenSelects_dp_opgeek = new Array ();
var aobjHiddenObjects_dp_opgeek = new Array ();

var bLibraryInitialized_dp_opgeek = false;
function runOnce_dp_opgeek
(
)
{
	bLibraryInitialized_dp_opgeek = true;

	return;
}

function initialize_dp_opgeek
(
	strInstanceName,
	strInitialValue,
	bExtruded,
	strDisplayFormat,
	nFirstYear,
	nLastYear
)
{
	if (!bLibraryInitialized_dp_opgeek)
	{
		runOnce_dp_opgeek ();
	}

	if (isDefined_dp_opgeek (allInstantiatedDatePickerFields_dp_opgeek [strInstanceName]))
	{
		alert ('Field ' + strInstanceName + ' is already defined for this page.');
	}
	else
	{
		var insCurrentInstance = new DatePicker_dp_opgeek (strInstanceName, strInitialValue, bExtruded, strDisplayFormat, nFirstYear, nLastYear);
		allInstantiatedDatePickerFields_dp_opgeek [strInstanceName] = insCurrentInstance;
	}

	return;
}

function hideDatePicker_dp_opgeek
(
	strInstanceName
)
{
	var insCurrentInstance = allInstantiatedDatePickerFields_dp_opgeek [strInstanceName];
	insCurrentInstance.Hide ();

	return;
}

function hideAllDatePickers_dp_opgeek
(
)
{
	for (each in allInstantiatedDatePickerFields_dp_opgeek)
	{
		if (isDefined_dp_opgeek (each))
		{
			allInstantiatedDatePickerFields_dp_opgeek [each].Hide ();
		}
	}

	return;
}

function preventEditing_dp_opgeek
(
	evnt
)
{
	evnt.target.blur ();

	return;
}

var strElementToIgnoreId = "";
function ignore_dp_opgeek
(
	evnt
)
{
	strElementToIgnoreId = evnt.target.id;

	return false;
}

var nBlurCount = 0;
function onBlur_dp_opgeek
(
	evnt
)
{
	if ((!isDefined_dp_opgeek (evnt)) || (evnt.target.id != strElementToIgnoreId))
	{
		nBlurCount++;
		if (nBlurCount > 1)
		{
			hideAllDatePickers_dp_opgeek ();
		}
	}

	return false;
}

var objHiddenOnclickHandler_dp_opgeek = null;
var objHiddenOncontextmenuHandler_dp_opgeek = null;
var objHiddenOncontrolselectHandler_dp_opgeek = null;
var objHiddenOnkeydownHandler_dp_opgeek = null;
var objHiddenOnselectionchangeHandler_dp_opgeek = null;
function trapEvents_dp_opgeek
(
)
{
	objHiddenOnclickHandler_dp_opgeek = document.onclick;
	document.onclick = onBlur_dp_opgeek;

	objHiddenOncontextmenuHandler_dp_opgeek = document.oncontextmenu;
	document.oncontextmenu = onBlur_dp_opgeek;

	objHiddenOncontrolselectHandler_dp_opgeek = document.oncontrolselect;
	document.oncontrolselect = onBlur_dp_opgeek;

	objHiddenOnkeydownHandler_dp_opgeek = document.onkeydown;
	document.onkeydown = onBlur_dp_opgeek;

	objHiddenOnselectionchangeHandler_dp_opgeek = document.onselectionchange;
	document.onselectionchange = onBlur_dp_opgeek;

	nBlurCount = 0;

	return;
}

function untrapEvents_dp_opgeek
(
)
{
	document.onclick = objHiddenOnclickHandler_dp_opgeek;
	objHiddenOnclickHandler_dp_opgeek = null;

	document.oncontextmenu = objHiddenOncontextmenuHandler_dp_opgeek;
	objHiddenOncontextmenuHandler_dp_opgeek = null;

	document.oncontrolselect = objHiddenOncontrolselectHandler_dp_opgeek;
	objHiddenOncontrolselectHandler_dp_opgeek = null;

	document.onkeydown = objHiddenOnkeydownHandler_dp_opgeek;
	objHiddenOnkeydownHandler_dp_opgeek = null;

	document.onselectionchange = objHiddenOnselectionchangeHandler_dp_opgeek;
	objHiddenOnselectionchangeHandler_dp_opgeek = null;

	return;
}

function onButtonClick_dp_opgeek
(
	strInstanceName,
	objButtonImage
)
{
	var insCurrentInstance = allInstantiatedDatePickerFields_dp_opgeek [strInstanceName];
	if (!insCurrentInstance.PopupCurrentlyDisplayed)
	{
		hideAllDatePickers_dp_opgeek ();
		insCurrentInstance.SetButtonX (objButtonImage.x);
		insCurrentInstance.SetButtonY (objButtonImage.y);
		insCurrentInstance.Show ();
	}
	else
	{
		hideAllDatePickers_dp_opgeek ();
	}

	return;
}

function selectDate_dp_opgeek
(
	strName,
	nDay,
	nMonth,
	nYear
)
{
	var dtSelectedDate = new Date ();
	dtSelectedDate.setYear (nYear);
	dtSelectedDate.setMonth (nMonth);
	dtSelectedDate.setDate (nDay);

	var insCurrentInstance = allInstantiatedDatePickerFields_dp_opgeek [strName];
	insCurrentInstance.SetDate (dtSelectedDate);

	hideDatePicker_dp_opgeek (strName);
	return;
}

function monthChange_dp_opgeek
(
	strName,
	nYear
)
{
	var objSelect = document.getElementById (strName + '_month_select');
	switchToMonth_dp_opgeek (strName, objSelect.value, nYear);

	return true;
}

function yearChange_dp_opgeek
(
	strName,
	nMonth
)
{
	var objSelect = document.getElementById (strName + '_year_select');
	switchToMonth_dp_opgeek (strName, nMonth, objSelect.value);

	return true;
}

function switchToMonth_dp_opgeek
(
	strName,
	nMonth,
	nYear
)
{
	var dtNewMonth = new Date ();
	dtNewMonth.setDate (1);
	dtNewMonth.setMonth (nMonth);
	dtNewMonth.setYear (nYear);
	nYear = dtNewMonth.getFullYear ();
	nMonth = dtNewMonth.getMonth ();

	var insCurrentInstance = allInstantiatedDatePickerFields_dp_opgeek [strName];
	if (nYear > insCurrentInstance.GetLastYear ())
	{
		nYear = insCurrentInstance.GetLastYear ();
		dtNewMonth.setYear (nYear);
	}
	else if (nYear < insCurrentInstance.GetFirstYear ())
	{
		nYear = insCurrentInstance.GetFirstYear ();
		dtNewMonth.setYear (nYear);
	}

	displayDatePicker_dp_opgeek (strName, dtNewMonth, insCurrentInstance.GetDate (), insCurrentInstance.GetExtruded (), insCurrentInstance.GetFirstYear (), insCurrentInstance.GetLastYear ());

	return;
}

function displayDatePicker_dp_opgeek
(
	strName,
	dtDateToUse,
	dtActiveDate,
	bExtruded,
	nFirstYear,
	nLastYear
)
{
	var elCurrentCal = getCalendarLayer_dp_opgeek (strName);
	elCurrentCal.visibility = 'show';

	var dpNewCalendar = new DatePickerPopup_dp_opgeek (strName, dtDateToUse, dtActiveDate, nFirstYear, nLastYear);
	dpNewCalendar.SetExtruded (bExtruded);

	var strCalendar = dpNewCalendar.GetCalendarPopup ();
	elCurrentCal.document.open ();
	elCurrentCal.document.write (strCalendar);
	elCurrentCal.document.close ();

	return;
}

function getLeftOffset_dp_opgeek
(
	srcTag
)
{
	var nLeftOffset = srcTag.left;
	if (!isDefined_dp_opgeek (nLeftOffset))
	{
		nLeftOffset = 0;
	}

    return nLeftOffset;
}

function getTopOffset_dp_opgeek
(
	srcTag
)
{
	var nTopOffset = srcTag.top;
	if (!isDefined_dp_opgeek (nTopOffset))
	{
		nTopOffset = 0;
	}

    return nTopOffset;
}

function isDefined_dp_opgeek
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

function getCalendarLayer_dp_opgeek
(
	strName
)
{
	var elCurrentCal = document.layers [strName + 'DatePicker_dp_opgeek'];
	if (!isDefined_dp_opgeek (elCurrentCal))
	{
		document.layers [strName + 'DatePicker_dp_opgeek'] = new Layer (200);
		elCurrentCal = document.layers [strName + 'DatePicker_dp_opgeek'];
		elCurrentCal.left = 50;
		elCurrentCal.top = 50;
		elCurrentCal.visibility = 'show';
		elCurrentCal.zIndex = 100;
	}

	return elCurrentCal;
}

var bSomeElementsHidden_dp_opgeek = false;
function hideProblematicElements_dp_opgeek
(
	objMaskingObject,
	strElementName,
	aHiddenElements
)
{
	var nMenuLeft = parseInt (objMaskingObject.left);
	var nMenuRight = nMenuLeft + parseInt (objMaskingObject.clientWidth);
	var nMenuTop = parseInt (objMaskingObject.top);
	var nMenuBottom = nMenuTop + parseInt (objMaskingObject.clientHeight);

	aHiddenElements.length = 0

	var objElement;
	var objElementParent;
	var nElementLeft;
	var nElementRight;
	var nElementTop;
	var nElementBottom;
	for (nCounter = 0; nCounter < document.tags [strElementName].length; nCounter++)
	{
		objElement = document.tags [strElementName] [nCounter];
		if (!objElement || !objElement.offsetParent)
		{
			continue;
		}

		nElementLeft = objElement.offsetLeft;
		nElementTop = objElement.offsetTop;
		objElementParent = objElement.offsetParent;

		while (objElementParent.tagName.toUpperCase() != 'BODY')
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

	bSomeElementsHidden_dp_opgeek = true;

	return;
}

function showProblematicElements_dp_opgeek
(
	aHiddenElements
)
{
	for (var nCounter = 0; nCounter < aHiddenElements.length; nCounter++)
	{
		document.all [aHiddenElements [nCounter]].style.visibility = 'visible';
	}

	return;
}

//======================================================================
// DatePicker_dp_opgeek object
//======================================================================
function DatePicker_dp_opgeek
(
	strInstanceName,
	strInitialValue,
	bExtruded,
	strDisplayFormat,
	nFirstYear,
	nLastYear
)
{
	this.DisplayFormat = strDisplayFormat;
	this.PopupCurrentlyDisplayed = false;

	this.SetName (strInstanceName);
	this.SetExtruded (bExtruded);
	this.SetFormID (this.FindFormID (strInstanceName));
	this.SetFirstYear (nFirstYear);
	this.SetLastYear (nLastYear);

	var elRealField = eval ('document.forms [' + this.GetFormID () + '].' + this.GetName ());
	if (elRealField.value != '')
	{
		this.SetDate (Date.GetDateFromODBCNormalizedForm (strInitialValue));
	}

	var elInputBox = eval ('document.forms [' + this.GetFormID () + '].' + this.GetName () + 'Display');
	elInputBox.onFocus = preventEditing_dp_opgeek;

	return;
}

DatePicker_dp_opgeek.prototype.GetField = function ()
{
	return eval ('document.forms [' + this.GetFormID () + '].' + this.GetName ());
}

DatePicker_dp_opgeek.prototype.GetDisplay = function ()
{
	return eval ('document.forms [' + this.GetFormID () + '].' + this.GetName () + 'Display');
}

DatePicker_dp_opgeek.prototype.GetCalendar = function ()
{
	return getCalendarLayer_dp_opgeek (this.GetName ());
}

DatePicker_dp_opgeek.prototype.GetDate = function ()
{
	return this._dtDate;
}

DatePicker_dp_opgeek.prototype.SetDate = function (dtNewDate)
{
	this._dtDate = dtNewDate;
	var elInputBox = this.GetDisplay ();
	elInputBox.value = this._dtDate.GetFormatted (this.DisplayFormat);

	var elRealField = this.GetField ();
	elRealField.value = this._dtDate.GetODBCNormalizedDate ();

	return;
}

DatePicker_dp_opgeek.prototype.GetName = function ()
{
	return this._strName;
}

DatePicker_dp_opgeek.prototype.SetName = function (strName)
{
	this._strName = strName;

	return;
}

DatePicker_dp_opgeek.prototype.GetFormID = function ()
{
	return this._nID;
}

DatePicker_dp_opgeek.prototype.SetFormID = function (nID)
{
	this._nID = nID;

	return;
}

DatePicker_dp_opgeek.prototype.GetExtruded = function ()
{
	return this._bExtruded;
}

DatePicker_dp_opgeek.prototype.SetExtruded = function (bExtruded)
{
	if (isDefined_dp_opgeek (bExtruded))
	{
		this._bExtruded = bExtruded;
	}

	return;
}

DatePicker_dp_opgeek.prototype.GetFirstYear = function ()
{
	return this._nFirstYear;
}

DatePicker_dp_opgeek.prototype.SetFirstYear = function (nFirstYear)
{
	this._nFirstYear = nFirstYear;

	return;
}

DatePicker_dp_opgeek.prototype.GetLastYear = function ()
{
	return this._nLastYear;
}

DatePicker_dp_opgeek.prototype.SetLastYear = function (nLastYear)
{
	this._nLastYear = nLastYear;

	return;
}

DatePicker_dp_opgeek.prototype.Show = function ()
{
	if (!this.PopupCurrentlyDisplayed)
	{
		var elCurrentCal = this.GetCalendar ();
		var nLeft = this.GetButtonX ();
		var nTop = this.GetButtonY ();
		var nRemainingWidth = window.innerWidth - nLeft;
		var nRemainingHeight = window.innerHeight - nTop - BUTTON_HEIGHT_DP_OPGEEK;

		nTop = nTop + BUTTON_HEIGHT_DP_OPGEEK;
		nTop = (nTop < 0 ? 0 : nTop);
		elCurrentCal.top = nTop;

		nLeft = (nLeft < 0 ? 0 : nLeft);
		elCurrentCal.left = nLeft;

		displayDatePicker_dp_opgeek (this.GetName (), this.GetDate (), this.GetDate (), this.GetExtruded (), this.GetFirstYear (), this.GetLastYear ());

		hideProblematicElements_dp_opgeek (elCurrentCal, 'select', aobjHiddenSelects_dp_opgeek);
		hideProblematicElements_dp_opgeek (elCurrentCal, 'object', aobjHiddenObjects_dp_opgeek);
		hideProblematicElements_dp_opgeek (elCurrentCal, 'textarea', aobjHiddenObjects_dp_opgeek);

		this.PopupCurrentlyDisplayed = true;

		trapEvents_dp_opgeek ();
	}
	else
	{
		hideDatePicker_dp_opgeek (this.Name);
	}

	return false;
}

DatePicker_dp_opgeek.prototype.Hide = function ()
{
	var elCurrentCal = this.GetCalendar ();
	elCurrentCal.visibility = 'hide';

	showProblematicElements_dp_opgeek (aobjHiddenSelects_dp_opgeek);
	showProblematicElements_dp_opgeek (aobjHiddenObjects_dp_opgeek);

	this.PopupCurrentlyDisplayed = false;

	untrapEvents_dp_opgeek ();

	return;
}

DatePicker_dp_opgeek.prototype.GetButtonX = function ()
{
	return this._nButtonX;
}

DatePicker_dp_opgeek.prototype.SetButtonX = function (nButtonX)
{
	this._nButtonX = nButtonX;

	return;
}

DatePicker_dp_opgeek.prototype.GetButtonY = function ()
{
	return this._nButtonY;
}

DatePicker_dp_opgeek.prototype.SetButtonY = function (nButtonY)
{
	this._nButtonY = nButtonY;

	return;
}

DatePicker_dp_opgeek.prototype.FindFormID = function (strInstanceName)
{
	var bIsFound = false;
	var nFormID = 0;
	var nFormCounter;
	for (nFormCounter = 0; (nFormCounter < document.forms.length) && ! bIsFound; nFormCounter++)
	{
		var nFieldCounter;
		for (nFieldCounter = 0; (nFieldCounter < document.forms [nFormCounter].elements.length) && !bIsFound; nFieldCounter++)
		{
			if (document.forms [nFormCounter].elements [nFieldCounter].name == (strInstanceName + 'Display'))
			{
				bIsFound = true;
				nFormID = nFormCounter;
			}
		}
	}

	return nFormID;
}

//======================================================================
// DatePickerPopup_dp_opgeek object
//======================================================================
function DatePickerPopup_dp_opgeek
(
	strName,
	dtDateToUse,
	dtActiveDate,
	nFirstYear,
	nLastYear
)
{
	if (!isDefined_dp_opgeek (dtDateToUse))
	{
		dtDateToUse = new Date ();
	}

	this._dtActiveDate = dtActiveDate;

	this._strName = '';
	this._nDay = 0;
	this._nMonth = 0;
	this._nYear = 0;
	this._nFirstYear = nFirstYear;
	this._nLastYear = nLastYear;
	this._bExtruded = false;

	this.SetName (strName);

	this.SetDay (dtDateToUse.getDate ());
	this.SetMonth (dtDateToUse.getMonth ());
	var nYearToUse = dtDateToUse.getFullYear ();
	if (nYearToUse > this.GetLastYear ())
	{
		nYearToUse = this.GetLastYear ();
	}
	else if (nYearToUse < this.GetFirstYear ())
	{
		nYearToUse = this.GetFirstYear ();
	}

	this.SetYear (nYearToUse);

	return;
}

DatePickerPopup_dp_opgeek.prototype.GetName = function ()
{
	return this._strName;
}

DatePickerPopup_dp_opgeek.prototype.SetName = function (strName)
{
	this._strName = strName;

	return;
}

DatePickerPopup_dp_opgeek.prototype.GetDay = function ()
{
	return this._nDay;
}

DatePickerPopup_dp_opgeek.prototype.SetDay = function (nDay)
{
	this._nDay = nDay;

	return;
}

DatePickerPopup_dp_opgeek.prototype.GetMonth = function ()
{
	return this._nMonth;
}

DatePickerPopup_dp_opgeek.prototype.SetMonth = function (nMonth)
{
	this._nMonth = nMonth;

	return;
}

DatePickerPopup_dp_opgeek.prototype.GetYear = function ()
{
	return this._nYear;
}

DatePickerPopup_dp_opgeek.prototype.SetYear = function (nYear)
{
	this._nYear = nYear;

	return;
}

DatePickerPopup_dp_opgeek.prototype.GetFirstYear = function ()
{
	return this._nFirstYear;
}

DatePickerPopup_dp_opgeek.prototype.SetFirstYear = function (nFirstYear)
{
	this._nFirstYear = nFirstYear;

	return;
}

DatePickerPopup_dp_opgeek.prototype.GetLastYear = function ()
{
	return this._nLastYear;
}

DatePickerPopup_dp_opgeek.prototype.SetLastYear = function (nLastYear)
{
	this._nLastYear = nLastYear;

	return;
}

DatePickerPopup_dp_opgeek.prototype.GetExtruded = function ()
{
	return this._bExtruded;
}

DatePickerPopup_dp_opgeek.prototype.SetExtruded = function (bExtruded)
{
	if (isDefined_dp_opgeek (bExtruded))
	{
		this._bExtruded = bExtruded;
	}

	return;
}

DatePickerPopup_dp_opgeek.prototype.GetColumnWidth = function (nColumn)
{
	var nWidth = 14;
	if ((nColumn == 0) || (nColumn == 6))
	{
		nWidth = 15;
	}

	return nWidth;
}

DatePickerPopup_dp_opgeek.prototype.GetCalendarHeader = function ()
{
	var strHeaderHTML = '';
	strHeaderHTML += '<tr>';
	strHeaderHTML += '<td align=\'center\' width=\'26\' style=\'' + MONTH_FORWARDBACK_STYLES_DP_OPGEEK + '\'>';
	strHeaderHTML += '<a href=\'#\' onClick=\'switchToMonth_dp_opgeek (' + QUOTE_MARK_DP_OPGEEK + this.GetName () + QUOTE_MARK_DP_OPGEEK + ', ' + (this.GetMonth () - 1) + ', ' + this.GetYear () + '); return false;\'>';
	strHeaderHTML += '&lt;&lt;</a></td>';
	strHeaderHTML += '<td align=\'center\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + ' font-weight: bold;\' colspan=\'5\'>' + astrMonthNames_dp_opgeek [this.GetMonth ()] + ' ' + this.GetYear () + '</td>';
	strHeaderHTML += '<td align=\'center\' width=\'26\' style=\'' + MONTH_FORWARDBACK_STYLES_DP_OPGEEK + '\'>';
	strHeaderHTML += '<a href=\'#\' onClick=\'switchToMonth_dp_opgeek (' + QUOTE_MARK_DP_OPGEEK + this.GetName () + QUOTE_MARK_DP_OPGEEK + ', ' + (this.GetMonth () + 1) + ', ' + this.GetYear () + '); return false;\'>';
	strHeaderHTML += '&gt;&gt;</a></td></tr>';

	return strHeaderHTML;
}

DatePickerPopup_dp_opgeek.prototype.GetDayColumnHeaders = function ()
{
	var strHeaderHTML = '';

	strHeaderHTML += '<tr>';
	strHeaderHTML += '<td align=\'center\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + '\' width=\'26\'>M</td>';
	strHeaderHTML += '<td align=\'center\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + '\' width=\'26\'>T</td>';
	strHeaderHTML += '<td align=\'center\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + '\' width=\'26\'>W</td>';
	strHeaderHTML += '<td align=\'center\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + '\' width=\'26\'>T</td>';
	strHeaderHTML += '<td align=\'center\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + '\' width=\'26\'>F</td>';
	strHeaderHTML += '<td align=\'center\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + '\' width=\'26\'>S</td>';
	strHeaderHTML += '<td align=\'center\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + '\' width=\'26\'>S</td>';
	strHeaderHTML += '</tr>';

	return strHeaderHTML;
}

DatePickerPopup_dp_opgeek.prototype.GetSelectableDay = function (nDate, nMonth, nYear, nColumn)
{
	var strDayHTML = '';
	strDayHTML += '<td align=\'center\' width=\'26\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK;
	if ((this._dtActiveDate != null)
		&& (nDate == this._dtActiveDate.getDate ())
		&& (nMonth == this._dtActiveDate.getMonth ())
		&& (nYear == this._dtActiveDate.getFullYear ()))
	{
		strDayHTML += ' font-weight: bold;';
	}
	strDayHTML += '\'>';
	strDayHTML += '<a href=\'#\' onClick=' + QUOTE_MARK_DP_OPGEEK + 'selectDate_dp_opgeek (\'' + this.GetName () + '\', ' + nDate + ', ' + nMonth + ', ' + nYear + '); return false;' + QUOTE_MARK_DP_OPGEEK + '>';
	strDayHTML += nDate;
	strDayHTML += '</a></td>';

	return strDayHTML;
}

DatePickerPopup_dp_opgeek.prototype.GetUnselectableDay = function (nDate, nColumn)
{
	var strDayHTML = '';
	strDayHTML += '<td align=\'center\' width=\'26\' style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + ' color: #999999;\'>';
	strDayHTML += nDate;
	strDayHTML += '</td>';

	return strDayHTML;
}

DatePickerPopup_dp_opgeek.prototype.GetDaysInMonthTable = function ()
{
	var dtFirstDayInMonth = new Date (this.GetYear (), this.GetMonth (), 1);
	var nStartDay = dtFirstDayInMonth.getDay ();
	if (nStartDay == 0)
	{
    	nStartDay = 7;
	}

	var nColumn = 0;
	var dtLastMonthPadding = new Date ();
	dtLastMonthPadding.setYear (this.GetYear ());
	dtLastMonthPadding.setMonth (this.GetMonth () - 1);

	var strDayListHTML = '';
	for (var nCounter = 1; nCounter < nStartDay; nCounter++)
	{
		strDayListHTML += this.GetUnselectableDay (anDaysInMonth_dp_opgeek [dtLastMonthPadding.getMonth ()] - nStartDay + nCounter + 1, nColumn);
		nColumn++;
	}

	for (var nCounter = 1; nCounter <= anDaysInMonth_dp_opgeek [this.GetMonth ()]; nCounter++)
	{
		strDayListHTML += this.GetSelectableDay (nCounter, this.GetMonth (), this.GetYear (), nColumn);
		nColumn++;
		if (nColumn == 7)
		{
			strDayListHTML += '</tr><tr>'
			nColumn = 0;
		}
	}

	if (nColumn != 0)
	{
		for (var nCounter = 1; nColumn != 0; nCounter++)
		{
			strDayListHTML += this.GetUnselectableDay (nCounter, nColumn);
			nColumn++;
			if (nColumn == 7)
			{
				nColumn = 0;
			}
		}
		strDayListHTML += '</tr>';
	}
	else
	{
		strDayListHTML = strDayListHTML.substring (0, strDayListHTML.length - 4);
	}

	return strDayListHTML;
}

DatePickerPopup_dp_opgeek.prototype.GetCalendarFooter = function ()
{
	var strHeaderHTML = '';
	strHeaderHTML += '<tr>';
	strHeaderHTML += '<td align=\'left\' colspan=\'3\' style=\'' + MONTH_FORWARDBACK_STYLES_DP_OPGEEK + '\'><b>';
	strHeaderHTML += '<font size=\'2\'><a href=\'#\' onClick=\'switchToMonth_dp_opgeek (' + QUOTE_MARK_DP_OPGEEK + this.GetName () + QUOTE_MARK_DP_OPGEEK + ', ' + this.GetMonth () + ', ' + (this.GetYear () - 10) + '); return false;\'>';
	strHeaderHTML += '&lt;&lt;</a>-10&nbsp;';
	strHeaderHTML += '<a href=\'#\' onClick=\'switchToMonth_dp_opgeek (' + QUOTE_MARK_DP_OPGEEK + this.GetName () + QUOTE_MARK_DP_OPGEEK + ', ' + this.GetMonth () + ', ' + (this.GetYear () - 1) + '); return false;\'>';
	strHeaderHTML += '&lt;</a>-1</font></b></td>';
	strHeaderHTML += '<td style=\'' + POPUP_FONT_STYLES_DP_OPGEEK + ' font-weight: bold;\'><font size=\'2\'>Yrs</font></td>';
	strHeaderHTML += '<td align=\'right\' colspan=\'3\' style=\'' + MONTH_FORWARDBACK_STYLES_DP_OPGEEK + '\'><b>';
	strHeaderHTML += '<font size=\'2\'>+1<a href=\'#\' onClick=\'switchToMonth_dp_opgeek (' + QUOTE_MARK_DP_OPGEEK + this.GetName () + QUOTE_MARK_DP_OPGEEK + ', ' + this.GetMonth () + ', ' + (this.GetYear () + 1) + '); return false;\'>';
	strHeaderHTML += '&gt;</a>&nbsp;';
	strHeaderHTML += '+10<a href=\'#\' onClick=\'switchToMonth_dp_opgeek (' + QUOTE_MARK_DP_OPGEEK + this.GetName () + QUOTE_MARK_DP_OPGEEK + ', ' + this.GetMonth () + ', ' + (this.GetYear () + 10) + '); return false;\'>';
	strHeaderHTML += '&gt;&gt;</a></font></b></td>';
	strHeaderHTML += '</tr>';

	return strHeaderHTML;
}

DatePickerPopup_dp_opgeek.prototype.GetCalendarPopup = function ()
{
	var strPopupHTML = '';

	var nMonth = this.GetMonth ();
	var nYear = this.GetYear ();

	var dtWorking = new Date ();

	dtWorking.setMonth (nMonth);
	dtWorking.setFullYear (nYear);

	if (((nYear % 4 == 0) && (nYear % 100 != 0)) || (nYear % 400 == 0))
	{
		anDaysInMonth_dp_opgeek [1] = 29;
	}
	else
	{
		anDaysInMonth_dp_opgeek [1] = 28;
	}

	strPopupHTML += '<table width=\'182\' border=\'1\' bgcolor=\'#cccccc\' id=\'' + this.GetName () + 'CalendarTable\' name=\'' + this.GetName () + 'CalendarTable\' cellpadding=\'0\' cellspacing=\'0\'>';
	strPopupHTML += this.GetCalendarHeader (dtWorking);
	if (this.GetExtruded ())
	{
		strPopupHTML += '<tr><td colspan=\'7\'><table border=\'0\' width=\'100%\' bgcolor=\'#cccccc\' id=\'' + this.GetName () + 'CalendarBodyTable\' name=\'' + this.GetName () + 'CalendarBodyTable\'>';
	}

	strPopupHTML += this.GetDayColumnHeaders ();
	strPopupHTML += this.GetDaysInMonthTable ();
	strPopupHTML += this.GetCalendarFooter ();
	if (this.GetExtruded ())
	{
		strPopupHTML += '</table></td></tr>';
	}

	strPopupHTML += '</table>';

	return strPopupHTML;
}

//======================================================================
// Date prototype methods
//======================================================================
function getFormatted_o_dp_opgeek
(
	strFormatString
)
{
	var strFormat = new String (strFormatString);
	var strHtml = new String (strFormatString);

	var strValue = this.GetDayName ();
	var strFormatToReplace = 'dddd';
	var iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = this.GetDayNameAbbrev ();
	strFormatToReplace = 'ddd';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = getZeroPrefixedNumber_o_dp_opgeek (this.getDate ());
	strFormatToReplace = 'dd';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = this.getDate ();
	strFormatToReplace = 'd';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = this.GetMonthName ();
	strFormatToReplace = 'MMMM';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = this.GetMonthNameAbbrev ();
	strFormatToReplace = 'MMM';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = getZeroPrefixedNumber_o_dp_opgeek (this.getMonth () + 1);
	strFormatToReplace = 'MM';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = this.getMonth () + 1;
	strFormatToReplace = 'M';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = this.getFullYear ();
	strFormatToReplace = 'yyyy';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = getTwoDigitNumber_o_dp_opgeek (this.getYear ());
	strFormatToReplace = 'yy';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = this.getYear ();
	strFormatToReplace = 'y';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	strValue = this.GetDateSuffix ();
	strFormatToReplace = 'x';
	iOffset = strFormat.indexOf (strFormatToReplace);
	while (iOffset > -1)
	{
		strFormat = getReplacedString_dp_opgeek (strFormat, getHashString_dp_opgeek (strValue), iOffset, strFormatToReplace.length);
		strHtml = getReplacedString_dp_opgeek (strHtml, strValue, iOffset, strFormatToReplace.length);
		iOffset = strFormat.indexOf (strFormatToReplace);
	}

	return strHtml;
}
Date.prototype.GetFormatted = getFormatted_o_dp_opgeek;

function getReplacedString_dp_opgeek (strWorkingString, strNewValue, iStart, iLength)
{
	return strWorkingString.substring (0, iStart) + strNewValue + strWorkingString.substring (iStart + iLength);
}

function getHashString_dp_opgeek (strValue)
{
	var strHashes = '############################################################';

	return strHashes.substring (0, (new String (strValue)).length);
}

function getZeroPrefixedNumber_o_dp_opgeek
(
	iValue
)
{
	var strValue = new String (iValue);
	if (iValue < 10)
	{
		strValue = '0' + iValue;
	}

	return strValue;
}

function getTwoDigitNumber_o_dp_opgeek
(
	iValue
)
{
	if (iValue > 99)
	{
		iValue = iValue % 100;
	}

	var strValue = new String (iValue);
	if (iValue < 10)
	{
		strValue = '0' + iValue;
	}

	return strValue;
}

function getDateSuffixByIndex_o_dp_opgeek
(
	nIndex
)
{
	var strDateSuffix;

	switch (nIndex)
	{
		case 1:
		case 21:
		case 31:
			strDateSuffix = 'st';
			break;

		case 2:
		case 22:
			strDateSuffix = 'nd';
			break;

		case 3:
		case 23:
			strDateSuffix = 'rd';
			break;

		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
		case 30:
			strDateSuffix = 'th';
			break;

		case 0:
		default:
			strDateSuffix = 'Error';
			break;
	}

	return strDateSuffix;
}
Date.getDateSuffixByIndex = getDateSuffixByIndex_o_dp_opgeek;
Date.prototype.GetDateSuffixByIndex = getDateSuffixByIndex_o_dp_opgeek;

function getMonthName_o_dp_opgeek
(
)
{
	return astrMonthNames_dp_opgeek [this.getMonth ()];
}
Date.prototype.GetMonthName = getMonthName_o_dp_opgeek;

function getMonthNameAbbrev_o_dp_opgeek
(
)
{
	return astrMonthNamesAbbrev_dp_opgeek [this.getMonth ()];
}
Date.prototype.GetMonthNameAbbrev = getMonthNameAbbrev_o_dp_opgeek;

function getDayName_o_dp_opgeek
(
)
{
	return astrDayNames_dp_opgeek [this.getDay ()];
}
Date.prototype.GetDayName = getDayName_o_dp_opgeek;

function getDayNameAbbrev_o_dp_opgeek
(
)
{
	return astrDayNamesAbbrev_dp_opgeek [this.getDay ()];
}
Date.prototype.GetDayNameAbbrev = getDayNameAbbrev_o_dp_opgeek;

function getDateSuffix_o_dp_opgeek
(
)
{
	return this.GetDateSuffixByIndex (this.getDate ());
}
Date.prototype.GetDateSuffix = getDateSuffix_o_dp_opgeek;

function getODBCNormalizedDate_o_dp_opgeek
(
)
{
	var strYear;
	var strMonth;
	var strDay;

	strYear = this.getFullYear ();

	strMonth = this.getMonth () + 1;
	if (strMonth < 10)
	{
		strMonth = '0' + strMonth;
	}

	strDay = this.getDate ();
	if (strDay < 10)
	{
		strDay = '0' + strDay;
	}

	return strYear + '-' + strMonth + '-' + strDay;
}
Date.prototype.GetODBCNormalizedDate = getODBCNormalizedDate_o_dp_opgeek;

function getODBCNormalizedTime_o_dp_opgeek
(
)
{
	var strNormalizedTime = '';

	if (this.getHours () >= 10)
	{
		strNormalizedTime += this.getHours ();
	}
	else
	{
		strNormalizedTime += '0' + this.getHours ();
	}

	strNormalizedTime += ':';

	if (this.getMinutes () >= 10)
	{
		strNormalizedTime += this.getMinutes ();
	}
	else
	{
		strNormalizedTime += '0' + this.getMinutes ();
	}

	strNormalizedTime += ':';

	if (this.getSeconds () >= 10)
	{
		strNormalizedTime += this.getSeconds ();
	}
	else
	{
		strNormalizedTime += '0' + this.getSeconds ();
	}

	return strNormalizedTime;
}
Date.prototype.GetODBCNormalizedTime = getODBCNormalizedTime_o_dp_opgeek;

function getODBCNormalizedTimeStamp_o_dp_opgeek
(
)
{
	return this.GetODBCNormalizedDate () + ' ' + this.GetODBCNormalizedTime ();
}
Date.prototype.GetODBCNormalizedTimeStamp = getODBCNormalizedTimeStamp_o_dp_opgeek;

function getDateFromODBCNormalizedForm_o_dp_opgeek
(
	strODBCFormDate
)
{
	var dtRealDate = new Date ();
	if (isDefined_dp_opgeek (strODBCFormDate))
	{
		var strYear = strODBCFormDate.substring (0, 4);
		var strMonth = strODBCFormDate.substring (5, 7);
		var strDay = strODBCFormDate.substring (8, 10);
		var nMonth = (Number (strMonth)) - 1;
		//alert ('Date values: ' + strDay + ', ' + nMonth + '(' + strMonth + '), ' + strYear + ' from ' + strODBCFormDate);

		dtRealDate.setYear (strYear);
		dtRealDate.setMonth (nMonth);
		dtRealDate.setDate (strDay);
	}

	return dtRealDate;
}
Date.GetDateFromODBCNormalizedForm = getDateFromODBCNormalizedForm_o_dp_opgeek;