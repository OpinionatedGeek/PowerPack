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

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A simple composite of ListBox and Label controls, to be used in the TwinListBox.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// <p class="i1">
    /// It is not intended that this control be used directly, only as part of the TwinListBox.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/TwinListBox.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </remarks>
    ///
    public class TwinnableListBox : ListBox
    {
        //============================================================
        // Private Data
        //============================================================

        private Label _label;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="TwinnableListBox"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the
        /// <see cref="TwinnableListBox"/> class. This default constructor initializes all fields to
        /// their default values.
        /// </remarks>
        ///
        public TwinnableListBox ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets the label control that will be used.
        /// </summary>
        /// <remarks>
        /// Gets the label control that will be used in combination with the ListBox, allowing you to
        /// set its Text property and alter its appearance.
        /// </remarks>
        /// <value>The Label control that will be used.</value>
        ///
        [Bindable (true)]
        [Browsable (false)]
        public Label Label
        {
            get
            {
                EnsureChildControls ();

                return _label;
            }
        }

        private bool ForcedWidth
        {
            get
            {
                bool forcedWidth = false;
                object forcedWidthObject = ViewState ["ForcedWidth"];
                if ((forcedWidthObject != null) && (forcedWidthObject is bool))
                {
                    forcedWidth = (bool) forcedWidthObject;
                }

                return forcedWidth;
            }
            set
            {
                ViewState ["ForcedWidth"] = value;

                return;
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
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their OnPreRender.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnPreRender (EventArgs e)
        {
            base.OnPreRender (e);

            if (Items.Count == 0)
            {
                if (Width == Unit.Empty)
                {
                    Width = 80;
                    ForcedWidth = true;
                }
            }
            else
            {
                if (ForcedWidth)
                {
                    Width = Unit.Empty;
                    ForcedWidth = false;
                }
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

            _label.RenderControl (realWriter);
            realWriter.Write ("<br />");

            base.Render (realWriter);

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
            base.CreateChildControls ();

            _label = new Label ();

            return;
        }
    }
}