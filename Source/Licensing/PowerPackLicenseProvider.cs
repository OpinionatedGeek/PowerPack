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
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.UI;

namespace OpinionatedGeek.Web.PowerPack.Licensing
{
    /// <summary>
    /// Ignored
    /// </summary>
    public class PowerPackLicenseProvider : LicenseProvider
    {
        //============================================================
        // Private Data
        //============================================================

        private LicenseCache _cache;

        //============================================================
        // Constructors
        //============================================================

        /// <summary>
        /// Ignored
        /// </summary>
        public PowerPackLicenseProvider ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        internal LicenseCache LicenseCache
        {
            get
            {
                if (_cache == null)
                {
                    _cache = LicenseCache.GetLicenseCache (GetConfiguredLicenses ());
                }

                return _cache;
            }
        }

        /// <summary>
        /// Ignored
        /// </summary>
        public virtual string ProductName
        {
            get
            {
                return Constants.ProductName;
            }
        }

        /// <summary>
        /// Ignored
        /// </summary>
        public virtual string ProductVersion
        {
            get
            {
                return Constants.BaseProductVersion;
            }
        }

        /// <summary>
        /// Ignored
        /// </summary>
        public virtual bool AllowLocal
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Ignored
        /// </summary>
        public virtual bool AllowLocalHost
        {
            get
            {
                return true;
            }
        }

        //============================================================
        // Methods
        //============================================================

        /// <summary>
        /// Ignored
        /// </summary>
        public override System.ComponentModel.License GetLicense (LicenseContext context, Type type, object instance, bool allowExceptions)
        {
            System.ComponentModel.License controlLicense = null;

            try
            {
                var licenseControl = instance as Control;
                if (licenseControl != null)
                {
                    if ((HttpContext.Current == null) || (AllowLocalHost && IsLocalHost ()) || (AllowLocal && IsLocal ()) || (IsLicensed (GetRunningServer (), GetMachineName (), ProductName, ProductVersion)))
                    {
                        controlLicense = new ValidLicense ();
                    }
                }
            }
            catch (Exception)
            {
                if (allowExceptions)
                {
#if DEBUG
                    throw;
#else
					throw new LicenseException (type, instance, Globalisation.GetString ("invalidLicenseData"));
#endif
                }
            }

            return controlLicense;
        }

        /// <summary>
        /// Ignored
        /// </summary>
        protected virtual string[] GetConfiguredLicenses ()
        {
            var licensePowerPackConfiguration = (PowerPackConfigurationSection) ConfigurationManager.GetSection (Constants.ConfigurationSectionName);
            string[] licenses = null;
            if (licensePowerPackConfiguration.HasCompoundValue (Constants.LicenseKeySection))
            {
                licenses = licensePowerPackConfiguration.GetCompoundValue (Constants.LicenseKeySection);
            }
            else
            {
                string configLicense = licensePowerPackConfiguration [Constants.LicenseKeySection];
                if (configLicense != null)
                {
                    licenses = new [] {configLicense};
                }
            }

            return licenses;
        }

        /// <summary>
        /// Ignored
        /// </summary>
        internal static string[] GetAllLicenses ()
        {
            var licenser = new PowerPackLicenseProvider ();
            return licenser.GetConfiguredLicenses ();
        }

        /// <summary>
        /// Ignored
        /// </summary>
        protected virtual bool IsLicensed (string hostname, string machinename, string product, string version)
        {
            return LicenseCache.IsServerLicensedForProduct (hostname, machinename, product, version);
        }

        private static string GetRunningServer ()
        {
            string runningServer = null;
            if (HttpContext.Current != null)
            {
                runningServer = HttpContext.Current.Request.Url.Host.ToLower (Globalisation.GetCultureInfo ());
            }

            return runningServer;
        }

        private static string GetMachineName ()
        {
            string machineName = null;
            if (HttpContext.Current != null)
            {
                machineName = HttpContext.Current.Server.MachineName.ToLower (Globalisation.GetCultureInfo ());
            }

            return machineName;
        }

        private static bool IsLocal ()
        {
            bool isLocal = false;
            if (GetRunningServer ().IndexOf ('.') == -1)
            {
                isLocal = true;
            }

            return isLocal;
        }

        private static bool IsLocalHost ()
        {
            bool isLocalHost = false;
            string server = GetRunningServer ();
            if ((server == "localhost") || (server == "127.0.0.1"))
            {
                isLocalHost = true;
            }

            return isLocalHost;
        }
    }
}