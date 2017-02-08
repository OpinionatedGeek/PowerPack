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
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A standard Button that has been enhanced to display a popup or confirmation message when pressed.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> Client-side Javascript must be available and enabled.
    /// </p>
    /// </summary>
    /// <remarks>
    /// This control behaves exactly like the regular ASP.NET Button with one exception: it can display a popup
    /// or confirmation message when pressed, before the form is submitted.  It can even be configured to allow the
    /// user to cancel the posting of the form.
    /// <p class="i1">
    /// The PopupButton allows two modes, <b>AlertOnly</b> and <b>Confirm</b>.  These modes are configured
    /// using the AlertOnly property.
    /// </p>
    /// <list type="table">
    ///		<listheader>
    ///			<term>AlertOnly value</term>
    ///			<description>Popup behaviour</description>
    ///		</listheader>
    ///		<item>
    ///			<term>True</term>
    ///			<description>The control operates in AlertOnly mode, and the popup is displayed with an 'OK' button.</description>
    ///		</item>
    ///		<item>
    ///			<term>False</term>
    ///			<description>The control operates in Confirm mode and the popup is displayed with both 'OK' and 'Cancel' buttons.
    ///			OK continues with the form posting and Cancel stops the form posting.</description>
    ///		</item>
    /// </list>
    /// <p class="i1">
    /// The message shown in the popup is configured by setting the PopupText property to whatever string of text you want
    /// to display.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This facility is only available if client-side Javascript is enabled in the user's browser.  If client-side
    /// Javascript is not available, this control reverts to the default Button behaviour.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then adds a
    /// PopupButton with the text 'Press Me!' which will bring up the alert 'This is an alert!'.
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:PopupButton
    ///     id="popupbutton"
    ///     AlertOnly="True"
    ///     text="Press Me!"
    ///     popuptext="This is an alert!"
    ///     runat="server"/&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/PopupButton.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [DefaultProperty ("Text")]
    [ToolboxData ("<{0}:PopupButton runat=server></{0}:PopupButton>")]
    [ToolboxBitmap (typeof (Button))]
    [LicenseProvider (typeof (PopupButtonLicenseProvider))]
    public class PopupButton : Button
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "PopupButton";

        private string _popupMessage = "Are you sure?";
        private bool _alertOnly;
        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="PopupButton"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="PopupButton"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public PopupButton ()
        {
            _license = LicenseManager.Validate (typeof (PopupButton), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets the AlertOnly mode.
        /// </summary>
        /// <remarks>
        /// Gets or sets the AlertOnly mode.  In AlertOnly mode, the PopupText is displayed in a dialog box with
        /// just an 'OK' button, and when 'OK' is pressed the underlying form is submitted.
        /// <br/><br/>
        /// When not in AlertOnly mode both an 'OK' button and a 'Cancel' button are displayed.  When 'OK' is
        /// pressed the form is submitted as normal, but when 'Cancel' is pressed the underlying form submission is
        /// also cancelled.
        /// </remarks>
        /// <value>
        /// Whether we are in AlertOnly mode or not.  The default value is <b>False</b>.
        /// <br/>
        /// <list type="table">
        /// <listheader>
        /// <term>AlertOnly value</term>
        /// <description>Popup behaviour</description>
        /// </listheader>
        /// <item>
        /// <term>True</term>
        /// <description>The control operates in AlertOnly mode, and the popup is displayed with an 'OK' button.</description>
        /// </item>
        /// <item>
        /// <term>False</term>
        /// <description>The control operates in Confirm mode and the popup is displayed with both 'OK' and 'Cancel' buttons.
        /// OK continues with the form posting and Cancel stops the form posting.</description>
        /// </item>
        /// </list>
        /// </value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("false")]
        [Description (@"In AlertOnly mode, the PopupText is displayed in a dialog box with just an 'OK' button.")]
        public bool AlertOnly
        {
            get
            {
                return _alertOnly;
            }
            set
            {
                _alertOnly = value;

                return;
            }
        }

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
        /// essential that any subclasses that override this method ensure this method is called via base.OnPreRender (e).
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
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data. </param>
        ///
        protected override void OnPreRender (EventArgs e)
        {
            ClientPopupManager.RegisterStartupScripts (Page);
            ClientPopupManager.AddEvent (this, _alertOnly, _popupMessage);

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