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
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace OpinionatedGeek.Web.PowerPack
{
    internal static class Globalisation
    {
        //============================================================
        // Private Data
        //============================================================

        private static readonly ResourceManager _resourceManager = new ResourceManager ("OpinionatedGeek.Web.PowerPack.LocalisedText", Assembly.GetExecutingAssembly ());

        //============================================================
        // Constructors
        //============================================================

        //============================================================
        // Static Methods
        //============================================================

        public static CultureInfo GetCultureInfo ()
        {
            return CultureInfo.CurrentUICulture;
        }

        public static string GetString (string localisationName, params object [] parameters)
        {
            string formatter = _resourceManager.GetString (localisationName, CultureInfo.CurrentUICulture) ?? "No message found.";

            return String.Format (CultureInfo.CurrentUICulture, formatter, parameters);
        }
    }
}