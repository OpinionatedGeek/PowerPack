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

namespace OpinionatedGeek.Web.PowerPack
{
    internal class DatePickerConstants
    {
        public const string ProductName = "DatePicker";
        public const string DefaultControlName = Constants.CompanyName + ProductName;
        public const string UniqueCodeBlockName = Constants.CompanyName + ProductName;
        public const string DefaultDateFormat = "dx MMMM yyyy";

        public const int MinimumControlWidth = 22;
        public const int MinimumControlHeight = 22;

        public const int ButtonWidth = 19;
        public const int ButtonHeight = 19;

        public const int DefaultFirstYear = 1970;
        public const int DefaultLastYear = 2050;

        public const string IE5DhtmlResource = "OpinionatedGeek.Web.PowerPack.DatePicker.CommonFiles.Ie5Dhtml.js";
        public const string MozDhtmlResource = "OpinionatedGeek.Web.PowerPack.DatePicker.CommonFiles.MozDhtml.js";
        public const string NSDhtmlResource = "OpinionatedGeek.Web.PowerPack.DatePicker.CommonFiles.NsDhtml.js";
        public const string WebKitDhtmlResource = "OpinionatedGeek.Web.PowerPack.DatePicker.CommonFiles.WebKitDhtml.js";
        public const string IconResource = "OpinionatedGeek.Web.PowerPack.DatePicker.CommonFiles.DatePickerIcon.gif";

        private DatePickerConstants ()
        {
            return;
        }
    }
}