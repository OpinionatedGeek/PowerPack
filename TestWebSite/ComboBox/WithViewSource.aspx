<%@ Page Language="C#" debug=true%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<%@ Register TagPrefix="site" Namespace="OpinionatedGeek.Site" Assembly="App_code"%>
<html>
	<head>
		<title>ComboBox tests</title>
	</head>
	<body>
		<h1>
			ComboBox Tests
		</h1>
	    <form runat="server">
            <h3>PowerPack ComboBox Control</h3>
            <p>
                This control will allow you to pick from any of the listed items, <b>or</b> it will
                allow you to type in a new value.
            </p>
            <blockquote>
                <b>
                    <opgeek:ComboBox id="cbDemoCombo" runat="server" midtext="<br>or<br>">
                        <asp:listitem Text="Homer" />
                        <asp:listitem Text="Marge" />
                        <asp:listitem Text="Bart" />
                        <asp:listitem Text="Lisa" />
                        <asp:listitem Text="Maggie" />
                    </opgeek:ComboBox>
                    <p>
                        <asp:Button runat="server" id="submit_button" Text="Test!" />
                        <br />
                        ComboBox value:
                        <%=cbDemoCombo.SelectedItem == null ? "" : cbDemoCombo.SelectedItem.Text%>
                    </p>
                </b>
            </blockquote>
            <h3>Default HTML Control</h3>
            <p>
                Contrast the ASP.NET PowerPack ComboBox control with the default HTML control below.
                This default HTML control will only allow you to pick from any of the listed items.  If you need to enter
                a new value - you can't!
            </p>
            <blockquote>
                <b>
                    <asp:DropDownList id="ddDefault" runat="server">
                        <asp:listitem Text="Homer" />
                        <asp:listitem Text="Marge" />
                        <asp:listitem Text="Bart" />
                        <asp:listitem Text="Lisa" />
                        <asp:listitem Text="Maggie" />
                    </asp:DropDownList>
                    <br />
                    <asp:Button runat="server" id="submit_button2" Text="Test!" />
                    <br />
                    DropDown value:
                    <%=ddDefault.SelectedItem == null ? "" : ddDefault.SelectedItem.Text%>
                </b>
            </blockquote>
    	    <site:ViewSource runat="server"/>
	    </form>
	</body>
</html>
