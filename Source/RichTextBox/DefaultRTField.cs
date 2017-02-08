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
using System.Web.UI;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class DefaultRTField
    {
        //============================================================
        // Private Data
        //============================================================

        protected RichTextBox _controller;
        private bool _widthExplicitlySet;
        private bool _heightExplicitlySet;
        private bool _rowsExplicitlySet;
        private bool _columnsExplicitlySet;
        private string _fontList = RTConstants.DefaultFontList;

        //============================================================
        // Constructors
        //============================================================

        public DefaultRTField (RichTextBox controller)
        {
            _controller = controller;

            return;
        }

        //============================================================
        // Properties
        //============================================================

        public bool WidthExplicitlySet
        {
            get
            {
                return _widthExplicitlySet;
            }
            set
            {
                _widthExplicitlySet = value;

                return;
            }
        }

        public bool HeightExplicitlySet
        {
            get
            {
                return _heightExplicitlySet;
            }
            set
            {
                _heightExplicitlySet = value;

                return;
            }
        }

        public bool ColumnsExplicitlySet
        {
            get
            {
                return _columnsExplicitlySet;
            }
            set
            {
                _columnsExplicitlySet = value;

                return;
            }
        }

        public bool RowsExplicitlySet
        {
            get
            {
                return _rowsExplicitlySet;
            }
            set
            {
                _rowsExplicitlySet = value;

                return;
            }
        }

        protected RichTextBox Controller
        {
            get
            {
                return _controller;
            }
        }

        public virtual string FontList
        {
            get
            {
                return _fontList;
            }
            set
            {
                _fontList = value;

                return;
            }
        }

        //============================================================
        // Events
        //============================================================

        public virtual void OnInit (EventArgs e)
        {
            return;
        }

        public virtual void OnLoad (EventArgs e)
        {
            return;
        }

        public virtual void OnPreRender (EventArgs e)
        {
            return;
        }

        public virtual void Render (HtmlTextWriter writer)
        {
            const string textareaTemplate = "<textarea name=\"{0}\" id=\"{0}\" {5}{6}{7}rows=\"{3}\" cols=\"{4}\" class=\"{2}\">{1}</textarea>";
            string disableCode = String.Empty;
            if (!_controller.Enabled)
            {
                disableCode = "disabled=\"disabled\" ";
            }

            string onFocus = String.Empty;
            if (_controller.Attributes ["onFocus"] != null)
            {
                onFocus = "onFocus=\"" + _controller.Attributes ["onFocus"] + "\" ";
            }

            string prompt = String.Empty;
            if (_controller.Attributes ["prompt"] != null)
            {
                prompt = "prompt=\"" + _controller.Attributes ["prompt"] + "\" ";
            }

            string textareaHtml = String.Format (Globalisation.GetCultureInfo (), textareaTemplate, _controller.ID, _controller.BaseText, _controller.CssClass, _controller.Rows, _controller.Columns, onFocus, prompt, disableCode);

            writer.Write (textareaHtml);

            return;
        }

        //============================================================
        // Methods
        //============================================================

        public virtual void FocusScriptRequired ()
        {
            return;
        }

        public virtual void PromptScriptRequired ()
        {
            return;
        }

        public virtual string GetHiddenFieldText ()
        {
            return _controller.BaseText;
        }
    }
}