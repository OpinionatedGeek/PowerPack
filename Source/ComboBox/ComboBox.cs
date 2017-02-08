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
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A genuine multi-platform ComboBox box, the common Windows/GUI widget!
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// A ComboBox box is a very common Windows/GUI widget.  It's a combination of the functionality of a dropdown
    /// and a textbox.  You can select an item from the dropdown list, or you can enter a value that isn't present
    /// in the list.
    /// <p class="i1">
    /// This differs from the normal HTML select/dropdown control.  The normal operation of the HTML control is to
    /// prevent users adding entries not in the predefined list.  That is fine in some situations, but in others it
    /// is preferential to allow users to create new entries 'on the fly'.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// The true ComboBox box is provided through DHTML in Internet Explorer 5 or higher, and Mozilla/Netscape 6
    /// or higher.  If it is not possible to provide the DHTML display in the current browser, then a dropdowns
    /// and a textbox is provided.  This will work in any browser.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then adds a
    /// ComboBox box with three initial entries.
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:ComboBox
    ///     id="cmbProducts"
    ///     runat="server"&gt;
    ///        &lt;asp:ListItem text="Hammer"/&gt;
    ///        &lt;asp:ListItem text="Screwdriver"/&gt;
    ///        &lt;asp:ListItem text="Pliers"/&gt;
    /// &lt;/opgeek:ComboBox&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/ComboBox.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [DefaultProperty ("Text")]
    [ValidationProperty ("Text")]
    [ToolboxData ("<{0}:ComboBox runat=server></{0}:ComboBox>")]
    [LicenseProvider (typeof (ComboBoxLicenseProvider))]
    [ToolboxBitmap (typeof (DropDownList))]
    [Designer (typeof (ListControlDesigner))]
    public class ComboBox : ListControl, INamingContainer, IPostBackDataHandler
    {
        //============================================================
        // Events
        //============================================================

        //============================================================
        // Constants
        //============================================================

        internal const string TextboxFieldId = "TextBox_opgeek";
        internal const string ProductName = "ComboBox";
        private const string EntriesAddedByUserViewStateKey = "EntriesAddedByUser";

        //============================================================
        // Private Data
        //============================================================

        private DefaultComboBoxField _realField;
        private License _license;
        private bool _textFieldChanged;
        private bool _explicitlyAbsolutelyPositioned;
        private short _tabIndex = -1;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="ComboBox"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public ComboBox ()
        {
            _license = LicenseManager.Validate (typeof (ComboBox), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets some text to be inserted between the dropdown and the textbox on downlevel browsers.
        /// </summary>
        /// <remarks>
        /// This property is only output on downlevel browsers, where the control is rendered as two separate
        /// fields - a dropdown and a textbox.  Text set in this property will appear between the two controls,
        /// giving a measure of control over their layout.  For example, you could set this property to "or",
        /// so that the user sees the dropdown, then the word "or", then the textbox, giving an indication of
        /// how the two fields are to be used.  This property also accepts HTML, so you can put in "&lt;br&gt;"
        /// to have the two controls appear on separate lines.
        /// </remarks>
        /// <value>Text to be inserted between the dropdown and the textbox on downlevel browsers.</value>
        ///
        public string MidText
        {
            get
            {
                EnsureChildControls ();

                return _realField.MidText;
            }
            set
            {
                EnsureChildControls ();

                _realField.MidText = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="ComboBox"/> control is enabled.
        /// </summary>
        /// <remarks>
        /// Use the Enabled property to specify or determine whether the <see cref="ComboBox"/> is
        /// functional. When set to false, the control appears dimmed, and no new value can be entered or
        /// selected.
        /// </remarks>
        /// <value><b>true</b> if control is enabled; otherwise, <b>false</b>. The default is <b>true</b>.</value>
        ///
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                EnsureChildControls ();

                base.Enabled = value;
                _realField.Enabled = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets the height of the ComboBox.  It is not possible to set the height.
        /// </summary>
        /// <remarks>
        /// While an INPUT field allows you to set the height of it, not all browsers support
        /// setting the height of a SELECT field.  (Notably Internet Explorer does not permit
        /// this.)  In order to prevent broken layouts, this property cannot be set on the
        /// ComboBox - any value set here will be ignored.
        /// </remarks>
        /// <value><b>Unit</b> The height of the ComboBox.</value>
        ///
        public override Unit Height
        {
            get
            {
                return base.Height;
            }
// ReSharper disable ValueParameterNotUsed
            set
// ReSharper restore ValueParameterNotUsed
            {
                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="ComboBox"/> can have text entered or not.
        /// </summary>
        /// <remarks>
        /// Use the TextEntryEnabled property to turn off the Combo behaviour and have the control behave as a
        /// regular dropdown control.
        /// </remarks>
        /// <value><b>true</b> if text entry is enabled; otherwise, <b>false</b>. The default is <b>true</b>.</value>
        ///
        public bool TextEntryEnabled
        {
            get
            {
                EnsureChildControls ();

                return _realField.Visible;
            }
            set
            {
                EnsureChildControls ();

                _realField.Visible = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the tab index of the <see cref="ComboBox"/> control.
        /// </summary>
        /// <remarks>
        /// Use the TabIndex property to specify or determine the tab index of a Web server control on the
        /// Web Forms page.
        /// </remarks>
        /// <value>The tab index of the <see cref="ComboBox"/> control.</value>
        ///
        public override short TabIndex
        {
            get
            {
                EnsureChildControls ();

                short tabIndex;
                if (HttpContext.Current == null)
                {
                    tabIndex = _tabIndex;
                }
                else
                {
                    tabIndex = -1;
                }

                return tabIndex;
            }
            set
            {
                EnsureChildControls ();

                if (HttpContext.Current == null)
                {
                    _tabIndex = value;
                }
                else
                {
                    _realField.TabIndex = value;
                }

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets a value indicating whether a postback to the server automatically occurs when the user
        /// changes the list selection or types a new value.
        /// </summary>
        /// <remarks>
        /// Set this property to true if the server needs to capture the selection as soon as it is made. For example,
        /// other controls on the Web page can be automatically filled depending on the user's selection from a list
        /// control.
        /// <p class="i1">
        /// This property can be used to allow automatic population of other controls on the Web page based on a
        /// user's selection from a list.
        /// </p>
        /// </remarks>
        /// <value><b>true</b> if a postback to the server automatically occurs whenever the user changes the selection of the list; otherwise, <b>false</b>. The default is <b>false</b>.</value>
        ///
        public override bool AutoPostBack
        {
            get
            {
                return base.AutoPostBack;
            }
            set
            {
                EnsureChildControls ();

                base.AutoPostBack = value;
                _realField.AutoPostBack = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the currently selected item in the dropdown.
        /// </summary>
        /// <remarks>
        /// Gets or sets the currently selected item.  Returns an empty string if there are no entries.  Creates
        /// a new entry for the value if that entry does not exist, otherwise sets the selected index to the first
        /// occurrance of the set value as either the Text or Value property of one of the contained Items.
        /// </remarks>
        /// <value>The currently selected item in the dropdown</value>
        ///
        [DesignerSerializationVisibility (DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                string text = String.Empty;
                if (SelectedItem != null)
                {
                    text = SelectedItem.Text;
                }

                return text;
            }
            set
            {
                EnsureChildControls ();

                bool foundSelectedItem = FindAndSelectItem (value, value);
                if (!foundSelectedItem)
                {
                    AddNewSelection (value, value);
                }
                _realField.Text = value;

                return;
            }
        }

        private ArrayList EntriesAddedByUser
        {
            get
            {
                var added = ViewState [EntriesAddedByUserViewStateKey] as ArrayList;
                if (added == null)
                {
                    added = new ArrayList ();
                    ViewState [EntriesAddedByUserViewStateKey] = added;
                }

                return added;
            }
        }

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
        /// Processes post back data for the server control.
        /// </summary>
        /// <remarks>
        /// The ASP.NET server tracks all the server controls that return True to this method call, then later
        /// invokes the RaisePostDataChangedEvent on those controls.
        /// </remarks>
        /// <param name="postDataKey">The key identifier for the control.</param>
        /// <param name="postCollection">The collection of all incoming name values.</param>
        /// <returns><b>True</b> if the server control's state changes as a result of the post back; otherwise <b>False</b>.</returns>
        ///
        public bool LoadPostData (string postDataKey, NameValueCollection postCollection)
        {
            EnsureChildControls ();

            _textFieldChanged = _realField.InternalLoadPostData (_realField.UniqueID, postCollection);
            bool loadedNewPostValue = false;

            string textFieldValue = _realField.Text;
            string previousValue = Text;
            string postedDropdownValue = postCollection [postDataKey] ?? "";
            bool dropDownChanged = (previousValue != postedDropdownValue);
//			bool nFirstRepost = (szPreviousValue.Length == 0);
//
//			if (nFirstRepost)
//			{
//				if (this.Items.FindByValue (szTextFieldValue) != null)
//				{
//					this.Text = szPostedDropdownValue;
//					if (
//					nLoadedNewPostValue = true;
//				}
//				else
//				{
//					if (this.Text != szTextFieldValue)
//					{
//						this.Text = szTextFieldValue;
//						nLoadedNewPostValue = true;
//					}
//					else if (nDropDownChanged)
//					{
//						this.Text = szPostedDropdownValue;
//						nLoadedNewPostValue = true;
//					}
//				}
//			}
//			else
//			{
            if (dropDownChanged)
            {
                Text = postedDropdownValue;
                loadedNewPostValue = true;
            }
            else if ((TextEntryEnabled) && (_textFieldChanged))
            {
                Text = textFieldValue;
                loadedNewPostValue = true;
            }
//			}

            return loadedNewPostValue;
        }

        ///
        /// <summary>
        /// Signals the server control to notify the ASP.NET application that the state of the control has changed.
        /// </summary>
        /// <remarks>
        /// This method forms part of the IPostBackDataHandler interface.  It is the standard mechanism by which
        /// the ASP.NET server tells the server control it has reached the point where all watchers should be
        /// notified that this controls' value (SelectedIndex) has changed.  (It knows if the value has changed
        /// because LoadPostData will have returned True.)
        /// </remarks>
        ///
        public virtual void RaisePostDataChangedEvent ()
        {
            OnSelectedIndexChanged (EventArgs.Empty);

            if (_textFieldChanged)
            {
                IPostBackDataHandler textField = _realField;
                textField.RaisePostDataChangedEvent ();
                OnTextChanged (EventArgs.Empty);
            }

            return;
        }

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

            Page.RegisterRequiresPostBack (this);

            EnsureChildControls ();

            base.TabIndex = -1;

            if ((Style ["position"] == null) && (Style ["POSITION"] == null))
            {
                Style.Add ("position", "absolute");
            }
            else
            {
                _explicitlyAbsolutelyPositioned = true;
            }

            if (!IsInDesignMode)
            {
                Style.Add ("display", "none");
            }

            _realField.Text = Text;

            return;
        }

        ///
        /// <summary>
        /// Raises the Load event.
        /// </summary>
        /// <remarks>
        /// This method notifies the server control that it should perform actions common to each HTTP request
        /// for the page it is associated with, such as setting up a database query. At this stage in the page
        /// lifecycle, server controls in the hierarchy are created and initialized, view state is restored,
        /// and form controls reflect client-side data.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnLoad (EventArgs e)
        {
//			if ((!_nLoadPostDataCalled) && (this.Page.IsPostBack))
//			{
//				LoadPostData (this.ID, HttpContext.Current.Request.Form);
//			}

            base.OnLoad (e);

            EnsureChildControls ();

            _realField.AddAttributes (Attributes);
            foreach (string key in Style.Keys)
            {
                if (Normaliser.StringCompare (key, "position"))
                {
                    if (_explicitlyAbsolutelyPositioned)
                    {
                        _realField.Style.Add (key, Style [key]);
                    }
                }
                else if (!Normaliser.StringCompare (key, "display"))
                {
                    _realField.Style.Add (key, Style [key]);
                }
            }

            if (_explicitlyAbsolutelyPositioned)
            {
                string topName = CssHelper.GetCaseInsensitiveName (Style, "TOP");
                if (topName != null)
                {
                    Style.Remove (topName);
                }

                string leftName = CssHelper.GetCaseInsensitiveName (Style, "LEFT");
                if (leftName != null)
                {
                    Style.Remove (leftName);
                }
            }

            return;
        }

        ///
        /// <summary>
        /// Raises the <b>SelectedIndexChanged</b> event.
        /// </summary>
        /// <remarks>
        /// This method notifies the server control that the selected index in the dropdown has been changed.
        /// <p class="i1">
        /// Notes to Inheritors:  When overriding <see cref="OnSelectedIndexChanged"/> in a derived class, be sure
        /// to call the base class's <see cref="OnSelectedIndexChanged"/> method.
        /// </p>
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnSelectedIndexChanged (EventArgs e)
        {
            base.OnSelectedIndexChanged (e);

            string dropdownFieldValue = Text;
            if (!String.IsNullOrEmpty (dropdownFieldValue))
            {
                FindAndSelectItem (dropdownFieldValue, dropdownFieldValue);
            }

            return;
        }

        ///
        /// <summary>
        /// Restores view-state information from a previous page request that was saved by the
        /// <see cref="Control.SaveViewState"/> method.
        /// </summary>
        /// <remarks>
        /// Be very careful if you override this method to customize how a derived ComboBox restores its view state.
        /// Be sure that derived classes also call this version of the LoadViewState method in addition to carrying
        /// out their own processing.
        /// </remarks>
        /// <param name="savedState">An <see cref="Object"/> that represents the control state to be restored.</param>
        ///
        protected override void LoadViewState (object savedState)
        {
            var stashedItems = new ListItemCollection ();
            foreach (ListItem item in Items)
            {
                stashedItems.Add (item);
            }

            Items.Clear ();

            base.LoadViewState (savedState);

            foreach (ListItem liItem in stashedItems)
            {
                if (Items.FindByValue (liItem.Value) == null)
                {
                    Items.Add (liItem);
                }
            }

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

            if ((SelectedIndex == -1) && (TextEntryEnabled))
            {
                if (Items.FindByValue (String.Empty) == null)
                {
                    var item = new ListItem (String.Empty, String.Empty);
                    Items.Insert (0, item);
                    SelectedIndex = 0;
                }
            }

            if (!TextEntryEnabled)
            {
                Style.Remove ("position");
                Style.Remove ("display");
            }

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
        protected override void Render (HtmlTextWriter writer)
        {
            HtmlTextWriter realWriter = HtmlTextWriterFactory.CreateCorrectHtmlTextWriter (writer);
            PowerPack.Announce (realWriter, ProductName);

            if (Page != null)
            {
                Page.VerifyRenderingInServerForm (this);
            }

            _realField.FinaliseAttributes ();

            _realField.RenderBeforeControl (realWriter);

            base.RenderBeginTag (realWriter);
            foreach (ListItem liItem in Items)
            {
                string selected = liItem.Selected ? "selected=\"selected\" " : String.Empty;
                realWriter.Write ("\t<option {2}value=\"{0}\">{1}</option>\n", HttpUtility.HtmlEncode (liItem.Value), liItem.Text, selected);
            }

            base.RenderEndTag (realWriter);
            if (!IsInDesignMode)
            {
                _realField.RenderMidText (realWriter);
                _realField.ApplyStyle (ControlStyle);
                _realField.RenderControl (realWriter);
                _realField.RenderAfterControl (realWriter);
            }

            return;
        }

        //============================================================
        // Methods
        //============================================================

        ///
        /// <summary>
        /// Tests the currently selected <see cref="ComboBox"/> value to see if it was added by the user or if
        /// it was in the default list.
        /// </summary>
        /// <remarks>
        /// The greatest benefit from using the <see cref="ComboBox"/> is that the user can enter a value not
        /// in the dropdown list.  However, sometimes it's useful to know in your form processing whether or not
        /// an item was in the original dropdown list or if it was added by the user.  For example, if you retrieve
        /// the list contents from a database, you'll need to update the list if the user has entered a new value
        /// not in the list, but you may not need to do anything if the user just picked a list entry.
        /// <p class="i1">
        /// This method gives you a way of checking the currently selected <see cref="ComboBox"/> value.  The method
        /// returns <b>True</b> for all entries typed in by the user, and <b>False</b> for all entries added
        /// programmatically (through the 'Add ()' method) or contained in tags on the ASPX page.
        /// </p>
        /// </remarks>
        /// <value><b>True</b> - the value was typed by the user<br/>
        /// <b>False</b> - the value was added to the list programmatically.</value>
        ///
        public bool AddedByUser ()
        {
            bool isAdded = false;
            if (SelectedItem != null)
            {
                isAdded = AddedByUser (SelectedItem.Value);
            }

            return isAdded;
        }

        ///
        /// <summary>
        /// Tests a <see cref="ComboBox"/> value to see if it was added by the user or if it was in the default list.
        /// </summary>
        /// <remarks>
        /// The greatest benefit from using the <see cref="ComboBox"/> is that the user can enter a value not
        /// in the dropdown list.  However, sometimes it's useful to know in your form processing whether or not
        /// an item was in the original dropdown list or if it was added by the user.  For example, if you retrieve
        /// the list contents from a database, you'll need to update the list if the user has entered a new value
        /// not in the list, but you may not need to do anything if the user just picked a list entry.
        /// <p class="i1">
        /// This method gives you a way of checking a <see cref="ComboBox"/> value.  The method returns <b>True</b>
        /// for all entries typed in by the user, and <b>False</b> for all entries added programmatically (through
        /// the 'Add ()' method) or contained in tags on the ASPX page.
        /// </p>
        /// </remarks>
        /// <param name="valueToTest">The <see cref="ComboBox"/> value to test.</param>
        /// <value><b>True</b> - the value was typed by the user<br/>
        /// <b>False</b> - the value was added to the list programmatically.</value>
        ///
        public bool AddedByUser (string valueToTest)
        {
            return EntriesAddedByUser.Contains (valueToTest);
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
        /// <param name="writer">A <see cref="System.Web.UI.HtmlTextWriter"/> that represents the writer stream
        /// to render HTML content on the client.</param>
        ///
        protected override void AddAttributesToRender (HtmlTextWriter writer)
        {
            writer.AddAttribute (HtmlTextWriterAttribute.Name, UniqueID);

            if (AutoPostBack && Page != null)
            {
                if (Attributes ["onchange"] != null)
                {
                    Attributes.Remove ("onchange");
                }
                writer.AddAttribute (HtmlTextWriterAttribute.Onchange, Page.ClientScript.GetPostBackEventReference (this, ""));
            }

            base.AddAttributesToRender (writer);

            return;
        }

        ///
        /// <summary>
        /// Notifies server controls that use composition-based implementation to create any child controls
        /// they contain in preparation for posting back or rendering.
        /// </summary>
        /// <remarks>
        /// If you override this method in a derived class, make sure you call this method as part of your
        /// base class's CreateChildControls.
        /// </remarks>
        ///
        protected override void CreateChildControls ()
        {
            base.CreateChildControls ();

            if (HttpContext.Current != null)
            {
                HttpBrowserCapabilities browserType = HttpContext.Current.Request.Browser;
                _realField = ComboBoxFieldFactory.GetField (browserType);

                _realField.SetParentComboBox (this);
            }
            else
            {
                _realField = new IE5ComboBoxField ();
            }

            _realField.TextChanged += FireTextChangedEvent;

            _realField.ID = TextboxFieldId;

            Controls.Add (_realField);

            ChildControlsCreated = true;

            return;
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
            if (disposing)
            {
                if (_license != null)
                {
                    _license.Dispose ();
                    _license = null;
                }

                if (_realField != null)
                {
                    _realField.Dispose ();
                    _realField = null;
                }
            }

            return;
        }

        private void AddNewSelection (string text, string value)
        {
            if (value != null)
            {
                ClearSelection ();

                var newItem = new ListItem {Text = text, Value = value, Selected = true};
                Items.Add (newItem);
                EntriesAddedByUser.Add (value);
                SelectedIndex = Items.Count - 1;
            }

            return;
        }

        private bool FindAndSelectItem (string text, string value)
        {
            bool foundSelectedItem = false;
            for (int itemCounter = 0; !foundSelectedItem && itemCounter < Items.Count; itemCounter++)
            {
                if ((Items [itemCounter].Value == value) || (Items [itemCounter].Text == text))
                {
                    SelectedIndex = itemCounter;
                    foundSelectedItem = true;
                }
            }

            return foundSelectedItem;
        }

        private void FireTextChangedEvent (object sender, EventArgs e)
        {
            OnTextChanged (e);

            return;
        }
    }
}