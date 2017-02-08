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
using System.Runtime.InteropServices;

namespace OpinionatedGeek.Web.PowerPack
{
    internal static class ResponseDecoder
    {
        //============================================================
        // Nasty Win32 Interop
        //============================================================

        [StructLayout (LayoutKind.Sequential)]
        private struct DnsDataStructure_A
        {
            public UInt32 uiIpAddress;
        }

        [StructLayout (LayoutKind.Sequential)]
        private struct DnsDataStructure_Mx
        {
            public string szServerName;
            public UInt16 iPreference;
            public UInt16 iPad;
        }

        [StructLayout (LayoutKind.Sequential)]
        private struct DnsDataStructure_Null
        {
            public UInt32 uiByteCount;
            public string szData;
        }

        //============================================================
        // Methods
        //============================================================

        public static DnsRecord Decode (int position, ref ResponseStructure dnsResponse)
        {
            DnsRecord record = null;
            position += Marshal.SizeOf (dnsResponse);

            switch ((DnsTypes) dnsResponse.type)
            {
                case DnsTypes.A:
                    var record_A = (DnsDataStructure_A) Marshal.PtrToStructure (new IntPtr (position), typeof (DnsDataStructure_A));
                    record = new DnsRecord_A (record_A.uiIpAddress);
                    break;

                case DnsTypes.MX:
                case DnsTypes.Afsdb:
                case DnsTypes.RT:
                    var record_MX = (DnsDataStructure_Mx) Marshal.PtrToStructure (new IntPtr (position), typeof (DnsDataStructure_Mx));
                    record = new DnsRecord_MX (record_MX.szServerName);
                    break;

                case DnsTypes.Null:
                    Marshal.PtrToStructure (new IntPtr (position), typeof (DnsDataStructure_Null));
                    record = new DnsRecord_Null ();
                    break;
            }

            return record;
        }
    }
}