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

namespace OpinionatedGeek.Web.PowerPack
{
    internal static class Normaliser
    {
        //============================================================
        // Private Data
        //============================================================

        //============================================================
        // Constructors
        //============================================================

        //============================================================
        // Static Methods
        //============================================================

        public static bool StringCompare (string s1, string s2)
        {
            return String.Compare (s1, s2, StringComparison.CurrentCultureIgnoreCase) == 0;
        }

        public static bool StringCompare (object o1, string s2)
        {
            return String.Compare (o1.ToString (), s2, StringComparison.CurrentCultureIgnoreCase) == 0;
        }

        //public static bool StringCompare (string s1, object o2)
        //{
        //    return String.Compare (s1, o2.ToString ()) == 0;
        //}

        public static string NormaliseForJavascript (string unnormalised)
        {
            string normalised = unnormalised.Replace ("\r\n", "\\n");

            return normalised;
        }

        public static string GetOdbcFormatFromDate (DateTime workingDate)
        {
            const string odbcFormatter = "{0:d4}-{1:d2}-{2:d2}";
            return String.Format (Globalisation.GetCultureInfo (), odbcFormatter, workingDate.Year, workingDate.Month, workingDate.Day);
        }

        public static DateTime GetDateFromOdbcFormat (string odbcDate)
        {
            DateTime date = DateTime.MinValue;

            try
            {
                string[] dateString = odbcDate.Split ('-', 'T');
                string yearString = dateString[0];
                string monthString = dateString[1];
                string dayString = dateString[2];

                int year = Convert.ToInt32 (yearString, Globalisation.GetCultureInfo ());
                int month = Convert.ToInt32 (monthString, Globalisation.GetCultureInfo ());
                int iDay = Convert.ToInt32 (dayString, Globalisation.GetCultureInfo ());

                date = CreateDate (year, month, iDay);
            }
            catch (NullReferenceException)
            {
            }
            catch (FormatException)
            {
            }

            return date;
        }

        public static DateTime CreateDate (int year, int month, int day)
        {
            DateTime workingDate = DateTime.Now;
            workingDate = workingDate.AddYears (year - workingDate.Year);
            workingDate = workingDate.AddMonths (month - workingDate.Month);
            workingDate = workingDate.AddDays (day - workingDate.Day);

            return workingDate;
        }
    }
}