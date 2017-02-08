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

using System.Collections;
using System.Collections.Specialized;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// Represents a collection of configuration file string keys and string values.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> Not applicable.
    /// </p>
    /// </summary>
    /// <remarks>
    /// Represents a collection of configuration file string keys and string values.  In addition to the normal
    /// key-value pairing, compound values can be retrieved through the <see cref="GetCompoundValue"/> method.
    /// <p class="i1">
    /// This class is never normally instantiated in user code.  Instead it is more usually created and returned
    /// by the <see cref="ConfigurationSectionHandler"/> class as part of the configuration file processing.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b>
    /// Not applicable.
    /// </p>
    /// <seealso cref="ConfigurationSectionHandler"/>
    /// </remarks>
    ///
    public class PowerPackConfigurationSection
    {
        //============================================================
        // Private Data
        //============================================================

        private readonly Hashtable _compoundValues = new Hashtable ();
        private readonly NameValueCollection _nameValues = new NameValueCollection ();

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="PowerPackConfigurationSection"/> class that is empty, has
        /// the default initial capacity and uses the default case-insensitive hash code provider and the default
        /// case-insensitive comparer.
        /// </summary>
        /// <remarks>
        /// The capacity is the number of key-and-value pairs that the <see cref="PowerPackConfigurationSection"/>
        /// can contain. The default initial capacity is zero. The capacity is automatically increased as required.
        /// </remarks>
        ///
        public PowerPackConfigurationSection ()
        {
            return;
        }

        ///
        /// <summary>
        /// Copies the entries from the specified <see cref="NameValueCollection"/> to a new
        /// <see cref="PowerPackConfigurationSection"/> with the same initial capacity as the number of entries
        /// copied and using the same hash code provider and the same comparer as the source collection.
        /// </summary>
        /// <remarks>
        /// The capacity is the number of key-and-value pairs that the <see cref="PowerPackConfigurationSection"/>
        /// can contain. The default initial capacity is zero. The capacity is automatically increased as required.
        /// <p class="i1">
        /// The elements of the new <see cref="PowerPackConfigurationSection"/> are sorted in the same order as the
        /// source <see cref="NameValueCollection"/>.
        /// </p>
        /// </remarks>
        /// <param name="collection">The <see cref="NameValueCollection"/> to copy to the new
        /// <see cref="PowerPackConfigurationSection"/> instance.</param>
        ///
        public PowerPackConfigurationSection (NameValueCollection collection)
        {
            _nameValues.Add (collection);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets the entry with the specified key in the <see cref="PowerPackConfigurationSection"/>.
        /// </summary>
        /// <remarks>
        /// This property provides the ability to access a specific element in the
        /// <see cref="PowerPackConfigurationSection"/> by using the following syntax: myCollection [name].
        /// </remarks>
        /// <param name="name">The <see cref="System.String"/> key of the entry to locate. The key can be a null reference (Nothing in Visual Basic).</param>
        /// <returns>A <see cref="System.String"/> value associated with the specified key.</returns>
        ///
        public string this [string name]
        {
            get
            {
                return _nameValues [name];
            }
        }

        //============================================================
        // Methods
        //============================================================

        ///
        /// <summary>
        /// Adds entries to the current <see cref="PowerPackConfigurationSection"/>.
        /// </summary>
        /// <remarks>
        /// If the specified key already exists in the target <see cref="PowerPackConfigurationSection"/> instance,
        /// the specified value is added to the existing comma-separated list of values associated with the same key
        /// in the target <see cref="PowerPackConfigurationSection"/> instance.
        /// <p class="i1">
        /// If the same value already exists under the same key in the collection, the new value overwrites the old
        /// value.
        /// </p>
        /// </remarks>
        /// <param name="name">The key of the entry to add. The key can be a null reference.</param>
        /// <param name="value">The value of the entry to add. The value can be a null reference.</param>
        ///
        public void Add (string name, string value)
        {
            _nameValues[name] = value;

            if (name != null)
            {
                if (value != null)
                {
                    AddCompound (name, value);
                }
            }

            return;
        }

        ///
        /// <summary>
        /// Removes the entries with the specified key from the <see cref="PowerPackConfigurationSection"/> instance.
        /// </summary>
        /// <remarks>
        /// In collections of contiguous elements, such as lists, fthe elements that follow the removed element
        /// move up to occupy the vacated spot. If the collection is indexed, the indexes of the elements that
        /// are moved are also updated. This behavior does not apply to collections where elements are conceptually
        /// grouped into buckets, such as a hashtable.
        /// </remarks>
        /// <param name="name">The key of the entry to remove. The key can be a null reference.</param>
        ///
        public void Remove (string name)
        {
            if (name != null)
            {
                _compoundValues.Remove (name);
            }

            return;
        }

        ///
        /// <summary>
        /// Invalidates the cached arrays and removes all entries from the <see cref="PowerPackConfigurationSection"/>.
        /// </summary>
        /// <remarks>
        /// Invalidates the cached arrays and removes all entries from the <see cref="PowerPackConfigurationSection"/>.
        /// </remarks>
        ///
        public void Clear ()
        {
            _compoundValues.Clear ();

            return;
        }

        ///
        /// <summary>
        /// Retrieves all the values that have been specified for that key, as an array of strings.
        /// </summary>
        /// <remarks>
        /// When keys have been specified more than once in a configuration file, this method will return
        /// all values in an array of strings.
        /// </remarks>
        /// <example>
        /// When configuration items have been specified more than once as follows:
        ///		<code>
        ///		&lt;add name="License" value="Value1"/&gt;
        ///		&lt;add name="License" value="Value2"/&gt;
        ///		&lt;add name="License" value="Value3"/&gt;
        ///		</code>
        ///	A call to GetCompoundValue will return an array of strings equivalent to:
        ///	<code>
        ///	{"Value1", "Value2", "Value3"}
        ///	</code>
        /// </example>
        /// <param name="name">The key of the entry to retrieve. The key can be a null reference.</param>
        /// <returns>All set values of the key, each as its own element in an array of strings.</returns>
        ///
        public string[] GetCompoundValue (string name)
        {
            string[] valueStrings = null;
            var values = (ArrayList) _compoundValues [name];
            if (values == null)
            {
                string ordinaryValue = this [name];
                if (ordinaryValue != null)
                {
                    valueStrings = new [] {ordinaryValue};
                }
            }
            else
            {
                valueStrings = new string[values.Count];
                values.CopyTo (valueStrings);
            }

            return valueStrings;
        }

        ///
        /// <summary>
        /// Determines whether a compound value has been specified for a given key.
        /// </summary>
        /// <remarks>
        /// This method allows you to check if keys have been specified more than once in
        /// a configuration file.
        /// </remarks>
        /// <example>
        /// When configuration items have been specified more than once as follows:
        ///		<code>
        ///		&lt;add name="License" value="Value1"/&gt;
        ///		&lt;add name="License" value="Value2"/&gt;
        ///		&lt;add name="License" value="Value3"/&gt;
        ///		</code>
        ///	A call to HasCompoundValue will return true:
        /// </example>
        /// <param name="name">The key of the entry to check.</param>
        /// <returns>True if the key has a compound value, false if the key has zero or one values.</returns>
        ///
        public bool HasCompoundValue (string name)
        {
            return _compoundValues [name] != null;
        }

        private void AddCompound (string name, string value)
        {
            if (_compoundValues [name] == null)
            {
                var values = new ArrayList {value};
                _compoundValues [name] = values;
            }
            else
            {
                var values = (ArrayList) _compoundValues [name];
                values.Add (value);
            }

            return;
        }
    }
}