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
using System.Web.UI;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A panel that is always a fixed width and height, providing scroll bars where necessary.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> HTML4-compliant browsers (IE5+, Mozilla, Opera etc).
    /// </p>
    /// </summary>
    /// <remarks>
    /// Sometimes, you just want some certainty in your layout.  Sometimes, you want a bit of your page to fit in
    /// a specific section, and you don't want the headache that comes when that bit has more dynamic content than
    /// it was ever supposed to handle.
    /// <p class="i1">
    /// The ScrollablePanel is the answer.  It works exactly the same way a regular ASP.NET Panel works, but it uses
    /// some HTML 4.0 magic to make sure the width and height of the panel are fixed, even if there's too much
    /// content.  (If there's too much content, scroll bars appear so that all content is still accessible).
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This control should work well in most browsers.  It requires support for DIV tags and style attributes, so
    /// it requires browsers such IE5 and higher.
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
    /// &lt;opgeek:ScrollablePanel
    ///     id="ScrollablePanel1"
    ///     width="50px"
    ///     height="50px"
    ///     runat="server"&gt;
    ///     I'm a scrollable panel!
    /// &lt;/opgeek:ScrollablePanel&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/ScrollablePanel.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [ParseChildren (false)]
    [LicenseProvider (typeof (ScrollablePanelLicenseProvider))]
    public class ScrollablePanel : Panel
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "ScrollablePanel";

        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollablePanel"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="ScrollablePanel"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public ScrollablePanel ()
        {
            _license = LicenseManager.Validate (typeof (ScrollablePanel), this);

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
        /// <param name="writer">A <see cref="System.Web.UI.HtmlTextWriter"/> that represents the writer stream
        /// to render HTML content on the client.</param>
        ///
        protected override void AddAttributesToRender (HtmlTextWriter writer)
        {
            base.AddAttributesToRender (writer);

            if ((!Height.IsEmpty) || (!Width.IsEmpty))
            {
                writer.AddStyleAttribute ("overflow", "auto");

                if (!Height.IsEmpty)
                {
                    writer.AddStyleAttribute ("overflow-y", "auto");
                }

                if (!Width.IsEmpty)
                {
                    writer.AddStyleAttribute ("overflow-x", "auto");
                }
            }

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
    }
}