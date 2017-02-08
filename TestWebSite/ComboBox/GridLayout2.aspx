<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack" %>
<%@ Page Language="c#" AutoEventWireup="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Inventris - Products</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styleMenus.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:textbox id="txtNotes" style="Z-INDEX: 118; LEFT: 480px; POSITION: absolute; TOP: 200px"
				tabIndex="19" runat="server" BorderColor="LightGray" BorderWidth="3px" BorderStyle="Inset"
				Width="345px" Height="88px"></asp:textbox>
			<opgeek:ComboBox id="cboNewQuantity" style="Z-INDEX: 158; LEFT: 600px; POSITION: absolute; TOP: 576px"
				runat="server" Width="144px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cboLocation" style="Z-INDEX: 157; LEFT: 600px; POSITION: absolute; TOP: 544px"
				runat="server" Width="144px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cboQuantity" style="Z-INDEX: 156; LEFT: 192px; POSITION: absolute; TOP: 600px"
				runat="server" Width="152px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cboChildName" style="Z-INDEX: 155; LEFT: 192px; POSITION: absolute; TOP: 568px"
				runat="server" Width="152px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cboChildPart" style="Z-INDEX: 154; LEFT: 192px; POSITION: absolute; TOP: 536px"
				runat="server" Width="152px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cbo1stName" style="Z-INDEX: 153; LEFT: 600px; POSITION: absolute; TOP: 80px"
				runat="server" Width="200px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cboMinShelf" style="Z-INDEX: 151; LEFT: 224px; POSITION: absolute; TOP: 424px"
				runat="server" Width="152px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cboLeadtime" style="Z-INDEX: 150; LEFT: 224px; POSITION: absolute; TOP: 392px"
				runat="server" Width="152px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cboMultiple" style="Z-INDEX: 149; LEFT: 224px; POSITION: absolute; TOP: 360px"
				runat="server" Width="152px" Text="Pack Quantity">
				<asp:ListItem Value="Pack Quantity" Selected="True">Pack Quantity</asp:ListItem>
			</opgeek:ComboBox>
			<opgeek:ComboBox id="cboMinOrder" style="Z-INDEX: 148; LEFT: 224px; POSITION: absolute; TOP: 328px"
				runat="server" Width="152px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cboCat" style="Z-INDEX: 147; LEFT: 152px; POSITION: absolute; TOP: 232px" runat="server"
				Width="224px"></opgeek:ComboBox>
			<opgeek:ComboBox id="cboName" style="Z-INDEX: 146; LEFT: 152px; POSITION: absolute; TOP: 112px" runat="server"
				Width="224px"></opgeek:ComboBox><asp:button id="btnPrintItems" style="Z-INDEX: 140; LEFT: 440px; POSITION: absolute; TOP: 632px"
				tabIndex="24" runat="server" Width="97px" Height="38px" Text="Print List" CssClass="formbutton" ToolTip="Deactivate product."></asp:button><asp:button id="btnChildName" style="Z-INDEX: 139; LEFT: 56px; POSITION: absolute; TOP: 568px"
				runat="server" BorderColor="Transparent" BorderStyle="None" Width="134px" Height="24px" Text="Child Item Name:" BackColor="White" ForeColor="#2C8AD0" Font-Bold="True" Font-Size="Small"></asp:button><asp:button id="btnChildCode" style="Z-INDEX: 138; LEFT: 56px; POSITION: absolute; TOP: 536px"
				runat="server" BorderColor="Transparent" BorderStyle="None" Width="134px" Height="24px" Text="Child Item Code:" BackColor="White" ForeColor="#2C8AD0" Font-Bold="True" Font-Size="Small"></asp:button><asp:panel id="pnlStock" style="Z-INDEX: -156; LEFT: 440px; POSITION: absolute; TOP: 344px"
				runat="server" BorderStyle="Groove" Width="424px" Height="272px"></asp:panel><asp:label id="lblStockLocation" style="Z-INDEX: 137; LEFT: 480px; POSITION: absolute; TOP: 544px"
				runat="server" Width="116px" Height="16px" CssClass="detaillabel">Location: </asp:label><asp:button id="btnUpdateStock" style="Z-INDEX: 136; LEFT: 752px; POSITION: absolute; TOP: 576px"
				tabIndex="23" runat="server" Width="58px" Height="24px" Text="Update" CssClass="smallformbutton" ToolTip="Add/Update location stock level."></asp:button><asp:label id="lblStockQuantity" style="Z-INDEX: 135; LEFT: 480px; POSITION: absolute; TOP: 576px"
				runat="server" Width="116px" Height="16px" CssClass="detaillabel">New Quantity: </asp:label><asp:label id="lblStock" style="Z-INDEX: 134; LEFT: 448px; POSITION: absolute; TOP: 352px"
				runat="server" Width="408px" Height="24px" CssClass="formlabel">Stock</asp:label><asp:datagrid id="dgStock" style="Z-INDEX: 133; LEFT: 480px; POSITION: absolute; TOP: 384px" tabIndex="1"
				runat="server" BorderColor="#2C8AD0" Width="345px" Height="20px" BackColor="White" ForeColor="Black" HorizontalAlign="Center" PageSize="5" AllowPaging="True" AutoGenerateColumns="False"
				Font-Names="Arial">
				<HeaderStyle Font-Names="Arial" Font-Bold="True" HorizontalAlign="Center" BorderWidth="1px" ForeColor="White"
					BorderStyle="Solid" BorderColor="White" VerticalAlign="Middle" BackColor="#2C8AD0"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="Location" HeaderText="Location">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ShelfQuantity" HeaderText="Quantity">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:button id="btnDeactivate" style="Z-INDEX: 132; LEFT: 552px; POSITION: absolute; TOP: 632px"
				tabIndex="25" runat="server" Width="97px" Height="38px" Text="Deactivate" CssClass="formbutton" ToolTip="Deactivate product."></asp:button><asp:panel id="Panel5" style="Z-INDEX: 102; LEFT: 440px; POSITION: absolute; TOP: 160px" runat="server"
				BorderStyle="Groove" Width="424px" Height="176px"></asp:panel><asp:panel id="Panel4" style="Z-INDEX: -104; LEFT: 440px; POSITION: absolute; TOP: 32px" runat="server"
				BorderStyle="Groove" Width="424px" Height="120px"></asp:panel><asp:panel id="Panel3" style="Z-INDEX: -107; LEFT: 8px; POSITION: absolute; TOP: 472px" runat="server"
				BorderStyle="Groove" Width="424px" Height="232px"></asp:panel><asp:panel id="Panel2" style="Z-INDEX: -109; LEFT: 8px; POSITION: absolute; TOP: 160px" runat="server"
				BorderStyle="Groove" Width="424px" Height="304px"></asp:panel><asp:checkbox id="chkLabel" style="Z-INDEX: 130; LEFT: 480px; POSITION: absolute; TOP: 304px"
				tabIndex="20" runat="server" Width="208px" Height="16px" Text="Print Labels?" CssClass="checkbox" ToolTip="Select if a label should be printed when the item is received."></asp:checkbox><asp:button id="btnName" style="Z-INDEX: 129; LEFT: 56px; POSITION: absolute; TOP: 112px" runat="server"
				BorderColor="Transparent" BorderStyle="None" Width="92px" Height="24px" Text="Item Name:" BackColor="White" ForeColor="#2C8AD0" Font-Bold="True" Font-Size="Small"></asp:button><asp:button id="btnCode" style="Z-INDEX: 128; LEFT: 56px; POSITION: absolute; TOP: 80px" runat="server"
				BorderColor="Transparent" BorderStyle="None" Width="92px" Height="24px" Text="Item Code:" BackColor="White" ForeColor="#2C8AD0" Font-Bold="True" Font-Size="Small"></asp:button><asp:textbox id="txtRRP" style="Z-INDEX: 107; LEFT: 152px; POSITION: absolute; TOP: 296px" tabIndex="6"
				runat="server" BorderColor="LightGray" BorderWidth="3px" BorderStyle="Inset" Width="224px"></asp:textbox><asp:textbox id="txt1stPart" style="Z-INDEX: 127; LEFT: 600px; POSITION: absolute; TOP: 112px"
				tabIndex="17" runat="server" BorderColor="LightGray" BorderWidth="3px" BorderStyle="Inset" Width="200px"></asp:textbox><asp:button id="btnNewSupplier" style="Z-INDEX: 126; LEFT: 808px; POSITION: absolute; TOP: 80px"
				tabIndex="18" runat="server" Width="40px" Height="24px" Text="New" CssClass="smallformbutton" ToolTip="Add a new supplier."></asp:button><asp:button id="btnChildAdd" style="Z-INDEX: 125; LEFT: 352px; POSITION: absolute; TOP: 544px"
				tabIndex="14" runat="server" Width="58px" Height="24px" Text="Add" CssClass="smallformbutton" ToolTip="Add child to child list."></asp:button><asp:button id="btnCancel" style="Z-INDEX: 124; LEFT: 664px; POSITION: absolute; TOP: 632px"
				tabIndex="26" runat="server" Width="88px" Height="38px" Text="Cancel" CssClass="formbutton" ToolTip="Cancel any changes and return to menu."></asp:button><asp:label id="Label19" style="Z-INDEX: 121; LEFT: 48px; POSITION: absolute; TOP: 600px" runat="server"
				Width="137px" Height="16px" CssClass="detaillabel">Quantity per unit:</asp:label><asp:label id="Label3" style="Z-INDEX: 119; LEFT: 16px; POSITION: absolute; TOP: 480px" runat="server"
				Width="408px" Height="24px" CssClass="formlabel">Child Parts</asp:label><asp:label id="Label17" style="Z-INDEX: 117; LEFT: 448px; POSITION: absolute; TOP: 168px" runat="server"
				Width="408px" Height="24px" CssClass="formlabel">Item Notes</asp:label><asp:label id="Label16" style="Z-INDEX: 116; LEFT: 448px; POSITION: absolute; TOP: 40px" runat="server"
				Width="408px" Height="24px" CssClass="formlabel">Supplier</asp:label><asp:label id="Label15" style="Z-INDEX: 115; LEFT: 496px; POSITION: absolute; TOP: 80px" runat="server"
				Width="96px" Height="16px" CssClass="detaillabel">Name: </asp:label><asp:label id="Label14" style="Z-INDEX: 114; LEFT: 24px; POSITION: absolute; TOP: 424px" runat="server"
				Width="193px" Height="16px" CssClass="detaillabel">Minimum Shelf Quantity:</asp:label><asp:label id="Label13" style="Z-INDEX: 113; LEFT: 48px; POSITION: absolute; TOP: 392px" runat="server"
				Width="168px" Height="16px" CssClass="detaillabel">Lead Time (Days): </asp:label><asp:label id="Label12" style="Z-INDEX: 112; LEFT: 48px; POSITION: absolute; TOP: 360px" runat="server"
				Width="168px" Height="16px" CssClass="detaillabel">Pack Quantity: </asp:label><asp:label id="Label11" style="Z-INDEX: 111; LEFT: 48px; POSITION: absolute; TOP: 264px" runat="server"
				Width="96px" Height="16px" CssClass="detaillabel">Cost: </asp:label><asp:label id="Label10" style="Z-INDEX: 110; LEFT: 48px; POSITION: absolute; TOP: 296px" runat="server"
				Width="96px" Height="16px" CssClass="detaillabel">Sale Price: </asp:label><asp:label id="Label9" style="Z-INDEX: 109; LEFT: 24px; POSITION: absolute; TOP: 328px" runat="server"
				Width="193px" Height="16px" CssClass="detaillabel">Minimum Order Quantity: </asp:label><asp:label id="Label8" style="Z-INDEX: 108; LEFT: 456px; POSITION: absolute; TOP: 112px" runat="server"
				Width="138px" Height="16px" CssClass="detaillabel">Supplier Part No.: </asp:label><asp:textbox id="txtCost" style="Z-INDEX: 106; LEFT: 152px; POSITION: absolute; TOP: 264px" tabIndex="5"
				runat="server" BorderColor="LightGray" BorderWidth="3px" BorderStyle="Inset" Width="224px"></asp:textbox><asp:label id="Label5" style="Z-INDEX: 105; LEFT: 48px; POSITION: absolute; TOP: 232px" runat="server"
				Width="96px" Height="16px" CssClass="detaillabel">Category: </asp:label><asp:label id="Label2" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 168px" runat="server"
				Width="408px" Height="24px" CssClass="formlabel">Details</asp:label>&nbsp;&nbsp;
			<asp:label id="Label1" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 40px" runat="server"
				Width="408px" Height="24px" CssClass="formlabel">Item</asp:label><asp:textbox id="txtDescription" style="Z-INDEX: 103; LEFT: 152px; POSITION: absolute; TOP: 200px"
				tabIndex="3" runat="server" BorderColor="LightGray" BorderWidth="3px" BorderStyle="Inset" Width="224px" Font-Size="10pt"></asp:textbox><asp:label id="Label4" style="Z-INDEX: 104; LEFT: 48px; POSITION: absolute; TOP: 200px" runat="server"
				Width="96px" Height="16px" CssClass="detaillabel">Description: </asp:label><asp:checkbox id="chkChild" style="Z-INDEX: 120; LEFT: 32px; POSITION: absolute; TOP: 504px" tabIndex="11"
				runat="server" Width="208px" Height="16px" Text="Contains Child Parts?" CssClass="checkbox" ToolTip="Select if product made up from other items." AutoPostBack="True"></asp:checkbox><asp:listbox id="lstChild" style="Z-INDEX: 122; LEFT: 48px; POSITION: absolute; TOP: 632px" runat="server"
				Width="288px" Height="64px"></asp:listbox><asp:button id="btnSave" style="Z-INDEX: 123; LEFT: 768px; POSITION: absolute; TOP: 632px" tabIndex="27"
				runat="server" Width="88px" Height="38px" Text="Save" CssClass="formbutton" ToolTip="Save changes and return to menu."></asp:button><asp:panel id="Panel1" style="Z-INDEX: -111; LEFT: 8px; POSITION: absolute; TOP: 32px" runat="server"
				BorderStyle="Groove" Width="424px" Height="120px"></asp:panel><asp:button id="btnChildRemove" style="Z-INDEX: 131; LEFT: 344px; POSITION: absolute; TOP: 664px"
				tabIndex="15" runat="server" Height="24px" Width="65px" ToolTip="Remove selected item from child list." CssClass="smallformbutton" Text="Remove"></asp:button>
			<opgeek:ComboBox id="cboCode" style="Z-INDEX: 145; LEFT: 152px; POSITION: absolute; TOP: 80px" runat="server"
				Width="224px"></opgeek:ComboBox></form>
	</body>
</HTML>
