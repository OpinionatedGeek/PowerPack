<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A pure HTML way of hiding/showing content!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack ShowOnConditionServerSide Control
	</h2>
	
	<p>
		This control allows you to show or hide page controls under different conditions.
	</p>
	<p>
		The text following each of the three field elements changes after postback if certain values
		are given to the elements.
	</p>
	<p>
		<asp:RadioButtonList Runat="server" ID="rb1">
			<asp:ListItem Value="value1"/>
			<asp:ListItem Value="value2"/>
			<asp:ListItem Value="value3"/>
			<asp:ListItem Value="value4"/>
		</asp:RadioButtonList>
	</p>
	<blockquote>
		<asp:Panel Runat=server ID="pan1rb1">
			This text is <b>hidden</b> after a postback when 'value3' is selected.
		</asp:Panel>
		<asp:Panel Runat=server ID="pan2rb1">
			<font color="darkblue">This text is <b>shown</b> after a postback when 'value3' is selected.</font>
		</asp:Panel>
		<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan1rb1" ControlToTest="rb1" ShowOnConditionValue="value3" debug="true" ID="Showonconditionserverside1" NAME="Showonconditionserverside1"/>
		<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan2rb1" ControlToTest="rb1" ShowOnConditionNotValue="value3" debug="true" ID="Showonconditionserverside2" NAME="Showonconditionserverside2"/>
	</blockquote>
	<p>
		<asp:DropDownList Runat="server" ID="dd1">
			<asp:ListItem Value="value1"/>
			<asp:ListItem Value="value2"/>
			<asp:ListItem Value="value3"/>
			<asp:ListItem Value="value4"/>
		</asp:DropDownList>
	</p>
	<blockquote>
		<asp:Panel Runat=server ID="pan1DD1">
			This text is <b>hidden</b> after a postback when 'value3' is selected.
		</asp:Panel>
		<asp:Panel Runat=server ID="pan2DD1">
			<font color="darkblue">This text is <b>shown</b> after a postback when 'value3' is selected.</font>
		</asp:Panel>
		<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan1DD1" ControlToTest="dd1" ShowOnConditionValue="value3" ID="Showonconditionserverside3" NAME="Showonconditionserverside3"/>
		<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan2DD1" ControlToTest="dd1" ShowOnConditionNotValue="value3" ID="Showonconditionserverside4" NAME="Showonconditionserverside4"/>
	</blockquote>
	<p>
		<asp:TextBox Runat="server" ID="txt1" />
	</p>
	<blockquote>
		<asp:Panel Runat=server ID="pan1Txt1">
			This text is <b>hidden</b> after a postback when 'widget' is entered.
		</asp:Panel>
		<asp:Panel Runat=server ID="pan2Txt1">
			<font color="darkblue">This text is <b>shown</b> after a postback when 'widget' is entered.</font>
		</asp:Panel>
		<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan1Txt1" ControlToTest="txt1" ShowOnConditionValue="widget" ID="Showonconditionserverside5" NAME="Showonconditionserverside5"/>
		<opgeek:ShowOnConditionServerSide runat="server" ControlToHide="pan2Txt1" ControlToTest="txt1" ShowOnConditionNotValue="widget" ID="Showonconditionserverside6" NAME="Showonconditionserverside6"/>
	</blockquote>

	<asp:Button Runat="server" text="PostBack" ID="butPost"/>
	
	<p>
	(<b>Note:</b> Compare this behavious with the Dynamic HTML version of the control,
	<a href="ShowOnConditionClientSide.aspx">ShowOnConditionClientSide</a>.)
	</p>
</asp:content>