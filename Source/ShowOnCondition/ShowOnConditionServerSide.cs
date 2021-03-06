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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpinionatedGeek.Web.PowerPack.Licensing;
using License=System.ComponentModel.License;

namespace OpinionatedGeek.Web.PowerPack
{
    ///
    /// <summary>
    /// A postback version of the <see cref="ShowOnCondition"/> control which allows hiding or showing of form
    /// elements based on other controls.  This control requires no dynamic HTML.
    /// <p class="i1" style="color: #0206A6">
    /// <b>Browser Requirements:</b> None.
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
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Browser Notes:</b>
    /// This facility is available to all browsers.
    /// </p>
    /// </remarks>
    /// <example>
    /// The following code declares the tag for use on the page via the Register directive, and then puts
    /// a ShowOnConditionClientSide control on the page, linked to a dropdown of Titles and a TextBox.  The TextBox
    /// is hidden if one of 'Mr.', 'Miss.', 'Mrs.' or 'Mz.' is selected, and shown if 'Other' is selected.
    /// <code>
    /// <![CDATA[
    /// <%@ Register TagPrefix="opgeek"
    ///		Namespace="OpinionatedGeek.Web.PowerPack"
    ///		Assembly="OpinionatedGeek.Web.PowerPack"%>
    /// ...
    /// <asp:DropDownList Runat="server" ID="rbTitles">
    ///		<asp:ListItem Value="Mr."/>
    ///		<asp:ListItem Value="Miss."/>
    ///		<asp:ListItem Value="Mrs."/>
    ///		<asp:ListItem Value="Mz."/>
    ///		<asp:ListItem Value="Other"/>
    /// </asp:DropDownList>
    /// <asp:TextBox Runat="server" ID="tbOther" />
    /// <opgeek:ShowOnConditionServerSide runat="server"
    ///		ControlToHide="tbOther"
    ///		ControlToTest="rbTitles"
    ///		ShowOnConditionNotValue="Other"/>
    ///	<asp:Button Runat="server" text="Postback"/>
    /// ]]>
    /// </code>
    /// <p class="i1">
    /// The TextBox will be hidden or shown after a postback, depending on the value of the dropdown list.  Note
    /// that unlike the <see cref="ShowOnConditionClientSide"/> control, the ShowOnConditionServerSide control requires a postback to take
    /// effect.
    /// </p>
    /// <p class="i1" style="color: #0206A6; background-color: #FFFFCC; padding: 0.5em 1em 0.5em 1em; border-width: 1px; border-style: solid; border-color: #999999;">
    /// <b>Live demo!</b> Click <a target="_new"
    /// href="http://www.opinionatedgeek.com/DotNet/Products/PowerPack/Examples/ShowOnConditionServerSide.aspx">here</a>
    /// for a live demonstration of the control.
    /// </p>
    /// </example>
    /// <seealso cref="ShowOnCondition"/>
    /// <seealso cref="ShowOnConditionClientSide"/>
    ///
    [DefaultProperty ("ShowOnConditionValue")]
    [ToolboxData ("<{0}:ShowOnConditionServerSide runat=server></{0}:ShowOnConditionServerSide>")]
    [ToolboxBitmap (typeof (RequiredFieldValidator))]
    [LicenseProvider (typeof (ShowOnConditionServerSideLicenseProvider))]
    public class ShowOnConditionServerSide : ShowOnCondition
    {
        //============================================================
        // Private Data
        //============================================================

        new internal const string ProductName = "ShowOnConditionServerSide";

        private License _license;

        //============================================================
        // Constructors
        //============================================================

        ///
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowOnConditionServerSide"/> class.
        /// </summary>
        /// <remarks>
        /// Use this constructor to create and initialize a new instance of the <see cref="ShowOnConditionServerSide"/> class.
        /// This default constructor initializes all fields to their default values.
        /// </remarks>
        ///
        public ShowOnConditionServerSide ()
        {
            _license = LicenseManager.Validate (typeof (ShowOnConditionServerSide), this);

            return;
        }

        //============================================================
        // Properties
        //============================================================

        //============================================================
        // Events
        //============================================================

        ///
        /// <summary>
        /// Makes final decision on whether to hide the desired control or not.
        /// </summary>
        /// <remarks>
        /// This is where the final decision is taken on whether to hide the desired control or not.  If the value
        /// of the tested control equals the ShowOnConditionValue (if specified), or does not equal the ShowOnConditionNotValue
        /// (if it is specified and ShowOnConditionValue isn't), then the control identified via ControlToHide has its
        /// visibility set to 'false'.
        /// Note for inheritors - for this control to function properly, any derived controls that override
        /// this method should ensure that they call this base method as part of their OnPreRender.
        /// </remarks>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        ///
        protected override void OnPreRender (EventArgs e)
        {
            base.OnPreRender (e);

            Control controlToTest = FindControl (ControlToTest);
            Control controlToHide = FindControl (ControlToHide);
            string value = GetValue (controlToTest);
            if (Enabled)
            {
                if (ShowOnConditionValue != null)
                {
                    if (value == ShowOnConditionValue)
                    {
                        HideControl (controlToHide);
                    }
                    else
                    {
                        UnhideControl (controlToHide);
                    }
                }
                else if (ShowOnConditionNotValue != null)
                {
                    if (value != ShowOnConditionNotValue)
                    {
                        HideControl (controlToHide);
                    }
                    else
                    {
                        UnhideControl (controlToHide);
                    }
                }
            }

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

            if (Page != null)
            {
                Page.VerifyRenderingInServerForm (this);
            }

            base.Render (realWriter);

            return;
        }

        //============================================================
        // Methods
        //============================================================

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

        private void HideControl (Control controlToHide)
        {
            controlToHide.Visible = false;
            ViewState ["WeHidControl"] = true;

            return;
        }

        private void UnhideControl (Control controlToHide)
        {
            object didWeHideControlObject = ViewState ["WeHidControl"];
            bool didWeHideControl = false;
            if (didWeHideControlObject != null)
            {
                didWeHideControl = (bool) didWeHideControlObject;
            }

            if (didWeHideControl)
            {
                controlToHide.Visible = true;
            }

            return;
        }

        private static string GetValue (Control ctlControlToDereference)
        {
            string value = "";
            var listControl = ctlControlToDereference as ListControl;
            var checkBox = ctlControlToDereference as CheckBox;
            var textBox = ctlControlToDereference as System.Web.UI.WebControls.TextBox;

            if (checkBox != null)
            {
                value = checkBox.Text;
            }
            else if (listControl != null)
            {
                if (listControl.SelectedItem != null)
                {
                    value = listControl.SelectedItem.Value;
                }
            }
            else
            {
                value = textBox != null ? textBox.Text : ctlControlToDereference.ToString ();
            }

            return value;
        }
    }
}