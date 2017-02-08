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
    internal class ValidLicense : System.ComponentModel.License
    {
        //============================================================
        // Private Data
        //============================================================

        //============================================================
        // Constructors
        //============================================================

        //============================================================
        // Properties
        //============================================================

        /// <summary>
        /// Ignored
        /// </summary>
        public override string LicenseKey
        {
            get
            {
                return "";
            }
        }

        ///
        /// <summary>
        /// Enables a server control to perform final clean up before it is released from memory.
        /// </summary>
        /// <remarks>
        /// Call Dispose when you are finished using the Control. The Dispose method leaves the Control in an
        /// unusable state. After calling this method, you must release all references to the control so the
        /// memory it was occupying can be reclaimed by garbage collection.
        /// </remarks>
        ///
        public override sealed void Dispose ()
        {
            Dispose (true);

            return;
        }

        ///
        /// <summary>
        /// Enables a server control to perform final clean up before it is released from
        /// memory.
        /// </summary>
        /// <remarks>
        /// The Dispose method leaves the Control in an unusable state. After calling this
        /// method, you must release all references to the control so the memory it was
        /// occupying can be reclaimed by garbage collection.
        /// </remarks>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources; <b>false</b> to release only unmanaged resources.</param>
        ///
        protected virtual void Dispose (bool disposing)
        {
            return;
        }
    }
}