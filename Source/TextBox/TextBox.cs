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
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// An enhanced TextBox, with Focus and Prompt features.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> Client-side Javascript must be available and enabled.
    /// </p>
    /// </summary>
    /// <remarks>
    /// The default TextBox provides a lot of features, but it misses a couple of simple ones.  There's
    /// no straightforward way to set a field as the default focus of a form, and there's no way to
    /// present some simple text already in the field as a 'prompt' which disappears as soon as the
    /// user tries to input their own text.  Both of these features have been added in this version!
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b> 
    /// If these features require functionality not present in the current browser (for example if the current
    /// browser is not known to support client-side Javascript) then these features are not output.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then sets
    /// it to have the default focus of the page.
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:TextBox
    ///     height="200"
    ///     width="400"
    ///     name="test"
    ///     focus=true
    ///     runat="server"/&gt;
    /// </code>
    /// <p class="i1">
    /// Here's another example.  This code declares the tag for use on the page via the Register directive, and
    /// then sets it to have a prompt that says 'Click Me!'.
    /// </p>
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:TextBox
    ///     height="200"
    ///     width="400"
    ///     name="test"
    ///     prompt="Click Me!"
    ///     runat="server"/&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/TextBox.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [DefaultProperty ("Text")]
    [ToolboxData ("<{0}:TextBox runat=server></{0}:TextBox>")]
    [ToolboxBitmap (typeof (System.Web.UI.WebControls.TextBox))]
    [LicenseProvider (typeof (TextBoxLicenseProvider))]
    public class TextBox : System.Web.UI.WebControls.TextBox
    {
        //============================================================
        // Events
        //============================================================

        ///
        /// <summary>
        /// Occurs when the server control may need to output the client-side Focus script.
        /// </summary>
        /// <remarks>
        /// Notifies the server control to perform any processing steps that are set to occur when a focus script
        /// may need to be output.  This event will be called once, after onload, and will be called regardless of
        /// the browser user agent.
        /// </remarks>
        ///
        public event EventHandler FocusScriptRequired;

        ///
        /// <summary>
        /// Occurs when the server control may need to output the client-side Prompt script.
        /// </summary>
        /// <remarks>
        /// Notifies the server control to perform any processing steps that are set to occur when a script to handle
        /// prompt text may need to be output.  This event will be called once, after onload, and will be called
        /// regardless of the browser user agent.
        /// </remarks>
        ///
        public event EventHandler PromptScriptRequired;

        //============================================================
        // Private Data
        //============================================================

        private const string ProductName = "TextBox";
        private const string FocusScriptKeyPrefix = "FocusOnTextBox_";
        private const string PromptScriptKey = "PromptInTextBox";
        private const string GetTextBoxKey = "GenericGetTextBox";

        private const string MozAndNSGetTextBox = @"<script language=""Javascript"">
		function getTextBox_tb_opgeek
		(
			strInstanceName
		)
		{
			var nFormCounter;
			for (nFormCounter = 0; nFormCounter < document.forms.length; nFormCounter++)
			{
				var nFieldCounter;
				for (nFieldCounter = 0; nFieldCounter < document.forms [nFormCounter].elements.length; nFieldCounter++)
				{
					if (document.forms [nFormCounter].elements [nFieldCounter].name == strInstanceName)
					{
						return document.forms [nFormCounter].elements [nFieldCounter];
					}
				}
			}

			return null;
		}
		</script>";

        private const string IEGetTextBox = @"<script language=""Javascript"">
		function getTextBox_tb_opgeek
		(
			strInstanceName
		)
		{
			return document.getElementById (strInstanceName);
		}
		</script>";

        private const string PromptScript = @"<script language=""Javascript"">
		function ClearTextField_tb_opgeek
		(
			field,
			prompt,
			realText
		)
		{
			if ((field.value == prompt) && (prompt != realText))
			{
				field.value = realText;
			}

			return;
		}
		</script>";

        private const string IEPromptActionTemplate = @"return ClearTextField_tb_opgeek (this, '{0}', '{1}');";
        private const string MozPromptActionTemplate = @"return ClearTextField_tb_opgeek (event.target, '{0}', '{1}');";
        private const string NSPromptActionTemplate = @"return ClearTextField_tb_opgeek (this, '{0}', '{1}');";

        private const string PromptSetupScript = @"<script language=""Javascript"">
getTextBox_tb_opgeek (""{0}"").value = ""{1}"";
		</script>";

        private const string FocusActionTemplate = @"<script language=""Javascript"">
getTextBox_tb_opgeek (""{0}"").focus ();
</script>";

        private static readonly UserAgentParser _userAgentParser = new UserAgentParser ();

        private bool _enableClientScript = true;
        private bool _focus;
        private string _prompt;
        private bool _promptScriptOutput;
        private bool _uplevelBrowser;
        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="TextBox"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public TextBox ()
        {
            _license = LicenseManager.Validate (typeof (TextBox), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Tells this field whether to grab the cursor focus or not.
        /// </summary>
        /// <remarks>
        /// When set to true, this tells the control to use client-side Javascript to set
        /// this field to have the default focus.  When set to false, nothing is done.
        /// </remarks>
        /// <value>
        /// <b>True</b> - output client-side Javascript to set this field's focus.<br/>
        /// <b>False (default)</b> - don't do anything regarding setting the focus.
        /// </value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue (false)]
        [Description (@"Whether or not to take the default focus when the page loads.")]
        public virtual bool GrabFocus
        {
            get
            {
                return _focus;
            }
            set
            {
                _focus = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gives the field a default 'prompt' value that is removed as soon as the user tries to use the field.
        /// </summary>
        /// <remarks>
        /// Simply put, this property places text in the value of the textbox itself until the field gets the
        /// focus.  When this happens, the prompt text is replaced with the real text of the field, or the
        /// empty string if no text has been set.
        /// </remarks>
        /// <value>A string of prompt text to be used to prompt the user.  The default value is null.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance"), DefaultValue ("")]
        [Description (@"A simple text prompt that will initially appear as the value of the TextBox until the user clicks there or otherwise sets focus in the box.")]
        public virtual string Prompt
        {
            get
            {
                return _prompt;
            }
            set
            {
                _prompt = value;

                return;
            }
        }

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

            if (DesignMode)
            {
            }
            else
            {
                BrowserType browserType = GetBrowserType ();
                switch (browserType)
                {
                    case BrowserType.FireFox2:
                    case BrowserType.IE5Up:
                    case BrowserType.IE6Up:
                    case BrowserType.IE7Up:
                    case BrowserType.Mozilla:
                    case BrowserType.Netscape:
                    case BrowserType.WebKit:
                        _uplevelBrowser = true;
                        break;
                }
            }

            return;
        }

        ///
        /// <summary>
        /// Raises the Load event.
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

            if ((_uplevelBrowser) && (EnableClientScript))
            {
                if (_focus)
                {
                    OnFocusScriptRequired (EventArgs.Empty);
                    if (FocusScriptRequired != null)
                    {
                        FocusScriptRequired (this, EventArgs.Empty);
                    }
                }

                if ((_prompt != null) && (!Page.IsPostBack))
                {
                    OnPromptScriptRequired (EventArgs.Empty);
                    if (PromptScriptRequired != null)
                    {
                        PromptScriptRequired (this, EventArgs.Empty);
                    }
                }
            }

            return;
        }

        ///
        /// <summary>
        /// Raises the FocusScriptRequired event.
        /// </summary>
        /// <remarks>
        /// This method inserts the required client-side Javascript to set the control's focus.  This need not
        /// be called in derived classes if the client-side Javascript is not required - the event itself will
        /// still be raised.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected virtual void OnFocusScriptRequired (EventArgs e)
        {
            if (!DesignMode)
            {
                BrowserType browserType = GetBrowserType ();
                switch (browserType)
                {
                    case BrowserType.IE5Up:
                    case BrowserType.IE6Up:
                    case BrowserType.IE7Up:
                        Page.ClientScript.RegisterClientScriptBlock (typeof (TextBox), GetTextBoxKey, IEGetTextBox);
                        string ieFocuser = String.Format (Globalisation.GetCultureInfo (), FocusActionTemplate, UniqueID);
                        Page.ClientScript.RegisterStartupScript (typeof (TextBox), FocusScriptKeyPrefix + UniqueID, ieFocuser);
                        break;

                    case BrowserType.FireFox2:
                    case BrowserType.Mozilla:
                    case BrowserType.WebKit:
                        Page.ClientScript.RegisterClientScriptBlock (typeof (TextBox), GetTextBoxKey, MozAndNSGetTextBox);
                        string mozFocuser = String.Format (Globalisation.GetCultureInfo (), FocusActionTemplate, UniqueID);
                        Page.ClientScript.RegisterStartupScript (typeof (TextBox), FocusScriptKeyPrefix + UniqueID, mozFocuser);
                        break;

                    case BrowserType.Netscape:
                        Page.ClientScript.RegisterClientScriptBlock (typeof (TextBox), GetTextBoxKey, MozAndNSGetTextBox);
                        string netscapeFocuser = String.Format (Globalisation.GetCultureInfo (), FocusActionTemplate, UniqueID);
                        Page.ClientScript.RegisterStartupScript (typeof (TextBox), FocusScriptKeyPrefix + UniqueID, netscapeFocuser);
                        break;
                }
            }

            return;
        }

        ///
        /// <summary>
        /// Raises the PromptScriptRequired event.
        /// </summary>
        /// <remarks>
        /// This method inserts the required client-side Javascript to remove the control's prompt text.  This
        /// need not be called in derived classes if the client-side Javascript is not required - the event
        /// itself will still be raised.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected virtual void OnPromptScriptRequired (EventArgs e)
        {
            if (!DesignMode)
            {
                BrowserType browserType = GetBrowserType ();
                switch (browserType)
                {
                    case BrowserType.IE5Up:
                    case BrowserType.IE6Up:
                    case BrowserType.IE7Up:
                        Page.ClientScript.RegisterClientScriptBlock (typeof (TextBox), PromptScriptKey, PromptScript);
                        string iePromptSetup = String.Format (Globalisation.GetCultureInfo (), PromptSetupScript, ClientID, _prompt);
                        Page.ClientScript.RegisterClientScriptBlock (typeof (TextBox), GetTextBoxKey, IEGetTextBox);
                        Page.ClientScript.RegisterStartupScript (typeof (TextBox), PromptScriptKey + UniqueID, iePromptSetup);
                        _promptScriptOutput = true;
                        break;

                    case BrowserType.FireFox2:
                    case BrowserType.Mozilla:
                    case BrowserType.WebKit:
                        Page.ClientScript.RegisterClientScriptBlock (typeof (TextBox), PromptScriptKey, PromptScript);
                        string mozillaPromptSetup = String.Format (Globalisation.GetCultureInfo (), PromptSetupScript, ClientID, _prompt);
                        Page.ClientScript.RegisterClientScriptBlock (typeof (TextBox), GetTextBoxKey, MozAndNSGetTextBox);
                        Page.ClientScript.RegisterStartupScript (typeof (TextBox), PromptScriptKey + UniqueID, mozillaPromptSetup);
                        _promptScriptOutput = true;
                        break;

                    case BrowserType.Netscape:
                        Page.ClientScript.RegisterClientScriptBlock (typeof (TextBox), PromptScriptKey, PromptScript);
                        string netscapePromptSetup = String.Format (Globalisation.GetCultureInfo (), PromptSetupScript, ClientID, _prompt);
                        Page.ClientScript.RegisterClientScriptBlock (typeof (TextBox), GetTextBoxKey, MozAndNSGetTextBox);
                        Page.ClientScript.RegisterStartupScript (typeof (TextBox), PromptScriptKey + UniqueID, netscapePromptSetup);
                        _promptScriptOutput = true;
                        break;
                }
            }

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

            if ((_uplevelBrowser) && (_prompt != null) && (_promptScriptOutput) && (!Page.IsPostBack))
            {
                AddPromptAttributes ();
            }

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
        /// Adds details of the prompt text to the control's attributes.
        /// </summary>
        /// <remarks>
        /// This method adds details of prompt text to the control's attribute collection as well as setting up
        /// the onFocus event.  This method is exposed so that it is available for derived classes that choose
        /// to override the Render () method, as well as allowing derived classes to override this behaviour.
        /// However, it is not recommended that you call or override this method since it is quite tightly coupled
        /// to the way the prompt text feature is implemented.
        /// </remarks>
        ///
        protected virtual void AddPromptAttributes ()
        {
            if (!DesignMode)
            {
                BrowserType browserType = GetBrowserType ();
                switch (browserType)
                {
                    case BrowserType.IE5Up:
                    case BrowserType.IE6Up:
                    case BrowserType.IE7Up:
                        string iePrompt = String.Format (Globalisation.GetCultureInfo (), IEPromptActionTemplate, Prompt, Normaliser.NormaliseForJavascript (Text));
                        Attributes.Add ("onFocus", iePrompt);
                        Attributes.Add ("prompt", _prompt);
                        break;

                    case BrowserType.FireFox2:
                    case BrowserType.Mozilla:
                    case BrowserType.WebKit:
                        string mozPrompt = String.Format (Globalisation.GetCultureInfo (), MozPromptActionTemplate, Prompt, Normaliser.NormaliseForJavascript (Text));
                        Attributes.Add ("onFocus", mozPrompt);
                        Attributes.Add ("prompt", _prompt);
                        break;

                    case BrowserType.Netscape:
                        string netscapePrompt = String.Format (Globalisation.GetCultureInfo (), NSPromptActionTemplate, Prompt, Normaliser.NormaliseForJavascript (Text));
                        Attributes.Add ("onFocus", netscapePrompt);
                        Attributes.Add ("prompt", _prompt);
                        break;
                }
            }

            return;
        }

        private static BrowserType GetBrowserType ()
        {
            HttpBrowserCapabilities client = HttpContext.Current.Request.Browser;

            return _userAgentParser.Parse (client);
        }
    }
}