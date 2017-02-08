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

namespace OpinionatedGeek.Web.PowerPack.Licensing
{
    /// <summary>
    /// Ignored
    /// </summary>
    internal class PrintLinkButtonLicenseProvider : PowerPackLicenseProvider
    {
        //============================================================
        // Private Data
        //============================================================

        private const string AlternativeProductName = "PowerPackPrintLinkButton";

        //============================================================
        // Constructors
        //============================================================

        /// <summary>
        /// Ignored
        /// </summary>
        public PrintLinkButtonLicenseProvider ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        //============================================================
        // Methods
        //============================================================

        /// <summary>
        /// Ignored
        /// </summary>
        protected override bool IsLicensed (string hostname, string machinename, string product, string version)
        {
            return base.IsLicensed (hostname, machinename, product, version) || base.IsLicensed (hostname, machinename, AlternativeProductName, version);
        }
    }
}