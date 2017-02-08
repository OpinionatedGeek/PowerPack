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
	if (bLibraryInitialized_dp_opgeek)
	{
		throw new Exception ('DatePicker library has already been initialized.');
	}

	document.write (getPopupCalendarStyles_dp_opgeek ());
	bLibraryInitialized_dp_opgeek = true;

	return;
}

function initialize_dp_opgeek
(
	strInstanceName,
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
		var insCurrentInstance = new DatePicker_dp_opgeek (strInstanceName, bExtruded, strDisplayFormat, nFirstYear, nLastYear);
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

var strElementToIgnoreId = "";
function ignore_dp_opgeek
(
)
{
	event.cancelBubble = true;
	strElementToIgnoreId = event.srcElement.id;

	return false;
}

var nBlurCount = 0;
function onBlur_dp_opgeek
(
)
{
	if ((!event.srcElement) || (event.srcElement.id != strElementToIgnoreId))
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

function onButtonDown_dp_opgeek
(
	strButtonID
)
{
	var elButton = document.all [strButtonID];
	elButton.style.borderStyle = 'inset';

	return;
}

function onButtonUp_dp_opgeek
(
	strButtonID
)
{
	var elButton = document.all [strButtonID];
	elButton.style.borderStyle = 'outset';

	return;
}

function onButtonClick_dp_opgeek
(
	strInstanceName
)
{
	var insCurrentInstance = allInstantiatedDatePickerFields_dp_opgeek [strInstanceName];
	if (!insCurrentInstance.PopupCurrentlyDisplayed)
	{
		hideAllDatePickers_dp_opgeek ();
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

	var insCurrentInstance = allInstantiatedDatePickerFields_dp_opgeek [strName];
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
	var elCurrentCal = document.all [strName + 'DatePicker_dp_opgeek'];

	var dpNewCalendar = new DatePickerPopup_dp_opgeek (strName, dtDateToUse, dtActiveDate, nFirstYear, nLastYear);
	dpNewCalendar.SetExtruded (bExtruded);
	elCurrentCal.innerHTML = dpNewCalendar.GetCalendarPopup ();

	return;
}

function highlightMenuItem_dp_opgeek
(
)
{
	event.srcElement.style.backgroundColor = 'highlight';
	event.srcElement.style.color = 'highlighttext';

	return true;
}

function unhighlightMenuItem_dp_opgeek
(
)
{
	event.srcElement.style.backgroundColor = '';
	event.srcElement.style.color = '';

	return true;
}

function getLeftOffset_dp_opgeek
(
	srcTag
)
{
	var nLeftOffset = 0;
	var elWorkingTag = srcTag;
	while ((elWorkingTag) && (elWorkingTag.style.position != 'absolute') && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
	{
		nLeftOffset += elWorkingTag.offsetLeft;
		elWorkingTag = elWorkingTag.offsetParent;
	}

    return nLeftOffset;
}

function getTopOffset_dp_opgeek
(
	srcTag
)
{
	var nTopOffset = 0;
	var elWorkingTag = srcTag;
	while ((elWorkingTag) && (elWorkingTag.style.position != 'absolute') && (elWorkingTag.tagName.toUpperCase () != 'BODY'))
	{
		nTopOffset += elWorkingTag.offsetTop;
		elWorkingTag = elWorkingTag.offsetParent;
	}

    return nTopOffset;
}

var bSomeElementsHidden_dp_opgeek = false;
function hideProblematicElements_dp_opgeek
(
	objMaskingObject,
	strElementName,
	aHiddenElements
)
{
	var nMenuLeft = parseInt (objMaskingObject.style.left);
	var nMenuRight = nMenuLeft + parseInt (objMaskingObject.clientWidth);
	var nMenuTop = parseInt (objMaskingObject.style.top);
	var nMenuBottom = nMenuTop + parseInt (objMaskingObject.clientHeight);

	aHiddenElements.length = 0

	var objElement;
	var objElementParent;
	var nElementLeft;
	var nElementRight;
	var nElementTop;
	var nElementBottom;
	for (nCounter = 0; nCounter < document.all.tags (strElementName).length; nCounter++)
	{
		objElement = document.all.tags (strElementName) [nCounter];
		if (!objElement || !objElement.offsetParent)
		{
			continue;
		}

		nElementLeft = objElement.offsetLeft;
		nElementTop = objElement.offsetTop;
		objElementParent = objElement.offsetParent;

		var bIsContainedInMask = false;
		while ((objElementParent != null)
			&& (objElementParent.tagName != null)
			&& (objElementParent.tagName.toUpperCase() != 'BODY'))
		{
			if (objElementParent == objMaskingObject)
			{
				bIsContainedInMask = true;
			}

			nElementLeft += objElementParent.offsetLeft;
			nElementTop += objElementParent.offsetTop;
			objElementParent = objElementParent.offsetParent;
		}

		nElementRight = nElementLeft + objElement.offsetWidth;
		nElementBottom = nElementTop + objElement.offsetHeight;

		if (!bIsContainedInMask
			&& !(nMenuLeft > nElementRight)
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

function getPopupCalendarStyles_dp_opgeek
(
)
{
	var strStyles = '';
	strStyles += '<style>\n';
	strStyles += '.DatePickerTable_dp_opgeek\n';
	strStyles += '{\n';
	strStyles += '\tfont-family: Tahoma, sans-serif;\n';
	strStyles += '\tfont-size: 8pt;\n';
	strStyles += '\tfont-weight: normal;\n';
	strStyles += '\tpadding: 2px;\n';
	strStyles += '\tcolor: black;\n';
	strStyles += '\tbackground-color: #E0E0E0;\n';
	strStyles += '\tborder-width: 2px;\n';
	strStyles += '\tborder-style: outset;\n';
	strStyles += '\tborder-color: buttonhighlight;\n';
	strStyles += '}\n\n';

	strStyles += '.DatePicker_dp_opgeek\n';
	strStyles += '{\n';
	strStyles += '\tposition: absolute;\n';
	strStyles += '\tleft: 0;\n';
	strStyles += '\ttop: 0;\n';
	strStyles += '}\n\n';

	strStyles += '.MonthTitle_dp_opgeek\n';
	strStyles += '{\n';
	strStyles += '\tcursor: default;\n';
	strStyles += '\tfont-weight: bold;\n';
	strStyles += '}\n\n';

	strStyles += '.ColumnTitle_dp_opgeek\n';
	strStyles += '{\n';
	strStyles += '\tcursor: default;\n';
	strStyles += '\tfont-weight: bold;\n';
	strStyles += '}\n\n';

	strStyles += '.NonSelectableDay_dp_opgeek\n';
	strStyles += '{\n';
	strStyles += '\tcursor: default;\n';
	strStyles += '\tcolor: #999999;\n';
	strStyles += '}\n\n';

	strStyles += '.SelectableDay_dp_opgeek\n';
	strStyles += '{\n';
	strStyles += '\tcursor: hand;\n';
	strStyles += '}\n\n';

	strStyles += '.SelectableTitle_dp_opgeek\n';
	strStyles += '{\n';
	strStyles += '\tcursor: hand;\n';
	strStyles += '\tfont-family: Arial;\n';
	strStyles += '\tfont-size: 10pt;\n';
	strStyles += '\tfont-weight: bold;\n';
	strStyles += '}\n\n';

	strStyles += '.SelectableActiveDay_dp_opgeek\n';
	strStyles += '{\n';
	strStyles += '\tcursor: hand;\n';
	strStyles += '\tfont-weight: bold;\n';
	strStyles += '}\n';
	strStyles += '</style>\n\n';

	return strStyles;
}

//======================================================================
// DatePicker object
//======================================================================
function DatePicker_dp_opgeek
(
	strInstanceName,
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
	this.SetFirstYear (nFirstYear);
	this.SetLastYear (nLastYear);

	var elRealField = this.GetField ();
	if (elRealField.value != '')
	{
		this.SetDate (Date.GetDateFromODBCNormalizedForm (elRealField.value));
	}

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

DatePicker_dp_opgeek.prototype.GetField = function ()
{
	var elField = null;
	var aAllElementsWithName = document.all [this.GetName ()];
	for (var i = 0; i < aAllElementsWithName.length; i++)
	{
		if ((aAllElementsWithName [i].tagName == 'INPUT')
			&& (aAllElementsWithName [i].className == 'DateBox_dp_opgeek'))
		{
			elField = aAllElementsWithName [i];
		}
	}

	return elField;
}

DatePicker_dp_opgeek.prototype.GetDisplay = function ()
{
	return document.all [this.GetName () + 'Display'];
}

DatePicker_dp_opgeek.prototype.GetCalendar = function ()
{
	return document.all [this.GetName () + 'DatePicker_dp_opgeek'];
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

		var nLeft = getLeftOffset_dp_opgeek (document.all [this.GetName () + 'Icon']);
		var nTop = getTopOffset_dp_opgeek (document.all [this.GetName () + 'Icon']);
		var nRemainingWidth = document.body.scrollLeft + document.body.clientWidth - document.all [this.GetName () + 'Icon'].offsetLeft;
		var nRemainingHeight = document.body.scrollTop + document.body.clientHeight - document.all [this.GetName () + 'Icon'].offsetTop - BUTTON_HEIGHT_DP_OPGEEK;

		if (nRemainingHeight > POPUP_HEIGHT_DP_OPGEEK)
		{
			nTop = nTop + BUTTON_HEIGHT_DP_OPGEEK;
		}
		else
		{
			nTop = nTop - POPUP_HEIGHT_DP_OPGEEK;
		}
		nTop = (nTop < 0 ? 0 : nTop);
		elCurrentCal.style.top = nTop;

		if (nRemainingWidth < POPUP_WIDTH_DP_OPGEEK)
		{
			nLeft = nLeft - POPUP_WIDTH_DP_OPGEEK + BUTTON_WIDTH_DP_OPGEEK;
			nLeft = (nLeft < 0 ? 0 : nLeft);
		}

		elCurrentCal.style.left = nLeft;

		displayDatePicker_dp_opgeek (this.GetName (), this.GetDate (), this.GetDate (), this.GetExtruded (), this.GetFirstYear (), this.GetLastYear ());

		hideProblematicElements_dp_opgeek (elCurrentCal, 'select', aobjHiddenSelects_dp_opgeek);
		hideProblematicElements_dp_opgeek (elCurrentCal, 'object', aobjHiddenObjects_dp_opgeek);

		this.PopupCurrentlyDisplayed = true;

		trapEvents_dp_opgeek ();
	}
	else
	{
		hideDatePicker_dp_opgeek (strName);
	}

	return false;
}

DatePicker_dp_opgeek.prototype.Hide = function ()
{
	var elCurrentCal = this.GetCalendar ();
	elCurrentCal.innerHTML = '';
	showProblematicElements_dp_opgeek (aobjHiddenSelects_dp_opgeek);
	showProblematicElements_dp_opgeek (aobjHiddenObjects_dp_opgeek);

	this.PopupCurrentlyDisplayed = false;

	untrapEvents_dp_opgeek ();

	return;
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
	strHeaderHTML += '<td align=\'center\' width=\'15%\' class=\'SelectableTitle_dp_opgeek\' ';
	strHeaderHTML += 'onmouseover=' + QUOTE_MARK_DP_OPGEEK + 'return highlightMenuItem_dp_opgeek ();' + QUOTE_MARK_DP_OPGEEK + ' ';
	strHeaderHTML += 'onmouseout=' + QUOTE_MARK_DP_OPGEEK + 'return unhighlightMenuItem_dp_opgeek ();' + QUOTE_MARK_DP_OPGEEK + ' ';
	strHeaderHTML += 'onclick=' + QUOTE_MARK_DP_OPGEEK + 'return switchToMonth_dp_opgeek (\'' + this.GetName () + '\', ' + (this.GetMonth () - 1) + ', ' + this.GetYear () + ')' + QUOTE_MARK_DP_OPGEEK + '>';
	strHeaderHTML += '&lt;&lt;</td>';
	strHeaderHTML += '<td align=\'center\' class=\'MonthTitle_dp_opgeek\' colspan=\'5\' nowrap>';
	strHeaderHTML += '<select id="' + this.GetName () + '_month_select" name="' + this.GetName () + '_month_select" onclick=\'return ignore_dp_opgeek ()\' onchange=\'return monthChange_dp_opgeek (' + QUOTE_MARK_DP_OPGEEK + this.GetName () + QUOTE_MARK_DP_OPGEEK + ', ' + this.GetYear () + ')\' style="font-size: 10px;">';
	for (var iMonthCounter = 0; iMonthCounter < astrMonthNames_dp_opgeek.length; iMonthCounter++)
	{
		strHeaderHTML += '<option value="';
		strHeaderHTML += iMonthCounter;
		strHeaderHTML += '"';
		if (iMonthCounter == this.GetMonth ())
		{
			strHeaderHTML += ' selected';
		}
		strHeaderHTML += '>';
		strHeaderHTML += astrMonthNames_dp_opgeek [iMonthCounter];
		strHeaderHTML += '</option>';
	}
	strHeaderHTML += '</select> ';
	strHeaderHTML += '<select id="' + this.GetName () + '_year_select" name="' + this.GetName () + '_year_select" onclick=\'return ignore_dp_opgeek ()\' onchange=\'return yearChange_dp_opgeek (' + QUOTE_MARK_DP_OPGEEK + this.GetName () + QUOTE_MARK_DP_OPGEEK + ', ' + this.GetMonth () + ')\' style="font-size: 10px;">';
	for (var iYearCounter = this.GetFirstYear (); iYearCounter <= this.GetLastYear (); iYearCounter++)
	{
		strHeaderHTML += '<option value="';
		strHeaderHTML += iYearCounter;
		strHeaderHTML += '"';
		if (iYearCounter == this.GetYear ())
		{
			strHeaderHTML += ' selected';
		}
		strHeaderHTML += '>';
		strHeaderHTML += iYearCounter;
		strHeaderHTML += '</option>';
	}
	strHeaderHTML += '</select> ';
	strHeaderHTML += '</td>';
	strHeaderHTML += '<td align=\'center\' width=\'15%\' class=\'SelectableTitle_dp_opgeek\' ';
	strHeaderHTML += 'onmouseover=' + QUOTE_MARK_DP_OPGEEK + 'return highlightMenuItem_dp_opgeek ();' + QUOTE_MARK_DP_OPGEEK + ' ';
	strHeaderHTML += 'onmouseout=' + QUOTE_MARK_DP_OPGEEK + 'return unhighlightMenuItem_dp_opgeek ();' + QUOTE_MARK_DP_OPGEEK + ' ';
	strHeaderHTML += 'onclick=' + QUOTE_MARK_DP_OPGEEK + 'return switchToMonth_dp_opgeek (\'' + this.GetName () + '\', ' + (this.GetMonth () + 1) + ', ' + this.GetYear () + ')' + QUOTE_MARK_DP_OPGEEK + '>';
	strHeaderHTML += '&gt;&gt;</td></tr>';

	return strHeaderHTML;
}

DatePickerPopup_dp_opgeek.prototype.GetDayColumnHeaders = function ()
{
	var strHeaderHTML = '';

	strHeaderHTML += '<tr>';
	strHeaderHTML += '<td align=\'center\' class=\'ColumnTitle_dp_opgeek\' width=\'15%\'>M</td>';
	strHeaderHTML += '<td align=\'center\' class=\'ColumnTitle_dp_opgeek\' width=\'14%\'>T</td>';
	strHeaderHTML += '<td align=\'center\' class=\'ColumnTitle_dp_opgeek\' width=\'14%\'>W</td>';
	strHeaderHTML += '<td align=\'center\' class=\'ColumnTitle_dp_opgeek\' width=\'14%\'>T</td>';
	strHeaderHTML += '<td align=\'center\' class=\'ColumnTitle_dp_opgeek\' width=\'14%\'>F</td>';
	strHeaderHTML += '<td align=\'center\' class=\'ColumnTitle_dp_opgeek\' width=\'14%\'>S</td>';
	strHeaderHTML += '<td align=\'center\' class=\'ColumnTitle_dp_opgeek\' width=\'15%\'>S</td>';
	strHeaderHTML += '</tr>';

	return strHeaderHTML;
}

DatePickerPopup_dp_opgeek.prototype.GetSelectableDay = function (nDate, nMonth, nYear, nColumn)
{
	var strDayHTML = '';
	strDayHTML += '<td align=\'center\' width=\'';
	strDayHTML += this.GetColumnWidth (nColumn);
	strDayHTML += '%\' class=\'';
	if ((this._dtActiveDate != null)
		&& (nDate == this._dtActiveDate.getDate ())
		&& (nMonth == this._dtActiveDate.getMonth ())
		&& (nYear == this._dtActiveDate.getFullYear ()))
	{
		strDayHTML += 'SelectableActiveDay_dp_opgeek';
	}
	else
	{
		strDayHTML += 'SelectableDay_dp_opgeek';
	}
	strDayHTML += '\' onmouseover=' + QUOTE_MARK_DP_OPGEEK + 'return highlightMenuItem_dp_opgeek ();' + QUOTE_MARK_DP_OPGEEK + ' ';
	strDayHTML += 'onmouseout=' + QUOTE_MARK_DP_OPGEEK + 'return unhighlightMenuItem_dp_opgeek ();' + QUOTE_MARK_DP_OPGEEK + ' ';
	strDayHTML += 'onclick=' + QUOTE_MARK_DP_OPGEEK + 'return selectDate_dp_opgeek (\'' + this.GetName () + '\', ' + nDate + ', ' + nMonth + ', ' + nYear + ');' + QUOTE_MARK_DP_OPGEEK + '>';
	strDayHTML += nDate;
	strDayHTML += '</td>';

	return strDayHTML;
}

DatePickerPopup_dp_opgeek.prototype.GetUnselectableDay = function (nDate, nColumn)
{
	var strDayHTML = '';
	strDayHTML += '<td align=\'center\' width=\''
	strDayHTML += this.GetColumnWidth (nColumn);
	strDayHTML += '%\' class=\'NonSelectableDay_dp_opgeek\'>';
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

	strPopupHTML += '<table border=\'0\' width=\'185\' class=\'DatePickerTable_dp_opgeek\'>';
	strPopupHTML += this.GetCalendarHeader (dtWorking);
	if (this.GetExtruded ())
	{
		strPopupHTML += '<tr><td colspan=\'7\'><table border=\'0\' width=\'100%\' class=\'DatePickerTable_dp_opgeek\'>';
	}
	strPopupHTML += this.GetDayColumnHeaders ();
	strPopupHTML += this.GetDaysInMonthTable ();
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

	strValue = getZeroPrefixedNumber_o_dp_opgeek (this.getYear ());
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
		case 21:
		case 22:
		case 23:
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