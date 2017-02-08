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
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class DnsLookup
    {
        //============================================================
        // Private Data
        //============================================================

        private IPAddress _dnsServer;
        private bool _bypassCache;

        //============================================================
        // Constructors
        //============================================================

        //============================================================
        // Properties
        //============================================================

        public IPAddress DnsServer
        {
            set
            {
                _dnsServer = value;

                return;
            }
        }

        public bool BypassCache
        {
            get
            {
                return _bypassCache;
            }
            set
            {
                _bypassCache = value;

                return;
            }
        }

        //============================================================
        // Methods
        //============================================================

        //public List<DnsRecord> LookupAll
        //(
        //    string szDomain
        //)
        //{
        //    return HiddenLookup (ref szDomain, DnsTypes.All, DnsTypes.Standard | DnsTypes.TreatAsFqdn);
        //}

        public List<DnsRecord> LookupMx (string domain)
        {
            return HiddenLookup (domain, DnsTypes.MX, DnsQueryTypes.Standard | DnsQueryTypes.TreatAsFqdn);
        }

        public List<DnsRecord> LookupA (string domain)
        {
            return HiddenLookup (domain, DnsTypes.A, DnsQueryTypes.Standard | DnsQueryTypes.TreatAsFqdn);
        }

        //public List<DnsRecord> Lookup
        //(
        //    string szDomain,
        //    UInt16 dnstype,
        //    UInt32 querytype
        //)
        //{
        //    return HiddenLookup (ref szDomain, dnstype, querytype);
        //}

        private List<DnsRecord> HiddenLookup (string domain, DnsTypes dnstype, DnsQueryTypes querytype)
        {
            List<DnsRecord> records = null;
            try
            {
                UInt32 queryResultsSet = 0;

                if ((BypassCache) || (_dnsServer != null))
                {
                    querytype |= DnsQueryTypes.BypassCache;
                }

                byte[] data = null;
                if (_dnsServer != null)
                {
                    data = new Byte [Marshal.SizeOf (typeof (UInt32)) * 2];
                    var memoryWriter = new BinaryWriter (new MemoryStream (data));
                    memoryWriter.Write ((UInt32) 1);
                    byte [] address = _dnsServer.GetAddressBytes ();
                    memoryWriter.Write (address);
                }

                uint dnsLookupResult = NativeMethods.DnsQuery (domain, (ushort) dnstype, (uint) querytype, data, ref queryResultsSet, 0);
                if (dnsLookupResult == 0)
                {
                    records = new List<DnsRecord> ();
                    var results = new IntPtr (queryResultsSet);

                    do
                    {
                        var response = (ResponseStructure) Marshal.PtrToStructure (results, typeof (ResponseStructure));
                        DnsRecord newRecord = ResponseDecoder.Decode (results.ToInt32 (), ref response);

                        records.Add (newRecord);

                        results = response.next;
                    } while (results.ToInt32 () != 0);

                    if (records.Count > 0)
                    {
                        NativeMethods.DnsRecordListFree (ref queryResultsSet, 1);
                    }
                }
            }
            catch (COMException)
            {
            }

            return records;
        }

//		private IPAddress [] GetSystemDnsServers
//		(
//		)
//		{
//			System.Net.IPAddress[] aipaAddresses = null;
//
//			try 
//			{
//				uint uiBufferLength = 0;
//				byte [] abData = null;
//				int iRetVal = DnsQueryConfig (6, 0, null, 0, null, ref uiBufferLength);
//				if (iRetVal != 0)
//				{
//					throw new IOException ("DnsQueryConfig returned " + iRetVal);
//				}
//
//				abData = new Byte [uiBufferLength];
//				iRetVal = DnsQueryConfig (6, 0, null, 0, abData, ref uiBufferLength);
//				if (iRetVal != 0)
//				{
//					throw new IOException ("DnsQueryConfig returned " + iRetVal);
//				}
//
//				BinaryReader brMemoryReader = new BinaryReader (new MemoryStream (abData));
//				uint uiNumServers = brMemoryReader.ReadUInt32 ();
//				aipaAddresses = new IPAddress [uiNumServers];
//				for (int iServerCount = 0; iServerCount < uiNumServers; iServerCount++)
//				{
//					aipaAddresses [iServerCount] = new IPAddress ((long) brMemoryReader.ReadUInt32 ());
//				}
//			}
//			catch (IOException) 
//			{
//				throw;
//			}
//			catch (Exception ex) 
//			{
//				throw new IOException (ex.Message, ex);
//			}
//
//			return aipaAddresses;
//		}
    }
}