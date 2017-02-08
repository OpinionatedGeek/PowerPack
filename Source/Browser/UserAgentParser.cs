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

namespace OpinionatedGeek.Web.PowerPack
{
    internal class UserAgentParser
    {
        public UserAgentParser()
        {
            return;
        }

        public BrowserType Parse (HttpBrowserCapabilities client)
        {
            BrowserType browserType = BrowserType.Unknown;
            switch (client.Browser)
            {
                case "Firefox":
                    if (client.MajorVersion >= 2)
                    {
                        browserType = BrowserType.FireFox2;
                    }
                    else
                    {
                        browserType = BrowserType.Mozilla;
                    }
                    break;

                case "IE":
                    if (client.MajorVersion >= 7)
                    {
                        browserType = BrowserType.IE7Up;
                    }
                    else if (client.MajorVersion == 6)
                    {
                        browserType = BrowserType.IE6Up;
                    }
                    else if (client.MajorVersion == 5)
                    {
                        browserType = BrowserType.IE5Up;
                    }
                    break;

                case "Mozilla":
                    browserType = BrowserType.Mozilla;
                    break;

                case "Netscape":
                    if (client.MajorVersion >= 5)
                    {
                        browserType = BrowserType.Mozilla;
                    }
                    break;

                case "AppleMAC-Safari":
                    if (client.MajorVersion >= 5)
                    {
                        browserType = BrowserType.WebKit;
                    }
                    break;

            }

            return browserType;
        }
    }
}
