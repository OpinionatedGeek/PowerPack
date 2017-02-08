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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A tag control that allows offensive words to be stripped from all content, whether it originally came
    /// from a database, another web site, or was input by other web users.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// The SwearFilter is a buffered control that controls the rendering of all child controls so that their
    /// output may be filtered.  This has no effect on the operation of those child controls (who don't see any
    /// difference), but it allows their output to be intercepted by this control before being passed on to the
    /// client browser.
    /// <p class="i1">
    /// The control is configured using a SwearFilter.config file.  This is an XML file whose contents are 
    /// basically a collection of word/replacement pairs. You can easily add to the list of blocked words by putting
    /// new words between <![CDATA[<BlockedWord><Word>...</Word></BlockedWord>]]> tags within the overall
    /// <![CDATA[<BlockedWords>...</BlockedWords>]]> tags.  A complete configuration file is shown at the end of
    /// this page.
    /// </p>
    /// <p class="i1">
    /// By default words are replaced by a string of asterisks the same length as the string being substituted.
    /// A custom replacement can be specified for each word by adding it between
    /// <![CDATA[<Replacement>...</Replacement>]]> tags.
    /// </p>
    /// <p class="i1">
    /// Changes to the configuration file should take effect immediately - there is no need to
    /// restart the server or recompile your pages.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// This control is entirely server-side and so places no dependencies on any client browser capabilities.
    /// </p>
    /// </remarks>
    /// <example>
    /// Using the Swear Filter on your pages is simple.  Just place the
    /// SwearFilter's tags around the HTML and controls you want to be filtered.
    /// <code>
    /// <![CDATA[
    /// <%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%>
    /// ...
    ///<opgeek:SwearFilter id="MyFilter" runat="server">
    ///   <%=Request.Form ["MyFileContents"]%>
    ///</opgeek:SwearFilter>
    /// ]]>
    /// </code>
    /// <p class="i1">
    /// Here is a complete, if simple, configuration file:
    /// </p>
    /// <code>
    /// <![CDATA[
    ///<?xml version="1.0"?>
    ///<SwearFilterConfiguration xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    ///	xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    ///   <BlockedWords>
    ///      <BlockedWord>
    ///         <Word>Homer</Word>
    ///         <Replacement>DOh!</Replacement>
    ///      </BlockedWord>
    ///      <BlockedWord>
    ///         <Word>Marge</Word>
    ///      </BlockedWord>
    ///      <BlockedWord>
    ///         <Word>Bart</Word>
    ///         <Replacement>Bartholomew</Replacement>
    ///      </BlockedWord>
    ///      <BlockedWord>
    ///         <Word>Lisa</Word>
    ///      </BlockedWord>
    ///      <BlockedWord>
    ///         <Word>Maggie</Word>
    ///      </BlockedWord>
    ///   </BlockedWords>
    ///</SwearFilterConfiguration>
    /// ]]>
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/SwearFilter.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [DefaultProperty ("Name")]
    [ToolboxData ("<{0}:SwearFilter runat=server></{0}:SwearFilter>")]
    [ParseChildren]
    [ToolboxBitmap (typeof (Bitmap))]
    [Designer (typeof (AutomaticDesigner))]
    [LicenseProvider (typeof (SwearFilterLicenseProvider))]
    public class SwearFilter : WebControl
    {
        //============================================================
        // Private Data
        //============================================================

        private const string ProductName = "SwearFilter";

        private SwearFilterConfiguration _blockedWords;
        private string _configFile = "SwearFilter.config";
        private License _license;
        private static readonly Hashtable _allConfigurations = new Hashtable ();

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="SwearFilter"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="SwearFilter"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public SwearFilter ()
        {
            _license = LicenseManager.Validate (typeof (SwearFilter), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets the name of the configuration file this tag should use.
        /// </summary>
        /// <remarks>
        /// By default the SwearFilter control will look for a configuration file called
        /// SwearFilter.config in the same folder as the current .aspx page. Although this
        /// allows you to tailor the filter every time you use it, it will probably be more convenient
        /// to set all your filter tags to use the same configuration file.  This is the property that
        /// allows you to specify what configuration file should be used.
        /// </remarks>
        /// <example>
        /// The following example shows how to specify the file "/mypf.config" should be used as the
        /// configuration file:
        /// <code>
        /// <![CDATA[
        ///<opgeek:SwearFilter id="MyFilter" ConfigFile="/mypf.config" runat="server">
        ///   ...
        ///</opgeek:SwearFilter>
        /// ]]>
        /// </code>
        /// </example>
        /// <value>The name of the configuration file this tag should use.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("SwearFilter.config")]
        [Description ("The name of the configuration file this tag should use.")]
        public string ConfigFile
        {
            get
            {
                return _configFile;
            }
            set
            {
                _configFile = value;

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

            string innerHtml = GetInnerHtml ();

            _blockedWords = GetConfiguration (_configFile);

            string filteredInnerHtml = FilterHtml (innerHtml);

            realWriter.Write (filteredInnerHtml);

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

        private string GetInnerHtml ()
        {
            var outputBuffer = new StringBuilder ("");
            var outputBufferWriter = new StringWriter (outputBuffer, Globalisation.GetCultureInfo ());
            var outputBufferHtmlWriter = new HtmlTextWriter (outputBufferWriter);
            RenderChildren (outputBufferHtmlWriter);

            return outputBuffer.ToString ();
        }

        private static SwearFilterConfiguration GetConfiguration (string configFile)
        {
            string filename = HttpContext.Current.Server.MapPath (configFile);
            var blockedWords = (SwearFilterConfiguration) _allConfigurations [NormaliseKey (filename)];

            if ((blockedWords == null) && (File.Exists (filename)))
            {
                blockedWords = SwearFilterConfiguration.LoadConfiguration (filename);
                _allConfigurations [NormaliseKey (filename)] = blockedWords;
                WatchConfigFile (filename);
            }

            return blockedWords;
        }

        private string FilterHtml (string html)
        {
            string filteredHtml = html;
            if (_blockedWords != null)
            {
                var filter = new StringBuilder ();
                foreach (BlockedWord bwWord in _blockedWords.BlockedWords)
                {
                    filter.Append (bwWord.Word);
                    filter.Append ("|");
                }

                if (filter.Length > 0)
                {
                    filter.Length = filter.Length - 1;
                }

                var filterRegex = new Regex (filter.ToString (), RegexOptions.IgnoreCase);
                filteredHtml = filterRegex.Replace (html, new MatchEvaluator (FilterMatcher));
            }

            return filteredHtml;
        }

        private string FilterMatcher (Match filterMatch)
        {
            return _blockedWords.GetReplacement (filterMatch.Value);
        }

        private static void WatchConfigFile (string completeFilename)
        {
            int pathSeparator = completeFilename.LastIndexOf ("\\");
            string foldername = "";
            string filename = "";
            if (pathSeparator > 0)
            {
                foldername = completeFilename.Substring (0, pathSeparator);
                filename = completeFilename.Substring (pathSeparator + 1);
            }

            var configFileWatcher = new FileSystemWatcher
                                        {
                                            Path = foldername,
                                            Filter = filename,
                                            NotifyFilter = NotifyFilters.LastWrite,
                                            IncludeSubdirectories = false
                                        };
            configFileWatcher.Changed += LoadChangedConfigFile;

            configFileWatcher.EnableRaisingEvents = true;

            return;
        }

        private static void LoadChangedConfigFile (object sender, FileSystemEventArgs e)
        {
            _allConfigurations [NormaliseKey (e.FullPath)] = null;

            return;
        }

        private static string NormaliseKey (string key)
        {
            return key.ToUpper (Globalisation.GetCultureInfo ());
        }
    }
}