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
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// Validates whether the current page has already been posted to the server.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// The <see cref="NoRepostValidator"/> provides a simple way of ensuring that a page is posted once and
    /// only once.
    /// <p class="i1">
    /// Some web forms are forms that you want to reload when the user hits 'Refresh', and that's fine by default.
    /// However, some important pages are ones that should be posted once and only once.  If someone has just
    /// posted a message to your forum, you don't want that message posted again if the user hits 'F5' by mistake.
    /// Or worse, you don't want to charge the user twice for a transaction if they accidentally double-click
    /// the submit button.
    /// </p>
    /// <p class="i1">
    /// All this validator does is check to see if the current page has already been submitted.  If it hasn't, the
    /// validation succeeds and the submission goes ahead.  If the page <i>has</i> already been submitted, validation
    /// fails.
    /// </p>
    /// <p class="i1">
    /// Note that this validator control is designed to allow the posting of new or changed data.  Only 'refreshes',
    /// where the same data is posted twice, are caught and returned invalid.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then puts
    /// a TextBox and EmailAddressValidator control on the page.  This validator is set to verify the server
    /// DNS record exists but not to verify the recipient address on that server.
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:TextBox
    ///     id="tbEmail"
    ///     runat="server"/&gt;
    /// &lt;opgeek:NoRepostValidator
    ///     ErrorMessage="You have already submitted this form"
    ///     runat="server"/&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/NoRepostValidator.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [ValidationProperty ("Text")]
    [LicenseProvider (typeof (NoRepostValidatorLicenseProvider))]
    [ToolboxBitmap (typeof (RequiredFieldValidator))]
    public class NoRepostValidator : BaseValidator
    {
        //============================================================
        // Private Data
        //============================================================

        private const string ProductName = "NoRepostValidator";

        private const string ViewStateRequestIdKey = "NoRepostValidatorId";
        private const string RequestIdPageIdSeparator = "_opgeek_NoRepostValidator_";

        private int _repostDuration = 15;
        private static int _lastRequestId;
        private string _currentRequestId;

        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="NoRepostValidator"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="NoRepostValidator"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public NoRepostValidator ()
        {
            _license = LicenseManager.Validate (typeof (NoRepostValidator), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets the number of minutes to cache post metadata.
        /// </summary>
        /// <remarks>
        /// In order to track whether a post has been submitted previously, it's necessary to store a small amount
        /// of data in the ASP.NET cache.  This value controls how long the data should stay in the cache.
        /// High-volume sites may want to reduce this value so that the cache remains small.  Sites paranoid about
        /// reposts may want to increase this value so that there is even less risk of a repost being accepted.
        /// </remarks>
        /// <value>Number of minutes to cache post metadata.  The default value is <b>15 minutes</b>.</value>
        ///
        public int RespostCheckTimeout
        {
            get
            {
                return _repostDuration;
            }
            set
            {
                _repostDuration = value;

                return;
            }
        }

        private string PreviousRequestId
        {
            get
            {
                return ViewState [ViewStateRequestIdKey] as string;
            }
        }

        private string CurrentRequestId
        {
            get
            {
                if (_currentRequestId == null)
                {
                    _currentRequestId = BuildRequestKey ();
                }

                return _currentRequestId;
            }
        }

        //============================================================
        // Methods
        //============================================================

        ///
        /// <summary>
        /// Raises the <see cref="Control.Init"/> event.
        /// </summary>
        /// <remarks>
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their OnInit.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            PowerPack.EnsureIdSet (this);

            ControlToValidate = ID;

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
            ViewState [ViewStateRequestIdKey] = CurrentRequestId;

            base.OnPreRender (e);

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
        /// <param name="writer">The <see cref="HtmlTextWriter"/> object that receives the server control content.</param>
        ///
        protected override void Render (HtmlTextWriter writer)
        {
            HtmlTextWriter realWriter = HtmlTextWriterFactory.CreateCorrectHtmlTextWriter (writer);
            PowerPack.Announce (realWriter, ProductName);

            base.Render (realWriter);

            return;
        }

        ///
        /// <summary>
        /// This method contains the code to determine whether this exact form has already been submitted or not.
        /// </summary>
        /// <remarks>
        /// Checks to see if this is a 'refresh' or a new submission.
        /// </remarks>
        /// <returns>
        /// <b>true</b> if the form is a new submission; otherwise, <b>false</b> because the form has already been submitted.
        /// </returns>
        ///
        protected override bool EvaluateIsValid ()
        {
            bool isValid = false;
            string requestId = PreviousRequestId;
            bool previouslySubmitted = GetCachedValue (requestId);
            if (!previouslySubmitted)
            {
                SetCachedValue (requestId);
                isValid = true;
            }

            return isValid;
        }

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

        private static string BuildRequestKey ()
        {
            return HttpContext.Current.Request.Path + RequestIdPageIdSeparator + GetNewRequestId ();
        }

        private static int GetNewRequestId ()
        {
            return ++_lastRequestId;
        }

        private static bool GetCachedValue (string requestId)
        {
            bool cached = false;
            var cachedValue = HttpContext.Current.Cache [requestId] as string;
            if (cachedValue == bool.TrueString)
            {
                cached = true;
            }

            return cached;
        }

        private void SetCachedValue (string requestId)
        {
            if (HttpContext.Current.Cache [requestId] != null)
            {
                HttpContext.Current.Cache.Remove (requestId);
            }

            HttpContext.Current.Cache.Insert (requestId, bool.TrueString, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes (RespostCheckTimeout));

            return;
        }
    }
}