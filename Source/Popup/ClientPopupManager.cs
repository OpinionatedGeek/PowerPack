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
using System.Web.UI.WebControls;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class ClientPopupManager
    {
        //============================================================
        // Private Data
        //============================================================

        //============================================================
        // Constructors
        //============================================================

        private ClientPopupManager ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        //============================================================
        // Methods
        //============================================================

        public static void RegisterStartupScripts (Page currentPage)
        {
            const string scripts = "<script type=\"text/javascript\">\nfunction PopupAlert_cpm_opgeek (szPopup)\n{\n\treturn alert (szPopup);\n}\n\nfunction PopupConfirm_cpm_opgeek (szPopup)\n{\n\treturn confirm (szPopup);\n}\n</script>";
            currentPage.ClientScript.RegisterStartupScript (typeof (ClientPopupManager), PopupConstants.UniqueCodeBlockName, scripts);

            return;
        }

        public static void AddEvent (WebControl currentControl, bool alertOnly, string popupMessage)
        {
            string normalisedMessage = popupMessage.Replace ("\"", "'");
            if (alertOnly)
            {
                currentControl.Attributes.Add ("onclick", "return PopupAlert_cpm_opgeek (\"" + normalisedMessage + "\")");
            }
            else
            {
                currentControl.Attributes.Add ("onclick", "return PopupConfirm_cpm_opgeek (\"" + normalisedMessage + "\")");
            }

            return;
        }

        public static void AddStartupEvent (WebControl currentControl, string popupMessage)
        {
            string normalisedMessage = popupMessage.Replace ("\"", "'");
            string startupScript = "<script type=\"text/javascript\">\nPopupAlert_cpm_opgeek (\"" + normalisedMessage + "\")\n</script>";
            currentControl.Page.ClientScript.RegisterStartupScript (typeof (ClientPopupManager), PopupConstants.UniqueCodeBlockName + currentControl.ClientID, startupScript);

            return;
        }
    }
}