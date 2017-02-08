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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// Validates whether the value of an associated input control is a valid email address or not.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// The <see cref="EmailAddressValidator"/> provides a simple way of validating that an email address
    /// entered by a user is a real address and not a fake one.  It provides three 'modes':
    /// <br />
    /// <list type="bullet">
    ///		<item>
    ///			<term>Format</term>
    ///			<description>Verifies that the address is properly formatted and 'looks like' an email address.</description>
    ///		</item>
    ///		<item>
    ///			<term>Server</term>
    ///			<description>Performs the 'Format' check and, if successful, verifies that the specified email domain
    ///			has a valid DNS record.</description>
    ///		</item>
    ///		<item>
    ///			<term>Recipient</term>
    ///			<description>Performs the above 'Server' check and, if successful, verifies that the specified email
    ///			server is willing to accept email for that address.</description>
    ///		</item>
    /// </list>
    /// <p class="i1">
    /// The mode is chosen by specifying the appropriate value for the <see cref="Check"/> property.
    /// </p>
    /// <p class="i1">
    /// As with built-in .NET validators, <b>an empty value is considered valid</b>.  If an email address is
    /// mandatory, the field should be linked to both an <see cref="EmailAddressValidator"/> and a
    /// <see cref="RequiredFieldValidator"/>.
    /// </p>
    /// <p class="i1">
    /// Note: this validator gives more confidence that the input address is correct, but it cannot provide a complete
    /// solution, for two reasons:
    /// <list type="number">
    ///		<item>
    ///			First of all, some servers will not return an error when given a non-existant address.  This is
    ///			primarily to stop spammers 'scanning' the email server to generate a list of addresses on that
    ///			system.  So it is possible for all the tests to pass for a non-existant email address.
    ///		</item>
    ///		<item>
    ///			Secondly, just because the email address exists doesn't mean it's the correct email address.  The
    ///			user could have accidentally entered another valid address, or may have entered someone else's
    ///			email address on purpose.
    ///		</item>
    /// </list>
    /// </p>
    /// <seealso cref="EmailAddressCheck"/>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then puts
    /// a TextBox and EmailAddressValidator control on the page.  This validator is set to verify the server
    /// DNS record exists but not to verify the recipient address on that server.
    /// <code>
    /// &lt;%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%&gt;
    /// ...
    /// &lt;opgeek:TextBox
    ///     id="tbEmail"
    ///     runat="server"/&gt;
    /// &lt;opgeek:EmailAddressValidator
    ///     ControlToValidate="tbEmail"
    ///     ErrorMessage="That email address is not valid"
    ///     Check="Server"
    ///     runat="server"&gt;*&lt;/opgeek:EmailAddressValidator&gt;
    /// </code>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/EmailAddressValidator.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    ///
    [LicenseProvider (typeof (EmailAddressValidatorLicenseProvider))]
    [ToolboxBitmap (typeof (RequiredFieldValidator))]
    public class EmailAddressValidator : RegularExpressionValidator
    {
        //============================================================
        // Private Data
        //============================================================

        private const string ProductName = "EmailAddressValidator";

        private const string ValidMailboxCharactersRegex = @"[a-zA-Z_0-9_\.\!\#\$\%\*\+\-\/\=\?\^\`\{\|\}\~]+";
        private const string ValidServerCharactersRegex = @"[a-zA-Z_0-9\-]+\.[a-zA-Z_0-9\-]+(\.[a-zA-Z_0-9\-]+)*";
        private const string ValidAddressRegex = @"^\s*" + ValidMailboxCharactersRegex + "@" + ValidServerCharactersRegex + @"\s*$";

        private IPAddress _serverAddress;
        private string _fromAddress;
        private EmailAddressCheck _check = EmailAddressCheck.Recipient;
        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddressValidator"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="EmailAddressValidator"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public EmailAddressValidator ()
        {
            _license = LicenseManager.Validate (typeof (EmailAddressValidator), this);

            ValidationExpression = ValidAddressRegex;

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets the custom DNS server to be used for looking up MX and A records.
        /// </summary>
        /// <remarks>
        /// Both <b>Server</b> and <b>Recipient</b> modes require a DNS lookup for the domain/hostname
        /// part of the email address.  By default this will be performed using whatever DNS settings are
        /// configured in the server, but this property allows you to override the system DNS with the IP
        /// address of a different DNS server.
        /// </remarks>
        /// <value>The IP address of a custom DNS server to be used for lookups.  By default, this property
        /// is <b>null</b> and lookups are performed on whatever DNS hosts are specified on the server's
        /// configuration.</value>
        ///
        public IPAddress DnsServer
        {
            get
            {
                return _serverAddress;
            }
            set
            {
                _serverAddress = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the custom 'FROM' address to be used when validating the recipient.
        /// </summary>
        /// <remarks>
        /// Verifying the recipient (part of the 'Recipient' mode) requires connecting to the SMTP server and
        /// specifying 'FROM' and 'TO' addresses.  By default, the <see cref="EmailAddressValidator"/> uses the
        /// same address for both the 'FROM' and 'TO' addresses - after all, it is generally possible to send
        /// email to yourself.  However, given the wide range of email systems out there, it is possible that some
        /// will not allow this, so you can override the 'FROM' address used in the test connection by specifying
        /// a valid email address here.
        /// </remarks>
        /// <value>The email address to use as the 'FROM' address in test connections.  By default, this property
        /// is <b>null</b> and the same test address is used as both 'FROM' and 'TO' addresses.</value>
        ///
        public string FromAddress
        {
            get
            {
                return _fromAddress;
            }
            set
            {
                _fromAddress = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the 'mode' the <see cref="EmailAddressValidator"/> is using.
        /// </summary>
        /// <remarks>
        /// The <see cref="EmailAddressValidator"/> provides three modes of operation:
        /// <list type="bullet">
        ///		<item>
        ///			<term>Format</term>
        ///			<description>
        ///				Verifies that the address is properly formatted and 'looks like' an email address.  This is
        ///				the fastest check, but also the weakest.
        ///			</description>
        ///		</item>
        ///		<item>
        ///			<term>Server</term>
        ///			<description>
        ///				Performs the 'Format' check and, if successful, verifies that the specified email domain
        ///				has a valid DNS record.  This check is not as fast as 'Format', since it requires at least
        ///				one and possibly two DNS lookups.  It is also a stronger check than 'Format'.  However, it
        ///				is usually much faster than 'Recipient'.
        ///			</description>
        ///		</item>
        ///		<item>
        ///			<term>Recipient</term>
        ///			<description>
        ///				Performs the above 'Server' check and, if successful, verifies that the specified email
        ///				server is willing to accept email for that address.  This is the strongest check but also
        ///				the one that takes longest to perform and is most dependent on external systems and servers.
        ///			</description>
        ///		</item>
        /// </list>
        /// </remarks>
        /// <value>
        ///		<b><see cref="EmailAddressCheck.Format"/></b>, <b><see cref="EmailAddressCheck.Server"/></b>
        ///		or <b><see cref="EmailAddressCheck.Recipient"/></b>, depending on the level of verification required.
        ///		The default is <see cref="EmailAddressCheck.Recipient"/>.
        ///	</value>
        ///
        public EmailAddressCheck Check
        {
            get
            {
                return _check;
            }
            set
            {
                _check = value;

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
        /// This method contains the code to determine whether the email address in the input control is valid.
        /// </summary>
        /// <remarks>
        /// Performs the checks specified in the <see cref="Check"/> property.
        /// </remarks>
        /// <returns>
        /// <b>true</b> if the email address in the input control passes all checks; otherwise, <b>false</b>.
        /// </returns>
        ///
        protected override bool EvaluateIsValid ()
        {
            bool isValid = base.EvaluateIsValid ();
            if (isValid)
            {
                if ((Check == EmailAddressCheck.Server) || (Check == EmailAddressCheck.Recipient))
                {
                    string addressToValidate = GetControlValidationValue (ControlToValidate);
                    if (addressToValidate != null)
                    {
                        addressToValidate = addressToValidate.Trim ();
                        if (addressToValidate.Length != 0)
                        {
                            isValid = false;
                            string domain = GetUsersDomain (addressToValidate);
                            if (domain != null)
                            {
                                string mailDomain = GetMailDomain (domain);
                                if (mailDomain != null)
                                {
                                    isValid = !(Check == EmailAddressCheck.Recipient) || VerifyMailAddressOnServer (mailDomain, addressToValidate);
                                }
                            }
                        }
                    }
                }
            }

            return isValid;
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

        private static string GetUsersDomain (string addressToValidate)
        {
            string domain = null;
            int atAt = addressToValidate.IndexOf ("@");
            if (atAt > -1)
            {
                domain = addressToValidate.Substring (atAt + 1);
                if (domain.IndexOf ("@") > -1)
                {
                    domain = null;
                }
            }

            return domain;
        }

        private string GetMailDomain (string domain)
        {
            string mailHost = null;
            var lookup = new DnsLookup {BypassCache = true};
            if (_serverAddress != null)
            {
                lookup.DnsServer = _serverAddress;
            }

            List<DnsRecord> servers = lookup.LookupMx (domain);
            if ((servers == null) || (servers.Count == 0))
            {
                servers = lookup.LookupA (domain);
            }

            if ((servers != null) && (servers.Count > 0))
            {
                if (servers [0] is DnsRecord_MX)
                {
                    var mx = (DnsRecord_MX) servers [0];
                    mailHost = mx.Server;
                }
                else if (servers [0] is DnsRecord_A)
                {
                    var a = (DnsRecord_A) servers [0];
                    var address = new IPAddress (a.IPAddress);
                    mailHost = address.ToString ();
                }
            }

            return mailHost;
        }

        private bool VerifyMailAddressOnServer (string server, string userAddress)
        {
            bool success = false;

            using (var smtpConnection = new TcpClient (server, 25))
            {
                using (NetworkStream smtpStream = smtpConnection.GetStream ())
                {
                    using (var smtpResponses = new StreamReader (smtpStream))
                    {
                        try
                        {
                            smtpResponses.ReadLine ();

                            SendCommand (smtpStream, smtpResponses, "HELO server");

                            string szFromAddress = userAddress;
                            if (FromAddress != null)
                            {
                                szFromAddress = FromAddress;
                            }
                            SendCommand (smtpStream, smtpResponses, "MAIL FROM: <" + szFromAddress + ">");

                            string szResponse = SendCommand (smtpStream, smtpResponses, "RCPT TO: <" + userAddress + ">");
                            success = VerifyResponse (szResponse);

                            SendCommand (smtpStream, smtpResponses, "QUIT");
                        }
                        catch (InvalidOperationException)
                        {
                        }
                        catch (IOException)
                        {
                        }
                    }
                }
            }

            return success;
        }

        private static string SendCommand (Stream writeTo, TextReader readFrom, string command)
        {
            Byte[] commandBytes = Encoding.ASCII.GetBytes ((command + "\r\n").ToCharArray ());
            writeTo.Write (commandBytes, 0, commandBytes.Length);

            return readFrom.ReadLine ();
        }

        private static bool VerifyResponse (string response)
        {
            bool success = false;
            if (response.StartsWith ("250 "))
            {
                success = true;
            }

            return success;
        }
    }
}