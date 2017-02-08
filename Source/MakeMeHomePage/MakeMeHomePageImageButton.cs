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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A special ImageButton that allows the user to set the browser's home page to the current page.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> IE5 or higher.
    /// </p>
    /// </summary>
    /// <remarks>
    /// The theory is simple - add this control to your page, and the user sees an ImageButton
    /// that allows them to set the browser's home page to the current page.
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This control only works with IE5 or higher, and so only generates output on that platform.  Mozilla-based
    /// browsers do not (yet) provide a Home Page mechanism, and Netscape browsers only make this functionality
    /// available to signed scripts.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then adds a
    /// MakeMeHomePageImageButton button with the image '/images/homepage.gif'.
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:MakeMeHomePageImageButton
    ///     id="homepagesetter"
    ///     ImageUrl="/images/homepage.gif"
    ///     runat="server"/&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/MakeMeHomePageImageButton.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [LicenseProvider (typeof (MakeMeHomePageImageButtonLicenseProvider))]
    [ToolboxBitmap (typeof (ImageButton))]
    public class MakeMeHomePageImageButton : ImageButton
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "MakeMeHomePageImageButton";

        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="MakeMeHomePageImageButton"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="MakeMeHomePageImageButton"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public MakeMeHomePageImageButton ()
        {
            _license = LicenseManager.Validate (typeof (MakeMeHomePageImageButton), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        private bool IsInDesignMode
        {
            get
            {
                return ((HttpContext.Current == null) || ((Site != null) && (Site.DesignMode)));
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
        /// Raises the Load event.
        /// </summary>
        /// <remarks>
        /// This method notifies the server control that it should perform actions common to each HTTP request
        /// for the page it is associated with, such as setting up a database query. At this stage in the page
        /// lifecycle, server controls in the hierarchy are created and initialized, view state is restored, and
        /// form controls reflect client-side data.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            EnsureChildControls ();

            if (!IsInDesignMode)
            {
                MakeMeHomePageAction.AddAttributes (Attributes);
            }

            return;
        }

        ///
        /// <summary>
        /// Raises the Render event and outputs the control to the page.
        /// </summary>
        /// <remarks>
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their Render.
        /// </remarks>
        /// <param name="writer">The <see cref="System.Web.UI.HtmlTextWriter"/> object that receives the server control content.</param>
        ///
        protected override void Render (HtmlTextWriter writer)
        {
            HtmlTextWriter realWriter = HtmlTextWriterFactory.CreateCorrectHtmlTextWriter (writer);
            PowerPack.Announce (realWriter, ProductName);

            if (String.IsNullOrEmpty (ImageUrl))
            {
                ImageUrl = Page.ClientScript.GetWebResourceUrl (typeof (MakeMeHomePageImageButton), MakeMeHomePageConstants.IconResource);
            }

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
    }
}