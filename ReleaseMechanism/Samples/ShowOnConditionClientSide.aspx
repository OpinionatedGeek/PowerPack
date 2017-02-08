<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A DHTML way of hiding/showing content!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack ShowOnConditionClientSide Control
	</h2>
	
	<p>
		This control allows you to show or hide page controls under different conditions.
	</p>
	<p>
		The text following each of the three field elements changes immediately if certain values
		are given to the elements.
	</p>
	<p>
		<asp:RadioButtonList Runat="server" ID="rb2">
			<asp:ListItem Value="value1"/>
			<asp:ListItem Value="value2"/>
			<asp:ListItem Value="value3"/>
			<asp:ListItem Value="value4"/>
		</asp:RadioButtonList>
	</p>
		<blockquote>
			<asp:Panel Runat=server ID="pan1rb2">
				This text is <b>hidden</b> when 'value3' is selected.
			</asp:Panel>
			<asp:Panel Runat=server ID="pan2rb2">
				<font color="darkblue">This text is <b>shown</b> when 'value3' is selected.</font>
			</asp:Panel>
			<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan1rb2" ControlToTest="rb2" ShowOnConditionValue="value3" ID="Showonconditionclientside1" NAME="Showonconditionclientside1"/>
			<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan2rb2" ControlToTest="rb2" ShowOnConditionNotValue="value3" ID="Showonconditionclientside2" NAME="Showonconditionclientside2"/>
		</blockquote>
	<p>
		<asp:DropDownList Runat="server" ID="dd2">
			<asp:ListItem Value="value1"/>
			<asp:ListItem Value="value2"/>
			<asp:ListItem Value="value3"/>
			<asp:ListItem Value="value4"/>
		</asp:DropDownList>
	</p>
		<blockquote>
			<asp:Panel Runat=server ID="pan1DD2">
				This text is <b>hidden</b> when 'value3' is selected.
			</asp:Panel>
			<asp:Panel Runat=server ID="pan2DD2">
				<font color="darkblue">This text is <b>shown</b> when 'value3' is selected.</font>
			</asp:Panel>
			<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan1DD2" ControlToTest="dd2" ShowOnConditionValue="value3" ID="Showonconditionclientside3" NAME="Showonconditionclientside3"/>
			<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan2DD2" ControlToTest="dd2" ShowOnConditionNotValue="value3" ID="Showonconditionclientside4" NAME="Showonconditionclientside4"/>
		</blockquote>
	<p>
		<asp:TextBox Runat="server" ID="txt2" />
	</p>
		<blockquote>
			<asp:Panel Runat=server ID="pan1txt2">
				This text is <b>hidden</b> when 'widget' is entered.
			</asp:Panel>
			<asp:Panel Runat=server ID="pan2txt2">
				<font color="darkblue">This text is <b>shown</b> when 'widget' is entered.</font>
			</asp:Panel>
			<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan1txt2" ControlToTest="txt2" ShowOnConditionValue="widget" ID="Showonconditionclientside5" NAME="Showonconditionclientside5"/>
			<opgeek:ShowOnConditionClientSide runat="server" ControlToHide="pan2txt2" ControlToTest="txt2" ShowOnConditionNotValue="widget" ID="Showonconditionclientside6" NAME="Showonconditionclientside6"/>
		</blockquote>
</asp:content>
