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
    /// A Panel-type control that only displays its contents if the user is <b>not</b> authenticated.
    /// <p class="i1" style="color: #003399">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// This control gives you a simple way to show some page content <i>only</i> to users who have not logged in.
    /// It's the converse of the <see cref="ShowIfLoggedIn"/> control.  You can use this control to provide a
    /// prompt to log in, username/password textboxes, or information on how to subscribe.
    /// <p class="i1">
    /// This control works well when used in conjunction with the <see cref="ShowIfLoggedIn"/> control.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This facility is available to all browsers.
    /// </p>
    /// <seealso cref="ShowIfLoggedIn"/>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then adds a
    /// ShowIfNotLoggedIn control which displays a prompt for the user to login, but only to those users who have
    /// not yet logged in.
    /// <code>
    ///&lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    ///&lt;opgeek:ShowIfNotLoggedIn
    ///     id="loginprompt"
    ///     runat="server"/&gt;
    ///     ...
    ///     Click &lt;a href="/login.aspx"&gt;here&lt;/a&gt; to log in.
    ///     ...
    ///&lt;/opgeek:ShowIfNotLoggedIn&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/ShowIfNotLoggedIn.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [LicenseProvider (typeof (ShowIfNotLoggedInLicenseProvider))]
    [Designer (typeof (AutomaticDesigner))]
    [ToolboxBitmap (typeof (Panel))]
    [ParseChildren (false)]
    public class ShowIfNotLoggedIn : WebControl
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "ShowIfNotLoggedIn";

        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowIfNotLoggedIn"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="ShowIfNotLoggedIn"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public ShowIfNotLoggedIn () : base (HtmlTextWriterTag.Span)
        {
            _license = LicenseManager.Validate (typeof (ShowIfNotLoggedIn), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

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
        /// Raises the PreRender event.
        /// </summary>
        /// <remarks>
        /// This method notifies the server control to perform any necessary prerendering steps prior to
        /// saving view state and rendering content.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnPreRender (EventArgs e)
        {
            base.OnPreRender (e);

            if (Context.Request.IsAuthenticated)
            {
                Visible = false;
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