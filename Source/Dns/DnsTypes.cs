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

namespace OpinionatedGeek.Web.PowerPack
{
	using System;

    [Flags]
	internal enum DnsTypes : ushort
	{
		A          = 0x0001,
		NS         = 0x0002,
		MD         = 0x0003,
		MF         = 0x0004,
		CName      = 0x0005,
		Soa        = 0x0006,
		MB         = 0x0007,
		MG         = 0x0008,
		MR         = 0x0009,
		Null       = 0x000a,
		Wks        = 0x000b,
		Ptr        = 0x000c,
		HInfo      = 0x000d,
		MInfo      = 0x000e,
		MX         = 0x000f,
		Text       = 0x0010,
		Afsdb      = 0x0012,
		RT         = 0x0015,

		All        = 0x00ff
	}
}
