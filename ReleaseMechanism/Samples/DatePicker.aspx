<%@ Page Language="C#" MasterPageFile="./Master.master" %>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<asp:content ID="titleContent" contentplaceholderid="titlePlaceHolder" runat="server">
    A complete DHTML DatePicker!
</asp:content>
<asp:content ID="bodyContent" contentplaceholderid="bodyPlaceHolder" runat="server">
	<h2>
		ASP.NET PowerPack DatePicker Control
	</h2>
	
	<p>
		This control allows you to pick a single date using a GUI-like control.  This control looks
		much neater on a web form than the default .NET calendar control.
	</p>
	<p>
		<opgeek:DatePicker id="dpSample" firstyear="2000" lastyear="2004" runat="server" />
	</p>
	<p>
		<input type="submit" runat="server" value="Test DatePicker!" ID="butSubmit" />
	</p>
	<%if (Request.Form ["dpSample"] != null) {%>
		<p>
			You picked date: <b><%=dpSample.Value.ToString ("dddd, d MMMM yyyy")%></b>
		</p>
	<%}%>
</asp:content>