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

namespace OpinionatedGeek.Web.PowerPack
{
    internal class DnsRecord_MX : DnsRecord
    {
        //============================================================
        // Private Data
        //============================================================

        private readonly string _server;

        //============================================================
        // Constructors
        //============================================================

        public DnsRecord_MX (ICloneable server)
        {
            _server = (string) server.Clone ();

            return;
        }

        //============================================================
        // Properties
        //============================================================
        public string Server
        {
            get
            {
                return _server;
            }
        }
    }
}