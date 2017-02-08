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
using System.Drawing;
using System.Web.UI;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// An enhanced HyperLink with smart linking, which doesn't 'linkify' the text if it points to the current page.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// It's good practice for a page not to link to itself (check out Jakob Nielsen's work if you don't
    /// believe us).  But how can you do that if you're using a hyperlink in a user control, or some other
    /// UI element that is shared between pages?  The answer is to use a HyperLink control that takes into
    /// account which page it is on before it renders the link.
    /// <p class="i1">
    /// This control renders the link if the NavigateUrl property points to a different page than the current
    /// one, or if the querystring is different, or if the page is a postback.  If the NavigateUrl effectively
    /// is the same URL as the current page, the control is output as text (formatted and styled properly)
    /// instead of a link.
    /// </p>
    /// <p class="i1">
    /// Note: You can turn this behaviour off by setting the <see cref="UseSmartLink"/> property to <b>True</b>.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This should work in any browser, as the default HyperLink control does.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then sets
    /// it up with some text and navigation properties.  If the current page is /Testing/Default.aspx, the
    /// control will render as "A link to this page" in red text.  If the current page is not /Testing/Default.aspx,
    /// the control will render a red link which says "A link to this page".
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:HyperLink
    ///     forecolor="red"
    ///     NavigateUrl="/Testing/default.aspx"
    ///     ID="test"
    ///     Text="A link to this page"
    ///     runat="server"/&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/HyperLink.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [LicenseProvider (typeof (HyperLinkLicenseProvider))]
    [ToolboxBitmap (typeof (System.Web.UI.WebControls.HyperLink))]
    public class HyperLink : System.Web.UI.WebControls.HyperLink
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "HyperLink";

        private bool _useSmartLink = true;
        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperLink"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="HyperLink"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public HyperLink ()
        {
            _license = LicenseManager.Validate (typeof (HyperLink), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets whether the smart link behaviour based on the current URL is on or off.
        /// </summary>
        /// <remarks>
        /// Allows you to programmatically turn on or off the smart link behaviour which doesn't output
        /// a link if the current page is the same page as the NavigateUrl property.  By default this
        /// behaviour is on, so this property is <b>true</b> by default.
        /// </remarks>
        /// <value>whether the smart link behaviour based on the current URL is enabled or not.</value>
        ///
        public bool UseSmartLink
        {
            get
            {
                return _useSmartLink;
            }
            set
            {
                _useSmartLink = value;

                return;
            }
        }

        //============================================================
        // Events
        //============================================================

        ///
        /// <summary>
        /// Raises the <see cref="Control.Init"/> event.
        /// </summary>
        /// <remarks>
        /// When notified by this method, server controls must perform any initialization steps that are required
        /// to create and set up an instance. In this stage of the server control's lifecycle, the control's view
        /// state has yet to be populated. Additionally, you can not access other server controls when this method
        /// is called either, regardless of whether it is a child or parent to this control. Other server controls
        /// are not certain to be created and ready for access.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            PowerPack.EnsureIdSet (this);

            return;
        }

        ///
        /// <summary>
        /// Render this control to the writer parameter specified.
        /// </summary>
        /// <remarks>
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their Render.
        /// </remarks>
        /// <param name="writer">The <see cref="HtmlTextWriter"/> object that receives the server control content.</param>
        ///
        override protected void Render (HtmlTextWriter writer)
        {
            HtmlTextWriter realWriter = HtmlTextWriterFactory.CreateCorrectHtmlTextWriter (writer);
            //
            // Don't announce this product because it may upset formatting.
            //
            //PowerPack.Announce (realWriter, ProductName);

            base.Render (realWriter);

            return;
        }

        //============================================================
        // Methods
        //============================================================

        ///
        /// <summary>
        /// Enables a server control to perform final clean up before it is released from
        /// memory.
        /// </summary>
        /// <remarks>
        /// The Dispose method leaves the Control in an unusable state. After calling this
        /// method, you must release all references to the control so the memory it was
        /// occupying can be reclaimed by garbage collection.
        /// </remarks>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources; <b>false</b> to release only unmanaged resources.</param>
        ///
        protected virtual void Dispose (bool disposing)
        {
            if ((disposing) && (_license != null))
            {
                _license.Dispose ();
                _license = null;
            }

            return;
        }

        ///
        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// <see cref="System.Web.UI.HtmlTextWriter"/>. This method is used primarily by control developers.
        /// </summary>
        /// <remarks>
        /// To render attributes and styles for a Web sServer control on the client, you typically call the
        /// <see cref="System.Web.UI.HtmlTextWriter.AddAttribute (string, string)"/> and
        /// <see cref="System.Web.UI.HtmlTextWriter.AddStyleAttribute (string, string)"/> methods to insert each attribute and style
        /// individually to the <see cref="System.Web.UI.HtmlTextWriter"/> output stream. To simplify the process,
        /// this method encapsulates all calls to the <see cref="System.Web.UI.HtmlTextWriter.AddAttribute (string, string)"/>
        /// and <see cref="System.Web.UI.HtmlTextWriter.AddStyleAttribute (string, string)"/> methods for every attribute and style
        /// associated with the Web server control. All attributes and styles are inserted into the
        /// <see cref="System.Web.UI.HtmlTextWriter.AddAttribute (string, string)"/> output stream in a single method call.
        /// This method is typically overridden by control developers in derived classes to insert the appropriate
        /// attributes and styles to the <see cref="System.Web.UI.HtmlTextWriter.AddAttribute (string, string)"/> output stream for
        /// the class.
        /// </remarks>
        /// <param name="writer">A <see cref="System.Web.UI.HtmlTextWriter"/> that represents the output stream
        /// to render HTML content on the client.</param>
        ///
        protected override void AddAttributesToRender (HtmlTextWriter writer)
        {
            if (DoWeShowLink ())
            {
                base.AddAttributesToRender (writer);
            }
            else
            {
                if (ControlStyleCreated)
                {
                    ControlStyle.AddAttributesToRender (writer, this);
                }
            }

            return;
        }

        private bool DoWeShowLink ()
        {
            bool showLink = true;
            if (UseSmartLink)
            {
                if ((!Page.IsPostBack) && (!DesignMode))
                {
                    if ((Uri.IsWellFormedUriString (NavigateUrl, UriKind.Absolute))
                        || (Uri.IsWellFormedUriString (NavigateUrl, UriKind.Relative)))
                    {
                        string localPath = Page.Request.Url.LocalPath;
                        var navigateUrl = new Uri (Page.Request.Url, NavigateUrl);
                        string navigatePath = navigateUrl.LocalPath;
                        if (ComparePaths (localPath, navigatePath))
                        {
                            string queryString = Page.Request.Url.Query;
                            string navigateString = navigateUrl.Query;
                            if (Normaliser.StringCompare (queryString, navigateString))
                            {
                                showLink = false;
                            }
                        }
                    }
                }
            }

            return showLink;
        }

        private static bool ComparePaths (string actual, string target)
        {
            bool match = false;
            if (Normaliser.StringCompare (actual, target))
            {
                match = true;
            }
            else
            {
                if (!target.EndsWith ("/"))
                {
                    target += "/";
                }
                target += "default.aspx";

                if (Normaliser.StringCompare (actual, target))
                {
                    match = true;
                }
            }

            return match;
        }
    }
}