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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// Implements an expand/collapse panel in a web page.  The panel can be expanded or collapsed
    /// by the user by clicking on the panel's title.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// A collapsible panel consists of two elements - a <b>title</b> and a <b>body</b>.  The title
    /// is 'active' - clicking it expands the body (if the body was collapsed) or collapses the body
    /// (if the body was expanded).  Both the title and body are strings of HTML, and must be well
    /// formed.  Complex styling can be achieved through the three styles in the panel:
    ///	<list type="number">
    ///	<item>The TitleStyle style (all standard styles applied solely to the title area, specified via the Title- prefix).</item>
    ///	<item>The BodyStyle style (all standard styles applied solely to the body area, specified via the Body- prefix).</item>
    ///	<item>The overall style (all standard styles applied to all areas except where overridden by a Title or Body style, specified without a prefix).</item>
    ///	</list>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> This facility is available in all browsers.  However, if the browser is DHTML-capable
    /// (such as IE5 or higher, or Netscape 6/Mozilla), then the expand or collapse happens immediately and no
    /// postback to the server is required.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then puts
    /// two sample panels on the page.
    /// <code>
    /// <![CDATA[
    ///<%@ Register TagPrefix="opgeek"
    ///	Namespace="OpinionatedGeek.Web.PowerPack"
    ///	Assembly="OpinionatedGeek.Web.PowerPack"%>
    ///<html>
    ///<head>
    ///	<title>CollapsiblePanel Example</title>
    ///</head>
    ///<body>
    ///	<opgeek:CollapsiblePanel
    ///		Text="A simple panel's title bar"
    ///		runat="server">
    ///		A simple panel's body text.
    ///	</opgeek:CollapsiblePanel>
    ///	<opgeek:CollapsiblePanel Text="A more complicated panel's title bar"
    ///		Title-Decoration="NONE"
    ///		Title-BackColor="lightsteelblue"
    ///		Title-ForeColor="black"
    ///		BackColor="darkslateblue"	
    ///		Body-BackColor="azure"
    ///		BorderStyle="groove"
    ///		BorderWidth="1"
    ///		Width="100%"
    ///		runat="server">
    ///	A more complicated panel's body text.
    ///	</opgeek:CollapsiblePanel>
    ///</body>
    ///</html>
    /// ]]>
    ///	</code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/CollapsiblePanel.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [DefaultProperty ("Text")]
    [ToolboxData ("<{0}:CollapsiblePanel runat=server></{0}:CollapsiblePanel>")]
    [ParseChildren (false)]
    [ToolboxBitmap (typeof (Bitmap))]
    [Designer (typeof (AutomaticDesigner))]
    [LicenseProvider (typeof (CollapsiblePanelLicenseProvider))]
    public class CollapsiblePanel : WebControl, IPostBackDataHandler, INamingContainer
    {
        //============================================================
        // Private Data
        //============================================================

        private const string ProductName = "CollapsiblePanel";

        private const string TitleLinkCommandName = "ExpandCollapse";
        private const string TitleLinkCommandToolTip = "Click to expand/collapse";

        private const string ExColIEJavascript = @"<script language='Javascript'>
function toggle_exc_opgeek (controlId, statefield)
{
	var control = document.all [controlId].style;
	var expandstate = document.all [statefield];

	if (control.display == 'none')
	{
		control.display = '';
		expandstate.value = 'true';
	}
	else
	{
		control.display = 'none';
		expandstate.value = 'false';
	}

	return false;
}
</script>";

        private const string ExColMoxJavascript = @"<script language='Javascript'>
function isDefined_exc_opgeek (objDoesThisExist)
{
	return ('' + objDoesThisExist) != 'undefined';
}

function setChildDisplay_exc_opgeek (control, szNewDisplay)
{
	for (var i = 0; i < control.childNodes.length; i++)
	{
		if (isDefined_exc_opgeek (control.childNodes [i].style))
		{
			control.childNodes [i].style.display = szNewDisplay;
		}
	}

	return;
}

function toggle_exc_opgeek (controlId, statefield)
{
	var control = document.getElementById (controlId);
	var expandstate = document.getElementById (statefield);

	if (control.style.display == 'none')
	{
		control.style.display = '';
		setChildDisplay_exc_opgeek (control, '');
		expandstate.value = 'true';
	}
	else
	{
		control.style.display = 'none';
		setChildDisplay_exc_opgeek (control, 'none');
		expandstate.value = 'false';
	}

	return false;
}
</script>";

        private bool _containsParsedSubObjects;
        private License _license;
        private TableRow _titleRow;
        private TableCell _titleCell;
        private TableRow _bodyRow;
        private TableCell _bodyCell;
        private LinkButton _titleLinkButton;
        private EnhancedStyle _titleStyle;
        private EnhancedStyle _bodyStyle;
        private System.Web.UI.WebControls.HyperLink _titleHyperLink;
        private HtmlInputHidden _hiddenState;
        private bool _expanded;
        private bool _expandByDefault;
        private bool _enableClientScript = true;
        private bool _viewstateLoadedOrExpandExplicitlySet;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="CollapsiblePanel"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="CollapsiblePanel"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public CollapsiblePanel () : base (HtmlTextWriterTag.Table)
        {
            _license = LicenseManager.Validate (typeof (CollapsiblePanel), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets/sets the title text for the collapsible panel.
        /// </summary>
        /// <remarks>
        /// Gets/sets the title text for the collapsible panel.  This text becomes a clickable
        /// A HREF=... tag, so unpredictable results will occur if the text HTML already contains
        /// an A tag.
        /// </remarks>
        /// <value>The HTML string to be used as the panel's title.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("")]
        [Description ("The text to be displayed in the Title bar.")]
        public string Text
        {
            get
            {
                EnsureChildControls ();

                string title;
                if (IsIE () || IsMozilla ())
                {
                    title = _titleHyperLink.Text;
                }
                else
                {
                    title = _titleLinkButton.Text;
                }

                return title;
            }
            set
            {
                EnsureChildControls ();

                _titleHyperLink.Text = value;
                _titleLinkButton.Text = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Specifies whether the tag should try to use Dynamic HTML if the browser accepts it.
        /// </summary>
        /// <remarks>
        /// Specifies whether the tag should try to use Dynamic HTML if the browser accepts it.  Newer
        /// browsers support DHTML to manipulate the page dynamically, and this generally gives a faster
        /// response and doesn't require a postback to the server.  It does however mean that all the text
        /// in the body must be sent to the client each time it accesses the page.
        /// </remarks>
        /// <value>Whether to try and use Dynamic HTML.  The default value for this property is <b>true</b>.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("")]
        [Description ("Whether the tag should try to use Dynamic HTML if the browser accepts it.")]
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

        /// <summary>
        /// Specifies whether the tag should start off expanded or collapsed.
        /// </summary>
        /// <remarks>
        /// A collapsible panel must always be in one of two states.  It can either be expanded or
        /// it can be collapsed.  This property allows you to set which of these states the panel
        /// begins in when a visitor first views the page.  It has no effect on subsequent page views,
        /// which are controlled by whether the user has chosen to expand or collapse the panel.
        /// </remarks>
        /// <value>
        /// Whether the tag should start off expanded or collapsed.  The default value for this property
        /// is <b>false</b>, so by default the panel is collapsed.
        /// </value>
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("")]
        [Description ("Whether the tag should start off expanded or collapsed.")]
        public bool ExpandByDefault
        {
            get
            {
                return _expandByDefault;
            }
            set
            {
                _expandByDefault = value;

                return;
            }
        }

        ///
        /// <summary>
        /// This property is used to determine whether the panel is in an expanded or collapsed state.
        /// </summary>
        /// <remarks>
        /// This is the property that is used to determine whether or not the panel is expanded or not.
        /// It bases its decision on the viewstate and the initial default state.
        /// </remarks>
        /// <value>Whether the panel is expanded or not.</value>
        ///
        [Bindable (true), Browsable (false), Category ("Appearance"), DefaultValue ("")]
        protected bool Expand
        {
            get
            {
                EnsureChildControls ();

                return _expanded;
            }
            set
            {
                EnsureChildControls ();

                _expanded = value;
                _viewstateLoadedOrExpandExplicitlySet = true;

                return;
            }
        }

        ///
        /// <summary>
        /// The style which will be applied to the Title part of the panel.
        /// </summary>
        /// <remarks>
        /// The title and the body can have separate styles if required.  This property is used to
        /// manage the style that applies to the title of the panel.
        /// </remarks>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///		<opgeek:CollapsiblePanel Text="Example control"<br/>
        ///			TitleStyle-Decoration="NONE"<br/>
        ///			TitleStyle-ForeColor="black"<br/>
        ///			TitleStyle-BackColor="lightsteelblue"<br/>
        ///			runat="server"><br/><br/>
        ///		This is the panel's body<br/><br/>
        ///		</opgeek:CollapsiblePanel>
        /// ]]>
        /// </code>
        /// </example>
        /// <value>The style to be applied to the title of the collapsible panel.</value>
        /// <seealso cref="EnhancedStyle">The EnhancedStyle class.</seealso>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("")]
        [Description ("The style which will be applied to the Title part of the panel.")]
        public EnhancedStyle TitleStyle
        {
            get
            {
                EnsureChildControls ();

                return _titleStyle;
            }
        }

        ///
        /// <summary>
        /// The CSS class which will be applied to the Title part of the panel.
        /// </summary>
        /// <remarks>
        /// The title and the body can have separate CSS classes if required.  This property is used to
        /// manage the CSS class that applies to the title of the panel.
        /// </remarks>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///		<opgeek:CollapsiblePanel Text="Example control"<br/>
        ///			TitleCssClass="MyTitleClass"<br/>
        ///			runat="server"><br/><br/>
        ///		This is the panel's body<br/><br/>
        ///		</opgeek:CollapsiblePanel>
        /// ]]>
        /// </code>
        /// </example>
        /// <value>The CSS class to be applied to the title of the collapsible panel.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("")]
        [Description ("The style which will be applied to the Title part of the panel.")]
        public string TitleCssClass
        {
            get
            {
                EnsureChildControls ();

                return _titleLinkButton.CssClass;
            }
            set
            {
                EnsureChildControls ();

                _titleLinkButton.CssClass = value;
                _titleHyperLink.CssClass = value;
                _titleRow.CssClass = value;
                _titleCell.CssClass = value;

                return;
            }
        }

        ///
        /// <summary>
        /// The style which will be applied to the Body part of the panel.
        /// </summary>
        /// <remarks>
        /// The title and the body can have separate styles if required.  This property is used to
        /// manage the style that applies to the title of the panel.
        /// </remarks>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///		<opgeek:CollapsiblePanel Text="Example control"<br/>
        ///			BodyStyle-ForeColor="black"<br/>
        ///			BodyStyle-BackColor="azure"<br/>
        ///			runat="server"><br/><br/>
        ///		This is the panel's body<br/><br/>
        ///		</opgeek:CollapsiblePanel>
        /// ]]>
        /// </code>
        /// </example>
        /// <value>The style to be applied to the body of the collapsible panel.</value>
        /// <seealso cref="EnhancedStyle">The EnhancedStyle class.</seealso>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("")]
        [Description ("The style which will be applied to the Body part of the panel.")]
        public EnhancedStyle BodyStyle
        {
            get
            {
                EnsureChildControls ();

                return _bodyStyle;
            }
        }

        ///
        /// <summary>
        /// The CSS class which will be applied to the Body part of the panel.
        /// </summary>
        /// <remarks>
        /// The title and the body can have separate CSS classes if required.  This property is used to
        /// manage the CSS class that applies to the body of the panel.
        /// </remarks>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///		<opgeek:CollapsiblePanel Text="Example control"<br/>
        ///			BodyCssClass="MyBodyClass"<br/>
        ///			runat="server"><br/><br/>
        ///		This is the panel's body<br/><br/>
        ///		</opgeek:CollapsiblePanel>
        /// ]]>
        /// </code>
        /// </example>
        /// <value>The CSS class to be applied to the body of the collapsible panel.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("")]
        [Description ("The style which will be applied to the Body part of the panel.")]
        public string BodyCssClass
        {
            get
            {
                EnsureChildControls ();

                return _bodyCell.CssClass;
            }
            set
            {
                EnsureChildControls ();

                _bodyRow.CssClass = value;
                _bodyCell.CssClass = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets a value indicating whether the Web server control is enabled.
        /// </summary>
        /// <remarks>
        /// Use the Enabled property to specify or determine whether the <see cref="CollapsiblePanel"/> is
        /// functional. When set to false, the control appears dimmed, and its state cannot be changed, meaning that
        /// it cannot be expanded or collapsed.
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

                SetStateBasedOnEnabled ();

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the vertical alignment of the contents in the panel body.
        /// </summary>
        /// <remarks>
        /// Use the <see cref="BodyVerticalAlign"/> property to specify the vertical alignment of the contents of
        /// the cell. The following table lists the possible values.
        /// <list type="table">
        /// <listheader>
        ///		<term>Vertical Alignment</term>
        ///		<description>Description</description>
        /// </listheader>
        /// <item>
        ///		<term>NotSet</term>
        ///		<description>The vertical alignment is not set.</description>
        /// </item>
        /// <item>
        ///		<term>Top</term>
        ///		<description>The contents of the cell are aligned with the top of the cell.</description>
        /// </item>
        /// <item>
        ///		<term>Middle</term>
        ///		<description>The contents of the cell are aligned with the middle of the cell.</description>
        /// </item>
        /// <item>
        ///		<term>Bottom</term>
        ///		<description>The contents of the cell are aligned with the bottom of the cell.</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <value>One of the <see cref="VerticalAlign"/> enumeration values. The default is <see cref="VerticalAlign.NotSet"/>.</value>
        ///
        public virtual VerticalAlign BodyVerticalAlign
        {
            get
            {
                EnsureChildControls ();

                return _bodyCell.VerticalAlign;
            }
            set
            {
                EnsureChildControls ();

                _bodyCell.VerticalAlign = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the vertical alignment of the contents in the panel title.
        /// </summary>
        /// <remarks>
        /// Use the <see cref="TitleVerticalAlign"/> property to specify the vertical alignment of the contents of
        /// the cell. The following table lists the possible values.
        /// <list type="table">
        /// <listheader>
        ///		<term>Vertical Alignment</term>
        ///		<description>Description</description>
        /// </listheader>
        /// <item>
        ///		<term>NotSet</term>
        ///		<description>The vertical alignment is not set.</description>
        /// </item>
        /// <item>
        ///		<term>Top</term>
        ///		<description>The contents of the cell are aligned with the top of the cell.</description>
        /// </item>
        /// <item>
        ///		<term>Middle</term>
        ///		<description>The contents of the cell are aligned with the middle of the cell.</description>
        /// </item>
        /// <item>
        ///		<term>Bottom</term>
        ///		<description>The contents of the cell are aligned with the bottom of the cell.</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <value>One of the <see cref="VerticalAlign"/> enumeration values. The default is <see cref="VerticalAlign.NotSet"/>.</value>
        ///
        public virtual VerticalAlign TitleVerticalAlign
        {
            get
            {
                EnsureChildControls ();

                return _titleCell.VerticalAlign;
            }
            set
            {
                EnsureChildControls ();

                _titleCell.VerticalAlign = value;

                return;
            }
        }

        //============================================================
        // Events
        //============================================================

        ///
        /// <summary>
        /// Initialises the control and creates any necessary child controls.
        /// </summary>
        /// <remarks>
        /// This must be called by the ASP.NET system to properly initialise the control.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnInit (EventArgs e)
        {
            EnsureChildControls ();

            base.OnInit (e);

            PowerPack.EnsureIdSet (this);

            Page.RegisterRequiresPostBack (this);

            if (IsIE () && EnableClientScript)
            {
                OnInit_IE ();
            }
            else if (IsMozilla () && EnableClientScript)
            {
                OnInit_Moz ();
            }
            else
            {
                OnInit_Default ();
            }

            SetStateBasedOnEnabled ();

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
            _titleRow.ApplyStyle (TitleStyle);
            _titleLinkButton.ApplyStyle (TitleStyle);
            _titleHyperLink.ApplyStyle (TitleStyle);
            if (TitleStyle.Decoration.Length != 0)
            {
                _titleLinkButton.Attributes.Add ("style", "text-decoration: " + TitleStyle.Decoration);
                _titleHyperLink.Attributes.Add ("style", "text-decoration: " + TitleStyle.Decoration);
            }

            _bodyRow.ApplyStyle (BodyStyle);
            _bodyCell.ApplyStyle (BodyStyle);

            base.OnPreRender (e);

            Page.ClientScript.RegisterHiddenField (UniqueID + "_Hidden", IsExpanded ().ToString ());

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

            if (Page != null)
            {
                Page.VerifyRenderingInServerForm (this);
            }

            RenderBeginTag (realWriter);
            if (IsIE () && EnableClientScript)
            {
                RenderContents_IE (writer);
            }
            else if (IsMozilla () && EnableClientScript)
            {
                RenderContents_Moz (writer);
            }
            else
            {
                if (IsExpanded ())
                {
                    RenderContents_Default (writer);
                }
                else
                {
                    Visible = false;
                }
            }
            RenderEndTag (realWriter);

            return;
        }

        ///
        /// <summary>
        /// Renders the HTML opening tag of the control into the specified writer. This method is used
        /// primarily by control developers.
        /// </summary>
        /// <remarks>
        /// This is made public so other controls can render multiple controls in between the opening
        /// and closing tags of a Web server control.
        /// </remarks>
        /// <param name="writer">A <see cref="System.Web.UI.HtmlTextWriter"/> that represents the
        /// writer stream to render HTML content on the client.</param>
        ///
        public override void RenderBeginTag (HtmlTextWriter writer)
        {
            base.RenderBeginTag (writer);
            _titleRow.RenderControl (writer);
            _bodyRow.RenderBeginTag (writer);

            return;
        }

        ///
        /// <summary>
        /// Renders the HTML closing tag of the control into the specified writer. This method is used
        /// primarily by control developers.
        /// </summary>
        /// <remarks>
        /// This is made public so other controls can render multiple controls in between the opening
        /// and closing tags of a Web server control.
        /// </remarks>
        /// <param name="writer">A <see cref="System.Web.UI.HtmlTextWriter"/> that represents the
        /// writer stream to render HTML content on the client.</param>
        ///
        public override void RenderEndTag (HtmlTextWriter writer)
        {
            _bodyRow.RenderEndTag (writer);
            base.RenderEndTag (writer);

            return;
        }

        //============================================================
        // Methods
        //============================================================

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
            _titleStyle = new EnhancedStyle ();
            _bodyStyle = new EnhancedStyle ();

            _titleLinkButton = new LinkButton ();
            _titleHyperLink = new System.Web.UI.WebControls.HyperLink ();

            // Need to explicitly set the IDs for them to be output in HTML.
            _titleLinkButton.ID = _titleLinkButton.ID;
            _titleHyperLink.ID = _titleHyperLink.ID;

            _titleRow = new TableRow ();
            Controls.Add (_titleRow);

            _titleCell = new TableCell ();
            _titleRow.Controls.Add (_titleCell);

            _bodyRow = new TableRow ();
            Controls.Add (_bodyRow);

            _bodyCell = new TableCell ();
            _bodyRow.Controls.Add (_bodyCell);
            _bodyCell.ID = _bodyCell.ID;
            _bodyCell.Attributes.Add ("id", _bodyCell.ClientID);
            _bodyCell.Width = new Unit (100, UnitType.Percentage);

            _hiddenState = new HtmlInputHidden ();
            _hiddenState.ID = _hiddenState.ID;
            _hiddenState.Name = _hiddenState.ID;

            return;
        }

        ///
        /// <summary>
        /// Restores view-state information from a previous page request that was saved by the
        /// <see cref="Control.SaveViewState"/> method.
        /// </summary>
        /// <remarks>
        /// Be very careful if you override this method to customize how a derived CollapsiblePanel restores its view state.
        /// Be sure that derived classes also call this version of the LoadViewState method in addition to carrying
        /// out their own processing.
        /// </remarks>
        /// <param name="savedState">An <see cref="Object"/> that represents the control state to be restored.</param>
        ///
        protected override void LoadViewState (object savedState)
        {
            var complete = (Pair) savedState;
            var state = (bool[]) complete.First;
            _expanded = state [0];
            _expandByDefault = state [1];
            _enableClientScript = state [2];
            _viewstateLoadedOrExpandExplicitlySet = true;

            base.LoadViewState (complete.Second);

            return;
        }

        ///
        /// <summary>
        /// Saves any server control view-state changes that have occurred since the time the page was posted back
        /// to the server.
        /// </summary>
        /// <remarks>
        /// Be very careful if you override this method to customize how a derived CollapsiblePanel saves its view state.
        /// Be sure that derived classes also call this version of the SaveViewState method in addition to carrying
        /// out their own processing.
        /// </remarks>
        /// <returns>Returns the server control's current view state. If there is no view state associated with the
        /// control, this method returns a null reference (Nothing in Visual Basic).</returns>
        ///
        protected override object SaveViewState ()
        {
            var state = new bool[3];
            state [0] = IsExpanded ();
            state [1] = _expandByDefault;
            state [2] = _enableClientScript;

            var complete = new Pair {First = state, Second = base.SaveViewState ()};

            return complete;
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

                if (_titleRow != null)
                {
                    _titleRow.Dispose ();
                    _titleRow = null;
                }

                if (_titleCell != null)
                {
                    _titleCell.Dispose ();
                    _titleCell = null;
                }

                if (_bodyRow != null)
                {
                    _bodyRow.Dispose ();
                    _bodyRow = null;
                }

                if (_bodyCell != null)
                {
                    _bodyCell.Dispose ();
                    _bodyCell = null;
                }

                if (_titleLinkButton != null)
                {
                    _titleLinkButton.Dispose ();
                    _titleLinkButton = null;
                }

                if (_titleStyle != null)
                {
                    _titleStyle.Dispose ();
                    _titleStyle = null;
                }

                if (_bodyStyle != null)
                {
                    _bodyStyle.Dispose ();
                    _bodyStyle = null;
                }

                if (_titleHyperLink != null)
                {
                    _titleHyperLink.Dispose ();
                    _titleHyperLink = null;
                }

                if (_hiddenState != null)
                {
                    _hiddenState.Dispose ();
                    _hiddenState = null;
                }
            }

            return;
        }

        ///
        /// <summary>
        /// Notifies the server control that an element, either XML or HTML, was parsed, and
        /// adds the element to the server control's <see cref="ControlCollection"/> object.
        /// </summary>
        /// <remarks>
        /// Unless you override it, this method automatically adds LiteralControl objects to the server
        /// control's <see cref="ControlCollection"/> object. This collection is accessible through
        /// <see cref="Control.Controls"/> property.
        /// </remarks>
        /// <param name="obj">An <see cref="Object"/> that represents the parsed element.</param>
        ///
        protected override void AddParsedSubObject (object obj)
        {
            EnsureChildControls ();

            var newControl = obj as Control;
            if (newControl != null)
            {
                _containsParsedSubObjects = true;
                _bodyCell.Controls.Add (newControl);
            }
            else
            {
                base.AddParsedSubObject (obj);
            }

            return;
        }

        private void OnInit_IE ()
        {
            Page.ClientScript.RegisterClientScriptBlock (typeof (CollapsiblePanel), CollapsiblePanelConstants.UniqueCodeBlockName, ExColIEJavascript);

            BuildDynamicTable ();

            return;
        }

        private void OnInit_Moz ()
        {
            Page.ClientScript.RegisterClientScriptBlock (typeof (CollapsiblePanel), CollapsiblePanelConstants.UniqueCodeBlockName, ExColMoxJavascript);

            BuildDynamicTable ();

            return;
        }

        private void OnInit_Default ()
        {
            _titleLinkButton.CommandName = TitleLinkCommandName;
            _titleLinkButton.Command += OnTitleClick;
            _titleLinkButton.ToolTip = TitleLinkCommandToolTip;
            _titleLinkButton.EnableViewState = true;

            _titleCell.Controls.Add (_titleLinkButton);

            return;
        }

        private void BuildDynamicTable ()
        {
            _titleHyperLink.EnableViewState = true;

            _titleCell.Controls.Add (_titleHyperLink);

            _hiddenState.Value = IsExpanded ().ToString (Globalisation.GetCultureInfo ());

            _titleCell.Controls.Add (_hiddenState);

            string hiddenState = Page.Request.Form [_hiddenState.Name];
            if (!String.IsNullOrEmpty (hiddenState))
            {
                Expand = Convert.ToBoolean (hiddenState, Globalisation.GetCultureInfo ());
            }

            return;
        }

        private void RenderContents_IE (HtmlTextWriter output)
        {
            if (IsExpanded ())
            {
                _bodyCell.Style.Add ("display", "");
            }
            else
            {
                _bodyCell.Style.Add ("display", "none");
            }

            if (_containsParsedSubObjects)
            {
                _bodyCell.RenderControl (output);
            }
            else
            {
                _bodyCell.RenderBeginTag (output);
                base.RenderContents (output);
                _bodyCell.RenderEndTag (output);
            }

            return;
        }

        private void RenderContents_Moz (HtmlTextWriter output)
        {
            if (!IsExpanded ())
            {
                _bodyCell.Style.Add ("display", "none");
            }

            if (_containsParsedSubObjects)
            {
                _bodyCell.RenderControl (output);
            }
            else
            {
                _bodyCell.RenderBeginTag (output);
                base.RenderContents (output);
                _bodyCell.RenderEndTag (output);
            }

            return;
        }

        private void RenderContents_Default (HtmlTextWriter output)
        {
            _bodyCell.Visible = IsExpanded ();

            if (_containsParsedSubObjects)
            {
                _bodyCell.RenderControl (output);
            }
            else
            {
                _bodyCell.RenderBeginTag (output);
                base.RenderContents (output);
                _bodyCell.RenderEndTag (output);
            }

            return;
        }

        private void OnTitleClick (object sender, CommandEventArgs e)
        {
            Expand = !IsExpanded ();

            return;
        }

        ///
        /// <summary>
        /// Manages the state data in the ViewState.
        /// </summary>
        /// <remarks>
        /// Loads the new state of the panel in from the postback data.
        /// </remarks>
        /// <param name="postDataKey">The key identified for the control.</param>
        /// <param name="postCollection">The collection of all incoming name values.</param>
        /// <returns><b>True</b> if the server control's state changes as a result of the post back; otherwise <b>false</b>.</returns>
        ///
        public virtual bool LoadPostData (string postDataKey, NameValueCollection postCollection)
        {
            string postedStateString = Context.Request.Form [UniqueID + "_Hidden"];
            bool postedState = Convert.ToBoolean (postedStateString, Globalisation.GetCultureInfo ());

            bool stateChanged = false;
            if ((EnableClientScript) && (Expand != postedState))
            {
                Expand = postedState;
                stateChanged = true;
            }

            return stateChanged;
        }

        ///
        /// <summary>
        /// This RaisePostDataChangedEvent is here to adhere to the IPostBackDataHandler interface.  It's not used.
        /// </summary>
        /// <remarks>
        /// Not used by this control.  It's only here because it's part of the interface.
        /// </remarks>
        ///
        public virtual void RaisePostDataChangedEvent ()
        {
            return;
        }

        private static bool IsIE ()
        {
            bool isIE = false;
            if ((HttpContext.Current != null) && (HttpContext.Current.Request.Browser.Browser.ToUpper (Globalisation.GetCultureInfo ()).IndexOf ("IE") > -1) && (HttpContext.Current.Request.Browser.MajorVersion >= 5))
            {
                isIE = true;
            }

            return isIE;
        }

        private static bool IsMozilla ()
        {
            bool isMozilla = false;
            if (HttpContext.Current != null)
            {
                string browser = HttpContext.Current.Request.Browser.Browser;
                if ((Normaliser.StringCompare (browser, "firefox"))
                    || (Normaliser.StringCompare (browser, "mozilla")))
                {
                    isMozilla = true;
                }
                else if ((Normaliser.StringCompare (browser, "netscape"))
                    && (HttpContext.Current.Request.Browser.MajorVersion >= 5))
                {
                    isMozilla = true;
                }
            }

            return isMozilla;
        }

        private void SetStateBasedOnEnabled ()
        {
            EnsureChildControls ();

            if (IsIE () || IsMozilla ())
            {
                if (_titleHyperLink != null)
                {
                    if (Enabled)
                    {
                        _titleHyperLink.Attributes.Add ("onclick", "return toggle_exc_opgeek ('" + _bodyCell.ClientID + "', '" + UniqueID + "_Hidden')");
                        _titleHyperLink.Attributes.Add ("onmouseover", "window.status = 'Click to expand/collapse'; return true");
                        _titleHyperLink.Attributes.Add ("onmouseout", "window.status = ''; return true");
                        _titleHyperLink.NavigateUrl = "#";
                        _titleHyperLink.ToolTip = TitleLinkCommandToolTip;
                    }
                    else
                    {
                        _titleHyperLink.Attributes.Remove ("onclick");
                        _titleHyperLink.Attributes.Remove ("onmouseover");
                        _titleHyperLink.Attributes.Remove ("onmouseout");
                        _titleHyperLink.NavigateUrl = null;
                        _titleHyperLink.ToolTip = null;
                    }
                }
            }
            else
            {
                if (_titleLinkButton != null)
                {
                    _titleLinkButton.Enabled = Enabled;
                }
            }

            return;
        }

        private bool IsExpanded ()
        {
            bool isExpanded = _viewstateLoadedOrExpandExplicitlySet ? Expand : ExpandByDefault;

            return isExpanded;
        }
    }
}