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
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// Ignored
    /// </summary>
    ///
    internal class SwearFilterConfiguration
    {
        //============================================================
        // Private Data
        //============================================================

        private const string MainEncosingTagName = "SwearFilterConfiguration";
        private const string BlockedWordsEnclosingTagName = "BlockedWords";
        private const string BlockedWordTagName = "Word";
        private const string ReplacementTagName = "Replacement";

        private readonly char[] _invalidCharacters = new [] {'\'', '"', '\n', '\r'};
        private Collection<BlockedWord> _blockedWords;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Ignored
        /// </summary>
        ///
        public SwearFilterConfiguration ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Ignored
        /// </summary>
        ///
        public Collection<BlockedWord> BlockedWords
        {
            get
            {
                return _blockedWords;
            }
        }

        //============================================================
        // Static Methods
        //============================================================

        internal static SwearFilterConfiguration LoadConfiguration (string configFilename)
        {
            SwearFilterConfiguration blockedWords = null;
            FileStream blockedList = null;

            try
            {
                blockedList = File.Open (configFilename, FileMode.Open, FileAccess.Read);
                var configDoc = new XmlDocument ();
                configDoc.Load (blockedList);

                XmlElement configuration = configDoc [MainEncosingTagName];
                if (configuration != null)
                {
                    XmlElement blockedWordsElement = configuration [BlockedWordsEnclosingTagName];
                    if (blockedWordsElement != null)
                    {
                        var allBlockedWords = new Collection<BlockedWord> ();
                        foreach (XmlElement blockedWordElement in blockedWordsElement.ChildNodes)
                        {
                            string word = null;
                            var blockedWordTag = blockedWordElement [BlockedWordTagName];
                            if (blockedWordTag != null)
                            {
                                word = blockedWordTag.InnerText;
                            }

                            string replacement = null;
                            var blockedWordReplacement = blockedWordElement [ReplacementTagName];
                            if (blockedWordReplacement != null)
                            {
                                replacement = blockedWordReplacement.InnerText;
                            }

                            var blockedWord = new BlockedWord { Word = word, Replacement = replacement };
                            if (blockedWord.Word != null)
                            {
                                allBlockedWords.Add (blockedWord);
                            }
                        }

                        blockedWords = new SwearFilterConfiguration {_blockedWords = allBlockedWords};
                        blockedWords.Validate ();
                    }
                }
            }
            finally
            {
                if (blockedList != null)
                {
                    blockedList.Close ();
                }
            }

            return blockedWords;
        }

        //============================================================
        // Methods
        //============================================================

        ///
        /// <summary>
        /// Ignored
        /// </summary>
        ///
        public string GetReplacement (string filteredWord)
        {
            int listLength = _blockedWords.Count;
            bool found = false;
            bool replaced = false;
            string replacement = "";
            for (int wordCounter = 0; ((!found) && (wordCounter < listLength)); wordCounter++)
            {
                if (filteredWord.ToUpper (Globalisation.GetCultureInfo ()) == _blockedWords [wordCounter].Word.ToUpper (Globalisation.GetCultureInfo ()))
                {
                    found = true;
                    if (_blockedWords [wordCounter].Replacement != null)
                    {
                        replacement = _blockedWords [wordCounter].Replacement;
                        replaced = true;
                    }
                }
            }

            if (!replaced)
            {
                replacement = replacement.PadRight (filteredWord.Length, '*');
            }

            return replacement;
        }

        ///
        /// <summary>
        /// Ignored
        /// </summary>
        ///
        public bool Validate ()
        {
            foreach (BlockedWord word in BlockedWords)
            {
                if ((word.Replacement != null) && (word.Replacement.IndexOfAny (_invalidCharacters) >= 0))
                {
                    throw new FormatException ("Replacements for a blocked words cannot contain single quotes, double quotes, newlines, or carriage returns.");
                }
            }

            return true;
        }
    }
}