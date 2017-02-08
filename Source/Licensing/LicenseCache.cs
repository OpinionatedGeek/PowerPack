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

using System.Collections;
using System.Collections.Generic;

namespace OpinionatedGeek.Web.PowerPack.Licensing
{
    /// <summary>
    /// Ignored
    /// </summary>
    internal class LicenseCache
    {
        //============================================================
        // Private Data
        //============================================================

        private readonly ArrayList _licenses;
        private readonly ArrayList _storedLicenseData;

        //============================================================
        // Singleton!
        //============================================================

        private static readonly LicenseCache _licenseCache = new LicenseCache ();

        public static LicenseCache GetLicenseCache (string[] originalLicenses)
        {
            if (!_licenseCache.IsCachedLicenseData (originalLicenses))
            {
                _licenseCache.Load (originalLicenses);
            }

            return _licenseCache;
        }

        //============================================================
        // Constructors
        //============================================================

        private LicenseCache ()
        {
            _licenses = new ArrayList ();
            _storedLicenseData = new ArrayList ();

            return;
        }

        //============================================================
        // Properties
        //============================================================

        private bool IsCachedLicenseData (string[] dataToCompare)
        {
            bool isCached = false;
            foreach (string[] cachedData in _storedLicenseData)
            {
                if (CompareLicenseData (dataToCompare, cachedData))
                {
                    isCached = true;
                }
            }

            return isCached;
        }

        //============================================================
        // Methods
        //============================================================

        public bool IsServerLicensedForProduct (string hostname, string machineName, string product, string version)
        {
            bool isLicensed = false;

            License license;
            for (int licenseCounter = 0; (!isLicensed) && (licenseCounter < _licenses.Count); licenseCounter++)
            {
                license = (License) _licenses [licenseCounter];
                if ((license.IsProduct (product)) && (license.IsVersion (version)))
                {
                    if (license.HasEmbeddedLicense ())
                    {
                        isLicensed = true;
                    }
                    else
                    {
                        isLicensed = license.HasServerLicense () ? license.IsServerLicensed (machineName) : license.IsWebsiteLicensed (hostname);
                    }
                }
            }

            return isLicensed;
        }

        private void LoadLicense (string licenseData)
        {
            var license = new License (licenseData);

            if (license.Verify ())
            {
                _licenses.Add (license);
            }

            return;
        }

        private void Load (IEnumerable<string> licenseData)
        {
            if (licenseData != null)
            {
                foreach (string individualLicense in licenseData)
                {
                    LoadLicense (individualLicense);
                }

                _storedLicenseData.Add (licenseData);
            }

            return;
        }

        private static bool CompareLicenseData (string[] licenseData1, string[] licenseData2)
        {
            bool dataIsSame = true;
            if ((licenseData1 == null) || (licenseData2 == null))
            {
                if ((licenseData1 != null) || (licenseData2 != null))
                {
                    dataIsSame = false;
                }
            }
            else if (licenseData1.Length != licenseData2.Length)
            {
                dataIsSame = false;
            }
            else
            {
                for (int licenseDataCounter = 0; licenseDataCounter < licenseData1.Length; licenseDataCounter++)
                {
                    if (licenseData1 [licenseDataCounter] != licenseData2 [licenseDataCounter])
                    {
                        dataIsSame = false;
                    }
                }
            }

            return dataIsSame;
        }
    }
}