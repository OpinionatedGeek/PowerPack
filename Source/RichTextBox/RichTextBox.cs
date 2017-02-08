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
    /// A rich-editing TEXTAREA, complete with toolbar and shortcut keys.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> IE5 or higher, or Mozilla 1.3 or higher, for WYSIWYG editing.
    /// </p>
    /// </summary>
    /// <remarks>
    /// RichTextBox is a DHTML WYSIWYG editing control that brings better form usability to browsers that
    /// provide the necessary support.  At the minute that means IE5 and higher, and Mozilla 1.3 and higher.  Sadly,
    /// no other browsers seem to support this kind of functionality.
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// If it is not possible to show the WYSIWYG editor in the current browser (for example if the current browser
    /// does not support the appropriate dynamic HTML) then a simple TEXTAREA is used.  This will
    /// allow the application to work regardless of the user's browser type, but will provide a better
    /// user experience for those users with better browsers.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then puts
    /// a WYSIWYG RichTextBox control on the page.
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:RichTextBox
    ///     height="200"
    ///     width="400"
    ///     name="test"
    ///     text="Some default contents"
    ///     runat="server"/&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/RichTextBox.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [DefaultProperty ("Text")]
    [ToolboxData ("<{0}:RichTextBox runat=server></{0}:RichTextBox>")]
    [ToolboxBitmap (typeof (Bitmap))]
    [LicenseProvider (typeof (RichTextBoxLicenseProvider))]
    public class RichTextBox : TextBox
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "RichTextBox";

        private DefaultRTField _realField;
        private Uri _initialPage;
        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="RichTextBox"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="RichTextBox"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public RichTextBox ()
        {
            _license = LicenseManager.Validate (typeof (RichTextBox), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets the server control identifier generated by ASP.NET.
        /// </summary>
        /// <remarks>
        /// ASP.NET automatically generates a ClientID for a server control regardless of whether you have specified
        /// an ID property for it or not. This property is used to identify a control for client-side operations,
        /// such as ECMAScript functions.
        /// </remarks>
        /// <value>The server control identifier generated by ASP.NET.</value>
        ///
        public override string ClientID
        {
            get
            {
                EnsureChildControls ();

                return base.ClientID.Replace (' ', '_');
            }
        }

        internal string BaseText
        {
            get
            {
                EnsureChildControls ();

                return base.Text;
            }
        }

        ///
        /// <summary>
        /// Sets the initial page loaded by the editable region's IFRAME tag.
        /// </summary>
        /// <remarks>
        /// This is a bit of an odd one.  When you put a RichTextBox control on a page, one of the
        /// things that is output is an IFRAME which is then put into edit mode.  However, the
        /// IFRAME tag has to have a target to load (even though we're probably going to overwrite
        /// the IFRAME's contents with the value of the Text property).  Normally we just use the
        /// "about:blank" page, and it causes very few problems.  However, there's a tendency for the
        /// browser to complain if the form itself is retrieved via https, since there's a
        /// 'secure' IFRAME that is trying to load content from the 'non-secure' "about:blank" page.
        /// To get around this problem you can set this property to the (https!) URL of a blank
        /// page within the same realm as the form.
        /// <br/><br/>
        /// If this doesn't make any sense to you, you probably don't need to worry about it.
        /// </remarks>
        /// <value>The initial page to use as the IFRAME's contents.  The default is "<b>about:blank</b>".</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue (RTConstants.DefaultInitialPage)]
        [Description (@"You only need to change this if you have SSL problems.")]
        public Uri InitialPage
        {
            get
            {
                EnsureChildControls ();

                return _initialPage;
            }
            set
            {
                EnsureChildControls ();

                _initialPage = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the text content of the RichTextBox control.
        /// </summary>
        /// <remarks>
        /// The RichTextBox control always returns HTML - even if a standard TEXTAREA is rendered, the value
        /// is manipulated to return paragraph tags instead of carriage returns.
        /// </remarks>
        /// <value>The text content of the text box. The default is <see cref="String.Empty"/>.</value>
        ///
        public override string Text
        {
            get
            {
                EnsureChildControls ();

                return base.Text;
            }
            set
            {
                EnsureChildControls ();

                base.Text = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Overridden TextMode property.  The RichTextBox control only supports TextBoxMode.MultiLine.
        /// </summary>
        /// <remarks>
        /// The RichTextBox control only supports TextBoxMode.MultiLine, so any attempts to set it to anything else
        /// are met with a swift ArgumentException.
        /// </remarks>
        /// <value>Always TextBoxMode.MultiLine.</value>
        ///
        public override TextBoxMode TextMode
        {
            get
            {
                EnsureChildControls ();

                return TextBoxMode.MultiLine;
            }
            set
            {
                EnsureChildControls ();

                if (value != TextBoxMode.MultiLine)
                {
                    throw new ArgumentException (Globalisation.GetString ("rtbOnlySupportsMultiline"), "value");
                }

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the width of the RichTextBox server control.
        /// </summary>
        /// <remarks>
        /// Use the Width property to specify the width of the RichTextBox server control.
        /// </remarks>
        /// <value>A <see cref="Unit"/> that represents the width of the control. The default is the minimum control width (390px).</value>
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

                base.Width = (Unit) Math.Max (RTConstants.MinimumControlWidth, value.Value);

                _realField.WidthExplicitlySet = true;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the height of the RichTextBox server control.
        /// </summary>
        /// <remarks>
        /// Use the Height property to specify the height of the RichTextBox server control.
        /// </remarks>
        /// <value>A <see cref="Unit"/> that represents the width of the control. The default is the minimum control height (200px).</value>
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

                base.Height = (Unit) Math.Max (RTConstants.MinimumControlHeight, value.Value);

                _realField.HeightExplicitlySet = true;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the number of columns in the RichTextBox server control.
        /// </summary>
        /// <remarks>
        /// This is simply an alias to the <see cref="Columns"/> property, to help when
        /// people use the Textarea 'cols' attribute instead of the TextBox 'columns' one.
        /// <br /><br />
        /// Use the <see cref="Width"/> property to specify the width of the RichTextBox server control in pixels.
        /// Columns gives only an approximate control over this figure.
        /// </remarks>
        /// <value>An int that represents the number of columns in the control.</value>
        ///
        public virtual int Cols
        {
            get
            {
                return Columns;
            }
            set
            {
                Columns = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the number of columns in the RichTextBox server control.
        /// </summary>
        /// <remarks>
        /// Use the <see cref="Width"/> property to specify the width of the RichTextBox server control in pixels.
        /// Columns gives only an approximate control over this figure.
        /// </remarks>
        /// <value>An int that represents the number of columns in the control.</value>
        ///
        public override int Columns
        {
            get
            {
                EnsureChildControls ();

                int columns = RTConstants.MinimumControlColumns;
                if (base.Columns > RTConstants.MinimumControlColumns)
                {
                    columns = base.Columns;
                }

                return columns;
            }
            set
            {
                EnsureChildControls ();

                base.Columns = Math.Max (RTConstants.MinimumControlColumns, value);

                _realField.ColumnsExplicitlySet = true;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the number of rows in the RichTextBox server control.
        /// </summary>
        /// <remarks>
        /// Use the <see cref="Height"/> property to specify the height of the RichTextBox server control in pixels.
        /// Columns gives only an approximate control over this figure.
        /// </remarks>
        /// <value>An int that represents the number of rows in the control.</value>
        ///
        public override int Rows
        {
            get
            {
                EnsureChildControls ();

                return base.Rows;
            }
            set
            {
                EnsureChildControls ();

                base.Rows = Math.Max (RTConstants.MinimumControlRows, value);

                _realField.RowsExplicitlySet = true;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the list of fonts that will appear in the font dropdown.
        /// </summary>
        /// <remarks>
        /// This property can be used to replace the default list of fonts that appears in the font
        /// name dropdown.  The value is a string, but is composed of font-name/substitution list pairs.
        /// There is no limit on the number of pairs which can be used.  The list pairs are of the form
        /// <i>font display name: font substitution list;</i>.  A semi-colon separates these font pairs
        /// from each other, and a colon separates the name from the substitution list.
        /// <p class="i1" style="color: #0206A6">
        /// As is standard in font use in browsers, the first named font in the font substitution list
        /// will be used if the browser supports it, and failing that the next one is used, and so on.
        /// It is best to start the list with the font you actually want displayed, and move down
        /// through a list of "close" fonts until you end with, in the worst case, the "serif" or
        /// "sans serif" fonts.
        /// </p>
        /// </remarks>
        /// <example>
        /// The default font list is equivalent to: "Courier: Courier, Century; Helvetica: Helvetica, Arial, sans serif; Times: Times New Roman, serif; Verdana: Verdana, Arial, sans serif;"
        /// </example>
        /// <value>The list of fonts to be used in the font dropdown..</value>
        ///
        public string FontList
        {
            get
            {
                EnsureChildControls ();

                return _realField.FontList;
            }
            set
            {
                EnsureChildControls ();

                _realField.FontList = value;

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
        /// Loads the control.
        /// </summary>
        /// <remarks>
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their OnLoad.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            _realField.OnLoad (e);

            if (!ControlHelper.IsPostBack)
            {
                if (ControlStyle.Font.Size.IsEmpty)
                {
                    ControlStyle.Font.Size = FontUnit.Parse ("12pt");
                }

                base.Text = _realField.GetHiddenFieldText ();
            }

            return;
        }

        ///
        /// <summary>
        /// Raises the FocusScriptRequired event.
        /// </summary>
        /// <remarks>
        /// This method inserts the required client-side Javascript to set the control's focus.
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their OnLoad.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnFocusScriptRequired (EventArgs e)
        {
            if ((_realField is IE5RTField) || (_realField is MozRTField))
            {
                _realField.FocusScriptRequired ();
            }
            else
            {
                base.OnFocusScriptRequired (e);
            }

            return;
        }

        ///
        /// <summary>
        /// Raises the PromptScriptRequired event.
        /// </summary>
        /// <remarks>
        /// This method inserts the required client-side Javascript to remove the control's prompt text.
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their OnLoad.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnPromptScriptRequired (EventArgs e)
        {
            if ((_realField is IE5RTField) || (_realField is MozRTField))
            {
                _realField.PromptScriptRequired ();
            }
            else
            {
                base.OnPromptScriptRequired (e);
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

            _realField.OnPreRender (e);

            return;
        }

        ///
        /// <summary>
        /// Render this control to the writer parameter specified.
        /// </summary>
        /// <remarks>
        /// This is the method that actually outputs the HTML generated by the control into the page's
        /// HTML text stream.  You do not normally need to call this method directly.
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

            bool uplevelBrowser = false;
            if (_realField is WysiwygRTField)
            {
                uplevelBrowser = true;
            }

            if (Page == null)
            {
                throw new ApplicationException("Page must not be null.");
            }

            if ((uplevelBrowser) && (Prompt != null) && (!Page.IsPostBack))
            {
                AddPromptAttributes ();
            }

            _realField.Render (realWriter);

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
            _realField = null;

            base.CreateChildControls ();

            _initialPage = new Uri (RTConstants.DefaultInitialPage);
            if (HttpContext.Current != null)
            {
                base.TextMode = TextBoxMode.MultiLine;

                if (EnableClientScript)
                {
                    HttpBrowserCapabilities browserType = HttpContext.Current.Request.Browser;
                    _realField = RichTextFieldFactory.GetField (this, browserType);
                }
            }

            if (_realField == null)
            {
                _realField = new DesignerRTField (this);
            }

            base.Width = RTConstants.MinimumControlWidth;
            base.Height = RTConstants.MinimumControlHeight;

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
        protected override void Dispose (bool disposing)
        {
            try
            {
                if ((disposing) && (_license != null))
                {
                    _license.Dispose ();
                    _license = null;
                }
            }
            finally
            {
                base.Dispose (disposing);
            }

            return;
        }
    }
}