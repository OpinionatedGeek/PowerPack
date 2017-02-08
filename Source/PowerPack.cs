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
using System.Reflection;
using System.Web;
using System.Web.UI;
using OpinionatedGeek.Web.PowerPack.Licensing;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class PowerPack
    {
        //============================================================
        // Private Data
        //============================================================

        private const string DisplayLicenseKeyQueryStringKey = "opgeek_showlicensekey";

        private static string _assemblyVersion;

        //============================================================
        // Constructors
        //============================================================

        private PowerPack ()
        {
            return;
        }

        //============================================================
        // Static Properties
        //============================================================

        private static string AssemblyVersion
        {
            get
            {
                if (_assemblyVersion == null)
                {
                    object[] attributes = Assembly.GetExecutingAssembly ().GetCustomAttributes (typeof (AssemblyFileVersionAttribute), true);
                    var versionAttribute = (AssemblyFileVersionAttribute) attributes [0];
                    _assemblyVersion = versionAttribute.Version;
                }

                return _assemblyVersion;
            }
        }

        //============================================================
        // Static Methods
        //============================================================

        public static void Announce (HtmlTextWriter writer, string productName)
        {
            writer.Write ("\n<!-- {0} v{1} from Opinionated Geek - visit http://www.opinionatedgeek.com/ for more info -->\n", productName, AssemblyVersion);

            if (HttpContext.Current != null)
            {
                string displayLicenseKeyQueryStringValue = HttpContext.Current.Request.QueryString [DisplayLicenseKeyQueryStringKey];
                if (displayLicenseKeyQueryStringValue != null)
                {
                    bool displayLicenseKey = false;
                    try
                    {
                        displayLicenseKey = Boolean.Parse (displayLicenseKeyQueryStringValue);
                    }
                    catch (FormatException)
                    {
                    }

                    if (displayLicenseKey)
                    {
                        string[] licenses = PowerPackLicenseProvider.GetAllLicenses ();
                        foreach (string license in licenses)
                        {
                            writer.Write ("\n<!-- {0} -->\n", license);
                        }
                    }
                }
            }

            return;
        }

        internal static void EnsureIdSet (Control control)
        {
            if (String.IsNullOrEmpty (control.ID))
            {
                // This line forces the creation of the unique ID
#pragma warning disable 168
                string discardedClientID = control.ClientID;
#pragma warning restore 168
                control.ID = control.ID;
            }

            if (String.IsNullOrEmpty (control.ID))
            {
                throw new InvalidProgramException (Globalisation.GetString ("failedToSetControlId"));
            }

            return;
        }
    }
}