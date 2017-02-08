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
	internal enum DnsQueryTypes : uint
	{
		Standard                = 0x00000000,
		AcceptTruncatedResponse = 0x00000001,
		UseTcpOnly              = 0x00000002,
		NoRecursion             = 0x00000004,
		BypassCache             = 0x00000008,
		CacheOnly               = 0x00000010,
		SocketKeepAlive         = 0x00000100,
		TreatAsFqdn             = 0x00001000,
		AllowEmptyAuthResp      = 0x00010000,
		DontResetTtlValues      = 0x00100000,
		Reserved                = 0xff000000
	}
}
