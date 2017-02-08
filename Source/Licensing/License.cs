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
using System.Security.Cryptography;
using System.Text;

namespace OpinionatedGeek.Web.PowerPack.Licensing
{
    /// <summary>
    /// Ignored
    /// </summary>
    internal class License
    {
        //============================================================
        // Private Data
        //============================================================

        private const string FieldSeparator = ";";
        private const string TitleValueSeparator = ":";
        private const string MultivalueSeparator = ",";
        private const string AllHosts = "*";
        public const string DataSignatureSeparator = "~";

        private const string PublicKey = ""; // Removed from 2017 publication.

        private readonly string _license;
        private string[] _products;
        private string[] _versions;
        private string[] _hosts;
        private string[] _servers;
        private string[] _licenseTypes;
        //private string [] _ids;
        //private string [] _vendors;
        //private string [] _purchasers;

        //============================================================
        // Constructors
        //============================================================

        public License (string license)
        {
            _license = license.Trim ();

            Decode (_license);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        public string[] Products
        {
            get
            {
                return _products;
            }
        }

        public string[] Versions
        {
            get
            {
                return _versions;
            }
        }

        public string[] Hosts
        {
            get
            {
                return _hosts;
            }
        }

        public string[] Servers
        {
            get
            {
                return _servers;
            }
        }

        public string[] LicenseTypes
        {
            get
            {
                return _licenseTypes;
            }
        }

        //public string [] Ids
        //{
        //    get
        //    {
        //        return _ids;
        //    }
        //}

        //public string [] Vendors
        //{
        //    get
        //    {
        //        return _vendors;
        //    }
        //}

        //public string [] Purchasers
        //{
        //    get
        //    {
        //        return _purchasers;
        //    }
        //}

        //============================================================
        // Methods
        //============================================================

        public bool HasEmbeddedLicense ()
        {
            return HasLicenseType ("embedded");
        }

        public bool HasServerLicense ()
        {
            return HasLicenseType ("server");
        }

        //public bool HasWebsiteLicense ()
        //{
        //    return HasLicenseType ("website");
        //}

        private bool HasLicenseType (string licenseType)
        {
            bool hasThatLicense = false;
            if (LicenseTypes != null)
            {
                for (int iLicenseTypesCounter = 0; (!hasThatLicense) && (iLicenseTypesCounter < LicenseTypes.Length); iLicenseTypesCounter++)
                {
                    if (LicenseTypes [iLicenseTypesCounter] == licenseType)
                    {
                        hasThatLicense = true;
                    }
                }
            }

            return hasThatLicense;
        }

        public bool IsProduct (string product)
        {
            bool isProductAcceptable = false;

            for (int productCounter = 0; (!isProductAcceptable) && (productCounter < Products.Length); productCounter++)
            {
                if (Normaliser.StringCompare (Products[productCounter], product))
                {
                    isProductAcceptable = true;
                }
            }

            return isProductAcceptable;
        }

        public bool IsVersion (string version)
        {
            bool isVersionAcceptable = false;

            for (int versionCounter = 0; (!isVersionAcceptable) && (versionCounter < Versions.Length); versionCounter++)
            {
                if (Normaliser.StringCompare (Versions [versionCounter], version))
                {
                    isVersionAcceptable = true;
                }
            }

            return isVersionAcceptable;
        }

        public bool IsWebsiteLicensed (string website)
        {
            return IsStringInArray (website, Hosts);
        }

        public bool IsServerLicensed (string server)
        {
            return IsStringInArray (server, Servers);
        }

        private static bool IsStringInArray (string stringToTest, string[] arrayToTest)
        {
            bool isStringInArray = false;

            string normalised = stringToTest.ToLower (Globalisation.GetCultureInfo ());
            for (int indexCounter = 0; indexCounter < arrayToTest.Length; indexCounter++)
            {
                if (Normaliser.StringCompare (arrayToTest [indexCounter], AllHosts)
                    || Normaliser.StringCompare (arrayToTest [indexCounter], normalised)
                    || Normaliser.StringCompare ("www." + arrayToTest [indexCounter], normalised))
                {
                    isStringInArray = true;
                    break;
                }
            }

            return isStringInArray;
        }

        private static string GetElementTitle (string licenseElement)
        {
            string comment = null;
            int separatorAt = licenseElement.IndexOf (TitleValueSeparator);
            if (separatorAt > -1)
            {
                comment = licenseElement.Substring (0, separatorAt).Trim ().ToLower (Globalisation.GetCultureInfo ());
            }

            return comment;
        }

        private static string[] GetElementValue (string licenseElement)
        {
            string value = null;
            int separatorAt = licenseElement.IndexOf (TitleValueSeparator);
            if (separatorAt > -1)
            {
                value = licenseElement.Substring (separatorAt + 1).Trim ().ToLower (Globalisation.GetCultureInfo ());
            }

            return (value == null ? null : value.Split (MultivalueSeparator.ToCharArray ()));
        }

        private void Decode (string license)
        {
            if (!String.IsNullOrEmpty (license))
            {
                string dataPart = license.Substring (0, license.IndexOf (DataSignatureSeparator));

                byte[] data = Convert.FromBase64String (dataPart);
                var utf8 = new UTF8Encoding ();
                string dataString = utf8.GetString (data);
                string[] licenseData = dataString.Split (FieldSeparator.ToCharArray ());

                string elementTitle;
                foreach (string element in licenseData)
                {
                    elementTitle = GetElementTitle (element);
                    string[] elementValue = GetElementValue (element);
                    if (!String.IsNullOrEmpty (elementTitle))
                    {
                        string elementTitleNormalised = elementTitle.Trim ().ToLower (Globalisation.GetCultureInfo ());

                        switch (elementTitleNormalised)
                        {
                            case "product":
                                _products = elementValue;
                                break;

                            case "version":
                                _versions = elementValue;
                                break;

                            case "hosts":
                                _hosts = elementValue;
                                break;

                            case "servers":
                                _servers = elementValue;
                                break;

                            case "types":
                                _licenseTypes = elementValue;
                                break;

                            case "ids":
                            case "vendors":
                            case "purchasers":
                                break;
                                //case "ids":
                                //    _ids = aszElementValue;
                                //    break;

                                //case "vendors":
                                //    _vendors = aszElementValue;
                                //    break;

                                //case "purchasers":
                                //    _purchasers = aszElementValue;
                                //    break;
                        }
                    }
                }
            }

            return;
        }

        public bool Verify ()
        {
            var parameters = new CspParameters {Flags = CspProviderFlags.UseMachineKeyStore};
            var cryptoServiceProvider = new RSACryptoServiceProvider (parameters) {PersistKeyInCsp = false};
            cryptoServiceProvider.FromXmlString (PublicKey);

            string dataPart = _license.Substring (0, _license.IndexOf (DataSignatureSeparator));
            string signaturePart = _license.Substring (_license.IndexOf (DataSignatureSeparator) + 1);

            byte[] signedData = Convert.FromBase64String (dataPart);
            byte[] signature = Convert.FromBase64String (signaturePart);

            bool verified = cryptoServiceProvider.VerifyData (signedData, "MD5", signature);

            return verified;
        }
    }
}
