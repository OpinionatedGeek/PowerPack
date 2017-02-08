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
using System.Collections.Specialized;
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
    /// A field that allows you to pick one specific date, usually from a nice WYSIWYG display.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// This web control allows the user to pick one date.  Where possible it provides a simple DHTML interface
    /// with a popup window showing the selected month and allowing the user to scroll months forwards and
    /// backwards.
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// The WYSIWYG display is provided through DHTML in Internet Explorer 5 or higher, Netscape 4 or
    /// higher, and Mozilla/Netscape 6.  If it is not possible to provide the DHTML display in the current
    /// browser, then three dropdowns (one each for day, month and year) are provided.  This will work in
    /// any browser.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then puts
    /// a DatePicker control on the page with the selected date defaulting to the current day.
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:DatePicker
    ///     name="test"
    ///     runat="server"/&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/DatePicker.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [DefaultProperty ("Value")]
    [ToolboxData ("<{0}:DatePicker runat=server></{0}:DatePicker>")]
    [ToolboxBitmap (typeof (Bitmap))]
    [LicenseProvider (typeof (DatePickerLicenseProvider))]
    public class DatePicker : WebControl, IPostBackDataHandler
    {
        //============================================================
        // Events
        //============================================================

        ///
        /// <summary>
        /// Occurs when the date in the DatePicker field changes between posts to the server.
        /// </summary>
        /// <remarks>
        /// The <see cref="DateChanged"/> event is raised when the content of the DatePicker field changes between
        /// posts to the server.
        /// <p class="i1">
        /// Note: A <see cref="DatePicker"/> control must persist some values between posts to the server for this
        /// event to work correctly. Be sure that view state is enabled for this control.
        /// </p>
        /// </remarks>
        ///
        public event EventHandler DateChanged;

        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "DatePicker";

        private DefaultDatePickerField _realField;

        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="DatePicker"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="DatePicker"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public DatePicker () : base (HtmlTextWriterTag.Div)
        {
            _license = LicenseManager.Validate (typeof (DatePicker), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// The first year to be shown in the basic datepicker year dropdown.
        /// </summary>
        /// <remarks>
        /// The basic version of the DatePicker has three dropdowns, one for day, one for month,
        /// and one for year.  This sets the first year that should be shown in the year dropdown.
        /// Note: this does not yet work for the DHTML versions.
        /// </remarks>
        /// <value>The first year that can be selected.  The default is 1970.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue (DatePickerConstants.DefaultFirstYear)]
        [Description (@"The first year to be shown in the basic datepicker year dropdown.")]
        public int FirstYear
        {
            get
            {
                EnsureChildControls ();

                return _realField.FirstYear;
            }
            set
            {
                EnsureChildControls ();

                _realField.FirstYear = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets a unique identifier assigned to the DatePicker instance.
        /// </summary>
        /// <remarks>
        /// Gives the control the unique name which can be used to reference it elsewhere on the page.
        /// </remarks>
        /// <value>The unique identifier assigned to the control.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue (DatePickerConstants.DefaultControlName)]
        [Description ("The unique ID for this DatePicker control.")]
        public override string ID
        {
            get
            {
                EnsureChildControls ();

                return _realField.ID;
            }
            set
            {
                EnsureChildControls ();

                base.ID = value;

                _realField.ID = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets a value indicating whether the DatePicker server control is enabled.
        /// </summary>
        /// <remarks>
        /// Use the Enabled property to specify or determine whether a control is functional. When set to <b>false</b>,
        /// the control appears dimmed, preventing any input from being entered in the control.
        /// </remarks>
        /// <value><b>true</b> if control is enabled; otherwise, <b>false</b>. The default is <b>true</b>.</value>
        ///
        [Bindable (true), Browsable (true), Category ("System"), DefaultValue (true)]
        [Description ("Gets or sets a value indicating whether the DatePicker server control is enabled.")]
        public override bool Enabled
        {
            get
            {
                EnsureChildControls ();

                return _realField.Enabled;
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
        /// Gets or sets a value indicating whether the DatePicker defaults to the current date or not.
        /// </summary>
        /// <remarks>
        /// The DatePicker can be set to show the current date on its first display (before selection and postback),
        /// or it can be set to appear empty, with no date shown.  This property toggles this behaviour.  Setting
        /// this property to <b>true</b> displays the field with the current date shown as the default, setting it
        /// to <b>false</b> displays an empty DatePicker field with no default value.
        /// </remarks>
        /// <value><b>true</b> if control should default to the current date; otherwise, <b>false</b>. The default is <b>true</b>.</value>
        ///
        [Bindable (true), Browsable (true), Category ("System"), DefaultValue (true)]
        [Description ("Gets or sets a value indicating whether the DatePicker defaults to the current date or not.")]
        public bool DefaultToCurrentDate
        {
            get
            {
                EnsureChildControls ();

                return _realField.DefaultToCurrentDate;
            }
            set
            {
                EnsureChildControls ();

                _realField.DefaultToCurrentDate = value;

                return;
            }
        }

        ///
        /// <summary>
        /// The last year to be shown in the basic datepicker year dropdown.
        /// </summary>
        /// <remarks>
        /// The basic version of the DatePicker has three dropdowns, one for day, one for month,
        /// and one for year.  This sets the last year that should be shown in the year dropdown.
        /// Note: this does not yet work for the DHTML versions.
        /// </remarks>
        /// <value>The last year that can be selected.  The default is 2050.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue (DatePickerConstants.DefaultLastYear)]
        [Description (@"The last year to be shown in the basic datepicker year dropdown.")]
        public int LastYear
        {
            get
            {
                EnsureChildControls ();

                return _realField.LastYear;
            }
            set
            {
                EnsureChildControls ();

                _realField.LastYear = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the display format to be used to display the date in the DatePicker.
        /// </summary>
        /// <remarks>
        /// This property allows you to specify a display format to be used in the DatePicker
        /// control itself.  The format is quite simple - one important thing to note is that
        /// this control does not fully support standard .NET date format strings.  (There's
        /// no reason it couldn't, but it's important to realise that this format string is
        /// interpreted on the client, in client-side Javascript, and adding all the DateTime
        /// formatting support would drastically increase the size of the client script
        /// code, which would slow down page parsing/displaying on each page request.
        /// Rather than do that, the control supports common ways of building formats so you
        /// shouldn't have any difficulty getting an appropriate format string.  If you do,
        /// let us know.)
        /// <br/><br/>
        /// <list type="table">
        /// <listheader>
        /// <term>Format specifier</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>d</term>
        /// <description>
        /// Displays the current day of the month, measured as a number between 1 and 31,
        /// inclusive. If the day is a single digit only (1-9), then it is displayed as
        /// a single digit.
        /// </description>
        /// </item>
        /// <item>
        /// <term>dd</term>
        /// <description>
        /// Displays the current day of the month, measured as a number between 1 and 31,
        /// inclusive. If the day is a single digit only (1-9), it is formatted with a
        /// preceding 0 (01-09).
        /// </description>
        /// </item>
        /// <item>
        /// <term>ddd</term>
        /// <description>
        /// Displays the abbreviated name of the day for the specified DateTime.
        /// </description>
        /// </item>
        /// <item>
        /// <term>dddd</term>
        /// <description>
        /// Displays the full name of the day for the specified DateTime.
        /// </description>
        /// </item>
        /// <item>
        /// <term>M</term>
        /// <description>
        /// Displays the month, measured as a number between 1 and 12, inclusive. If the month
        /// is a single digit (1-9), it is displayed as a single digit.
        /// </description>
        /// </item>
        /// <item>
        /// <term>MM</term>
        /// <description>
        /// Displays the month, measured as a number between 1 and 12, inclusive. If the month
        /// is a single digit (1-9), it is formatted with a preceding 0 (01-09).
        /// </description>
        /// </item>
        /// <item>
        /// <term>MMM</term>
        /// <description>
        /// Displays the abbreviated name of the month for the specified DateTime.
        /// </description>
        /// </item>
        /// <item>
        /// <term>MMMM</term>
        /// <description>
        /// Displays the full name of the month for the specified DateTime.
        /// </description>
        /// </item>
        /// <item>
        /// <term>y</term>
        /// <description>
        /// Displays the year for the specified DateTime as a maximum two-digit number. The
        /// first two digits of the year are omitted. If the year is a single digit (1-9), it
        /// is displayed as a single digit. 
        /// </description>
        /// </item>
        /// <item>
        /// <term>yy</term>
        /// <description>
        /// Displays the year for the specified DateTime as a maximum two-digit number. The
        /// first two digits of the year are omitted. If the year is a single digit (1-9), it
        /// is formatted with a preceding 0 (01-09).
        /// </description>
        /// </item>
        /// <item>
        /// <term>yyyy</term>
        /// <description>
        /// Displays the year for the specified DateTime, including the century. If the year
        /// is less than four digits in length, then preceding zeros are appended as necessary
        /// to make the displayed year four digits long.
        /// </description>
        /// </item>
        /// <item>
        /// <term>x</term>
        /// <description>
        /// Displays the date suffix for the specified DateTime, such as 'st', 'nd', 'rd', or
        /// 'th'.  <b>This is not a standard DateTime format specifier.</b>
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <value>The current date value of the field, as a string. The default is "dx MMMM yyyy".</value>
        ///
        public virtual string DisplayFormat
        {
            get
            {
                EnsureChildControls ();

                return _realField.DisplayFormat;
            }
            set
            {
                EnsureChildControls ();

                _realField.DisplayFormat = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the date value of the DatePicker field, using a string.
        /// </summary>
        /// <remarks>
        /// This property allows you to specify the initial value of the field, or to retrieve the
        /// current value.  You <b>must</b> set this using a valid date string.  Really, you'd be better
        /// off using .Value as the property you get and set - it's much more type-safe.  The only
        /// reason this is here is for consistency with the majority of other ASP.NET fields.
        /// <br/><br/>
        /// The default value of the field is DateTime.Now.
        /// </remarks>
        /// <value>The current date value of the field, as a string. The default is <see cref="DateTime.Now">DateTime.Now</see>.</value>
        ///
        [Bindable (false), Browsable (false)]
        public virtual string Text
        {
            get
            {
                EnsureChildControls ();

                return Normaliser.GetOdbcFormatFromDate (_realField.Value);
            }
            set
            {
                EnsureChildControls ();

                _realField.Value = DateTime.Parse (value, Globalisation.GetCultureInfo ());

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the date value to be initially displayed in the DatePicker field.
        /// </summary>
        /// <remarks>
        /// This property allows you to specify the initial value of the field, or to retrieve the
        /// current value.  It is generally better to use this property than DatePicker.Text.
        /// The default value of the field is DateTime.Now.
        /// </remarks>
        /// <value>The current date value of the field. The default is <see cref="DateTime.Now">DateTime.Now</see>.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance")]
        [Description ("The date value to be initially displayed in the DatePicker field.")]
        public DateTime Value
        {
            get
            {
                EnsureChildControls ();

                return _realField.Value;
            }
            set
            {
                EnsureChildControls ();

                _realField.Value = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the height of the DatePicker server control.
        /// </summary>
        /// <remarks>
        /// Use the Height property to specify the height of the DatePicker server control.
        /// </remarks>
        /// <value>A <see cref="Unit"/> that represents the width of the control. The default is not specified, and the minimum is 22px.</value>
        ///
        public override Unit Height
        {
            get
            {
                EnsureChildControls ();

                return base.Height;
            }
            set
            {
                EnsureChildControls ();

                base.Height = (Unit) Math.Max (DatePickerConstants.MinimumControlHeight, value.Value);

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the width of the DatePicker server control.
        /// </summary>
        /// <remarks>
        /// Use the Width property to specify the width of the DatePicker server control.  The width
        /// of the textbox reduces as this width reduces, and at the limit (22px, the size of the
        /// image button) the textbox is hidden completely.
        /// </remarks>
        /// <value>A <see cref="Unit"/> that represents the width of the control. The default is not specified, and the minimum is 22px.</value>
        ///
        public override Unit Width
        {
            get
            {
                EnsureChildControls ();

                return base.Width;
            }
            set
            {
                EnsureChildControls ();

                base.Width = (Unit) Math.Max (DatePickerConstants.MinimumControlWidth, value.Value);

                return;
            }
        }

        private bool IsInDesignMode
        {
            get
            {
                EnsureChildControls ();

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

            EnsureChildControls ();

            Page.RegisterRequiresPostBack (this);

            if ((DefaultToCurrentDate) && (!Page.IsPostBack))
            {
                Value = DateTime.Now;
            }

            return;
        }

        ///
        /// <summary>
        /// Raises the <see cref="DateChanged"/> event.
        /// </summary>
        /// <remarks>
        /// This method notifies the server control that the date in the date field has been changed.
        /// <p class="i1">
        /// Notes to Inheritors:  When overriding <see cref="OnDateChanged"/> in a derived class, be sure
        /// to call the base class's <see cref="OnDateChanged"/> method.
        /// </p>
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected virtual void OnDateChanged (EventArgs e)
        {
            if (DateChanged != null)
            {
                DateChanged (this, e);
            }

            return;
        }

        ///
        /// <summary>
        /// Perform last-minute duties before rendering us and our child controls.
        /// </summary>
        /// <remarks>
        /// This method allows us to perform actions after all controls have been loaded and events
        /// processed, just before we start the rendering cycle.  We use this time to propagate style
        /// information to our child controls.
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their OnPreRender.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnPreRender (EventArgs e)
        {
            base.OnPreRender (e);

            if ((!IsInDesignMode) && (ControlStyleCreated))
            {
                _realField.ApplyStyle (ControlStyle);
                ControlStyle.Reset ();
                foreach (string styleName in Style.Keys)
                {
                    _realField.Style [styleName] = Style [styleName];
                }
            }

            ViewState ["ChosenDateValue"] = Value;

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
            PowerPack.Announce (realWriter, ProductName);

            if (Page != null)
            {
                Page.VerifyRenderingInServerForm (this);
            }

            _realField.RenderControl (realWriter);

            return;
        }

        //============================================================
        // Methods
        //============================================================

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
            if (!IsInDesignMode)
            {
                HttpBrowserCapabilities hbcClient = HttpContext.Current.Request.Browser;
                _realField = DatePickerFieldFactory.GetField (hbcClient);
            }
            else
            {
                _realField = new IE5DatePickerField ();
            }

            Controls.Add (_realField);

            return;
        }

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
        public virtual bool LoadPostData (string postDataKey, NameValueCollection postCollection)
        {
            EnsureChildControls ();

            bool loadedNewPostValue = false;

            object value = ViewState ["ChosenDateValue"];
            if (value != null)
            {
                var valueDateTime = (DateTime) value;
                if (valueDateTime.Date.CompareTo (Value.Date) != 0)
                {
                    loadedNewPostValue = true;
                }
            }

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
            OnDateChanged (EventArgs.Empty);

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
    }
}