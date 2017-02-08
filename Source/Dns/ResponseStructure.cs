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
    [StructLayout (LayoutKind.Sequential)]
    internal struct ResponseStructure
    {
        public IntPtr next;

        public string name;

        [MarshalAs (UnmanagedType.U2)]
        public UInt16 type;

        [MarshalAs (UnmanagedType.U2)]
        public UInt16 dataLength;

        [MarshalAs (UnmanagedType.U4)]
        public UInt32 flags2;

        [MarshalAs (UnmanagedType.U4)]
        public UInt32 ttl;

        [MarshalAs (UnmanagedType.U4)]
        public UInt32 reserved;
    }
}