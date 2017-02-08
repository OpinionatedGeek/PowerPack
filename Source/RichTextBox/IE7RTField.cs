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
    internal class IE7RTField : WysiwygRTField
    {
        //============================================================
        // Private Data
        //============================================================

        private bool _promptRequired;
        private const string GetTextBoxKey = "GenericGetRichTextBox";
        private const string PromptScriptKey = "PromptInRichTextBox";
        private const string IeGetTextBox = @"<script language=""Javascript"">
		function getRichTextBox_tb_opgeek
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
			if ((document.readyState == ""complete"") && (frames [field.id].document.body.innerText == prompt) && (prompt != realText))
			{
				frames [field.id].document.body.innerHTML = realText;
			}

			return;
		}
		</script>";

        //============================================================
        // Constructors
        //============================================================

        public IE7RTField (RichTextBox rtController)
            : base (rtController)
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

        protected override string GetRectangle (string top, string right, string bottom, string left)
        {
            return String.Format (Globalisation.GetCultureInfo (), "rect ({0} {1} {2} {3})", top, right, bottom, left);
        }

        protected override string GetBackgroundColorSelector ()
        {
            var colorOptions = new StringBuilder ();
            const string ColorOptionTemplate = "<option value=\"{0}\" style=\"background-color: {1};\"{2}>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>";
            colorOptions.Append ("<option value=\"transparent\" style=\"background-color: transparent; font-style: italic;\">&nbsp;Transparent&nbsp;&nbsp;</option>");
            for (int nColorCounter = 0; nColorCounter < _fontColorList.Length; nColorCounter++)
            {
                string selectedMoniker = (_fontColorList [nColorCounter] == "White" ? " selected" : "");
                string colorOption = String.Format (Globalisation.GetCultureInfo (), ColorOptionTemplate, _fontColorList [nColorCounter], _fontColorList [nColorCounter], selectedMoniker);
                colorOptions.Append (colorOption);
            }

            const string ColorSelectorTemplate = "<select name=\"{0}BackColor\" id=\"{0}BackColor\" tabindex=\"-1\" onchange=\"setBackColor_rtb_opgeek ('{0}'); return false;\" style=\"width: 85px; font-size: 10px; \">{1}</select>";
            string colorSelector = String.Format (Globalisation.GetCultureInfo (), ColorSelectorTemplate, _controller.UniqueID, colorOptions);

            return colorSelector;
        }

        protected override string GetEditFrame ()
        {
            const string FrameTemplate = "\n<textarea name=\"{1}\" id=\"{0}\" cols=40 rows=15 style=\"display: none\">{3}</textarea>\n<iframe src=\"{4}\" contentEditable=true name=\"{1}FrameName\" id=\"{1}FrameID\" width=\"{5}\" height=\"{6}\" style=\"{8}{9}\" class=\"{2}\"></iframe><br /><div id=\"{1}ContentID\" style=\"display: none\"><div style=\"{10}\">{3}</div></div><div id=\"{1}PromptID\" style=\"display: none\">{7}</div>";
            const string ColorTemplate = "#{0:x2}{1:x2}{2:x2}; ";
            string foreColor = String.Empty;
            if (!_controller.ControlStyle.ForeColor.IsEmpty)
            {
                foreColor = "color: " + String.Format (Globalisation.GetCultureInfo (), ColorTemplate, _controller.ControlStyle.ForeColor.R, _controller.ControlStyle.ForeColor.G, _controller.ControlStyle.ForeColor.B);
            }

            string backColor = String.Empty;
            if (!_controller.ControlStyle.BackColor.IsEmpty)
            {
                backColor = "background-color: " + String.Format (Globalisation.GetCultureInfo (), ColorTemplate, _controller.ControlStyle.BackColor.R, _controller.ControlStyle.BackColor.G, _controller.ControlStyle.BackColor.B);
            }

            string style = GetStyleString ();
            string prompt = "";
            if (!String.IsNullOrEmpty (_controller.Prompt))
            {
                prompt = (_controller.Page.IsPostBack ? String.Empty : "<div style=\"" + style + "\">" + _controller.Prompt + "</div>");
            }

            string frame = String.Format (Globalisation.GetCultureInfo (), FrameTemplate, _controller.ClientID, _controller.UniqueID, _controller.CssClass, _controller.Text, _controller.InitialPage, GetWidth (), GetHeight () - ToolbarControlHeight, prompt, foreColor, backColor, style);

            return frame;
        }

        protected override string GetEditorActivator ()
        {
            var activation = new StringBuilder ();

            const string ActivationTemplate = @"
	activateField_rtb_opgeek ('{0}', '{2}');
	{1}
";

            string activationCode = @"
	function showContextMenu_{0}_rtb_opgeek ()
	{{
		showContextMenu_rtb_opgeek ('{1}');
		return false;
	}}

	function setState_{0}_rtb_opgeek ()
	{{
		setState_rtb_opgeek ('{1}');
		return true;
	}}

	var editControl_{0}_rtb_opgeek = frames ['{1}FrameID'].document;
";

            const string SetupTemplate = @"

	document.getElementById ('{1}FrameID').onfocus = prepareForSubmission_rtb_opgeek;
	document.getElementById ('{1}FrameID').onblur = prepareForSubmission_rtb_opgeek;
	setFontName_rtb_opgeek ('{1}');
	setFontSize_rtb_opgeek ('{1}');
	finaliseFieldReadiness_rtb_opgeek ('{1}', '{5}', '{6}', '{3}', '{4}');
";

            string text = SafeContents;
            if (_promptRequired)
            {
                text = _controller.Prompt;
            }

            string foreColor = GetForeColor ();
            string backColor = GetBackColor ();

            if (_controller.Enabled)
            {
                activationCode = String.Format (Globalisation.GetCultureInfo (), ActivationTemplate, _controller.UniqueID, activationCode, _controller.GrabFocus);
            }

            activation.Append ("<script type=\"text/javascript\" type=\"text/javascript\">\n");
            activation.Append (activationCode);
            activation.Append (SetupTemplate);
            activation.Append ("</script>\n");

            string editorActivator = String.Format (Globalisation.GetCultureInfo (), activation.ToString (), _controller.ClientID, _controller.UniqueID, text, foreColor, backColor, _controller.ControlStyle.Font.Name, _controller.ControlStyle.Font.Size);

            return editorActivator;
        }

        protected override string GetDhtmlFileResourceName ()
        {
            return RTConstants.IE7DhtmlResource;
        }

        protected override string GetButtonDown ()
        {
            return _controller.Page.ClientScript.GetWebResourceUrl (typeof (IE7RTField), RTConstants.ButtonDownOverlayResource);
        }

        protected override string GetButtonUp ()
        {
            return _controller.Page.ClientScript.GetWebResourceUrl (typeof (IE7RTField), RTConstants.ButtonUpOverlayResource);
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
            Controller.Page.ClientScript.RegisterClientScriptBlock (typeof (IE7RTField), PromptScriptKey, PromptScript);
            Controller.Page.ClientScript.RegisterClientScriptBlock (typeof (IE7RTField), GetTextBoxKey, IeGetTextBox);
            _promptRequired = true;

            return;
        }

        public override string GetHiddenFieldText ()
        {
            // In IE 7, it uppercases some things, so a blank entry needs to look something like:
            // <DIV style="FONT-SIZE: 12pt; FONT-FAMILY: Verdana"></DIV>
            const string TextTemplate = "<DIV style=\"{1}\">{0}</DIV>";
            string style = GetStyleString ();

            return String.Format (TextTemplate, _controller.BaseText, style);
        }

        private string GetStyleString ()
        {
            return "FONT-SIZE: " + _controller.ControlStyle.Font.Size + "; FONT-FAMILY: " + _controller.ControlStyle.Font.Name;
        }
    }
}