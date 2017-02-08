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
using System.Collections;
using System.Text;
using System.Web.UI;

namespace OpinionatedGeek.Web.PowerPack
{
    internal abstract class WysiwygRTField : DefaultRTField
    {
        //============================================================
        // Private Data
        //============================================================

        protected const string UniqueCodeBlockName = "OpinionatedGeekRichTextBox";

        protected const int ToolbarControlHeight = 20;
        private const int Toolbar1TotalWidth = 250;
        private const int Toolbar1DisabledWidth = 250;
        private const int Toolbar2TotalWidth = 250;
        private const int Toolbar2DisabledWidth = 250;

        private const int ButtonWidth = 25;
        private const int SpacerWidth = 5;

        protected string[] _fontNameList = {"Courier, Century", "Helvetica, Arial, sans serif", "Times New Roman, serif", "Verdana, Arial, sans serif"};
        protected string[] _fontTitleList = {"Courier", "Helvetica", "Times", "Verdana"};
        protected readonly string[] _fontColorList = {"#000000", "#800000", "#008000", "#808000", "#000080", "#800080", "#008080", "#808080", "#C0C0C0", "#FF0000", "#00FF00", "#FFFF00", "#0000FF", "#FF00FF", "#00FFFF", "#FFFFFF"};

        //============================================================
        // Constructors
        //============================================================

        protected WysiwygRTField (RichTextBox controller) : base (controller)
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        protected virtual string SafeContents
        {
            get
            {
                var contents = new StringBuilder (_controller.Text);
                contents = contents.Replace ("'", "&#039;");
                contents = contents.Replace ("\"", "&quot;");
                contents = contents.Replace ("\r\n\r\n", "</p><p>");
                contents = contents.Replace ('\r', ' ');
                contents = contents.Replace ('\n', ' ');

                return contents.ToString ();
            }
        }

        public override string FontList
        {
            get
            {
                return base.FontList;
            }
            set
            {
                if (!String.IsNullOrEmpty (value))
                {
                    base.FontList = value;

                    var fontTitles = new ArrayList ();
                    var fontNames = new ArrayList ();
                    foreach (string szFontPair in value.Split (';'))
                    {
                        string[] pair = szFontPair.Split (':');
                        string fontName = pair [0].Trim ();
                        if (!String.IsNullOrEmpty (fontName))
                        {
                            fontTitles.Add (fontName);
                            if (pair.Length > 1)
                            {
                                fontNames.Add (pair [1].Trim ());
                            }
                            else
                            {
                                fontNames.Add (fontName);
                            }
                        }
                    }

                    _fontTitleList = new string[fontTitles.Count];
                    fontTitles.CopyTo (_fontTitleList);
                    _fontNameList = new string[fontNames.Count];
                    fontNames.CopyTo (_fontNameList);
                }

                return;
            }
        }

        //============================================================
        // Events
        //============================================================

        public override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            if (_controller.Style ["background-color"] == null)
            {
                _controller.Style ["background-color"] = "#E0E0E0";
            }

            if (_controller.Style ["border-style"] == null)
            {
                _controller.Style ["border-style"] = "inset";
            }

            if (_controller.Style ["border-color"] == null)
            {
                _controller.Style ["border-color"] = "#999999";
            }

            if (_controller.Style ["border-width"] == null)
            {
                _controller.Style ["border-width"] = "1px";
            }

            string dhtmlResourceName = GetDhtmlFileResourceName ();
            if (!String.IsNullOrEmpty (dhtmlResourceName))
            {
                _controller.Page.ClientScript.RegisterClientScriptResource (typeof (WysiwygRTField), dhtmlResourceName);
            }

            return;
        }

        public override void Render (HtmlTextWriter writer)
        {
            var controlHtml = new StringBuilder ();

            string normalButtonUrl = GetButtonNormal ();
            string upButtonUrl = GetButtonUp ();
            string downButtonUrl = GetButtonDown ();
            string defaultBackgroundUrl = _controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.ToolbarBackgroundResource);
            const string InitialisationTemplate = "<script type=\"text/javascript\" type=\"text/javascript\">\n\tinitializeField_rtb_opgeek (\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\");\n</script>\n";
            string initialisation = String.Format (Globalisation.GetCultureInfo (), InitialisationTemplate, normalButtonUrl, upButtonUrl, downButtonUrl, _controller.UniqueID, _controller.ClientID);
            controlHtml.Append (initialisation);

