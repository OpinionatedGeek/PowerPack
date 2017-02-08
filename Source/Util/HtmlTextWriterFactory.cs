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
    ///
    /// <summary>
    /// Creates an appropriate <see cref="HtmlTextWriter"/> object based on an existing <see cref="HtmlTextWriter"/>
    /// and the capabilities of the browser.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// ASP.NET has a nice architecture, and one of the good bits is that server controls are given a different
    /// HtmlTextWriter in their rendering routines depending on browser client used.
    /// <p class="i1">
    /// There are two <see cref="HtmlTextWriter"/>s - the <see cref="HtmlTextWriter"/> class outputs HTML 4.0, and the
    /// <see cref="Html32TextWriter"/> outputs HTML 3.2.  So when you change the font by setting the
    /// <see cref="System.Web.UI.WebControls.WebControl.Font"/> attribute, it sets the
    /// <see cref="System.Web.UI.WebControls.Style.Font"/> property in the
    /// <see cref="System.Web.UI.WebControls.WebControl.ControlStyle"/> <see cref="System.Web.UI.WebControls.Style"/>
    /// object, which in turn sets the font information in the <see cref="HtmlTextWriter"/>, which, and this is the
    /// good bit, either outputs HTML 4 style attributes or HTML 3.2 FONT tags depending on the browser type!
    /// </p>
    /// <p class="i1">
    /// Neat eh!  Except it doesn't work.
    /// </p>
    /// <p class="i1">
    /// From what I can tell here, the only browser that ASP.NET accepts as being HTML 4 capable is, in fact, Internet
    /// Explorer.  That means that although Opera and Mozilla are much more standards compliant, they're stuck with
    /// HTML 3.2 which doesn't always give the right effect.
    /// </p>
    /// <p class="i1">
    /// Personally, I smell a rat here.  But anyway, that's the problem this factory class is designed to solve.
    /// Using the <see cref="CreateCorrectHtmlTextWriter"/> factory method, you get back an HtmlTextWriter object
    /// that's right for the browser client.  So you get:
    /// <list type="bullet">
    /// <item>The original <see cref="HtmlTextWriter"/> back if the browser is Internet Explorer (letting MS worry
    /// about which version should get HTML 3.2 and which should get HTML 4.0).</item>
    /// <item>An <see cref="HtmlTextWriter"/> (HTML 4.0) if the browser is Opera 5 or higher, or if it's
    /// Mozilla/Netscape 5 or higher.</item>
    /// <item>The original <see cref="Html32TextWriter"/> back if the browser is anything else.</item>
    /// </list>
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// Not applicable.
    /// </p>
    /// </remarks>
    /// <example>
    /// The standard Render method in a control is given an <see cref="HtmlTextWriter"/> and it propagates that to
    /// the subsidiary Render methods.  The simplest way to intercept it for all Render methods in a control is to
    /// do the following:
    /// <code>
    /// protected override void Render
    /// (
    /// 	HtmlTextWriter htwOutput
    /// )
    /// {
    /// 	HtmlTextWriter htwRealOutput = HtmlTextWriterFactory.CreateCorrectHtmlTextWriter (htwOutput);
    ///
    /// 	base.Render (htwRealOutput);
    ///
    /// 	return;
    /// }
    /// </code>
    /// </example>
    ///
    public static class HtmlTextWriterFactory
    {
        //============================================================
        // Private Data
        //============================================================

        //============================================================
        // Constructors
        //============================================================

        //============================================================
        // Static Methods
        //============================================================

        ///
        /// <summary>
        /// Returns an appropriate HtmlTextWriter based on the HtmlTextWriter parameter and the current request's
        /// browser type.
        /// </summary>
        /// <remarks>
        /// The actual <see cref="HtmlTextWriter"/> passed to a control's Render methods may not be the most
        /// appropriate for the current request's browser type.  In particular, trying to set styles such as
        /// foreground colour may not work well in Mozilla because Mozilla causes the control to receive an
        /// <see cref="Html32TextWriter"/> (which outputs only HTML 3.2) instead of the more appropriate
        /// <see cref="HtmlTextWriter"/> (which outputs HTML 4.0).  This isn't Mozilla's fault, but is a problem with
        /// the ASP.NET engine itself.
        /// <p class="i1">
        /// This factory method will return an HTML 4.0 <see cref="HtmlTextWriter"/> if the browser is Mozilla 5 or
        /// higher, or if it is Opera 5 or higher.  In all other circumstances it will return the original
        /// <see cref="HtmlTextWriter"/> (so Internet Explorer will still use the HTML 4.0
        /// <see cref="HtmlTextWriter"/>, and Netscape 3.2 will still use the HTML 3.2 <see cref="Html32TextWriter"/>.
        /// </p>
        /// <p class="i1">
        /// In all cases, the <see cref="HtmlTextWriter"/> received will write to the same writer stream.
        /// </p>
        /// <seealso cref="HtmlTextWriterFactory"/>
        /// </remarks>
        /// <param name="writer">The <see cref="HtmlTextWriter"/> object that receives the server control content.</param>
        /// <returns>An <see cref="HtmlTextWriter"/> object, which may be the same object that was passed.</returns>
        ///
        public static HtmlTextWriter CreateCorrectHtmlTextWriter (HtmlTextWriter writer)
        {
            HtmlTextWriter realWriter = writer;
            if (HttpContext.Current != null)
            {
                HttpBrowserCapabilities client = HttpContext.Current.Request.Browser;
                if ((client.Browser == "Netscape") && (client.MajorVersion >= 5))
                {
                    // Mozilla
                    realWriter = new HtmlTextWriter (writer);
                }
                else if ((client.Browser == "Opera") && (client.MajorVersion >= 5))
                {
                    // Opera
                    realWriter = new HtmlTextWriter (writer);
                }
            }

            return realWriter;
        }
    }
}