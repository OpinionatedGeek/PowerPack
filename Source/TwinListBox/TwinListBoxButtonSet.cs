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
    /// A simple way of gathering all the buttons used in the TwinListBox.
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
    public class TwinListBoxButtonSet
    {
        //============================================================
        // Private Data
        //============================================================

        private readonly Button[] _allButtons;

        //============================================================
        // Constructors
        //============================================================

        internal TwinListBoxButtonSet (Button addSelected, Button addAll, Button removeSelected, Button removeAll)
        {
            _allButtons = new Button[4];
            _allButtons [0] = addSelected;
            _allButtons [1] = addAll;
            _allButtons [2] = removeSelected;
            _allButtons [3] = removeAll;

            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets the AddSelected button used by the TwinListBox.
        /// </summary>
        /// <remarks>
        /// Gets the button control that will be used as the AddSelected button in the TwinListBox.
        /// This allows you to set its Text property and alter its appearance.
        /// </remarks>
        /// <value>The Button that will be used.</value>
        ///
        public Button AddSelected
        {
            get
            {
                return _allButtons [0];
            }
        }

        ///
        /// <summary>
        /// Gets the AddAll button used by the TwinListBox.
        /// </summary>
        /// <remarks>
        /// Gets the button control that will be used as the AddAll button in the TwinListBox.
        /// This allows you to set its Text property and alter its appearance.
        /// </remarks>
        /// <value>The Button that will be used.</value>
        ///
        public Button AddAll
        {
            get
            {
                return _allButtons [1];
            }
        }

        ///
        /// <summary>
        /// Gets the RemoveSelected button used by the TwinListBox.
        /// </summary>
        /// <remarks>
        /// Gets the button control that will be used as the RemoveSelected button in the TwinListBox.
        /// This allows you to set its Text property and alter its appearance.
        /// </remarks>
        /// <value>The Button that will be used.</value>
        ///
        public Button RemoveSelected
        {
            get
            {
                return _allButtons [2];
            }
        }

        ///
        /// <summary>
        /// Gets the RemoveAll button used by the TwinListBox.
        /// </summary>
        /// <remarks>
        /// Gets the button control that will be used as the RemoveAll button in the TwinListBox.
        /// This allows you to set its Text property and alter its appearance.
        /// </remarks>
        /// <value>The Button that will be used.</value>
        ///
        public Button RemoveAll
        {
            get
            {
                return _allButtons [3];
            }
        }

        //============================================================
        // Methods
        //============================================================
    }
}