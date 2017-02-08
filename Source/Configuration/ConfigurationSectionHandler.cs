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
using System.Configuration;
using System.Xml;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A custom configuration-section handler which allows for some more interesting configuration options.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> Not applicable.
    /// </p>
    /// </summary>
    /// <remarks>
    /// By using a custom handler for configuration section, two 'twists' on regular configuration are possible.
    ///	<list type="number">
    ///		<item>Values can be specified in the body of the 'add' tag, rather than in the 'value' attribute.  This
    ///		can be very useful when trying to put, say, HTML inside the configuration (for configurable HTML emails
    ///		etc.)  So, for example, you could specify the configuration option 'SomeEmailMessage' as:
    ///		<code>
    ///		&lt;add name="SomeEmailMessage"&gt;
    ///		&lt;![CDATA[
    ///		&lt;blockquote&gt;
    ///			Here's a simple email message with a nice
    ///			&lt;a href='http://www.opinionatedgeek.com'&gt;link&lt;/a&gt;.
    ///		&lt;/blockquote&gt;
    ///		]]&gt;
    ///		&lt;/add&gt;
    ///		</code>
    ///		</item>
    ///		<item>Values can be 'compounded' instead of having new values replace old values.  For instance, this is
    ///		used by the License configuration to allow multiple licenses to be used at the same time.  Multiple values
    ///		can be specified as:
    ///		<code>
    ///		&lt;add name="License" value="Value1"/&gt;
    ///		&lt;add name="License" value="Value2"/&gt;
    ///		&lt;add name="License" value="Value3"/&gt;
    ///		</code>
    ///		When accessed through the <see cref="PowerPackConfigurationSection"/>'s
    ///		<see cref="PowerPackConfigurationSection.GetCompoundValue"/> method, all three values are returned in
    ///		a string array.  Access through the normal NameValueSectionHandler returns just the last specified value,
    ///		which is the normal behaviour.
    ///		</item>
    /// </list>
    /// Overall though, you probably don't need to use this handler in your own code.
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b>
    /// Not applicable.
    /// </p>
    /// <seealso cref="PowerPackConfigurationSection"/>
    /// </remarks>
    ///
    public class ConfigurationSectionHandler : IConfigurationSectionHandler
    {
        //============================================================
        // Private Data
        //============================================================

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSectionHandler"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="ConfigurationSectionHandler"/> class.
        /// This default constructor initializes all fields to their default values.
        /// <p class="i1">
        /// This constructor is <b>never</b> normally called through user code.  Instead this class is usually
        /// instantiated via the configuration subsystem when this class is specified as a section handler in
        /// the configuration file.
        /// </p>
        /// </remarks>
        /// <example>
        /// This class is specified as a configuration section handler in a configuration file as follows:
        /// <code>
        ///	&lt;configuration&gt;
        ///		&lt;configSections&gt;
        ///			&lt;section name="MyConfiguration" type="OpinionatedGeek.Web.PowerPack.ConfigurationSectionHandler,OpinionatedGeek.Web.PowerPack" /&gt;
        ///		&lt;/configSections&gt;
        ///		...
        /// </code>
        /// </example>
        ///
        public ConfigurationSectionHandler ()
        {
            return;
        }

        //============================================================
        // Methods
        //============================================================

        ///
        /// <summary>
        /// Creates a new configuration handler and adds it to the section handler collection.
        /// </summary>
        /// <remarks>
        /// Performs the regular handling of configuration sections, plus our custom handling of compound values
        /// and inner-XML values.
        /// <seealso cref="PowerPackConfigurationSection"/>
        /// </remarks>
        /// <param name="parent">The configuration settings in a corresponding parent configuration section.</param>
        /// <param name="configContext">The virtual path for which the configuration section handler computes
        /// configuration values. Normally this parameter is reserved and is a null reference (<b>Nothing</b>
        /// in Visual Basic).</param>
        /// <param name="section">The <see cref="XmlNode"/> that contains the configuration information to be
        /// handled. Provides direct access to the XML contents of the configuration section.</param>
        /// <returns>A <see cref="PowerPackConfigurationSection"/>.</returns>
        ///
        public object Create (object parent, object configContext, XmlNode section)
        {
            if (section == null)
            {
                throw new ArgumentNullException ("section", Globalisation.GetString ("argumentCannotBeNull"));
            }

            PowerPackConfigurationSection settings = parent == null ? new PowerPackConfigurationSection () : new PowerPackConfigurationSection ((NameValueCollection) parent);

            foreach (XmlNode node in section.ChildNodes)
            {
                string key;
                if (node.Name == "add")
                {
                    key = GetKey (node);
                    string value = GetValue (node);
                    settings.Add (key, value);
                }
                else if (node.Name == "remove")
                {
                    key = GetKey (node);
                    settings.Remove (key);
                }
                else if (node.Name == "clear")
                {
                    settings.Clear ();
                }
            }

            return settings;
        }

        private static string GetKey (XmlNode configurationNode)
        {
            string key = GetAttribute (configurationNode, "key");
            if (String.IsNullOrEmpty (key))
            {
                throw new ConfigurationErrorsException ("Required attribute 'key' not found.");
            }

            return key;
        }

        private static string GetValue (XmlNode configurationNode)
        {
            string value = GetAttribute (configurationNode, "value") ?? configurationNode.InnerText;

            return value;
        }

        private static string GetAttribute (XmlNode configurationNode, string name)
        {
            string value = null;
            if (configurationNode.NodeType == XmlNodeType.Element)
            {
                XmlAttribute xaAttribute = configurationNode.Attributes [name];
                value = (xaAttribute != null ? xaAttribute.Value : null);
            }

            return value;
        }
    }
}