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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// BETA VERSION!  THIS PROGRAMMATIC INTERFACE IS NOT STABLE!  A twin list-box control that allows you to multi-select items from a list.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// <p class="i1">
    /// Sometimes you want to have a nice way for users to select items from one list.  For instance,
    /// say you have a list of 100 users and you want to allow the user to specify which ones are in
    /// the 'Trusted' group.  Yes, you can use a standard listbox and tell them to control-click, but
    /// it's a little fragile and it's not the most intuitive.
    /// </p>
    /// <p class="i1">
    /// The TwinListBox control is a more elegant solution, and one which will be familiar to Windows
    /// users.  The control displays a ListBox for "Items" and another ListBox for SelectedItems, along
    /// with some buttons to move items between the two lists.  This is much more intuitive for users.
    /// </p>
    /// <p class="i1">
    /// Note that this is currently a beta control.  It's here for you to provide some feedback, not yet
    /// ready for production use.  The current version uses postbacks for each move - the fully-released
    /// version will, of course, provide client-side functionality for these operations.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b>
    /// This facility is available to all browsers.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then puts
    /// a TwinListBox control on the page, getting the list of people from the GetAllPeople () and
    /// GetTrustedMembers () methods on the page.
    /// <code>
    /// <![CDATA[
    /// <%@ Register TagPrefix="opgeek"
    ///		Namespace="OpinionatedGeek.Web.PowerPack"
    ///		Assembly="OpinionatedGeek.Web.PowerPack"%>
    /// ...
    /// <alchemy:TwinListBox runat="server" id="trusted_membership"
    ///		Source-Label-Text="All People:" Source-Label-CssClass="fieldtitle"
    ///		Source-Width="175"
    ///		Source-DataTextField="Fullname" Source-DataValueField="Name"
    ///		Source-datasource="<%# GetAllPeople () %>"
    ///		Destination-Label-Text="Trusted Members:" Destination-Label-CssClass="fieldtitle"
    ///		Destination-Width="175"
    ///		Destination-DataTextField="Fullname" Destination-DataValueField="Name"
    ///		Destination-datasource="<%# GetTrustedMembers () %>"/>
    ///	<asp:Button Runat="server" text="Save"/>
    /// ]]>
    /// </code>
    /// <p class="i1">
    /// On pressing Save, the updated list of usernames in the Trusted group can be retrieved from
    /// trusted_membership.DestinationItems.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/TwinListBox.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [ParseChildren (true, "Source")]
    [DefaultProperty ("DataSource")]
    [ToolboxData ("<{0}:TwinListBox runat=server></{0}:TwinListBox>")]
    [ToolboxBitmap (typeof (WebControl))]
    [LicenseProvider (typeof (TextBoxLicenseProvider))]
    public class TwinListBox : WebControl
    {
        //============================================================
        // Events
        //============================================================

        //============================================================
        // Private Data
        //============================================================

        private const string ProductName = "TwinListBox";
        private bool _enableClientScript = true;
        private TwinListBoxButtonSet _buttons;
        private TwinListBoxListBoxSet _listBoxes;
        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="TwinListBox"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="TwinListBox"/>
        /// class. This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public TwinListBox ()
        {
            _license = LicenseManager.Validate (typeof (TwinListBox), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets a value indicating whether client-side scripting is enabled.
        /// </summary>
        /// <remarks>
        /// Use the <see cref="EnableClientScript"/> property to specify whether client-side scripting is enabled.
        /// <p class="i1">
        /// Some features, such as the Focus and Prompt properties, require the use of client-side script code
        /// to qork properly.  Setting <see cref="EnableClientScript"/> to false will disable all features which
        /// are dependent on client-side script to work.
        /// </p>
        /// </remarks>
        /// <value><b>True (default)</b> - we allow client-side scripting, if it is possible with the chosen browser.<br/>
        /// <b>False</b> - we prevent client-side scripting and output no client-side code.</value>
        ///
        [Bindable (true), Browsable (true), Category ("System"), DefaultValue (true)]
        [Description (@"Allows you to turn off client-side scripting programmatically, irrespective of which browser is used.")]
        public virtual bool EnableClientScript
        {
            get
            {
                return _enableClientScript;
            }
            set
            {
                _enableClientScript = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets the Source ListBox in the TwinListBox.
        /// </summary>
        /// <remarks>
        /// Gets the Source ListBox, enabling you to directly set properties (such as Width, Height
        /// etc.) on it, and also to set its DataSource.
        /// </remarks>
        /// <value>The ListBox displayed as the Source of items.</value>
        ///
        [Bindable (true)]
        [Browsable (false)]
        public virtual TwinnableListBox Source
        {
            get
            {
                EnsureChildControls ();

                return _listBoxes.Source;
            }
        }

        ///
        /// <summary>
        /// Gets the Destination ListBox in the TwinListBox.
        /// </summary>
        /// <remarks>
        /// Gets the Destination ListBox, enabling you to directly set properties (such as Width, Height
        /// etc.) on it, and also to set its DataSource.
        /// </remarks>
        /// <value>The ListBox displayed as the Destination of items.</value>
        ///
        [Bindable (true)]
        [Browsable (false)]
        public virtual TwinnableListBox Destination
        {
            get
            {
                EnsureChildControls ();

                return _listBoxes.Destination;
            }
        }

        ///
        /// <summary>
        /// Gets the collection of Buttons used for moving items.
        /// </summary>
        /// <remarks>
        /// Gets the collection of Buttons used by the control, allowing you to hook into their events
        /// or change their Text.
        /// </remarks>
        /// <value>The TwinListBoxButtonSet of all Buttons.</value>
        ///
        [Bindable (true)]
        [Browsable (false)]
        public TwinListBoxButtonSet Buttons
        {
            get
            {
                EnsureChildControls ();

                return _buttons;
            }
        }

        //============================================================
        // Events
        //============================================================

        ///
        /// <summary>
        /// Raises the Init event.
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

            EnsureChildControls ();

            return;
        }

        ///
        /// <summary>
        /// Raises the PreRender event.
        /// </summary>
        /// <remarks>
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their OnPreRender.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnPreRender (EventArgs e)
        {
            base.OnPreRender (e);

            var itemsToRemove = new List<object> ();
            foreach (ListItem item in _listBoxes.Source.Items)
            {
                if (_listBoxes.Destination.Items.FindByValue (item.Value) != null)
                {
                    itemsToRemove.Add (item);
                }
            }

            foreach (ListItem item in itemsToRemove)
            {
                _listBoxes.Source.Items.Remove (item);
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

        ///
        /// <summary>
        /// Notifies server controls that use composition-based implementation to create any child controls they
        /// contain in preparation for posting back or rendering.
        /// </summary>
        /// <remarks>
        /// When you develop a composite or templated server control, you must override this method.
        /// </remarks>
        ///
        protected override void CreateChildControls ()
        {
            base.CreateChildControls ();

            var table = new HtmlTable ();
            Controls.Add (table);
            var row = new HtmlTableRow ();
            table.Controls.Add (row);
            var destination = new HtmlTableCell ();
            row.Controls.Add (destination);
            var buttonColumn = new HtmlTableCell ();
            row.Controls.Add (buttonColumn);
            var source = new HtmlTableCell ();
            row.Controls.Add (source);

            var destinationListBox = new TwinnableListBox {Height = 150, SelectionMode = ListSelectionMode.Multiple};
            destination.Controls.Add (destinationListBox);

            var sourceListBox = new TwinnableListBox {Height = 150, SelectionMode = ListSelectionMode.Multiple};
            source.Controls.Add (sourceListBox);

            _listBoxes = new TwinListBoxListBoxSet (sourceListBox, destinationListBox);

            var addSelected = new Button {Text = Globalisation.GetString ("addSelected"), Width = 50};
            addSelected.Click += butAddSelected_Click;
            buttonColumn.Controls.Add (addSelected);
            buttonColumn.Controls.Add (new LiteralControl ("<br />"));

            var addAll = new Button {Text = Globalisation.GetString ("addAll"), Width = 50};
            addAll.Click += butAddAll_Click;
            buttonColumn.Controls.Add (addAll);
            buttonColumn.Controls.Add (new LiteralControl ("<br />"));

            var removeSelected = new Button {Text = Globalisation.GetString ("removeSelected"), Width = 50};
            removeSelected.Click += butRemoveSelected_Click;
            buttonColumn.Controls.Add (removeSelected);
            buttonColumn.Controls.Add (new LiteralControl ("<br />"));

            var removeAll = new Button {Text = Globalisation.GetString ("removeAll"), Width = 50};
            removeAll.Click += butRemoveAll_Click;
            buttonColumn.Controls.Add (removeAll);

            _buttons = new TwinListBoxButtonSet (addSelected, addAll, removeSelected, removeAll);

            return;
        }

        private void butAddSelected_Click (object sender, EventArgs e)
        {
            DeselectDestinationItems ();

            var itemsToAdd = new List<object> ();
            foreach (ListItem item in _listBoxes.Source.Items)
            {
                if (item.Selected)
                {
                    itemsToAdd.Add (item);
                }
            }

            foreach (ListItem item in itemsToAdd)
            {
                _listBoxes.Source.Items.Remove (item);
                _listBoxes.Destination.Items.Add (item);
            }

            DeselectSourceItems ();

            return;
        }

        private void butAddAll_Click (object sender, EventArgs e)
        {
            DeselectDestinationItems ();

            var itemsToAdd = new List<object> ();
            foreach (ListItem item in _listBoxes.Source.Items)
            {
                itemsToAdd.Add (item);
            }

            foreach (ListItem item in itemsToAdd)
            {
                _listBoxes.Source.Items.Remove (item);
                _listBoxes.Destination.Items.Add (item);
            }

            DeselectSourceItems ();

            return;
        }

        private void butRemoveSelected_Click (object sender, EventArgs e)
        {
            DeselectSourceItems ();

            var itemsToRemove = new List<object> ();
            foreach (ListItem item in _listBoxes.Destination.Items)
            {
                if (item.Selected)
                {
                    itemsToRemove.Add (item);
                }
            }

            foreach (ListItem item in itemsToRemove)
            {
                _listBoxes.Destination.Items.Remove (item);
                _listBoxes.Source.Items.Add (item);
            }

            DeselectDestinationItems ();

            return;
        }

        private void butRemoveAll_Click (object sender, EventArgs e)
        {
            DeselectSourceItems ();

            var itemsToRemove = new List<object> ();
            foreach (ListItem item in _listBoxes.Destination.Items)
            {
                itemsToRemove.Add (item);
            }

            foreach (ListItem item in itemsToRemove)
            {
                _listBoxes.Destination.Items.Remove (item);
                _listBoxes.Source.Items.Add (item);
            }

            DeselectDestinationItems ();

            return;
        }

        private void DeselectSourceItems ()
        {
            DeselectAllItems (_listBoxes.Source);

            return;
        }

        private void DeselectDestinationItems ()
        {
            DeselectAllItems (_listBoxes.Destination);

            return;
        }

        private static void DeselectAllItems (ListControl itemsToDeselect)
        {
            foreach (ListItem item in itemsToDeselect.Items)
            {
                item.Selected = false;
            }

            return;
        }
    }
}