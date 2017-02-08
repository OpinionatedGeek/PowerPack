<%@ Page Language="C#" EnableSessionState="false" debug="true" %>
<%@ Import namespace="System.Security.Cryptography"%>
<%@ Import namespace="OpinionatedGeek.Web.PowerPack"%>
<%@ Register TagPrefix="opgeek" Namespace="OpinionatedGeek.Web.PowerPack" Assembly="OpinionatedGeek.Web.PowerPack"%>
<html>
	<head>
		<title>Licensing Test</title>
	</head>
	<body>
		<h1>
			Licensing Test
		</h1>
		<form name="myForm" runat="server">
			<table border="0">
				<tr>
					<td>Is LocalHost:</td><td><b><%= IsLocalHost () %></b></td>
				</tr>
				<tr>
					<td>Is Local:</td><td><b><%= IsLocal () %></b></td>
				</tr>
				<tr>
					<td>Server:</td><td><b><%= GetRunningServer () %></b></td>
				</tr>
				<tr>
					<td>Machine&nbsp;Name:</td><td><b><%= GetMachineName () %></b></td>
				</tr>
				<tr>
					<td></td><td><b></b></td>
				</tr>
			</table>
			<blockquote>
				<asp:Repeater Runat="server" DataSource="<%# GetConfiguredLicenses () %>">
					<ItemTemplate>
						<p>
							<div runat="server" visible='<%# !Convert.ToBoolean (DataBinder.Eval (Container.DataItem, "Verified")) %>' style="color: red; font-weight: bold;">
								License failed verification!
							</div>
							<table border="0" runat="server" visible='<%# DataBinder.Eval (Container.DataItem, "Verified") %>'>
								<tr>
									<td>Product:</td><td><b><%# DataBinder.Eval (Container.DataItem, "Product") %></b></td>
								</tr>
								<tr>
									<td>Version:</td><td><b><%# DataBinder.Eval (Container.DataItem, "Version") %></b></td>
								</tr>
								<tr>
									<td>Sites:</td><td><b><%# DataBinder.Eval (Container.DataItem, "Hosts") %></b></td>
								</tr>
								<tr>
									<td>Servers:</td><td><b><%# DataBinder.Eval (Container.DataItem, "Servers") %></b></td>
								</tr>
								<tr>
									<td>IDs:</td><td><b><%# DataBinder.Eval (Container.DataItem, "IDs") %></b></td>
								</tr>
								<tr>
									<td>Types:</td><td><b><%# DataBinder.Eval (Container.DataItem, "Types") %></b></td>
								</tr>
								<tr>
									<td>Vendors:</td><td><b><%# DataBinder.Eval (Container.DataItem, "Vendors") %></b></td>
								</tr>
								<tr>
									<td>Purchasers:</td><td><b><%# DataBinder.Eval (Container.DataItem, "Purchasers") %></b></td>
								</tr>
								<tr>
									<td>Raw&nbsp;Data:</td><td><b><%# DataBinder.Eval (Container.DataItem, "LicenseData") %></b></td>
								</tr>
							</table>
						</p>
					</ItemTemplate>
				</asp:Repeater>
			</blockquote>
		</form>
	</body>
