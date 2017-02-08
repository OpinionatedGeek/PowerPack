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

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// Specifies the behavior mode of the <see cref="EmailAddressValidator"/>
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// This enumeration allows some control over the number of checks performed by the
    /// <see cref="EmailAddressValidator"/> control.  The checks increase in their complexity, with the
    /// <see cref="Format"/> option being the simplest - it only checks the format of the entered value.
    /// Next is the <see cref="Server"/> option, which performs the <see cref="Format"/> option tests and then
    /// checks for the existence of an appropriate DNS record for that mail domain.  Finally, the
    /// <see cref="Recipient"/> option performs the checks for the <see cref="Format"/> and <see cref="Server"/>
    /// options and then opens an SMTP connection to that server to verify the recipient is valid.
    /// <seealso cref="EmailAddressValidator"/>
    /// </remarks>
    ///
    public enum EmailAddressCheck
    {
        ///
        /// <summary>
        /// Only the format of the address is verified.
        /// </summary>
        /// <remarks>
        /// Using this option, only the format of the address is verified, no DNS lookup or test connections to
        /// that SMTP server are attempted.
        /// </remarks>
        ///
        Format,

        ///
        /// <summary>
        /// The format of the address is verified, and a DNS lookup is performed for the mail server.
        /// </summary>
        /// <remarks>
        /// Using this option, the format of the address is verified as with the <see cref="Format"/> option.
        /// If that test is passed, then a DNS lookup is performed for the mail exchange (MX) record for that
        /// email address.  If that fails, a lookup is performed for the normal A record for that address.
        /// No test connections to that address are attempted.
        /// </remarks>
        ///
        Server,

        ///
        /// <summary>
        /// The format of the address is verified, a DNS lookup is performed for the mail server, and a test
        /// connection is opened to that SMTP server to verify the address.
        /// </summary>
        /// <remarks>
        /// Using this option, the tests for both the <see cref="Format"/> option and <see cref="Server"/> option
        /// are performed, and if successful a test SMTP connection is opened to that server to verify the
        /// recipient.
        /// </remarks>
        ///
        Recipient
    }
}