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
    [ParseChildren (false)]
    internal class IE5ComboBoxField : DefaultComboBoxField
    {
        //============================================================
        // Private Data
        //============================================================

        private const string InitialisationCodeTemplate = @"
	var txtTextbox = document.getElementById ('{1}');
	var ddDropdown = document.getElementById ('{0}');
	if (ddDropdown != null)
	{{
		initializeField_cb_opgeek (txtTextbox, ddDropdown);
	}}
";

        //============================================================
        // Constructors
        //============================================================

        public IE5ComboBoxField ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        //============================================================
        // Events
        //============================================================

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            PowerPack.EnsureIdSet (this);

            return;
        }

        protected override void OnPreRender (EventArgs e)
        {
            base.OnPreRender (e);

            string initialisationCode = String.Format (Globalisation.GetCultureInfo (), InitialisationCodeTemplate, Parent.ClientID, ClientID);
            Page.ClientScript.RegisterStartupScript (typeof (IE5ComboBoxField), UniqueID, BuildClientScriptBlock (initialisationCode));

            return;
        }

        //============================================================
        // Methods
        //============================================================

        public override void SetDhtmlStyle ()
        {
            return;
        }

        protected override void Render (HtmlTextWriter writer)
        {
            if (Visible)
            {
                base.Render (writer);
            }

            return;
        }

        public override void AddAttributes (AttributeCollection attributes)
        {
            attributes.Add ("onchange", "return dropdownChangeHandler_cb_opgeek ('" + ClientID + "')");

            return;
        }

        public override void RenderMidText (HtmlTextWriter writer)
        {
            return;
        }

        protected override string GetDhtmlFileResourceName ()
        {
            return ComboBoxConstants.IE5DhtmlResource;
        }
    }
}