</html>
<script language="C#" runat="server">
	private const string PUBLIC_KEY = ""; // Removed from 2017 publication.
	private const string DATA_SIGNATURE_SEPARATOR = "~";
	private const string TITLE_VALUE_SEPARATOR = ":";
	private const string VALUE_SEPARATOR = ";";

	protected override void OnLoad (EventArgs e)
	{
		base.OnLoad (e);
		
		DataBind ();
		
		return;
	}

	protected string GetRunningServer ()
	{
		string szRunningServer = null;
		if (HttpContext.Current != null)
		{
			szRunningServer = HttpContext.Current.Request.Url.Host.ToLower ();
		}

		return szRunningServer;
	}

	protected string GetMachineName ()
	{
		string szMachine = null;
		if (HttpContext.Current != null)
		{
			szMachine = HttpContext.Current.Server.MachineName.ToLower ();
		}

		return szMachine;
	}

	protected bool IsLocal ()
	{
		bool nIsLocal = false;
		if (GetRunningServer ().IndexOf ('.') == -1)
		{
			nIsLocal = true;
		}

		return nIsLocal;
	}

	protected bool IsLocalHost ()
	{
		bool nIsLocalHost = false;
		string szServer = GetRunningServer ();
		if ((szServer == "localhost") || (szServer == "127.0.0.1"))
		{
			nIsLocalHost = true;
		}

		return nIsLocalHost;
	}

	private Details [] GetConfiguredLicenses ()
	{
        PowerPackConfigurationSection cnvcLicenseConfiguration = ConfigurationSettings.GetConfig ("OpinionatedGeek.Web.PowerPack") as PowerPackConfigurationSection;
		string [] aszLicenses = null;
		if (cnvcLicenseConfiguration == null)
		{
            string szConfigLicense = cnvcLicenseConfiguration ["License"];
			if (szConfigLicense != null)
			{
				aszLicenses = new string [] {szConfigLicense};
			}
		}
		else
		{
			aszLicenses = cnvcLicenseConfiguration.GetCompoundValue ("License");
		}

		Details [] allDetails = new Details [aszLicenses.Length];
		for (int counter = 0; counter < aszLicenses.Length; counter++)
		{
			allDetails [counter] = GetDetails (aszLicenses [counter]);
		}

		return allDetails;
	}

	protected Details GetDetails (string licenseData)
	{
		Details license = new Details ();
		license.LicenseData = licenseData;
		CspParameters cp = new CspParameters();
		cp.Flags = CspProviderFlags.UseMachineKeyStore;
		RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);
		rsa.PersistKeyInCsp = false;
		rsa.FromXmlString (PUBLIC_KEY);

		string szLicense = licenseData;
		string szDataPart = szLicense.Substring (0, szLicense.IndexOf (DATA_SIGNATURE_SEPARATOR));
		string szSignaturePart = szLicense.Substring (szLicense.IndexOf (DATA_SIGNATURE_SEPARATOR) + 1);
		byte [] abSignedText = Convert.FromBase64String (szDataPart);
		byte [] abSignature = Convert.FromBase64String (szSignaturePart);

		license.Verified = rsa.VerifyData (abSignedText, "MD5", abSignature);

		if (license.Verified)
		{
			UTF8Encoding utf8 = new UTF8Encoding ();
			string szPlaintext = utf8.GetString (abSignedText);
			string [] aszLicenseDetails = szPlaintext.Split (VALUE_SEPARATOR.ToCharArray ());

			string szNormalisedElement;
			foreach (string szElement in aszLicenseDetails)
			{
				szNormalisedElement = szElement.Trim ();
				if (!String.IsNullOrEmpty (szNormalisedElement))
				{
					string szTitle = szNormalisedElement.Substring (0, szNormalisedElement.IndexOf (TITLE_VALUE_SEPARATOR));
					string szValue = szNormalisedElement.Substring (szNormalisedElement.IndexOf (TITLE_VALUE_SEPARATOR) + 1);
					switch (szTitle)
					{
						case "Product":
							license.Product = szValue;
							break;

						case "Version":
							license.Version = szValue;
							break;

						case "Hosts":
							license.Hosts = szValue;
							break;
	                        
						case "Servers":
							license.Servers = szValue;
							break;

						case "Ids":
							license.IDs = szValue;
							break;

						case "Types":
							license.Types = szValue;
							break;

						case "Vendors":
							license.Vendors = szValue;
							break;

						case "Purchasers":
							license.Purchasers = szValue;
							break;

						default:
							throw new ArgumentException ("Unknown encrypted data type", szTitle);
					}
				}
			}
		}

		rsa.Clear ();

		return license;
	}
	
	public class Details
	{
		private string _product;
		private string _version;
		private string _hosts;
		private string _servers;
		private string _ids;
		private string _types;
		private string _vendors;
		private string _purchasers;
		private string _licenseData;
		private bool _verified = false;

		public string Product
		{
			get
			{
				return _product;
			}
			set
			{
				_product = value;
				
				return;
			}
		}

		public string Version
		{
			get
			{
				return _version;
			}
			set
			{
				_version = value;
				
				return;
			}
		}

		public string Hosts
		{
			get
			{
				return _hosts;
			}
			set
			{
				_hosts = value;
				
				return;
			}
		}

		public string Servers
		{
			get
			{
				return _servers;
			}
			set
			{
				_servers = value;
				
				return;
			}
		}

		public string LicenseData
		{
			get
			{
				return _licenseData;
			}
			set
			{
				_licenseData = value;
				
				return;
			}
		}

		public bool Verified
		{
			get
			{
				return _verified;
			}
			set
			{
				_verified = value;
				
				return;
			}
		}

		public string IDs
		{
			get
			{
				return _ids;
			}
			set
			{
				_ids = value;
				
				return;
			}
		}

		public string Types
		{
			get
			{
				return _types;
			}
			set
			{
				_types = value;
				
				return;
			}
		}

		public string Vendors
		{
			get
			{
				return _vendors;
			}
			set
			{
				_vendors = value;
				
				return;
			}
		}

		public string Purchasers
		{
			get
			{
				return _purchasers;
			}
			set
			{
				_purchasers = value;

				return;
			}
		}
	}
</script>
