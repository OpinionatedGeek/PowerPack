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

using System.Web;
using System.Web.UI;

namespace OpinionatedGeek.Web.PowerPack
{
    internal static class MakeMeHomePageAction
    {
        //============================================================
        // Private Data
        //============================================================

        private const string DefaultHomepageAction = "alert ('Sorry, this browser version does not allow web pages to set the default home page.'); return false;";
        private const string NSHomepageAction = "alert ('Sorry, this browser version does not allow web pages to set the default home page.  Follow the steps below to make \\'' + document.title + '\\' automatically appear when you launch your browser and when you click the Home button:\\n\\n\\t* Open the Edit menu and choose Preferences.\\n\\t* Select the Navigator category.\\n\\t* Choose Home page under Navigator starts with.\\n\\t* In the Home page section, type \\'' + document.location + '\\' in the Location box.\\n\\t* Click the OK button.\\n\\nCongratulations! \\'' + document.title + '\\' is now your new home!'); return false;";
        private const string MozHomepageAction = "alert ('Sorry, this browser version does not allow web pages to set the default home page.  Follow the steps below to make \\'' + document.title + '\\' automatically appear when you launch your browser and when you click the Home button:\\n\\n\\t* Open the Edit menu and choose Preferences.\\n\\t* Select the Navigator category.\\n\\t* Choose Home page under When Navigator starts up, display.\\n\\t* In the Home page section, type \\'' + document.location + '\\' in the Location box.\\n\\t* Click the OK button.\\n\\nCongratulations! \\'' + document.title + '\\' is now your new home!'); return false;";
        private const string IEHomepageAction = "this.style.behavior='url(#default#homepage)'; this.setHomePage (document.location); return false;";
        private const string StartupActionName = "MakeHomePageAction_opgeek";
        private const string IEOnStartupAction = @"
	<style>
		#spnHomePageSetter_opgeek {behavior:url(#default#homepage);}
	</style>
	<span id=""spnHomePageSetter_opgeek"" />
	<script language=""javascript"">
		spnHomePageSetter_opgeek.setHomePage (document.location);
	</script>";

        private static readonly UserAgentParser _userAgentParser = new UserAgentParser ();

        //============================================================
        // Constructors
        //============================================================

        //============================================================
        // Events
        //============================================================

        //============================================================
        // Methods
        //============================================================

        public static void AddAttributes (AttributeCollection attributes)
        {
            AddAttributes ("onclick", attributes);

            return;
        }

        public static void AddAttributes (string @event, AttributeCollection attributes)
        {
            HttpBrowserCapabilities client = HttpContext.Current.Request.Browser;
            BrowserType browserType = _userAgentParser.Parse (client);
            switch (browserType)
            {
                case BrowserType.IE5Up:
                case BrowserType.IE6Up:
                case BrowserType.IE7Up:
                    attributes.Add (@event, IEHomepageAction);
                    break;

                case BrowserType.FireFox2:
                case BrowserType.Mozilla:
                case BrowserType.WebKit:
                    attributes.Add (@event, MozHomepageAction);
                    break;

                case BrowserType.Netscape:
                    attributes.Add (@event, NSHomepageAction);
                    break;

                default:
                    attributes.Add (@event, DefaultHomepageAction);
                    break;
            }

            return;
        }

        public static void RegisterStartupScript (Page page)
        {
            HttpBrowserCapabilities client = HttpContext.Current.Request.Browser;
            BrowserType browserType = _userAgentParser.Parse (client);
            switch (browserType)
            {
                case BrowserType.IE5Up:
                case BrowserType.IE6Up:
                case BrowserType.IE7Up:
                    page.ClientScript.RegisterStartupScript (typeof (MakeMeHomePageAction), StartupActionName, IEOnStartupAction);
                    break;

                default:
                    break;
            }

            return;
        }
    }
}