            var styles = new StringBuilder ();
            foreach (string szStyleKey in _controller.Style.Keys)
            {
                styles.Append (szStyleKey);
                styles.Append (": ");
                styles.Append (_controller.Style [szStyleKey]);
                styles.Append (";");
            }
            const string TableDefinitionTemplate = "<table border=\"0\" width=\"{0}\" cellpadding=\"0\" cellspacing=\"0\" style=\"{1}\" background=\"{2}\">";
            string tableDefinition = String.Format (Globalisation.GetCultureInfo (), TableDefinitionTemplate, GetWidth (), styles, defaultBackgroundUrl);
            controlHtml.Append (tableDefinition);

            string toolbar1;
            int toolbar1Width;
            int toolbar2Width;
            string toolbar2 = GetToolbar2 ();
            string fontSelectors = GetFontNameSelector () + GetFontSizeSelector ();
            string colorSelectors = GetFontColorSelector () + GetBackgroundColorSelector ();
            double selectorWidth;

            string completeToolbarTemplate;
            if (GetWidth () > RTConstants.Threshold1Width)
            {
                completeToolbarTemplate = "<tr style=\"height: 22px;\"><td width=\"{1}\">{0}</td><td width=\"{3}\">{2}</td><td>{4}{5}</td></tr>";
                toolbar1 = GetToolbar1 ();
                toolbar1Width = Toolbar1TotalWidth;
                toolbar2Width = Toolbar2TotalWidth;
                selectorWidth = 0;
            }
            else if (GetWidth () > RTConstants.Threshold2Width)
            {
                int buttonBarWidth = Math.Min (Toolbar1TotalWidth + SpacerWidth, Toolbar2TotalWidth);
                completeToolbarTemplate = "<tr style=\"height: 22px;\"><td width=\"{1}\">{0}</td><td></td><td width=\"{6}\">{4}{5}</td></tr><tr style=\"height: 22px;\"><td width=\"{3}\">{2}</td><td></td><td></td></tr>";
                toolbar1 = GetToolbar1 ();
                toolbar1Width = buttonBarWidth;
                toolbar2Width = buttonBarWidth;
                selectorWidth = GetWidth () - buttonBarWidth;
            }
            else
            {
                int buttonBarWidth = Math.Min (Toolbar1TotalWidth + SpacerWidth, Toolbar2TotalWidth);
                completeToolbarTemplate = "<tr style=\"height: 22px;\"><td width=\"{1}\">{0}</td><td></td><td width=\"{6}\">{4}</td></tr><tr style=\"height: 22px;\"><td width=\"{3}\">{2}</td><td></td><td>{5}</td></tr>";
                toolbar1 = GetToolbar1 ();
                toolbar1Width = buttonBarWidth;
                toolbar2Width = buttonBarWidth;
                selectorWidth = GetWidth () - buttonBarWidth;
            }

            string completeToolbar = String.Format (Globalisation.GetCultureInfo (), completeToolbarTemplate, toolbar1, toolbar1Width, toolbar2, toolbar2Width, fontSelectors, colorSelectors, selectorWidth);
            controlHtml.Append (completeToolbar);

            const string editableRegionTemplate = "<tr bgcolor=\"white\"><td colspan=\"3\">{0}</td></tr></table>";
            string editableRegion = String.Format (Globalisation.GetCultureInfo (), editableRegionTemplate, GetEditFrame ());
            controlHtml.Append (editableRegion);

            controlHtml.Append (GetEditorActivator ());

            controlHtml.Append (GetImagePrepopulation ());

            writer.Write (controlHtml.ToString ());

