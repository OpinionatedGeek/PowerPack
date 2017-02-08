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

using System.Web.UI.WebControls;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// An object derived from the standard Style object which has been extended to
    /// support text decorations.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> Not applicable.
    /// </p>
    /// </summary>
    /// <remarks>
    /// Works identically to the default Style object.  However, the ability to 'decorate' text
    /// has been added via the new 'Decoration' property.
    /// <p class="i1">
    /// Unfortunately, this 'decoration' style only works with controls that specifically know about the
    /// EnhancedStyle class, rather than with all controls that work with the Style class.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b>
    /// Text decoration only works in browsers with good CSS support, such as IE5 or higher, or Mozilla 1.0 or higher.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following CollapsiblePanel tag will set the Title's text-decoration style to 'none', meaning the
    /// expand/collapse link will not be underlined.
    /// <code>
    /// <![CDATA[
    /// <%@ Register TagPrefix="opgeek"
    ///     Namespace="OpinionatedGeek.Web.PowerPack"
    ///     Assembly="OpinionatedGeek.Web.PowerPack"%>
    /// ...
    ///	<opgeek:CollapsiblePanel
    ///		Text="A non-underlined title bar"
    ///		Title-Decoration="none"
    ///		runat="server">
    ///		A simple body panel.
    ///	</opgeek:CollapsiblePanel>
    /// ]]>
    ///	</code>
    /// </example>
    ///
    public class EnhancedStyle : Style
    {
        //============================================================
        // Private Data
        //============================================================

        private readonly TextDecoration _decoration = new TextDecoration ();

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the EnhancedStyle class.
        /// </summary>
        /// <remarks>
        /// Initializes a new instance of the <see cref="EnhancedStyle"/> class using default values.
        /// </remarks>
        ///
        public EnhancedStyle ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        /// <summary>
        /// A TextDecoration object that allows you to specify different text decoration attributes.
        /// </summary>
        /// <remarks>
        /// You can use this to specify, for example, whether the object's text style should have no
        /// underlining of anchors etc.
        /// </remarks>
        /// <example>
        /// <![CDATA[
        /// <...<i>tagname</i> <i>object</i>-Decoration="NONE" ...>
        /// ]]>
        /// </example>
        /// <value>The current decoration value to be applied as part of the style.</value>
        public string Decoration
        {
            get
            {
                return _decoration.ToString ();
            }
            set
            {
                _decoration.SetValue (value);

                return;
            }
        }
    }
}