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

using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class DefaultDatePickerField : WebControl
    {
        //============================================================
        // Private Data
        //============================================================

        private const string DayFieldNameSuffix = "Day_opgeek";
        private const string MonthFieldNameSuffix = "Month_opgeek";
        private const string YearFieldNameSuffix = "Year_opgeek";

        private static readonly string[] _monthNames = {"", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

        private static readonly string [] _dayNames = { "", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "13th", "14th", "15th", "16th", "17th", "18th", "19th", "20th", "21st", "22nd", "23rd", "24th", "25th", "26th", "27th", "28th", "29th", "30th", "31st" };

        protected DateTime _value = DateTime.MinValue;
        private bool _defaultToCurrentDate = true;
        private int _firstYear = DatePickerConstants.DefaultFirstYear;
        private string _id;
        private int _lastYear = DatePickerConstants.DefaultLastYear;

        //============================================================
        // Constructors
        //============================================================

        public DefaultDatePickerField ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        public bool DefaultToCurrentDate
        {
            get
            {
                return _defaultToCurrentDate;
            }
            set
            {
                _defaultToCurrentDate = value;

                return;
            }
        }

        public int FirstYear
        {
            get
            {
                return _firstYear;
            }

            set
            {
                _firstYear = value;

                return;
            }
        }

        public override string ID
        {
            get
            {
                return _id;
            }

            set
            {
                base.ID = value + "HiddenId";
                _id = value;

                return;
            }
        }

        public virtual bool IsEmpty
        {
            get
            {
                bool returnValue = false;
                string value = GetFormValue ();
                if ((String.IsNullOrEmpty (value)) && (_value == DateTime.MinValue))
                {
                    returnValue = true;
                }

                return returnValue;
            }
        }

        public int LastYear
        {
            get
            {
                return _lastYear;
            }

            set
            {
                _lastYear = value;

                return;
            }
        }

        public virtual DateTime Value
        {
            get
            {
                string value = GetFormValue ();
                if (null != value)
                {
                    string dayValueString = HttpContext.Current.Request.Form [ID + DayFieldNameSuffix];
                    string monthValueString = HttpContext.Current.Request.Form [ID + MonthFieldNameSuffix];
                    string yearValueString = HttpContext.Current.Request.Form [ID + YearFieldNameSuffix];

                    int dayValue = Convert.ToInt32 (dayValueString, Globalisation.GetCultureInfo ());
                    int monthValue = Convert.ToInt32 (monthValueString, Globalisation.GetCultureInfo ());
                    int yearValue = Convert.ToInt32 (yearValueString, Globalisation.GetCultureInfo ());
                    _value = Normaliser.CreateDate (yearValue, monthValue, dayValue);
                }

                return _value;
            }
            set
            {
                _value = value;

                return;
            }
        }

        public virtual string DisplayFormat
        {
            get
            {
                var displayFormat = ViewState ["DisplayFormat"] as string;
                if (String.IsNullOrEmpty (displayFormat))
                {
                    displayFormat = DatePickerConstants.DefaultDateFormat;
                }

                return displayFormat;
            }
            set
            {
                ViewState ["DisplayFormat"] = value;

                return;
            }
        }

        //============================================================
        // Events
        //============================================================

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            Page.ClientScript.RegisterHiddenField (_id, "1");

            if (_value != DateTime.MinValue)
            {
                if (_value.Year < FirstYear)
                {
                    // Set the date to the first of January of the first year.
                    _value = DateTime.Parse ("01/01/" + FirstYear + " 00:00:00", Globalisation.GetCultureInfo ());
                    // Can set it to the current date in the first year instead:
                    //_value = _value.AddYears (FirstYear - _value.Year);
                }
                else if (_value.Year > LastYear)
                {
                    // Set the date to the first of January of the last year.
                    _value = DateTime.Parse ("01/01/" + LastYear + " 00:00:00", Globalisation.GetCultureInfo ());
                    // Can set it to the current date in the last year instead:
                    //_value = _value.AddYears (LastYear - _value.Year);
                }
            }

            string dhtmlResourceName = GetDhtmlFileResourceName ();
            if (!String.IsNullOrEmpty (dhtmlResourceName))
            {
                Page.ClientScript.RegisterClientScriptResource (typeof (DefaultDatePickerField), dhtmlResourceName);
            }

            return;
        }

        protected override void RenderContents (HtmlTextWriter htwOutput)
        {
            var controlHtml = new StringBuilder ("");

            if (Enabled)
            {
                controlHtml.Append ("<select name=\"");
                controlHtml.Append (ID);
                controlHtml.Append (DayFieldNameSuffix);
                controlHtml.Append ("\">");

                for (int dayCounter = 1; dayCounter < _dayNames.Length; dayCounter++)
                {
                    controlHtml.Append ("<option value=\"");
                    controlHtml.Append (dayCounter < 10 ? "0" : "");
                    controlHtml.Append (dayCounter);
                    controlHtml.Append ("\"");
                    if ((!IsEmpty) && (Value.Day == dayCounter))
                    {
                        controlHtml.Append (" selected");
                    }
                    controlHtml.Append (">");
                    controlHtml.Append (_dayNames [dayCounter]);
                    controlHtml.Append ("</option>");
                }
                controlHtml.Append ("</select>");

                controlHtml.Append ("<select name=\"");
                controlHtml.Append (ID);
                controlHtml.Append (MonthFieldNameSuffix);
                controlHtml.Append ("\">");
                for (int monthCounter = 1; monthCounter < _monthNames.Length; monthCounter++)
                {
                    controlHtml.Append ("<option value=\"");
                    controlHtml.Append (monthCounter < 10 ? "0" : "");
                    controlHtml.Append (monthCounter);
                    controlHtml.Append ("\"");
                    if ((!IsEmpty) && (Value.Month == monthCounter))
                    {
                        controlHtml.Append (" selected");
                    }
                    controlHtml.Append (">");
                    controlHtml.Append (_monthNames [monthCounter]);
                    controlHtml.Append ("</option>");
                }
                controlHtml.Append ("</select>");

                controlHtml.Append ("<select name=\"");
                controlHtml.Append (ID);
                controlHtml.Append (YearFieldNameSuffix);
                controlHtml.Append ("\">");

                RationaliseFirstAndLastYears ();
                for (int yearCounter = FirstYear; yearCounter <= LastYear; yearCounter++)
                {
                    controlHtml.Append ("<option value=\"");
                    controlHtml.Append (yearCounter);
                    controlHtml.Append ("\"");
                    if ((!IsEmpty) && (Value.Year == yearCounter))
                    {
                        controlHtml.Append (" selected");
                    }
                    controlHtml.Append (">");
                    controlHtml.Append (yearCounter);
                    controlHtml.Append ("</option>");
                }
                controlHtml.Append ("</select>");
            }
            else
            {
                controlHtml.Append (Value.Day);
                controlHtml.Append ("&nbsp;");
                controlHtml.Append (_monthNames [Value.Month]);
                controlHtml.Append ("&nbsp;");
                controlHtml.Append (Value.Year);
            }

            htwOutput.Write (controlHtml.ToString ());
            return;
        }

        //============================================================
        // Methods
        //============================================================

        protected string GetIconUrl ()
        {
            return Page.ClientScript.GetWebResourceUrl (typeof (DefaultDatePickerField), DatePickerConstants.IconResource);
        }

        private void RationaliseFirstAndLastYears ()
        {
            int minimum = Math.Min (FirstYear, LastYear);
            int maximum = Math.Max (FirstYear, LastYear);

            FirstYear = minimum;
            LastYear = maximum;

            return;
        }

        protected virtual string GetFormValue ()
        {
            string value = null;
            string dayValue = HttpContext.Current.Request.Form [ID + DayFieldNameSuffix];
            if (null != dayValue)
            {
                string monthValue = HttpContext.Current.Request.Form [ID + MonthFieldNameSuffix];
                string yearValue = HttpContext.Current.Request.Form [ID + YearFieldNameSuffix];

                value = dayValue + "-" + monthValue + "-" + yearValue;
            }

            return value;
        }

        protected virtual string GetDhtmlFileResourceName ()
        {
            return null;
        }
    }
}