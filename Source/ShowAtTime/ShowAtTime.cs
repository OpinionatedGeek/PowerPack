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
    /// Displays or hides all child controls depending on specified time-based parameters.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// Say you have a special deal that you want to kick in at midnight on the 1st of September 2003 and run for
    /// all that month.  Now you <i>could</i> be ready at midnight and FTP up the appropriate file, or you could
    /// just use this control and set those dates and times so that, on the dot of midnight, the new text would
    /// be displayed.  It would continue to be shown for that month (or you could replace that page when you wake
    /// up the next day!).
    /// <p class="i1">
    /// This control allows you to display or hide some content based on the date and/or time.  It can contain an 'If'
    /// template and an 'Else' template.  If the current date and time meet the specified criteria then the 'If' template
    /// is displayed.  If the current date and time do <b>not</b> meet the specified criteria, then the 'Else'
    /// template is displayed.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This facility is available to all browsers.
    /// </p>
    /// </remarks>
    /// <example>
    /// Here's a simple page that shows the text "TIME-DELAYED DISPLAY" between the 1st of September 2003 and
    /// 30th September 2003.
    /// <code>
    /// <![CDATA[
    ///<%@ Register TagPrefix="opgeek"
    ///	Namespace="OpinionatedGeek.Web.PowerPack"
    ///	Assembly="OpinionatedGeek.Web.PowerPack"%>
    ///	...
    ///	<opgeek:ShowAtTime StartAt="09/01/2002 00:00" StopAt="09/30/2002 23:59" runat="server">
    ///   <iftemplate>
    ///		TIME-DELAYED DISPLAY
    ///   </iftemplate>
    ///	</opgeek:ShowAtTime>
    /// ]]>
    ///	</code>
    /// Here's another, more complete example.  This page that shows "Good Morning", "Good Afternoon", "Good Evening" or
    /// "Good Night", depending on the current time.
    /// <code>
    /// <![CDATA[
    ///<%@ Register TagPrefix="opgeek"
    ///	Namespace="OpinionatedGeek.Web.PowerPack"
    ///	Assembly="OpinionatedGeek.Web.PowerPack"%>
    ///<html>
    ///<head>
    ///	<title>ShowAtTime Example</title>
    ///</head>
    ///<body>
    ///	<p>
    ///	  Good
    ///	    <opgeek:ShowAtTime StartAt="01/01/2001 00:00" StopAt="01/01/2001 06:00" IgnoreDateParts="true" runat="server">
    ///	      <iftemplate>Night</iftemplate>
    ///	      <elsetemplate>
    ///	        <opgeek:ShowAtTime StartAt="01/01/2001 06:00" StopAt="01/01/2001 12:00" IgnoreDateParts="true" runat="server">
    ///	          <iftemplate>Morning</iftemplate>
    ///	          <elsetemplate>
    ///	            <opgeek:ShowAtTime StartAt="01/01/2001 12:00" StopAt="01/01/2001 18:00" IgnoreDateParts="true" runat="server">
    ///	              <iftemplate>Afternoon</iftemplate>
    ///	              <elsetemplate>Evening</elsetemplate>
    ///	            </opgeek:ShowAtTime>
    ///	          </elsetemplate>
    ///	        </opgeek:ShowAtTime>
    ///	      </elsetemplate>
    ///	    </opgeek:ShowAtTime>
    ///	</p>
    ///</body>
    ///</html>
    /// ]]>
    ///	</code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/ShowAtTime.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [ToolboxData ("<{0}:ShowAtTime runat=server></{0}:ShowAtTime>")]
    [ParseChildren (true)]
    [ToolboxBitmap (typeof (Panel))]
    [LicenseProvider (typeof (ShowAtTimeLicenseProvider))]
    [Designer (typeof (AutomaticDesigner))]
    public class ShowAtTime : WebControl, INamingContainer
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "ShowAtTime";

        private ITemplate _if;
        private ITemplate _else;
        private Control _ifPanel;
        private Control _elsePanel;

        private DateTime _start = DateTime.MinValue;
        private DateTime _stop = DateTime.MaxValue;
        private bool _ignoreDatePart;
        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowAtTime"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="ShowAtTime"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public ShowAtTime ()
        {
            _license = LicenseManager.Validate (typeof (ShowAtTime), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// The date-time to <i>start</i> showing the contents of the tag.
        /// </summary>
        /// <remarks>
        /// The date-time to <i>start</i> showing the contents of the tag.  If the current date-time is before
        /// this, the contents will not be displayed on the web page.
        /// </remarks>
        /// <value>The date-time to <i>start</i> showing child contents - default is DateTime.MinValue.</value>
        ///
        public virtual DateTime StartAt
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;

                return;
            }
        }

        ///
        /// <summary>
        /// The date-time to <i>stop</i> showing the contents of the tag.
        /// </summary>
        /// <remarks>
        /// The date-time to <i>stop</i> showing the contents of the tag.  If the current date-time is after
        /// this, the contents will not be displayed on the web page.
        /// </remarks>
        /// <value>The date-time to <i>stop</i> showing child contents - default is DateTime.MaxValue.</value>
        ///
        public virtual DateTime StopAt
        {
            get
            {
                return _stop;
            }
            set
            {
                _stop = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Whether we ignore the date parts or not.
        /// </summary>
        /// <remarks>
        /// The tag can be set to ignore the date parts of the start and end times.  This will allow the tag
        /// to show its contents based on a recurrance pattern, say always between 12:00 and 2:00.
        /// </remarks>
        /// <value>Whether we ignore the date parts (true) or not (false).  Default is false.</value>
        ///
        public virtual bool IgnoreDateParts
        {
            get
            {
                return _ignoreDatePart;
            }
            set
            {
                _ignoreDatePart = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the custom content to be displayed if the time matches.
        /// </summary>
        /// <remarks>
        /// The <see cref="ShowAtTime" /> control renders a different template 
        /// depending on whether the current time falls between the <see cref="StartAt" />
        /// and <see cref="StopAt" /> <see cref="DateTime" />s.  If the time falls between
        /// <see cref="StartAt" /> and <see cref="StopAt" />, the <see cref="IfTemplate" />
        /// is displayed, otherwise the <see cref="ElseTemplate" /> is displayed.
        /// </remarks>
        /// <value>A <see cref="ITemplate" /> that contains the custom content to be
        /// displayed if the time matches. The default value is <c>null</c>, which
        /// indicates that this property is not set.</value>
        /// <seealso cref="StartAt"/>
        /// <seealso cref="StopAt"/>
        /// <seealso cref="ElseTemplate"/>
        ///
        [TemplateContainer (typeof (ChildTemplatePanel))]
        public ITemplate IfTemplate
        {
            get
            {
                return _if;
            }
            set
            {
                _if = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the custom content to be displayed if the time does not match.
        /// </summary>
        /// <remarks>
        /// The <see cref="ShowAtTime" /> control renders a different template 
        /// depending on whether the current time falls between the <see cref="StartAt" />
        /// and <see cref="StopAt" /> <see cref="DateTime" />s.  If the time falls between
        /// <see cref="StartAt" /> and <see cref="StopAt" />, the <see cref="IfTemplate" />
        /// is displayed, otherwise the <see cref="ElseTemplate" /> is displayed.
        /// </remarks>
        /// <value>A <see cref="ITemplate" /> that contains the custom content to be
        /// displayed if the time matches. The default value is <c>null</c>, which
        /// indicates that this property is not set.</value>
        /// <seealso cref="StartAt"/>
        /// <seealso cref="StopAt"/>
        /// <seealso cref="IfTemplate"/>
        ///
        [TemplateContainer (typeof (ChildTemplatePanel))]
        public ITemplate ElseTemplate
        {
            get
            {
                return _else;
            }
            set
            {
                _else = value;

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
        /// Makes final decision on whether to display the 'If' contents or the 'Else' contents.
        /// </summary>
        /// <remarks>
        /// This is where the final decision is taken on whether to display the contents or not.  The same criteria
        /// as those used in the ShowWhen control are used.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnPreRender (EventArgs e)
        {
            bool isCurrentlyVisible = Visible;
            base.OnPreRender (e);
            Visible = isCurrentlyVisible;

            DateTime now = DateTime.Now;
            if (Enabled)
            {
                if (DoWeShow (now))
                {
                    ShowIf ();
                }
                else
                {
                    ShowElse ();
                }
            }
            else
            {
                _ifPanel.Visible = false;
                _elsePanel.Visible = false;
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

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use
        /// composition-based implementation to create any child controls they contain in
        /// preparation for posting back or rendering. 
        /// </summary>
        /// <remarks>
        /// When you develop a composite or templated server control, you must override
        /// this method. Controls that override the <see cref="CreateChildControls" />
        /// method should implement the <see cref="INamingContainer" /> interface to avoid
        /// naming conflicts.
        /// </remarks>
        protected override void CreateChildControls ()
        {
            base.CreateChildControls ();

            _ifPanel = new Control ();
            Controls.Add (_ifPanel);
            _ifPanel.ID = "If";

            _elsePanel = new Control ();
            Controls.Add (_elsePanel);
            _elsePanel.ID = "Else";

            return;
        }

        private bool DoWeShow (DateTime dateTimeToCheck)
        {
            bool doWeShow = _ignoreDatePart ? DoWeShow_TimeOnly (dateTimeToCheck) : DoWeShow_DateAndTime (dateTimeToCheck);

            return doWeShow;
        }

        private bool DoWeShow_DateAndTime (IComparable<DateTime> dateTimeToCheck)
        {
            bool doWeShow = true;
            if ((dateTimeToCheck.CompareTo (_start) < 0) || (dateTimeToCheck.CompareTo (_stop) > 0))
            {
                doWeShow = false;
            }

            return doWeShow;
        }

        private bool DoWeShow_TimeOnly (DateTime dateTimeToCheck)
        {
            bool doWeShow = true;
            TimeSpan timeToCheck = dateTimeToCheck.TimeOfDay;
            TimeSpan startTime = _start.TimeOfDay;
            TimeSpan stopTime = _stop.TimeOfDay;
            if ((timeToCheck.CompareTo (startTime) < 0) || (timeToCheck.CompareTo (stopTime) > 0))
            {
                doWeShow = false;
            }

            return doWeShow;
        }

        private void ShowIf ()
        {
            if (_if != null)
            {
                _ifPanel.Visible = true;
                _elsePanel.Visible = false;
                _if.InstantiateIn (_ifPanel);
            }

            return;
        }

        private void ShowElse ()
        {
            if (_else != null)
            {
                _ifPanel.Visible = false;
                _elsePanel.Visible = true;
                _else.InstantiateIn (_elsePanel);
            }

            return;
        }

        private class ChildTemplatePanel : Panel, INamingContainer
        {
        }
    }
}