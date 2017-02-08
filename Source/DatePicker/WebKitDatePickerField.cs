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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class WebKitDatePickerField : DefaultDatePickerField
    {
        //============================================================
        // Private Data
        //============================================================

        //============================================================
        // Constructors
        //============================================================

        public WebKitDatePickerField ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        public override DateTime Value
        {
            get
            {
                string odbcDateValue = GetFormValue ();
                if (!String.IsNullOrEmpty (odbcDateValue))
                {
                    _value = Normaliser.GetDateFromOdbcFormat (odbcDateValue);
                }

                return _value;
            }
            set
            {
                _value = value;

                return;
            }
        }

        //============================================================
        // Events
        //============================================================

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            PowerPack.EnsureIdSet (this);

            return;
        }

        protected override void RenderContents (HtmlTextWriter writer)
        {
            const string MouseTemplate = "onmousedown=\"return onButtonDown_dp_opgeek ('{0}Icon');\" onmouseup=\"return onButtonUp_dp_opgeek ('{0}Icon');\" onmouseout=\"return onButtonUp_dp_opgeek ('{0}Icon');\" onclick=\"return onButtonClick_dp_opgeek ('{0}');\"";
            const string ControlTemplate = "<span class=\"DatePicker_dp_opgeek\" id=\"{0}DatePicker_dp_opgeek\" style=\"position: absolute; display:\"></span><input type=\"text\" style=\"background-color: menu; font-size: 8pt; padding-top: 4; padding-left: 2;{8}\" name=\"{0}Display\" id=\"{0}Display\" size=\"18\" value=\"\" {5}readonly/><img id=\"{0}Icon\" name=\"{0}Icon\" src=\"{2}DatePickerIcon.gif\" width=\"{9}\" height=\"{10}\" valign=\"bottom\" {6} style=\"vertical-align: bottom; background-color: menu; border-width: 2px; border-style: outset;\"><input type=\"hidden\" class=\"DateBox_dp_opgeek\" name=\"{0}\" id=\"{0}\" value=\"{1}\"/><script type=\"text/javascript\">\n\tinitialize_dp_opgeek ('{0}', '{1}', true, '{7}', {3}, {4});\n</script>\n";

            string disableCode = String.Empty;
            string mouseHtml = String.Empty;
            if (!Enabled)
            {
                disableCode = "disabled=\"disabled\" ";
            }
            else
            {
                mouseHtml = String.Format (Globalisation.GetCultureInfo (), MouseTemplate, ClientID);
            }

            string value = String.Empty;
            if (!IsEmpty)
            {
                value = Normaliser.GetOdbcFormatFromDate (Value);
            }

            string boxWidth = String.Empty;
            if ((!Width.IsEmpty) && (Width.Type == UnitType.Pixel))
            {
                int iWidth = (int) Width.Value - DatePickerConstants.ButtonWidth - 3;
                if (iWidth > 0)
                {
                    boxWidth = "width: " + iWidth + "px; ";
                }
                else
                {
                    boxWidth = "display: none;";
                }
            }

            string boxHeight = String.Empty;
            if ((!Height.IsEmpty) && (Height.Type == UnitType.Pixel))
            {
                boxHeight = "height: " + (Height.Value - DatePickerConstants.ButtonHeight - 3) + "px; ";
            }

            string boxSize = boxHeight + boxWidth;

            string controlHtml = String.Format (Globalisation.GetCultureInfo (), ControlTemplate, ClientID, value, GetIconUrl (), FirstYear, LastYear, disableCode, mouseHtml, DisplayFormat, boxSize, DatePickerConstants.ButtonHeight, DatePickerConstants.ButtonWidth);

            writer.Write (controlHtml);

            return;
        }

        //============================================================
        // Methods
        //============================================================

        protected override string GetFormValue ()
        {
            string value = HttpContext.Current.Request.Form [ClientID];
            if (value != null)
            {
                value = value.Trim ();
            }

            return value;
        }

        protected override string GetDhtmlFileResourceName ()
        {
            return DatePickerConstants.WebKitDhtmlResource;
        }
    }
}