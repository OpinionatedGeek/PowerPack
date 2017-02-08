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
using System.Runtime.InteropServices;
using System.Web.UI;
using OpinionatedGeek.Web.PowerPack;

[assembly: AssemblyVersion ("2.1.0.0")]
[assembly: AssemblyFileVersion ("2.1.0.0")]

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle ("OpinionatedGeek ASP.NET PowerPack")]
[assembly: AssemblyDescription ("A collection of dynamic ASP.NET controls to enhance web forms.")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("OpinionatedGeek")]
[assembly: AssemblyProduct ("OpinionatedGeek ASP.NET PowerPack")]
[assembly: AssemblyCopyright ("2003-2008 OpinionatedGeek.com")]
[assembly: AssemblyTrademark ("OpinionatedGeek ASP.NET PowerPack")]
[assembly: AssemblyCulture ("")]
[assembly: CLSCompliant (true)]
[assembly: ComVisible (false)]
[assembly: TagPrefix ("OpinionatedGeek.Web.PowerPack", "opgeek")]

//
// All web resources, such as images and client-side script, should be referenced here.
//
[assembly: WebResource (ComboBoxConstants.Firefox2DhtmlResource, "text/javascript")]
[assembly: WebResource (ComboBoxConstants.IE5DhtmlResource, "text/javascript")]
[assembly: WebResource (ComboBoxConstants.IE6DhtmlResource, "text/javascript")]
[assembly: WebResource (ComboBoxConstants.IE7DhtmlResource, "text/javascript")]
[assembly: WebResource (ComboBoxConstants.MozDhtmlResource, "text/javascript")]
[assembly: WebResource (ComboBoxConstants.WebKitDhtmlResource, "text/javascript")]

[assembly: WebResource (DatePickerConstants.IE5DhtmlResource, "text/javascript")]
[assembly: WebResource (DatePickerConstants.MozDhtmlResource, "text/javascript")]
[assembly: WebResource (DatePickerConstants.NSDhtmlResource, "text/javascript")]
[assembly: WebResource (DatePickerConstants.WebKitDhtmlResource, "text/javascript")]
[assembly: WebResource (DatePickerConstants.IconResource, "image/gif")]

[assembly: WebResource (MakeMeHomePageConstants.IconResource, "image/gif")]

[assembly: WebResource (PopupConstants.IconResource, "image/gif")]

[assembly: WebResource (PrintConstants.IconResource, "image/gif")]

[assembly: WebResource (RTConstants.Firefox2DhtmlResource, "text/javascript")]
[assembly: WebResource (RTConstants.IE5DhtmlResource, "text/javascript")]
[assembly: WebResource (RTConstants.IE7DhtmlResource, "text/javascript")]
[assembly: WebResource (RTConstants.MozDhtmlResource, "text/javascript")]
[assembly: WebResource (RTConstants.WebKitDhtmlResource, "text/javascript")]
[assembly: WebResource (RTConstants.ButtonDownResource, "image/gif")]
[assembly: WebResource (RTConstants.ButtonNormalResource, "image/gif")]
[assembly: WebResource (RTConstants.ButtonUpResource, "image/gif")]
[assembly: WebResource (RTConstants.Toolbar1Resource, "image/gif")]
[assembly: WebResource (RTConstants.Toolbar1DisabledResource, "image/gif")]
[assembly: WebResource (RTConstants.Toolbar2Resource, "image/gif")]
[assembly: WebResource (RTConstants.Toolbar2DisabledResource, "image/gif")]
[assembly: WebResource (RTConstants.ToolbarBackgroundResource, "image/gif")]
[assembly: WebResource (RTConstants.ButtonUpOverlayResource, "image/png")]
[assembly: WebResource (RTConstants.ButtonDownOverlayResource, "image/png")]

[assembly: WebResource (ShowOnConditionConstants.IE5DhtmlResource, "text/javascript")]
[assembly: WebResource (ShowOnConditionConstants.MozDhtmlResource, "text/javascript")]