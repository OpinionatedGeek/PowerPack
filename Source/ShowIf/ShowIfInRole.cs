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
    /// A Panel-type control that only displays its contents if the user is authenticated and a member of a
    /// specified role.
    /// <p class="i1" style="color: #003399">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// This control gives you a simple way to show some page content <i>only</i> to users who have logged in and
    /// are verified to be members of a specified role.  You to provide content only available to particular groups
    /// of subscribers.
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This facility is available to all browsers.
    /// </p>
    /// <seealso cref="ShowIfLoggedIn"/>
    /// <seealso cref="ShowIfNotLoggedIn"/>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then adds a
    /// ShowIfInRole control which displays a 'Create' button, but only if the user is assigned either the 'author'
    /// or 'admin' role.
    /// <code>
    ///&lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    ///&lt;opgeek:ShowIfInRole
    ///     id="create"
    ///     roles="author, admin"
    ///     runat="server"/&gt;
    ///     ...
    ///     &lt;asp:Button id="createButton" text="Create" OnClick="DoSomethingRestricted" /&gt;
    ///     ...
    ///&lt;/opgeek:ShowIfInRole&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/ShowIfInRole.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [LicenseProvider (typeof (ShowIfInRoleLicenseProvider))]
    [ParseChildren (false)]
    [ToolboxBitmap (typeof (Panel))]
    [Designer (typeof (AutomaticDesigner))]
    public class ShowIfInRole : WebControl
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "ShowIfInRole";

        private readonly char[] roleSeparators = new [] {','};
        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowIfInRole"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="ShowIfInRole"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public ShowIfInRole () : base (HtmlTextWriterTag.Span)
        {
            _license = LicenseManager.Validate (typeof (ShowIfInRole), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets a comma-separated list of roles for which to show the content.
        /// </summary>
        /// <remarks>
        /// Set this property to the name of the role you want to see the content.  If you want more than one
        /// role to see the content, set this property to a comma-separated list of all the roles.
        /// </remarks>
        /// <value>
        /// A comma-separated list of roles.
        /// </value>
        /// <example>
        /// The following code declares the tag for use on the page via the Register directive, and then sets the
        /// content to be visible to the 'admin' and 'author' roles.
        /// <code>
        /// &lt;%@ Register TagPrefix="opgeek"
        ///     Namespace="OpinionatedGeek.Web.PowerPack"
        ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
        /// ...
        /// &lt;opgeek:ShowIfInRole
        ///     id="authorsAndAdminsOnly"
        ///     roles="author, admin"
        ///     runat="server"&gt;
        ///     ...
        ///     Some content only the authors and admins should see
        ///     ...
        /// &lt;/opgeek:ShowIfInRole&gt;
        /// </code>
        /// </example>
        ///
        public string Roles
        {
            get
            {
                return ViewState ["roles"] as string;
            }
            set
            {
                ViewState ["roles"] = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets a comma-separated list of users for which to show the content.
        /// </summary>
        /// <remarks>
        /// Set this property to the name of the user you want to see the content.  If you want more than one
        /// user to see the content, set this property to a comma-separated list of all the users.
        /// </remarks>
        /// <value>
        /// A comma-separated list of usernames.
        /// </value>
        /// <example>
        /// The following code declares the tag for use on the page via the Register directive, and then sets the
        /// content to be visible to the 'geek1' and 'geek2' users.
        /// <code>
        /// &lt;%@ Register TagPrefix="opgeek"
        ///     Namespace="OpinionatedGeek.Web.PowerPack"
        ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
        /// ...
        /// &lt;opgeek:ShowIfInRole
        ///     id="authorsAndAdminsOnly"
        ///     users="geek1, geek2"
        ///     runat="server"&gt;
        ///     ...
        ///     Some content only geek1 and geek2 should see
        ///     ...
        /// &lt;/opgeek:ShowIfInRole&gt;
        /// </code>
        /// </example>
        ///
        public string Users
        {
            get
            {
                return ViewState ["users"] as string;
            }
            set
            {
                ViewState ["users"] = value;

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
            bool visible = false;
            if (Context.Request.IsAuthenticated)
            {
                string users = Users;
                if (!String.IsNullOrEmpty (users))
                {
                    string[] usersArray = users.Split (roleSeparators);
                    foreach (string user in usersArray)
                    {
                        if (Context.User.Identity.Name.Equals (user.Trim ()))
                        {
                            visible = true;
                        }
                    }
                }

                string roles = Roles;
                if ((!visible) && !String.IsNullOrEmpty (roles))
                {
                    string[] rolesArray = roles.Split (roleSeparators);
                    foreach (string szRole in rolesArray)
                    {
                        if (Context.User.IsInRole (szRole.Trim ()))
                        {
                            visible = true;
                        }
                    }
                }
            }

            if (visible)
            {
                HtmlTextWriter realWriter = HtmlTextWriterFactory.CreateCorrectHtmlTextWriter (writer);
                PowerPack.Announce (realWriter, ProductName);

                base.Render (realWriter);
            }

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