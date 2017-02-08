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
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A 'sticky note' type control that allows you to put highlighted notes on your web pages.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// This control simply displays the enclosed text and controls inside a yellow, bordered table designed
    /// to look like a sticky note.  It's really simple but quite effective.
    /// <p class="i1">
    /// As with the HTML IMG tag, setting the 'align' property tells the Note to 'float', so that text flows around the note!
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This control should work well in any browser.  It requires table support, but that's been around since
    /// Netscape version 2.  It looks better in newer browsers that support CSS (specifically the border-style and
    /// border-width style attributes).
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then adds a
    /// Note control that shows the text "I'm a sticky note!".
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:Note
    ///     id="note"
    ///     runat="server"&gt;
    ///     I'm a sticky note!
    /// &lt;/opgeek:Note&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/Note.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [ParseChildren (false)]
    [LicenseProvider (typeof (NoteLicenseProvider))]
    public class Note : WebControl
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "Note";

        private string _title = String.Empty;
        private string _align = String.Empty;

        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="Note"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public Note () : base (HtmlTextWriterTag.Table)
        {
            _license = LicenseManager.Validate (typeof (Note), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets the note's title.
        /// </summary>
        /// <remarks>
        /// The title of the note is displayed just before the contained text and controls, and is
        /// rendered in bold.  By default this value is the empty string, so no title is displayed.
        /// </remarks>
        /// <value>The title of the note, as a string, to be displayed in bold.</value>
        ///
        public string Title
        {
            get
            {
                EnsureChildControls ();

                return _title;
            }
            set
            {
                EnsureChildControls ();

                _title = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the alignment of the note itself.
        /// </summary>
        /// <remarks>
        /// This property allows you to set the alignment of the note itself (<b>not</b> the alignment of
        /// the contained text, which is set using the <see cref="HorizontalAlign"/> property).  Note
        /// alignment works just as it does with tables and images, so setting 'align="right"' means the
        /// note is aligned to the right of its HTML container and text flows down its left side.
        /// </remarks>
        /// <value>The alignment of the note itself (not the alignment of the contained text).</value>
        ///
        public string Align
        {
            get
            {
                EnsureChildControls ();

                return _align;
            }
            set
            {
                EnsureChildControls ();

                _align = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the horizontal text alignment of the contents of the note.
        /// </summary>
        /// <remarks>
        /// This property allows you to set the alignment of the contents of the note, not the note itself
        /// (which is set using the <see cref="Align"/> property).
        /// </remarks>
        /// <value>The alignment of the text contained within the note.</value>
        ///
        public HorizontalAlign HorizontalAlign
        {
            get
            {
                EnsureChildControls ();

                object horizontalAlign = ViewState ["HorizontalAlign"];
                if (horizontalAlign != null)
                {
                    return (HorizontalAlign) horizontalAlign;
                }

                return HorizontalAlign.NotSet;
            }
            set
            {
                EnsureChildControls ();

                ViewState ["HorizontalAlign"] = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the horizontal text alignment of the contents of the note.  (This is simply an
        /// alias for the <see cref="HorizontalAlign"/> property.)
        /// </summary>
        /// <remarks>
        /// This is simply an alias for the <see cref="HorizontalAlign"/> property.  HorizontalAlign is the
        /// more standard name for the property, even though TextAlign makes a bit more sense.
        /// </remarks>
        /// <value>The alignment of the text contained within the note.</value>
        ///
        public HorizontalAlign TextAlign
        {
            get
            {
                EnsureChildControls ();

                return HorizontalAlign;
            }
            set
            {
                EnsureChildControls ();

                HorizontalAlign = value;

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
        /// Renders the contents of the control into the specified writer. This method is used primarily by
        /// control developers.
        /// </summary>
        /// <remarks>
        /// Just renders the contained control tree, not the begin and end tags of the current control.
        /// </remarks>
        /// <param name="writer">A <see cref="System.Web.UI.HtmlTextWriter"/> that represents the writer
        /// stream to render HTML content on the client.</param>
        ///
        protected override void RenderContents (HtmlTextWriter writer)
        {
            const string cellTemplate = "<tr><td{0}>";
            string cell = String.Format (Globalisation.GetCultureInfo (), cellTemplate, GetHorizontalAlign ());
            writer.Write (cell);

            if (Title.Length != 0)
            {
                writer.Write ("<b>");
                writer.Write (Title);
                writer.Write (":</b> ");
            }

            base.RenderContents (writer);

            writer.Write ("</td></tr>");

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
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// <see cref="System.Web.UI.HtmlTextWriter"/>. This method is used primarily by control developers.
        /// </summary>
        /// <remarks>
        /// To render attributes and styles for a Web Server control on the client, you typically call the
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
        /// <param name="writer">A <see cref="System.Web.UI.HtmlTextWriter"/> that represents the output stream
        /// to render HTML content on the client.</param>
        ///
        protected override void AddAttributesToRender (HtmlTextWriter writer)
        {
            base.AddAttributesToRender (writer);

            Color border = BorderColor;
            if (!(border.IsEmpty))
            {
                writer.AddAttribute (HtmlTextWriterAttribute.Bordercolor, ColorTranslator.ToHtml (border));
            }

            Unit borderWidth = BorderWidth;
            writer.AddAttribute (HtmlTextWriterAttribute.Border, borderWidth.Value.ToString (NumberFormatInfo.InvariantInfo));

            if (Align.Length != 0)
            {
                writer.AddAttribute (HtmlTextWriterAttribute.Align, Align);
            }

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
            BorderWidth = 0;
            BackColor = Color.FromArgb (0xFF, 0xFF, 0xCC);
            Style.Add ("border-style", "outset");
            Style.Add ("border-width", "2px");

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
            if ((disposing) && (_license != null))
            {
                _license.Dispose ();
                _license = null;
            }

            return;
        }

        private string GetHorizontalAlign ()
        {
            string align = String.Empty;
            if (HorizontalAlign != HorizontalAlign.NotSet)
            {
                align = " align=\"" + HorizontalAlign + "\"";
            }

            return align;
        }
    }
}