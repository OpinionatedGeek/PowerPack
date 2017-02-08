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
using System.Web.UI;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A special invisible control that automatically displays a popup or confirmation message when the page is
    /// loaded.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> Client-side Javascript must be available and enabled.
    /// </p>
    /// </summary>
    /// <remarks>
    /// Adding this control to a page automatically brings up a popup or confirmation message when the page is
    /// loaded.
    /// <p class="i1">
    /// The message shown in the popup is configured by setting the PopupText property to whatever string of text you want
    /// to display.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This facility is only available if client-side Javascript is enabled in the user's browser.  If client-side
    /// Javascript is not available, no popup will be displayed.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then adds a
    /// PopupAutomatically control which will bring up the alert 'This is an alert!'.
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:PopupAutomatically
    ///     id="PopupAutomatically"
    ///     popuptext="This is an alert!"
    ///     runat="server"/&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/PopupAutomatically.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [DefaultProperty ("Text")]
    [ToolboxData ("<{0}:PopupAutomatically runat=server></{0}:PopupAutomatically>")]
    [LicenseProvider (typeof (PopupAutomaticallyLicenseProvider))]
    [Designer (typeof (AutomaticDesigner))]
    public class PopupAutomatically : WebControl
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "PopupAutomatically";

        private string _popupMessage = "Are you sure?";
        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="PopupAutomatically"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="PopupAutomatically"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public PopupAutomatically ()
        {
            _license = LicenseManager.Validate (typeof (PopupAutomatically), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets the text to be displayed in the popup message before the form is posted.
        /// </summary>
        /// <remarks>
        /// The text set here will be passed through to client-side Javascript.  It is inadvisable to put
        /// double-quotes ('"') in this text.
        /// </remarks>
        /// <value>The text to be displayed in the popup before postback. The default value is "Are you sure?".</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("Are you sure?")]
        [Description (@"The text to be displayed in the popup message before the form is posted")]
        public String PopupText
        {
            get
            {
                return _popupMessage;
            }
            set
            {
                _popupMessage = value;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the text to be displayed in the popup message before the form is posted.  This is an alias
        /// for the PopupText property for this control, which is used by the other PowerPack popup controls.
        /// </summary>
        /// <remarks>
        /// The text set here will be passed through to client-side Javascript.  It is inadvisable to put
        /// double-quotes ('"') in this text.
        /// </remarks>
        /// <value>The text to be displayed in the popup before postback. The default value is "Are you sure?".</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance")]
        [Description (@"This is an alias for the PopupText property.")]
        public string Text
        {
            get
            {
                return PopupText;
            }
            set
            {
                PopupText = value;
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
        /// Called when the <b>PreRender</b> event is triggered.
        /// </summary>
        /// <remarks>
        /// This method is used to register the client-side Javascript code used to perform the popups.  It is
        /// essential that any subclasses that override this method ensure this method is called via
        /// base.OnPreRender (e).
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to safely override this method in subclasses.
        /// <code>
        ///protected override void OnPreRender(EventArgs e)
        ///{
        ///	// Call this base class version to register the client-side Javascript.
        ///	base.OnPreRender(e);
        ///	
        ///	// Perform sub-class specific pre-render steps.
        ///	
        ///	// Then return
        ///	return;
        ///}
        /// </code>
        /// </example>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnPreRender (EventArgs e)
        {
            ClientPopupManager.RegisterStartupScripts (Page);
            ClientPopupManager.AddStartupEvent (this, _popupMessage);

            base.OnPreRender (e);
        }

        ///
        /// <summary>
        /// Raises the Render event and outputs the control to the page.
        /// </summary>
        /// <remarks>
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their Render.
        /// </remarks>
        /// <param name="writer">The <see cref="HtmlTextWriter"/> object that receives the server control content.</param>
        ///
        protected override void Render (HtmlTextWriter writer)
        {
            HtmlTextWriter realWriter = HtmlTextWriterFactory.CreateCorrectHtmlTextWriter (writer);
            PowerPack.Announce (realWriter, ProductName);

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