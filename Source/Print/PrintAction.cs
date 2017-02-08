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

using System.Web.UI;

namespace OpinionatedGeek.Web.PowerPack
{
    internal static class PrintAction
    {
        //============================================================
        // Private Data
        //============================================================

        private const string PrintActionScript = "window.print (); return false;";
        private const string OnStartupActionName = "PrintAction_opgeek";
        private const string OnStartupAction = @"
	<script language=""javascript"">
		window.print ();
	</script>";

        //============================================================
        // Constructors
        //============================================================

        //============================================================
        // Events
        //============================================================

        //============================================================
        // Methods
        //============================================================

        public static void AddAttributes (AttributeCollection attributes)
        {
            AddAttributes ("onclick", attributes);

            return;
        }

        public static void AddAttributes (string @event, AttributeCollection attributes)
        {
            attributes.Add (@event, PrintActionScript);

            return;
        }

        public static void RegisterStartupScript (Page page)
        {
            page.ClientScript.RegisterStartupScript (typeof (PrintAction), OnStartupActionName, OnStartupAction);

            return;
        }
    }
}