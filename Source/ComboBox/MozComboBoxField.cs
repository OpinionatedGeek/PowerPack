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
using System.Web.UI.WebControls;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class MozComboBoxField : DefaultComboBoxField
    {
        //============================================================
        // Private Data
        //============================================================

        private const string InitialisationCodeTemplate = @"
	var txtTextbox = document.getElementById ('{1}');
	var ddDropdown = document.getElementById ('{0}');
	initializeField_cb_opgeek (txtTextbox, ddDropdown);
";

        //============================================================
        // Constructors
        //============================================================

        public MozComboBoxField ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        public override bool AutoPostBack
        {
            get
            {
                return false;
            }
// ReSharper disable ValueParameterNotUsed
            set
// ReSharper restore ValueParameterNotUsed
            {
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

        protected override void OnPreRender (EventArgs e)
        {
            base.OnPreRender (e);

            string initialisationCode = String.Format (Globalisation.GetCultureInfo (), InitialisationCodeTemplate, Parent.ClientID, ClientID);
            Page.ClientScript.RegisterStartupScript (typeof (MozComboBoxField), UniqueID, BuildClientScriptBlock (initialisationCode));

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
                writer.Write ("<div>");
                base.Render (writer);
                writer.Write ("</div>");
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

        public override void RenderBeforeControl (HtmlTextWriter writer)
        {
            string width = "";
            if (ParentComboBox.Width.Type == UnitType.Percentage)
            {
                width = " width: " + ParentComboBox.Width + ";";
                ParentComboBox.Width = Unit.Percentage (100);
            }

            writer.Write ("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"display: inline; margin: 0px; padding: 0px; vertical-align: -6px;" + width + ";");

            string positionName = CssHelper.GetCaseInsensitiveName (Style, "POSITION");
            if ((positionName != null) && (Style [positionName] != null))
            {
                writer.Write (positionName);
                writer.Write (": ");
                writer.Write (Style [positionName]);
                writer.Write (";");
            }

            string leftName = CssHelper.GetCaseInsensitiveName (Style, "LEFT");
            if ((leftName != null) && (Style [leftName] != null))
            {
                writer.Write (leftName);
                writer.Write (": ");
                writer.Write (Style [leftName]);
                writer.Write (";");
                Style.Remove (leftName);
            }

            string topName = CssHelper.GetCaseInsensitiveName (Style, "TOP");
            if ((topName != null) && (Style [topName] != null))
            {
                writer.Write (topName);
                writer.Write (": ");
                writer.Write (Style [topName]);
                writer.Write (";");
                Style.Remove (topName);
            }

            writer.Write ("\"><tr><td width=\"100%\"><div style=\"position: relative;\">");

            return;
        }

        public override void RenderAfterControl (HtmlTextWriter writer)
        {
            writer.Write ("</div></td></tr></table>");

            return;
        }

        protected override string GetDhtmlFileResourceName ()
        {
            return ComboBoxConstants.MozDhtmlResource;
        }
    }
}