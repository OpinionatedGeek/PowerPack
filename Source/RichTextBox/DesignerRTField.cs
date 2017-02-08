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

namespace OpinionatedGeek.Web.PowerPack
{
    internal class DesignerRTField : WysiwygRTField
    {
        //============================================================
        // Private Data
        //============================================================

        //============================================================
        // Constructors
        //============================================================

        public DesignerRTField (RichTextBox controller) : base (controller)
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        //============================================================
        // Events
        //============================================================

        //============================================================
        // Static Methods
        //============================================================

        //============================================================
        // Methods
        //============================================================

        protected override string GetRectangle (string top, string right, string bottom, string left)
        {
            return String.Format (Globalisation.GetCultureInfo (), "rect ({0} {1} {2} {3})", top, right, bottom, left);
        }

        protected override string GetBackgroundColorSelector ()
        {
            var colorOptions = new StringBuilder ();
            const string ColorOptionTemplate = "<option value=\"{0}\" style=\"background-color: {1};\"{2}>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>";
            colorOptions.Append ("<option value=\"transparent\" style=\"background-color: transparent; font-style: italic;\">&nbsp;Transparent&nbsp;&nbsp;</option>");
            for (int colorCounter = 0; colorCounter < _fontColorList.Length; colorCounter++)
            {
                string selectedMoniker = (_fontColorList [colorCounter] == "White" ? " selected" : "");
                string colorOption = String.Format (Globalisation.GetCultureInfo (), ColorOptionTemplate, _fontColorList [colorCounter], _fontColorList [colorCounter], selectedMoniker);
                colorOptions.Append (colorOption);
            }

            const string ColorSelectorTemplate = "<select name=\"{0}BackColor\" id=\"{0}BackColor\" tabindex=\"-1\" onchange=\"setBackColor_rtb_opgeek ('{0}'); return false;\" style=\"width: 85px; font-size: 10px; \">{1}</select>";
            string colorSelector = String.Format (Globalisation.GetCultureInfo (), ColorSelectorTemplate, _controller.UniqueID, colorOptions);

            return colorSelector;
        }

        protected override string GetEditFrame ()
        {
            const string FrameTemplate = "<div id=\"{0}\" style=\"width: {2}px; height: {3}px; {4}\">{1}</div>";
            //string szFrameTemplate = "\n<textarea name=\"{1}\" id=\"{0}\" cols=40 rows=15 style=\"display: none\"><div style=\"{10}\">{3}</div></textarea>\n<iframe src=\"{4}\" contentEditable=true name=\"{1}FrameName\" id=\"{1}FrameID\" width=\"{5}\" height=\"{6}\" style=\"{8}{9}\" class=\"{2}\"></iframe><br /><div id=\"{1}ContentID\" style=\"display: none\"><div style=\"{10}\">{3}</div></div><div id=\"{1}PromptID\" style=\"display: none\">{7}</div>";

            const string colorTemplate = "#{0:x2}{1:x2}{2:x2}; ";
            string style = "font-family: " + _controller.Font.Name + "; font-size: " + _controller.Font.Size + ";";
            if (!_controller.ControlStyle.ForeColor.IsEmpty)
            {
                style += "color: " + String.Format (Globalisation.GetCultureInfo (), colorTemplate, _controller.ControlStyle.ForeColor.R, _controller.ControlStyle.ForeColor.G, _controller.ControlStyle.ForeColor.B) + ";";
            }

            if (!_controller.ControlStyle.BackColor.IsEmpty)
            {
                style += "background-color: " + String.Format (Globalisation.GetCultureInfo (), colorTemplate, _controller.ControlStyle.BackColor.R, _controller.ControlStyle.BackColor.G, _controller.ControlStyle.BackColor.B) + ";";
            }

            string frame = String.Format (Globalisation.GetCultureInfo (), FrameTemplate, _controller.ClientID, _controller.Text, GetWidth (), GetHeight () - ToolbarControlHeight, style);

            return frame;
        }

        protected override string GetEditorActivator ()
        {
            return "";
        }

        protected override string GetDhtmlFileResourceName ()
        {
            return RTConstants.IE5DhtmlResource;
        }

        public override void PromptScriptRequired ()
        {
            return;
        }
    }
}