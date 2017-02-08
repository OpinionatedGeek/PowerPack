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
using System.Web.UI.WebControls;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A tag-based system to allow hiding or showing of form elements based on other controls.  This is an
    /// <b>abstract base class</b> - see <see cref="ShowOnConditionClientSide"/> and
    /// <see cref="ShowOnConditionServerSide"/> for concrete implementations.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> Not applicable.
    /// </p>
    /// </summary>
    /// <remarks>
    /// <p class="i1">
    /// Sometimes you want to hide elements on a form based on the values of other form elements.  Say you wanted
    /// to have a dropdown field for 'Title', which contained 'Mr.', 'Miss.', 'Mrs.' and 'Mz.'  But what if the
    /// person was a Doctor and preferred the title 'Dr.'?  The normal way of doing this in a form is to have
    /// a final option on the dropdown, 'Other', which allows the person to enter their title in a text field
    /// beside the dropdown.  Unfortunately, having an empty Other field on the form all the time is ugly and
    /// has usability problems - problems the ShowOnCondition control is designed to solve!
    /// </p>
    /// <p class="i1">
    /// Adding a ShowOnCondition control to the page allows you to specify a control to be hidden under certain conditions,
    /// as well as detailing what those conditions are.  In this case, you would add the ShowOnCondition control to the page
    /// and tell it to hide the text field if the value of the DropDown was not 'Other'.  That way the control would
    /// be shown if 'Other' was selected, and hidden if any different value was selected.
    /// </p>
    /// <p class="i1">
    /// <b>Important!</b>  Both <see cref="ShowOnConditionClientSide"/> and <see cref="ShowOnConditionServerSide"/> perform the same job,
    /// hiding and showing form elements based on other controls.  When deciding which to use, bear the following
    /// in mind:
    /// <list type="bullet">
    /// <item><see cref="ShowOnConditionServerSide"/> will work on all browsers.</item>
    /// <item><see cref="ShowOnConditionServerSide"/> requires a postback to change what is hidden or shown.</item>
    /// <item><see cref="ShowOnConditionClientSide"/> requires a browser capable of dynamic HTML (such as Internet Explorer 5 or higher).</item>
    /// </list>
    /// </p>
    /// <p class="i1">
    /// It is also possible that, like the ASP.NET validators, you may need to chain two or more ShowOnCondition controls
    /// together to achieve the desired effect.  For instance, it may be appropriate on your form to apply both
    /// a <see cref="ShowOnConditionClientSide"/> and a <see cref="ShowOnConditionServerSide"/> to the same control, using the same criteria.
    /// This would ensure that the parts you want to hide are hidden in all browsers, but that the hiding has a more
    /// immediate effect in newer browsers.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b>
    /// Not applicable.
    /// </p>
    /// <seealso cref="ShowOnConditionClientSide"/>
    /// <seealso cref="ShowOnConditionServerSide"/>
    /// </remarks>
    /// <example>
    /// The ShowOnCondition control cannot be used directly.  Usable derived classes are <see cref="ShowOnConditionClientSide"/>
    /// and <see cref="ShowOnConditionServerSide"/>.
    /// </example>
    ///
    [Designer (typeof (AutomaticDesigner))]
    public abstract class ShowOnCondition : WebControl
    {
        //============================================================
        // Private Data
        //============================================================

        internal const string ProductName = "ShowOnCondition";

        private string _controlToHide;
        private string _controlToTest;
        private string _showOnConditionValue;
        private string _showOnConditionNotValue;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowOnCondition"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="ShowOnCondition"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        protected ShowOnCondition ()
        {
            return;
        }

        //============================================================
        // Properties
        //============================================================

        ///
        /// <summary>
        /// Gets or sets the ID of the control to hide under specific conditions.
        /// </summary>
        /// <remarks>
        /// Gets or sets the ID of the control to hide.  This must be the control's ID as far as the Page is
        /// concerned, not the UniqueId or the ClientId.  If the control cannot be found within the same
        /// naming container via a call to FindControl (), an exception is thrown at runtime.
        /// </remarks>
        /// <value>The ID of the control to hide.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance")]
        [Description (@"The ID of the control to hide.")]
        public string ControlToHide
        {
            get
            {
                return _controlToHide;
            }
            set
            {
                _controlToHide = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the ID of the control whose value should be tested.
        /// </summary>
        /// <remarks>
        /// Gets or sets the ID of the control whose value should be tested.  This must be the control's ID
        /// as far as the Page is concerned, not the UniqueId or the ClientId.  If the control cannot be found
        /// within the same naming container via a call to FindControl (), an exception is thrown at runtime.
        /// </remarks>
        /// <value>The ID of the control to test.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance")]
        [Description (@"The ID of the control to test.")]
        public string ControlToTest
        {
            get
            {
                return _controlToTest;
            }
            set
            {
                _controlToTest = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the value to test with.
        /// </summary>
        /// <remarks>
        /// Gets or sets the value to test against.  If the control specified via ControlToTest has this
        /// value, it will be hidden.
        /// </remarks>
        /// <value>The value to be used when testing the control specified in ControlToTest.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance")]
        [Description (@"The value to be used when testing the control specified in ControlToTest.")]
        public string ShowOnConditionValue
        {
            get
            {
                return _showOnConditionValue;
            }
            set
            {
                _showOnConditionValue = value;

                return;
            }
        }

        ///
        /// <summary>
        /// Gets or sets the value to test with.
        /// </summary>
        /// <remarks>
        /// Gets or sets the value to test against.  If the control specified via ControlToTest has <b>not</b>
        /// been set to this value, it will be hidden.
        /// </remarks>
        /// <value>The value to be used when testing the control specified in ControlToTest.</value>
        ///
        [Bindable (true), Browsable (true), Category ("Appearance")]
        [Description (@"The value to be used when testing the control specified in ControlToTest.")]
        public string ShowOnConditionNotValue
        {
            get
            {
                return _showOnConditionNotValue;
            }
            set
            {
                _showOnConditionNotValue = value;

                return;
            }
        }

        //============================================================
        // Events
        //============================================================

        ///
        /// <summary>
        /// Initialises the control.
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

            if (!DesignMode)
            {
                if (FindControl (ControlToHide) == null)
                {
                    throw new InvalidOperationException (Globalisation.GetString ("controlWithIdCouldNotBeFound_Id", ControlToHide));
                }

                if (FindControl (ControlToTest) == null)
                {
                    throw new InvalidOperationException (Globalisation.GetString ("controlWithIdCouldNotBeFound_Id", ControlToTest));
                }
            }

            return;
        }

        //============================================================
        // Methods
        //============================================================
    }
}