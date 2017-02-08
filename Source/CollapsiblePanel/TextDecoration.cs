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
    internal class TextDecoration
    {
        //============================================================
        // Private Data
        //============================================================

        private string _currentValue;
        private bool _empty = true;

        //============================================================
        // Constructors
        //============================================================

        //============================================================
        // Properties
        //============================================================

        //============================================================
        // Methods
        //============================================================

        public void SetValue (string newValue)
        {
            string normalisedNewValue = newValue.ToLower (Globalisation.GetCultureInfo ());
            switch (normalisedNewValue)
            {
                case "none":
                    _currentValue = "none";
                    _empty = false;
                    break;

                case "underline":
                    _currentValue = "underline";
                    _empty = false;
                    break;

                case "overline":
                    _currentValue = "overline";
                    _empty = false;
                    break;

                case "linethrough":
                case "line-through":
                    _currentValue = "line-through";
                    _empty = false;
                    break;

                case "blink":
                    _currentValue = "blink";
                    _empty = false;
                    break;

                default:
                    _currentValue = "";
                    _empty = true;
                    break;
            }

            return;
        }

        public override string ToString ()
        {
            string value = "";
            if (!_empty)
            {
                value = _currentValue;
            }

            return value;
        }
    }
}