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
using System.Web.UI.Design;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class AutomaticDesigner : ControlDesigner
    {
        //============================================================
        // Private Data
        //============================================================

        //============================================================
        // Constructors
        //============================================================

        public AutomaticDesigner ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        public override bool AllowResize
        {
            get
            {
                return true;
            }
        }

        //============================================================
        // Methods
        //============================================================

        public override string GetDesignTimeHtml ()
        {
            string type = Component.GetType ().Name;
            string name = String.Empty;
            if (Component != null)
            {
                type = Component.GetType ().Name;
                var ctlComponent = (Control) Component;
                name = ctlComponent.ID;
            }

            return "<font color=\"green\">[" + type + " \"" + name + "\"]</font>";
        }

        protected override string GetEmptyDesignTimeHtml ()
        {
            return GetDesignTimeHtml ();
        }

        protected override string GetErrorDesignTimeHtml (Exception e)
        {
            return GetDesignTimeHtml ();
        }
    }
}