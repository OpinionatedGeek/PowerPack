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
using System.Collections.Specialized;
using System.Web.UI;

namespace OpinionatedGeek.Web.PowerPack
{
    [ParseChildren (false)]
    internal class DefaultComboBoxField : System.Web.UI.WebControls.TextBox, IPostBackDataHandler
    {
        //============================================================
        // Private Data
        //============================================================

        private string _midText;
        private ComboBox _parent;

        //============================================================
        // Constructors
        //============================================================

        public DefaultComboBoxField ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        protected ComboBox ParentComboBox
        {
            get
            {
                return _parent;
            }
        }

        public string MidText
        {
            get
            {
                return _midText;
            }
            set
            {
                _midText = value;

                return;
            }
        }

        //============================================================
        // Methods
        //============================================================

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            string dhtmlResourceName = GetDhtmlFileResourceName ();
            if (!String.IsNullOrEmpty (dhtmlResourceName))
            {
                Page.ClientScript.RegisterClientScriptResource (typeof (DefaultComboBoxField), dhtmlResourceName);
            }

            return;
        }

        bool IPostBackDataHandler.LoadPostData (string postDataKey, NameValueCollection postCollection)
        {
            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent ()
        {
            return;
        }

        public virtual void FinaliseAttributes ()
        {
            return;
        }

        internal void SetParentComboBox (ComboBox cbParent)
        {
            _parent = cbParent;

            return;
        }

        public bool InternalLoadPostData (string postDataKey, NameValueCollection postCollection)
        {
            bool loadedNewValue = false;
            string loadedValue = postCollection [postDataKey] ?? "";
            if (Text != loadedValue)
            {
                Text = loadedValue;
                loadedNewValue = true;
            }

            return loadedNewValue;
        }

        protected static string BuildClientScriptBlock (string scriptingCode)
        {
            const string clientScriptBlock = "<script type=\"text/javascript\">{0}</script>\n";

            return string.Format (Globalisation.GetCultureInfo (), clientScriptBlock, scriptingCode);
        }

        public virtual void AddAttributes (AttributeCollection attributes)
        {
            return;
        }

        public virtual void SetDhtmlStyle ()
        {
            if (_parent != null)
            {
                _parent.Style.Remove ("display");
                _parent.Style.Remove ("position");
            }

            return;
        }

        public virtual void RenderMidText (HtmlTextWriter writer)
        {
            if (Visible)
            {
                writer.Write (MidText);
            }

            return;
        }

        public virtual void RenderBeforeControl (HtmlTextWriter writer)
        {
            return;
        }

        public virtual void RenderAfterControl (HtmlTextWriter writer)
        {
            return;
        }

        protected virtual string GetDhtmlFileResourceName ()
        {
            return null;
        }
    }
}