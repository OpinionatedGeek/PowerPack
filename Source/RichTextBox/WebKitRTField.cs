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
    internal class WebKitRTField : WysiwygRTField
    {
        //============================================================
        // Private Data
        //============================================================

        private const string GetTextBoxKey = "GenericGetRichTextBox";
        private const string PromptScriptKey = "PromptInRichTextBox";
        private const string WebKitGetTextBox = @"<script language=""Javascript"">
		function getTextBox_tb_opgeek
		(
			strInstanceName
		)
		{
			return document.getElementById (strInstanceName);
		}
		</script>";
        private const string PromptScript = @"<script language=""Javascript"">
		function ClearTextField_rtb_opgeek
		(
			field,
			prompt,
			realText
		)
		{
			if ((document.readyState == ""complete"") && (document.getElementById (field.id).contentWindow.document.body.innerText == prompt) && (prompt != realText))
			{
				document.getElementById (field.id).contentWindow.document.body.innerHTML = realText;
			}

			return;
		}
		</script>";

        private bool _promptRequired;

        //============================================================
        // Constructors
        //============================================================

        public WebKitRTField (RichTextBox controller)
            : base (controller)
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
        // Methods
        //============================================================

        protected override string GetFontColorSelector ()
        {
            var colorOptions = new StringBuilder ("");
            const string ColorOptionTemplate = "<option value=\"{0}\" style=\"color: {1}{2};\"{3}>A&nbsp;</option>";
            for (int colorCounter = 0; colorCounter < _fontColorList.Length; colorCounter++)
            {
                string selectedMoniker = (_fontColorList [colorCounter] == "Black" ? " selected" : "");
                string backgroundColor = (_fontColorList [colorCounter] == "White" ? "; background-color: Black" : "");
                string colorOption = String.Format (Globalisation.GetCultureInfo (), ColorOptionTemplate, _fontColorList [colorCounter], _fontColorList [colorCounter], backgroundColor, selectedMoniker);
                colorOptions.Append (colorOption);
            }

            const string ColorSelectorTemplate = "<select name=\"{0}ForeColor\" id=\"{0}ForeColor\" tabindex=\"1\" onchange=\"setFontColor_rtb_opgeek ('{0}'); return false;\" style=\"background-color: white; font-style: italic; font-weight: bold; width: 45px; font-size: 11px;\">{1}</select>";
            string colorSelector = String.Format (Globalisation.GetCultureInfo (), ColorSelectorTemplate, _controller.UniqueID, colorOptions);

            return colorSelector;
        }

        protected override string GetFontSizeSelector ()
        {
            var fontSizeSelectionOptions = new StringBuilder ("");
            const string FontSizeSelectorOptionTemplate = "<option value=\"{0}\"{2}>{1}</option>";
            for (int fontSizeCounter = 1; fontSizeCounter < 8; fontSizeCounter++)
            {
                string pointSize = "" + (6 + (2 * fontSizeCounter)) + "pt";
                string selectedMoniker = "";
                if (Normaliser.StringCompare (_controller.ControlStyle.Font.Size.Unit, pointSize))
                {
                    selectedMoniker = " selected";
                }
                string fontSizeSelectorOption = String.Format (Globalisation.GetCultureInfo (), FontSizeSelectorOptionTemplate, fontSizeCounter, pointSize, selectedMoniker);
                fontSizeSelectionOptions.Append (fontSizeSelectorOption);
            }

            const string FontSizeSelectorTemplate = "<select name=\"{0}FontSize\" id=\"{0}FontSize\" tabindex=\"1\" onchange=\"setFontSize_rtb_opgeek ('{0}'); return false;\" style=\"font-size: 10px; width: 50;\">{1}</select>";
            string fontSizeSelector = String.Format (Globalisation.GetCultureInfo (), FontSizeSelectorTemplate, _controller.UniqueID, fontSizeSelectionOptions);

            return fontSizeSelector;
        }

        protected override string GetFontNameSelector ()
        {
            var fontSelectionOptions = new StringBuilder ("");
            const string FontSelectorOptionTemplate = "<option value=\"{0}\"{2}>{1}</option>";
            for (int fontCounter = 0; fontCounter < _fontNameList.Length; fontCounter++)
            {
                string selectedMoniker = "";
                if (Normaliser.StringCompare (_controller.ControlStyle.Font.Name, _fontTitleList[fontCounter]))
                {
                    selectedMoniker = " selected";
                }
                string fontSelectorOption = String.Format (Globalisation.GetCultureInfo (), FontSelectorOptionTemplate, _fontNameList [fontCounter], _fontTitleList [fontCounter], selectedMoniker);
                fontSelectionOptions.Append (fontSelectorOption);
            }

            const string FontSelectorTemplate = "<select name=\"{0}FontName\" id=\"{0}FontName\" tabindex=\"1\" onchange=\"setFontName_rtb_opgeek ('{0}'); return false;\" style=\"font-size: 10px; width: 80;\">{1}</select>";
            string fontNameSelector = String.Format (Globalisation.GetCultureInfo (), FontSelectorTemplate, _controller.UniqueID, fontSelectionOptions);

            return fontNameSelector;
        }

        protected override string GetBackgroundColorSelector ()
        {
            var colorOptions = new StringBuilder ("");
            const string ColorOptionTemplate = "<option value=\"{0}\" style=\"background-color: {1};\"{2}>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>";
            colorOptions.Append ("<option value=\"transparent\" style=\"background-color: transparent; font-style: italic;\">&nbsp;Transparent&nbsp;&nbsp;</option>");
            for (int colorCounter = 0; colorCounter < _fontColorList.Length; colorCounter++)
            {
                string selectedMoniker = (_fontColorList [colorCounter] == "White" ? " selected" : "");
                string colorOption = String.Format (Globalisation.GetCultureInfo (), ColorOptionTemplate, _fontColorList [colorCounter], _fontColorList [colorCounter], selectedMoniker);
                colorOptions.Append (colorOption);
            }

            const string ColorSelectorTemplate = "<select name=\"{0}BackColor\" id=\"{0}BackColor\" tabindex=\"1\" onchange=\"setBackColor_rtb_opgeek ('{0}'); return false;\" style=\"width: 85px; font-size: 10px; \">{1}</select>";
            string colorSelector = String.Format (Globalisation.GetCultureInfo (), ColorSelectorTemplate, _controller.UniqueID, colorOptions);

            return colorSelector;
        }

        protected override string GetEditFrame ()
        {
            const string FrameTemplate = "\n<textarea name=\"{1}\" id=\"{0}\" cols=\"40\" rows=\"15\" style=\"display: none;\">{3}</textarea>\n<iframe name=\"{1}FrameName\" id=\"{1}FrameID\" style=\"{5}{6}{7}; width: 100%; height: 100%;\" class=\"{2}\" contentEditable=\"true\"></iframe><br /><div id=\"{1}ContentID\" style=\"display: none\"><div style=\"{7}\">{3}</div></div><div id=\"{1}PromptID\" style=\"display: none\">{4}</div>";

            const string colorTemplate = "#{0:x2}{1:x2}{2:x2}";
            string foreColor = String.Empty;
            if (!_controller.ControlStyle.ForeColor.IsEmpty)
            {
                foreColor = "color: " + String.Format (Globalisation.GetCultureInfo (), colorTemplate, _controller.ControlStyle.ForeColor.R, _controller.ControlStyle.ForeColor.G, _controller.ControlStyle.ForeColor.B);
            }

            string backColor = String.Empty;
            if (!_controller.ControlStyle.BackColor.IsEmpty)
            {
                backColor = "background-color: " + String.Format (Globalisation.GetCultureInfo (), colorTemplate, _controller.ControlStyle.BackColor.R, _controller.ControlStyle.BackColor.G, _controller.ControlStyle.BackColor.B);
            }

            string style = GetStyleString ();
            string prompt = (ControlHelper.IsPostBack ? String.Empty : "<div style=\"" + style + "\">" + _controller.Prompt + "</div>");

            string frame = String.Format (Globalisation.GetCultureInfo (), FrameTemplate, _controller.ClientID, _controller.UniqueID, _controller.CssClass, _controller.Text, prompt, foreColor, backColor, style);

            return frame;
        }

        protected override string GetEditorActivator ()
        {
            var activation = new StringBuilder ("");

            const string ActivationTemplate = @"
	activateField_rtb_opgeek ('{0}', {6});
	{1}
	finaliseFieldReadiness_rtb_opgeek ('{0}', '{2}', '{3}', '{4}', '{5}');
";

            string activationCode = @"
	function showContextMenu_{0}_rtb_opgeek (eventArgs)
	{{
		showContextMenu_rtb_opgeek ('{1}', eventArgs);
		return true;
	}}

	function setState_{0}_rtb_opgeek ()
	{{
		setState_rtb_opgeek ('{1}');
		return true;
	}}

	function clearPrompt_{0}_rtb_opgeek ()
	{{
		clearPrompt_rtb_opgeek ('{1}');
		return true;
	}}

	function handleKeyPress_{0}_rtb_opgeek (eventArgs)
	{{
		handleKeyPress_rtb_opgeek ('{1}', eventArgs);
		return true;
	}}

";

            string text = SafeContents;
            if (_promptRequired)
            {
                text = _controller.Prompt;
            }

            const string setupTemplate = @"
	var editControl_{0}_rtb_opgeek = document.getElementById ('{1}FrameID').contentWindow;
	editControl_{0}_rtb_opgeek.addEventListener ('beforeeditfocus', setState_{0}_rtb_opgeek, true);
	editControl_{0}_rtb_opgeek.addEventListener ('keyup', setState_{0}_rtb_opgeek, true);
	editControl_{0}_rtb_opgeek.addEventListener ('keydown', setState_{0}_rtb_opgeek, true);
	editControl_{0}_rtb_opgeek.addEventListener ('keypress', handleKeyPress_{0}_rtb_opgeek, true);
	editControl_{0}_rtb_opgeek.addEventListener ('selectionchange', setState_{0}_rtb_opgeek, true);
	editControl_{0}_rtb_opgeek.addEventListener ('propertychange', setState_{0}_rtb_opgeek, true);
	editControl_{0}_rtb_opgeek.addEventListener ('contextmenu', showContextMenu_{0}_rtb_opgeek, true);
	editControl_{0}_rtb_opgeek.addEventListener ('click', hideAllContextMenus_rtb_opgeek, true);
	editControl_{0}_rtb_opgeek.addEventListener ('click', setState_{0}_rtb_opgeek, true);
	editControl_{0}_rtb_opgeek.addEventListener ('focus', clearPrompt_{0}_rtb_opgeek, true);
";

            string foreColor = GetForeColor ();
            string backColor = GetBackColor ();

            if (_controller.Enabled)
            {
                activationCode = String.Format (Globalisation.GetCultureInfo (), ActivationTemplate, _controller.UniqueID, activationCode, _controller.ControlStyle.Font.Name, _controller.ControlStyle.Font.Size, foreColor, backColor, (_controller.GrabFocus ? "true" : "false"));
            }

            activation.Append ("<script type=\"text/javascript\" type=\"text/javascript\">\n");
            activation.Append (activationCode);
            activation.Append (setupTemplate);
            activation.Append ("</script>\n");

            string editorActivator = String.Format (Globalisation.GetCultureInfo (), activation.ToString (), _controller.ClientID, _controller.UniqueID, text, foreColor, backColor, _controller.ControlStyle.Font.Name, _controller.ControlStyle.Font.Size);

            return editorActivator;
        }

        protected override string GetDhtmlFileResourceName ()
        {
            return RTConstants.WebKitDhtmlResource;
        }

        protected override string GetButtonDown ()
        {
            return _controller.Page.ClientScript.GetWebResourceUrl (typeof (WebKitRTField), RTConstants.ButtonDownOverlayResource);
        }

        protected override string GetButtonUp ()
        {
            return _controller.Page.ClientScript.GetWebResourceUrl (typeof (WebKitRTField), RTConstants.ButtonUpOverlayResource);
        }

        protected override string GetImagePrepopulation ()
        {
            const string ImageTemplate = "<img src=\"{0}\" style=\"display: none\" />";

            string normal = String.Format (Globalisation.GetCultureInfo (), ImageTemplate, GetButtonNormal ());
            string up = String.Format (Globalisation.GetCultureInfo (), ImageTemplate, GetButtonUp ());
            string down = String.Format (Globalisation.GetCultureInfo (), ImageTemplate, GetButtonDown ());

            return normal + up + down;
        }

        public override void PromptScriptRequired ()
        {
            Controller.Page.ClientScript.RegisterClientScriptBlock (typeof (WebKitRTField), PromptScriptKey, PromptScript);
            Controller.Page.ClientScript.RegisterClientScriptBlock (typeof (WebKitRTField), GetTextBoxKey, WebKitGetTextBox);
            _promptRequired = true;

            return;
        }

        public override string GetHiddenFieldText ()
        {
            // In Firefox, a blank entry needs to look something like:
            // <div style="font-family: Helvetica; font-size: 12pt;"></div>
            const string TextTemplate = "<div style=\"{1}\">{0}</div>";
            string style = GetStyleString ();

            return String.Format (TextTemplate, _controller.BaseText, style);
        }

        private string GetStyleString ()
        {
            return "font-family: " + _controller.Font.Name + "; font-size: " + _controller.Font.Size + ";";
        }
    }
}