            return;
        }

        //============================================================
        // Static Methods
        //============================================================

        //============================================================
        // Methods
        //============================================================

        protected virtual string GetRectangle (string top, string right, string bottom, string left)
        {
            return String.Format (Globalisation.GetCultureInfo (), "rect({0}, {1}, {2}, {3})", top, right, bottom, left);
        }

        protected virtual string GetToolbar1 ()
        {
            var toolbar1 = new StringBuilder ();
            toolbar1.Append (GetToolbar1DisabledButton ("Cut", GetRectangle ("auto", "30px", "auto", "5px")));
            toolbar1.Append (GetToolbar1DisabledButton ("Copy", GetRectangle ("auto", "55px", "auto", "30px")));
            toolbar1.Append (GetToolbar1DisabledButton ("Paste", GetRectangle ("auto", "80px", "auto", "55px")));
            toolbar1.Append (GetToolbar1DisabledButton ("Undo", GetRectangle ("auto", "110px", "auto", "85px")));
            toolbar1.Append (GetToolbar1DisabledButton ("Redo", GetRectangle ("auto", "135px", "auto", "110px")));
            toolbar1.Append (GetToolbar1DisabledButton ("Bold", GetRectangle ("auto", "165px", "auto", "140px")));
            toolbar1.Append (GetToolbar1DisabledButton ("Italic", GetRectangle ("auto", "190px", "auto", "165px")));
            toolbar1.Append (GetToolbar1DisabledButton ("Underline", GetRectangle ("auto", "215px", "auto", "190px")));
            toolbar1.Append ("<table background=\"");
            toolbar1.Append (_controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.Toolbar1Resource));
            toolbar1.Append ("\" border=\"0\" width=\"");

            toolbar1.Append (Toolbar1TotalWidth);

            toolbar1.Append ("\" cellpadding=\"0\" cellspacing=\"0\">");
            toolbar1.Append ("<tr>");
            toolbar1.Append ("<td width=\"" + SpacerWidth + "\"></td>");
            toolbar1.Append (GetRegularToolbarButton ("Cut", "Cut"));
            toolbar1.Append (GetRegularToolbarButton ("Copy", "Copy"));
            toolbar1.Append (GetRegularToolbarButton ("Paste", "Paste"));
            toolbar1.Append ("<td width=\"" + SpacerWidth + "\"></td>");
            toolbar1.Append (GetRegularToolbarButton ("Undo", "Undo"));
            toolbar1.Append (GetRegularToolbarButton ("Redo", "Redo"));
            toolbar1.Append ("<td width=\"" + SpacerWidth + "\"></td>");
            toolbar1.Append (GetDependentPushdownToolbarButton ("Bold", "Bold"));
            toolbar1.Append (GetPushdownToolbarButton ("Italic", "Italic"));
            toolbar1.Append (GetPushdownToolbarButton ("Underline", "Underline"));
            toolbar1.Append ("<td width=\"" + SpacerWidth + "\"></td>");
            toolbar1.Append (GetPushdownToolbarButton ("HTML", "Edit raw HTML"));
            toolbar1.Append ("<td width=\"" + SpacerWidth + "\"></td>");

            toolbar1.Append ("</tr></table>");

            return toolbar1.ToString ();
        }

        protected virtual string GetToolbar2 ()
        {
            var toolbar2 = new StringBuilder ();
            toolbar2.Append (GetToolbar2DisabledButton ("JustifyLeft", GetRectangle ("auto", "30px", "auto", "5px")));
            toolbar2.Append (GetToolbar2DisabledButton ("JustifyCenter", GetRectangle ("auto", "55px", "auto", "30px")));
            toolbar2.Append (GetToolbar2DisabledButton ("JustifyRight", GetRectangle ("auto", "80px", "auto", "55px")));
            toolbar2.Append (GetToolbar2DisabledButton ("JustifyFull", GetRectangle ("auto", "105px", "auto", "80px")));

            toolbar2.Append (GetToolbar2DisabledButton ("InsertUnorderedList", GetRectangle ("auto", "135px", "auto", "110px")));
            toolbar2.Append (GetToolbar2DisabledButton ("InsertOrderedList", GetRectangle ("auto", "160px", "auto", "135px")));

            toolbar2.Append (GetToolbar2DisabledButton ("Indent", GetRectangle ("auto", "190px", "auto", "165px")));
            toolbar2.Append (GetToolbar2DisabledButton ("Outdent", GetRectangle ("auto", "215px", "auto", "190px")));

            toolbar2.Append (GetToolbar2DisabledButton ("CreateLink", GetRectangle ("auto", "245px", "auto", "220px")));

            toolbar2.Append ("<table background=\"");
            toolbar2.Append (_controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.Toolbar2Resource));
            toolbar2.Append ("\" border=\"0\" width=\"");
            toolbar2.Append (Toolbar2TotalWidth);
            toolbar2.Append ("\" cellpadding=\"0\" cellspacing=\"0\">");
            toolbar2.Append ("<tr>");
            toolbar2.Append ("<td width=\"" + SpacerWidth + "\"></td>");
            toolbar2.Append (GetDependentPushdownToolbarButton ("JustifyLeft", "Align Left"));
            toolbar2.Append (GetDependentPushdownToolbarButton ("JustifyCenter", "Center"));
            toolbar2.Append (GetDependentPushdownToolbarButton ("JustifyRight", "Align Right"));
            toolbar2.Append (GetDependentPushdownToolbarButton ("JustifyFull", "Justify"));
            toolbar2.Append ("<td width=\"" + SpacerWidth + "\"></td>");
            toolbar2.Append (GetPushdownToolbarButton ("InsertUnorderedList", "Bulleted List"));
            toolbar2.Append (GetPushdownToolbarButton ("InsertOrderedList", "Numbered List"));
            toolbar2.Append ("<td width=\"" + SpacerWidth + "\"></td>");
            toolbar2.Append (GetRegularToolbarButton ("Indent", "Indent"));
            toolbar2.Append (GetRegularToolbarButton ("Outdent", "Outdent"));
            toolbar2.Append ("<td width=\"" + SpacerWidth + "\"></td>");
            toolbar2.Append (GetPushdownToolbarButton ("CreateLink", "Hyperlink"));
            toolbar2.Append ("<td width=\"" + SpacerWidth + "\"></td>");
            toolbar2.Append ("</tr></table>");

            return toolbar2.ToString ();
        }

        protected virtual string GetFontNameSelector ()
        {
            var fontSelectionOptions = new StringBuilder ();
            const string FontSelectorOptionTemplate = "<option value=\"{0}\"{2}>{1}</option>";
            for (int fontCounter = 0; fontCounter < _fontNameList.Length; fontCounter++)
            {
                string selectedMoniker = "";
                if (Normaliser.StringCompare (_controller.ControlStyle.Font.Name, _fontTitleList [fontCounter]))
                {
                    selectedMoniker = " selected";
                }
                string fontSelectorOption = String.Format (Globalisation.GetCultureInfo (), FontSelectorOptionTemplate, _fontNameList [fontCounter], _fontTitleList [fontCounter], selectedMoniker);
                fontSelectionOptions.Append (fontSelectorOption);
            }

            const string FontSelectorTemplate = "<select name=\"{0}FontName\" id=\"{0}FontName\" tabindex=\"-1\" onchange=\"setFontName_rtb_opgeek ('{0}'); return false;\" style=\"font-size: 10px; width: 80;\">{1}</select>";
            string fontSelector = String.Format (Globalisation.GetCultureInfo (), FontSelectorTemplate, _controller.UniqueID, fontSelectionOptions);

            return fontSelector;
        }

        protected virtual string GetFontSizeSelector ()
        {
            var fontSizeSelectionOptions = new StringBuilder ();
            const string FontSizeSelectorOptionTemplate = "<option value=\"{0}\"{2}>{1}</option>";
            for (int fontSizeCounter = 1; fontSizeCounter < 8; fontSizeCounter++)
            {
                string pointSize = "" + (8 + (2 * fontSizeCounter)) + "pt";
                string selectedMoniker = "";
                if (Normaliser.StringCompare (_controller.ControlStyle.Font.Size.Unit, pointSize))
                {
                    selectedMoniker = " selected";
                }
                string fontSizeSelectorOption = String.Format (Globalisation.GetCultureInfo (), FontSizeSelectorOptionTemplate, fontSizeCounter, pointSize, selectedMoniker);
                fontSizeSelectionOptions.Append (fontSizeSelectorOption);
            }

            const string FontSizeSelectorTemplate = "<select name=\"{0}FontSize\" id=\"{0}FontSize\" tabindex=\"-1\" onchange=\"setFontSize_rtb_opgeek ('{0}'); return false;\" style=\"font-size: 10px; width: 50;\">{1}</select>";
            string fontSizeSelector = String.Format (Globalisation.GetCultureInfo (), FontSizeSelectorTemplate, _controller.UniqueID, fontSizeSelectionOptions);

            return fontSizeSelector;
        }

        protected virtual string GetFontColorSelector ()
        {
            var colorOptions = new StringBuilder ();
            const string ColorOptionTemplate = "<option value=\"{0}\" style=\"color: {1}{2};\"{3}>A&nbsp;</option>";
            colorOptions.Append ("<option value=\"transparent\" style=\"color: gray; background-color: lightgray;\">A(f)</option>");
            for (int colorCounter = 0; colorCounter < _fontColorList.Length; colorCounter++)
            {
                string selectedMoniker = (_fontColorList [colorCounter] == "Black" ? " selected" : "");
                string backgroundColor = (_fontColorList [colorCounter] == "White" ? "; background-color: Black" : "");
                string colorOption = String.Format (Globalisation.GetCultureInfo (), ColorOptionTemplate, _fontColorList [colorCounter], _fontColorList [colorCounter], backgroundColor, selectedMoniker);
                colorOptions.Append (colorOption);
            }

            const string ColorSelectorTemplate = "<select name=\"{0}ForeColor\" id=\"{0}ForeColor\" tabindex=\"-1\" onchange=\"setFontColor_rtb_opgeek ('{0}'); return false;\" style=\"background-color: white; font-style: italic; font-weight: bold; width: 45px; font-size: 11px;\">{1}</select>";
            string colorSelector = String.Format (Globalisation.GetCultureInfo (), ColorSelectorTemplate, _controller.UniqueID, colorOptions);

            return colorSelector;
        }

        protected virtual string GetBackgroundColorSelector ()
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

            const string ColorSelectorTemplate = "<select name=\"{0}HiliteColor\" id=\"{0}HiliteColor\" tabindex=\"-1\" onchange=\"setBackColor_rtb_opgeek ('{0}'); return false;\" style=\"width: 85px; font-size: 10px; \">{1}</select>";
            string colorSelector = String.Format (Globalisation.GetCultureInfo (), ColorSelectorTemplate, _controller.UniqueID, colorOptions);

            return colorSelector;
        }

        protected virtual string GetToolbar1DisabledButton (string szButtonName, string szClippingRegion)
        {
            const string ButtonTemplate = "<div id=\"{0}{1}Disabled\" style=\"z-index: 1; position: absolute; overflow: hidden; clip: {2}; display: none;\"><img src=\"{5}\" alt=\"\" width=\"{4}\" height=\"{3}\" /></div>";
            string button = String.Format (Globalisation.GetCultureInfo (), ButtonTemplate, _controller.UniqueID, szButtonName, szClippingRegion, ToolbarControlHeight, Toolbar1DisabledWidth, _controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.Toolbar1DisabledResource));

            return button;
        }

        protected virtual string GetToolbar2DisabledButton (string szButtonName, string szClippingRegion)
        {
            const string ButtonTemplate = "<div id=\"{0}{1}Disabled\" style=\"clip: {2}; z-index: 1; display: none; position: absolute; overflow: hidden;\"><img src=\"{5}\" alt=\"\" width=\"{4}\" height=\"{3}\" /></div>";
            string button = String.Format (Globalisation.GetCultureInfo (), ButtonTemplate, _controller.UniqueID, szButtonName, szClippingRegion, ToolbarControlHeight, Toolbar2DisabledWidth, _controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.Toolbar2DisabledResource));

            return button;
        }

        protected virtual string GetButtonUp ()
        {
            return _controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.ButtonUpResource);
        }

        protected virtual string GetButtonDown ()
        {
            return _controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.ButtonDownResource);
        }

        protected virtual string GetButtonNormal ()
        {
            return _controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.ButtonNormalResource);
        }

        protected virtual string GetImagePrepopulation ()
        {
            return "";
        }

        protected virtual string GetDependentPushdownToolbarButton (string szButtonName, string szButtonTitle)
        {
            const string ButtonTemplate = "<td width=\"{4}\"><img src=\"{5}\" alt=\"{2}\" height=\"{3}\" width=\"{4}\" name=\"{0}{1}\" onclick=\"return handleMouseClick_rtb_opgeek ('{0}', '{1}'); return false;\" onmouseover=\"return handleDependentMouseOver_rtb_opgeek ('{0}', '{1}'); return false;\" onmouseout=\"return handleMouseOut_rtb_opgeek ('{0}', '{1}'); return false;\" /></td>";
            string button = String.Format (Globalisation.GetCultureInfo (), ButtonTemplate, _controller.UniqueID, szButtonName, szButtonTitle, ToolbarControlHeight, ButtonWidth, _controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.ButtonNormalResource));

            return button;
        }

        protected virtual string GetPushdownToolbarButton (string szButtonName, string szButtonTitle)
        {
            const string ButtonTemplate = "<td width=\"{4}\"><img src=\"{5}\" alt=\"{2}\" height=\"{3}\" width=\"{4}\" name=\"{0}{1}\" onclick=\"return handleMouseClick_rtb_opgeek ('{0}', '{1}'); return false;\" onmouseover=\"return handleMouseOver_rtb_opgeek ('{0}', '{1}'); return false;\" onmouseout=\"return handleMouseOut_rtb_opgeek ('{0}', '{1}'); return false;\" /></td>";
            string button = String.Format (Globalisation.GetCultureInfo (), ButtonTemplate, _controller.UniqueID, szButtonName, szButtonTitle, ToolbarControlHeight, ButtonWidth, _controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.ButtonNormalResource));

            return button;
        }

        protected virtual string GetRegularToolbarButton (string szButtonName, string szButtonTitle)
        {
            const string ButtonTemplate = "<td width=\"{4}\"><img src=\"{5}\" alt=\"{2}\" height=\"{3}\" width=\"{4}\" name=\"{0}{1}\" onmousedown=\"handleMouseClick_rtb_opgeek ('{0}', '{1}'); return false;\" onmouseover=\"handleMouseOver_rtb_opgeek ('{0}', '{1}'); return false;\" onmouseup=\"handleMouseUp_rtb_opgeek ('{0}', '{1}'); return false;\" onmouseout=\"handleMouseOut_rtb_opgeek ('{0}', '{1}'); return false;\" /></td>";
            string button = String.Format (Globalisation.GetCultureInfo (), ButtonTemplate, _controller.UniqueID, szButtonName, szButtonTitle, ToolbarControlHeight, ButtonWidth, _controller.Page.ClientScript.GetWebResourceUrl (typeof (WysiwygRTField), RTConstants.ButtonNormalResource));

            return button;
        }

        protected abstract string GetEditFrame ();

        protected abstract string GetEditorActivator ();

        protected double GetWidth ()
        {
            double width;
            if (WidthExplicitlySet)
            {
                width = _controller.Width.Value;
            }
            else if (ColumnsExplicitlySet)
            {
                width = _controller.Columns * RTConstants.TextareaWidthScalingFactor;
                width = (width > RTConstants.MinimumControlWidth ? width : RTConstants.MinimumControlWidth);
            }
            else
            {
                width = _controller.Width.Value;
            }

            return width;
        }

        protected double GetHeight ()
        {
            double height;
            if (HeightExplicitlySet)
            {
                height = _controller.Height.Value;
            }
            else if (RowsExplicitlySet)
            {
                height = _controller.Rows * RTConstants.TextareaHeightScalingFactor;
                height = (height > RTConstants.MinimumControlHeight ? height : RTConstants.MinimumControlHeight);
            }
            else
            {
                height = _controller.Height.Value;
            }

            return height;
        }

        protected string GetForeColor ()
        {
            const string colorTemplate = "#{0:x2}{1:x2}{2:x2}";
            string foreColor = RTConstants.DefaultForeColour;
            if (!_controller.ControlStyle.ForeColor.IsEmpty)
            {
                foreColor = String.Format (Globalisation.GetCultureInfo (), colorTemplate,
                                           _controller.ControlStyle.ForeColor.R,
                                           _controller.ControlStyle.ForeColor.G,
                                           _controller.ControlStyle.ForeColor.B);
            }

            return foreColor;
        }

        protected string GetBackColor ()
        {
            const string colorTemplate = "#{0:x2}{1:x2}{2:x2}";
            string backColor = RTConstants.DefaultBackColour;
            if (!_controller.ControlStyle.BackColor.IsEmpty)
            {
                backColor = String.Format (Globalisation.GetCultureInfo (), colorTemplate,
                                           _controller.ControlStyle.BackColor.R,
                                           _controller.ControlStyle.BackColor.G,
                                           _controller.ControlStyle.BackColor.B);
            }
            return backColor;
        }

        protected abstract string GetDhtmlFileResourceName ();
    }
}