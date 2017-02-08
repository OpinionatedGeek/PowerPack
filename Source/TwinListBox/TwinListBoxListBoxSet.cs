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
    /// A simple way of gathering all the ListBoxes used in the TwinListBox.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
    /// </p>
    /// </summary>
    /// <remarks>
    /// <p class="i1">
    /// It is not intended that this control be used directly, only as part of the TwinListBox.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/TwinListBox.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </remarks>
    ///
    internal class TwinListBoxListBoxSet
    {
        //============================================================
        // Private Data
        //============================================================

        private readonly TwinnableListBox[] _allListBoxes;

        //============================================================
        // Constructors
        //============================================================

        internal TwinListBoxListBoxSet (TwinnableListBox source, TwinnableListBox destination)
        {
            _allListBoxes = new TwinnableListBox[2];
            _allListBoxes [0] = source;
            _allListBoxes [1] = destination;

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets the Source TwinnableListBox used by the TwinListBox.
        /// </summary>
        /// <remarks>
        /// Gets the TwinnableListBox control that will be used as the Source button in the TwinListBox.
        /// This allows you to set its Text property and alter its appearance.
        /// </remarks>
        /// <value>The TwinnableListBox that will be used.</value>
        ///
        public TwinnableListBox Source
        {
            get
            {
                return _allListBoxes [0];
            }
        }

        ///
        /// <summary>
        /// Gets the Destination TwinnableListBox used by the TwinListBox.
        /// </summary>
        /// <remarks>
        /// Gets the TwinnableListBox control that will be used as the Destination button in the TwinListBox.
        /// This allows you to set its Text property and alter its appearance.
        /// </remarks>
        /// <value>The TwinnableListBox that will be used.</value>
        ///
        public TwinnableListBox Destination
        {
            get
            {
                return _allListBoxes [1];
            }
        }

        //============================================================
        // Methods
        //============================================================
    }
}